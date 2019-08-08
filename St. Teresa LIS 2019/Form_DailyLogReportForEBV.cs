using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace St.Teresa_LIS_2019
{
    public partial class Form_DailyLogReportForEBV : Form
    {
        public Form_DailyLogReportForEBV()
        {
            InitializeComponent();
        }

        private void button_Preview_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "報表文件(*.csv)|*.csv";
                sfd.RestoreDirectory = true;
                sfd.FileName = "ebv_report.csv";
                string localFilePath = "c:\\temp\\ebv_report.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString();
                    string receiptDateFrom = "";
                    string receiptDateTo = "";
                    string reportDateFrom = "";
                    string reportDateTo = "";
                    string caseNoFrom = "";
                    string caseNoTo = "";

                    if (radioButton_By_Case_Date_Range.Checked)
                    {
                        receiptDateFrom = textBox_Case_Date_From.Text.Trim();
                        receiptDateTo = textBox_Case_Date_To.Text.Trim();
                    }

                    if (radioButton_By_Report_Date_Range.Checked)
                    {
                        reportDateFrom = textBox_Report_Date_From.Text.Trim();
                        reportDateTo = textBox_Report_Date_To.Text.Trim();
                    }

                    if (radioButton_By_Case_No_Range.Checked)
                    {
                        caseNoFrom = textBox_Case_No_From.Text.Trim();
                        caseNoTo = textBox_Case_No_To.Text.Trim();
                    }

                    string group = textBox_Group.Text.Trim();
                    string keywordInDiagnos = ddl_diagnosis.Text.Trim();
                    string keywordInRemind = textBox_Remind.Text.Trim();

                    string checkSql = string.Format("EXEC [sp_searchEBVSpecimentRecord] '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", receiptDateFrom, receiptDateTo, reportDateFrom, reportDateTo, caseNoFrom, caseNoTo, group, keywordInRemind, keywordInDiagnos);
                    SqlCommand checkCmd = new SqlCommand(checkSql, DBConn.getConnection());
                    checkCmd.CommandTimeout = 600;

                    SqlDataAdapter sdap = new SqlDataAdapter();
                    sdap.SelectCommand = checkCmd;

                    DataTable dt = new DataTable();
                    sdap.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("UTF-8"));
                        sw.WriteLine("case_no,barcode,ver,date,rpt_date,sign_dr,client,doctor_id,doctor_ic,doctor_o,lab_ref,ethnic,patient,cname,pat_seq,pat_birth,pat_age,pat_sex,pat_hkid,bed_room,bed_no,discharge,receipt,inv_no,inv_amt,inv_date,pay_date,diagnosis,result,result1,result2,result3,result4,result5,result6,remind,initial,priv_case,tumour,print_by,print_at,print_ctr,issue_by,issue_at,update_by,update_at,update_ctr,updated,uploaded");

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            DataRow item = dt.Rows[j];
                            string rowValue = "";
                            //rowValue += item["case_no"] + "," + item["barcode"] + "," + item["ver"] + "," + Convert.ToDateTime(item["date"]).ToString("yyyy-MM-dd") + "," + Convert.ToDateTime(item["rpt_date"]).ToString("yyyy-MM-dd") + "," + item["sign_dr"] + "," + item["client"] + "," + item["doctor_id"] + "," + item["doctor_ic"] + "," + item["doctor_o"] + "," + item["lab_ref"] + "," + item["ethnic"] + "," + item["patient"] + "," + item["cname"] + "," + item["pat_seq"] + "," + Convert.ToDateTime(item["pat_birth"]).ToString("yyyy-MM-dd") + "," + item["pat_age"] + "," + item["pat_sex"] + "," + item["pat_hkid"] + "," + item["bed_room"] + "," + item["bed_no"] + "," + item["discharge"] + "," + item["receipt"] + "," + item["inv_no"] + "," + item["inv_amt"] + "," + Convert.ToDateTime(item["inv_date"]).ToString("yyyy-MM-dd") + "," + Convert.ToDateTime(item["pay_date"]).ToString("yyyy-MM-dd") + "," + item["diagnosis"] + "," + item["result"] + "," + item["result1"] + "," + item["result2"] + "," + item["result3"] + "," + item["result4"] + "," + item["result5"] + "," + item["result6"] + "," + item["remind"] + "," + item["initial"] + "," + item["priv_case"] + "," + item["tumour"] + "," + item["print_by"] + "," + item["print_at"] + "," + item["print_ctr"] + "," + item["issue_by"] + "," + item["issue_at"] + "," + item["update_by"] + "," + item["update_at"] + "," + item["update_ctr"] + "," + item["updated"] + "," + item["uploaded"];
                            rowValue += item["case_no"] + "," + item["barcode"] + "," + item["ver"] + "," + item["date"] + "," + item["rpt_date"] + "," + item["sign_dr"] + "," + item["client"] + "," + item["doctor_id"] + "," + item["doctor_ic"] + "," + item["doctor_o"] + "," + item["lab_ref"] + "," + item["ethnic"] + "," + item["patient"] + "," + item["cname"] + "," + item["pat_seq"] + "," + item["pat_birth"] + "," + item["pat_age"] + "," + item["pat_sex"] + "," + item["pat_hkid"] + "," + item["bed_room"] + "," + item["bed_no"] + "," + item["discharge"] + "," + item["receipt"] + "," + item["inv_no"] + "," + item["inv_amt"] + "," + item["inv_date"] + "," + item["pay_date"] + "," + item["diagnosis"] + "," + item["result"] + "," + item["result1"] + "," + item["result2"] + "," + item["result3"] + "," + item["result4"] + "," + item["result5"] + "," + item["result6"] + "," + item["remind"] + "," + item["initial"] + "," + item["priv_case"] + "," + item["tumour"] + "," + item["print_by"] + "," + item["print_at"] + "," + item["print_ctr"] + "," + item["issue_by"] + "," + item["issue_at"] + "," + item["update_by"] + "," + item["update_at"] + "," + item["update_ctr"] + "," + item["updated"] + "," + item["uploaded"];

                            sw.WriteLine(rowValue);
                        }
                        sw.Close();
                        MessageBox.Show("Export done");
                    }
                    else
                    {
                        MessageBox.Show("No record found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show("Fail to export the file");
            }
        }

        private void Form_DailyLogReportForEBV_Load(object sender, EventArgs e)
        {
            radioButton_By_Case_Date_Range.Checked = true;
            setFieldStatus();
            textBox_Case_Date_From.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox_Case_Date_To.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox_Report_Date_From.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox_Report_Date_To.Text = DateTime.Now.ToString("yyyy-MM-dd");

            string diagnosisSql = "SELECT '' AS DIAGNOSIS UNION SELECT DIAGNOSIS FROM [diagnosis]";
            DataSet diagnosisDataSet = new DataSet();
            SqlDataAdapter diagnosisDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diagnosisSql, diagnosisDataSet, "diagnosis");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("DIAGNOSIS");

            foreach (DataRow mDr in diagnosisDataSet.Tables["diagnosis"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["DIAGNOSIS"] });
            }

            ddl_diagnosis.DataSource = newDt;
        }

        private void setFieldStatus()
        {
            if (radioButton_By_Case_Date_Range.Checked)
            {
                textBox_Case_Date_From.Enabled = true;
                textBox_Case_Date_To.Enabled = true;
            }
            else
            {
                textBox_Case_Date_From.Enabled = false;
                textBox_Case_Date_To.Enabled = false;
            }

            if (radioButton_By_Report_Date_Range.Checked)
            {
                textBox_Report_Date_From.Enabled = true;
                textBox_Report_Date_To.Enabled = true;
            }
            else
            {
                textBox_Report_Date_From.Enabled = false;
                textBox_Report_Date_To.Enabled = false;
            }

            if (radioButton_By_Case_No_Range.Checked)
            {
                textBox_Case_No_From.Enabled = true;
                textBox_Case_No_To.Enabled = true;
            }
            else
            {
                textBox_Case_No_From.Enabled = false;
                textBox_Case_No_To.Enabled = false;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {

        }

        private void radioButton_By_Case_Date_Range_CheckedChanged(object sender, EventArgs e)
        {
            setFieldStatus();
        }

        private void radioButton_By_Report_Date_Range_CheckedChanged(object sender, EventArgs e)
        {
            setFieldStatus();
        }

        private void radioButton_Over_due_For_One_Day_CheckedChanged(object sender, EventArgs e)
        {
            setFieldStatus();
        }

        private void radioButton_By_Case_No_Range_CheckedChanged(object sender, EventArgs e)
        {
            setFieldStatus();
        }
    }
}
