using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace St.Teresa_LIS_2019
{
    public class HisPatient
    {
        public string patientNo { get; set; }
        public string visitNo { get; set; }
        public string pvSurname { get; set; }
        public string pvGivenname { get; set; }
        public string pvChiName { get; set; }
        public string pvIdType { get; set; }
        public string idTypeCode { get; set; }
        public string pvIdNo { get; set; }
        public string pvIdNoCd { get; set; }
        public string pvSex { get; set; }
        public string pvDob { get; set; }
        public string exactDateIndicatorCode { get; set; }
        public string pvPhoneNo { get; set; }
        public string pvDischargeDt { get; set; }
        public string pvType { get; set; }
        public string bedNo { get; set; }
        public string deptCode { get; set; }
        public string hospClassCode { get; set; }
        public string doctorCode { get; set; }
        public string pvVisitDt { get; set; }
        public string doctorSurname { get; set; }
        public string doctorGivenname { get; set; }
        public string doctorEngName { get; set; }
        public string doctorChiName { get; set; }
        public string requestNo { get; set; }
        public string clinicalNotes { get; set; }
        public string surgicalProcedure { get; set; }
        public string natureOfSpecimen { get; set; }

        public HisPatient()
        {

        }

        public Double getCurrentAge()
        {
            if (pvDob == null)
            {
                return Double.NaN;
            }

            DateTime dob = DateTime.ParseExact(pvDob, "yyyyMMdd", null);
            if (dob == null)
            {
                return Double.NaN;
            }

            return Math.Round(((DateTime.Now - dob).TotalDays / 365), 2);
        }

        public String getDoctorFullName()
        {
            String fullName = "";

            if (doctorSurname != null)
            {
                fullName = doctorSurname;
            }
            if (fullName == "")
            {
                if (doctorGivenname != null)
                {
                    fullName = doctorGivenname;
                }
            }
            else
            {
                fullName = fullName + " " + doctorGivenname;
            }

            if (fullName == "")
            {
                return null;
            }
            else
            {
                return fullName;
            }
        }

        public String getFullName()
        {
            String fullName = "";

            if (pvSurname != null)
            {
                fullName = pvSurname;
            }
            if (fullName == "")
            {
                if (pvGivenname != null)
                {
                    fullName = pvGivenname;
                }
            }
            else
            {
                fullName = fullName + " " + pvGivenname;
            }

            if (fullName == "")
            {
                return null;
            }
            else
            {
                return fullName;
            }
        }

        public String getFullHKID()
        {

            if (pvIdNo == null)
            {
                return null;
            }
            else
            {
                if (pvIdNoCd == null)
                {
                    return pvIdNo;
                }
                else
                {
                    return String.Format("{0}({1})", pvIdNo, pvIdNoCd);
                }
            }

        }

        public HisPatient(XmlDocument xmlDoc)
        {
            if (xmlDoc == null)
            {

            }
            else
            {
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml(xml);

                String xPath = "Wraper/NewDataSet/Histo_Patient";
                var nodes = xmlDoc.SelectNodes(xPath);
                if (nodes == null)
                {
                    //MessageBox.Show("Cannot parse the feedback");
                }
                else
                {
                    foreach (XmlNode childrenNode in nodes)
                    {
                        String pp = "";
                        foreach (XmlNode grandChild in childrenNode)
                        {
                            pp = pp + Environment.NewLine + grandChild.Name + " : " + grandChild.InnerText;
                            if (grandChild.Name.Trim().ToLower() == "patient_no")
                            {
                                patientNo = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "visit_no")
                            {
                                visitNo = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "pv_surname")
                            {
                                pvSurname = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "pv_givenname".ToLower())
                            {
                                pvGivenname = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "pv_chiname".ToLower())
                            {
                                pvChiName = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_ID_Type".ToLower())
                            {
                                pvIdType = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "ID_Type_Code".ToLower())
                            {
                                idTypeCode = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_IDNo".ToLower())
                            {
                                pvIdNo = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_IDNo_CD".ToLower())
                            {
                                pvIdNoCd = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_Sex".ToLower())
                            {
                                pvSex = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_DOB".ToLower())
                            {
                                pvDob = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Exact_Date_Indicator_Code".ToLower())
                            {
                                exactDateIndicatorCode = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_PhoneNo".ToLower())
                            {
                                pvPhoneNo = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_Discharge_DT".ToLower())
                            {
                                pvDischargeDt = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_Type".ToLower())
                            {
                                pvType = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Bed_No".ToLower())
                            {
                                bedNo = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Dept_Code".ToLower())
                            {
                                deptCode = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Hosp_Class_Code".ToLower())
                            {
                                hospClassCode = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Doctor_Code".ToLower())
                            {
                                doctorCode = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "PV_Visit_DT".ToLower())
                            {
                                pvVisitDt = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Doctor_Surname".ToLower())
                            {
                                doctorSurname = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Doctor_Givenname".ToLower())
                            {
                                doctorGivenname = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Doctor_Engname".ToLower())
                            {
                                doctorEngName = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Doctor_Chiname".ToLower())
                            {
                                doctorChiName = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Request_No".ToLower())
                            {
                                requestNo = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Clinical_Notes".ToLower())
                            {
                                clinicalNotes = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Surgical_Procedure".ToLower())
                            {
                                surgicalProcedure = grandChild.InnerText.Trim();
                            }

                            if (grandChild.Name.Trim().ToLower() == "Nature_Of_Specimen".ToLower())
                            {
                                natureOfSpecimen = grandChild.InnerText.Trim();
                            }


                        }
                        if (Properties.Settings.Default.HisEnableDebug)
                        {
                            //MessageBox.Show(pp);
                        }

                    }


                }
            }
        }
    }
}
