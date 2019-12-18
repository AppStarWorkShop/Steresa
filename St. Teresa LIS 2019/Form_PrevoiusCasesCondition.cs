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
        private string currentId;

        public delegate void BxcySpecimentSelectedSingle(string str);
        public BxcySpecimentSelectedSingle OnBxcySpecimentSelectedSingle;
        public Form_BXCYFile bxcyDetailFileForm;
        public int currentStatus;

        public Form_PrevoiusCasesCondition()
        {
            InitializeComponent();
        }

        public void setCurrentStatus(int pageStatus)
        {
            this.currentStatus = pageStatus;
        }

        public void setBxcyDetailFileForm(Form_BXCYFile form)
        {
            this.bxcyDetailFileForm = form;
        }

        public Form_BXCYFile getBxcyDetailFileForm()
        {
            return this.bxcyDetailFileForm;
        }

        public Form_PrevoiusCasesCondition(string hkid, string currentId)
        {
            this.hkid = hkid;
            this.currentId = currentId;
            InitializeComponent();
        }

        public Form_PrevoiusCasesCondition(string hkid)
        {
            this.hkid = hkid;
            this.currentId = null;
            InitializeComponent();
        }

        private void Form_PrevoiusCasesCondition_Load(object sender, EventArgs e)
        {
            loadDataGridViewDate();
            dataGridViewFormat();
            dataGridView1.Refresh();
        }

        private void loadDataGridViewDate(int currentPageNum = 1)
        {
            string sql = string.Format("select bs.[case_no], format([date], 'dd/MM/yyyy') as [date], ISNULL(bs.[snopcode_t],'') as Tcode1, ISNULL(bs.[snopcode_t2],'') as Tcode2, ISNULL(bs.[snopcode_t3],'') as Tcode3, ISNULL(bs.[snopcode_m],'') as Mcode1, ISNULL(bs.[snopcode_m2],'') as Mcode2, ISNULL(bs.[snopcode_m3],'') as Mcode3,bs.pat_hkid,bs.id From [BXCY_SPECIMEN] bs Where bs.pat_hkid = '{0}' Order by bs.[case_no] desc", hkid);
            if (currentId != null)
            {
                sql = string.Format("select bs.[case_no], format([date], 'dd/MM/yyyy') as [date], ISNULL(bs.[snopcode_t],'') as Tcode1, ISNULL(bs.[snopcode_t2],'') as Tcode2, ISNULL(bs.[snopcode_t3],'') as Tcode3, ISNULL(bs.[snopcode_m],'') as Mcode1, ISNULL(bs.[snopcode_m2],'') as Mcode2, ISNULL(bs.[snopcode_m3],'') as Mcode3,bs.pat_hkid,bs.id From [BXCY_SPECIMEN] bs Where bs.pat_hkid = '{0}' and bs.id <> {1} Order by bs.[case_no] desc", hkid, currentId);
            }

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

            string Tcode = "";
            string Mcode = "";
            foreach (DataRow mDr in dtDb.Rows)
            {
                Tcode = "";
                Mcode = "";

                Tcode = mDr["Tcode1"].ToString().Trim();
                if(Tcode != "" && mDr["Tcode2"].ToString().Trim() != "")
                {
                    Tcode = Tcode + System.Environment.NewLine + mDr["Tcode2"].ToString().Trim();
                }
                else
                {
                    Tcode = Tcode + mDr["Tcode2"].ToString().Trim();
                }

                if (Tcode != "" && mDr["Tcode3"].ToString().Trim() != "")
                {
                    Tcode = Tcode + System.Environment.NewLine + mDr["Tcode3"].ToString().Trim();
                }
                else
                {
                    Tcode = Tcode + mDr["Tcode3"].ToString().Trim();
                }

                Mcode = mDr["Mcode1"].ToString().Trim();
                if (Mcode != "" && mDr["Mcode2"].ToString().Trim() != "")
                {
                    Mcode = Mcode + System.Environment.NewLine + mDr["Mcode2"].ToString().Trim();
                }
                else
                {
                    Mcode = Mcode + mDr["Mcode2"].ToString().Trim();
                }

                if (Mcode != "" && mDr["Mcode3"].ToString().Trim() != "")
                {
                    Mcode = Mcode + System.Environment.NewLine + mDr["Mcode3"].ToString().Trim();
                }
                else
                {
                    Mcode = Mcode + mDr["Mcode3"].ToString().Trim();
                }

                string sqlExt = string.Format("SELECT bd.[site] as Site, bd.[diagnosis] as Diagnosis From [BXCY_DIAG] bd WHERE case_no = '{0}'", mDr["CASE_NO"].ToString().Trim());
                SqlCommand checkCmdExt = new SqlCommand(sqlExt, DBConn.getConnection());
                checkCmd.CommandType = CommandType.Text;

                checkCmdExt.CommandTimeout = 600;
                SqlDataAdapter sdapExt = new SqlDataAdapter();
                sdapExt.SelectCommand = checkCmdExt;
                DataTable dtDbExt = new DataTable();
                sdapExt.Fill(dtDbExt);

                string site = "";
                string diagnosis = "";
                foreach (DataRow mDrExt in dtDbExt.Rows)
                {
                    if (site != "" && mDrExt["site"].ToString().Trim() != "")
                    {
                        site = site + System.Environment.NewLine + mDrExt["site"].ToString().Trim();
                    }
                    else
                    {
                        site = site + mDrExt["site"].ToString().Trim();
                    }

                    if (diagnosis != "" && mDrExt["diagnosis"].ToString().Trim() != "")
                    {
                        diagnosis = diagnosis + System.Environment.NewLine + mDrExt["diagnosis"].ToString().Trim();
                    }
                    else
                    {
                        diagnosis = diagnosis + mDrExt["diagnosis"].ToString().Trim();
                    }
                }

                dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["date"], Tcode, Mcode, site, diagnosis, mDr["id"] });
            }
            dataGridView1.DataSource = dt;
            dataGridViewFormat();

            label_Total_No.Text = "Total : " + dtDb.Rows.Count.ToString();
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F7_View_Details_Click(object sender, EventArgs e)
        {
            string idStr = "";
            string case_no = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                idStr = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                case_no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            if (idStr == "")
            {
                MessageBox.Show("No record selected");
                return;
            }

            if (case_no != null && case_no.Trim() != "" && case_no.Length > 0 && case_no.Trim().Substring(case_no.Length - 1, 1).ToLower() == "g")
            {
                Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname(idStr);
                open.Show();
            }
            else
            {
                if (case_no != null && case_no.Trim() != "" && case_no.Length > 0 && case_no.Trim().Substring(0, 1).ToLower() == "d")
                {
                    Form_BXeHRCCSPFile open = new Form_BXeHRCCSPFile(idStr);
                    open.Show();
                }
                else
                {
                    Form_BXCYFile open = new Form_BXCYFile(idStr);
                    open.Show();
                    open.disableEdit();
                }
            }
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            //column0.Width = 130;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 160;
            /*
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 240;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 60;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 90;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 300;
            
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 1;
            */
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Visible = false;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridView1.EnableHeadersVisualStyles = false;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void button_F6_View_Diagnosis_Click(object sender, EventArgs e)
        {
            string idStr = "";
            string case_no = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                idStr = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                case_no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            if (idStr == "")
            {
                MessageBox.Show("No record selected");
                return;
            }

            if (case_no != null && case_no.Trim() != "" && case_no.Length > 0 && case_no.Trim().Substring(case_no.Length - 1, 1).ToLower() == "g")
            {
                Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname(idStr);
                open.Show();
            }
            else
            {
                if (case_no != null && case_no.Trim() != "" && case_no.Length > 0 && case_no.Trim().Substring(0, 1).ToLower() == "d")
                {
                    Form_BXeHRCCSPFile open = new Form_BXeHRCCSPFile(idStr);
                    open.Show();
                }
                else
                {
                    Form_BXCYFile open = new Form_BXCYFile(idStr);
                    open.Show();
                    if (bxcyDetailFileForm != null)
                    {
                        bxcyDetailFileForm.Close();
                    }
                }
            }

            /*
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
            open.disableEdit();
            */
        }
    }
}
