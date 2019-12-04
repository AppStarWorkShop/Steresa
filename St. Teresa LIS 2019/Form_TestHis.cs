using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace St.Teresa_LIS_2019
{
    public partial class Form_TestHis : Form
    {
        public Form_TestHis()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string generateDiagnosis(DataRow row)
        {
            string r = "";
            
            r = row["site"].ToString() + ", " + row["operation"].ToString() + Environment.NewLine
                            + row["diagnosis"].ToString() + Environment.NewLine
                            + row["siteChi"].ToString() + ", " + row["operationChi"].ToString() + Environment.NewLine
                            + row["diagnosisChi"].ToString();

            return r;
        }

        private String generateReportXml(HisHistoReport r)
        {

            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Histology_PDF");

            xmlWriter.WriteStartElement("Record");
            xmlWriter.WriteAttributeString("Path_No", r.pathNo);

            xmlWriter.WriteStartElement("Visit_No");
            xmlWriter.WriteString(r.visitNo);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Version_No");
            xmlWriter.WriteString(r.versionNo.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Tx_Type");
            xmlWriter.WriteString("A");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Report_Type_Code");
            xmlWriter.WriteString("01");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Report_DT");
            xmlWriter.WriteString(r.reportDateTime.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Order_Doctor_Code");
            xmlWriter.WriteString(r.orderDoctorCode);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Order_Doctor_Name");
            xmlWriter.WriteString(r.orderDoctorName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy1_Doctor_Code");
            xmlWriter.WriteString(r.copy1DoctorCode);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy1_Doctor_Name");
            xmlWriter.WriteString(r.copy1DoctorName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy2_Doctor_Code");
            xmlWriter.WriteString(r.copy2DoctorCode);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy2_Doctor_Name");
            xmlWriter.WriteString(r.copy2DoctorName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy2_Doctor_Code");
            xmlWriter.WriteString(r.copy2DoctorCode);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy2_Doctor_Name");
            xmlWriter.WriteString(r.copy2DoctorName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy3_Doctor_Code");
            xmlWriter.WriteString(r.copy3DoctorCode);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy3_Doctor_Name");
            xmlWriter.WriteString(r.copy3DoctorName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy4_Doctor_Code");
            xmlWriter.WriteString(r.copy4DoctorCode);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy4_Doctor_Name");
            xmlWriter.WriteString(r.copy4DoctorName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Approved_Doctor_Name");
            xmlWriter.WriteString(r.approvedDoctorName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Clinical_History");
            xmlWriter.WriteString(r.clinicalHistory);
            xmlWriter.WriteEndElement();


            xmlWriter.WriteStartElement("Diagnosis1");
            xmlWriter.WriteString(r.diagnosis1);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis2");
            xmlWriter.WriteString(r.diagnosis2);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis3");
            xmlWriter.WriteString(r.diagnosis3);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis4");
            xmlWriter.WriteString(r.diagnosis4);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis5");
            xmlWriter.WriteString(r.diagnosis5);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis6");
            xmlWriter.WriteString(r.diagnosis6);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis7");
            xmlWriter.WriteString(r.diagnosis7);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis8");
            xmlWriter.WriteString(r.diagnosis8);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis9");
            xmlWriter.WriteString(r.diagnosis9);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("File_Name");
            xmlWriter.WriteString(r.visitNo + r.pathNo + r.versionNo.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("File_Content");
            xmlWriter.WriteString("ABCDEF");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement(); //Record


            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            return stringWriter.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_output.Text = "";

            string sqlCon = Properties.Settings.Default.medlabConnectionString;
            DataSet userDataSet = new DataSet();
            string tableName = "v_hisReportContent";
            string sql = string.Format("select * FROM v_hisReportContent where case_no='" + textBox_caseNo.Text.Trim().ToUpper() + "' AND versionNo = '" + textBox_reportNo.Text + "'");
            DBConn.fetchDataIntoDataSetSelectOnly(sql, userDataSet, tableName);
            if (userDataSet.Tables[tableName].Rows.Count > 0)
            {
                HisHistoReport r = new HisHistoReport();
                Boolean notFillinFirstPart = true;
                int diagNo = 1;
                foreach (DataRow row in userDataSet.Tables[tableName].Rows)
                {
                    if (notFillinFirstPart)
                    {
                        r.caseNo = row["case_no"].ToString();
                        r.pathNo = row["pathNo"].ToString();
                        r.visitNo = row["visitNo"].ToString();
                        r.versionNo = int.Parse(row["versionNo"].ToString());
                        r.reportDateTime = DateTime.Parse(row["reportDateTime"].ToString());
                        if (row["orderDoctorCode"] != null)
                        {
                            r.orderDoctorCode = row["orderDoctorCode"].ToString();
                        } 
                        r.orderDoctorName = row["orderDoctorName"].ToString();
                        //r.copy1DoctorCode = row["copy1DoctorCode"].ToString();
                        r.approvedDoctorName = row["approvedDoctorName"].ToString();
                        r.clinicalHistory = row["clinicalHistory"].ToString();
                        notFillinFirstPart = true;
                    }

                    if (diagNo ==1 )
                    {
                        r.diagnosis1 = generateDiagnosis(row);
                    } else if (diagNo == 2)
                    {
                        r.diagnosis2 = generateDiagnosis(row);
                    }
                    else if (diagNo == 3)
                    {
                        r.diagnosis3 = generateDiagnosis(row);
                    }
                    else if (diagNo == 4)
                    {
                        r.diagnosis4 = generateDiagnosis(row);
                    }
                    else if (diagNo == 5)
                    {
                        r.diagnosis5 = generateDiagnosis(row);
                    }
                    else if (diagNo == 6)
                    {
                        r.diagnosis6 = generateDiagnosis(row);
                    }
                    else if (diagNo == 7)
                    {
                        r.diagnosis7 = generateDiagnosis(row);
                    }
                    else if (diagNo == 8)
                    {
                        r.diagnosis8 = generateDiagnosis(row);
                    }
                    else if (diagNo == 9)
                    {
                        r.diagnosis9 = generateDiagnosis(row);
                    }

                    diagNo++;
                }

                textBox_output.Text = this.generateReportXml(r);
            }

        }
    }
}
