*** Function: use Web Service interface to get data for Patients in XML format.
*** Updated By   :  Samuel Leung
*** Updated At   :  20-03-2017
*** Version No.  :  1.0
*** Program Tool :  VFP 9.0
***
*** Steps:
***    1) Pass the Hospital No. to call the Web Service interface
***    2) Hospital No. :  field name in LIS "lab_ref" Char(30) = "visit_no" Char(13) column name in HIS SQL table

=GET_PATIENT(LEFT(bxcy_specimen.lab_ref,13) , .F.)
RETURN


PROCEDURE GET_PATIENT
LPARAMETER _hosp_no, _silentupd
LOCAL oProxy, _WS_success, _WS_errmsg, _XML_str, _XML_str_DByte, _XML_str_UTF8
xws_server = "http://sthweb/Histology/ws/HistologyWebservice.asmx?wsdl"
xws_user   = "HISTOUSER"
xws_pswd   = "HISTO"
_WS_svr_type = IIF(xws_pswd = "TEST", "< Testing Server > !!!" , "< Production Server > !!!")
_WS_url  = xws_server
_WS_user = xws_user
_WS_pswd = xws_pswd
_WS_Err = .F.
_WS_Err = oProxy.MSSoapInit(_WS_url)
oProxy.MSSoapInit(_WS_url)
IF TYPE("oProxy") <> "O"
  _WS_Err = .T.
ENDIF
IF _WS_Err = .T.
  RETURN .F.
ENDIF
_XML_result = oProxy.getPatient(_WS_user , _WS_pswd , _hosp_no)
IF TYPE("_XML_result") <> "C"
  _WS_Err = .T.
ELSE
  _WS_Err = .F.
ENDIF
RELEASE oProxy
IF USED("XMLPatient")
  USE IN XMLPatient
ENDIF
_XML_result2 = STREXTRACT(_XML_result, "<Histo_Patient>" , "</NewDataSet>" )
_XML_result2 = "  <Histo_Patient>" + _XML_result2                           
_XML_result2 = "<Result>" +CHR(13)+CHR(10)+ _XML_result2 + "</Result>"      
STRTOFILE(STRCONV(_XML_result2,9), "XMLPatient.XML")
IF NOT "</Histo_Patient>" $ _XML_result2
  MESSAGEBOX(" Patient Is Not Found From Web Service Gateway !"+CHR(13)+" Hospital No. :  "+_hosp_no, 48, "Patient Not Found")
  RETURN
ENDIF
XMLTOCURSOR("XMLPatient.XML", "XMLPatient", 512)
IF USED("XMLPatient")      
  SELECT XMLPatient
  COPY TO XMLPatient.DBF
  GO TOP
ENDIF
_WS_success = IIF("<Status>1" $ _XML_result , .T. , .F.)
*** STATUS: 1 = Successful , 2 = Failure 
*** STAUTS_DESC: Blank if successful or Descriptive Reason if failure
IF _WS_success = .F.
    MESSAGEBOX("Warning : " +CHR(13)+"Unable To Get Patient Records From W.S. getPatient" +CHR(13)+ ;
               ">>> Please Call Technical Support For Help.", 16, "Get Patient Failed !")
  ENDIF
ENDIF
RETURN _WS_success
****** =========================== End Of Function =========================== ******


*** manually convert the Plain Text XML format file to a cursor file, 
PROCEDURE XML_TO_CURSOR
LPARAMETERS _xmlfile
LOCAL _xmlfile_str, _old_memo_width
CREATE CURSOR XMLPatient ;
   (Patient_No C(13), Visit_No C(13), PV_Surname C(30), PV_Givenname C(30), PV_ChiName C(15) ,;
    PV_ID_Type L, PV_IDNo C(20), PV_IDNo_CD C(2), PV_Sex C(1), PV_DOB N(14), PV_DOB_YY L ,;
    PV_PhoneNo C(20), PV_Discharge_DT N(14), PV_Type L, Bed_No C(8), Dept_Code C(5) ,;
    Hosp_Class_Code C(2), Doctor_Code N(5), PV_Visit_DT N(14), Doctor_Surname C(30) ,;
    Doctor_Givenname C(30), Doctor_Engname C(20), Doctor_Chiname C(15) ,;
    Request_No C(13), Clinical_Notes C(200), Surgical_Procedure C(60), Nature_Of_Specimen C(60))
_old_memo_width = SET("MEMOWIDTH")
SET MEMOWIDTH TO 200
_xmlfile_str = FILETOSTR(_xmlfile)
SELECT XMLPatient
APPEND BLANK
IF "<Patient_No>" $ _xmlfile_str
  REPLACE Patient_No       WITH SUBSTR(_xmlfile_str, AT("<Patient_No>",_xmlfile_str)+12, (AT("</Patient_No>",_xmlfile_str)) - (AT("<Patient_No>",_xmlfile_str)+12) )
ENDIF
IF "<Visit_No>" $ _xmlfile_str
  REPLACE Visit_No         WITH SUBSTR(_xmlfile_str, AT("<Visit_No>",_xmlfile_str)+10, (AT("</Visit_No>",_xmlfile_str)) - (AT("<Visit_No>",_xmlfile_str)+10) )
ENDIF
IF "<PV_Surname>" $ _xmlfile_str
  REPLACE PV_Surname       WITH SUBSTR(_xmlfile_str, AT("<PV_Surname>",_xmlfile_str)+12, (AT("</PV_Surname>",_xmlfile_str)) - (AT("<PV_Surname>",_xmlfile_str)+12) )
ENDIF
IF "<PV_Givenname>" $ _xmlfile_str
  REPLACE PV_Givenname     WITH SUBSTR(_xmlfile_str, AT("<PV_Givenname>",_xmlfile_str)+14, (AT("</PV_Givenname>",_xmlfile_str)) - (AT("<PV_Givenname>",_xmlfile_str)+14) )
ENDIF
IF "<PV_ChiName>" $ _xmlfile_str
  REPLACE PV_ChiName       WITH SUBSTR(_xmlfile_str, AT("<PV_ChiName>",_xmlfile_str)+12, (AT("</PV_ChiName>",_xmlfile_str)) - (AT("<PV_ChiName>",_xmlfile_str)+12) )
ENDIF
IF "<PV_ID_Type>" $ _xmlfile_str
  REPLACE PV_ID_Type       WITH IIF(SUBSTR(_xmlfile_str, AT("<PV_ID_Type>",_xmlfile_str)+12, 1) = "1", .T. , .F.)
ENDIF
IF "<PV_IDNo>" $ _xmlfile_str
  REPLACE PV_IDNo          WITH SUBSTR(_xmlfile_str, AT("<PV_IDNo>",_xmlfile_str)+9, (AT("</PV_IDNo>",_xmlfile_str)) - (AT("<PV_IDNo>",_xmlfile_str)+9) )
ENDIF
IF "<PV_IDNo_CD>" $ _xmlfile_str
  REPLACE PV_IDNo_CD       WITH SUBSTR(_xmlfile_str, AT("<PV_IDNo_CD>",_xmlfile_str)+12, (AT("</PV_IDNo_CD>",_xmlfile_str)) - (AT("<PV_IDNo_CD>",_xmlfile_str)+12) )
ENDIF
IF "<PV_Sex>" $ _xmlfile_str
  REPLACE PV_Sex           WITH SUBSTR(_xmlfile_str, AT("<PV_Sex>",_xmlfile_str)+8, 1)
ENDIF
IF "<PV_DOB>" $ _xmlfile_str
  REPLACE PV_DOB           WITH VAL(SUBSTR(_xmlfile_str, AT("<PV_DOB>",_xmlfile_str)+8, 14))
ENDIF
IF SUBSTR(_xmlfile_str, AT("<PV_DOB_YY>",_xmlfile_str)+11, 5) = "false" OR SUBSTR(_xmlfile_str, AT("<PV_DOB_YY>",_xmlfile_str)+11, 1) = "0"
  && this value will be equal to "false" ro "true" , and sometimes may be "0" or "1"
  REPLACE PV_DOB_YY        WITH .F.
ELSE
  REPLACE PV_DOB_YY        WITH .T.
ENDIF
IF "<PV_PhoneNo>" $ _xmlfile_str
  REPLACE PV_PhoneNo       WITH SUBSTR(_xmlfile_str, AT("<PV_PhoneNo>",_xmlfile_str)+12, (AT("</PV_PhoneNo>",_xmlfile_str)) - (AT("<PV_PhoneNo>",_xmlfile_str)+12) )
ENDIF
IF "<PV_Discharge_DT>" $ _xmlfile_str
  REPLACE PV_Discharge_DT  WITH VAL(SUBSTR(_xmlfile_str, AT("<PV_Discharge_DT>",_xmlfile_str)+17, 14))
ENDIF
IF "<PV_Type>" $ _xmlfile_str
  REPLACE PV_Type          WITH IIF(SUBSTR(_xmlfile_str, AT("<PV_Type>",_xmlfile_str)+9, 1) = "1", .T. , .F.)
ENDIF
IF "<Bed_No>" $ _xmlfile_str
  REPLACE Bed_No           WITH SUBSTR(_xmlfile_str, AT("<Bed_No>",_xmlfile_str)+8, (AT("</Bed_No>",_xmlfile_str)) - (AT("<Bed_No>",_xmlfile_str)+8) )
ENDIF
IF "<Dept_Code>" $ _xmlfile_str
  REPLACE Dept_Code        WITH SUBSTR(_xmlfile_str, AT("<Dept_Code>",_xmlfile_str)+11, (AT("</Dept_Code>",_xmlfile_str)) - (AT("<Dept_Code>",_xmlfile_str)+11) )
ENDIF
IF "<Hosp_Class_Code>" $ _xmlfile_str
  REPLACE Hosp_Class_Code  WITH SUBSTR(_xmlfile_str, AT("<Hosp_Class_Code>",_xmlfile_str)+17, (AT("</Hosp_Class_Code>",_xmlfile_str)) - (AT("<Hosp_Class_Code>",_xmlfile_str)+17) )
ENDIF
IF "<Doctor_Code>" $ _xmlfile_str
  REPLACE Doctor_Code      WITH VAL(SUBSTR(_xmlfile_str, AT("<Doctor_Code>",_xmlfile_str)+13, (AT("</Doctor_Code>",_xmlfile_str)) - (AT("<Doctor_Code>",_xmlfile_str)+13) ))
ENDIF
IF "<PV_Visit_DT>" $ _xmlfile_str
  REPLACE PV_Visit_DT      WITH VAL(SUBSTR(_xmlfile_str, AT("<PV_Visit_DT>",_xmlfile_str)+13, 14))
ENDIF
IF "<Doctor_Surname>" $ _xmlfile_str
  REPLACE Doctor_Surname   WITH SUBSTR(_xmlfile_str, AT("<Doctor_Surname>",_xmlfile_str)+16, (AT("</Doctor_Surname>",_xmlfile_str)) - (AT("<Doctor_Surname>",_xmlfile_str)+16) )
ENDIF
IF "<Doctor_Givenname>" $ _xmlfile_str
  REPLACE Doctor_Givenname WITH SUBSTR(_xmlfile_str, AT("<Doctor_Givenname>",_xmlfile_str)+18, (AT("</Doctor_Givenname>",_xmlfile_str)) - (AT("<Doctor_Givenname>",_xmlfile_str)+18) )
ENDIF
IF "<Doctor_Engname>" $ _xmlfile_str
  REPLACE Doctor_Engname   WITH SUBSTR(_xmlfile_str, AT("<Doctor_Engname>",_xmlfile_str)+16, (AT("</Doctor_Engname>",_xmlfile_str)) - (AT("<Doctor_Engname>",_xmlfile_str)+16) )
ENDIF
IF "<Doctor_Chiname>" $ _xmlfile_str
  REPLACE Doctor_Chiname   WITH SUBSTR(_xmlfile_str, AT("<Doctor_Chiname>",_xmlfile_str)+16, (AT("</Doctor_Chiname>",_xmlfile_str)) - (AT("<Doctor_Chiname>",_xmlfile_str)+16) )
ENDIF
IF "<Request_No>" $ _xmlfile_str
  REPLACE Request_No       WITH SUBSTR(_xmlfile_str, AT("<Request_No>",_xmlfile_str)+12, (AT("</Request_No>",_xmlfile_str)) - (AT("<Request_No>",_xmlfile_str)+12) )
ENDIF
IF "<Clinical_Notes>" $ _xmlfile_str
  REPLACE Clinical_Notes   WITH SUBSTR(_xmlfile_str, AT("<Clinical_Notes>",_xmlfile_str)+16, (AT("</Clinical_Notes>",_xmlfile_str)) - (AT("<Clinical_Notes>",_xmlfile_str)+16) )
ENDIF
IF "<Surgical_Procedure>" $ _xmlfile_str
  REPLACE Surgical_Procedure WITH SUBSTR(_xmlfile_str, AT("<Surgical_Procedure>",_xmlfile_str)+20, (AT("</Surgical_Procedure>",_xmlfile_str)) - (AT("<Surgical_Procedure>",_xmlfile_str)+20) )
ENDIF
IF "<Nature_Of_Specimen>" $ _xmlfile_str
  REPLACE Nature_Of_Specimen WITH SUBSTR(_xmlfile_str, AT("<Nature_Of_Specimen>",_xmlfile_str)+20, (AT("</Nature_Of_Specimen>",_xmlfile_str)) - (AT("<Nature_Of_Specimen>",_xmlfile_str)+20) )
ENDIF
REPLACE PV_Surname         WITH XML_CONV_CHAR(PV_Surname, .T.)
REPLACE PV_Givenname       WITH XML_CONV_CHAR(PV_Givenname, .T.)
REPLACE Doctor_Surname     WITH XML_CONV_CHAR(Doctor_Surname, .T.)
REPLACE Doctor_Givenname   WITH XML_CONV_CHAR(Doctor_Givenname, .T.)
REPLACE Doctor_Engname     WITH XML_CONV_CHAR(Doctor_Engname, .T.)
REPLACE Clinical_Notes     WITH XML_CONV_CHAR(Clinical_Notes, .T.)
REPLACE Surgical_Procedure WITH XML_CONV_CHAR(Surgical_Procedure, .T.)
REPLACE Nature_Of_Specimen WITH XML_CONV_CHAR(Nature_Of_Specimen, .T.)
SET MEMOWIDTH TO _old_memo_width
RETURN
****** =========================== End Of Function =========================== ******


*** below is an example of the converted XML file content made by above step.
TEXT

<Result>
  <Histo_Patient>
    <Patient_No>PN19971103747</Patient_No>
    <Visit_No>HN20081200001</Visit_No>
    <PV_Surname>CHANG                         </PV_Surname>
    <PV_Givenname>YEE LING ANGELA</PV_Givenname>
    <PV_ChiName>張綺玲</PV_ChiName>
    <PV_ID_Type>1</PV_ID_Type>
    <PV_IDNo>G684074</PV_IDNo>
    <PV_IDNo_CD>3 </PV_IDNo_CD>
    <PV_Sex>F</PV_Sex>
    <PV_DOB>19690613000000</PV_DOB>
    <PV_DOB_YY>false</PV_DOB_YY>
    <PV_PhoneNo>96703328</PV_PhoneNo>
    <PV_Discharge_DT>20110915170928</PV_Discharge_DT>
    <PV_Type>1</PV_Type>
    <Bed_No>368-4   </Bed_No>
    <Dept_Code>E3W  </Dept_Code>
    <Hosp_Class_Code>C </Hosp_Class_Code>
    <Doctor_Code>1763</Doctor_Code>
    <PV_Visit_DT>20110914120722</PV_Visit_DT>
    <Doctor_Surname>KO                            </Doctor_Surname>
    <Doctor_Givenname>CHING TUNG HELEN (a)</Doctor_Givenname>
    <Doctor_Chiname>高正東</Doctor_Chiname>
    <Request_No xml:space="preserve">             </Request_No>
    <Clinical_Notes />
    <Surgical_Procedure />
    <Nature_Of_Specimen />
  </Histo_Patient>
</Result>

ENDTEXT
