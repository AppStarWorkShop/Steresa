﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace St.Teresa_LIS_2019
{
    public partial class Form_EBVRecordSearch : Form
    {
        private DataTable dt;
        private DataSet ebv_specimenDataSet = new DataSet();

        private string labelSearching = "Locate Case No:";
        private string contentSearching = "CASE_NO";

        private string whereStr = "";
        private string whereVal = "";
        private int dateMode = 1;
        private string dateFrom = "";
        private string dateTo = "";

        int pageSize = 30;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行

        private int columnType = 1;

        public Form_EBVRecordSearch()
        {
            InitializeComponent();
            label_Search_Type.Text = labelSearching;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_LocateCaseNo_Load(object sender, EventArgs e)
        {
            whereStr = "";
            whereVal = "";
            pageCurrent = 1;
            loadDataGridViewDate();
            dataGridViewFormat();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_F6_View_Record_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                Form_EBVFile open = new Form_EBVFile(id);
                open.Show();
            }
        }

        private void loadDataGridViewDate(int currentPageNum = 1)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            /*string sql = "SELECT CASE_NO,RPT_DATE,PATIENT,VER,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_ID,id FROM ebv_specimen ORDER BY ID";
            DBConn.fetchDataIntoDataSetSelectOnly(sql, ebv_specimenDataSet, "ebv_specimen");*/

            string sql = string.Format("getEBVSpecimentByPage");
            SqlCommand checkCmd = new SqlCommand(sql, DBConn.getConnection());
            checkCmd.CommandType = CommandType.StoredProcedure;

            checkCmd.Parameters.Add(new SqlParameter("@pageCount", SqlDbType.Int));
            checkCmd.Parameters.Add(new SqlParameter("@pageNum", SqlDbType.Int));
            checkCmd.Parameters.Add(new SqlParameter("@whereStr", SqlDbType.NVarChar));
            checkCmd.Parameters.Add(new SqlParameter("@whereVal", SqlDbType.NVarChar));
            checkCmd.Parameters.Add(new SqlParameter("@dateMode", SqlDbType.Int));
            checkCmd.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.NVarChar));
            checkCmd.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.NVarChar));

            checkCmd.Parameters["@pageCount"].Value = pageSize;
            checkCmd.Parameters["@pageNum"].Value = currentPageNum;
            checkCmd.Parameters["@whereStr"].Value = whereStr;
            checkCmd.Parameters["@whereVal"].Value = whereVal;
            checkCmd.Parameters["@dateMode"].Value = dateMode;
            checkCmd.Parameters["@dateFrom"].Value = dateFrom;
            checkCmd.Parameters["@dateTo"].Value = dateTo;

            checkCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            checkCmd.CommandTimeout = 600;
            SqlDataAdapter sdap = new SqlDataAdapter();
            sdap.SelectCommand = checkCmd;
            DataTable dtDb = new DataTable();
            sdap.Fill(dtDb);

            pageCount = (int)checkCmd.Parameters["@RETURN_VALUE"].Value;

            DataTable dt = new DataTable();
            if (columnType == 1)
            {
                dt.Columns.Add("Case No.");
                dt.Columns.Add("Report Date");
                dt.Columns.Add("Patient");
                dt.Columns.Add(" ");
                dt.Columns.Add("Seq");
                dt.Columns.Add("Age");
                dt.Columns.Add("Sex");
                dt.Columns.Add("HKID No.");
                dt.Columns.Add("Client");
                dt.Columns.Add("Doctor In Charge");
                dt.Columns.Add("Result");
                dt.Columns.Add("Diagnosis");
                dt.Columns.Add("Date Received");
                dt.Columns.Add("Id");
                dt.Columns.Add("Lab Ref");
                dt.Columns.Add("Doctor ID");

                foreach (DataRow mDr in dtDb.Rows)
                {
                    dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["RPT_DATE"], mDr["PATIENT"], mDr["VER"], mDr["PAT_SEQ"], mDr["PAT_AGE"], mDr["PAT_SEX"], mDr["PAT_HKID"], mDr["CLIENT"], mDr["DOCTOR_IC"], mDr["result"], mDr["diagnosis"], mDr["date"],mDr["id"], mDr["LAB_REF"], mDr["DOCTOR_ID"] });
                }
            }
            else
            {
                dt.Columns.Add("Case No.");
                dt.Columns.Add("Report Date");
                dt.Columns.Add("Patient");
                dt.Columns.Add(" ");
                dt.Columns.Add("Seq");
                dt.Columns.Add("Age");
                dt.Columns.Add("Sex");
                dt.Columns.Add("Date Received");
                dt.Columns.Add("Result");
                dt.Columns.Add("Diagnosis");
                dt.Columns.Add("Client");
                dt.Columns.Add("Doctor In Charge");
                dt.Columns.Add("HKID No.");
                dt.Columns.Add("Id");
                dt.Columns.Add("Lab Ref");
                dt.Columns.Add("Doctor ID");

                foreach (DataRow mDr in dtDb.Rows)
                {
                    dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["RPT_DATE"], mDr["PATIENT"], mDr["VER"], mDr["PAT_SEQ"], mDr["PAT_AGE"], mDr["PAT_SEX"], mDr["date"] ,mDr["result"], mDr["diagnosis"], mDr["CLIENT"], mDr["DOCTOR_IC"], mDr["PAT_HKID"], mDr["id"], mDr["LAB_REF"], mDr["DOCTOR_ID"] });
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            LoadData();
        }

        private void dataGridViewFormat()
        {
            /*DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 90;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 120;
            column1.ReadOnly = true;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 120;
            column2.ReadOnly = true;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 100;
            column3.ReadOnly = true;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 100;
            column4.ReadOnly = true;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 100;
            column5.ReadOnly = true;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 100;
            column6.ReadOnly = true;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 100;
            column7.ReadOnly = true;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 120;
            column8.ReadOnly = true;
            DataGridViewColumn column9 = dataGridView1.Columns[9];
            column9.Width = 100;
            column9.ReadOnly = true;*/
            DataGridViewColumn column13 = dataGridView1.Columns[13];
            column13.Width = 1;
            column13.ReadOnly = true;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            column14.Width = 1;
            column14.ReadOnly = true;

            DataGridViewColumn column15 = dataGridView1.Columns[15];
            column15.Width = 1;
            column15.ReadOnly = true;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

        }

        private void searchRecord()
        {
            whereStr = contentSearching;
            whereVal = textBox_Search_Type.Text.Trim();

            if (radioButton_Data_All.Checked)
            {
                dateMode = 1;
            }
            else
            {
                if (radioButton_Data_Past_7.Checked)
                {
                    dateMode = 2;
                }
                else
                {
                    if (radioButton_Data_Past_14.Checked)
                    {
                        dateMode = 3;
                    }
                    else
                    {
                        if (radioButton_Data_Past_28.Checked)
                        {
                            dateMode = 4;
                        }
                        else
                        {
                            dateMode = 5;
                        }
                    }
                }
            }

            dateFrom = dateTimePicker_From.Value.ToString("yyyy-MM-dd");
            dateTo = dateTimePicker_To.Value.ToString("yyyy-MM-dd");

            loadDataGridViewDate();

            setButtonStatus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                switch (contentSearching)
                {
                    case "CASE_NO":
                        contentSearching = "PATIENT";
                        labelSearching = "Patient:";
                        break;
                    case "PATIENT":
                        contentSearching = "PAT_HKID";
                        labelSearching = "Patient HKID:";
                        break;
                    case "PAT_HKID":
                        contentSearching = "LAB_REF";
                        labelSearching = "Hospital NO.:";
                        break;
                    case "hospitalNo":
                        contentSearching = "client";
                        labelSearching = "Client:";
                        break;
                    case "client":
                        contentSearching = "DOCTOR_ID";
                        labelSearching = "Doctor:";
                        break;
                    case "DOCTOR_ID":
                        contentSearching = "CASE_NO";
                        labelSearching = "Locate Case No:";
                        break;
                    default:
                        contentSearching = "CASE_NO";
                        labelSearching = "Locate Case No:";
                        break;
                }

                label_Search_Type.Text = labelSearching;
                setButtonStatus();
            }

            if (keyData == Keys.Enter && (textBox_Search_Type.Focused || radioButton_Data_All.Focused || radioButton_Data_Past_7.Focused || radioButton_Data_Past_14.Focused || radioButton_Data_Past_28.Focused || radioButton_Data_From.Focused || dateTimePicker_From.Focused || dateTimePicker_To.Focused))
            {
                searchRecord();

                return true;
            }

            if (keyData == Keys.Enter && txtCurrentPage.Focused)
            {
                int inputPage;
                bool result = int.TryParse(txtCurrentPage.Text, out inputPage);
                if (result)
                {
                    if (inputPage > 0 && inputPage <= pageCount)
                    {
                        pageCurrent = inputPage;
                        loadDataGridViewDate(pageCurrent);
                    }
                    else
                    {
                        MessageBox.Show("Invalid page num");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid page num");
                }
                return true;
            }

            if (keyData == Keys.F2)
            {
                button_F2_New_Record.PerformClick();
                return true;
            }

            if (keyData == Keys.F3)
            {
                buttonF3_Edit_Record.PerformClick();
                return true;
            }

            if (keyData == Keys.F4)
            {
                button_F4_Daily_Report.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
                button_F5_New_Patient.PerformClick();
                return true;
            }

            if (keyData == Keys.F6)
            {
                button_F6_View_Record.PerformClick();
                return true;
            }

            if (keyData == Keys.F7)
            {
                button_F7_Columas.PerformClick();
                return true;
            }

            if (keyData == Keys.F && textBox_Search_Type.Focused && textBox_Search_Type.Text.Trim() == "")
            {
                textBox_Search_Type.Text = string.Format("HN{0}", DateTime.Now.ToString("yyyy"));
                textBox_Search_Type.Focus();
                textBox_Search_Type.Select(textBox_Search_Type.TextLength, 0);
                textBox_Search_Type.ScrollToCaret();
                return true;
            }

            if (keyData == Keys.A && textBox_Search_Type.Focused && textBox_Search_Type.Text.Trim() == "")
            {
                textBox_Search_Type.Text = string.Format("DC{0}", DateTime.Now.ToString("yyyy"));
                textBox_Search_Type.Focus();
                textBox_Search_Type.Select(textBox_Search_Type.TextLength, 0);
                textBox_Search_Type.ScrollToCaret();
                return true;
            }

            if (keyData == Keys.B && textBox_Search_Type.Focused && textBox_Search_Type.Text.Trim() == "")
            {
                textBox_Search_Type.Text = string.Format("OP{0}", DateTime.Now.ToString("yyyy"));
                textBox_Search_Type.Focus();
                textBox_Search_Type.Select(textBox_Search_Type.TextLength, 0);
                textBox_Search_Type.ScrollToCaret();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
            
        }

        private void button_F2_New_Record_Click(object sender, EventArgs e)
        {
            Form_EBVFile open = new Form_EBVFile();
            open.Show();
            open.patientCopy(textBox_Search_Type.Text.Trim());
        }

        private void buttonF3_Edit_Record_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                Form_EBVFile open = new Form_EBVFile(id);
                open.Show();
                open.processEdit();
            }
        }

        private void button_F5_New_Patient_Click(object sender, EventArgs e)
        {
            Form_PatientFileMaintenancecs open = new Form_PatientFileMaintenancecs();
            open.Show();
            open.processNew();
        }

        private void button_F4_Daily_Report_Click(object sender, EventArgs e)
        {
            Form_DailyLogReportForEBV open = new Form_DailyLogReportForEBV();
            open.Show();
        }

        private void button_F7_Columas_Click(object sender, EventArgs e)
        {
            if(columnType == 1)
            {
                columnType = 2;
            }
            else
            {
                columnType = 1;
            }

            loadDataGridViewDate(pageCurrent);
        }

        private void LoadData()
        {
            lblPageCount.Text = pageCount.ToString();
            txtCurrentPage.Text = Convert.ToString(pageCurrent);
        }

        private void BindingNavigate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Top")
            {
                pageCurrent = 1;
                loadDataGridViewDate(pageCurrent);
            }
            if (e.ClickedItem.Text == "End")
            {
                pageCurrent = pageCount;
                loadDataGridViewDate(pageCurrent);
            }
            if (e.ClickedItem.Text == "Previous")
            {
                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("It is the first page");
                    return;
                }
                else
                {
                    loadDataGridViewDate(pageCurrent);
                    //nCurrent = pageSize * (pageCurrent - 1);
                }
            }
            if (e.ClickedItem.Text == "Next")
            {
                pageCurrent++;
                if (pageCurrent > pageCount)
                {
                    MessageBox.Show("It is the last page");
                    return;
                }
                else
                {
                    loadDataGridViewDate(pageCurrent);
                    //nCurrent = pageSize * (pageCurrent - 1);
                }
            }
        }

        private void radioButton_Data_From_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Data_From.Checked)
            {
                dateTimePicker_From.Enabled = true;
                dateTimePicker_To.Enabled = true;
            }
            else
            {
                dateTimePicker_From.Enabled = false;
                dateTimePicker_To.Enabled = false;
            }
        }

        private void textBox_Search_Type_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Search_Type.Text.Trim().IndexOf("/") != -1)
            {
                string subTextStr = textBox_Search_Type.Text.Trim().Substring(textBox_Search_Type.Text.Trim().IndexOf("/"));
                if (subTextStr.Length >= 4)
                {
                    searchRecord();
                }
            }
        }

        private void setButtonStatus()
        {
            button_F2_New_Record.Enabled = true;
            buttonF3_Edit_Record.Enabled = true;
            button_F5_New_Patient.Enabled = true;
            button_F6_View_Record.Enabled = true;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                buttonF3_Edit_Record.Enabled = true;
                button_F6_View_Record.Enabled = true;
            }
            else
            {
                buttonF3_Edit_Record.Enabled = false;
                button_F6_View_Record.Enabled = false;
            }

            if(contentSearching == "CASE_NO" && textBox_Search_Type.Text.Trim() != "")
            {
                button_F2_New_Record.Enabled = true;
            }
            else
            {
                button_F2_New_Record.Enabled = false;
            }

            if (contentSearching == "PATIENT" && textBox_Search_Type.Text.Trim() != "")
            {
                DataSet copyEbvDataSet = new DataSet();

                string sql = string.Format("SELECT TOP 1 * FROM [EBV_SPECIMEN] WHERE PATIENT = '{0}'", textBox_Search_Type.Text.Trim());
                DBConn.fetchDataIntoDataSetSelectOnly(sql, copyEbvDataSet, "EBV_SPECIMEN");

                if (copyEbvDataSet.Tables["EBV_SPECIMEN"].Rows.Count > 0)
                {
                    button_F5_New_Patient.Enabled = false;
                }
                else
                {
                    button_F5_New_Patient.Enabled = true;
                }
            }
            else
            {
                button_F5_New_Patient.Enabled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Row Click!!!!!!" );
            if (dataGridView1.SelectedRows.Count > 0)
            {
                switch (contentSearching)
                {
                    case "CASE_NO":
                        textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        break;
                    case "PATIENT":
                        textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        break;
                    case "PAT_HKID":
                        if (columnType == 1)
                        {
                            textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                        }
                        else
                        {
                            textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                        }
                            
                        break;
                    case "hospitalNo":
                        textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                        break;
                    case "client":
                        if (columnType == 1)
                        {
                            textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                        }
                        else
                        {
                            textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                        }

                        break;
                    case "DOCTOR_ID":
                        textBox_Search_Type.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                        break;
                }

                setButtonStatus();
            }
        }
    }
}
