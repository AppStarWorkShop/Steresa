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
    public partial class Form_DigitalSignature : Form
    {
        private DataTable dt;
        private DataSet bxcy_specimenDataSet = new DataSet();

        private string currentDoctorName;
        public Form_DigitalSignature()
        {
            InitializeComponent();
        }

        public Form_DigitalSignature(string currentDoctorName)
        {
            this.currentDoctorName = currentDoctorName;
            InitializeComponent();
        }

        private void loadDataGridViewDate(string searchCaseNo = "")
        {
            string sql = string.Format("select * from BXCY_SPECIMEN where sign_dr = '{0}'", currentDoctorName);
            if (searchCaseNo != "")
            {
                sql = string.Format("select * from BXCY_SPECIMEN where (sign_dr = '{0}' or sign_dr2 = '{0}') and case_no = '{1}'", currentDoctorName, searchCaseNo);
            }
            
            DBConn.fetchDataIntoDataSetSelectOnly(sql, bxcy_specimenDataSet, "BXCY_SPECIMEN");

            dt = new DataTable();
            dt.Columns.Add(" ", typeof(Boolean));
            dt.Columns.Add("Case No.");
            dt.Columns.Add("Report No.");
            dt.Columns.Add("Report Date");
            dt.Columns.Add("Name");
            dt.Columns.Add("HKID No.");
            dt.Columns.Add("id");

            foreach (DataRow mDr in bxcy_specimenDataSet.Tables["BXCY_SPECIMEN"].Rows)
            {
                dt.Rows.Add(new object[] { false, mDr["case_no"], mDr["institute"], mDr["rpt_date"], mDr["cname"], mDr["pat_hkid"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
        }

        private void Form_DigitalSignature_Load(object sender, EventArgs e)
        {
            loadDataGridViewDate();
            dataGridViewFormat();
        }

        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 25;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 130;
            column1.ReadOnly = true;
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 130;
            column2.ReadOnly = true;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 130;
            column3.ReadOnly = true;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 240;
            column4.ReadOnly = true;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 185;
            column5.ReadOnly = true;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 1;
            column6.ReadOnly = true;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);


            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;


            // center text

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Sign_Selected_Cases_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you Sure to \n" +
            "\n" +
            "Digitally sign the\n" +
            "\n" +
            "Selected case?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        private void button_F6_View_Record_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string case_no = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                if (case_no == null || case_no.Trim() == "" || case_no.Trim().Length == 0)
                {
                    Form_BXCYFile open = new Form_BXCYFile(id);
                    open.Show();
                    return;
                }

                case_no = case_no.Trim();

                if (case_no.Substring(case_no.Length - 1, 1).ToLower() == "g")
                {
                    Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname(id);
                    open.Show();
                }
                else
                {
                    if (case_no.Substring(0, 1).ToLower() == "d")
                    {
                        Form_BXeHRCCSPFile open = new Form_BXeHRCCSPFile(id);
                        open.Show();
                    }
                    else
                    {
                        Form_BXCYFile open = new Form_BXCYFile(id);
                        open.Show();
                    }
                }
            }
        }

        private void button_Select_all_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                foreach (DataRow mDr in dt.Rows)
                {
                    mDr[0] = true;
                }
            }
        }

        private void button_Unselect_all_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                foreach (DataRow mDr in dt.Rows)
                {
                    mDr[0] = false;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && textBox_Case_No.Focused)
            {
                loadDataGridViewDate(textBox_Case_No.Text.Trim());
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
