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
    public partial class Form_BXCYRecordSearch : Form
    {
        private DataTable dt;
        private DataSet bxcy_specimenDataSet = new DataSet();

        private string labelSearching = "Locate Case No:";
        private string contentSearching = "CASE_NO";

        public Boolean edit;

        private string whereStr = "";
        private string whereVal = "";

        int pageSize = 30;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        /*DataSet ds = new DataSet();
        DataTable dtInfo = new DataTable();*/

        //private int SearchTypeCount;
        public static string selected { get; private set; }

        public Form_BXCYRecordSearch()
        {
            InitializeComponent();
            //edit = false;
        }

        public void getSelected()
        {
            /*selected = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            MessageBox.Show(selected);*/
        }

        private void Form_BXCYRecordSearch_Load(object sender, EventArgs e)
        {
            whereStr = "";
            whereVal = "";
            pageCurrent = 1;
            loadDataGridViewDate();
            dataGridViewFormat();
        }

        private void loadDataGridViewDate(int currentPageNum = 1)
        {
            string sql = string.Format("getBXCYSpecimentByPage");
            SqlCommand checkCmd = new SqlCommand(sql, DBConn.getConnection());
            checkCmd.CommandType = CommandType.StoredProcedure;

            checkCmd.Parameters.Add(new SqlParameter("@pageCount", SqlDbType.Int));
            checkCmd.Parameters.Add(new SqlParameter("@pageNum", SqlDbType.Int));
            checkCmd.Parameters.Add(new SqlParameter("@whereStr", SqlDbType.NVarChar));
            checkCmd.Parameters.Add(new SqlParameter("@whereVal", SqlDbType.NVarChar));

            checkCmd.Parameters["@pageCount"].Value = pageSize;
            checkCmd.Parameters["@pageNum"].Value = currentPageNum;
            checkCmd.Parameters["@whereStr"].Value = whereStr;
            checkCmd.Parameters["@whereVal"].Value = whereVal;

            checkCmd.Parameters.Add("@RETURN_VALUE",SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            checkCmd.CommandTimeout = 600;
            SqlDataAdapter sdap = new SqlDataAdapter();
            sdap.SelectCommand = checkCmd;
            DataTable dtDb = new DataTable();
            sdap.Fill(dtDb);

            pageCount = (int)checkCmd.Parameters["@RETURN_VALUE"].Value;

            dt = new DataTable();
            dt.Columns.Add("Case No.");
            dt.Columns.Add("Report Date");
            dt.Columns.Add("Patient");
            dt.Columns.Add(" ");
            dt.Columns.Add("Age");
            dt.Columns.Add("Sex");
            dt.Columns.Add("HKID No.");
            dt.Columns.Add("Client");
            dt.Columns.Add("Doctor In Charge");
            dt.Columns.Add("Fz Section");
            dt.Columns.Add("Snopcode M");
            dt.Columns.Add("Snopcode T");
            dt.Columns.Add("Cy report");
            dt.Columns.Add("Sign Dr");
            dt.Columns.Add("ER");
            dt.Columns.Add("EM");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in dtDb.Rows)
            {
                //dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["RPT_DATE"], mDr["PATIENT"], mDr["PAT_AGE"], mDr["PAT_SEX"], mDr["PAT_HKID"], mDr["CLIENT"], mDr["DOCTOR_ID"], mDr["fz_section"], mDr["snopcode_m"], mDr["snopcode_t"], mDr["cy_report"], mDr["sign_dr"].ToString()+"/"+ mDr["sign_dr2"].ToString(), mDr["er"], mDr["em"], mDr["id"] });
                dt.Rows.Add(new object[] { mDr["CASE_NO"], mDr["RPT_DATE"], mDr["PATIENT"], mDr["PAT_AGE"], mDr["PAT_SEX"], mDr["PAT_HKID"], mDr["CLIENT"], mDr["DOCTOR_ID"], mDr["fz_section"], mDr["snopcode_m"], mDr["snopcode_t"], mDr["cy_report"], mDr["sign_dr"], mDr["er"], mDr["em"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
            LoadData();
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
            column6.Width = 150;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 240;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 240;
            DataGridViewColumn column9 = dataGridView1.Columns[9];
            column9.Width = 20;
            DataGridViewColumn column10 = dataGridView1.Columns[10];
            column10.Width = 60;
            DataGridViewColumn column11 = dataGridView1.Columns[11];
            column11.Width = 130;
            DataGridViewColumn column12 = dataGridView1.Columns[12];
            column12.Width = 60;
            DataGridViewColumn column13 = dataGridView1.Columns[13];
            column13.Width = 130;
            DataGridViewColumn column14 = dataGridView1.Columns[14];
            column14.Width = 60;
            DataGridViewColumn column15 = dataGridView1.Columns[15];
            column15.Width = 130;
            DataGridViewColumn column16 = dataGridView1.Columns[16];
            column16.Width = 60;
            /*DataGridViewColumn column17 = dataGridView1.Columns[17];
            column17.Width = 130;
            DataGridViewColumn column18 = dataGridView1.Columns[18];
            column18.Width = 60;
            DataGridViewColumn column19 = dataGridView1.Columns[19];
            column19.Width = 130;
            DataGridViewColumn column20 = dataGridView1.Columns[20];
            column20.Width = 60;
            DataGridViewColumn column21 = dataGridView1.Columns[21];
            column21.Width = 130;
            DataGridViewColumn column22 = dataGridView1.Columns[22];
            column22.Width = 120;
            DataGridViewColumn column23 = dataGridView1.Columns[23];
            column23.Width = 150;
            DataGridViewColumn column24 = dataGridView1.Columns[24];
            column24.Width = 20;
            DataGridViewColumn column25 = dataGridView1.Columns[25];
            column25.Width = 20;*/
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            edit_modle();
            
        }

        private void edit_modle()
        {
            button_F2_New_Record.ForeColor = Color.Black;
            buttonF3_Edit_Record.ForeColor = Color.Black;
            button_F5_New_Patient.ForeColor = Color.Black;
            button_F6_View_Record.ForeColor = Color.Black;
            edit = true;

        }

        private void disedit_modle()
        {
            button_F2_New_Record.ForeColor = Color.Gray;
            buttonF3_Edit_Record.ForeColor = Color.Gray;
            button_F5_New_Patient.ForeColor = Color.Gray;
            button_F6_View_Record.ForeColor = Color.Gray;
            edit = false;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void textBox_Search_Type_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Search_Type_Click(object sender, EventArgs e)
        {

        }

        private void button_F1_Search_Click(object sender, EventArgs e)
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
                    labelSearching = "Case No:";
                    break;
                default:
                    contentSearching = "CASE_NO";
                    labelSearching = "Case No:";
                    break;
            }

            label_Search_Type.Text = labelSearching;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                button_F1_Search.PerformClick();
            }

            if (keyData == Keys.Enter && textBox_Search_Type.Focused)
            {
                whereStr = contentSearching;
                whereVal = textBox_Search_Type.Text.Trim();
                loadDataGridViewDate();
                return true;
            }

            if (keyData == Keys.Enter && txtCurrentPage.Focused)
            {
                int inputPage;
                bool result = int.TryParse(txtCurrentPage.Text, out inputPage);
                if (result) {
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
                button_F7_Columns.PerformClick();
                return true;
            }

            if (keyData == Keys.F8)
            {
                button_F8_Pic_Path.PerformClick();
                return true;
            }

            if (keyData == Keys.F10)
            {
                button_Digital_Signature.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button_F2_New_Record_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Form_BXCYFile open = new Form_BXCYFile();
                open.Show();
                open.newRecord();
            }
        }

        private void button_F2m()
        {
            if (edit)
            {
                Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname();
            open.Show();
            }
        }
        private void buttonF3_Edit_Record_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                Form_BXCYFile open = new Form_BXCYFile(id);
                open.Show();
                open.processEdit();
            }
        }
        
        private void button_F3m()
        {
            
        }
        private void button_F4_Daily_Report_Click(object sender, EventArgs e)
        {
            Form_DailyLogReportForBiopsyCytolgyMokculurCase open = new Form_DailyLogReportForBiopsyCytolgyMokculurCase();
            open.Show();
        }

        private void button_F5_New_Patient_Click(object sender, EventArgs e)
        {
            Form_PatientFileMaintenancecs open = new Form_PatientFileMaintenancecs();
            open.Show();
            open.processNew();
        }
        private void button_F5m()
        {
            
        }

        private void button_F6_View_Record_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                Form_BXCYFile open = new Form_BXCYFile(id);
                open.Show();
            }
        }

        private void button_F6m()
        {
            if (edit)
            {
                getSelected();
                Form_BXCYFile open = new Form_BXCYFile();
                open.Show();
            }
        }
        private void button_F7_Columas_Click(object sender, EventArgs e)
        {
            //button_F7m();
        }
        

        private void button_F8_Pic_Path_Click(object sender, EventArgs e)
        {
            Form_ChangePicturePath open = new Form_ChangePicturePath();
            open.Show();
        }
        private void button_F8m()
        {
            
        }
        private void button_F9_Set_BX_CY_Click(object sender, EventArgs e)
        {

        }
        private void button_F9m()
        {
            
        }

        private void button_Digital_Signature_Click(object sender, EventArgs e)
        {
            Form_LoginDigitalSignature open = new Form_LoginDigitalSignature();
            open.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            button_Escm();
        }
        private void button_Escm()
        {
            this.Close();
        }

        private void Form_BXCYRecordSearch_KeyDown(object sender, KeyEventArgs e)
        {
            /*switch (e.KeyCode)
            {
                case Keys.F1:
                    button_F1m();
                    break;
                case Keys.F2:
                    button_F2m();
                    break;
                case Keys.F3:
                    button_F3m();
                    break;
                case Keys.F4:
                    button_F4m();
                    break;
                case Keys.F5:
                    button_F5m();
                    break;
                case Keys.F6:
                    button_F6m();
                    break;
                case Keys.F7:
                    button_F7m();
                    break;
                case Keys.F8:
                    button_F8m();
                    break;
                case Keys.F9:
                    button_F9m();
                    break;
                case Keys.F10:
                    button_F10m();
                    break;
                case Keys.Escape:
                    button_Escm();
                    break;
                //// etc
                default:
                    // do nothing
                    break;
            }*/
        }

        private void button_BX_Click(object sender, EventArgs e)
        {
            textBox_Search_Type.Text = string.Format("BX{0}/", DateTime.Now.ToString("yyyy").Substring(2));
        }

        private void button_BB_Click(object sender, EventArgs e)
        {
            textBox_Search_Type.Text = string.Format("BB{0}-", DateTime.Now.ToString("yyyy").Substring(2));
        }

        private void button_CY_Click(object sender, EventArgs e)
        {
            textBox_Search_Type.Text = string.Format("CY{0}-", DateTime.Now.ToString("yyyy").Substring(2));
        }

        private void button_CC_Click(object sender, EventArgs e)
        {
            textBox_Search_Type.Text = string.Format("CC{0}-", DateTime.Now.ToString("yyyy").Substring(2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_Search_Type.Text = string.Format("MP{0}-", DateTime.Now.ToString("yyyy").Substring(2));
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
    }
}
