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
    public partial class Form_SelectFrozenSection : Form
    {
        private DataTable dt;
        private DataSet frozen_sectionDataSet = new DataSet();

        public delegate void frozen_sectionSelectedMore(string idStr);
        public frozen_sectionSelectedMore Onfrozen_sectionSelectedMore;

        public delegate void frozen_sectionSelectedSingle(string str);
        public frozen_sectionSelectedSingle Onfrozen_sectionSelectedSingle;

        public Form_SelectFrozenSection()
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
                    string sql = string.Format("SELECT [FZ_DETAIL],[UPDATE_BY], id FROM [frozen_section] WHERE FZ_DETAIL LIKE '%{0}%'", textBox_Serch_Doctor.Text.Trim());
                    DBConn.fetchDataIntoDataSetSelectOnly(sql, frozen_sectionDataSet, "frozen_section");

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Frozen Section Detail");
                    dt.Columns.Add("Update By");
                    dt.Columns.Add("Id");

                    foreach (DataRow mDr in frozen_sectionDataSet.Tables["frozen_section"].Rows)
                    {
                        dt.Rows.Add(new object[] { mDr["FZ_DETAIL"], mDr["UPDATE_BY"], mDr["id"] });
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
            string frozenSectionStr = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                frozenSectionStr = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                idStr = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }

            if (idStr == "")
            {
                MessageBox.Show("No record selected");
                return;
            }
            if (Onfrozen_sectionSelectedMore != null)
            {
                Onfrozen_sectionSelectedMore(idStr);
            }
            if (Onfrozen_sectionSelectedSingle != null)
            {
                Onfrozen_sectionSelectedSingle(frozenSectionStr);
            }
            this.Close();
        }

        private void loadDataGridViewDate()
        {
            string sql = string.Format("SELECT [FZ_DETAIL],[UPDATE_BY], id FROM [frozen_section] WHERE FZ_DETAIL LIKE '%{0}%'", textBox_Serch_Doctor.Text.Trim());
            DBConn.fetchDataIntoDataSetSelectOnly(sql, frozen_sectionDataSet, "frozen_section");

            DataTable dt = new DataTable();
            dt.Columns.Add("Frozen Section Detail");
            dt.Columns.Add("Update By");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in frozen_sectionDataSet.Tables["frozen_section"].Rows)
            {
                dt.Rows.Add(new object[] { mDr["FZ_DETAIL"], mDr["UPDATE_BY"], mDr["id"] });
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

        private void Form_Selectfrozen_section_Load(object sender, EventArgs e)
        {
            loadDataGridViewDate();
            dataGridViewFormat();
        }
    }
}
