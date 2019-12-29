*** Function: use Web Service interface to get data for Patients in XML format.
*** Updated By   :  Samuel Leung
*** Updated At   :  20-03-2017
*** Version No.  :  1.0
*** Program Tool :  VFP 9.0
***
*** Steps:
***    1) Pass the Doctor ID to call the Web Service interface
***    2) Doctor ID :  field name in LIS "doctor_id" Char(5) = "doctor_code" Char(5) column name in HIS SQL table

=GET_DOCTOR(.T. , doctor.doctor_id , .T.)
RETURN


PROCEDURE GET_DOCTOR
PARAMETER p_updall, p_drcode, p_silentupd
LOCAL _cursel, _used_webservice
_cursel = SELECT()
_updsqlok = .F.
_sqlerr   = .F.
_doctorctr = 0
_used_webservice = .T.

IF _used_webservice = .T.
  IF NOT FILE("XMLDoctor.DBF") OR FDATE("XMLDoctor.DBF") <> DATE()
    DO ws_get_doctor
  ENDIF
  IF USED("sql_doctor")
    USE IN sql_doctor
  ENDIF
  IF FILE("XMLDoctor.DBF")
    _connhandle = 1
    _success = 1
    SELECT IIF(doctor_cod>9999,RIGHT("00000"+TRAN(doctor_cod),5),RIGHT("0000"+TRAN(doctor_cod),4)+space(1)) AS doctor_code,;
           doctor_sur AS doctor_surname, doctor_giv AS doctor_givenname, doctor_chi AS doctor_chiname, doctor_sta AS doctor_status,;
           mobile_pho AS mobile_phone, pager, office_pho AS office_phone, office_fax, address1, address2, address3, address4,;
           CTOT(SUBSTR(TRANS(lastupdate),7,2)+"/"+SUBSTR(TRANS(lastupdate),5,2)+"/"+SUBSTR(TRANS(lastupdate),1,4) + ; 
           " " + SUBSTR(TRANS(lastupdate),9,2)+":"+SUBSTR(TRANS(lastupdate),11,2)+":"+SUBSTR(TRANS(lastupdate),13,2)) AS lastupdate;
           FROM XMLDoctor ORDER BY doctor_code INTO CURSOR sql_doctor
    USE IN XMLDoctor
  ELSE
    _connhandle = -1
    _success = -1
  ENDIF
ENDIF

IF _connhandle > 0
  IF _success > 0
    SELECT doctor
    _dorcor_curtag = ORDER()
    SET ORDER TO TAG doctor_id
    SELECT sql_doctor
    GO TOP
    IF p_updall = .F.
      LOCATE FOR doctor_code = p_drcode
    ENDIF
    DO WHILE NOT EOF()
      IF _used_webservice = .F.
        DO chk_null
      ENDIF
      SCATTER MEMVAR MEMO
      IF TYPE("m.lastupdate") <> "T"
        m.lastupdate = CTOT("")
      ENDIF
      * here DO NOT update doctor's English name because in Medlab, it will be added ", DR." at the end.
      _dr_engname = ALLTRIM(m.doctor_surname)+' '+ALLTRIM(m.doctor_givenname)+', DR.'
      _dr_chiname = ALLTRIM(m.doctor_chiname)
      _dr_chiname = IIF("醫生" $ _dr_chiname, _dr_chiname, _dr_chiname+"醫生")
      SELECT doctor
      SEEK m.doctor_code
      IF FOUND() and not EMPTY(m.doctor_code)
        _old_sql_phone = sql_mobile + sql_pager + sql_phone + sql_fax
        _old_sql_addr  = sql_addr1  + sql_addr2 + sql_addr3 + sql_addr4
        _new_sql_phone = m.mobile_phone + m.pager + m.office_phone + m.office_fax
        _new_sql_addr  = m.address1 + m.address2 + m.address3 + m.address4
        IF _old_sql_phone # _new_sql_phone OR _old_sql_addr # _new_sql_addr
          _updsqlok = .T.
          _doctorctr = _doctorctr + 1
          WAIT WINDOW NOWAIT CHR(13) + SPACE(3) + TRAN(_doctorctr) + " )  " + "Updating  Doctor :  " + ALLTRIM(doctor) + SPACE(3) + CHR(13)
          DO WHILE NOT RLOCK()
          ENDDO
          IF NOT EMPTY(_dr_chiname) AND _dr_chiname <> "醫生"
            REPLACE cname WITH _dr_chiname
          ENDIF
          REPLACE sql_sname  WITH ALLTRIM(m.doctor_surname), sql_gname WITH ALLTRIM(m.doctor_givenname) ,;
                  sql_mobile WITH ALLTRIM(m.mobile_phone),   sql_pager WITH ALLTRIM(m.pager) ,;
                  sql_phone  WITH ALLTRIM(m.office_phone),   sql_fax   WITH ALLTRIM(m.office_fax) ,;
                  sql_update WITH m.lastupdate
          IF _old_sql_addr # _new_sql_addr
            REPLACE address1   WITH ALLTRIM(m.address1),     address2  WITH ALLTRIM(m.address2) ,;
                    address3   WITH ALLTRIM(m.address3),     address4  WITH ALLTRIM(m.address4) ,;
                    sql_addr1  WITH ALLTRIM(m.address1),     sql_addr2 WITH ALLTRIM(m.address2) ,;
                    sql_addr3  WITH ALLTRIM(m.address3),     sql_addr4 WITH ALLTRIM(m.address4)
          ENDIF
          UNLOCK
        ENDIF
      ENDIF
      IF p_updall = .F.
        EXIT
      ENDIF
      SELECT sql_doctor
      SKIP
    ENDDO
    IF _updsqlok = .T. 
      STRTOFILE(TTOC(DATETIME())+", Updated Doctors: "+TRAN(_doctorctr)+CHR(13)+CHR(10), "sqlupddoctor.txt" , .T.)
    ENDIF
    SELECT doctor
    IF _updsqlok = .T. and CURSORGETPROP("Buffering") <> 1
      TABLEUPDATE(.T.)
    ENDIF
    SET ORDER TO (_dorcor_curtag)
    USE IN sql_doctor
  ELSE
    _sqlerr = .T.
  ENDIF
ELSE
  _sqlerr = .T.
ENDIF
SELECT (_cursel)
WAIT CLEAR
CLEAR TYPEAHEAD
RETURN


PROCEDURE chk_null
** avoid null value error, replace it with empty value first.
FOR j = 1 TO FCOUNT()
  zfldname = FIELD(j)
  IF ISNULL(&zfldname)
    DO CASE
    CASE TYPE(zfldname) $ 'C'          && character/character(binary)
      REPLACE &zfldname WITH ''
    CASE TYPE(zfldname) $ 'NY'         && numeric/float/integer/currency=Y
      REPLACE &zfldname WITH 0
    CASE TYPE(zfldname) $ 'DT'         && date/datetime
      REPLACE &zfldname WITH CTOD('')
    CASE TYPE(zfldname) $ 'L'          && logical
      REPLACE &zfldname WITH .F.
    ENDCASE
  ENDIF
NEXT
RETURN


** use Web Service to get data for Patients & Doctors in XML format.
PROCEDURE ws_get_doctor
LOCAL oProxy, _WS_success, _WS_errmsg, _XML_str, _XML_str_DByte, _XML_str_UTF8
xws_server = "http://sthweb/Histology/ws/HistologyWebservice.asmx?wsdl"
xws_user   = "HISTOUSER"
xws_pswd   = "HISTO"
_WS_svr_type = IIF(xws_pswd = "TEST", "< Testing Server > !!!" , "< Production Server > !!!")
_WS_url  = xws_server
_WS_user = xws_user
_WS_pswd = xws_pswd
_WS_Err = .F.
oProxy.MSSoapInit(_WS_url)
IF TYPE("oProxy") <> "O"
  _WS_Err = .T.
ENDIF
IF _WS_Err = .T.
  RETURN .F.
ENDIF
_XML_result = oProxy.getDoctor(_WS_user , _WS_pswd)
IF TYPE("_XML_result") <> "C"
  _WS_Err = .T.
ELSE
  _WS_Err = .F.
ENDIF
RELEASE oProxy
IF USED("XMLDoctor")
  USE IN XMLDoctor
ENDIF
_XML_result2 = STREXTRACT(_XML_result, "<Histo_Doctor>" , "</NewDataSet>" )
_XML_result2 = "  <Histo_Doctor>" + _XML_result2
_XML_result2 = "<Result>" +CHR(13)+CHR(10)+ _XML_result2 + "</Result>"
STRTOFILE(STRCONV(_XML_result2,9), "XMLdoctor.XML")
IF NOT "</Histo_Doctor>" $ _XML_result2
  MESSAGEBOX(" Doctor Is Not Found From Web Service Gateway !", 48, "Doctor Not Found")
  RETURN
ENDIF
XMLTOCURSOR("XMLdoctor.XML", "XMLDoctor", 512)
IF USED("XMLDoctor")      
  SELECT XMLDoctor
  COPY TO XMLDoctor.DBF
  USE
ENDIF
_WS_success = IIF("<Status>1" $ _XML_result , .T. , .F.)
*** STATUS: 1 = Successful , 2 = Failure 
*** STAUTS_DESC: Blank if successful or Descriptive Reason if failure
IF _WS_success = .F.
  MESSAGEBOX("Warning : " +CHR(13)+"Unable To Get Doctor Records From W.S. getDoctor" +CHR(13)+ ;
             ">>> Please Call Technical Support For Help.", 16, "Upload Failed !")
  ENDIF
ENDIF
RETURN _WS_success
****** =========================== End Of Function =========================== ******


*** below is an example of the converted XML file content made by above step.
TEXT

<Result>
  <Histo_Doctor>
    <Doctor_Code>0002</Doctor_Code>
    <Doctor_Surname>AU                            </Doctor_Surname>
    <Doctor_Givenname>KOK KI</Doctor_Givenname>
    <Doctor_Chiname>區國基</Doctor_Chiname>
    <Doctor_Status>2</Doctor_Status>
    <Mobile_Phone>8128 8802</Mobile_Phone>
    <Pager>7116 3311-969</Pager>
    <Office_Phone>2388 9885</Office_Phone>
    <Office_Fax>2384 0461</Office_Fax>
    <Address1>ROOM 707,</Address1>
    <Address2>CHAMPION BLDG.,</Address2>
    <Address3>301-309, NATHAN RD.,</Address3>
    <Address4>KOWLOON</Address4>
    <LastUpdate>2011-08-15 15:37:34</LastUpdate>
    <LastUpdate>20110916095048</LastUpdate>
  </Histo_Doctor>
  <Histo_Doctor>
    <Doctor_Code>0007</Doctor_Code>
    <Doctor_Surname>AU                            </Doctor_Surname>
    <Doctor_Givenname>WAI MAN</Doctor_Givenname>
    <Doctor_Chiname>歐偉民</Doctor_Chiname>
    <Doctor_Status>4</Doctor_Status>
    <Mobile_Phone xml:space="preserve"> </Mobile_Phone>
    <Pager xml:space="preserve"> </Pager>
    <Office_Phone xml:space="preserve"> </Office_Phone>
    <Office_Fax xml:space="preserve"> </Office_Fax>
    <Address1 />
    <Address2 />
    <Address3 />
    <Address4 xml:space="preserve"> </Address4>
    <LastUpdate>20110917130942</LastUpdate>
  </Histo_Doctor>
  <Histo_Doctor>
    <Doctor_Code>3320</Doctor_Code>
    <Doctor_Surname>LI                            </Doctor_Surname>
    <Doctor_Givenname>KA MING VICKY (f)</Doctor_Givenname>
    <Doctor_Chiname>李家明</Doctor_Chiname>
    <Doctor_Status>2</Doctor_Status>
    <Mobile_Phone>9681 7751/65079893</Mobile_Phone>
    <Office_Phone>3417 4179</Office_Phone>
    <Office_Fax>3417 4189</Office_Fax>
    <Address1>C/O WELLXIM`S MEDICAL CENTRE</Address1>
    <Address2>FLAT B06A, G/F,PARK CENTRAL,</Address2>
    <Address3>9 TONG TAK STREET,</Address3>
    <Address4>TSEUNG KWAN O, N.T.</Address4>
    <LastUpdate>20110914120722</LastUpdate>
  </Histo_Doctor>
</Result>

ENDTEXT
