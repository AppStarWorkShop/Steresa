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
        private string bxcy_id;
        private DataSet bxcy_diagDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataTable dt;

        private DataSet bxcy_specimenDataSet = new DataSet();
        private DataTable bxcy_specimentDt;
        private SqlDataAdapter bxcy_specimentDataAdapter;

        public Form_Description()
        {
            InitializeComponent();
        }

        public Form_Description(string caseNo, string bxcy_id)
        {
            this.caseNo = caseNo;
            this.bxcy_id = bxcy_id;
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
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");

            dt = bxcy_diagDataSet.Tables["bxcy_diag"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Clear();
            comboBox_Description.DataBindings.Clear();
            comboBox_Description2.DataBindings.Clear();
            textBox_Remarks_CY.DataBindings.Clear();
            textBox_Parts1.DataBindings.Clear();

            textBox_Picture_File_1.DataBindings.Clear();
            textBox_Picture_File_2.DataBindings.Clear();
            textBox_Picture_File_3.DataBindings.Clear();
            textBox_Picture_File_4.DataBindings.Clear();
            textBox_Picture_File_5.DataBindings.Clear();
            textBox_Picture_File_6.DataBindings.Clear();
            textBox_Picture_File_7.DataBindings.Clear();
            textBox_Picture_File_8.DataBindings.Clear();

            comboBox_Caption_1.DataBindings.Clear();
            comboBox_Caption_2.DataBindings.Clear();
            comboBox_Caption_3.DataBindings.Clear();
            comboBox_Caption_4.DataBindings.Clear();
            comboBox_Caption_5.DataBindings.Clear();
            comboBox_Caption_6.DataBindings.Clear();
            comboBox_Caption_7.DataBindings.Clear();
            comboBox_Caption_8.DataBindings.Clear();

            textBox_Site_frort.DataBindings.Clear();
            comboBox_Site.DataBindings.Clear();
            textBox_Chinese_Description_1_DIA.Clear();
            comboBox_Operation.DataBindings.Clear();
            textBox_Chinese_Description_2_DIA.Clear();
            textBox_Diagnosis.DataBindings.Clear();
            comboBox_Diagnosis_1.DataBindings.Clear();
            comboBox_Diagnosis_2.DataBindings.Clear();

            comboBox_Snop_T1.DataBindings.Clear();
            comboBox_Snop_T2.DataBindings.Clear();
            comboBox_Snop_T3.DataBindings.Clear();
            comboBox_Snop_M1.DataBindings.Clear();
            comboBox_Snop_M2.DataBindings.Clear();
            comboBox_Snop_M3.DataBindings.Clear();

            string siteSql = "SELECT [site] FROM [site]";
            DataSet siteDataSet = new DataSet();
            SqlDataAdapter siteDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(siteSql, siteDataSet, "site");

            DataTable siteDt = new DataTable();
            siteDt.Columns.Add("site");

            foreach (DataRow mDr in siteDataSet.Tables["site"].Rows)
            {
                siteDt.Rows.Add(new object[] { mDr["site"] });
            }

            comboBox_Site.DataSource = siteDt;

            string operationSql = "SELECT [operation] FROM [operation]";
            DataSet operationDataSet = new DataSet();
            SqlDataAdapter operationDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(operationSql, operationDataSet, "operation");

            DataTable operationDt = new DataTable();
            operationDt.Columns.Add("operation");

            foreach (DataRow mDr in operationDataSet.Tables["operation"].Rows)
            {
                operationDt.Rows.Add(new object[] { mDr["operation"] });
            }

            comboBox_Operation.DataSource = operationDt;

            string marco_nameSql = "SELECT [marco_name] FROM [marco_name]";
            DataSet marco_nameDataSet = new DataSet();
            SqlDataAdapter marco_nameDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(marco_nameSql, marco_nameDataSet, "marco_name");

            DataTable marco_nameDt = new DataTable();
            marco_nameDt.Columns.Add("marco_name");

            foreach (DataRow mDr in marco_nameDataSet.Tables["marco_name"].Rows)
            {
                marco_nameDt.Rows.Add(new object[] { mDr["marco_name"] });
            }

            comboBox_Description.DataSource = marco_nameDt;
            comboBox_Description2.DataSource = marco_nameDt;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            comboBox_Description.DataBindings.Add("Text", dt, "macro_name", false);
            comboBox_Description2.DataBindings.Add("Text", dt, "macro_name", false);
            textBox_Remarks_CY.DataBindings.Add("Text", dt, "micro_desc", false);
            textBox_Parts1.DataBindings.Add("Text", dt, "group", false);

            textBox_Picture_File_1.DataBindings.Add("Text", dt, "macro_pic1", false);
            textBox_Picture_File_2.DataBindings.Add("Text", dt, "macro_pic2", false);
            textBox_Picture_File_3.DataBindings.Add("Text", dt, "macro_pic3", false);
            textBox_Picture_File_4.DataBindings.Add("Text", dt, "macro_pic4", false);
            textBox_Picture_File_5.DataBindings.Add("Text", dt, "macro_pic1", false);
            textBox_Picture_File_6.DataBindings.Add("Text", dt, "macro_pic2", false);
            textBox_Picture_File_7.DataBindings.Add("Text", dt, "macro_pic3", false);
            textBox_Picture_File_8.DataBindings.Add("Text", dt, "macro_pic4", false);

            comboBox_Caption_1.DataBindings.Add("Text", dt, "macro_cap1", false);
            comboBox_Caption_2.DataBindings.Add("Text", dt, "macro_cap2", false);
            comboBox_Caption_3.DataBindings.Add("Text", dt, "macro_cap3", false);
            comboBox_Caption_4.DataBindings.Add("Text", dt, "macro_cap4", false);
            comboBox_Caption_5.DataBindings.Add("Text", dt, "macro_cap1", false);
            comboBox_Caption_6.DataBindings.Add("Text", dt, "macro_cap2", false);
            comboBox_Caption_7.DataBindings.Add("Text", dt, "macro_cap3", false);
            comboBox_Caption_8.DataBindings.Add("Text", dt, "macro_cap4", false);

            textBox_Site_frort.DataBindings.Add("Text", dt, "seq", false);
            comboBox_Site.DataBindings.Add("Text", dt, "site", false);
            textBox_Chinese_Description_1_DIA.DataBindings.Add("Text", dt, "Site2", false);
            comboBox_Operation.DataBindings.Add("Text", dt, "Operation", false);
            textBox_Chinese_Description_2_DIA.DataBindings.Add("Text", dt, "Operation2", false);
            textBox_Diagnosis.DataBindings.Add("Text", dt, "Diagnosis", false);
            comboBox_Diagnosis_1.DataBindings.Add("Text", dt, "Diag_desc1", false);
            comboBox_Diagnosis_2.DataBindings.Add("Text", dt, "Diag_desc2", false);

            string snopcodeTSql = "SELECT [desc] FROM [snopcode] WHERE SNOPTYPE = 'T' ";
            DataSet snopcodeTDataSet = new DataSet();
            SqlDataAdapter snopcodeTDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeTSql, snopcodeTDataSet, "snopcode");

            DataTable snopcodeTDt = new DataTable();
            snopcodeTDt.Columns.Add("desc");

            foreach (DataRow mDr in snopcodeTDataSet.Tables["snopcode"].Rows)
            {
                snopcodeTDt.Rows.Add(new object[] { mDr["desc"] });
            }

            comboBox_Snop_T1.DataSource = snopcodeTDt;
            comboBox_Snop_T2.DataSource = snopcodeTDt;
            comboBox_Snop_T3.DataSource = snopcodeTDt;

            string snopcodeMSql = "SELECT [desc] FROM [snopcode] WHERE SNOPTYPE = 'M' ";
            DataSet snopcodeMDataSet = new DataSet();
            SqlDataAdapter snopcodeMDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeMSql, snopcodeMDataSet, "snopcode");

            DataTable snopcodeMDt = new DataTable();
            snopcodeMDt.Columns.Add("desc");

            foreach (DataRow mDr in snopcodeMDataSet.Tables["snopcode"].Rows)
            {
                snopcodeMDt.Rows.Add(new object[] { mDr["desc"] });
            }

            comboBox_Snop_M1.DataSource = snopcodeMDt;
            comboBox_Snop_M2.DataSource = snopcodeMDt;
            comboBox_Snop_M3.DataSource = snopcodeMDt;

            string bxcy_sql = string.Format("SELECT * FROM [bxcy_specimen] WHERE id={0}", bxcy_id);
            bxcy_specimentDataAdapter = DBConn.fetchDataIntoDataSet(bxcy_sql, bxcy_specimenDataSet, "bxcy_specimen");

            bxcy_specimentDt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            bxcy_specimentDt.PrimaryKey = new DataColumn[] { bxcy_specimentDt.Columns["id"] };
            /*bxcy_specimentDt.Columns["id"].AutoIncrement = true;
            bxcy_specimentDt.Columns["id"].AutoIncrementStep = 1;*/

            comboBox_Snop_T1.DataBindings.Add("Text", bxcy_specimentDt, "Snopcode_t", false);
            comboBox_Snop_T2.DataBindings.Add("Text", bxcy_specimentDt, "Snopcode_t2", false);
            comboBox_Snop_T3.DataBindings.Add("Text", bxcy_specimentDt, "Snopcode_t3", false);
            comboBox_Snop_M1.DataBindings.Add("Text", bxcy_specimentDt, "Snopcode_m", false);
            comboBox_Snop_M2.DataBindings.Add("Text", bxcy_specimentDt, "Snopcode_m2", false);
            comboBox_Snop_M3.DataBindings.Add("Text", bxcy_specimentDt, "Snopcode_m3", false);
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            string countSql = string.Format(" [bxcy_diag] WHERE id > {0} and case_no = '{1}'", textBox_ID.Text, caseNo);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [bxcy_diag] WHERE id > {0} and case_no = '{1}' ORDER BY ID", textBox_ID.Text, caseNo);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            string countSql = string.Format(" [bxcy_diag] WHERE id < {0} and case_no = '{1}'", textBox_ID.Text, caseNo);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [bxcy_diag] WHERE id < {0} and case_no = '{1}' ORDER BY ID DESC", textBox_ID.Text, caseNo);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [bxcy_diag] WHERE case_no = '{0}' ORDER BY ID", caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [bxcy_diag] WHERE case_no = '{0} ORDER BY ID DESC", caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
        }
    }
}
