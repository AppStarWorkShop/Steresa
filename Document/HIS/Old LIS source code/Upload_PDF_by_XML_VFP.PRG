*** Function: Upload Histology PDF Reports to STH Server in XML format by using Web Service
*** Updated By   :  Samuel Leung
*** Updated At   :  20-03-2017
*** Version No.  :  1.0
*** Program Tool :  VFP 9.0
***
*** Steps:
***    1) Firstly auto-generate the PDF report files whenever the Histology reports are printed at the same time.
***    2) The PDF report files are saved at current sub-folder "PDFfiles"
***    3) Convert the PDF report files (Base64 Encoded Binary) to XML format in UTF-8 and saved at current sub-folder "XML"
***    4) Upload the converted XML to STH back-end server using Web Service interface provided by STH IT Dept.

_pdf_file = ALLTRIM(temp_sql.barcode) + ".PDF"
_pdf_str  = FILETOSTR("PDFfiles\" + _pdf_file)
_status1  = PDF_TO_XML(temp_sql.case_no, temp_sql.barcode, temp_sql.ver, _pdf_str)
_xml_file = "XML\" + ALLTRIM(temp_sql.barcode) + ".xml"
_status2  = UPLOAD_TO_STH(_xml_file, temp_sql.case_no)
RETURN


PROCEDURE PDF_TO_XML
LPARAMETER _case_no, _barcode, _ver, _pdf_str
THISFORM.action_button.upload_btn.ENABLED = .F.
_old_memowidth = SET('MemoWidth')
SET MEMOWIDTH TO 8192
** Record Type:
** 01 - Histopathology Report
** 02 - EBV Serology Report
** 03 - Cytology Report
** 04 - Gynecological(Cytology) Report
IF NOT USED('doctor')
  USE doctor ORDER TAG doctor_id IN 0
ENDIF
IF NOT USED('diagnosis')
  USE diagnosis ORDER TAG diagnosis IN 0
ENDIF
IF NOT USED('bxcy_diag')
  USE bxcy_diag ORDER TAG case_no IN 0
ENDIF
IF NOT USED('ebv_specimen')
  USE ebv_specimen IN 0
ENDIF
IF NOT USED('bxcy_specimen')
  USE bxcy_specimen IN 0
ENDIF
SELECT ebv_specimen
SET ORDER TO TAG case_no
SELECT bxcy_specimen
SET ORDER TO TAG case_no
*
_linefeed = CHR(13)+CHR(10)
_upload_ctr = 0

DO centermsg WITH "Generating  XML  File  For  Case  No. :  " + ALLTRIM(_case_no) + "  ......"
DO CASE
CASE LEFT(ALLTRIM(_case_no),2) $ "BX,MP"
  _rec_type = "01"
CASE LEFT(ALLTRIM(_case_no),1) $ "S,H,T"
  _rec_type = "02"
CASE LEFT(ALLTRIM(_case_no),2) = "CY"
  _rec_type = "03"
CASE LEFT(ALLTRIM(_case_no),2) = "CY" AND RIGHT(ALLTRIM(_case_no),1) = "G"
  _rec_type = "04"
OTHERWISE
  _rec_type = "??"
ENDCASE
SELECT temp_sql
REPLACE rec_type WITH _rec_type
IF _rec_type = "02"
  SELECT ebv_specimen
ELSE
  SELECT bxcy_specimen
ENDIF
SEEK _case_no
IF FOUND()
  STORE SPACE(0) TO _sub_dr1_code, _sub_dr2_code, _sub_dr3_code, _sub_dr4_code, _sub_dr5_code
  STORE SPACE(0) TO _sub_dr1_name, _sub_dr2_name, _sub_dr3_name, _sub_dr4_name, _sub_dr5_name
  STORE SPACE(0) TO _diag1, _diag2, _diag3, _diag4, _diag5, _diag6, _diag7, _diag8, _diag9
  SCATTER MEMVAR MEMO
  =SEEK(doctor_id, "doctor", "doctor_id")
  _action   = "A"
  _barcode  = ALLTRIM(_barcode)
  _hosp_no  = ALLTRIM(lab_ref)
  _part_no  = RIGHT(ALLTRIM(_barcode),1)
  _ver_no   = _ver
  _sign_dr  = ALLTRIM(sign_dr)
  _rpt_date = DTOC(rpt_date)
  _pat_hist = pat_hist
  _pat_hist = _pat_hist + SPACE(1)
  _main_dr_code = LEFT(doctor_id,4)
  _main_dr_name = ALLTRIM(doctor.sql_sname) + " " + ALLTRIM(doctor.sql_gname)
  IF EMPTY(_main_dr_code)
    _main_dr_name = ALLTRIM(doctor_ic)
    _main_dr_name = STRTRAN(_main_dr_name, ", DR." , "")
    _main_dr_name = STRTRAN(_main_dr_name, ",DR." , "")
    _main_dr_name = STRTRAN(_main_dr_name, "DR." , "")
  ENDIF
  _other_drname = ALLTRIM(doctor_o)
  _sub_dr_ctr = 1
  DO WHILE NOT EMPTY(_other_drname) AND _sub_dr_ctr <= 5
    _sub_dr_code_seq = "_sub_dr" + STR(_sub_dr_ctr,1) + "_code"
    _sub_dr_name_seq = "_sub_dr" + STR(_sub_dr_ctr,1) + "_name"
    IF "/" $ _other_drname
      _sub_dr_str = ALLTRIM(SUBSTR(_other_drname, 1, AT("/",_other_drname)-1))
    ELSE
      _sub_dr_str = ALLTRIM(_other_drname)
    ENDIF
    ** firstly cut away the extra marker, if any
    IF SUBSTR(_sub_dr_str, LEN(_sub_dr_str)-5, 1) = "(" AND RIGHT(_sub_dr_str, 1) = ")"
      &_sub_dr_code_seq = SUBSTR(_sub_dr_str, LEN(_sub_dr_str)-4, 4)
      IF SEEK(&_sub_dr_code_seq+SPACE(1), "doctor", "doctor_id")
        &_sub_dr_name_seq = ALLTRIM(doctor.sql_sname) + " " + ALLTRIM(doctor.sql_gname)
      ELSE
        &_sub_dr_name_seq = ALLTRIM(SUBSTR(_sub_dr_str, 1, LEN(_sub_dr_str)-6))
        &_sub_dr_name_seq = STRTRAN(&_sub_dr_name_seq, ", DR." , "")
        &_sub_dr_name_seq = STRTRAN(&_sub_dr_name_seq, ",DR." , "")
        &_sub_dr_name_seq = STRTRAN(&_sub_dr_name_seq, "DR." , "")
      ENDIF
    ELSE
      &_sub_dr_code_seq = SPACE(0)
      &_sub_dr_name_seq = _sub_dr_str
      &_sub_dr_name_seq = STRTRAN(&_sub_dr_name_seq, ", DR." , "")
      &_sub_dr_name_seq = STRTRAN(&_sub_dr_name_seq, ",DR." , "")
      &_sub_dr_name_seq = STRTRAN(&_sub_dr_name_seq, "DR." , "")       
    ENDIF
    IF "/" $ _other_drname
      _other_drname = ALLTRIM(SUBSTR(_other_drname, AT("/",_other_drname)+1, 999))
    ELSE
      EXIT
    ENDIF
    _sub_dr_ctr = _sub_dr_ctr + 1
  ENDDO

  IF _rec_type = "02"
    =SEEK(ebv_specimen.diagnosis, "diagnosis" , "diagnosis")
    _diag1 = diagnosis.desc
  ELSE
    ** IMPORTANT: record data MUST BE uploaded with the current record version of specified barcode
    _diagctr = 0
    _max_group = RIGHT(ALLTRIM(_barcode),1)
    SELECT bxcy_diag
    SET ORDER TO TAG case_no
    SEEK _case_no
    SCAN WHILE case_no = _case_no
      IF group = _max_group
        _diagctr  = _diagctr + 1
        _diagdtl  = "_diag" + TRAN(_diagctr)
        &_diagdtl = &_diagdtl + IIF(EMPTY(seq), SPACE(0) , ALLTRIM(seq)+SPACE(1))
        &_diagdtl = &_diagdtl + ALLTRIM(site)+IIF(EMPTY(site), '' , ', ') + ALLTRIM(operation)
        &_diagdtl = &_diagdtl + IIF(EMPTY(&_diagdtl), '' , _linefeed)
        _diagnosis = memotext2(diagnosis)      && cut-off all leading or tailing blank lines of Memo field
        IF NOT EMPTY(_diagnosis)
          _memolines = MEMLINES(_diagnosis)
          FOR _linectr = 1 TO _memolines
            &_diagdtl = &_diagdtl + SPACE(0) + MLINE(_diagnosis, _linectr) + _linefeed
          NEXT
        ENDIF
        &_diagdtl = &_diagdtl + SPACE(0) + ALLTRIM(site2)+IIF(EMPTY(site2), '' , ', ')  + ALLTRIM(operation2)
        &_diagdtl = &_diagdtl + IIF(EMPTY(diag_desc1), '' , _linefeed + SPACE(0) + '- ' + ALLTRIM(diag_desc1) )
        &_diagdtl = &_diagdtl + IIF(EMPTY(diag_desc2), '' , _linefeed + SPACE(0) + '- ' + ALLTRIM(diag_desc2) )
        &_diagdtl = &_diagdtl + IIF(EMPTY(&_diagdtl), '' , SPACE(1))
        IF _diagctr >= 9     && only allow maximum 9 diagnosis fields in STH's SQL table
          EXIT
        ENDIF
      ENDIF
    ENDSCAN
  ENDIF
  IF NOT DIRECTORY("XML")
    MD XML
  ENDIF
  _xml_file = "XML\" + ALLTRIM(_barcode) + ".xml"
  STRTOFILE('<?xml version="1.0" encoding="utf-8"?>' + _linefeed , _xml_file)
  STRTOFILE('<Histology_PDF>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(2) + '<Record Path_No="' + ALLTRIM(_case_no) + '">' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Visit_No>' + _hosp_no + '</Visit_No>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Part_No>' + _part_no + '</Part_No>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Version_No>' + _ver_no + '</Version_No>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Tx_Type>' + _action + '</Tx_Type>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Report_Type_Code>' + _rec_type + '</Report_Type_Code>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Report_DT>' + _rpt_date + '</Report_DT>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Order_Doctor_Code>' + _main_dr_code + '</Order_Doctor_Code>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Order_Doctor_Name>' + _main_dr_name + '</Order_Doctor_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy1_Doctor_Code>' + _sub_dr1_code + '</Copy1_Doctor_Code>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy1_Doctor_Name>' + _sub_dr1_name + '</Copy1_Doctor_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy2_Doctor_Code>' + _sub_dr2_code + '</Copy2_Doctor_Code>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy2_Doctor_Name>' + _sub_dr2_name + '</Copy2_Doctor_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy3_Doctor_Code>' + _sub_dr3_code + '</Copy3_Doctor_Code>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy3_Doctor_Name>' + _sub_dr3_name + '</Copy3_Doctor_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy4_Doctor_Code>' + _sub_dr4_code + '</Copy4_Doctor_Code>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy4_Doctor_Name>' + _sub_dr4_name + '</Copy4_Doctor_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy5_Doctor_Code>' + _sub_dr5_code + '</Copy5_Doctor_Code>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Copy5_Doctor_Name>' + _sub_dr5_name + '</Copy5_Doctor_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Approved_Doctor_Name>' + _sign_dr   + '</Approved_Doctor_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Clinical_History>' + _pat_hist + '</Clinical_History>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis1>' + _diag1 + '</Diagnosis1>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis2>' + _diag2 + '</Diagnosis2>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis3>' + _diag3 + '</Diagnosis3>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis4>' + _diag4 + '</Diagnosis4>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis5>' + _diag5 + '</Diagnosis5>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis6>' + _diag6 + '</Diagnosis6>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis7>' + _diag7 + '</Diagnosis7>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis8>' + _diag8 + '</Diagnosis8>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<Diagnosis9>' + _diag9 + '</Diagnosis9>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<File_Name>' + _hosp_no + ALLTRIM(_barcode) + "-" + _ver_no + '.pdf</File_Name>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(4) + '<File_Content>' + _pdf_str + '</File_Content>' + _linefeed , _xml_file , .T.)
  STRTOFILE(SPACE(2) + '</Record>' + _linefeed , _xml_file , .T.)
  STRTOFILE('</Histology_PDF>' + _linefeed , _xml_file , .T.)
  _xml_str = FILETOSTR(_xml_file)
  _xml_str_utf8 = STRCONV(_xml_str,9)
  STRTOFILE(_xml_str_utf8, _xml_file)
ENDIF
WAIT CLEAR
CLEAR TYPEAHEAD
SET MEMOWIDTH TO _old_memowidth
RETURN


PROCEDURE UPLOAD_TO_STH
** WSDL for Testing:
** IP: 192.168.10.85 ==> WS server location: sthwebdev / user: HISTOUSER / login: TEST
** WSDL for Production:
** IP: 192.168.10.83 ==> WS server location: sthweb    / user: HISTOUSER / login: HISTO
LPARAMETER _XML_file, _case_no
LOCAL oProxy, _WS_success, _WS_errmsg, _XML_str, _XML_str_DByte, _XML_str_UTF8
xws_server = "http://sthweb/Histology/ws/HistologyWebservice.asmx?wsdl"
xws_user   = "HISTOUSER"
xws_pswd   = "HISTO"
&& firstly convert the UTF-8 XML to double-byte Chinese characters
_XML_str_UTF8 = FILETOSTR(_XML_file)
_XML_str_DByte = STRCONV(_XML_str_UTF8, 11)
_XML_str  = _XML_str_DByte
_WS_svr_type = IIF(xws_pswd = "TEST", "< Testing Server > !!!" , "< Production Server > !!!")
_WS_url  = xws_server
_WS_user = xws_user
_WS_pswd = xws_pswd
oWS_Err = NULL
_WS_Err = .F.
_WS_Err = oProxy.MSSoapInit(_WS_url)
IF _WS_Err = .T.
  RETURN .F.
ENDIF
_XML_result = oProxy.updateResult(_WS_user , _WS_pswd , _XML_str)
STRTOFILE(_XML_result, "ws_result.xml")
_WS_success = IIF("<Status>1" $ _XML_result , .T. , .F.)
*** STATUS: 1 = Successful , 2 = Failure 
*** STAUTS_DESC: Blank if successful or Descriptive Reason if failure
RETURN _WS_success
