using System;
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
    public partial class Form_PrevoiusCasesCondition : Form
    {
        private DataTable dt;
        private DataSet bxcy_specimenDataSet = new DataSet();
        private string hkid;

        public delegate void BxcySpecimentSelectedSingle(string str);
        public BxcySpecimentSelectedSingle OnBxcySpecimentSelectedSingle;

        public Form_PrevoiusCasesCondition()
        {
            InitializeComponent();
        }

        public Form_PrevoiusCasesCondition(string hkid)
        {
            this.hkid = hkid;
            InitializeComponent();
        }

        private void Form_PrevoiusCasesCondition_Load(object sender, EventArgs e)
        {
            loadDataGridViewDate();
            dataGridViewFormat();
        }

        private void loadDataGridViewDate(int currentPageNum = 1)
        {
            string sql = string.Format("select bs.[case_no], [date], ISNULL(bs.[snopcode_t],'')+' '+ISNULL(bs.[snopcode_t2],'') +' ' + ISNULL(bs.[snopcode_t3],'') as Tcode, ISNULL(bs.[snopcode_m],'')+' '+ISNULL(bs.[snopcode_m2],'') +' ' + ISNULL(bs.[snopcode_m3],'') as Mcode, bd.[site] as Site, bd.[diagnosis] as Diagnosis,bs.pat_hkid,bs.id From [BXCY_SPECIMEN] bs, [BXCY_DIAG] bd Where bs.[case_no] = bd.[case_no] and bs.pat_hkid = '{0}' Order by bs.[case_no] desc", hkid);
            SqlCommand checkCmd = new SqlCommand(sql, DBConn.getConnection());
            checkCmd.CommandType = CommandType.Text;

            checkCmd.CommandTimeout = 600;
            SqlDataAdapter sdap = new SqlDataAdapter();
            sdap.SelectCommand = checkCmd;
            DataTable dtDb = new DataTable();
            sdap.Fill(dtDb);

            dt = new DataTable();
            dt.Columns.Add("Case No.");
            dt.Columns.Add("Date");
            dt.Columns.Add("T-code");
            dt.Columns.Add("M-code");
            dt.Columns.Add("Site");
            dt.Columns.Add("Diagnosis");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in dtDb.Rows)
            {
                dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["date"], mDr["Tcode"], mDr["Mcode"], mDr["site"], mDr["Diagnosis"], mDr["id"] });
            }
            dataGridView1.DataSource = dt;
            dataGridViewFormat();

            label_Total_No.Text = dtDb.Rows.Count.ToString();
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F7_View_Details_Click(object sender, EventArgs e)
        {
            string idStr = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                idStr = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            }

            if (idStr == "")
            {
                MessageBox.Show("No record selected");
                return;
            }

            if (OnBxcySpecimentSelectedSingle != null)
            {
                OnBxcySpecimentSelectedSingle(idStr);
            }
            this.Close();
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 130;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 150;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 240;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 60;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 90;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 120;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 1;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void button_F6_View_Diagnosis_Click(object sender, EventArgs e)
        {
            string idStr = "";
            string caseNoStr = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                idStr = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                caseNoStr = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            if (idStr == "")
            {
                MessageBox.Show("No record selected");
                return;
            }

            Form_Description open = new Form_Description(caseNoStr, idStr);
            open.Show();
        }
    }
}
