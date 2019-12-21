using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace St.Teresa_LIS_2019
{
    public partial class Form_ReportPreview : Form
    {
        public const String ONE_PHOTO = "_one_photo";
        public const String TWO_PHOTO = "_two_photo";
        public const String MULTIPLE_PHOTO = "_multiple_photo";
        public const String ST_BX_NO_PHOTO = "01 STH BX";
        public const String ST_BX_ONE_PHOTO = "01 STH BX" + ONE_PHOTO;
        public const String ST_BX_TWO_PHOTO = "01 STH BX" + TWO_PHOTO;
        public const String ST_BX_MULTIPLE_PHOTO = "01 STH BX" + MULTIPLE_PHOTO;
        public const String PRIVATE_BX = "18 PRIVATE BX";
        public const String PRIVATE_BX_ONE_PHOTO = PRIVATE_BX + ONE_PHOTO;
        public const String PRIVATE_BX_TWO_PHOTO = PRIVATE_BX + TWO_PHOTO;
        public const String PRIVATE_BX_MULTIPLE_PHOTO = PRIVATE_BX + MULTIPLE_PHOTO;

        private String reportType;
        private String caseNo;
        private String reportNo = "1";
        private String showHKAS = "1";

        public Form_ReportPreview()
        {
            InitializeComponent();

            List<string> reportList = new List<string>();
            reportList.Add(ST_BX_NO_PHOTO);
            //reportList.Add("02 STH BX noHKAS");
            //reportList.Add("03 PBH BX");
            //reportList.Add("04 HKAH BX");
            //reportList.Add("05 TWAH BX");
            reportList.Add("06 PATHLAB BX");
            //reportList.Add("07 EVANGEL BX");
            reportList.Add("08 STH CY");
            //reportList.Add("10 PBH CY");
            //reportList.Add("11 HKAH CY");
            //reportList.Add("12 TWAH CY");
            reportList.Add("13 PATHLAB CY");
            //reportList.Add("14 EVANGEL CY");
            //reportList.Add("15 ONCO CY");
            reportList.Add("16 BIO-TECH CY");
            //reportList.Add("17 CY Screening");
            reportList.Add(PRIVATE_BX);
            reportList.Add(PRIVATE_BX_ONE_PHOTO);
            reportList.Add(PRIVATE_BX_TWO_PHOTO);
            reportList.Add(PRIVATE_BX_MULTIPLE_PHOTO);

            reportList.Add("19 PRIVATE CY");
            /*
            reportList.Add("58 STH EBV");
            reportList.Add("59 PBH EBV");
            reportList.Add("60 Private EBV");
            reportList.Add("61 Private EBV 6 Doctor");
            reportList.Add("63 STH CY Diagnosis");
            reportList.Add("64 STH CY Diagnosis without Primary Screener");
            reportList.Add("65 STH CY Diagnosis noHKAS");
            reportList.Add("66 PBH CY Diagnosis");
            reportList.Add("67 Private CY Diagnosis");
            reportList.Add("68 HKAH CY Diagnosis");
            reportList.Add("69 TWAH CY Diagnosis");
            reportList.Add("70 Private CY 6 Doctors");
            reportList.Add("71 ONCO CY Diagnosis");
            reportList.Add("72 Bio-Tech CY Diagnosis");
            reportList.Add("73 Evangel CY Diagnosis");
            reportList.Add("75 Invoice Report Detail");
            reportList.Add("79 Invoice Report Summary");
            reportList.Add("82 Daily Log Report For Gynaecological Cases");
            reportList.Add("84 Daily Log Report By Cut Off Date Time");
            */
            reportList.Add(ST_BX_ONE_PHOTO);
            reportList.Add(ST_BX_TWO_PHOTO);
            reportList.Add(ST_BX_MULTIPLE_PHOTO);

            comboBoxReportType.DataSource = reportList;
        }

        public DataTable GetDataTable(string ConnectionString, string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public void setReportParameter(String iReportType, String iCaseNo, String iReportNo, String ishowHKAS)
        {
            reportType = iReportType;
            caseNo = iCaseNo;
            if (iReportNo == null || iReportNo.Trim().Length < 1)
            {
                reportNo = "1";
            }
            else
            {
                reportNo = iReportNo;
            }
            

            if (reportType != null && reportType.Trim().Length > 0)
            {
                comboBoxReportType.Text = reportType;
            }

            if (caseNo != null && caseNo.Trim().Length > 0)
            {
                textBoxCaseNo.Text = caseNo;
            }

            if (reportNo != null && reportNo.Trim().Length > 0)
            {
                textBoxReportNo.Text = reportNo;
            }

            if (ishowHKAS != null)
            {
                showHKAS = ishowHKAS;
                textBoxHKAS.Text = ishowHKAS;
            }
            
        }

        private void MySubreportEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            string sqlCon = Properties.Settings.Default.medlabConnectionString;
            string sql = "";
            string reportPath = e.ReportPath;
            
            
            sql = "select top 1 *, dbo.reportCaseNo(case_no) as pathNo, dbo.reportAge(pat_age) as pathAge from BXCY_SPECIMEN where case_no = '" + caseNo + "'";
            DataTable table1 = GetDataTable(sqlCon, sql);
            table1.TableName = "BXCY_SPECIMEN";

            sql = "select * from BXCY_DIAG where case_no = '" + caseNo + "' and [GROUP] = '" + textBoxReportNo.Text + "' ";
            DataTable table2 = GetDataTable(sqlCon, sql);
            table2.TableName = "BXCY_DIAG";

            /*
            String sql = "select top 1 macro_name, macro_desc, micro_name, micro_desc, macro_pic1, macro_pic2, macro_pic3, macro_pic4, "
                + "macro_cap1, macro_cap2, macro_cap3, macro_cap4 from BXCY_DIAG where isnull(macro_name, '') <> '' and case_no = '" + caseNo + "' AND [GROUP] = '" + textBoxReportNo.Text +  "'";
            */
            sql = "select top 1 macro_name, macro_desc, micro_name, micro_desc, macro_pic1, macro_pic2, macro_pic3, macro_pic4, "
                + "macro_cap1, macro_cap2, macro_cap3, macro_cap4, dbo.fn_reportName([GROUP]) as [GROUP] from BXCY_DIAG where case_no = '" + caseNo + "' AND [GROUP] = '" + textBoxReportNo.Text + "'";
            DataTable table3 = GetDataTable(sqlCon, sql );
            table3.TableName = "Macro_Micro";

            DataTable table4 = GetDataTable(sqlCon, "select top 1 s.case_no , s.sign_dr, d.ename, d.cname, d.title from BXCY_SPECIMEN s left join sign_doctor d on (s.sign_dr = d.DOCTOR) where case_no = '" + caseNo + "'");
            table4.TableName = "signedDoctor";

            
            if (textBoxHKAS.Text == "0")
            {
                sql = "select record_status, pat_age_str, '0' as hkas, report_number, org_case_no, lastUpdateInitial from v_reportHeader where org_case_no = '" + caseNo + "'";
            } 
            else
            {
                sql = "select record_status, pat_age_str, '1' as hkas, report_number, org_case_no, lastUpdateInitial from v_reportHeader where org_case_no = '" + caseNo + "'";
            }
            DataTable table5 = GetDataTable(sqlCon, sql);
            table5.TableName = "reportExtra";

            Microsoft.Reporting.WinForms.ReportDataSource table1DS = new Microsoft.Reporting.WinForms.ReportDataSource(table1.TableName, table1);
            e.DataSources.Add(table1DS);

            Microsoft.Reporting.WinForms.ReportDataSource table2DS = new Microsoft.Reporting.WinForms.ReportDataSource(table2.TableName, table2);
            e.DataSources.Add(table2DS);

            Microsoft.Reporting.WinForms.ReportDataSource table3DS = new Microsoft.Reporting.WinForms.ReportDataSource(table3.TableName, table3);
            e.DataSources.Add(table3DS);

            Microsoft.Reporting.WinForms.ReportDataSource table4DS = new Microsoft.Reporting.WinForms.ReportDataSource(table4.TableName, table4);
            e.DataSources.Add(table4DS);

            Microsoft.Reporting.WinForms.ReportDataSource table5DS = new Microsoft.Reporting.WinForms.ReportDataSource(table5.TableName, table5);
            e.DataSources.Add(table5DS);

            if (e.ReportPath == "STH_common_header")
            {
                if (textBoxHKAS.Text == "0")
                {
                    sql = "select top 1 dbo.reportCaseNo(case_no) as case_no, patient, cname, pat_hkid, '0' as hkas from v_reportHeader where org_case_no = '" + caseNo + "'";
                }
                else
                {
                    sql = "select top 1 dbo.reportCaseNo(case_no) as case_no, patient, cname, pat_hkid, '1' as hkas from v_reportHeader where org_case_no = '" + caseNo + "'";
                }
                DataTable headerDt = null;
                headerDt = GetDataTable(sqlCon, sql);
                headerDt.TableName = "Header";
                Microsoft.Reporting.WinForms.ReportDataSource headerDS = new Microsoft.Reporting.WinForms.ReportDataSource(headerDt.TableName, headerDt);
                e.DataSources.Add(headerDS);
            }
        }

        private DataTable LoadHeader(String reportName, String caseNo)
        {
            string sqlCon = Properties.Settings.Default.medlabConnectionString;
            String sql = "";

            DataTable headerDt = null;
            string[] args = null;
            switch (reportName)
            {
                case "01 STH BX":
                    if (textBoxHKAS.Text == "0")
                    {
                        sql = "select top 1 dbo.reportCaseNo(case_no) as case_no, patient, cname, pat_hkid, '0' as hkas from v_reportHeader where org_case_no = '" + caseNo + "'";
                    }
                    else
                    {
                        sql = "select top 1 dbo.reportCaseNo(case_no) as case_no, patient, cname, pat_hkid, '1' as hkas from v_reportHeader where org_case_no = '" + caseNo + "'";
                    }
                        
                    headerDt = GetDataTable(sqlCon, sql);
                    break;

                case "75 Invoice Report Detail":
                    args = new string[] { "01/28/2019", "02/28/2019", "INV12345", "03/28/2019" };
                    headerDt = GetDataTable(sqlCon, "select '" + args[0] + "' start_date, '" + args[1] + "' end_date, '" + args[2] + "' inv_no, '" + args[3] + "' inv_date");
                    break;
                case "79 Invoice Report Summary":
                    args = new string[] { "01/28/2019", "02/28/2019", "All Types" };
                    headerDt = GetDataTable(sqlCon, "select '" + args[0] + "' start_date, '" + args[1] + "' end_date, '" + args[2] + "' inv_type");
                    break;
                case "82 Daily Log Report For Gynaecological Cases":
                    args = new string[] { "01/28/2019", "02/28/2019", "03/28/2019" };
                    headerDt = GetDataTable(sqlCon, "select '" + args[0] + "' start_date, '" + args[1] + "' end_date, '" + args[2] + "' inv_date");
                    break;
                case "84 Daily Log Report By Cut Off Date Time":
                    args = new string[] { "01/28/2019 11:11:11", "02/28/2019 14:14:14", "03/28/2019" };
                    headerDt = GetDataTable(sqlCon, "select '" + args[0] + "' start_date, '" + args[1] + "' end_date, '" + args[2] + "' inv_date");
                    break;
                default:
                    if (showHKAS == "0")
                    {
                        sql = "select top 1 dbo.reportCaseNo(case_no) as case_no, patient, cname, pat_hkid, '0' as hkas from v_reportHeader where org_case_no = '" + caseNo + "'";
                    }
                    else
                    {
                        sql = "select top 1 dbo.reportCaseNo(case_no) as case_no, patient, cname, pat_hkid, '1' as hkas from v_reportHeader where org_case_no = '" + caseNo + "'";
                    }
                    headerDt = GetDataTable(sqlCon, sql);
                    break;
            }
            if (headerDt != null)
            {
                headerDt.TableName = "Header";
            }

            return headerDt;
        }

        private DataTable LoadFooter(String reportName)
        {
            string sqlCon = Properties.Settings.Default.medlabConnectionString;

            DataTable footerDt = null;
            string[] args = null;
            switch (reportName)
            {
                default:
                    footerDt = GetDataTable(sqlCon, "select top 1 rpt_date, rtrim(barcode) barcode, initial, sign_dr from BXCY_SPECIMEN where case_no = '" + caseNo + "'");
                    break;
            }
            if (footerDt != null)
            {
                footerDt.TableName = "Footer";
            }

            return footerDt;
        }

        public void showReport()
        {
            string sqlCon = Properties.Settings.Default.medlabConnectionString;

            string report = comboBoxReportType.SelectedValue.ToString();
            caseNo = textBoxCaseNo.Text;

            this.FindForm().Controls.Remove(this.reportViewer1);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportEventHandler);

            string exeFolder = (Path.GetDirectoryName(Application.StartupPath)).Substring(0, (Path.GetDirectoryName(Application.StartupPath)).Length - 3);
            string reportPath = Path.Combine(exeFolder, @"Report/" + report + ".rdlc");

            this.reportViewer1.LocalReport.ReportPath = reportPath;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            //String subReportPath = Path.Combine(exeFolder, @"Report/" + "BodyENOnePhoto" + ".rdlc");
            //this.reportViewer1.LocalReport.LoadSubreportDefinition("Subreport1", new StreamReader(subReportPath));

            DataTable headerDt = LoadHeader(report, caseNo);
            if (headerDt != null)
            {
                Microsoft.Reporting.WinForms.ReportDataSource headerDS = new Microsoft.Reporting.WinForms.ReportDataSource(headerDt.TableName, headerDt);
                this.reportViewer1.LocalReport.DataSources.Add(headerDS);
                
            }

            DataTable footerDt = LoadFooter(report);
            if (footerDt != null)
            {
                Microsoft.Reporting.WinForms.ReportDataSource footerDS = new Microsoft.Reporting.WinForms.ReportDataSource(footerDt.TableName, footerDt);
                this.reportViewer1.LocalReport.DataSources.Add(footerDS);
            }

            this.reportViewer1.Width = this.FindForm().Width;
            this.reportViewer1.Height = this.FindForm().Height;

            this.reportViewer1.RefreshReport();
            this.reportViewer1.Show();

            this.FindForm().Controls.Add(reportViewer1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlCon = Properties.Settings.Default.medlabConnectionString;

            string report = comboBoxReportType.SelectedValue.ToString();
            caseNo = textBoxCaseNo.Text;

            this.FindForm().Controls.Remove(this.reportViewer1);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportEventHandler);

            string exeFolder = (Path.GetDirectoryName(Application.StartupPath)).Substring(0, (Path.GetDirectoryName(Application.StartupPath)).Length - 3);
            string reportPath = Path.Combine(exeFolder, @"Report/" + report + ".rdlc");

            this.reportViewer1.LocalReport.ReportPath = reportPath;
            this.reportViewer1.LocalReport.EnableExternalImages = true;

            DataTable headerDt = LoadHeader(report, caseNo);
            if (headerDt != null)
            {
                Microsoft.Reporting.WinForms.ReportDataSource headerDS = new Microsoft.Reporting.WinForms.ReportDataSource(headerDt.TableName, headerDt);
                this.reportViewer1.LocalReport.DataSources.Add(headerDS);
            }

            DataTable footerDt = LoadFooter(report);
            if (footerDt != null)
            {
                Microsoft.Reporting.WinForms.ReportDataSource footerDS = new Microsoft.Reporting.WinForms.ReportDataSource(footerDt.TableName, footerDt);
                this.reportViewer1.LocalReport.DataSources.Add(footerDS);
            }

            this.reportViewer1.Width = this.FindForm().Width;
            this.reportViewer1.Height = this.FindForm().Height;

            this.reportViewer1.RefreshReport();
            this.reportViewer1.Show();

            this.FindForm().Controls.Add(reportViewer1);
        }

        private void textBoxCaseNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
