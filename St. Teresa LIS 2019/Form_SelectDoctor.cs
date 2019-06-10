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
    public partial class Form_SelectDoctor : Form
    {
        private DataTable dt;
        private DataSet doctorDataSet = new DataSet();

        public delegate void DoctorSelectedMore(string idStr);
        public DoctorSelectedMore OnDoctorSelectedMore;

        public Form_SelectDoctor()
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
                    string sql = string.Format("SELECT doctor,cname,initial,address1,tel1,fax,opd,contact,id FROM [DOCTOR] WHERE DOCTOR LIKE '%{0}%' OR CNAME LIKE '%{0}%'", textBox_Serch_Doctor.Text.Trim());
                    DBConn.fetchDataIntoDataSetSelectOnly(sql, doctorDataSet, "doctor");

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Select", typeof(bool));
                    dt.Columns.Add("Doctor's Name");
                    dt.Columns.Add("Chinese Name");
                    dt.Columns.Add("Initial");
                    dt.Columns.Add("Address1");
                    dt.Columns.Add("Tel1");
                    dt.Columns.Add("Fax");
                    dt.Columns.Add("Opd");
                    dt.Columns.Add("Contact");
                    dt.Columns.Add("Id");

                    foreach (DataRow mDr in doctorDataSet.Tables["doctor"].Rows)
                    {
                        dt.Rows.Add(new object[] { "false", mDr["doctor"], mDr["cname"], mDr["initial"], mDr["address1"], mDr["tel1"], mDr["fax"], mDr["opd"], mDr["contact"], mDr["id"] });
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (bool.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == true)
                {
                    if (dataGridView1.Rows[i].Cells[9].Value.ToString() != "")
                    {
                        if (idStr == "")
                        {
                            idStr += dataGridView1.Rows[i].Cells[9].Value.ToString();
                        }
                        else
                        {
                            idStr += "," + dataGridView1.Rows[i].Cells[9].Value.ToString();
                        }

                    }
                }
            }
            OnDoctorSelectedMore(idStr);
            this.Close();
        }

        private void Form_SelectDoctor_Load(object sender, EventArgs e)
        {
            loadDataGridViewDate();
            dataGridViewFormat();
        }

        private void loadDataGridViewDate()
        {
            string sql = "SELECT doctor,cname,initial,address1,tel1,fax,opd,contact,id FROM [DOCTOR]";
            DBConn.fetchDataIntoDataSetSelectOnly(sql, doctorDataSet, "doctor");

            DataTable dt = new DataTable();
            dt.Columns.Add("Select", typeof(bool));
            dt.Columns.Add("Doctor's Name");
            dt.Columns.Add("Chinese Name");
            dt.Columns.Add("Initial");
            dt.Columns.Add("Address1");
            dt.Columns.Add("Tel1");
            dt.Columns.Add("Fax");
            dt.Columns.Add("Opd");
            dt.Columns.Add("Contact");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in doctorDataSet.Tables["doctor"].Rows)
            {
                dt.Rows.Add(new object[] { "false", mDr["doctor"], mDr["cname"], mDr["initial"], mDr["address1"], mDr["tel1"], mDr["fax"], mDr["opd"], mDr["contact"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 30;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 190;
            column1.ReadOnly = true;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 145;
            column2.ReadOnly = true;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 130;
            column3.ReadOnly = true;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 30;
            column4.ReadOnly = true;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 30;
            column5.ReadOnly = true;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 60;
            column6.ReadOnly = true;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 50;
            column7.ReadOnly = true;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 60;
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
    }
}
