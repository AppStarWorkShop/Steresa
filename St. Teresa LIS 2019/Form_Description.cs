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
    public partial class Form_Description : Form
    {
        private string caseNo;
        private DataSet ebv_diagDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataTable dt;

        public Form_Description()
        {
            InitializeComponent();
        }

        public Form_Description(string caseNo)
        {
            this.caseNo = caseNo;
            InitializeComponent();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Detail_5_Click(object sender, EventArgs e)
        {
            Form_MacroscopicTemplateMaintenance open = new Form_MacroscopicTemplateMaintenance();
            open.Show();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)

        {

            KeyEventArgs e = new KeyEventArgs(keyData);

            if (e.Control && e.KeyCode == Keys.F1)

            {

                return true; // handled

            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void Form_Description_KeyDown(object sender, KeyEventArgs e)
        {/*
            if (e.KeyCode == Keys.F1)
            {
                tabControl1.SelectedIndex = 0;
                label9.Text = "F1";
            }
            if (e.KeyCode == Keys.F2)
            {
                tabControl1.SelectedIndex = 1;
                label9.Text = "F2";
            }
            if (e.KeyCode == Keys.F3)
            {
                tabControl1.SelectedIndex = 2;
                label9.Text = "F3";
            }
            */
            switch (e.KeyCode)
            {
                case Keys.F1:
                    tabControl1.SelectedIndex = 0;
                    break;
                case Keys.F2:
                    tabControl1.SelectedIndex = 1;
                    break;
                case Keys.F3:
                    tabControl1.SelectedIndex = 2;
                    break;
                //// etc
                default:
                    // do nothing
                    break;
            }
            

        }

        private void button_Caption_Detail_Click(object sender, EventArgs e)
        {
            Form_PictureCaptionMaintenance open = new Form_PictureCaptionMaintenance();
            open.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form_MicroscopicCYTemplateMaintenance open = new Form_MicroscopicCYTemplateMaintenance();
            open.Show();
        }

        private void tabPage_MACROSCOPIC_Click(object sender, EventArgs e)
        {

        }

        private void button_Label_Click(object sender, EventArgs e)
        {
            Form_PathologyReport open = new Form_PathologyReport();
            open.Show();
        }

        private void button_Detail_3_DIA_Click(object sender, EventArgs e)
        {

        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            Form_ChangePicturePath open = new Form_ChangePicturePath();
            open.Show();
        }

        private void button_MAC_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_MACROSCOPICReportMaintenance open = new Form_MACROSCOPICReportMaintenance();
            open.Show();
        }

        private void button_MIC_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_MICROSCOPICReportMaintenance open = new Form_MICROSCOPICReportMaintenance();
            open.Show();
        }

        private void Form_Description_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [BXCY_DIAG] WHERE case_no = '{0}' ORDER BY ID",caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, ebv_diagDataSet, "ebv_diag");

            dt = ebv_diagDataSet.Tables["ebv_diag"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_Picture_File_1.DataBindings.Clear();

            textBox_Picture_File_1.DataBindings.Add("Text", dt, "id", false);
            
        }

        private void button_Top_Click(object sender, EventArgs e)
        {

        }

        private void button_Back_Click(object sender, EventArgs e)
        {

        }

        private void button_Next_Click(object sender, EventArgs e)
        {

        }

        private void button_End_Click(object sender, EventArgs e)
        {

        }
    }
}
