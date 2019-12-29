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
            
            r = row["seq"].ToString().Trim() + " " + row["site"].ToString().Trim() + ", " + row["operation"].ToString().Trim() + Environment.NewLine
                            + row["diagnosis"].ToString().Trim() + Environment.NewLine
                            + row["siteChi"].ToString().Trim() + ", " + row["operationChi"].ToString().Trim() + Environment.NewLine
                            + "- " + row["diagnosisChi"].ToString().Trim();

            return r;
        }

        private void writeStringToXml(XmlWriter xmlWriter, String strIn, int maxLen)
        {
            if (strIn == null )
            {
                xmlWriter.WriteString("");
            } else
            {
                if (strIn.Trim() == "")
                {
                    xmlWriter.WriteString("");
                }
                else
                {
                    String i = strIn.Trim();
                    if (i.Length > maxLen)
                    {
                        xmlWriter.WriteString(strIn.Trim().Substring(0, maxLen - 1));
                    } else
                    {
                        xmlWriter.WriteString(strIn.Trim());
                    }
                    
                }
            }
        }

        private String generateReportXml(HisHistoReport r)
        {

            Utf8StringWriter stringWriter = new Utf8StringWriter();
            
            XmlWriterSettings setting = new XmlWriterSettings {Encoding=Encoding.UTF8, Indent=true, NewLineOnAttributes=true};
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, setting);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Histology_PDF");

            xmlWriter.WriteStartElement("Record");
            xmlWriter.WriteAttributeString("Path_No", r.pathNo);

            xmlWriter.WriteStartElement("Visit_No");
            xmlWriter.WriteString(r.visitNo);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Part_No");
            xmlWriter.WriteString(r.partNo.ToString());
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
            xmlWriter.WriteString(r.reportDateTime.ToString("dd/MM/yyyy"));
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Order_Doctor_Code");
            writeStringToXml(xmlWriter, r.orderDoctorCode, 5);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Order_Doctor_Name");
            writeStringToXml(xmlWriter, r.orderDoctorName, 60);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy1_Doctor_Code");
            writeStringToXml(xmlWriter, r.copy1DoctorCode, 5);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy1_Doctor_Name");
            writeStringToXml(xmlWriter, r.copy1DoctorName, 60);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy2_Doctor_Code");
            writeStringToXml(xmlWriter, r.copy2DoctorCode, 5);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy2_Doctor_Name");
            writeStringToXml(xmlWriter, r.copy2DoctorName, 60);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy3_Doctor_Code");
            writeStringToXml(xmlWriter, r.copy3DoctorCode, 5);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy3_Doctor_Name");
            writeStringToXml(xmlWriter, r.copy3DoctorName, 60);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy4_Doctor_Code");
            writeStringToXml(xmlWriter, r.copy4DoctorCode, 5);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy4_Doctor_Name");
            writeStringToXml(xmlWriter, r.copy4DoctorName, 60);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Copy5_Doctor_Code");
            writeStringToXml(xmlWriter, r.copy5DoctorCode, 5);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Copy5_Doctor_Name");
            writeStringToXml(xmlWriter, r.copy5DoctorName, 60);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Approved_Doctor_Name");
            writeStringToXml(xmlWriter, r.approvedDoctorName, 60);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Clinical_History");
            writeStringToXml(xmlWriter, r.clinicalHistory, 300);
            xmlWriter.WriteEndElement();


            xmlWriter.WriteStartElement("Diagnosis1");
            writeStringToXml(xmlWriter, r.diagnosis1, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis2");
            writeStringToXml(xmlWriter, r.diagnosis2, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis3");
            writeStringToXml(xmlWriter, r.diagnosis3, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis4");
            writeStringToXml(xmlWriter, r.diagnosis4, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis5");
            writeStringToXml(xmlWriter, r.diagnosis5, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis6");
            writeStringToXml(xmlWriter, r.diagnosis6, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis7");
            writeStringToXml(xmlWriter, r.diagnosis7, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis8");
            writeStringToXml(xmlWriter, r.diagnosis8, 800);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Diagnosis9");
            writeStringToXml(xmlWriter, r.diagnosis9, 800);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("File_Name");
            xmlWriter.WriteString(r.visitNo + CaseBarCodeNumberOperator.generate(r.caseNo) + "-" + r.versionNo.ToString() + ".pdf");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("File_Content");
            if (r.fileContent == null || r.fileContent == "")
            {
                xmlWriter.WriteString("");
            } else
            {
                xmlWriter.WriteString(r.fileContent);
            }
            xmlWriter.WriteString("");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement(); //Record


            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            return stringWriter.ToString();
        }

        private HisHistoReport generateHisHistoReport(String case_no, String reportNo, String pdfReportFile)
        {
            string sqlCon = Properties.Settings.Default.medlabConnectionString;
            DataSet userDataSet = new DataSet();
            string tableName = "v_hisReportContent";
            string sql = string.Format("select * FROM v_hisReportContent where case_no='" + case_no + "' AND versionNo = '" + reportNo + "'");
            DBConn.fetchDataIntoDataSetSelectOnly(sql, userDataSet, tableName);

            HisHistoReport r = new HisHistoReport();
            if (userDataSet.Tables[tableName].Rows.Count > 0)
            {
                Boolean notFillinFirstPart = true;
                int diagNo = 1;
                foreach (DataRow row in userDataSet.Tables[tableName].Rows)
                {
                    if (notFillinFirstPart)
                    {
                        r.caseNo = row["case_no"].ToString();
                        if ("" == textBox_reportNo.Text || "1" == textBox_reportNo.Text)
                        {
                            r.pathNo = row["case_no"].ToString();
                        }
                        else
                        {
                            r.pathNo = row["case_no"].ToString() + "-" + textBox_reportNo.Text;
                        }

                        r.visitNo = row["visitNo"].ToString();
                        r.partNo = int.Parse(row["versionNo"].ToString());
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

                        Byte[] b = File.ReadAllBytes(pdfReportFile);
                        r.fileContent = Convert.ToBase64String(b);

                        notFillinFirstPart = true;
                    }

                    if (diagNo == 1)
                    {
                        r.diagnosis1 = generateDiagnosis(row);
                    }
                    else if (diagNo == 2)
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

                
            }

            return r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_output.Text = "";

            HisHistoReport r = this.generateHisHistoReport(textBox_caseNo.Text.Trim().ToUpper(), textBox_reportNo.Text, textBox_reportFilePath.Text);

            String xml = this.generateReportXml(r);
            textBox_output.Text = xml.Substring(0, 2000) + Environment.NewLine
                + "..." + Environment.NewLine
                + "..." + Environment.NewLine
                + "..." + Environment.NewLine
                + xml.Substring(xml.Length - 100, 100);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_output.Text = "";
            String caseNo = textBox_caseNo.Text.Trim().ToUpper();
            String reportNo = textBox_reportNo.Text;

            HisHistoReport r = this.generateHisHistoReport(caseNo, reportNo, textBox_reportFilePath.Text);

            String xml = this.generateReportXml(r);

            HisOperator hisOperator = new HisOperator();
            textBox_output.Text = hisOperator.sentReportToHis(caseNo, reportNo, xml, "sys");
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button_getpatient_Click(object sender, EventArgs e)
        {
            if (textBoxHNNo.Text == "")
            {
                MessageBox.Show("Please input a HN number!");
            }
            else
            {
                HisOperator o = new HisOperator();
                String r = o.readPatient(textBoxHNNo.Text);
                textBoxOutputPatient.Text = r;
            }
        }
    }
}
