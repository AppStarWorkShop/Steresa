using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using ThoughtWorks.QRCode.Codec;
//using BarcodeLib;

namespace St.Teresa_LIS_2019
{
    public partial class Form_PathologyReport : Form
    {
        private string id;
        private string case_no;
        private string report_no = "1";
        private int noOfPhotos = 0;

        private DataSet bxcy_specimenDataSet = new DataSet();
        private DataTable bxcy_specimenDt;
        private SqlDataAdapter bxcy_specimenDataAdapter;

        private DataSet bxcy_diagDataSet = new DataSet();
        private DataTable bxcy_diagDt;
        private SqlDataAdapter bxcy_diagDataAdapter;

        public Form_PathologyReport()
        {
            InitializeComponent();
        }
        // Updated by eric leung 
        public Form_PathologyReport(string id, string case_no, string report_No, int noOfPhotos)
        {
            this.id = id;
            this.case_no = case_no;
            this.report_no = report_No;
            this.noOfPhotos = noOfPhotos;
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_PathologyReport_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            comboBox_Report_Heading.Items.Clear();

            comboBox_Report_Heading.Items.Add("01 STH BX");
            //comboBox_Report_Heading.Items.Add("2 - PRIVATE - BX (OLD - 2 Doctors)");
            //comboBox_Report_Heading.Items.Add("3 - P.B.H. - BX");
            //comboBox_Report_Heading.Items.Add("4 - H.K.A.H. - BX");
            //comboBox_Report_Heading.Items.Add("5 - T.W.A.H. - BX");
            comboBox_Report_Heading.Items.Add("06 PATHLAB BX");
            //comboBox_Report_Heading.Items.Add("7 - EVANGEL - BX");
            comboBox_Report_Heading.Items.Add("08 STH CY");
            //comboBox_Report_Heading.Items.Add("9 - PRIVATE - CY(OLD - 2 Doctors");
            //comboBox_Report_Heading.Items.Add("10 - P.B.H. - CY");
            //comboBox_Report_Heading.Items.Add("11 - H.K.A.H. - CY");
            //comboBox_Report_Heading.Items.Add("12 - T.W.A.H. - CY");
            comboBox_Report_Heading.Items.Add("13 PATHLAB CY");
            //comboBox_Report_Heading.Items.Add("14 - P.B.H. - CY");
            //comboBox_Report_Heading.Items.Add("15 - ONCO - CY");
            comboBox_Report_Heading.Items.Add("16 BIO-TECH CY");
            //comboBox_Report_Heading.Items.Add("17 - CY Screening");
            comboBox_Report_Heading.Items.Add("18 PRIVATE BX");
            comboBox_Report_Heading.Items.Add("19 PRIVATE CY");

            string sqlExt = string.Format("SELECT * FROM [bxcy_specimen] WHERE id = {0}", id);
            bxcy_specimenDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(sqlExt, bxcy_specimenDataSet, "bxcy_specimen");
            bxcy_specimenDt = bxcy_specimenDataSet.Tables["bxcy_specimen"];

            if (bxcy_specimenDt != null && bxcy_specimenDt.Rows.Count > 0)
            {
                DataRow mDr = bxcy_specimenDt.Rows[0];
                if (mDr["client"] != null)
                {
                    String client = mDr["client"].ToString().Trim().ToUpper();
                    if ("ST. TERESA'S HOSPITAL" == client)
                    {
                        if (case_no.ToUpper().StartsWith("BX"))
                        {
                            comboBox_Report_Heading.SelectedIndex = 0;
                        }
                        else if (case_no.ToUpper().StartsWith("CY"))
                        {
                            comboBox_Report_Heading.SelectedIndex = 2;
                        }
                    }
                    else if ("PATHLAB MED LAB" == client)
                    {
                        if (case_no.ToUpper().StartsWith("BX"))
                        {
                            comboBox_Report_Heading.SelectedIndex = 1;
                        }
                        else if (case_no.ToUpper().StartsWith("CY"))
                        {
                            comboBox_Report_Heading.SelectedIndex = 3;
                        }
                    }
                    else if ("BIO-TECHNOLOGY LTD" == client)
                    {
                        if (case_no.ToUpper().StartsWith("CY"))
                        {
                            comboBox_Report_Heading.SelectedIndex = 4;
                        }
                    }
                    else
                    {
                        if (case_no.ToUpper().StartsWith("BX"))
                        {
                            comboBox_Report_Heading.SelectedIndex = 5;
                        }
                        else if (case_no.ToUpper().StartsWith("CY"))
                        {
                            comboBox_Report_Heading.SelectedIndex = 6;
                        }
                    }

                }
            }

            string sql = string.Format("SELECT * FROM [BXCY_DIAG] WHERE case_no = '{0}' ORDER BY ID", case_no);
            bxcy_diagDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(sql, bxcy_diagDataSet, "bxcy_diag");
            bxcy_diagDt = bxcy_diagDataSet.Tables["bxcy_diag"];  
            
            if (noOfPhotos == 0)
            {
                radioButtonSecondPage.Enabled = false;
                radioButtonSecondPage.Checked = false;
                radioButtonMiddle.Enabled = false;
                radioButtonMiddle.Checked = false;
                radioButtonRight.Enabled = false;
                radioButtonRight.Checked = false;
            }
            else if (noOfPhotos == 1)
            {
                radioButtonSecondPage.Enabled = true;
                radioButtonSecondPage.Checked = false;
                radioButtonMiddle.Enabled = false;
                radioButtonMiddle.Checked = false;
                radioButtonRight.Enabled = true;
                radioButtonRight.Checked = true;
            }
            else if (noOfPhotos == 2)
            {
                radioButtonSecondPage.Enabled = true;
                radioButtonSecondPage.Checked = false;
                radioButtonMiddle.Enabled = true;
                radioButtonMiddle.Checked = true;
                radioButtonRight.Enabled = false;
                radioButtonRight.Checked = false;
            }
            else if (noOfPhotos > 2)
            {
                radioButtonSecondPage.Enabled = true;
                radioButtonSecondPage.Checked = true;
                radioButtonMiddle.Enabled = false;
                radioButtonMiddle.Checked = false;
                radioButtonRight.Enabled = false;
                radioButtonRight.Checked = false;
            }
            label_Total_Photo.Text = "( Total Photo : " + noOfPhotos + " )";
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_ReportPreview newForm = new Form_ReportPreview();
            newForm.Show();
            if (checkBox_Print_HOKLAS_ISO_Format.Checked)
            {
                if (radioButtonRight.Checked)
                {
                    newForm.setReportParameter(comboBox_Report_Heading.Text + Form_ReportPreview.ONE_PHOTO, case_no, report_no, "1");
                }
                else if (radioButtonMiddle.Checked)
                {
                    newForm.setReportParameter(comboBox_Report_Heading.Text + Form_ReportPreview.TWO_PHOTO, case_no, report_no, "1");
                }
                else if (radioButtonSecondPage.Checked)
                {
                    newForm.setReportParameter(comboBox_Report_Heading.Text + Form_ReportPreview.MULTIPLE_PHOTO, case_no, report_no, "1");
                }
                else
                {
                    newForm.setReportParameter(comboBox_Report_Heading.Text, case_no, report_no, "1");
                }
            }
            else
            {
                newForm.setReportParameter(comboBox_Report_Heading.Text, case_no, report_no, "0");
            }
            
            newForm.showReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CreateNewPdfPage();
            Form_ReportPreview newForm = new Form_ReportPreview();
            newForm.Show();
            if (checkBox_Print_HOKLAS_ISO_Format.Checked)
            {
                newForm.setReportParameter(comboBox_Report_Heading.Text, case_no, report_no, "1");
            }
            else
            {
                newForm.setReportParameter(comboBox_Report_Heading.Text, case_no, report_no, "0");
            }
            newForm.showReport();
        }



        private void CreateNewPdfPage()
        {
            string fileName = string.Empty;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Bxcy Report";
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "Text documents (.pdf)|*.pdf";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                fileName = dlg.FileName;
                Document document = new Document(PageSize.NOTE);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                document.Open();
                // 第一页
                //System.Drawing.Font titleFont = new System.Drawing.Font("Meiryo UI", 18, FontStyle.Bold);

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font f = new iTextSharp.text.Font(bf);

                string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
                BaseFont bfChinese = BaseFont.CreateFont(basePath+"\\fonts\\STSONG.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font fChinese = new iTextSharp.text.Font(bfChinese, 12, iTextSharp.text.Font.NORMAL);

                iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("HISTOPATHOLOGY REPORT", f);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                p = new iTextSharp.text.Paragraph("ST.TERESA'S HOSPITAL", f);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                p = new iTextSharp.text.Paragraph("聖德肋撒醫院", fChinese);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                p = new iTextSharp.text.Paragraph("HISTOPATHOLOGY LABORATORY", f);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                p = new iTextSharp.text.Paragraph("組織病理化驗室", fChinese);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                if (bxcy_specimenDt != null && bxcy_specimenDt.Rows.Count > 0)
                {
                    DataRow mDr = bxcy_specimenDt.Rows[0];

                    p = new iTextSharp.text.Paragraph(string.Format("Path. No.: {0}", mDr["case_no"].ToString().Trim()), f);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    //p = new iTextSharp.text.Paragraph(string.Format("Record Status: {0}", mDr["case_no"].ToString().Trim()), f);
                    p = new iTextSharp.text.Paragraph(string.Format("Record Status: {0}", "N"), f);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("Patient's name: {0} {1}                             ID#:{2}", mDr["patient"].ToString().Trim(), mDr["cname"].ToString().Trim(), mDr["pat_hkid"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("Hospital no.: {0}    Room: {1}    Bed:{2}      Sex:{3}       Age:{4}", mDr["lab_ref"].ToString().Trim(), mDr["bed_room"].ToString().Trim(), mDr["bed_no"].ToString().Trim(), mDr["pat_sex"].ToString().Trim(), mDr["pat_age"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("Under the service of: {0}({1})", mDr["doctor_ic"].ToString().Trim(), mDr["doctor_id"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("Clinical history: {0}", mDr["pat_hist"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("Surgical procedure: {0}", mDr["surgical"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("Nature of specimen: {0}", mDr["nature"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    
                    p = new iTextSharp.text.Paragraph(string.Format("Frozen section diagnosis(if any): {0}                   Date Received:", mDr["fz_detail"].ToString().Trim(), mDr["date"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                }

                p = new iTextSharp.text.Paragraph("-------------------------------------------------------------------------------------------", fChinese);
                p.Alignment = Element.ALIGN_LEFT;
                document.Add(p);

                /*p = new iTextSharp.text.Paragraph("DIAGNOSIS: ", fChinese);
                p.Alignment = Element.ALIGN_LEFT;
                document.Add(p);

                p = new iTextSharp.text.Paragraph("主要病理診斷: ", fChinese);
                p.Alignment = Element.ALIGN_LEFT;
                document.Add(p);*/

                int rowNo = 1;
                foreach (DataRow mDrDetail in bxcy_diagDt.Rows)
                {
                    if(rowNo == 1)
                    {
                        p = new iTextSharp.text.Paragraph(string.Format("DIAGNOSIS:      {0})     {1}, {2} ", rowNo.ToString(), mDrDetail["site"].ToString().Trim(), mDrDetail["operation"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);

                        p = new iTextSharp.text.Paragraph(string.Format("主要病理診斷:   {0}", mDrDetail["diagnosis"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);

                        p = new iTextSharp.text.Paragraph(string.Format("                {0}, {1} ", mDrDetail["site2"].ToString().Trim(), mDrDetail["operation2"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);

                        p = new iTextSharp.text.Paragraph(string.Format("                {0}", mDrDetail["diag_desc1"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);
                    }
                    else
                    {
                        p = new iTextSharp.text.Paragraph(string.Format("                {1}, {2} ", rowNo.ToString(), mDrDetail["site"].ToString().Trim(), mDrDetail["operation"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);

                        p = new iTextSharp.text.Paragraph(string.Format("                {0}", mDrDetail["diagnosis"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);

                        p = new iTextSharp.text.Paragraph(string.Format("                {0}, {1} ", mDrDetail["site2"].ToString().Trim(), mDrDetail["operation2"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);

                        p = new iTextSharp.text.Paragraph(string.Format("                {0}", mDrDetail["diag_desc1"].ToString().Trim()), fChinese);
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(p);
                    }

                    p = new iTextSharp.text.Paragraph(string.Format(" "), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                    rowNo++;
                }

                foreach (DataRow mDrDetail in bxcy_diagDt.Rows)
                {
                    p = new iTextSharp.text.Paragraph(string.Format("{0}", mDrDetail["macro_name"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("{0}", mDrDetail["macro_desc"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format(""), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                }

                document.NewPage();

                foreach (DataRow mDrDetail in bxcy_diagDt.Rows)
                {
                    p = new iTextSharp.text.Paragraph(string.Format("{0}", mDrDetail["micro_name"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("{0}", mDrDetail["micro_desc"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format(""), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                }

                document.NewPage();

                int offectY = 600;
                int imgWidth = 80;
                int imgHeight = 80;
                int img1OffectX = 50;
                int img2OffectX = 160;
                int img3OffectX = 270;
                int img4OffectX = 380;
                int lineDistance = 110;
                int lineSize = 220;

                foreach (DataRow mDrDetail in bxcy_diagDt.Rows)
                {
                    p = new iTextSharp.text.Paragraph(string.Format(" "), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                    document.Add(p);
                    document.Add(p);
                    document.Add(p);
                    document.Add(p);
                    //document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("             {0}                     {1}                     {2}                     {3}", mDrDetail["macro_cap1"].ToString().Trim(), mDrDetail["macro_cap2"].ToString().Trim(), mDrDetail["macro_cap3"].ToString().Trim(), mDrDetail["macro_cap4"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format(" "), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                    document.Add(p);
                    document.Add(p);
                    document.Add(p);
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("             {0}                     {1}                     {2}                     {3}", mDrDetail["micro_cap1"].ToString().Trim(), mDrDetail["micro_cap2"].ToString().Trim(), mDrDetail["micro_cap3"].ToString().Trim(), mDrDetail["micro_cap4"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    string img1FullPath = "";
                    string img2FullPath = "";
                    string img3FullPath = "";
                    string img4FullPath = "";
                    string img5FullPath = "";
                    string img6FullPath = "";
                    string img7FullPath = "";
                    string img8FullPath = "";

                    img1FullPath = CurrentUser.picturePath + "\\" + mDrDetail["macro_pic1"].ToString().Trim();
                    img2FullPath = CurrentUser.picturePath + "\\" + mDrDetail["macro_pic2"].ToString().Trim();
                    img3FullPath = CurrentUser.picturePath + "\\" + mDrDetail["macro_pic3"].ToString().Trim();
                    img4FullPath = CurrentUser.picturePath + "\\" + mDrDetail["macro_pic4"].ToString().Trim();
                    img5FullPath = CurrentUser.picturePath + "\\" + mDrDetail["micro_pic1"].ToString().Trim();
                    img6FullPath = CurrentUser.picturePath + "\\" + mDrDetail["micro_pic2"].ToString().Trim();
                    img7FullPath = CurrentUser.picturePath + "\\" + mDrDetail["micro_pic3"].ToString().Trim();
                    img8FullPath = CurrentUser.picturePath + "\\" + mDrDetail["micro_pic4"].ToString().Trim();

                    if (File.Exists(img1FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img1FullPath);
                        img.SetAbsolutePosition(img1OffectX, offectY);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    if (File.Exists(img2FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img2FullPath);
                        img.SetAbsolutePosition(img2OffectX, offectY);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    if (File.Exists(img3FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img3FullPath);
                        img.SetAbsolutePosition(img3OffectX, offectY);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    if (File.Exists(img4FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img4FullPath);
                        img.SetAbsolutePosition(img4OffectX, offectY);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    if (File.Exists(img5FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img5FullPath);
                        img.SetAbsolutePosition(img1OffectX, offectY - lineDistance);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    if (File.Exists(img6FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img6FullPath);
                        img.SetAbsolutePosition(img2OffectX, offectY - lineDistance);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    if (File.Exists(img7FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img7FullPath);
                        img.SetAbsolutePosition(img3OffectX, offectY - lineDistance);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    if (File.Exists(img8FullPath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(img8FullPath);
                        img.SetAbsolutePosition(img4OffectX, offectY - lineDistance);
                        img.ScaleToFit(imgWidth, imgHeight);
                        writer.DirectContent.AddImage(img);
                        p.Alignment = Element.ALIGN_LEFT;
                    }

                    offectY -= lineSize;
                }

                document.NewPage();

                if (bxcy_specimenDt != null && bxcy_specimenDt.Rows.Count > 0)
                {
                    DataRow mDr = bxcy_specimenDt.Rows[0];

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      Approved signatory: .................................."), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      {0}", mDr["sign_dr"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      Hong Kong Accreditation Service(HKAS) has "), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      accredited the St. Teresa's Hospital -"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      Histopathology Laboratory(Reg. No. HOKLAS 811P)"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      under Hong Kong Laboratory Accreditation"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      Scheme(HOKLAS) for performing specific"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      examination and, in some case, "), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      for providing clinical interprctation as listed"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      in its scope of accreditation. The examination"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      are conducted in accordance with the terms of"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("Date of report: {0} {1}                          accreditation for St. Teresa's Hospital - ", mDr["rpt_date"].ToString().Trim(), mDr["initial"].ToString().Trim()), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      Histopathology Laboratory. Report should"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("                                                                      not be reproduced except in full."), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    

                    System.Drawing.Image image = CommonFunction.CreateBarCode(mDr["barcode"].ToString().Trim());
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img.SetAbsolutePosition(40, 410);
                    writer.DirectContent.AddImage(img);
                    p.Alignment = Element.ALIGN_LEFT;

                    p = new iTextSharp.text.Paragraph(string.Format("  "), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("     Electronic copy for doctor's reference"), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);

                    p = new iTextSharp.text.Paragraph(string.Format("     Please refer to signed printed copy."), fChinese);
                    p.Alignment = Element.ALIGN_LEFT;
                    document.Add(p);
                    //document.Add(p);
                }

                /*
                document.Add(new iTextSharp.text.Paragraph("PDF1, PDF1, PDF1, PDF1, PDF1"));
                document.Add(new iTextSharp.text.Paragraph("PDF1, PDF1, PDF1, PDF1, PDF1"));
                document.Add(new iTextSharp.text.Paragraph("PDF1, PDF1, PDF1, PDF1, PDF1"));
                // 添加新页面
                document.NewPage();
                // 第二页
                // 添加第二页内容
                document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
                document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
                document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
                document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
                document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
                document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
                // 添加新页面
                document.NewPage();
                // 第三页
                // 添加新内容
                document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
                document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
                document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
                document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
                // 重新开始页面计数
                document.ResetPageCount();
                // 新建一页
                document.NewPage();
                // 第四页
                // 添加第四页内容
                document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));
                document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));
                document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));
                document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));*/
                document.Close();

                MessageBox.Show("Done!");
            }//end if
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
