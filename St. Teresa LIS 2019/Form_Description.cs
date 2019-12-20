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

        public delegate void BxcyDiagExit(int status, bool refresh, DataSet existDiagDataSet, SqlDataAdapter existDiagDataAdapter, bool readOnly);
        public BxcyDiagExit OnBxcyDiagExit;

        public delegate int BxcyDiagSaveBoth(Object snopT1, Object snopT2, Object snopT3, Object snopM1, Object snopM2, Object snopM3);
        public BxcyDiagSaveBoth OnBxcyDiagSaveBoth;

        public bool isNeedRefreshMainPage = false;

        private Form mainPage;

        private string patientName;
        private string patientHKID;
        private bool isNewRecord = false;

        private bool isSameGroupNewRecord = false;

        private Object snopT1, snopT2, snopT3, snopM1, snopM2, snopM3;

        public CurrencyManager currencyManager;
        private Boolean readOnly = false;
        private int currentNevigateMode = NevigateMode.MODE_GROUP;

        public static class NevigateMode
        {
            public const int MODE_GROUP = 1;
            public const int MODE_DIAGNOSIS = 2;
        }

        public void setReadOnly(Boolean readOnly)
        {
            this.readOnly = readOnly;
            if (readOnly)
            {
                disableEditbuttons();
            }
        }

        public void disableEditbuttons()
        {
            button_New.Enabled = false;
            button_New2.Enabled = false;
            button_Save.Enabled = false;
            button_F6_Edit.Enabled = false;
            button_Delete.Enabled = false;
            button_Undo.Enabled = false;
            button_Path.Enabled = false;
        }

        public void enableEditbuttons()
        {
            button_New.Enabled = true;
            button_New2.Enabled = true;
            button_Save.Enabled = true;
            button_F6_Edit.Enabled = true;
            button_Delete.Enabled = true;
            button_Undo.Enabled = true;
            button_Path.Enabled = true;
        }

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

        public Form_Description(string caseNo, string bxcy_id, int status, Object snopT1, Object snopT2, Object snopT3, Object snopM1, Object snopM2, Object snopM3, string patientName, string patientHKID, bool isNewRecord, DataSet existDataSet = null)
        {
            this.caseNo = caseNo;
            this.bxcy_id = bxcy_id;
            this.snopT1 = snopT1;
            this.snopT2 = snopT2;
            this.snopT3 = snopT3;
            this.snopM1 = snopM1;
            this.snopM2 = snopM2;
            this.snopM3 = snopM3;
            this.patientName = patientName;
            this.patientHKID = patientHKID;
            this.isNewRecord = isNewRecord;
            currentStatus = status;
            InitializeComponent();

            setButtonStatus(currentStatus);

            if (currentStatus == PageStatus.STATUS_VIEW)
            {
                reloadAndBindingDBData();
            }
            else
            {
                if (existDataSet != null)
                {
                    reloadAndBindingDBDataWithExistDataSet(existDataSet);
                }
                else
                {
                    reloadAndBindingDBData();
                }

                if (currentStatus == PageStatus.STATUS_NEW && existDataSet == null)
                {
                    isSameGroupNewRecord = false;

                    currentEditRow = bxcy_diagDataSet.Tables["bxcy_diag"].NewRow();
                    currentEditRow["id"] = -1;
                    currentEditRow["case_no"] = caseNo;

                    currentEditRow["micro_name"] = "MICROSCOPIC EXAMINATION:";
                    currentEditRow["macro_name"] = "MACROSCOPIC EXAMINATION:";

                    string groupSql = string.Format("SELECT ISNULL(max([group]),0) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
                    DataSet groupDataSet1 = new DataSet();
                    SqlDataAdapter groupDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet1, "bxcy_diag");

                    DataTable groupDt = groupDataSet1.Tables["bxcy_diag"];
                    string strMaxGroup = groupDt.Rows[0]["maxGroup"].ToString();
                    currentEditRow["group"] = (Convert.ToInt32(strMaxGroup) + 1).ToString();

                    currentEditRow["diagnosisId"] = 1;

                    bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Clear();
                    bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Add(currentEditRow);
                }
            }
        }

        public Form_Description(string caseNo, string bxcy_id)
        {
            this.caseNo = caseNo;
            this.bxcy_id = bxcy_id;
            currentStatus = PageStatus.STATUS_VIEW;
            InitializeComponent();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            if (OnBxcyDiagExit != null)
            {
                textBox_ID.BindingContext[dt].Position++;
                int backStatus = currentStatus;
                if (currentStatus == PageStatus.STATUS_NEW)
                {
                    backStatus = PageStatus.STATUS_EDIT;
                }
                OnBxcyDiagExit(backStatus, isNeedRefreshMainPage, bxcy_diagDataSet, dataAdapter, readOnly);
                
            }
            this.Close();
        }

        private void button_Detail_5_Click(object sender, EventArgs e)
        {
            Form_MacroscopicTemplateMaintenance open = new Form_MacroscopicTemplateMaintenance();
            open.OnRecordUpdateDone += onMacroscopicTemplateRecordUpdateDone;
            open.Show();
        }

        private void onMacroscopicTemplateRecordUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadMacroscopicTemplateRecord();
            }
        }

        /*public bool checkDuplicateHKID()
        {
            bool result = false;

            if (isNewPatient)
            {
                DataSet checkBxcy_specimenDataSet = new DataSet();
                SqlDataAdapter checkdataAdapter;
                string checkSql = string.Format("SELECT * FROM [bxcy_specimen] WHERE patient = '{0}' AND pat_hkid = '{1}'", patientName, patientHKID);
                checkdataAdapter = DBConn.fetchDataIntoDataSet(checkSql, checkBxcy_specimenDataSet, "bxcy_specimen");

                if (checkBxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
                {
                    MessageBox.Show("Duplicate Patient's name and HKID, unable to save");
                    result = true;
                }
            }

            return result;
        }*/

        private void reloadMacroscopicTemplateRecord()
        {
            string macro_templateSql = "SELECT distinct DOCTOR FROM [macro_template]";
            DataSet macro_templateDataSet = new DataSet();
            SqlDataAdapter macro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(macro_templateSql, macro_templateDataSet, "macro_template");

            DataTable macro_templateDt = new DataTable();
            macro_templateDt.Columns.Add("DOCTOR");

            macro_templateDt.Rows.Add(new object[] { "" });
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

            micro_templateDt.Rows.Add(new object[] { "" });
            foreach (DataRow mDr in micro_templateDataSet.Tables["micro_template"].Rows)
            {
                micro_templateDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Doctor2.DataSource = micro_templateDt;
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
            open.OnRecordUpdateDone += onPictureCaptionUpdateDone;
            open.Show();
        }

        private void onPictureCaptionUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadPictureCaptionUpdate();
            }
        }

        private void reloadPictureCaptionUpdate()
        {
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
            //Form_PathologyReport open = new Form_PathologyReport(bxcy_id, caseNo, textBox_Parts.Text, 0);
            Form_PathologyReport open = new Form_PathologyReport(bxcy_id, caseNo);
            open.Show();
        }

        private void button_Detail_3_DIA_Click(object sender, EventArgs e)
        {
            Form_DiagnosisDictionaryMaintenance open = new Form_DiagnosisDictionaryMaintenance();
            open.OnRecordUpdateDone += onDiagnosisUpdateDone;
            open.Show();
        }

        private void onDiagnosisUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadDiagnosisUpdate();
            }
        }

        private void reloadDiagnosisUpdate()
        {
            string diag_descSql = "SELECT C_DESC,E_DESC FROM [diag_desc] WHERE E_DESC is not null ORDER BY E_DESC";
            DataSet diag_descDataSet = new DataSet();
            SqlDataAdapter diag_descDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diag_descSql, diag_descDataSet, "diag_desc");

            DataTable diag_descDt1 = new DataTable();
            diag_descDt1.Columns.Add("C_DESC");
            diag_descDt1.Columns.Add("E_DESC");
            DataTable diag_descDt2 = diag_descDt1.Clone();
            AutoCompleteStringCollection autoCompleteCollection1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autoCompleteCollection2 = new AutoCompleteStringCollection();

            diag_descDt1.Rows.Add(new object[] { "", "" });
            diag_descDt2.Rows.Add(new object[] { "", "" });
            foreach (DataRow mDr in diag_descDataSet.Tables["diag_desc"].Rows)
            {
                diag_descDt1.Rows.Add(new object[] { mDr["C_DESC"].ToString().Trim(), mDr["E_DESC"].ToString().Trim() });
                diag_descDt2.Rows.Add(new object[] { mDr["C_DESC"].ToString().Trim(), mDr["E_DESC"].ToString().Trim() });
                autoCompleteCollection1.Add(mDr["E_DESC"].ToString().Trim() + " | " + mDr["C_DESC"].ToString().Trim());
                autoCompleteCollection2.Add(mDr["E_DESC"].ToString().Trim() + " | " + mDr["C_DESC"].ToString().Trim());
            }

            comboBox_Diagnosis_1.DataSource = diag_descDt1;
            comboBox_Diagnosis_1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            comboBox_Diagnosis_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox_Diagnosis_1.AutoCompleteCustomSource = autoCompleteCollection1;

            comboBox_Diagnosis_2.DataSource = diag_descDt2;
            comboBox_Diagnosis_2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            comboBox_Diagnosis_2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox_Diagnosis_2.AutoCompleteCustomSource = autoCompleteCollection2;
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            Form_ChangePicturePath open = new Form_ChangePicturePath();
            open.Show();
        }

        private void button_MAC_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_MACROSCOPICReportMaintenance open = new Form_MACROSCOPICReportMaintenance();
            open.OnRecordUpdateDone += onMACROSCOPICReportUpdateDone;
            open.Show();
        }

        private void onMACROSCOPICReportUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadMACROSCOPIC_Report();
            }
        }

        private void reloadMACROSCOPIC_Report()
        {
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
        }

        private void button_MIC_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_MICROSCOPICReportMaintenance open = new Form_MICROSCOPICReportMaintenance();
            open.OnRecordUpdateDone += onMICROSCOPICReportUpdateDone;
            open.Show();
        }

        private void onMICROSCOPICReportUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadMICROSCOPIC_Report();
            }
        }

        private void reloadMICROSCOPIC_Report()
        {
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
        }

        private void Form_Description_Load(object sender, EventArgs e)
        {
            /*setButtonStatus(currentStatus);
            reloadAndBindingDBData();*/
        }

        private void reloadAndBindingDBDataWithExistDataSet(DataSet existBxcy_diagDataSet)
        {
            currentNevigateMode = NevigateMode.MODE_GROUP;
            bxcy_diagDataSet = existBxcy_diagDataSet;

            dt = bxcy_diagDataSet.Tables["bxcy_diag"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            currencyManager = (CurrencyManager)this.BindingContext[dt];

            textBox_ID.DataBindings.Clear();
            comboBox_Description.DataBindings.Clear();
            comboBox_Description2.DataBindings.Clear();
            textBox_Remarks_CY.DataBindings.Clear();
            textBox_Parts.DataBindings.Clear();
            textBox_Parts2.DataBindings.Clear();
            textBox_Parts3.DataBindings.Clear();

            textBox_DiagnosisNo.DataBindings.Clear();
            textBox_DiagnosisNo2.DataBindings.Clear();
            textBox_DiagnosisNo3.DataBindings.Clear();

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

            textBox_specimenID.DataBindings.Clear();

            string siteSql = "SELECT [site],[desc] FROM [site] WHERE site is not null ORDER BY site";
            DataSet siteDataSet = new DataSet();
            SqlDataAdapter siteDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(siteSql, siteDataSet, "site");

            DataTable siteDt = new DataTable();
            siteDt.Columns.Add("site");
            siteDt.Columns.Add("Desc");

            siteDt.Rows.Add(new object[] { "", "" });

            foreach (DataRow mDr in siteDataSet.Tables["site"].Rows)
            {
                siteDt.Rows.Add(new object[] { mDr["site"].ToString().Trim(), mDr["desc"].ToString().Trim() });
            }

            comboBox_Site.DataSource = siteDt;
            //comboBox_Site.SelectedValue

            string operationSql = "SELECT [operation],[desc] FROM [operation] WHERE operation is not null ORDER BY operation";
            DataSet operationDataSet = new DataSet();
            SqlDataAdapter operationDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(operationSql, operationDataSet, "operation");

            DataTable operationDt = new DataTable();
            operationDt.Columns.Add("operation");
            operationDt.Columns.Add("Desc");

            operationDt.Rows.Add(new object[] { "", "" });
            foreach (DataRow mDr in operationDataSet.Tables["operation"].Rows)
            {
                operationDt.Rows.Add(new object[] { mDr["operation"].ToString().Trim(), mDr["desc"].ToString().Trim() });
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

            macro_templateDt.Rows.Add(new object[] { "" });
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

            micro_templateDt.Rows.Add(new object[] { "" });
            foreach (DataRow mDr in micro_templateDataSet.Tables["micro_template"].Rows)
            {
                micro_templateDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Doctor2.DataSource = micro_templateDt;

            string diag_descSql = "SELECT C_DESC,E_DESC FROM [diag_desc] WHERE E_DESC is not null ORDER BY E_DESC";
            DataSet diag_descDataSet = new DataSet();
            SqlDataAdapter diag_descDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diag_descSql, diag_descDataSet, "diag_desc");

            DataTable diag_descDt1 = new DataTable();
            diag_descDt1.Columns.Add("C_DESC");
            diag_descDt1.Columns.Add("E_DESC");
            DataTable diag_descDt2 = diag_descDt1.Clone();
            AutoCompleteStringCollection autoCol1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autoCol2 = new AutoCompleteStringCollection();

            diag_descDt1.Rows.Add(new object[] { "", "" });
            diag_descDt2.Rows.Add(new object[] { "", "" });
            foreach (DataRow mDr in diag_descDataSet.Tables["diag_desc"].Rows)
            {
                diag_descDt1.Rows.Add(new object[] { mDr["C_DESC"].ToString().Trim(), mDr["E_DESC"].ToString().Trim() });
                diag_descDt2.Rows.Add(new object[] { mDr["C_DESC"].ToString().Trim(), mDr["E_DESC"].ToString().Trim() });
                autoCol1.Add(mDr["E_DESC"].ToString().Trim() + " | " + mDr["C_DESC"].ToString().Trim());
                autoCol2.Add(mDr["E_DESC"].ToString().Trim() + " | " + mDr["C_DESC"].ToString().Trim());
            }

            comboBox_Diagnosis_1.DataSource = diag_descDt1;
            comboBox_Diagnosis_1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            comboBox_Diagnosis_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox_Diagnosis_1.AutoCompleteCustomSource = autoCol1;

            comboBox_Diagnosis_2.DataSource = diag_descDt2;
            comboBox_Diagnosis_2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            comboBox_Diagnosis_2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox_Diagnosis_2.AutoCompleteCustomSource = autoCol2;

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

            picture_capDt1.Rows.Add(new object[] { "" });
            picture_capDt2.Rows.Add(new object[] { "" });
            picture_capDt3.Rows.Add(new object[] { "" });
            picture_capDt4.Rows.Add(new object[] { "" });
            picture_capDt5.Rows.Add(new object[] { "" });
            picture_capDt6.Rows.Add(new object[] { "" });
            picture_capDt7.Rows.Add(new object[] { "" });
            picture_capDt8.Rows.Add(new object[] { "" });

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
            comboBox_Description2.DataBindings.Add("Text", dt, "micro_name", false);
            textBox_Remarks_CY.DataBindings.Add("Text", dt, "micro_desc", false);
            textBox_Parts.DataBindings.Add("Text", dt, "group", false);
            textBox_Parts2.DataBindings.Add("Text", dt, "group", false);
            textBox_Parts3.DataBindings.Add("Text", dt, "group", false);

            textBox_DiagnosisNo.DataBindings.Add("Text", dt, "diagnosisId", false);
            textBox_DiagnosisNo2.DataBindings.Add("Text", dt, "diagnosisId", false);
            textBox_DiagnosisNo3.DataBindings.Add("Text", dt, "diagnosisId", false);

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
            comboBox_Site.DataBindings.Add("SelectedValue", dt, "site", false);
            textBox_Chinese_Description_1_DIA.DataBindings.Add("Text", dt, "Site2", false);
            comboBox_Operation.DataBindings.Add("SelectedValue", dt, "Operation", false);
            textBox_Chinese_Description_2_DIA.DataBindings.Add("Text", dt, "Operation2", false);
            textBox_Diagnosis.DataBindings.Add("Text", dt, "Diagnosis", false);
            comboBox_Diagnosis_1.DataBindings.Add("SelectedValue", dt, "Diag_desc1", false);
            comboBox_Diagnosis_2.DataBindings.Add("SelectedValue", dt, "Diag_desc2", false);

            string snopcodeTSql = "SELECT [desc],snopcode,id FROM [snopcode] WHERE SNOPTYPE = 'T' ORDER BY [desc]";
            DataSet snopcodeTDataSet = new DataSet();
            SqlDataAdapter snopcodeTDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeTSql, snopcodeTDataSet, "snopcode");

            DataTable snopcodeTDt1 = new DataTable();
            snopcodeTDt1.Columns.Add("SNOPCODE");
            snopcodeTDt1.Columns.Add("Desc");
            snopcodeTDt1.Columns.Add("id");
            DataTable snopcodeTDt2 = snopcodeTDt1.Clone();
            DataTable snopcodeTDt3 = snopcodeTDt1.Clone();

            foreach (DataRow mDr in snopcodeTDataSet.Tables["snopcode"].Rows)
            {
                snopcodeTDt1.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeTDt2.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeTDt3.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
            }

            comboBox_Snop_T1.DataSource = snopcodeTDt1;
            comboBox_Snop_T2.DataSource = snopcodeTDt2;
            comboBox_Snop_T3.DataSource = snopcodeTDt3;

            string snopcodeMSql = "SELECT [desc],snopcode,id FROM [snopcode] WHERE SNOPTYPE = 'M' ORDER BY [desc]";
            DataSet snopcodeMDataSet = new DataSet();
            SqlDataAdapter snopcodeMDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeMSql, snopcodeMDataSet, "snopcode");

            DataTable snopcodeMDt1 = new DataTable();
            snopcodeMDt1.Columns.Add("SNOPCODE");
            snopcodeMDt1.Columns.Add("Desc");
            snopcodeMDt1.Columns.Add("id");
            DataTable snopcodeMDt2 = snopcodeMDt1.Clone();
            DataTable snopcodeMDt3 = snopcodeMDt1.Clone();

            foreach (DataRow mDr in snopcodeMDataSet.Tables["snopcode"].Rows)
            {
                snopcodeMDt1.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeMDt2.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeMDt3.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
            }

            comboBox_Snop_M1.DataSource = snopcodeMDt1;
            comboBox_Snop_M2.DataSource = snopcodeMDt2;
            comboBox_Snop_M3.DataSource = snopcodeMDt3;

            /*string bxcy_sql = string.Format("SELECT * FROM [bxcy_specimen] WHERE id={0}", bxcy_id);
            bxcy_specimentDataAdapter = DBConn.fetchDataIntoDataSet(bxcy_sql, bxcy_specimenDataSet, "bxcy_specimen");

            bxcy_specimentDt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            bxcy_specimentDt.PrimaryKey = new DataColumn[] { bxcy_specimentDt.Columns["id"] };
            bxcy_specimentDt.Columns["id"].AutoIncrement = true;
            bxcy_specimentDt.Columns["id"].AutoIncrementStep = 1;

            textBox_specimenID.DataBindings.Add("Text", bxcy_specimentDt, "id", false);

            comboBox_Snop_T1.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_t", false);
            comboBox_Snop_T2.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_t2", false);
            comboBox_Snop_T3.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_t3", false);
            comboBox_Snop_M1.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m", false);
            comboBox_Snop_M2.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m2", false);
            comboBox_Snop_M3.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m3", false);*/

            label_Total_Parts_No.DataBindings.Clear();
            string groupSql = string.Format("SELECT ISNULL(max([group]),0) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
            DataSet groupDataSet = new DataSet();
            SqlDataAdapter groupDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet, "bxcy_diag");

            DataTable groupDt = groupDataSet.Tables["bxcy_diag"];
            label_Total_Parts_No.DataBindings.Add("Text", groupDt, "maxGroup", false);

            if (snopT1 != null)
            {
                comboBox_Snop_T1.SelectedValue = snopT1;
            }
            if (snopT2 != null)
            {
                comboBox_Snop_T2.SelectedValue = snopT2;
            }
            if (snopT3 != null)
            {
                comboBox_Snop_T3.SelectedValue = snopT3;
            }
            if (snopM1 != null)
            {
                comboBox_Snop_M1.SelectedValue = snopM1;
            }
            if (snopM2 != null)
            {
                comboBox_Snop_M2.SelectedValue = snopM2;
            }
            if (snopM3 != null)
            {
                comboBox_Snop_M3.SelectedValue = snopM3;
            }

            /*if (groupDt != null && groupDt.Rows.Count > 0)
            {
                label_Total_Parts_No.Text = groupDt.Rows[0]["maxGroup"].ToString();
            }*/
        }

        private void reloadAndBindingDBData(string groupNo = null)
        {
            currentNevigateMode = NevigateMode.MODE_GROUP;

            //string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' AND [group] in (SELECT min([group]) FROM [bxcy_diag] WHERE case_no = '{0}') ORDER BY id", caseNo);
            string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' ORDER BY [group] , diagnosisid", caseNo);
            if (groupNo != null && groupNo.Trim() != "")
            {
                sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' AND [group] = {1} ORDER BY diagnosisid", caseNo, groupNo);
            }

            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");

            dt = bxcy_diagDataSet.Tables["bxcy_diag"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            currencyManager = (CurrencyManager)this.BindingContext[dt];
            textBox_ID.DataBindings.Clear();
            comboBox_Description.DataBindings.Clear();
            comboBox_Description2.DataBindings.Clear();
            textBox_Remarks_CY.DataBindings.Clear();
            textBox_Parts.DataBindings.Clear();
            textBox_Parts2.DataBindings.Clear();
            textBox_Parts3.DataBindings.Clear();

            textBox_DiagnosisNo.DataBindings.Clear();
            textBox_DiagnosisNo2.DataBindings.Clear();
            textBox_DiagnosisNo3.DataBindings.Clear();

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

            textBox_specimenID.DataBindings.Clear();

            string siteSql = "SELECT [site],[desc] FROM [site] WHERE site is not null ORDER BY site";
            DataSet siteDataSet = new DataSet();
            SqlDataAdapter siteDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(siteSql, siteDataSet, "site");

            DataTable siteDt = new DataTable();
            siteDt.Columns.Add("site");
            siteDt.Columns.Add("Desc");

            siteDt.Rows.Add(new object[] { "", "" });

            foreach (DataRow mDr in siteDataSet.Tables["site"].Rows)
            {
                siteDt.Rows.Add(new object[] { mDr["site"].ToString().Trim(), mDr["desc"].ToString().Trim() });
            }

            comboBox_Site.DataSource = siteDt;
            //comboBox_Site.SelectedValue

            string operationSql = "SELECT [operation],[desc] FROM [operation] WHERE operation is not null ORDER BY operation";
            DataSet operationDataSet = new DataSet();
            SqlDataAdapter operationDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(operationSql, operationDataSet, "operation");

            DataTable operationDt = new DataTable();
            operationDt.Columns.Add("operation");
            operationDt.Columns.Add("Desc");

            operationDt.Rows.Add(new object[] { "", "" });
            foreach (DataRow mDr in operationDataSet.Tables["operation"].Rows)
            {
                operationDt.Rows.Add(new object[] { mDr["operation"].ToString().Trim(), mDr["desc"].ToString().Trim() });
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

            macro_templateDt.Rows.Add(new object[] { "" });
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

            micro_templateDt.Rows.Add(new object[] { "" });
            foreach (DataRow mDr in micro_templateDataSet.Tables["micro_template"].Rows)
            {
                micro_templateDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Doctor2.DataSource = micro_templateDt;

            string diag_descSql = "SELECT C_DESC,E_DESC FROM [diag_desc] WHERE E_DESC is not null ORDER BY E_DESC";
            DataSet diag_descDataSet = new DataSet();
            SqlDataAdapter diag_descDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diag_descSql, diag_descDataSet, "diag_desc");

            DataTable diag_descDt1 = new DataTable();
            diag_descDt1.Columns.Add("C_DESC");
            diag_descDt1.Columns.Add("E_DESC");
            DataTable diag_descDt2 = diag_descDt1.Clone();
            AutoCompleteStringCollection autoCol1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autoCol2 = new AutoCompleteStringCollection();

            diag_descDt1.Rows.Add(new object[] { "", "" });
            diag_descDt2.Rows.Add(new object[] { "", "" });
            foreach (DataRow mDr in diag_descDataSet.Tables["diag_desc"].Rows)
            {
                diag_descDt1.Rows.Add(new object[] { mDr["C_DESC"].ToString().Trim(), mDr["E_DESC"].ToString().Trim() });
                diag_descDt2.Rows.Add(new object[] { mDr["C_DESC"].ToString().Trim(), mDr["E_DESC"].ToString().Trim() });
                autoCol1.Add(mDr["E_DESC"].ToString().Trim() + " | " + mDr["C_DESC"].ToString().Trim());
                autoCol2.Add(mDr["E_DESC"].ToString().Trim() + " | " + mDr["C_DESC"].ToString().Trim());
            }

            comboBox_Diagnosis_1.DataSource = diag_descDt1;
            comboBox_Diagnosis_1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            comboBox_Diagnosis_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox_Diagnosis_1.AutoCompleteCustomSource = autoCol1;

            comboBox_Diagnosis_2.DataSource = diag_descDt2;
            comboBox_Diagnosis_2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            comboBox_Diagnosis_2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox_Diagnosis_2.AutoCompleteCustomSource = autoCol2;

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

            picture_capDt1.Rows.Add(new object[] { "" });
            picture_capDt2.Rows.Add(new object[] { "" });
            picture_capDt3.Rows.Add(new object[] { "" });
            picture_capDt4.Rows.Add(new object[] { "" });
            picture_capDt5.Rows.Add(new object[] { "" });
            picture_capDt6.Rows.Add(new object[] { "" });
            picture_capDt7.Rows.Add(new object[] { "" });
            picture_capDt8.Rows.Add(new object[] { "" });

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
            comboBox_Description2.DataBindings.Add("Text", dt, "micro_name", false);
            textBox_Remarks_CY.DataBindings.Add("Text", dt, "micro_desc", false);
            textBox_Parts.DataBindings.Add("Text", dt, "group", false);
            textBox_Parts2.DataBindings.Add("Text", dt, "group", false);
            textBox_Parts3.DataBindings.Add("Text", dt, "group", false);

            textBox_DiagnosisNo.DataBindings.Add("Text", dt, "diagnosisId", false);
            textBox_DiagnosisNo2.DataBindings.Add("Text", dt, "diagnosisId", false);
            textBox_DiagnosisNo3.DataBindings.Add("Text", dt, "diagnosisId", false);

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
            comboBox_Site.DataBindings.Add("SelectedValue", dt, "site", false);
            textBox_Chinese_Description_1_DIA.DataBindings.Add("Text", dt, "Site2", false);
            comboBox_Operation.DataBindings.Add("SelectedValue", dt, "Operation", false);
            textBox_Chinese_Description_2_DIA.DataBindings.Add("Text", dt, "Operation2", false);
            textBox_Diagnosis.DataBindings.Add("Text", dt, "Diagnosis", false);
            comboBox_Diagnosis_1.DataBindings.Add("SelectedValue", dt, "Diag_desc1", false);
            comboBox_Diagnosis_2.DataBindings.Add("SelectedValue", dt, "Diag_desc2", false);

            string snopcodeTSql = "SELECT [desc],snopcode,id FROM [snopcode] WHERE SNOPTYPE = 'T' ORDER BY [desc]";
            DataSet snopcodeTDataSet = new DataSet();
            SqlDataAdapter snopcodeTDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeTSql, snopcodeTDataSet, "snopcode");

            DataTable snopcodeTDt1 = new DataTable();
            snopcodeTDt1.Columns.Add("SNOPCODE");
            snopcodeTDt1.Columns.Add("Desc");
            snopcodeTDt1.Columns.Add("id");
            DataTable snopcodeTDt2 = snopcodeTDt1.Clone();
            DataTable snopcodeTDt3 = snopcodeTDt1.Clone();

            foreach (DataRow mDr in snopcodeTDataSet.Tables["snopcode"].Rows)
            {
                snopcodeTDt1.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeTDt2.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeTDt3.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
            }

            comboBox_Snop_T1.DataSource = snopcodeTDt1;
            comboBox_Snop_T2.DataSource = snopcodeTDt2;
            comboBox_Snop_T3.DataSource = snopcodeTDt3;

            string snopcodeMSql = "SELECT [desc],snopcode,id FROM [snopcode] WHERE SNOPTYPE = 'M' ORDER BY [desc]";
            DataSet snopcodeMDataSet = new DataSet();
            SqlDataAdapter snopcodeMDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeMSql, snopcodeMDataSet, "snopcode");

            DataTable snopcodeMDt1 = new DataTable();
            snopcodeMDt1.Columns.Add("SNOPCODE");
            snopcodeMDt1.Columns.Add("Desc");
            snopcodeMDt1.Columns.Add("id");
            DataTable snopcodeMDt2 = snopcodeMDt1.Clone();
            DataTable snopcodeMDt3 = snopcodeMDt1.Clone();

            foreach (DataRow mDr in snopcodeMDataSet.Tables["snopcode"].Rows)
            {
                snopcodeMDt1.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeMDt2.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
                snopcodeMDt3.Rows.Add(new object[] { mDr["SNOPCODE"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
            }

            comboBox_Snop_M1.DataSource = snopcodeMDt1;
            comboBox_Snop_M2.DataSource = snopcodeMDt2;
            comboBox_Snop_M3.DataSource = snopcodeMDt3;

            /*string bxcy_sql = string.Format("SELECT * FROM [bxcy_specimen] WHERE id={0}", bxcy_id);
            bxcy_specimentDataAdapter = DBConn.fetchDataIntoDataSet(bxcy_sql, bxcy_specimenDataSet, "bxcy_specimen");

            bxcy_specimentDt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            bxcy_specimentDt.PrimaryKey = new DataColumn[] { bxcy_specimentDt.Columns["id"] };
            bxcy_specimentDt.Columns["id"].AutoIncrement = true;
            bxcy_specimentDt.Columns["id"].AutoIncrementStep = 1;

            textBox_specimenID.DataBindings.Add("Text", bxcy_specimentDt, "id", false);

            comboBox_Snop_T1.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_t", false);
            comboBox_Snop_T2.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_t2", false);
            comboBox_Snop_T3.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_t3", false);
            comboBox_Snop_M1.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m", false);
            comboBox_Snop_M2.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m2", false);
            comboBox_Snop_M3.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m3", false);*/

            label_Total_Parts_No.DataBindings.Clear();
            string groupSql = string.Format("SELECT ISNULL(max([group]),0) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
            DataSet groupDataSet = new DataSet();
            SqlDataAdapter groupDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet, "bxcy_diag");

            DataTable groupDt = groupDataSet.Tables["bxcy_diag"];
            label_Total_Parts_No.DataBindings.Add("Text", groupDt, "maxGroup", false);

            if (snopT1 != null)
            {
                comboBox_Snop_T1.SelectedValue = snopT1;
            }
            if (snopT2 != null)
            {
                comboBox_Snop_T2.SelectedValue = snopT2;
            }
            if (snopT3 != null)
            {
                comboBox_Snop_T3.SelectedValue = snopT3;
            }
            if (snopM1 != null)
            {
                comboBox_Snop_M1.SelectedValue = snopM1;
            }
            if (snopM2 != null)
            {
                comboBox_Snop_M2.SelectedValue = snopM2;
            }
            if (snopM3 != null)
            {
                comboBox_Snop_M3.SelectedValue = snopM3;
            }

            /*if (groupDt != null && groupDt.Rows.Count > 0)
            {
                label_Total_Parts_No.Text = groupDt.Rows[0]["maxGroup"].ToString();
            }*/
        }

        private void reloadDBData(int position = 0)
        {
            string sql = string.Format("SELECT TOP 1 * FROM BXCY_DIAG WHERE case_no = '{0}' ORDER BY ID",caseNo);
            DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "BXCY_DIAG");

            DataTable dt = bxcy_diagDataSet.Tables["BXCY_DIAG"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            label_Total_Parts_No.DataBindings.Clear();
            string groupSql = string.Format("SELECT ISNULL(max([group]),0) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
            DataSet groupDataSet = new DataSet();
            SqlDataAdapter groupDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet, "bxcy_diag");

            DataTable groupDt = groupDataSet.Tables["bxcy_diag"];
            label_Total_Parts_No.DataBindings.Add("Text", groupDt, "maxGroup", false);
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (textBox_Parts.Text.Trim() == "")
            {
                return;
            }

            /*if (textBox_ID.Text.Trim() != "")
            {
                string countSql = string.Format(" [bxcy_diag] WHERE [group] > '{0}' and case_no = '{1}'", textBox_Parts.Text, caseNo);
                if (DBConn.getSqlRecordCount(countSql) > 0)
                {
                    string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{1}' AND [group] in (SELECT min([group]) FROM [bxcy_diag] WHERE [group] > '{0}' AND case_no = '{1}') ORDER BY ID", textBox_Parts.Text, caseNo);
                    dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
                }
            }*/

            var minGroupFromProg = (from p in dt.AsEnumerable()
                                    where p.Field<string>("group").CompareTo(textBox_Parts.Text.Trim()) == 1
                                    select p.Field<string>("group")).Min();
            if (minGroupFromProg != null)
            { 
                string strMinGroupFromProg = Convert.ToString(minGroupFromProg);

                DataRow dr = dt.Select("group=" + strMinGroupFromProg)[0];
                currencyManager.Position = dt.Rows.IndexOf(dr);
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            if (textBox_Parts.Text.Trim() == "")
            {
                return;
            }

            /*
            if (textBox_ID.Text.Trim() != "")
            {
                string countSql = string.Format(" [bxcy_diag] WHERE [group] < {0} and case_no = '{1}'", textBox_Parts.Text, caseNo);
                if (DBConn.getSqlRecordCount(countSql) > 0)
                {
                    string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE [group] < '{0}' and case_no = '{1}' ORDER BY ID", textBox_Parts.Text, caseNo);
                    dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
                }
            }*/
            // edit by eirc to fix the report back problem
            /*if (textBox_ID.Text != "" && textBox_Parts.Text != "")
            {
                if (textBox_Parts.Text != "1")
                {
                    string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{1}' AND [group] in (SELECT top 1 [group] FROM [bxcy_diag] WHERE [group] < '{0}' AND case_no = '{1}' order by [group] desc) ORDER BY id", textBox_Parts.Text, caseNo);
                    dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
                }
            }*/

            var minGroupFromProg = (from p in dt.AsEnumerable()
                                    select p.Field<string>("group")).Min();

            if (minGroupFromProg != null)
            {
                string strMinGroupFromProg = Convert.ToString(minGroupFromProg);

                DataRow dr = dt.Select("group=" + strMinGroupFromProg)[0];
                currencyManager.Position = dt.Rows.IndexOf(dr);
            }

        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            /*string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' AND [group] in (SELECT min([group]) FROM [bxcy_diag] WHERE case_no = '{0}') ORDER BY id", caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");*/

            /*if (currentNevigateMode == NevigateMode.MODE_DIAGNOSIS)
            {
                string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' ORDER BY [group]", caseNo);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
            }

            if (currencyManager != null)
            {
                currencyManager.Position = 0;
            }*/
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            
            /*string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' AND [group] in (SELECT max([group]) FROM [bxcy_diag] WHERE case_no = '{0}' ORDER BY id", caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");*/
            

            /*if (currentNevigateMode == NevigateMode.MODE_DIAGNOSIS)
            {
                string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' ORDER BY [group]", caseNo);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
            }

            if (currencyManager != null)
            {
                currencyManager.Position = 0;
            }*/
        }

        private void button_F6_Edit_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                button_New.PerformClick();
            }
            else
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
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_EDIT);

            isSameGroupNewRecord = false;

            currentEditRow = bxcy_diagDataSet.Tables["bxcy_diag"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["case_no"] = caseNo;

            string groupSql = string.Format("SELECT ISNULL(max([group]),0) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
            DataSet groupDataSet1 = new DataSet();
            SqlDataAdapter groupDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet1, "bxcy_diag");

            DataTable groupDt = groupDataSet1.Tables["bxcy_diag"];
            int intMaxGroupFromDB = 1;
            int.TryParse(groupDt.Rows[0]["maxGroup"].ToString(), out intMaxGroupFromDB);

            var maxGroupFromProgFromDB = (from p in dt.AsEnumerable()
                                          where p.Field<string>("case_no") == caseNo
                                          select p.Field<string>("group")).Max();

            int intMaxGroupFromProg = 1;
            if (maxGroupFromProgFromDB != null)
            {
                int.TryParse(maxGroupFromProgFromDB, out intMaxGroupFromProg);
            }

            if(intMaxGroupFromDB > intMaxGroupFromProg)
            {
                currentEditRow["group"] = (Convert.ToInt32(intMaxGroupFromDB) + 1).ToString();
            }
            else
            {
                currentEditRow["group"] = (Convert.ToInt32(intMaxGroupFromProg) + 1).ToString();
            }

            currentEditRow["diagnosisId"] = 1;

            currentEditRow["micro_name"] = "MICROSCOPIC EXAMINATION:";
            currentEditRow["macro_name"] = "MACROSCOPIC EXAMINATION:";

            //bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Clear();
            bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Add(currentEditRow);
            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Sure to delete this record in group {0}?", textBox_Parts.Text), "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM BXCY_DIAG WHERE [group] = '{0}' and case_no = '{1}'", textBox_Parts.Text, caseNo);

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
                comboBox_Description.Enabled = false;

                button_Caption_Detail.Enabled = false;
                textBox_Picture_File_1.Enabled = false;
                textBox_Picture_File_2.Enabled = false;
                textBox_Picture_File_3.Enabled = false;
                textBox_Picture_File_4.Enabled = false;
                textBox_Picture_File_5.Enabled = false;
                textBox_Picture_File_6.Enabled = false;
                textBox_Picture_File_7.Enabled = false;
                textBox_Picture_File_8.Enabled = false;

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

                //button_Top.Enabled = true;
                button_Back.Enabled = true;
                button_Next.Enabled = true;
                //button_End.Enabled = true;
                button_New.Enabled = true;

                //button_Top2.Enabled = true;
                button_Back2.Enabled = true;
                button_Next2.Enabled = true;
                //button_End2.Enabled = true;
                button_New2.Enabled = true;

                button_Save.Enabled = false;
                button_F6_Edit.Enabled = true;
                button_Delete.Enabled = true;
                button_Label.Enabled = true;
                button_Path.Enabled = true;
                button_F8_Back_To_Main.Enabled = true;
                button_Undo.Enabled = false;

                comboBox_MIC_Add2.Enabled = false;
                buttonremoveCinese.Enabled = false;
                button_Copy.Enabled = true;

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

                    //button_Top.Enabled = false;
                    button_Back.Enabled = true;
                    button_Next.Enabled = true;
                    //button_End.Enabled = false;
                    button_New.Enabled = true;

                    //button_Top2.Enabled = true;
                    button_Back2.Enabled = true;
                    button_Next2.Enabled = true;
                    //button_End2.Enabled = true;
                    button_New2.Enabled = true;

                    button_Save.Enabled = true;
                    
                    button_F6_Edit.Enabled = false;
                    button_Delete.Enabled = true;
                    button_Label.Enabled = false;
                    button_Path.Enabled = true;
                    button_F8_Back_To_Main.Enabled = true;
                    button_Undo.Enabled = false;

                    comboBox_MIC_Add2.Enabled = true;
                    buttonremoveCinese.Enabled = true;
                    button_Copy.Enabled = true;
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

                        //button_Top.Enabled = false;
                        button_Back.Enabled = true;
                        button_Next.Enabled = true;
                        //button_End.Enabled = false;
                        button_New.Enabled = true;

                        //button_Top2.Enabled = true;
                        button_Back2.Enabled = true;
                        button_Next2.Enabled = true;
                        //button_End2.Enabled = true;
                        button_New2.Enabled = true;

                        button_Save.Enabled = true;
                        
                        button_F6_Edit.Enabled = false;
                        button_Delete.Enabled = false;
                        button_Label.Enabled = false;
                        button_Path.Enabled = true;
                        button_F8_Back_To_Main.Enabled = true;
                        button_Undo.Enabled = true;

                        comboBox_MIC_Add2.Enabled = true;
                        buttonremoveCinese.Enabled = true;
                        button_Copy.Enabled = false;
                        edit_modle();
                    }
                }
            }
        }

        private void edit_modle()
        {
            //button_Top.Image = Image.FromFile("Resources/topGra.png");
            //button_Top.ForeColor = Color.Gray;
            button_Back.Image = Image.FromFile("Resources/back.png");
            button_Back.ForeColor = Color.Black;
            button_Next.Image = Image.FromFile("Resources/next.png");
            button_Next.ForeColor = Color.Black;
            //button_End.Image = Image.FromFile("Resources/endGra.png");
            //button_End.ForeColor = Color.Gray;
            button_Save.Image = Image.FromFile("Resources/save.png");
            button_Save.ForeColor = Color.Black;
            button_New.Image = Image.FromFile("Resources/new.png");
            button_New.ForeColor = Color.Black;
            button_F6_Edit.Image = Image.FromFile("Resources/editGra.png");
            button_F6_Edit.ForeColor = Color.Gray;
            button_Delete.Image = Image.FromFile("Resources/deleteGra.png");
            button_Delete.ForeColor = Color.Gray;
            button_Undo.Image = Image.FromFile("Resources/undo.png");
            button_Undo.ForeColor = Color.Black;
            button_F8_Back_To_Main.Image = Image.FromFile("Resources/exit.png");
            button_F8_Back_To_Main.ForeColor = Color.Black;

            button_Copy.Image = Image.FromFile("Resources/newGra.png");
            button_Copy.ForeColor = Color.Gray;
            /*button_Label.Image = Image.FromFile("Resources/print.png");
            button_Label.ForeColor = Color.Black;*/
        }

        private void disedit_modle()
        {
            //button_Top.Image = Image.FromFile("Resources/top.png");
            //button_Top.ForeColor = Color.Black;
            button_Back.Image = Image.FromFile("Resources/back.png");
            button_Back.ForeColor = Color.Black;
            button_Next.Image = Image.FromFile("Resources/next.png");
            button_Next.ForeColor = Color.Black;
            //button_End.Image = Image.FromFile("Resources/end.png");
            //button_End.ForeColor = Color.Black;
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

            button_Copy.Image = Image.FromFile("Resources/new.png");
            button_Copy.ForeColor = Color.Black;
            /*button_Label.Image = Image.FromFile("Resources/print.png");
            button_Label.ForeColor = Color.Black;*/
            /*button_Label.Image = Image.FromFile("Resources/print.png");
            button_Label.ForeColor = Color.Black;*/
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
            /*int mainPageUpdateResult = 0;
            if (OnBxcyDiagSaveBoth != null)
            {
                mainPageUpdateResult = OnBxcyDiagSaveBoth(comboBox_Snop_T1.SelectedValue, comboBox_Snop_T2.SelectedValue, comboBox_Snop_T3.SelectedValue, comboBox_Snop_M1.SelectedValue, comboBox_Snop_M2.SelectedValue, comboBox_Snop_M3.SelectedValue);
            }

            if (mainPageUpdateResult != 1 && mainPageUpdateResult != 2)
            {
                bool updated = true;
                if (currentStatus == PageStatus.STATUS_NEW)
                {
                    if (currentEditRow != null)
                    {
                        currentEditRow["barcode"] = currentEditRow["case_no"].ToString().Trim().Replace("/", "") + currentEditRow["group"].ToString().Trim();
                        textBox_ID.BindingContext[dt].Position++;

                        string currentGroupNo = textBox_Parts.Text.Trim();
                        int currentPosition = currencyManager.Position;

                        if (DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "bxcy_diag"))
                        {
                            reloadAndBindingDBData(currentGroupNo);
                            if (currentPosition < currencyManager.Count)
                            {
                                currencyManager.Position = currentPosition;
                            }
                        }
                        else
                        {
                            updated = false;
                        }
                    }
                }
                else
                {
                    if (currentStatus == PageStatus.STATUS_EDIT)
                    {
                        DataRow drow = bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Find(textBox_ID.Text);
                        if (drow != null)
                        {
                            textBox_ID.BindingContext[dt].Position++;

                            string currentGroupNo = textBox_Parts.Text.Trim();
                            int currentPosition = currencyManager.Position;

                            if (!DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "bxcy_diag"))
                            {
                                updated = false;
                            }
                            else
                            {
                                reloadAndBindingDBData(currentGroupNo);
                                if (currentPosition < currencyManager.Count)
                                {
                                    currencyManager.Position = currentPosition;
                                }
                            }
                        }
                    }
                }

                if (updated || mainPageUpdateResult == 0)
                {
                    MessageBox.Show("Record updated");
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                else
                {
                    MessageBox.Show("Record updated fail, please contact Admin");
                }
            }
            else
            {
                if (mainPageUpdateResult != 1)
                {
                    MessageBox.Show("Record updated fail, please contact Admin");
                }
            }*/
        }

        private void comboBox_MAC_Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_MIC_Add2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string macro_templateSql = string.Format("SELECT distinct ORGAN FROM [macro_template] WHERE DOCTOR = '{0}'", comboBox_Doctor.SelectedValue.ToString());
            DataSet macro_templateDataSet = new DataSet();
            SqlDataAdapter macro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(macro_templateSql, macro_templateDataSet, "macro_template");

            DataTable macro_templateDt = new DataTable();
            macro_templateDt.Columns.Add("ORGAN");

            macro_templateDt.Rows.Add(new object[] { "" });
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

            macro_templateDt.Rows.Add(new object[] { "" });
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
                textBox_Remarks.Text += macro_templateDataSet.Tables["macro_template"].Rows[0]["MACRO_DESC"].ToString();
            }
        }

        private void comboBox_Doctor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string micro_templateSql = string.Format("SELECT distinct ORGAN FROM [micro_template] WHERE DOCTOR = '{0}'", comboBox_Doctor2.SelectedValue.ToString());
            DataSet micro_templateDataSet = new DataSet();
            SqlDataAdapter micro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(micro_templateSql, micro_templateDataSet, "micro_template");

            DataTable micro_templateDt = new DataTable();
            micro_templateDt.Columns.Add("ORGAN");

            micro_templateDt.Rows.Add(new object[] { "" });
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

            micro_templateDt.Rows.Add(new object[] { "" });
            foreach (DataRow mDr in micro_templateDataSet.Tables["micro_template"].Rows)
            {
                micro_templateDt.Rows.Add(new object[] { mDr["TEMPLATE"] });
            }

            comboBox_Template2.DataSource = micro_templateDt;
        }

        private void button_Add_Template2_Click(object sender, EventArgs e)
        {
            string micro_templateSql = string.Format("SELECT TOP 1 * FROM [micro_template] WHERE DOCTOR = '{0}' AND ORGAN = '{1}' AND TEMPLATE = '{2}'", comboBox_Doctor2.SelectedValue.ToString(), comboBox_Organ2.SelectedValue.ToString(), comboBox_Template2.SelectedValue.ToString());
            DataSet micro_templateDataSet = new DataSet();
            SqlDataAdapter micro_templateDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(micro_templateSql, micro_templateDataSet, "micro_template");

            if (micro_templateDataSet.Tables["micro_template"].Rows.Count > 0)
            {
                var countList = from p in dt.AsEnumerable()
                                 where p.Field<string>("group") == textBox_Parts.Text.Trim()
                                 && p.Field<string>("case_no") == caseNo
                                 select p;
                if (countList.Count() == 1)
                {
                    currentEditRow = countList.FirstOrDefault();
                    /*if (currentEditRow["micro_desc"].ToString() == "" 
                        && currentEditRow["site"].ToString() == ""
                        && currentEditRow["site2"].ToString() == ""
                        && currentEditRow["operation"].ToString() == ""
                        && currentEditRow["operation2"].ToString() == ""
                        && currentEditRow["Diagnosis"].ToString() == ""
                        && currentEditRow["Diag_desc1"].ToString() == ""
                        && currentEditRow["Diag_desc2"].ToString() == ""
                        )
                        */
                    // Updated by eric leung removed the micro description checking
                    if (
                        currentEditRow["site"].ToString() == ""
                        && currentEditRow["site2"].ToString() == ""
                        && currentEditRow["operation"].ToString() == ""
                        && currentEditRow["operation2"].ToString() == ""
                        && currentEditRow["Diagnosis"].ToString() == ""
                        && currentEditRow["Diag_desc1"].ToString() == ""
                        && currentEditRow["Diag_desc2"].ToString() == ""
                    )
                    {
                        currentEditRow["micro_desc"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["micro_DESC"].ToString();

                        currentEditRow["site"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE"].ToString();

                        currentEditRow["site2"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE2"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE2"].ToString();

                        currentEditRow["operation"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION"].ToString();

                        currentEditRow["operation2"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION2"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION2"].ToString();

                        currentEditRow["Diagnosis"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAGNOSIS"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAGNOSIS"].ToString();

                        currentEditRow["Diag_desc1"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC1"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC1"].ToString();

                        currentEditRow["Diag_desc2"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC2"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC2"].ToString();

                        return;
                    }
                }

                isSameGroupNewRecord = true;
                currentEditRow = bxcy_diagDataSet.Tables["bxcy_diag"].NewRow();

                currentEditRow["macro_name"] = "";
                currentEditRow["micro_name"] = "";
                currentEditRow["micro_desc"] = "";
                currentEditRow["macro_pic1"] = "";
                currentEditRow["macro_pic2"] = "";
                currentEditRow["macro_pic3"] = "";
                currentEditRow["macro_pic4"] = "";
                currentEditRow["micro_pic1"] = "";
                currentEditRow["micro_pic2"] = "";
                currentEditRow["micro_pic3"] = "";
                currentEditRow["micro_pic4"] = "";
                currentEditRow["macro_cap1"] = "";
                currentEditRow["macro_cap2"] = "";
                currentEditRow["macro_cap3"] = "";
                currentEditRow["macro_cap4"] = "";
                currentEditRow["micro_cap1"] = "";
                currentEditRow["micro_cap2"] = "";
                currentEditRow["micro_cap3"] = "";
                currentEditRow["micro_cap4"] = "";
                currentEditRow["macro_desc"] = "";
                currentEditRow["site"] = "";
                currentEditRow["Site2"] = "";
                currentEditRow["Operation"] = "";
                currentEditRow["Operation2"] = "";
                currentEditRow["Diagnosis"] = "";
                currentEditRow["Diag_desc1"] = "";
                currentEditRow["Diag_desc2"] = "";
                currentEditRow["seq"] = "";

                currentEditRow["case_no"] = caseNo;
                currentEditRow["group"] = textBox_Parts.Text.Trim();

                var maxDiagnosisIdFromProg = (from p in dt.AsEnumerable()
                                              where p.Field<string>("case_no") == caseNo
                                                  && p.Field<string>("group") == textBox_Parts.Text.Trim()
                                              select p.Field<int>("diagnosisId")).Max();

                int maxDiagnosisFromProg = Convert.ToInt32(maxDiagnosisIdFromProg);

                string groupSql = string.Format("SELECT ISNULL(max([diagnosisId]),0) as maxDiagnosisId FROM [bxcy_diag] WHERE case_no='{0}' and [group] = '{1}'", caseNo, textBox_Parts.Text.Trim());
                DataSet groupDataSet1 = new DataSet();
                SqlDataAdapter groupDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet1, "bxcy_diag");

                DataTable groupDt = groupDataSet1.Tables["bxcy_diag"];
                int currentDiagnosisIdInDB = 1;
                int.TryParse(groupDt.Rows[0]["maxDiagnosisId"].ToString(), out currentDiagnosisIdInDB);

                if (maxDiagnosisFromProg > currentDiagnosisIdInDB)
                {
                    currentEditRow["diagnosisId"] = maxDiagnosisFromProg + 1;
                }
                else
                {
                    currentEditRow["diagnosisId"] = currentDiagnosisIdInDB + 1;
                }

                setFirstMarcoAndMicroValue(currentEditRow);

                // updated by Eric Leung 2019-12-14 14:11
                if (textBox_Remarks_CY.Text == "")
                {
                    currentEditRow["micro_desc"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["micro_DESC"].ToString();
                }
                else
                {
                    currentEditRow["micro_desc"] = textBox_Remarks_CY.Text + Environment.NewLine + Environment.NewLine + micro_templateDataSet.Tables["micro_template"].Rows[0]["micro_DESC"].ToString();
                }

                currentEditRow["site"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE"].ToString();

                currentEditRow["site2"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE2"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["SITE2"].ToString();

                currentEditRow["operation"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION"].ToString();

                currentEditRow["operation2"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION2"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["OPERATION2"].ToString();

                currentEditRow["Diagnosis"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAGNOSIS"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAGNOSIS"].ToString();

                currentEditRow["Diag_desc1"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC1"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC1"].ToString();

                currentEditRow["Diag_desc2"] = micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC2"].ToString() == null ? "" : micro_templateDataSet.Tables["micro_template"].Rows[0]["DIAG_DESC2"].ToString();

                bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Add(currentEditRow);
                currencyManager.Position = currencyManager.Count - 1;
            }
        }

        private void button_Detail_4_DIA_Click(object sender, EventArgs e)
        {
            Form_DiagnosisDictionaryMaintenance open = new Form_DiagnosisDictionaryMaintenance();
            open.OnRecordUpdateDone += onDiagnosisUpdateDone;
            open.Show();
        }

        private void button_Detail_1_DIA_Click(object sender, EventArgs e)
        {
            Form_SiteFileMaintenance open = new Form_SiteFileMaintenance();
            open.OnRecordUpdateDone += onSiteUpdateDone;
            open.Show();
        }

        private void onSiteUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadSiteUpdate();
            }
        }

        private void reloadSiteUpdate()
        {
            string siteSql = "SELECT [site],[desc] FROM [site] WHERE site is not null ORDER BY site";
            DataSet siteDataSet = new DataSet();
            SqlDataAdapter siteDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(siteSql, siteDataSet, "site");

            DataTable siteDt = new DataTable();
            siteDt.Columns.Add("site");
            siteDt.Columns.Add("Desc");

            foreach (DataRow mDr in siteDataSet.Tables["site"].Rows)
            {
                siteDt.Rows.Add(new object[] { mDr["site"].ToString().Trim(), mDr["desc"].ToString().Trim() });
            }

            comboBox_Site.DataSource = siteDt;
        }

        private void button_Detail_2_DIA_Click(object sender, EventArgs e)
        {
            Form_OperationFileMaintenance open = new Form_OperationFileMaintenance();
            open.OnRecordUpdateDone += onOperationUpdateDone;
            open.Show();
        }

        private void onOperationUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadOperationUpdate();
            }
        }

        private void reloadOperationUpdate()
        {
            string operationSql = "SELECT [operation],[desc] FROM [operation] WHERE operation is not null ORDER BY operation";
            DataSet operationDataSet = new DataSet();
            SqlDataAdapter operationDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(operationSql, operationDataSet, "operation");

            DataTable operationDt = new DataTable();
            operationDt.Columns.Add("operation");
            operationDt.Columns.Add("Desc");

            operationDt.Rows.Add(new object[] { "", "" });
            foreach (DataRow mDr in operationDataSet.Tables["operation"].Rows)
            {
                operationDt.Rows.Add(new object[] { mDr["operation"].ToString().Trim(), mDr["desc"].ToString().Trim()});
            }

            comboBox_Operation.DataSource = operationDt;
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

        private void comboBox_MAC_Add_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (textBox_Remarks.Text == "")
            {
                textBox_Remarks.Text = comboBox_MAC_Add.SelectedValue.ToString();
            }
            else
            {
                textBox_Remarks.Text = textBox_Remarks.Text + Environment.NewLine + comboBox_MAC_Add.SelectedValue.ToString();
            }
            
        }

        private void comboBox_MIC_Add2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (textBox_Remarks_CY.Text == "")
            {
                textBox_Remarks_CY.Text = comboBox_MIC_Add2.SelectedValue.ToString();
            }
            else
            {
                textBox_Remarks_CY.Text = textBox_Remarks_CY.Text + Environment.NewLine + comboBox_MIC_Add2.SelectedValue.ToString();
            }
            
        }

        private void comboBox_Site_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet siteResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [site] WHERE site ='{0}'", comboBox_Site.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, siteResultDataSet, "site");

            if (siteResultDataSet.Tables["site"].Rows.Count > 0)
            {
                DataRow mDr = siteResultDataSet.Tables["site"].Rows[0];
                textBox_Chinese_Description_1_DIA.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_Operation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet operationResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [operation] WHERE operation ='{0}'", comboBox_Operation.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, operationResultDataSet, "operation");

            if (operationResultDataSet.Tables["operation"].Rows.Count > 0)
            {
                DataRow mDr = operationResultDataSet.Tables["operation"].Rows[0];
                textBox_Chinese_Description_2_DIA.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_Snop_T1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Snop_T2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Snop_T3_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Snop_M1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(desc, e.Font, sb, r2);

            Console.WriteLine("M1 draw");
        }

        private void comboBox_Site_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string site = drv.Row["site"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(desc, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(site, e.Font, sb, r2);
        }

        private void comboBox_Operation_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string operation = drv.Row["operation"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(desc, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(operation, e.Font, sb, r2);
        }

        private void buttonremoveCinese_Click(object sender, EventArgs e)
        {
            textBox_Chinese_Description_1_DIA.Text = "";
            textBox_Chinese_Description_2_DIA.Text = "";
            comboBox_Diagnosis_1.Text = "";
            comboBox_Diagnosis_2.Text = "";
        }

        private void comboBox_Diagnosis_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Snop_M2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void button_Top2_Click(object sender, EventArgs e)
        {
            /*if (currentStatus == PageStatus.STATUS_VIEW)
            {
                string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' and [group] = '{1}' ORDER BY ID", caseNo, textBox_Parts.Text.ToString());
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
            }
            else
            {*/
                /*if (currencyManager != null)
                {
                    currencyManager.Position = 0;
                }*/
            //}
        }

        private void button_Back2_Click(object sender, EventArgs e)
        {
            if (textBox_DiagnosisNo.Text.Trim() == "")
            {
                return;
            }

            /*if (textBox_ID.Text.Trim() != "")
            {
                if (currentStatus == PageStatus.STATUS_VIEW)
                {
                    string countSql = string.Format(" [bxcy_diag] WHERE id < {0} and case_no = '{1}' and [group] = '{2}'", textBox_ID.Text, caseNo, textBox_Parts.Text.ToString());
                    if (DBConn.getSqlRecordCount(countSql) > 0)
                    {
                        string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE id < {0} and case_no = '{1}' and [group] = '{2}' ORDER BY ID DESC", textBox_ID.Text, caseNo, textBox_Parts.Text.ToString());
                        dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
                    }
                }
                else
                {
                    if (currencyManager != null)
                    {
                        currencyManager.Position --;
                    }
                }
            }*/

            /*if (currencyManager != null)
            {
                currencyManager.Position--;
            }*/

            var prevFromProg = from p in dt.AsEnumerable()
                                    where p.Field<string>("group") == textBox_Parts.Text.Trim()
                                    && p.Field<int>("diagnosisId") < Convert.ToInt32(textBox_DiagnosisNo.Text.Trim())
                                    orderby p.Field<int>("diagnosisId") descending
                               select p;

            if (prevFromProg.Any())
            {
                currencyManager.Position = dt.Rows.IndexOf(prevFromProg.FirstOrDefault());
            }
        }

        private void button_Next2_Click(object sender, EventArgs e)
        {
            if (textBox_DiagnosisNo.Text.Trim() == "")
            {
                return;
            }

            /*if (textBox_ID.Text.Trim() != "")
            {
                string countSql = string.Format(" [bxcy_diag] WHERE id > {0} and case_no = '{1}' and [group] = '{2}'", textBox_ID.Text, caseNo, textBox_Parts.Text.ToString());
                if (DBConn.getSqlRecordCount(countSql) > 0)
                {
                    if (currentStatus == PageStatus.STATUS_VIEW)
                    {
                        string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE id > {0} and case_no = '{1}' and [group] = '{2}' ORDER BY ID", textBox_ID.Text, caseNo, textBox_Parts.Text.ToString());
                        dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
                    }
                    else
                    {
                        if (currencyManager != null)
                        {
                            currencyManager.Position++;
                        }
                    }
                }
            }*/

            var nextFromProg = from p in dt.AsEnumerable()
                               where p.Field<string>("group") == textBox_Parts.Text.Trim()
                               && p.Field<int>("diagnosisId") > Convert.ToInt32(textBox_DiagnosisNo.Text.Trim())
                               orderby p.Field<int>("diagnosisId") ascending
                               select p;

            if (nextFromProg.Any())
            {
                currencyManager.Position = dt.Rows.IndexOf(nextFromProg.FirstOrDefault());
            }
        }

        private void button_End2_Click(object sender, EventArgs e)
        {
            /*if (currentStatus == PageStatus.STATUS_VIEW)
            {
                string sql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' and [group] = '{1}' ORDER BY ID DESC", caseNo, textBox_Parts.Text.ToString());
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");
            }
            else
            {*/
                /*if (currencyManager != null)
                {
                    currencyManager.Position = currencyManager.Count - 1;
                }*/
            //}
        }

        private void button_New2_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_EDIT);

            isSameGroupNewRecord = true;

            currentEditRow = bxcy_diagDataSet.Tables["bxcy_diag"].NewRow();

            currentEditRow["macro_name"] = "";
            currentEditRow["micro_name"] = "";
            currentEditRow["micro_desc"] = "";
            currentEditRow["macro_pic1"] = "";
            currentEditRow["macro_pic2"] = "";
            currentEditRow["macro_pic3"] = "";
            currentEditRow["macro_pic4"] = "";
            currentEditRow["micro_pic1"] = "";
            currentEditRow["micro_pic2"] = "";
            currentEditRow["micro_pic3"] = "";
            currentEditRow["micro_pic4"] = "";
            currentEditRow["macro_cap1"] = "";
            currentEditRow["macro_cap2"] = "";
            currentEditRow["macro_cap3"] = "";
            currentEditRow["macro_cap4"] = "";
            currentEditRow["micro_cap1"] = "";
            currentEditRow["micro_cap2"] = "";
            currentEditRow["micro_cap3"] = "";
            currentEditRow["micro_cap4"] = "";
            currentEditRow["macro_desc"] = "";
            currentEditRow["site"] = "";
            currentEditRow["Site2"] = "";
            currentEditRow["Operation"] = "";
            currentEditRow["Operation2"] = "";
            currentEditRow["Diagnosis"] = "";
            currentEditRow["Diag_desc1"] = "";
            currentEditRow["Diag_desc2"] = "";
            currentEditRow["seq"] = "";

            currentEditRow["case_no"] = caseNo;
            currentEditRow["group"] = textBox_Parts.Text.Trim();

            var maxDiagnosisIdFromProg = (from p in dt.AsEnumerable()
                                    where p.Field<string>("case_no") == caseNo
                                        && p.Field<string>("group") == textBox_Parts.Text.Trim()
                                        select p.Field<int>("diagnosisId")).Max();

            int maxDiagnosisFromProg = Convert.ToInt32(maxDiagnosisIdFromProg);

            string groupSql = string.Format("SELECT ISNULL(max([diagnosisId]),0) as maxDiagnosisId FROM [bxcy_diag] WHERE case_no='{0}' and [group] = '{1}'", caseNo, textBox_Parts.Text.Trim());
            DataSet groupDataSet1 = new DataSet();
            SqlDataAdapter groupDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet1, "bxcy_diag");

            DataTable groupDt = groupDataSet1.Tables["bxcy_diag"];
            int currentDiagnosisIdInDB = 1;
            int.TryParse(groupDt.Rows[0]["maxDiagnosisId"].ToString(), out currentDiagnosisIdInDB);

            if(maxDiagnosisFromProg > currentDiagnosisIdInDB)
            {
                currentEditRow["diagnosisId"] = maxDiagnosisFromProg + 1;
            }
            else
            {
                currentEditRow["diagnosisId"] = currentDiagnosisIdInDB+1;
            }

            setFirstMarcoAndMicroValue(currentEditRow);

            //bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Clear();
            bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Add(currentEditRow);

            currencyManager.Position = currencyManager.Count - 1;
        }

        private void setFirstMarcoAndMicroValue(DataRow currentEditRow)
        {
            var changeList = from p in dt.AsEnumerable()
                             where p.Field<string>("group") == textBox_Parts.Text.Trim()
                             && p.Field<string>("case_no") == caseNo
                             select p;
            if (changeList.Any())
            {
                DataRow dr = changeList.FirstOrDefault();

                currentEditRow["micro_desc"] = dr["micro_desc"].ToString().Trim();
                currentEditRow["macro_desc"] = dr["macro_desc"].ToString().Trim();
                currentEditRow["micro_name"] = "MICROSCOPIC EXAMINATION:";
                currentEditRow["macro_name"] = "MACROSCOPIC EXAMINATION:";
            }
            else
            {
                if (currentEditRow != null && currentEditRow["case_no"] != null && currentEditRow["case_no"].ToString() != "" && currentEditRow["group"] != null && currentEditRow["group"].ToString() != "")
                {
                    string checkSql = string.Format("SELECT TOP 1 * FROM [bxcy_diag] WHERE case_no = '{0}' and [group] = '{1}' ORDER BY diagnosisId", currentEditRow["case_no"].ToString(), currentEditRow["group"].ToString());
                    DataSet firstBxcy_diagDataSet = new DataSet();
                    SqlDataAdapter firstDataAdapter = DBConn.fetchDataIntoDataSet(checkSql, firstBxcy_diagDataSet, "bxcy_diag");

                    if (firstBxcy_diagDataSet.Tables["bxcy_diag"].Rows.Count > 0)
                    {
                        DataRow mDr = firstBxcy_diagDataSet.Tables["bxcy_diag"].Rows[0];

                        currentEditRow["micro_desc"] = mDr["micro_desc"].ToString().Trim();
                        currentEditRow["macro_desc"] = mDr["macro_desc"].ToString().Trim();
                        currentEditRow["micro_name"] = "MICROSCOPIC EXAMINATION:";
                        currentEditRow["macro_name"] = "MACROSCOPIC EXAMINATION:";
                    }
                }
            }
        }

        private void textBox_Remarks_TextChanged(object sender, EventArgs e)
        {
            var changeList = from p in dt.AsEnumerable()
                             where p.Field<string>("group") == textBox_Parts.Text.Trim()
                             && p.Field<string>("case_no") == caseNo
                             && p.Field<int>("diagnosisId") != int.Parse(textBox_DiagnosisNo.Text.Trim())
                             select p;

            foreach (DataRow dr in changeList)
            {
                dr["macro_desc"] = textBox_Remarks.Text.Trim();
            }
        }

        private void textBox_Remarks_CY_TextChanged(object sender, EventArgs e)
        {
            var changeList = from p in dt.AsEnumerable()
                             where p.Field<string>("group") == textBox_Parts.Text.Trim()
                             && p.Field<string>("case_no") == caseNo
                             && p.Field<int>("diagnosisId") != int.Parse(textBox_DiagnosisNo.Text.Trim())
                             select p;

            foreach (DataRow dr in changeList)
            {
                dr["micro_desc"] = textBox_Remarks_CY.Text.Trim();
            }
        }

        private void comboBox_Description2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var changeList = from p in dt.AsEnumerable()
                             where p.Field<string>("group") == textBox_Parts.Text.Trim()
                             && p.Field<string>("case_no") == caseNo
                             && p.Field<int>("diagnosisId") != int.Parse(textBox_DiagnosisNo.Text.Trim())
                             select p;

            foreach (DataRow dr in changeList)
            {
                dr["micro_name"] = comboBox_Description2.SelectedValue.ToString().Trim();
            }
        }

        private void comboBox_Description_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var changeList = from p in dt.AsEnumerable()
                             where p.Field<string>("group") == textBox_Parts.Text.Trim()
                             && p.Field<string>("case_no") == caseNo
                             && p.Field<int>("diagnosisId") != int.Parse(textBox_DiagnosisNo.Text.Trim())
                             select p;

            foreach (DataRow dr in changeList)
            {
                dr["macro_name"] = comboBox_Description.SelectedValue.ToString().Trim();
            }
        }

        private void button_Delete2_Click(object sender, EventArgs e)
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

        private void button_Copy_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);
            isSameGroupNewRecord = false;
            string newGroup;

            var maxGroupFromProg = (from p in dt.AsEnumerable()
                             where p.Field<string>("case_no") == caseNo
                             select p.Field<string>("group")).Max();

            int intMaxGroupFromProg = Convert.ToInt32(maxGroupFromProg);

            string groupSql = string.Format("SELECT ISNULL(max([group]),0) as maxGroup FROM [bxcy_diag] WHERE case_no='{0}'", caseNo);
            DataSet groupDataSet1 = new DataSet();
            SqlDataAdapter groupDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(groupSql, groupDataSet1, "bxcy_diag");

            DataTable groupDt = groupDataSet1.Tables["bxcy_diag"];
            string strMaxGroup = groupDt.Rows[0]["maxGroup"].ToString();
            int intMaxGroupFromDB = Convert.ToInt32(strMaxGroup);

            if(intMaxGroupFromDB > intMaxGroupFromProg)
            {
                newGroup = (intMaxGroupFromDB + 1).ToString();
            }
            else
            {
                newGroup = (intMaxGroupFromProg + 1).ToString();
            }

            var varGroupList = from p in dt.AsEnumerable()
                             where p.Field<string>("group") == textBox_Parts.Text.Trim()
                             && p.Field<string>("case_no") == caseNo
                             select p;

            List<DataRow> groupList = varGroupList.ToList();

            foreach (DataRow dr in groupList)
            {
                currentEditRow = bxcy_diagDataSet.Tables["bxcy_diag"].NewRow();
                currentEditRow["group"] = newGroup;
                currentEditRow["case_no"] = caseNo;

                currentEditRow["macro_name"] = dr["macro_name"];
                currentEditRow["micro_name"] = dr["micro_name"];
                currentEditRow["micro_desc"] = dr["micro_desc"];
                currentEditRow["macro_desc"] = dr["macro_desc"];
                currentEditRow["macro_pic1"] = dr["macro_pic1"];
                currentEditRow["macro_pic2"] = dr["macro_pic2"];
                currentEditRow["macro_pic3"] = dr["macro_pic3"];
                currentEditRow["macro_pic4"] = dr["macro_pic4"];
                currentEditRow["micro_pic1"] = dr["micro_pic1"];
                currentEditRow["micro_pic2"] = dr["micro_pic2"];
                currentEditRow["micro_pic3"] = dr["micro_pic3"];
                currentEditRow["micro_pic4"] = dr["micro_pic4"];
                currentEditRow["macro_cap1"] = dr["macro_cap1"];
                currentEditRow["macro_cap2"] = dr["macro_cap2"];
                currentEditRow["macro_cap3"] = dr["macro_cap3"];
                currentEditRow["macro_cap4"] = dr["macro_cap4"];
                currentEditRow["micro_cap1"] = dr["micro_cap1"];
                currentEditRow["micro_cap2"] = dr["micro_cap2"];
                currentEditRow["micro_cap3"] = dr["micro_cap3"];
                currentEditRow["micro_cap4"] = dr["micro_cap4"];
                currentEditRow["site"] = dr["site"];
                currentEditRow["Site2"] = dr["Site2"];
                currentEditRow["Operation"] = dr["Operation"];
                currentEditRow["Operation2"] = dr["Operation2"];
                currentEditRow["Diagnosis"] = dr["Diagnosis"];
                currentEditRow["Diag_desc1"] = dr["Diag_desc1"];
                currentEditRow["Diag_desc2"] = dr["Diag_desc2"];
                currentEditRow["seq"] = dr["seq"];
                currentEditRow["diagnosisId"] = dr["diagnosisId"];

                bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Add(currentEditRow);
                bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Remove(dr);
            }

            /*var varGroupListToDelete = from p in bxcy_diagDataSet.Tables["bxcy_diag"].AsEnumerable()
                               where p.Field<string>("group") != newGroup
                               && p.Field<string>("case_no") == caseNo
                               select p;

            List<DataRow> groupListToDelete = varGroupList.ToList();

            foreach (DataRow dr in groupListToDelete)
            {
                bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Remove(dr);
            }*/
        }

        private void comboBox_Diagnosis_1_Validated(object sender, EventArgs e)
        {
            // added by eric 
            string test = comboBox_Diagnosis_1.Text;
            if (test != string.Empty && test != "")
            {
                if (test.Contains("|"))
                {
                    string[] StringArg = test.Split("|".ToCharArray());
                    if (StringArg != null && StringArg.Length == 2)
                    {
                        comboBox_Diagnosis_1.Text = StringArg[1].Trim();
                    }
                    else
                    {
                        String error = "Cannot found matched chinese diagnosis";

                    }

                }
            }
            //MessageBox.Show("Validated " + test);
        }

        private void comboBox_Diagnosis_2_Validated(object sender, EventArgs e)
        {
            // added by eric
            string test = comboBox_Diagnosis_2.Text;
            if (test != string.Empty && test != "")
            {
                if (test.Contains("|"))
                {
                    string[] StringArg = test.Split("|".ToCharArray());
                    if (StringArg != null && StringArg.Length == 2)
                    {
                        comboBox_Diagnosis_2.Text = StringArg[1].Trim();
                    }
                    else
                    {
                        String error = "Cannot found matched chinese diagnosis";

                    }

                }
            }
        }

        private void comboBox_Site_Validated(object sender, EventArgs e)
        {
            DataSet siteResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [site] WHERE site ='{0}'", StringUtil.escapeDBSpecialChar(comboBox_Site.SelectedValue.ToString()));
            DBConn.fetchDataIntoDataSetSelectOnly(sql, siteResultDataSet, "site");

            if (siteResultDataSet.Tables["site"].Rows.Count > 0)
            {
                DataRow mDr = siteResultDataSet.Tables["site"].Rows[0];
                textBox_Chinese_Description_1_DIA.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_Operation_Validated(object sender, EventArgs e)
        {
            DataSet operationResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [operation] WHERE operation ='{0}'", StringUtil.escapeDBSpecialChar(comboBox_Operation.SelectedValue.ToString()));
            DBConn.fetchDataIntoDataSetSelectOnly(sql, operationResultDataSet, "operation");

            if (operationResultDataSet.Tables["operation"].Rows.Count > 0)
            {
                DataRow mDr = operationResultDataSet.Tables["operation"].Rows[0];
                textBox_Chinese_Description_2_DIA.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_Site_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Site.Text == "")
            {
                textBox_Chinese_Description_1_DIA.Text = "";
            }
        }

        private void comboBox_Operation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Operation.Text == "")
            {
                textBox_Chinese_Description_2_DIA.Text = "";
            }
        }

        private void comboBox_Snop_M3_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Diagnosis_1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string c_desc = drv.Row["c_desc"].ToString();
            string e_desc = drv.Row["e_desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 3;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(e_desc, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 3) * 2;
            e.Graphics.DrawString(c_desc, e.Font, sb, r2);
        }

        private void comboBox_Diagnosis_2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string c_desc = drv.Row["c_desc"].ToString();
            string e_desc = drv.Row["e_desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 3;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(e_desc, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 3) * 2;
            e.Graphics.DrawString(c_desc, e.Font, sb, r2);
        }

        private void textBox_Diagnosis_TextChanged(object sender, EventArgs e)
        {

        }

        public void disableEdit()
        {
            button_F6_Edit.Enabled = false;
            button_New.Enabled = false;
            button_Delete.Enabled = false;
        }

        private int getNoOfPhotos()
        {
            int noOfPhotos = 0;

            if (textBox_Picture_File_1.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            if (textBox_Picture_File_2.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            if (textBox_Picture_File_3.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            if (textBox_Picture_File_4.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            if (textBox_Picture_File_5.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            if (textBox_Picture_File_6.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            if (textBox_Picture_File_7.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            if (textBox_Picture_File_8.Text.Trim() != "")
            {
                noOfPhotos++;
            }

            return noOfPhotos;
        }
    }

    
}
