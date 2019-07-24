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
    public partial class Form_SelectClientInstitute : Form
    {
        public Boolean mergeSlavee;
        private DataTable dt;
        private DataSet clientDataSet = new DataSet();

        public delegate void ClientInstituteSelectedMore(string idStr);
        public ClientInstituteSelectedMore OnClientInstituteSelectedMore;

        public delegate void ClientInstituteSelectedSingle(string str);
        public ClientInstituteSelectedSingle OnClientInstituteSelectedSingle;

        public Form_SelectClientInstitute()
        {
            InitializeComponent();
        }

        private void Form_SelectClientInstitute_Load(object sender, EventArgs e)
        {
            loadDataGridViewDate();
            dataGridViewFormat();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string idStr = "";
            string clientStr = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (bool.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == true)
                {
                    if (dataGridView1.Rows[i].Cells[7].Value.ToString() != "")
                    {
                        clientStr = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        if (idStr == "")
                        {
                            idStr += dataGridView1.Rows[i].Cells[7].Value.ToString();
                        }
                        else
                        {
                            idStr += "," + dataGridView1.Rows[i].Cells[7].Value.ToString();
                        }

                    }
                }
            }

            if (idStr == "")
            {
                MessageBox.Show("No record selected");
                return;
            }

            if (OnClientInstituteSelectedMore != null)
            {
                OnClientInstituteSelectedMore(idStr);
            }
            if (OnClientInstituteSelectedSingle != null)
            {
                OnClientInstituteSelectedSingle(clientStr);
            }
            this.Close();
        }

        private void loadDataGridViewDate()
        {
            string sql = "SELECT client,cname,address1,tel,fax,contact,id FROM [CLIENT]";
            DBConn.fetchDataIntoDataSetSelectOnly(sql, clientDataSet, "client");

            DataTable dt = new DataTable();
            dt.Columns.Add("Select", typeof(bool));
            dt.Columns.Add("Client's Name");
            dt.Columns.Add("Chinese Name");
            dt.Columns.Add("Address");
            dt.Columns.Add("Tel");
            dt.Columns.Add("Fax");
            dt.Columns.Add("Contact");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in clientDataSet.Tables["client"].Rows)
            {
                dt.Rows.Add(new object[] { "false", mDr["client"], mDr["cname"], mDr["address1"], mDr["tel"], mDr["fax"], mDr["contact"], mDr["id"] });
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
            column6.Width = 130;
            column6.ReadOnly = true;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 1;
            column7.ReadOnly = true;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (textBox_Serch_Client.Focused)
                {
                    string sql = string.Format("SELECT client,cname,address1,tel,fax,contact,id FROM [CLIENT] WHERE CLIENT LIKE '%{0}%' OR CNAME LIKE '%{0}%'", textBox_Serch_Client.Text.Trim());
                    DBConn.fetchDataIntoDataSetSelectOnly(sql, clientDataSet, "client");

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Select", typeof(bool));
                    dt.Columns.Add("Client's Name");
                    dt.Columns.Add("Chinese Name");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Tel");
                    dt.Columns.Add("Fax");
                    dt.Columns.Add("Contact");
                    dt.Columns.Add("Id");

                    foreach (DataRow mDr in clientDataSet.Tables["client"].Rows)
                    {
                        dt.Rows.Add(new object[] { "false", mDr["client"], mDr["cname"], mDr["address1"], mDr["tel"], mDr["fax"], mDr["contact"], mDr["id"] });
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
    }
}
