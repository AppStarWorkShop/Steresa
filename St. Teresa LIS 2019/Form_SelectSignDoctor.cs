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
    public partial class Form_SelectSignDoctor : Form
    {
        private DataTable dt;
        private DataSet doctorDataSet = new DataSet();

        public delegate void SignDoctorSelectedMore(string idStr);
        public SignDoctorSelectedMore OnSignDoctorSelectedMore;

        public delegate void SignDoctorSelectedSingle(string str);
        public SignDoctorSelectedSingle OnSignDoctorSelectedSingle;

        public Form_SelectSignDoctor()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (textBox_Serch_Doctor.Focused)
                {
                    string sql = string.Format("SELECT DOC_NO,DOCTOR,id FROM [SIGN_DOCTOR] WHERE DOCTOR LIKE '%{0}%' OR CNAME LIKE '%{0}%'", textBox_Serch_Doctor.Text.Trim());
                    DBConn.fetchDataIntoDataSetSelectOnly(sql, doctorDataSet, "doctor");

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Doctor's Name");
                    dt.Columns.Add("Doctor No.");
                    dt.Columns.Add("Id");

                    foreach (DataRow mDr in doctorDataSet.Tables["sign_doctor"].Rows)
                    {
                        dt.Rows.Add(new object[] { mDr["doctor"], mDr["DOC_NO"], mDr["id"] });
                    }

                    dataGridView1.DataSource = dt;
                }
                else
                {
                    button_OK.PerformClick();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox_Serch_Doctor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string idStr = "";
            string doctorNameStr = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                doctorNameStr = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                idStr = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }

            if (idStr == "")
            {
                MessageBox.Show("No record selected");
                return;
            }
            if (OnSignDoctorSelectedMore != null)
            {
                OnSignDoctorSelectedMore(idStr);
            }
            if (OnSignDoctorSelectedSingle != null)
            {
                OnSignDoctorSelectedSingle(doctorNameStr);
            }
            this.Close();
        }

        private void loadDataGridViewDate()
        {
            string sql = string.Format("SELECT DOC_NO,DOCTOR,id FROM [SIGN_DOCTOR] WHERE DOCTOR LIKE '%{0}%'", textBox_Serch_Doctor.Text.Trim());
            DBConn.fetchDataIntoDataSetSelectOnly(sql, doctorDataSet, "sign_doctor");

            DataTable dt = new DataTable();
            dt.Columns.Add("Doctor's Name");
            dt.Columns.Add("Doctor No.");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in doctorDataSet.Tables["sign_doctor"].Rows)
            {
                dt.Rows.Add(new object[] { mDr["doctor"], mDr["DOC_NO"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 300;
            column1.ReadOnly = true;
            DataGridViewColumn column2 = dataGridView1.Columns[1];
            column2.Width = 200;
            column2.ReadOnly = true;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            column3.Width = 1;
            column3.ReadOnly = true;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

        }

        private void Form_SelectSignDoctor_Load(object sender, EventArgs e)
        {
            loadDataGridViewDate();
            dataGridViewFormat();
        }
    }
}
