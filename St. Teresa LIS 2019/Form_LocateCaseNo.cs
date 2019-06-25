using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace St.Teresa_LIS_2019
{
    public partial class Form_LocateCaseNo : Form
    {
        private DataTable dt;
        private DataSet ebv_specimenDataSet = new DataSet();

        public Form_LocateCaseNo()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_LocateCaseNo_Load(object sender, EventArgs e)
        {
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
                string id = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                Form_EBVFile open = new Form_EBVFile(id);
                open.Show();
            }
        }

        private void loadDataGridViewDate()
        {
            string sql = "SELECT CASE_NO,RPT_DATE,PATIENT,VER,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_ID,id FROM ebv_specimen";
            DBConn.fetchDataIntoDataSetSelectOnly(sql, ebv_specimenDataSet, "ebv_specimen");

            DataTable dt = new DataTable();
            //dt.Columns.Add("Select", typeof(bool));
            dt.Columns.Add("Case No.");
            dt.Columns.Add("Report Date");
            dt.Columns.Add("Patient");
            dt.Columns.Add(" ");
            dt.Columns.Add("Age");
            dt.Columns.Add("Sex");
            dt.Columns.Add("HKID No.");
            dt.Columns.Add("Client");
            dt.Columns.Add("Doctor In Charge");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in ebv_specimenDataSet.Tables["ebv_specimen"].Rows)
            {
                dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["RPT_DATE"], mDr["PATIENT"], mDr["VER"], mDr["PAT_AGE"], mDr["PAT_SEX"], mDr["PAT_HKID"], mDr["CLIENT"], mDr["DOCTOR_ID"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
        }

        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
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
            column9.Width = 1;
            column9.ReadOnly = true;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                string sql = string.Format("SELECT CASE_NO,RPT_DATE,PATIENT,VER,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_ID,id FROM ebv_specimen WHERE CASE_NO LIKE '%{0}%' OR PATIENT LIKE '%{0}%' OR PAT_HKID LIKE '%{0}%' OR PAT_HIST LIKE '%{0}%' OR CLIENT LIKE '%{0}%' OR DOCTOR_ID LIKE '%{0}%'", textBox_Search_Type.Text.Trim());
                DBConn.fetchDataIntoDataSetSelectOnly(sql, ebv_specimenDataSet, "ebv_specimen");

                DataTable dt = new DataTable();
                //dt.Columns.Add("Select", typeof(bool));
                dt.Columns.Add("Case No.");
                dt.Columns.Add("Report Date");
                dt.Columns.Add("Patient");
                dt.Columns.Add(" ");
                dt.Columns.Add("Age");
                dt.Columns.Add("Sex");
                dt.Columns.Add("HKID No.");
                dt.Columns.Add("Client");
                dt.Columns.Add("Doctor In Charge");
                dt.Columns.Add("Id");

                foreach (DataRow mDr in ebv_specimenDataSet.Tables["ebv_specimen"].Rows)
                {
                    dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["RPT_DATE"], mDr["PATIENT"], mDr["VER"], mDr["PAT_AGE"], mDr["PAT_SEX"], mDr["PAT_HKID"], mDr["CLIENT"], mDr["DOCTOR_ID"], mDr["id"] });
                }

                dataGridView1.DataSource = dt;
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

            return base.ProcessCmdKey(ref msg, keyData);
            
        }

        private void button_F2_New_Record_Click(object sender, EventArgs e)
        {
            Form_EBVFile open = new Form_EBVFile();
            open.Show();
            open.processNew();
        }

        private void buttonF3_Edit_Record_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
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
    }
}
