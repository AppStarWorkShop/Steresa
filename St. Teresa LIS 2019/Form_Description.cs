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
        private int currentStatus;
        private string caseNo;
        private string bxcy_id;
        private DataSet bxcy_diagDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataTable dt;
        private DataRow currentEditRow;
        private Bxcy_diagStr copyBxcy_diagStr;

        private DataSet bxcy_specimenDataSet = new DataSet();
        private DataTable bxcy_specimentDt;
        private SqlDataAdapter bxcy_specimentDataAdapter;

        public delegate void BxcyDiagExit(int status);
        public BxcyDiagExit OnBxcyDiagExit;

        public class Bxcy_diag
        {
            public int id { get; set; }
            public string case_no { get; set; }
            public string barcode { get; set; }
            public string seq { get; set; }
            public string group { get; set; }
            public string ver { get; set; }
            public string site { get; set; }
            public string site2 { get; set; }
            public string operation { get; set; }
            public string operation2 { get; set; }
            public string diag_desc1 { get; set; }
            public string diag_desc2 { get; set; }
            public string macro_name { get; set; }
            public string macro_pic1 { get; set; }
            public string macro_cap1 { get; set; }
            public string macro_pic2 { get; set; }
            public string macro_cap2 { get; set; }
            public string macro_pic3 { get; set; }
            public string macro_cap3 { get; set; }
            public string macro_pic4 { get; set; }
            public string macro_cap4 { get; set; }
            public string micro_name { get; set; }
            public string micro_pic1 { get; set; }
            public string micro_cap1 { get; set; }
            public string micro_pic2 { get; set; }
            public string micro_cap2 { get; set; }
            public string micro_pic3 { get; set; }
            public string micro_cap3 { get; set; }
            public string micro_pic4 { get; set; }
            public string micro_cap4 { get; set; }
            public string micro_desc { get; set; }
            public string macro_desc { get; set; }
            public string diagnosis { get; set; }
            public string hpv_date { get; set; }
            public string hpv_type { get; set; }
            public string hpv_result { get; set; }
            public string hpvohr { get; set; }
            public string hpv16 { get; set; }
            public string hpv18 { get; set; }
            public string hpv_remark { get; set; }
            public string hpv_gen_by { get; set; }
            public string hpv_gen_at { get; set; }
        }

        public class Bxcy_diagStr
        {
            public int id { get; set; }
            public string case_no { get; set; }
            public string barcode { get; set; }
            public string seq { get; set; }
            public string group { get; set; }
            public string ver { get; set; }
            public string site { get; set; }
            public string site2 { get; set; }
            public string operation { get; set; }
            public string operation2 { get; set; }
            public string diag_desc1 { get; set; }
            public string diag_desc2 { get; set; }
            public string macro_name { get; set; }
            public string macro_pic1 { get; set; }
            public string macro_cap1 { get; set; }
            public string macro_pic2 { get; set; }
            public string macro_cap2 { get; set; }
            public string macro_pic3 { get; set; }
            public string macro_cap3 { get; set; }
            public string macro_pic4 { get; set; }
            public string macro_cap4 { get; set; }
            public string micro_name { get; set; }
            public string micro_pic1 { get; set; }
            public string micro_cap1 { get; set; }
            public string micro_pic2 { get; set; }
            public string micro_cap2 { get; set; }
            public string micro_pic3 { get; set; }
            public string micro_cap3 { get; set; }
            public string micro_pic4 { get; set; }
            public string micro_cap4 { get; set; }
            public string micro_desc { get; set; }
            public string macro_desc { get; set; }
            public string diagnosis { get; set; }
            public string hpv_date { get; set; }
            public string hpv_type { get; set; }
            public string hpv_result { get; set; }
            public string hpvohr { get; set; }
            public string hpv16 { get; set; }
            public string hpv18 { get; set; }
            public string hpv_remark { get; set; }
            public string hpv_gen_by { get; set; }
            public string hpv_gen_at { get; set; }
        }

        public Form_Description()
        {
            InitializeComponent();
        }

        public Form_Description(string caseNo, string bxcy_id, int status)
        {
            this.caseNo = caseNo;
            this.bxcy_id = bxcy_id;
            currentStatus = status;
            InitializeComponent();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            if (OnBxcyDiagExit != null)
            {
                OnBxcyDiagExit(currentStatus);
            }
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
            Form_DiagnosisDictionaryMaintenance open = new Form_DiagnosisDictionaryMaintenance();
            open.Show();
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
            setButtonStatus(currentStatus);
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
            textBox_Parts2.DataBindings.Clear();

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

            textBox_Remarks.DataBindings.Clear();
            textBox_Site_frort.DataBindings.Clear();
            comboBox_Site.DataBindings.Clear();
            textBox_Chinese_Description_1_DIA.DataBindings.Clear();
            comboBox_Operation.DataBindings.Clear();
            textBox_Chinese_Description_2_DIA.DataBindings.Clear();
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

            string micro_nameSql = "SELECT [micro_name] FROM [micro_name]";
            DataSet micro_nameDataSet = new DataSet();
            SqlDataAdapter micro_nameDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(micro_nameSql, micro_nameDataSet, "micro_name");

            DataTable micro_nameDt = new DataTable();
            micro_nameDt.Columns.Add("micro_name");

            foreach (DataRow mDr in micro_nameDataSet.Tables["micro_name"].Rows)
            {
                micro_nameDt.Rows.Add(new object[] { mDr["micro_name"] });
            }

            comboBox_Description2.DataSource = micro_nameDt;

            string MACROSCOPIC_ReportSql = "SELECT [MACROSCOPIC],[Description] FROM [MACROSCOPIC_Report]";
            DataSet MACROSCOPIC_ReportDataSet = new DataSet();
            SqlDataAdapter MACROSCOPIC_ReportDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(MACROSCOPIC_ReportSql, MACROSCOPIC_ReportDataSet, "MACROSCOPIC_Report");

            DataTable MACROSCOPIC_ReportDt = new DataTable();
            MACROSCOPIC_ReportDt.Columns.Add("MACROSCOPIC");
            MACROSCOPIC_ReportDt.Columns.Add("Description");

            foreach (DataRow mDr in MACROSCOPIC_ReportDataSet.Tables["MACROSCOPIC_Report"].Rows)
            {
                MACROSCOPIC_ReportDt.Rows.Add(new object[] { mDr["MACROSCOPIC"], mDr["Description"] });
            }

            comboBox_MAC_Add.DataSource = MACROSCOPIC_ReportDt;

            string MICROSCOPIC_ReportSql = "SELECT [MICROSCOPIC],[Description] FROM [MICROSCOPIC_Report]";
            DataSet MICROSCOPIC_ReportDataSet = new DataSet();
            SqlDataAdapter MICROSCOPIC_ReportDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(MICROSCOPIC_ReportSql, MICROSCOPIC_ReportDataSet, "MICROSCOPIC_Report");

            DataTable MICROSCOPIC_ReportDt = new DataTable();
            MICROSCOPIC_ReportDt.Columns.Add("MICROSCOPIC");
            MICROSCOPIC_ReportDt.Columns.Add("Description");

            foreach (DataRow mDr in MICROSCOPIC_ReportDataSet.Tables["MICROSCOPIC_Report"].Rows)
            {
                MICROSCOPIC_ReportDt.Rows.Add(new object[] { mDr["MICROSCOPIC"], mDr["Description"] });
            }

            comboBox_MIC_Add2.DataSource = MICROSCOPIC_ReportDt;


            string macro_templateSql = "SELECT distinct DOCTOR FROM [macro_template]";
            DataSet macro_templateDataSet = new DataSet();
            SqlDataAdapter macro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(macro_templateSql, macro_templateDataSet, "macro_template");

            DataTable macro_templateDt = new DataTable();
            macro_templateDt.Columns.Add("DOCTOR");

            foreach (DataRow mDr in macro_templateDataSet.Tables["macro_template"].Rows)
            {
                macro_templateDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Doctor.DataSource = macro_templateDt;

            string micro_templateSql = "SELECT distinct DOCTOR FROM [micro_template]";
            DataSet micro_templateDataSet = new DataSet();
            SqlDataAdapter micro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(micro_templateSql, micro_templateDataSet, "micro_template");

            DataTable micro_templateDt = new DataTable();
            micro_templateDt.Columns.Add("DOCTOR");

            foreach (DataRow mDr in micro_templateDataSet.Tables["micro_template"].Rows)
            {
                micro_templateDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Doctor2.DataSource = micro_templateDt;

            string diag_descSql = "SELECT C_DESC FROM [diag_desc]";
            DataSet diag_descDataSet = new DataSet();
            SqlDataAdapter diag_descDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diag_descSql, diag_descDataSet, "diag_desc");

            DataTable diag_descDt1 = new DataTable();
            diag_descDt1.Columns.Add("C_DESC");
            DataTable diag_descDt2 = diag_descDt1.Clone();

            foreach (DataRow mDr in diag_descDataSet.Tables["diag_desc"].Rows)
            {
                diag_descDt1.Rows.Add(new object[] { mDr["C_DESC"] });
                diag_descDt2.Rows.Add(new object[] { mDr["C_DESC"] });
            }

            comboBox_Diagnosis_1.DataSource = diag_descDt1;
            comboBox_Diagnosis_2.DataSource = diag_descDt2;

            string picture_capSql = "SELECT [CAPTION] FROM [picture_cap]";
            DataSet picture_capDataSet = new DataSet();
            SqlDataAdapter picture_capDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(picture_capSql, picture_capDataSet, "picture_cap");

            DataTable picture_capDt1 = new DataTable();
            picture_capDt1.Columns.Add("CAPTION");
            DataTable picture_capDt2 = picture_capDt1.Clone();
            DataTable picture_capDt3 = picture_capDt1.Clone();
            DataTable picture_capDt4 = picture_capDt1.Clone();
            DataTable picture_capDt5 = picture_capDt1.Clone();
            DataTable picture_capDt6 = picture_capDt1.Clone();
            DataTable picture_capDt7 = picture_capDt1.Clone();
            DataTable picture_capDt8 = picture_capDt1.Clone();

            foreach (DataRow mDr in picture_capDataSet.Tables["picture_cap"].Rows)
            {
                picture_capDt1.Rows.Add(new object[] { mDr["CAPTION"] });
                picture_capDt2.Rows.Add(new object[] { mDr["CAPTION"] });
                picture_capDt3.Rows.Add(new object[] { mDr["CAPTION"] });
                picture_capDt4.Rows.Add(new object[] { mDr["CAPTION"] });
                picture_capDt5.Rows.Add(new object[] { mDr["CAPTION"] });
                picture_capDt6.Rows.Add(new object[] { mDr["CAPTION"] });
                picture_capDt7.Rows.Add(new object[] { mDr["CAPTION"] });
                picture_capDt8.Rows.Add(new object[] { mDr["CAPTION"] });
            }

            comboBox_Caption_1.DataSource = picture_capDt1;
            comboBox_Caption_2.DataSource = picture_capDt2;
            comboBox_Caption_3.DataSource = picture_capDt3;
            comboBox_Caption_4.DataSource = picture_capDt4;
            comboBox_Caption_5.DataSource = picture_capDt5;
            comboBox_Caption_6.DataSource = picture_capDt6;
            comboBox_Caption_7.DataSource = picture_capDt7;
            comboBox_Caption_8.DataSource = picture_capDt8;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            comboBox_Description.DataBindings.Add("Text", dt, "macro_name", false);
            comboBox_Description2.DataBindings.Add("Text", dt, "macro_name", false);
            textBox_Remarks_CY.DataBindings.Add("Text", dt, "micro_desc", false);
            textBox_Parts.DataBindings.Add("Text", dt, "group", false);
            textBox_Parts2.DataBindings.Add("Text", dt, "group", false);
            textBox_Parts3.DataBindings.Add("Text", dt, "group", false);

            textBox_Picture_File_1.DataBindings.Add("Text", dt, "macro_pic1", false);
            textBox_Picture_File_2.DataBindings.Add("Text", dt, "macro_pic2", false);
            textBox_Picture_File_3.DataBindings.Add("Text", dt, "macro_pic3", false);
            textBox_Picture_File_4.DataBindings.Add("Text", dt, "macro_pic4", false);
            textBox_Picture_File_5.DataBindings.Add("Text", dt, "micro_pic1", false);
            textBox_Picture_File_6.DataBindings.Add("Text", dt, "micro_pic2", false);
            textBox_Picture_File_7.DataBindings.Add("Text", dt, "micro_pic3", false);
            textBox_Picture_File_8.DataBindings.Add("Text", dt, "micro_pic4", false);

            comboBox_Caption_1.DataBindings.Add("Text", dt, "macro_cap1", false);
            comboBox_Caption_2.DataBindings.Add("Text", dt, "macro_cap2", false);
            comboBox_Caption_3.DataBindings.Add("Text", dt, "macro_cap3", false);
            comboBox_Caption_4.DataBindings.Add("Text", dt, "macro_cap4", false);
            comboBox_Caption_5.DataBindings.Add("Text", dt, "micro_cap1", false);
            comboBox_Caption_6.DataBindings.Add("Text", dt, "micro_cap2", false);
            comboBox_Caption_7.DataBindings.Add("Text", dt, "micro_cap3", false);
            comboBox_Caption_8.DataBindings.Add("Text", dt, "micro_cap4", false);

            textBox_Remarks.DataBindings.Add("Text", dt, "macro_desc", false);

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

            DataTable snopcodeTDt1 = new DataTable();
            snopcodeTDt1.Columns.Add("desc");
            DataTable snopcodeTDt2 = snopcodeTDt1.Clone();
            DataTable snopcodeTDt3 = snopcodeTDt1.Clone();

            foreach (DataRow mDr in snopcodeTDataSet.Tables["snopcode"].Rows)
            {
                snopcodeTDt1.Rows.Add(new object[] { mDr["desc"] });
                snopcodeTDt2.Rows.Add(new object[] { mDr["desc"] });
                snopcodeTDt3.Rows.Add(new object[] { mDr["desc"] });
            }

            comboBox_Snop_T1.DataSource = snopcodeTDt1;
            comboBox_Snop_T2.DataSource = snopcodeTDt2;
            comboBox_Snop_T3.DataSource = snopcodeTDt3;

            string snopcodeMSql = "SELECT [desc] FROM [snopcode] WHERE SNOPTYPE = 'M' ";
            DataSet snopcodeMDataSet = new DataSet();
            SqlDataAdapter snopcodeMDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeMSql, snopcodeMDataSet, "snopcode");

            DataTable snopcodeMDt1 = new DataTable();
            snopcodeMDt1.Columns.Add("desc");
            DataTable snopcodeMDt2 = snopcodeMDt1.Clone();
            DataTable snopcodeMDt3 = snopcodeMDt1.Clone();

            foreach (DataRow mDr in snopcodeMDataSet.Tables["snopcode"].Rows)
            {
                snopcodeMDt1.Rows.Add(new object[] { mDr["desc"] });
                snopcodeMDt2.Rows.Add(new object[] { mDr["desc"] });
                snopcodeMDt3.Rows.Add(new object[] { mDr["desc"] });
            }

            comboBox_Snop_M1.DataSource = snopcodeMDt1;
            comboBox_Snop_M2.DataSource = snopcodeMDt2;
            comboBox_Snop_M3.DataSource = snopcodeMDt3;

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

            label_Total_Parts_No.DataBindings.Clear();
            string groupSql = string.Format("SELECT ISNULL(max([group]),0) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
            DataSet groupDataSet = new DataSet();
            SqlDataAdapter groupDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet, "bxcy_diag");

            DataTable groupDt = groupDataSet.Tables["bxcy_diag"];
            label_Total_Parts_No.DataBindings.Add("Text", groupDt, "maxGroup", false);

            /*if (groupDt != null && groupDt.Rows.Count > 0)
            {
                label_Total_Parts_No.Text = groupDt.Rows[0]["maxGroup"].ToString();
            }*/
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM BXCY_DIAG ORDER BY ID";
            DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "BXCY_DIAG");

            DataTable dt = bxcy_diagDataSet.Tables["BXCY_DIAG"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            label_Total_Parts_No.DataBindings.Clear();
            string groupSql = string.Format("SELECT max([group]) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
            DataSet groupDataSet = new DataSet();
            SqlDataAdapter groupDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet, "bxcy_diag");

            DataTable groupDt = bxcy_diagDataSet.Tables["bxcy_diag"];
            label_Total_Parts_No.DataBindings.Add("Text", groupDt, "maxGroup", false);
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
            string sql = string.Format("SELECT TOP 1 * FROM [bxcy_diag] WHERE case_no = '{0}' ORDER BY ID DESC", caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
        }

        private void button_F6_Edit_Click(object sender, EventArgs e)
        {
            copyBxcy_diagStr = new Bxcy_diagStr();

            copyBxcy_diagStr.macro_name = comboBox_Description.Text;
            copyBxcy_diagStr.macro_name = comboBox_Description2.Text;
            copyBxcy_diagStr.micro_desc = textBox_Remarks_CY.Text;
            copyBxcy_diagStr.group = textBox_Parts2.Text;

            copyBxcy_diagStr.macro_pic1 = textBox_Picture_File_1.Text;
            copyBxcy_diagStr.macro_pic2 = textBox_Picture_File_2.Text;
            copyBxcy_diagStr.macro_pic3 = textBox_Picture_File_3.Text;
            copyBxcy_diagStr.macro_pic4 = textBox_Picture_File_4.Text;
            copyBxcy_diagStr.macro_pic1 = textBox_Picture_File_5.Text;
            copyBxcy_diagStr.macro_pic2 = textBox_Picture_File_6.Text;
            copyBxcy_diagStr.macro_pic3 = textBox_Picture_File_7.Text;
            copyBxcy_diagStr.macro_pic4 = textBox_Picture_File_8.Text;

            copyBxcy_diagStr.macro_cap1 = comboBox_Caption_1.Text;
            copyBxcy_diagStr.macro_cap2 = comboBox_Caption_2.Text;
            copyBxcy_diagStr.macro_cap3 = comboBox_Caption_3.Text;
            copyBxcy_diagStr.macro_cap4 = comboBox_Caption_4.Text;
            copyBxcy_diagStr.macro_cap1 = comboBox_Caption_5.Text;
            copyBxcy_diagStr.macro_cap2 = comboBox_Caption_6.Text;
            copyBxcy_diagStr.macro_cap3 = comboBox_Caption_7.Text;
            copyBxcy_diagStr.macro_cap4 = comboBox_Caption_8.Text;

            copyBxcy_diagStr.macro_desc = textBox_Remarks.Text;

            copyBxcy_diagStr.seq = textBox_Site_frort.Text;
            copyBxcy_diagStr.site = comboBox_Site.Text;
            copyBxcy_diagStr.site2 = textBox_Chinese_Description_1_DIA.Text;
            copyBxcy_diagStr.operation = comboBox_Operation.Text;
            copyBxcy_diagStr.operation2 = textBox_Chinese_Description_2_DIA.Text;
            copyBxcy_diagStr.diagnosis = textBox_Diagnosis.Text;
            copyBxcy_diagStr.diag_desc1 = comboBox_Diagnosis_1.Text;
            copyBxcy_diagStr.diag_desc2 = comboBox_Diagnosis_2.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_diagDataSet.Tables["bxcy_diag"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["case_no"] = caseNo;

            bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Clear();
            bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Add(currentEditRow);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM BXCY_DIAG WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    reloadDBData(0);
                    MessageBox.Show("Bxcy Diag deleted");
                }
                else
                {
                    MessageBox.Show("Bxcy Diag deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
            }
        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;

            if (status == PageStatus.STATUS_VIEW)
            {
                comboBox_Description.Enabled = true;

                button_Caption_Detail.Enabled = true;
                textBox_Picture_File_1.Enabled = true;
                textBox_Picture_File_2.Enabled = true;
                textBox_Picture_File_3.Enabled = false;
                textBox_Picture_File_4.Enabled = true;
                textBox_Picture_File_5.Enabled = true;
                textBox_Picture_File_6.Enabled = true;
                textBox_Picture_File_7.Enabled = false;
                textBox_Picture_File_8.Enabled = true;

                comboBox_Caption_1.Enabled = false;
                comboBox_Caption_2.Enabled = false;
                comboBox_Caption_3.Enabled = false;
                comboBox_Caption_4.Enabled = false;
                comboBox_Caption_5.Enabled = false;
                comboBox_Caption_6.Enabled = false;
                comboBox_Caption_7.Enabled = false;
                comboBox_Caption_8.Enabled = false;

                button_Picture_File_1_Path.Enabled = false;
                button_Picture_File_2_Path.Enabled = false;
                button_Picture_File_3_Path.Enabled = false;
                button_Picture_File_4_Path.Enabled = false;
                button_Picture_File_5_Path.Enabled = false;
                button_Picture_File_6_Path.Enabled = false;
                button_Picture_File_7_Path.Enabled = false;
                button_Picture_File_8_Path.Enabled = false;

                button_Picture_File_1.Enabled = true;
                button_Picture_File_2.Enabled = true;
                button_Picture_File_3.Enabled = true;
                button_Picture_File_4.Enabled = true;
                button_Picture_File_5.Enabled = true;
                button_Picture_File_6.Enabled = true;
                button_Picture_File_7.Enabled = true;
                button_Picture_File_8.Enabled = true;

                textBox_Parts.Enabled = false;
                textBox_Remarks.Enabled = false;

                comboBox_MAC_Add.Enabled = false;
                comboBox_Doctor.Enabled = false;
                comboBox_Organ.Enabled = false;
                comboBox_Template.Enabled = false;
                button_Add_Template.Enabled = false;
                button_MAC_Add_Edit.Enabled = true;
                button_Detail.Enabled = true;

                comboBox_Description2.Enabled = false;
                textBox_Parts2.Enabled = false;
                textBox_Remarks_CY.Enabled = false;
                comboBox_Doctor2.Enabled = false;
                comboBox_Organ2.Enabled = false;
                comboBox_Template2.Enabled = false;
                button_Add_Template2.Enabled = false;

                button_MIC_Add_Edit2.Enabled = true;
                //button_MAC_Add_Edit2.Enabled = false;
                button_Detail2.Enabled = true;
                //comboBox5_MIC_Add.Enabled = false;

                textBox_Site_frort.Enabled = false;
                comboBox_Site.Enabled = false;
                button_Detail_1_DIA.Enabled = true;
                textBox_Chinese_Description_1_DIA.Enabled = false;
                comboBox_Operation.Enabled = false;
                button_Detail_2_DIA.Enabled = true;
                textBox_Chinese_Description_2_DIA.Enabled = false;
                textBox_Diagnosis.Enabled = false;
                comboBox_Diagnosis_1.Enabled = false;
                button_Detail_3_DIA.Enabled = true;
                comboBox_Diagnosis_2.Enabled = false;
                button_Detail_4_DIA.Enabled = true;
                textBox_Parts3.Enabled = false;

                comboBox_Snop_T1.Enabled = false;
                comboBox_Snop_T2.Enabled = false;
                comboBox_Snop_T3.Enabled = false;

                comboBox_Snop_M1.Enabled = false;
                comboBox_Snop_M2.Enabled = false;
                comboBox_Snop_M3.Enabled = false;

                button_Top.Enabled = true;
                button_Back.Enabled = true;
                button_Next.Enabled = true;
                button_End.Enabled = true;

                button_Save.Enabled = false;
                button_New.Enabled = true;
                button_F6_Edit.Enabled = true;
                button_Delete.Enabled = true;
                button_Label.Enabled = true;
                button_Path.Enabled = true;
                button_F8_Back_To_Main.Enabled = true;
                button_Undo.Enabled = false;

                comboBox_MIC_Add2.Enabled = false;

                disedit_modle();
            }
            else
            {
                if (status == PageStatus.STATUS_NEW)
                {
                    comboBox_Description.Enabled = true;

                    button_Caption_Detail.Enabled = true;
                    textBox_Picture_File_1.Enabled = true;
                    textBox_Picture_File_2.Enabled = true;
                    textBox_Picture_File_3.Enabled = true;
                    textBox_Picture_File_4.Enabled = true;
                    textBox_Picture_File_5.Enabled = true;
                    textBox_Picture_File_6.Enabled = true;
                    textBox_Picture_File_7.Enabled = true;
                    textBox_Picture_File_8.Enabled = true;

                    comboBox_Caption_1.Enabled = true;
                    comboBox_Caption_2.Enabled = true;
                    comboBox_Caption_3.Enabled = true;
                    comboBox_Caption_4.Enabled = true;
                    comboBox_Caption_5.Enabled = true;
                    comboBox_Caption_6.Enabled = true;
                    comboBox_Caption_7.Enabled = true;
                    comboBox_Caption_8.Enabled = true;

                    button_Picture_File_1_Path.Enabled = true;
                    button_Picture_File_2_Path.Enabled = true;
                    button_Picture_File_3_Path.Enabled = true;
                    button_Picture_File_4_Path.Enabled = true;
                    button_Picture_File_5_Path.Enabled = true;
                    button_Picture_File_6_Path.Enabled = true;
                    button_Picture_File_7_Path.Enabled = true;
                    button_Picture_File_8_Path.Enabled = true;

                    button_Picture_File_1.Enabled = true;
                    button_Picture_File_2.Enabled = true;
                    button_Picture_File_3.Enabled = true;
                    button_Picture_File_4.Enabled = true;
                    button_Picture_File_5.Enabled = true;
                    button_Picture_File_6.Enabled = true;
                    button_Picture_File_7.Enabled = true;
                    button_Picture_File_8.Enabled = true;

                    textBox_Parts.Enabled = true;
                    textBox_Remarks.Enabled = true;

                    comboBox_MAC_Add.Enabled = true;
                    comboBox_Doctor.Enabled = true;
                    comboBox_Organ.Enabled = true;
                    comboBox_Template.Enabled = true;
                    button_Add_Template.Enabled = true;
                    button_MAC_Add_Edit.Enabled = true;
                    button_Detail.Enabled = true;

                    comboBox_Description2.Enabled = true;
                    textBox_Parts2.Enabled = true;
                    textBox_Remarks_CY.Enabled = true;
                    comboBox_Doctor2.Enabled = true;
                    comboBox_Organ2.Enabled = true;
                    comboBox_Template2.Enabled = true;
                    button_Add_Template2.Enabled = true;

                    button_MIC_Add_Edit2.Enabled = true;
                    //button_MAC_Add_Edit2.Enabled = true;
                    button_Detail2.Enabled = true;
                    //comboBox5_MIC_Add.Enabled = true;

                    textBox_Site_frort.Enabled = true;
                    comboBox_Site.Enabled = true;
                    button_Detail_1_DIA.Enabled = true;
                    textBox_Chinese_Description_1_DIA.Enabled = true;
                    comboBox_Operation.Enabled = true;
                    button_Detail_2_DIA.Enabled = true;
                    textBox_Chinese_Description_2_DIA.Enabled = true;
                    textBox_Diagnosis.Enabled = true;
                    comboBox_Diagnosis_1.Enabled = true;
                    button_Detail_3_DIA.Enabled = true;
                    comboBox_Diagnosis_2.Enabled = true;
                    button_Detail_4_DIA.Enabled = true;
                    textBox_Parts3.Enabled = true;

                    comboBox_Snop_T1.Enabled = true;
                    comboBox_Snop_T2.Enabled = true;
                    comboBox_Snop_T3.Enabled = true;

                    comboBox_Snop_M1.Enabled = true;
                    comboBox_Snop_M2.Enabled = true;
                    comboBox_Snop_M3.Enabled = true;

                    button_Top.Enabled = false;
                    button_Back.Enabled = false;
                    button_Next.Enabled = false;
                    button_End.Enabled = false;

                    button_Save.Enabled = true;
                    button_New.Enabled = false;
                    button_F6_Edit.Enabled = false;
                    button_Delete.Enabled = false;
                    button_Label.Enabled = false;
                    button_Path.Enabled = true;
                    button_F8_Back_To_Main.Enabled = false;
                    button_Undo.Enabled = true;

                    comboBox_MIC_Add2.Enabled = true;
                    edit_modle();
                }
                else
                {
                    if (status == PageStatus.STATUS_EDIT)
                    {
                        comboBox_Description.Enabled = true;

                        button_Caption_Detail.Enabled = true;
                        textBox_Picture_File_1.Enabled = true;
                        textBox_Picture_File_2.Enabled = true;
                        textBox_Picture_File_3.Enabled = true;
                        textBox_Picture_File_4.Enabled = true;
                        textBox_Picture_File_5.Enabled = true;
                        textBox_Picture_File_6.Enabled = true;
                        textBox_Picture_File_7.Enabled = true;
                        textBox_Picture_File_8.Enabled = true;

                        comboBox_Caption_1.Enabled = true;
                        comboBox_Caption_2.Enabled = true;
                        comboBox_Caption_3.Enabled = true;
                        comboBox_Caption_4.Enabled = true;
                        comboBox_Caption_5.Enabled = true;
                        comboBox_Caption_6.Enabled = true;
                        comboBox_Caption_7.Enabled = true;
                        comboBox_Caption_8.Enabled = true;

                        button_Picture_File_1_Path.Enabled = true;
                        button_Picture_File_2_Path.Enabled = true;
                        button_Picture_File_3_Path.Enabled = true;
                        button_Picture_File_4_Path.Enabled = true;
                        button_Picture_File_5_Path.Enabled = true;
                        button_Picture_File_6_Path.Enabled = true;
                        button_Picture_File_7_Path.Enabled = true;
                        button_Picture_File_8_Path.Enabled = true;

                        button_Picture_File_1.Enabled = true;
                        button_Picture_File_2.Enabled = true;
                        button_Picture_File_3.Enabled = true;
                        button_Picture_File_4.Enabled = true;
                        button_Picture_File_5.Enabled = true;
                        button_Picture_File_6.Enabled = true;
                        button_Picture_File_7.Enabled = true;
                        button_Picture_File_8.Enabled = true;

                        textBox_Parts.Enabled = true;
                        textBox_Remarks.Enabled = true;

                        comboBox_MAC_Add.Enabled = true;
                        comboBox_Doctor.Enabled = true;
                        comboBox_Organ.Enabled = true;
                        comboBox_Template.Enabled = true;
                        button_Add_Template.Enabled = true;
                        button_MAC_Add_Edit.Enabled = true;
                        button_Detail.Enabled = true;

                        comboBox_Description2.Enabled = true;
                        textBox_Parts2.Enabled = true;
                        textBox_Remarks_CY.Enabled = true;
                        comboBox_Doctor2.Enabled = true;
                        comboBox_Organ2.Enabled = true;
                        comboBox_Template2.Enabled = true;
                        button_Add_Template2.Enabled = true;

                        button_MIC_Add_Edit2.Enabled = true;
                        //button_MAC_Add_Edit2.Enabled = true;
                        button_Detail2.Enabled = true;
                        //comboBox5_MIC_Add.Enabled = true;

                        textBox_Site_frort.Enabled = true;
                        comboBox_Site.Enabled = true;
                        button_Detail_1_DIA.Enabled = true;
                        textBox_Chinese_Description_1_DIA.Enabled = true;
                        comboBox_Operation.Enabled = true;
                        button_Detail_2_DIA.Enabled = true;
                        textBox_Chinese_Description_2_DIA.Enabled = true;
                        textBox_Diagnosis.Enabled = true;
                        comboBox_Diagnosis_1.Enabled = true;
                        button_Detail_3_DIA.Enabled = true;
                        comboBox_Diagnosis_2.Enabled = true;
                        button_Detail_4_DIA.Enabled = true;
                        textBox_Parts3.Enabled = true;

                        comboBox_Snop_T1.Enabled = true;
                        comboBox_Snop_T2.Enabled = true;
                        comboBox_Snop_T3.Enabled = true;

                        comboBox_Snop_M1.Enabled = true;
                        comboBox_Snop_M2.Enabled = true;
                        comboBox_Snop_M3.Enabled = true;

                        button_Top.Enabled = false;
                        button_Back.Enabled = false;
                        button_Next.Enabled = false;
                        button_End.Enabled = false;

                        button_Save.Enabled = true;
                        button_New.Enabled = false;
                        button_F6_Edit.Enabled = false;
                        button_Delete.Enabled = false;
                        button_Label.Enabled = false;
                        button_Path.Enabled = true;
                        button_F8_Back_To_Main.Enabled = true;
                        button_Undo.Enabled = true;

                        comboBox_MIC_Add2.Enabled = true;
                        edit_modle();
                    }
                }
            }
        }

        private void edit_modle()
        {
            button_Top.Image = Image.FromFile("Resources/topGra.png");
            button_Top.ForeColor = Color.Gray;
            button_Back.Image = Image.FromFile("Resources/backGra.png");
            button_Back.ForeColor = Color.Gray;
            button_Next.Image = Image.FromFile("Resources/nextGra.png");
            button_Next.ForeColor = Color.Gray;
            button_End.Image = Image.FromFile("Resources/endGra.png");
            button_End.ForeColor = Color.Gray;
            button_Save.Image = Image.FromFile("Resources/save.png");
            button_Save.ForeColor = Color.Black;
            button_New.Image = Image.FromFile("Resources/newGra.png");
            button_New.ForeColor = Color.Gray;
            button_F6_Edit.Image = Image.FromFile("Resources/editGra.png");
            button_F6_Edit.ForeColor = Color.Gray;
            button_Delete.Image = Image.FromFile("Resources/deleteGra.png");
            button_Delete.ForeColor = Color.Gray;
            button_Undo.Image = Image.FromFile("Resources/undo.png");
            button_Undo.ForeColor = Color.Black;
            button_F8_Back_To_Main.Image = Image.FromFile("Resources/exit.png");
            button_F8_Back_To_Main.ForeColor = Color.Black;
        }

        private void disedit_modle()
        {
            button_Top.Image = Image.FromFile("Resources/top.png");
            button_Top.ForeColor = Color.Black;
            button_Back.Image = Image.FromFile("Resources/back.png");
            button_Back.ForeColor = Color.Black;
            button_Next.Image = Image.FromFile("Resources/next.png");
            button_Next.ForeColor = Color.Black;
            button_End.Image = Image.FromFile("Resources/end.png");
            button_End.ForeColor = Color.Black;
            button_Save.Image = Image.FromFile("Resources/saveGra.png");
            button_Save.ForeColor = Color.Gray;
            button_New.Image = Image.FromFile("Resources/new.png");
            button_New.ForeColor = Color.Black;
            button_F6_Edit.Image = Image.FromFile("Resources/edit.png");
            button_F6_Edit.ForeColor = Color.Black;
            button_Delete.Image = Image.FromFile("Resources/delete.png");
            button_Delete.ForeColor = Color.Black;
            button_Undo.Image = Image.FromFile("Resources/undoGra.png");
            button_Undo.ForeColor = Color.Gray;
            button_F8_Back_To_Main.Image = Image.FromFile("Resources/exit.png");
            button_F8_Back_To_Main.ForeColor = Color.Black;
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    bxcy_diagDataSet.Tables["BXCY_DIAG"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyBxcy_diagStr != null)
                    {
                        comboBox_Description.Text = copyBxcy_diagStr.macro_name;
                        comboBox_Description2.Text = copyBxcy_diagStr.macro_name;
                        textBox_Remarks_CY.Text = copyBxcy_diagStr.micro_desc;
                        textBox_Parts2.Text = copyBxcy_diagStr.group;

                        textBox_Picture_File_1.Text = copyBxcy_diagStr.macro_pic1;
                        textBox_Picture_File_2.Text = copyBxcy_diagStr.macro_pic2;
                        textBox_Picture_File_3.Text = copyBxcy_diagStr.macro_pic3;
                        textBox_Picture_File_4.Text = copyBxcy_diagStr.macro_pic4;
                        textBox_Picture_File_5.Text = copyBxcy_diagStr.macro_pic1;
                        textBox_Picture_File_6.Text = copyBxcy_diagStr.macro_pic2;
                        textBox_Picture_File_7.Text = copyBxcy_diagStr.macro_pic3;
                        textBox_Picture_File_8.Text = copyBxcy_diagStr.macro_pic4;

                        comboBox_Caption_1.Text = copyBxcy_diagStr.macro_cap1;
                        comboBox_Caption_2.Text = copyBxcy_diagStr.macro_cap2;
                        comboBox_Caption_3.Text = copyBxcy_diagStr.macro_cap3;
                        comboBox_Caption_4.Text = copyBxcy_diagStr.macro_cap4;
                        comboBox_Caption_5.Text = copyBxcy_diagStr.macro_cap1;
                        comboBox_Caption_6.Text = copyBxcy_diagStr.macro_cap2;
                        comboBox_Caption_7.Text = copyBxcy_diagStr.macro_cap3;
                        comboBox_Caption_8.Text = copyBxcy_diagStr.macro_cap4;

                        textBox_Remarks.Text = copyBxcy_diagStr.macro_desc;

                        textBox_Site_frort.Text = copyBxcy_diagStr.seq;
                        comboBox_Site.Text = copyBxcy_diagStr.site;
                        textBox_Chinese_Description_1_DIA.Text = copyBxcy_diagStr.site2;
                        comboBox_Operation.Text = copyBxcy_diagStr.operation;
                        textBox_Chinese_Description_2_DIA.Text = copyBxcy_diagStr.operation2;
                        textBox_Diagnosis.Text = copyBxcy_diagStr.diagnosis;
                        comboBox_Diagnosis_1.Text = copyBxcy_diagStr.diag_desc1;
                        comboBox_Diagnosis_2.Text = copyBxcy_diagStr.diag_desc2;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    /*currentEditRow["UPDATE_BY"] = "Admin";
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");*/
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "bxcy_diag"))
                    {
                        //reloadDBData(currencyManager.Count - 1);
                        reloadAndBindingDBData();
                        button_End.PerformClick();
                        MessageBox.Show("New Bxcy Diag saved");
                    }
                    else
                    {
                        MessageBox.Show("Bxcy Diag saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        /*drow["UPDATE_BY"] = "Admin";
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");*/
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "bxcy_diag"))
                        {
                            MessageBox.Show("Bxcy Diag updated");
                        }
                        else
                        {
                            MessageBox.Show("Bxcy Diag updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void comboBox_MAC_Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Remarks.Text = textBox_Remarks.Text + comboBox_MAC_Add.SelectedValue.ToString();
        }

        private void comboBox_MIC_Add2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Remarks_CY.Text = textBox_Remarks_CY.Text + comboBox_MIC_Add2.SelectedValue.ToString();
        }

        private void comboBox_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string macro_templateSql = string.Format("SELECT distinct ORGAN FROM [macro_template] WHERE DOCTOR = '{0}'", comboBox_Doctor.SelectedValue.ToString());
            DataSet macro_templateDataSet = new DataSet();
            SqlDataAdapter macro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(macro_templateSql, macro_templateDataSet, "macro_template");

            DataTable macro_templateDt = new DataTable();
            macro_templateDt.Columns.Add("ORGAN");

            foreach (DataRow mDr in macro_templateDataSet.Tables["macro_template"].Rows)
            {
                macro_templateDt.Rows.Add(new object[] { mDr["ORGAN"] });
            }

            comboBox_Organ.DataSource = macro_templateDt;
        }

        private void comboBox_Organ_SelectedIndexChanged(object sender, EventArgs e)
        {
            string macro_templateSql = string.Format("SELECT distinct TEMPLATE FROM [macro_template] WHERE DOCTOR = '{0}' AND ORGAN = '{1}'", comboBox_Doctor.SelectedValue.ToString(), comboBox_Organ.SelectedValue.ToString());
            DataSet macro_templateDataSet = new DataSet();
            SqlDataAdapter macro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(macro_templateSql, macro_templateDataSet, "macro_template");

            DataTable macro_templateDt = new DataTable();
            macro_templateDt.Columns.Add("TEMPLATE");

            foreach (DataRow mDr in macro_templateDataSet.Tables["macro_template"].Rows)
            {
                macro_templateDt.Rows.Add(new object[] { mDr["TEMPLATE"] });
            }

            comboBox_Template.DataSource = macro_templateDt;
        }

        private void button_Add_Template_Click(object sender, EventArgs e)
        {
            string macro_templateSql = string.Format("SELECT TOP 1 MACRO_DESC FROM [macro_template] WHERE DOCTOR = '{0}' AND ORGAN = '{1}' AND TEMPLATE = '{2}'", comboBox_Doctor.SelectedValue.ToString(), comboBox_Organ.SelectedValue.ToString(), comboBox_Template.SelectedValue.ToString());
            DataSet macro_templateDataSet = new DataSet();
            SqlDataAdapter macro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(macro_templateSql, macro_templateDataSet, "macro_template");

            if(macro_templateDataSet.Tables["macro_template"].Rows.Count > 0)
            {
                textBox_Remarks.Text = macro_templateDataSet.Tables["macro_template"].Rows[0]["MACRO_DESC"].ToString();
            }
        }

        private void comboBox_Doctor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string micro_templateSql = string.Format("SELECT distinct ORGAN FROM [micro_template] WHERE DOCTOR = '{0}'", comboBox_Doctor2.SelectedValue.ToString());
            DataSet micro_templateDataSet = new DataSet();
            SqlDataAdapter micro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(micro_templateSql, micro_templateDataSet, "micro_template");

            DataTable micro_templateDt = new DataTable();
            micro_templateDt.Columns.Add("ORGAN");

            foreach (DataRow mDr in micro_templateDataSet.Tables["micro_template"].Rows)
            {
                micro_templateDt.Rows.Add(new object[] { mDr["ORGAN"] });
            }

            comboBox_Organ2.DataSource = micro_templateDt;
        }

        private void comboBox_Organ2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string micro_templateSql = string.Format("SELECT distinct TEMPLATE FROM [micro_template] WHERE DOCTOR = '{0}' AND ORGAN = '{1}'", comboBox_Doctor2.SelectedValue.ToString(), comboBox_Organ2.SelectedValue.ToString());
            DataSet micro_templateDataSet = new DataSet();
            SqlDataAdapter micro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(micro_templateSql, micro_templateDataSet, "micro_template");

            DataTable micro_templateDt = new DataTable();
            micro_templateDt.Columns.Add("TEMPLATE");

            foreach (DataRow mDr in micro_templateDataSet.Tables["micro_template"].Rows)
            {
                micro_templateDt.Rows.Add(new object[] { mDr["TEMPLATE"] });
            }

            comboBox_Template2.DataSource = micro_templateDt;
        }

        private void button_Add_Template2_Click(object sender, EventArgs e)
        {
            string micro_templateSql = string.Format("SELECT TOP 1 micro_DESC FROM [micro_template] WHERE DOCTOR = '{0}' AND ORGAN = '{1}' AND TEMPLATE = '{2}'", comboBox_Doctor2.SelectedValue.ToString(), comboBox_Organ2.SelectedValue.ToString(), comboBox_Template2.SelectedValue.ToString());
            DataSet micro_templateDataSet = new DataSet();
            SqlDataAdapter micro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(micro_templateSql, micro_templateDataSet, "micro_template");

            if (micro_templateDataSet.Tables["micro_template"].Rows.Count > 0)
            {
                textBox_Remarks_CY.Text = micro_templateDataSet.Tables["micro_template"].Rows[0]["micro_DESC"].ToString();
            }
        }

        private void button_Detail_4_DIA_Click(object sender, EventArgs e)
        {
            Form_DiagnosisDictionaryMaintenance open = new Form_DiagnosisDictionaryMaintenance();
            open.Show();
        }

        private void button_Detail_1_DIA_Click(object sender, EventArgs e)
        {
            Form_SiteFileMaintenance open = new Form_SiteFileMaintenance();
            open.Show();
        }

        private void button_Detail_2_DIA_Click(object sender, EventArgs e)
        {
            Form_OperationFileMaintenance open = new Form_OperationFileMaintenance();
            open.Show();
        }

        private string getPicFileName()
        {
            string fileName = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();     //显示选择文件对话框
            openFileDialog1.InitialDirectory = CurrentUser.picturePath;
            openFileDialog1.Filter = "TIFF (*.tiff)|*.tiff|Jpg (*.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName  = System.IO.Path.GetFileName(openFileDialog1.FileName);
            }

            return fileName;
        }

        private void button_Picture_File_1_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_1.Text = getPicFileName();
        }

        private void button_Picture_File_2_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_2.Text = getPicFileName();
        }

        private void button_Picture_File_3_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_3.Text = getPicFileName();
        }

        private void button_Picture_File_4_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_4.Text = getPicFileName();
        }

        private void button_Picture_File_5_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_5.Text = getPicFileName();
        }

        private void button_Picture_File_6_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_6.Text = getPicFileName();
        }

        private void button_Picture_File_7_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_7.Text = getPicFileName();
        }

        private void button_Picture_File_8_Path_Click(object sender, EventArgs e)
        {
            textBox_Picture_File_8.Text = getPicFileName();
        }

        private void button_Picture_File_1_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_1.Text.Trim());
            open.Show();
        }

        private void button_Picture_File_2_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_2.Text.Trim());
            open.Show();
        }

        private void button_Picture_File_3_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_3.Text.Trim());
            open.Show();

        }

        private void button_Picture_File_4_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_4.Text.Trim());
            open.Show();
        }

        private void button_Picture_File_5_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_5.Text.Trim());
            open.Show();
        }

        private void button_Picture_File_6_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_6.Text.Trim());
            open.Show();
        }

        private void button_Picture_File_7_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_7.Text.Trim());
            open.Show();
        }

        private void button_Picture_File_8_Click(object sender, EventArgs e)
        {
            ShowPicture open = new ShowPicture(textBox_Picture_File_8.Text.Trim());
            open.Show();
        }
    }
}
