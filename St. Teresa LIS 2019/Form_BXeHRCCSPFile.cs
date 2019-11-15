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
    public partial class Form_BXeHRCCSPFile : Form
    {
        private DataSet bxcy_specimenDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        public static Boolean merge;
        //public CurrencyManager currencyManager;
        private Bxcy_specimenStr copybxcy_specimen;
        private int currentStatus;
        private DataTable dt;
        //private int currentPosition;
        private DataRow currentEditRow;
        private string id;

        private bool isNewPatient = false;

        public class Bxcy_specimen
        {
            public int id { get; set; }
            public string case_no { get; set; }
            public string barcode { get; set; }
            public string ver { get; set; }
            public DateTime? date { get; set; }
            public DateTime? rpt_date { get; set; }
            public string sign_dr { get; set; }
            public string sign_dr2 { get; set; }
            public string client { get; set; }
            public string institute { get; set; }
            public string doctor_id { get; set; }
            public string doctor_ic { get; set; }
            public string doctor_o { get; set; }
            public string lab_ref { get; set; }
            public string ethnic { get; set; }
            public string patient { get; set; }
            public string cname { get; set; }
            public Double? pat_seq { get; set; }
            public DateTime? pat_birth { get; set; }
            public Double? pat_age { get; set; }
            public string pat_sex { get; set; }
            public string pat_hkid { get; set; }
            public string pat_hist { get; set; }
            public string surgical { get; set; }
            public string nature { get; set; }
            public string bed_room { get; set; }
            public string bed_no { get; set; }
            public DateTime? discharge { get; set; }
            public string receipt { get; set; }
            public string inv_no { get; set; }
            public Double? inv_amt { get; set; }
            public DateTime? inv_date { get; set; }
            public DateTime? pay_date { get; set; }
            public bool? fz_section { get; set; }
            public string fz_detail { get; set; }
            public string cy_type { get; set; }
            public string cy_report { get; set; }
            public string snopcode_t { get; set; }
            public string desc_t { get; set; }
            public string snopcode_m { get; set; }
            public string desc_m { get; set; }
            public string er { get; set; }
            public string em { get; set; }
            public string remind { get; set; }
            public string remark { get; set; }
            public string initial { get; set; }
            public Double? priv_case { get; set; }
            public bool? supp { get; set; }
            public string mt { get; set; }
            public string print_by { get; set; }
            public DateTime? print_at { get; set; }
            public Double? print_ctr { get; set; }
            public string issue_by { get; set; }
            public Double? issue_at { get; set; }
            public string update_by { get; set; }
            public DateTime? update_at { get; set; }
            public Double? update_ctr { get; set; }
            public string updated { get; set; }
            public bool? uploaded { get; set; }
            public string snopcode_t2 { get; set; }
            public string desc_t2 { get; set; }
            public string snopcode_t3 { get; set; }
            public string desc_t3 { get; set; }
            public string snopcode_m2 { get; set; }
            public string desc_m2 { get; set; }
            public string snopcode_m3 { get; set; }
            public string desc_m3 { get; set; }
            public string clinical_History { get; set; }
            public string class1 { get; set; }
            public string doctor_ic2 { get; set; }
            public string doctor_id2 { get; set; }
            public string doctor_ic3 { get; set; }
            public string doctor_id3 { get; set; }
            public string histo { get; set; }
            public string cyto_Type { get; set; }
        }

        public class Bxcy_specimenStr
        {
            public int id { get; set; }
            public string case_no { get; set; }
            public string barcode { get; set; }
            public string ver { get; set; }
            public string date { get; set; }
            public string rpt_date { get; set; }
            public string sign_dr { get; set; }
            public string sign_dr2 { get; set; }
            public string client { get; set; }
            public string institute { get; set; }
            public string doctor_id { get; set; }
            public string doctor_ic { get; set; }
            public string doctor_o { get; set; }
            public string lab_ref { get; set; }
            public string ethnic { get; set; }
            public string patient { get; set; }
            public string cname { get; set; }
            public string pat_seq { get; set; }
            public string pat_birth { get; set; }
            public string pat_age { get; set; }
            public string pat_sex { get; set; }
            public string pat_hkid { get; set; }
            public string pat_hist { get; set; }
            public string surgical { get; set; }
            public string nature { get; set; }
            public string bed_room { get; set; }
            public string bed_no { get; set; }
            public string discharge { get; set; }
            public string receipt { get; set; }
            public string inv_no { get; set; }
            public string inv_amt { get; set; }
            public string inv_date { get; set; }
            public string pay_date { get; set; }
            public bool? fz_section { get; set; }
            public string fz_detail { get; set; }
            public string cy_type { get; set; }
            public string cy_report { get; set; }
            public string snopcode_t { get; set; }
            public string desc_t { get; set; }
            public string snopcode_m { get; set; }
            public string desc_m { get; set; }
            public string er { get; set; }
            public string em { get; set; }
            public string remind { get; set; }
            public string remark { get; set; }
            public string initial { get; set; }
            public string priv_case { get; set; }
            public bool? supp { get; set; }
            public string mt { get; set; }
            public string print_by { get; set; }
            public string print_at { get; set; }
            public string print_ctr { get; set; }
            public string issue_by { get; set; }
            public string issue_at { get; set; }
            public string update_by { get; set; }
            public string update_at { get; set; }
            public string update_ctr { get; set; }
            public string updated { get; set; }
            public bool? uploaded { get; set; }
            public string snopcode_t2 { get; set; }
            public string desc_t2 { get; set; }
            public string snopcode_t3 { get; set; }
            public string desc_t3 { get; set; }
            public string snopcode_m2 { get; set; }
            public string desc_m2 { get; set; }
            public string snopcode_m3 { get; set; }
            public string desc_m3 { get; set; }
            public string clinical_History { get; set; }
            public string class1 { get; set; }
            public string doctor_ic2 { get; set; }
            public string doctor_id2 { get; set; }
            public string doctor_ic3 { get; set; }
            public string doctor_id3 { get; set; }
            public string histo { get; set; }
            public string cyto_Type { get; set; }
        }

        public Form_BXeHRCCSPFile()
        {
            InitializeComponent();
        }

        public Form_BXeHRCCSPFile(bool isNewPatient)
        {
            this.isNewPatient = isNewPatient;
            InitializeComponent();
        }

        public Form_BXeHRCCSPFile(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        public void newRecord()
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;
            currentEditRow["DATE"] = DateTime.Now;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);
        }

        public void patientNameCopy(string patientName)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["patient"] = patientName;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;
            currentEditRow["DATE"] = DateTime.Now;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);
        }

        public void patientCopy(string caseNo)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";
            currentEditRow["CLIENT"] = "ST. Teresa's Hospital";
            currentEditRow["Institute"] = "ST. Teresa's Hospital";

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;

            DataSet copyBxcyDataSet = new DataSet();

            string sql = string.Format("SELECT TOP 1 * FROM [bxcy_specimen] WHERE case_no = '{0}'", caseNo);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, copyBxcyDataSet, "bxcy_specimen");

            if (copyBxcyDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
            {
                DataRow mDr = copyBxcyDataSet.Tables["bxcy_specimen"].Rows[0];

                currentEditRow["ETHNIC"] = mDr["ETHNIC"];
                currentEditRow["PATIENT"] = mDr["PATIENT"];
                currentEditRow["PAT_SEQ"] = mDr["PAT_SEQ"];
                currentEditRow["CNAME"] = mDr["CNAME"];
                currentEditRow["PAT_BIRTH"] = mDr["PAT_BIRTH"];
                currentEditRow["PAT_AGE"] = mDr["PAT_AGE"];
                currentEditRow["PAT_SEX"] = mDr["PAT_SEX"];
                currentEditRow["PAT_HKID"] = mDr["PAT_HKID"];
            }

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F5_Description_Click(object sender, EventArgs e)
        {
            bool isNewRecord = currentStatus == PageStatus.STATUS_NEW ? true : false;
            Form_Description open = new Form_Description(textBox_Case_No.Text.Trim(), textBox_ID.Text.Trim(), currentStatus, comboBox_Snop_T1.SelectedValue, comboBox_Snop_T2.SelectedValue, comboBox_Snop_T3.SelectedValue, comboBox_Snop_M1.SelectedValue, comboBox_Snop_M2.SelectedValue, comboBox_Snop_M3.SelectedValue, textBox_Patient.Text.Trim(), textBox_HKID.Text.Trim(), isNewRecord);
            open.OnBxcyDiagExit += OnStatusReturn;
            open.OnBxcyDiagSaveBoth += onBxcyDiagSaveBoth;
            open.Show();
        }

        private void OnStatusReturn(int status, bool refresh)
        {
            if (refresh)
            {
                reloadAndBindingDBData(0, textBox_Case_No.Text.Trim());
            }
            currentStatus = status;
            setButtonStatus(currentStatus);
        }

        private int onBxcyDiagSaveBoth(Object snopT1, Object snopT2, Object snopT3, Object snopM1, Object snopM2, Object snopM3)
        {
            return saveDataWithSnopCode(snopT1, snopT2, snopT3, snopM1, snopM2, snopM3);
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            //currencyManager.Position++;
            string countSql = string.Format(" [bxcy_specimen] WHERE ((case_no = '{0}' and id > {1}) or case_no > '{0}') AND case_no LIKE 'D%'", textBox_Case_No.Text.Trim(), textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE ((case_no = '{0}' and id > {1}) or case_no > '{0}') AND case_no LIKE 'D%' ORDER BY  case_no,id", textBox_Case_No.Text.Trim(), textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");
            }

            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
            setPreviousRecordMark();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            //currencyManager.Position--;
            string countSql = string.Format(" [bxcy_specimen] WHERE ((case_no = '{0}' and id < {1}) or case_no < '{0}') AND case_no LIKE 'D%'", textBox_Case_No.Text.Trim(), textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE ((case_no = '{0}' and id < {1}) or case_no < '{0}') AND case_no LIKE 'D%' ORDER BY case_no DESC,id DESC", textBox_Case_No.Text.Trim(), textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");
            }

            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
            setPreviousRecordMark();
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no LIKE 'D%' ORDER BY case_no,id");
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
            setPreviousRecordMark();
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no LIKE 'D%' ORDER BY case_no DESC,id DESC");
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
            setPreviousRecordMark();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    if (!checkDuplicateHKID())
                    {
                        currentEditRow["ISSUE_BY"] = CurrentUser.currentUserId;
                        currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                        currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
                        {
                            //reloadDBData(currencyManager.Count - 1);
                            reloadAndBindingDBData();
                            button_End.PerformClick();
                            //reloadAndBindingDBData(currencyManager.Count - 1);
                            MessageBox.Show("New ebv_specimen saved");
                        }
                        else
                        {
                            MessageBox.Show("Bxcy_specimen saved fail, please contact Admin");
                        }
                        setButtonStatus(PageStatus.STATUS_VIEW);
                    }
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        //drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
                        {
                            MessageBox.Show("Bxcy_specimen updated");
                        }
                        else
                        {
                            MessageBox.Show("Bxcy_specimen updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    reloadAndBindingDBData();
                }
            }
        }

        private int saveDataWithSnopCode(Object snopT1, Object snopT2, Object snopT3, Object snopM1, Object snopM2, Object snopM3)
        {
            int result = 0;
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    if (!checkDuplicateHKID())
                    {
                        string currentCaseNo = textBox_Case_No.Text.Trim();
                        currentEditRow["ISSUE_BY"] = CurrentUser.currentUserId;
                        currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                        currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");

                        currentEditRow["snopcode_t"] = snopT1;
                        currentEditRow["snopcode_t2"] = snopT2;
                        currentEditRow["snopcode_t3"] = snopT3;
                        currentEditRow["snopcode_m"] = snopM1;
                        currentEditRow["snopcode_m2"] = snopM2;
                        currentEditRow["snopcode_m3"] = snopM3;

                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
                        {
                            //reloadDBData(currencyManager.Count - 1);
                            reloadAndBindingDBData(0, currentCaseNo);
                            button_End.PerformClick();
                        }
                        else
                        {
                            result = 2;
                        }
                        setButtonStatus(PageStatus.STATUS_VIEW);
                    }
                    else
                    {
                        result = 1;
                    }
                }
                
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                string currentCaseNo = textBox_Case_No.Text.Trim();
                DataRow drow = bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Find(textBox_ID.Text);
                if (drow != null)
                {
                    //drow["UPDATE_BY"] = CurrentUser.currentUserId;
                    drow["UPDATE_BY"] = CurrentUser.currentUserId;
                    drow["UPDATE_AT"] = DateTime.Now.ToString("");

                    drow["snopcode_t"] = snopT1;
                    drow["snopcode_t2"] = snopT2;
                    drow["snopcode_t3"] = snopT3;
                    drow["snopcode_m"] = snopM1;
                    drow["snopcode_m2"] = snopM2;
                    drow["snopcode_m3"] = snopM3;

                    textBox_ID.BindingContext[dt].Position++;

                    if (!DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
                    {
                        result = 3;
                    }
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData(0, currentCaseNo);
            }

            return result;
        }

        private bool checkDuplicateHKID()
        {
            bool result = false;

            if (isNewPatient)
            {
                DataSet checkBxcy_specimenDataSet = new DataSet();
                SqlDataAdapter checkdataAdapter;
                string checkSql = string.Format("SELECT * FROM [bxcy_specimen] WHERE patient = '{0}' AND pat_hkid = '{1}'", textBox_Patient.Text.Trim(), textBox_HKID.Text.Trim());
                checkdataAdapter = DBConn.fetchDataIntoDataSet(checkSql, checkBxcy_specimenDataSet, "bxcy_specimen");

                if (checkBxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
                {
                    MessageBox.Show("Duplicate Patient's name and HKID, unable to save");
                    result = true;
                }
            }

            return result;
        }

        public void processEdit()
        {
            button_Edit.PerformClick();
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            //currentEditRow["case_no"] = textBox_Case_No.Text;
            //currentEditRow["date"] = DateTime.ParseExact(textBox_Date.Text, "dd/MM/yyyy", null);
            currentEditRow["ethnic"] = comboBox_Ethnic.Text;
            //currentEditRow["cyto_Type"] = comboBox_cytoType.Text;
            currentEditRow["patient"] = textBox_Patient.Text;
            currentEditRow["pat_seq"] = textBox_PatSeq.Text;
            currentEditRow["cname"] = textBox_Chinese_Name.Text;
            currentEditRow["pat_hkid"] = textBox_HKID.Text;
            currentEditRow["pat_birth"] = DateTime.ParseExact(textBox_DOB.Text, "dd/MM/yyyy", null);
            currentEditRow["class"] = comboBox_Class.Text;
            currentEditRow["pat_age"] = textBox_Age.Text;
            currentEditRow["pat_sex"] = textBox_Sex.Text;
            /*currentEditRow["bed_room"] = textBox_Room.Text;
            currentEditRow["bed_no"] = textBox_Bed.Text;*/
            currentEditRow["clinical_History"] = textBox_Patient_s_Clinical_History.Text;

            currentEditRow["surgical"] = textBox_Surgical.Text;
            currentEditRow["nature"] = textBox_Nature.Text;

            /*currentEditRow["client"] = textBox_Client.Text;
            currentEditRow["institute"] = textBox_Institute.Text;*/
            currentEditRow["lab_ref"] = textBox_Ref_No.Text;
            //currentEditRow["doctor_o"] = textBox_Dr_I_C_Free_Text.Text;

            currentEditRow["doctor_ic"] = textBox_Doctor_I_C.Text;
            currentEditRow["doctor_id"] = textBox_Doctor_I_C_ID_1.Text;

            /*currentEditRow["doctor_id2"] = textBox_Doctor_I_C_2.Text;
            currentEditRow["doctor_id2"] = textBox_Doctor_I_C_ID_2.Text;

            currentEditRow["doctor_id3"] = textBox_Doctor_I_C_3.Text;
            currentEditRow["doctor_id3"] = textBox_Doctor_I_C_ID_3.Text;

            currentEditRow["inv_no"] = textBox_Involce_No.Text;
            currentEditRow["receipt"] = textBox_Receipt.Text;*/
           /* currentEditRow["inv_date"] = DateTime.ParseExact(textBox_Invoice_Date.Text, "dd/MM/yyyy", null);
            currentEditRow["inv_amt"] = textBox_Amount_HK.Text;

            currentEditRow["pay_date"] = DateTime.ParseExact(textBox_Paid_Date.Text, "dd/MM/yyyy", null);*/

            //currentEditRow["rpt_date"] = textBox_Rpt_Date.Text;
            currentEditRow["snopcode_t"] = comboBox_Snop_T1.Text;
            currentEditRow["snopcode_t2"] = comboBox_Snop_T2.Text;
            currentEditRow["snopcode_t3"] = comboBox_Snop_T3.Text;
            //currentEditRow["sign_dr"] = comboBox_Sign_By_Dr_1.Text;
            currentEditRow["snopcode_m"] = comboBox_Snop_M1.Text;
            currentEditRow["snopcode_m2"] = comboBox_Snop_M2.Text;
            currentEditRow["snopcode_m3"] = comboBox_Snop_M3.Text;
            //currentEditRow["sign_dr2"] = comboBox_Sign_By_Dr_2.Text;
            //currentEditRow["histo"] = comboBox_HistoType.Text;

            //currentEditRow["remark"] = textBox_Remarks.Text;
            currentEditRow["initial"] = textBox_Cytology.Text;
            currentEditRow["uploaded"] = checkBox_Uploaded.Checked;
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copybxcy_specimen = new Bxcy_specimenStr();
            copybxcy_specimen.case_no = textBox_Case_No.Text;
            //copybxcy_specimen.date = textBox_Date.Text;
            copybxcy_specimen.ethnic = comboBox_Ethnic.Text;
            //copybxcy_specimen.cyto_Type = comboBox_cytoType.Text;
            copybxcy_specimen.patient = textBox_Patient.Text;
            copybxcy_specimen.pat_seq = textBox_PatSeq.Text;
            copybxcy_specimen.cname = textBox_Chinese_Name.Text;
            copybxcy_specimen.pat_hkid = textBox_HKID.Text;
            copybxcy_specimen.pat_birth = textBox_DOB.Text;
            copybxcy_specimen.class1 = comboBox_Class.Text;
            copybxcy_specimen.pat_age = textBox_Age.Text;
            copybxcy_specimen.pat_sex = textBox_Sex.Text;
            copybxcy_specimen.bed_room = textBox_Organization.Text;
            copybxcy_specimen.pat_hist = textBox_Patient_s_Clinical_History.Text;
            //copybxcy_specimen.clinical_History = textBox_Patient_s_Clinical_History.Text;

            copybxcy_specimen.surgical = textBox_Surgical.Text;
            copybxcy_specimen.nature = textBox_Nature.Text;

            copybxcy_specimen.client = textBox_LabHCIName.Text;
            copybxcy_specimen.institute = textBox_LabHCIID.Text;
            copybxcy_specimen.lab_ref = textBox_Ref_No.Text;
            copybxcy_specimen.doctor_o = textBox_STH_Patient_No.Text;

            copybxcy_specimen.doctor_ic = textBox_Doctor_I_C.Text;
            copybxcy_specimen.doctor_id = textBox_Doctor_I_C_ID_1.Text;

            copybxcy_specimen.inv_no = textBox_LabHCIID_2.Text;
            copybxcy_specimen.remind = textBox_eHR_No.Text;
            copybxcy_specimen.receipt = textBox_Record_Key.Text;
            copybxcy_specimen.inv_date = textBox_Date_Requested.Text;

            copybxcy_specimen.rpt_date = textBox_Rpt_Date.Text;
            copybxcy_specimen.snopcode_t = comboBox_Snop_T1.Text;
            copybxcy_specimen.snopcode_t2 = comboBox_Snop_T2.Text;
            copybxcy_specimen.snopcode_t3 = comboBox_Snop_T3.Text;
            copybxcy_specimen.sign_dr = comboBox_Sign_By_Dr_1.Text;
            copybxcy_specimen.snopcode_m = comboBox_Snop_M1.Text;
            copybxcy_specimen.snopcode_m2 = comboBox_Snop_M2.Text;
            copybxcy_specimen.snopcode_m3 = comboBox_Snop_M3.Text;
            copybxcy_specimen.sign_dr2 = comboBox_Sign_By_Dr_2.Text;
            //copybxcy_specimen.histo = comboBox_HistoType.Text;

            copybxcy_specimen.uploaded = checkBox_Uploaded.Checked;

            copybxcy_specimen.remark = textBox_Remarks.Text;
            copybxcy_specimen.initial = textBox_Cytology.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Advance_Click(object sender, EventArgs e)
        {
            Form_Authorization open = new Form_Authorization();
            open.OnAuthorizationPass += OnAuthorizeDone;
            open.Show();
        }

        private void OnAuthorizeDone(bool authorizationResult)
        {
            if (authorizationResult)
            {
                copybxcy_specimen = new Bxcy_specimenStr();
                copybxcy_specimen.case_no = textBox_Case_No.Text;
                //copybxcy_specimen.date = textBox_Date.Text;
                copybxcy_specimen.ethnic = comboBox_Ethnic.Text;
                //copybxcy_specimen.cyto_Type = comboBox_cytoType.Text;
                copybxcy_specimen.patient = textBox_Patient.Text;
                copybxcy_specimen.pat_seq = textBox_PatSeq.Text;
                copybxcy_specimen.cname = textBox_Chinese_Name.Text;
                copybxcy_specimen.pat_hkid = textBox_HKID.Text;
                copybxcy_specimen.pat_birth = textBox_DOB.Text;
                copybxcy_specimen.class1 = comboBox_Class.Text;
                copybxcy_specimen.pat_age = textBox_Age.Text;
                copybxcy_specimen.pat_sex = textBox_Sex.Text;
                copybxcy_specimen.bed_room = textBox_Organization.Text;
                copybxcy_specimen.pat_hist = textBox_Patient_s_Clinical_History.Text;
                //copybxcy_specimen.clinical_History = textBox_Patient_s_Clinical_History.Text;

                copybxcy_specimen.surgical = textBox_Surgical.Text;
                copybxcy_specimen.nature = textBox_Nature.Text;

                copybxcy_specimen.client = textBox_LabHCIName.Text;
                copybxcy_specimen.institute = textBox_LabHCIID.Text;
                copybxcy_specimen.lab_ref = textBox_Ref_No.Text;
                copybxcy_specimen.doctor_o = textBox_STH_Patient_No.Text;

                copybxcy_specimen.doctor_ic = textBox_Doctor_I_C.Text;
                copybxcy_specimen.doctor_id = textBox_Doctor_I_C_ID_1.Text;

                copybxcy_specimen.inv_no = textBox_LabHCIID_2.Text;
                copybxcy_specimen.remind = textBox_eHR_No.Text;
                copybxcy_specimen.receipt = textBox_Record_Key.Text;
                copybxcy_specimen.inv_date = textBox_Date_Requested.Text;

                copybxcy_specimen.rpt_date = textBox_Rpt_Date.Text;
                copybxcy_specimen.snopcode_t = comboBox_Snop_T1.Text;
                copybxcy_specimen.snopcode_t2 = comboBox_Snop_T2.Text;
                copybxcy_specimen.snopcode_t3 = comboBox_Snop_T3.Text;
                copybxcy_specimen.sign_dr = comboBox_Sign_By_Dr_1.Text;
                copybxcy_specimen.snopcode_m = comboBox_Snop_M1.Text;
                copybxcy_specimen.snopcode_m2 = comboBox_Snop_M2.Text;
                copybxcy_specimen.snopcode_m3 = comboBox_Snop_M3.Text;
                copybxcy_specimen.sign_dr2 = comboBox_Sign_By_Dr_2.Text;
                //copybxcy_specimen.histo = comboBox_HistoType.Text;

                copybxcy_specimen.uploaded = checkBox_Uploaded.Checked;

                copybxcy_specimen.remark = textBox_Remarks.Text;
                copybxcy_specimen.initial = textBox_Cytology.Text;

                setButtonStatus(PageStatus.STATUS_ADVANCE_EDIT);
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {

        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT || currentStatus == PageStatus.STATUS_ADVANCE_EDIT)
                {
                    if (copybxcy_specimen != null)
                    {
                        //textBox_ID.Text = copybxcy_specimen.id;
                        textBox_Case_No.Text = copybxcy_specimen.case_no;
                        //textBox_Date.Text = copybxcy_specimen.date;
                        comboBox_Ethnic.Text = copybxcy_specimen.ethnic;
                        //comboBox_cytoType.Text = copybxcy_specimen.cyto_Type;
                        textBox_Patient.Text = copybxcy_specimen.patient;
                        textBox_PatSeq.Text = copybxcy_specimen.pat_seq;
                        textBox_Chinese_Name.Text = copybxcy_specimen.cname;
                        textBox_HKID.Text = copybxcy_specimen.pat_hkid;
                        textBox_DOB.Text = copybxcy_specimen.pat_birth;
                        comboBox_Class.Text = copybxcy_specimen.class1;
                        textBox_Age.Text = copybxcy_specimen.pat_age;
                        textBox_Sex.Text = copybxcy_specimen.pat_sex;
                        textBox_Organization.Text = copybxcy_specimen.bed_room;
                        textBox_Patient_s_Clinical_History.Text = copybxcy_specimen.pat_hist;
                        //textBox_Patient_s_Clinical_History.Text = copybxcy_specimen.clinical_History;

                        textBox_Surgical.Text = copybxcy_specimen.surgical;
                        textBox_Nature.Text = copybxcy_specimen.nature;

                        textBox_LabHCIName.Text = copybxcy_specimen.client;
                        textBox_LabHCIID.Text = copybxcy_specimen.institute;
                        textBox_Ref_No.Text = copybxcy_specimen.lab_ref;
                        textBox_STH_Patient_No.Text = copybxcy_specimen.doctor_o;

                        textBox_Doctor_I_C.Text = copybxcy_specimen.doctor_ic;
                        textBox_Doctor_I_C_ID_1.Text = copybxcy_specimen.doctor_id;

                        textBox_LabHCIID_2.Text = copybxcy_specimen.inv_no;
                        textBox_eHR_No.Text = copybxcy_specimen.remind;
                        textBox_Record_Key.Text = copybxcy_specimen.receipt;
                        textBox_Date_Requested.Text = copybxcy_specimen.inv_date;

                        textBox_Rpt_Date.Text = copybxcy_specimen.rpt_date;
                        comboBox_Snop_T1.Text = copybxcy_specimen.snopcode_t;
                        comboBox_Snop_T2.Text = copybxcy_specimen.snopcode_t2;
                        comboBox_Snop_T3.Text = copybxcy_specimen.snopcode_t3;
                        comboBox_Sign_By_Dr_1.Text = copybxcy_specimen.sign_dr;
                        comboBox_Snop_M1.Text = copybxcy_specimen.snopcode_m;
                        comboBox_Snop_M2.Text = copybxcy_specimen.snopcode_m2;
                        comboBox_Snop_M3.Text = copybxcy_specimen.snopcode_m3;
                        comboBox_Sign_By_Dr_2.Text = copybxcy_specimen.sign_dr2;
                        //comboBox_HistoType.Text = copybxcy_specimen.histo;

                        textBox_Remarks.Text = copybxcy_specimen.remark;
                        textBox_Cytology.Text = copybxcy_specimen.initial;

                        checkBox_Uploaded.Checked = copybxcy_specimen.uploaded.HasValue ? copybxcy_specimen.uploaded.HasValue : false;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_Label_Click(object sender, EventArgs e)
        {

        }

        private void Form_BXeHRCCSPFile_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void reloadAndBindingDBData(int position = 0, string caseNo = null)
        {
            string sql = "SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no LIKE 'D%' ORDER BY case_no,id";
            if (this.id != null)
            {
                sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE id={0} AND case_no LIKE 'D%' ORDER BY  case_no,id", this.id);
                id = null;
            }
            else
            {
                if (caseNo != null)
                {
                    sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no='{0}' AND case_no LIKE 'D%' ORDER BY  case_no,id", caseNo);
                }
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

            textBox_ID.DataBindings.Clear();
            textBox_Case_No.DataBindings.Clear();
            textBox_Date_Received.DataBindings.Clear();
            comboBox_Ethnic.DataBindings.Clear();
            //comboBox_cytoType.DataBindings.Clear();
            textBox_Patient.DataBindings.Clear();
            textBox_PatSeq.DataBindings.Clear();
            textBox_Chinese_Name.DataBindings.Clear();
            textBox_HKID.DataBindings.Clear();
            textBox_DOB.DataBindings.Clear();
            //comboBox_Class.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            textBox_Organization.DataBindings.Clear();
            textBox_Patient_s_Clinical_History.DataBindings.Clear();
            //textBox_Bed.DataBindings.Clear();
            //textBox_Patient_s_Clinical_History.DataBindings.Clear();

            //textBox_Surgical.DataBindings.Clear();
            textBox_Nature.DataBindings.Clear();

            textBox_LabHCIName.DataBindings.Clear();
            textBox_LabHCIID.DataBindings.Clear();
            textBox_Ref_No.DataBindings.Clear();
            textBox_STH_Patient_No.DataBindings.Clear();

            textBox_Doctor_I_C.DataBindings.Clear();
            textBox_Doctor_I_C_ID_1.DataBindings.Clear();

            textBox_LabHCIID_2.DataBindings.Clear();
            textBox_eHR_No.DataBindings.Clear();
            textBox_Record_Key.DataBindings.Clear();
            textBox_Date_Requested.DataBindings.Clear();

            textBox_Rpt_Date.DataBindings.Clear();
            comboBox_Snop_T1.DataBindings.Clear();
            comboBox_Snop_T2.DataBindings.Clear();
            comboBox_Snop_T3.DataBindings.Clear();
            comboBox_Sign_By_Dr_1.DataBindings.Clear();
            comboBox_Snop_M1.DataBindings.Clear();
            comboBox_Snop_M2.DataBindings.Clear();
            comboBox_Snop_M3.DataBindings.Clear();
            comboBox_Sign_By_Dr_2.DataBindings.Clear();
            //comboBox_HistoType.DataBindings.Clear();

            textBox_Remarks.DataBindings.Clear();
            textBox_Cytology.DataBindings.Clear();

            textBox_Updated_By_1.DataBindings.Clear();
            textBox_Updated_At.DataBindings.Clear();
            textBox_Issued_By.DataBindings.Clear();
            textBox_Issued_At.DataBindings.Clear();
            //textBox_Rpt_Date.DataBindings.Clear();

            label_Printed.DataBindings.Clear();

            dt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            DataTable cytoTypeDt = new DataTable();
            cytoTypeDt.Columns.Add("cytoType");
            cytoTypeDt.Rows.Add(new object[] { "G" });
            cytoTypeDt.Rows.Add(new object[] { "F" });
            cytoTypeDt.Rows.Add(new object[] { "N" });
            cytoTypeDt.Rows.Add(new object[] { "HS" });
            cytoTypeDt.Rows.Add(new object[] { "HQ" });

            label_Printed.DataBindings.Clear();

            checkBox_Uploaded.DataBindings.Clear();

            /*label_Uploaded_At.DataBindings.Clear();
            label_Uploaded_By.DataBindings.Clear();*/
            label_Version.DataBindings.Clear();

            label_Print_At.DataBindings.Clear();
            label_Print_By.DataBindings.Clear();

            //comboBox_cytoType.DataSource = cytoTypeDt;

            /*DataTable classDt = new DataTable();
            classDt.Columns.Add("classValue");
            classDt.Rows.Add(new object[] { "classValue1" });
            classDt.Rows.Add(new object[] { "classValue2" });
            classDt.Rows.Add(new object[] { "classValue3" });

            comboBox_Class.DataSource = classDt;*/

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

            string ethnicSql = "SELECT PEOPLE FROM [ethnic]";
            DataSet ethnicDataSet = new DataSet();
            SqlDataAdapter ethnicDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(ethnicSql, ethnicDataSet, "ethnic");

            DataTable ethnicDt = new DataTable();
            ethnicDt.Columns.Add("PEOPLE");

            foreach (DataRow mDr in ethnicDataSet.Tables["ethnic"].Rows)
            {
                ethnicDt.Rows.Add(new object[] { mDr["PEOPLE"] });
            }

            comboBox_Ethnic.DataSource = ethnicDt;

            string doctorSql = "SELECT doctor FROM [doctor]";
            DataSet doctorDataSet = new DataSet();
            SqlDataAdapter doctorDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql, doctorDataSet, "doctor");

            DataTable doctorDt1 = new DataTable();
            doctorDt1.Columns.Add("doctor");
            DataTable doctorDt2 = doctorDt1.Clone();

            foreach (DataRow mDr in doctorDataSet.Tables["doctor"].Rows)
            {
                doctorDt1.Rows.Add(new object[] { mDr["doctor"] });
                doctorDt2.Rows.Add(new object[] { mDr["doctor"] });
            }

            comboBox_Sign_By_Dr_1.DataSource = doctorDt1;
            comboBox_Sign_By_Dr_2.DataSource = doctorDt2;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Case_No.DataBindings.Add("Text", dt, "CASE_NO", false);
            textBox_Date_Received.DataBindings.Add("Text", dt, "DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            comboBox_Ethnic.DataBindings.Add("SelectedValue", dt, "ETHNIC", false);
            //comboBox_cytoType.DataBindings.Add("SelectedValue", dt, "Cyto_Type", false);
            textBox_Patient.DataBindings.Add("Text", dt, "PATIENT", false);
            textBox_PatSeq.DataBindings.Add("Text", dt, "PAT_SEQ", false);
            textBox_Chinese_Name.DataBindings.Add("Text", dt, "CNAME", false);
            textBox_HKID.DataBindings.Add("Text", dt, "PAT_HKID", false);
            textBox_DOB.DataBindings.Add("Text", dt, "PAT_BIRTH", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            //comboBox_Class.DataBindings.Add("SelectedValue", dt, "Class", false);
            textBox_Age.DataBindings.Add("Text", dt, "PAT_AGE", false);
            textBox_Sex.DataBindings.Add("Text", dt, "PAT_SEX", false);
            textBox_Organization.DataBindings.Add("Text", dt, "BED_ROOM", false);
            textBox_Patient_s_Clinical_History.DataBindings.Add("Text", dt, "Pat_hist", false);
            //textBox_Bed.DataBindings.Add("Text", dt, "BED_NO", false);
            //textBox_Patient_s_Clinical_History.DataBindings.Add("Text", dt, "Clinical_History", false);

            //textBox_Surgical.DataBindings.Add("Text", dt, "surgical", false, DataSourceUpdateMode.OnPropertyChanged, "");
            textBox_Nature.DataBindings.Add("Text", dt, "nature", false, DataSourceUpdateMode.OnPropertyChanged, "");

            textBox_LabHCIName.DataBindings.Add("Text", dt, "CLIENT", false);
            textBox_LabHCIID.DataBindings.Add("Text", dt, "Institute", false);
            textBox_Ref_No.DataBindings.Add("Text", dt, "LAB_REF", false);
            textBox_STH_Patient_No.DataBindings.Add("Text", dt, "DOCTOR_O", false);

            textBox_Doctor_I_C.DataBindings.Add("Text", dt, "DOCTOR_IC", false);
            textBox_Doctor_I_C_ID_1.DataBindings.Add("Text", dt, "doctor_id", false);

            textBox_LabHCIID_2.DataBindings.Add("Text", dt, "Inv_no", false);
            textBox_eHR_No.DataBindings.Add("Text", dt, "Remind", false);
            textBox_Record_Key.DataBindings.Add("Text", dt, "RECEIPT", false);
            textBox_Date_Requested.DataBindings.Add("Text", dt, "INV_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");

            textBox_Rpt_Date.DataBindings.Add("Text", dt, "Rpt_date", false);
            comboBox_Snop_T1.DataBindings.Add("SelectedValue", dt, "snopcode_t", false);
            comboBox_Snop_T2.DataBindings.Add("SelectedValue", dt, "snopcode_t2", false);
            comboBox_Snop_T3.DataBindings.Add("SelectedValue", dt, "snopcode_t3", false);
            comboBox_Sign_By_Dr_1.DataBindings.Add("SelectedValue", dt, "Sign_dr", false);
            comboBox_Snop_M1.DataBindings.Add("SelectedValue", dt, "Snopcode_m", false);
            comboBox_Snop_M2.DataBindings.Add("SelectedValue", dt, "Snopcode_m2", false);
            comboBox_Snop_M3.DataBindings.Add("SelectedValue", dt, "Snopcode_m3", false);
            comboBox_Sign_By_Dr_2.DataBindings.Add("SelectedValue", dt, "Sign_dr2", false);
            //comboBox_HistoType.DataBindings.Add("SelectedValue", dt, "Histo", false);

            textBox_Remarks.DataBindings.Add("Text", dt, "Remark", false);
            textBox_Cytology.DataBindings.Add("Text", dt, "initial", false);

            textBox_Updated_By_1.DataBindings.Add("Text", dt, "update_by", false);
            textBox_Updated_At.DataBindings.Add("Text", dt, "update_at", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            textBox_Issued_By.DataBindings.Add("Text", dt, "issue_by", false);
            textBox_Issued_At.DataBindings.Add("Text", dt, "issue_at", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            //textBox_Rpt_Date.DataBindings.Add("Text", dt, "rpt_date", false);
            label_Printed.DataBindings.Add("Text", dt, "print_ctr", false);

            checkBox_Uploaded.DataBindings.Add("Checked", dt, "uploaded", false);

            /*label_Uploaded_At.DataBindings.Add("Text", dt, "update_at", false);
            label_Uploaded_By.DataBindings.Add("Text", dt, "update_by", false);*/
            label_Version.DataBindings.Add("Text", dt, "update_ctr", false);

            label_Print_At.DataBindings.Add("Text", dt, "print_at", false);
            label_Print_By.DataBindings.Add("Text", dt, "print_by", false);

            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());

            setPreviousRecordMark();
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [BXCY_SPECIMEN] ORDER BY  case_no,id";
            DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

            DataTable dt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;
            /*currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;*/
        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;

            if (status == PageStatus.STATUS_VIEW)
            {
                button_Top.Enabled = true;
                button_Back.Enabled = true;
                button_Next.Enabled = true;
                button_End.Enabled = true;
                button_Save.Enabled = false;
                button_New.Enabled = true;
                button_Edit.Enabled = true;
                button_Delete.Enabled = true;
                button_Undo.Enabled = false;
                button_Exit.Enabled = true;

                button_F1.Enabled = false;
                button_F7.Enabled = false;
                //button_F8.Enabled = false;
                button_F9.Enabled = false;
                //button_F3_Surgical.Enabled = true;
                button_F4_Nature.Enabled = true;

                textBox_Case_No.Enabled = false;
                //textBox_Date.Enabled = false;
                comboBox_Ethnic.Enabled = false;
                //comboBox_cytoType.Enabled = false;
                textBox_Patient.Enabled = false;
                textBox_PatSeq.Enabled = false;
                textBox_Chinese_Name.Enabled = false;
                textBox_HKID.Enabled = false;
                textBox_DOB.Enabled = false;
                //comboBox_Class.Enabled = false;
                textBox_Age.Enabled = false;
                textBox_Sex.Enabled = false;
                //textBox_Room.Enabled = false;
                //textBox_Bed.Enabled = false;
                textBox_Patient_s_Clinical_History.Enabled = false;

                //textBox_Client.Enabled = false;
                //textBox_Institute.Enabled = false;
                textBox_Ref_No.Enabled = false;
                //textBox_Dr_I_C_Free_Text.Enabled = false;
                textBox_Doctor_I_C.Enabled = false;
                textBox_Doctor_I_C_ID_1.Enabled = false;
                //textBox_Doctor_I_C_2.Enabled = false;
                /*textBox_Doctor_I_C_ID_2.Enabled = false;
                textBox_Doctor_I_C_3.Enabled = false;
                textBox_Doctor_I_C_ID_3.Enabled = false;*/

                //textBox_Involce_No.Enabled = false;
                //textBox_Receipt.Enabled = false;
                /*textBox_Invoice_Date.Enabled = false;
                textBox_Amount_HK.Enabled = false;
                textBox_Paid_Up.Enabled = false;
                textBox_Paid_Date.Enabled = false;*/

                textBox_Rpt_Date.Enabled = false;
                comboBox_Snop_T1.Enabled = false;
                comboBox_Snop_T2.Enabled = false;
                comboBox_Snop_T3.Enabled = false;
                comboBox_Sign_By_Dr_1.Enabled = false;
                comboBox_Snop_M1.Enabled = false;
                comboBox_Snop_M2.Enabled = false;
                comboBox_Snop_M3.Enabled = false;
                comboBox_Sign_By_Dr_2.Enabled = false;
                //comboBox_HistoType.Enabled = false;

                textBox_Remarks.Enabled = false;
                textBox_Cytology.Enabled = false;

                label_New_Record.Visible = false;

                /*button_Shif.Enabled = false;
                button_F9_2.Enabled = false;
                button_Shif_2.Enabled = false;
                button_Shif_3.Enabled = false;
                button3.Enabled = false;
                button_F9_3.Enabled = false;*/
                button_Advance.Enabled = true;

                button_Rpt_Date_Tick.Enabled = false;
                //checkBox_Uploaded.Enabled = false;

                disedit_modle();
            }
            else
            {
                if (status == PageStatus.STATUS_NEW)
                {
                    button_Top.Enabled = false;
                    button_Back.Enabled = false;
                    button_Next.Enabled = false;
                    button_End.Enabled = false;
                    button_Save.Enabled = true;
                    button_New.Enabled = false;
                    button_Edit.Enabled = false;
                    button_Delete.Enabled = false;
                    button_Undo.Enabled = true;
                    button_Exit.Enabled = false;

                    button_F1.Enabled = true;
                    button_F7.Enabled = true;
                    //button_F8.Enabled = true;
                    button_F9.Enabled = true;
                    //button_F3_Surgical.Enabled = true;
                    button_F4_Nature.Enabled = true;

                    textBox_Case_No.Enabled = true;
                    //textBox_Date.Enabled = true;
                    comboBox_Ethnic.Enabled = true;
                    //comboBox_cytoType.Enabled = true;
                    textBox_Patient.Enabled = true;
                    textBox_PatSeq.Enabled = true;
                    textBox_Chinese_Name.Enabled = true;
                    textBox_HKID.Enabled = true;
                    textBox_DOB.Enabled = true;
                    //comboBox_Class.Enabled = true;
                    textBox_Age.Enabled = true;
                    textBox_Sex.Enabled = true;
                    /*textBox_Room.Enabled = true;
                    textBox_Bed.Enabled = true;*/
                    textBox_Patient_s_Clinical_History.Enabled = true;

                    /*textBox_Client.Enabled = true;
                    textBox_Institute.Enabled = true;*/
                    textBox_Ref_No.Enabled = true;
                    //textBox_Dr_I_C_Free_Text.Enabled = true;
                    textBox_Doctor_I_C.Enabled = true;
                    textBox_Doctor_I_C_ID_1.Enabled = true;
                    //textBox_Doctor_I_C_2.Enabled = true;
                    /*textBox_Doctor_I_C_ID_2.Enabled = true;
                    textBox_Doctor_I_C_3.Enabled = true;
                    textBox_Doctor_I_C_ID_3.Enabled = true;*/

                    //textBox_Involce_No.Enabled = true;
                    //textBox_Receipt.Enabled = true;
                    /*textBox_Invoice_Date.Enabled = true;
                    textBox_Amount_HK.Enabled = true;
                    textBox_Paid_Up.Enabled = true;
                    textBox_Paid_Date.Enabled = true;*/

                    textBox_Rpt_Date.Enabled = true;
                    comboBox_Snop_T1.Enabled = true;
                    comboBox_Snop_T2.Enabled = true;
                    comboBox_Snop_T3.Enabled = true;
                    comboBox_Sign_By_Dr_1.Enabled = true;
                    comboBox_Snop_M1.Enabled = true;
                    comboBox_Snop_M2.Enabled = true;
                    comboBox_Snop_M3.Enabled = true;
                    comboBox_Sign_By_Dr_2.Enabled = true;
                    //comboBox_HistoType.Enabled = true;

                    textBox_Remarks.Enabled = true;
                    textBox_Cytology.Enabled = true;

                    label_New_Record.Text = "<New Record>";
                    label_New_Record.Visible = true;

                    /*button_Shif.Enabled = true;
                    button_F9_2.Enabled = true;
                    button_Shif_2.Enabled = true;
                    button_Shif_3.Enabled = true;
                    button3.Enabled = true;
                    button_F9_3.Enabled = true;*/
                    button_Advance.Enabled = false;

                    button_Rpt_Date_Tick.Enabled = true;
                    //checkBox_Uploaded.Enabled = true;

                    edit_modle();
                }
                else
                {
                    if (status == PageStatus.STATUS_EDIT)
                    {
                        button_Top.Enabled = false;
                        button_Back.Enabled = false;
                        button_Next.Enabled = false;
                        button_End.Enabled = false;
                        button_Save.Enabled = true;
                        button_New.Enabled = false;
                        button_Edit.Enabled = false;
                        button_Delete.Enabled = false;
                        button_Undo.Enabled = true;
                        button_Exit.Enabled = false;

                        button_F1.Enabled = false;
                        button_F7.Enabled = false;
                        //button_F8.Enabled = false;
                        button_F9.Enabled = false;
                        //button_F3_Surgical.Enabled = true;
                        button_F4_Nature.Enabled = true;

                        textBox_Case_No.Enabled = true;
                        //textBox_Date.Enabled = true;
                        comboBox_Ethnic.Enabled = true;
                        //comboBox_cytoType.Enabled = true;
                        textBox_Patient.Enabled = true;
                        textBox_PatSeq.Enabled = true;
                        textBox_Chinese_Name.Enabled = true;
                        textBox_HKID.Enabled = true;
                        textBox_DOB.Enabled = true;
                        //comboBox_Class.Enabled = true;
                        textBox_Age.Enabled = true;
                        textBox_Sex.Enabled = true;
                        /*textBox_Room.Enabled = true;
                        textBox_Bed.Enabled = true;*/
                        textBox_Patient_s_Clinical_History.Enabled = true;

                        /*textBox_Client.Enabled = true;
                        textBox_Institute.Enabled = true;*/
                        textBox_Ref_No.Enabled = true;
                        //textBox_Dr_I_C_Free_Text.Enabled = true;
                        textBox_Doctor_I_C.Enabled = true;
                        textBox_Doctor_I_C_ID_1.Enabled = true;
                        //textBox_Doctor_I_C_2.Enabled = true;
                        /*textBox_Doctor_I_C_ID_2.Enabled = true;
                        textBox_Doctor_I_C_3.Enabled = true;
                        textBox_Doctor_I_C_ID_3.Enabled = true;*/

                        //textBox_Involce_No.Enabled = true;
                        //textBox_Receipt.Enabled = true;
                        /*textBox_Invoice_Date.Enabled = true;
                        textBox_Amount_HK.Enabled = true;
                        textBox_Paid_Up.Enabled = true;
                        textBox_Paid_Date.Enabled = true;*/

                        textBox_Rpt_Date.Enabled = true;
                        comboBox_Snop_T1.Enabled = true;
                        comboBox_Snop_T2.Enabled = true;
                        comboBox_Snop_T3.Enabled = true;
                        comboBox_Sign_By_Dr_1.Enabled = true;
                        comboBox_Snop_M1.Enabled = true;
                        comboBox_Snop_M2.Enabled = true;
                        comboBox_Snop_M3.Enabled = true;
                        comboBox_Sign_By_Dr_2.Enabled = true;
                        //comboBox_HistoType.Enabled = true;

                        textBox_Remarks.Enabled = true;
                        textBox_Cytology.Enabled = true;

                        label_New_Record.Text = "<Edit Record>";
                        label_New_Record.Visible = true;

                        /*button_Shif.Enabled = true;
                        button_F9_2.Enabled = true;
                        button_Shif_2.Enabled = true;
                        button_Shif_3.Enabled = true;
                        button3.Enabled = true;
                        button_F9_3.Enabled = true;*/
                        button_Advance.Enabled = false;

                        button_Rpt_Date_Tick.Enabled = true;
                        //checkBox_Uploaded.Enabled = true;

                        edit_modle();
                    }
                    else
                    {
                        if (status == PageStatus.STATUS_ADVANCE_EDIT)
                        {
                            button_Top.Enabled = false;
                            button_Back.Enabled = false;
                            button_Next.Enabled = false;
                            button_End.Enabled = false;
                            button_Save.Enabled = true;
                            button_New.Enabled = false;
                            button_Edit.Enabled = false;
                            button_Delete.Enabled = false;
                            button_Undo.Enabled = true;
                            button_Exit.Enabled = false;

                            button_F1.Enabled = true;
                            button_F7.Enabled = true;
                            //button_F8.Enabled = true;
                            button_F9.Enabled = true;
                            //button_F3_Surgical.Enabled = true;
                            button_F4_Nature.Enabled = true;

                            textBox_Case_No.Enabled = true;
                            //textBox_Date.Enabled = true;
                            comboBox_Ethnic.Enabled = true;
                            //comboBox_cytoType.Enabled = true;
                            textBox_Patient.Enabled = true;
                            textBox_PatSeq.Enabled = true;
                            textBox_Chinese_Name.Enabled = true;
                            textBox_HKID.Enabled = true;
                            textBox_DOB.Enabled = true;
                            //comboBox_Class.Enabled = true;
                            textBox_Age.Enabled = true;
                            textBox_Sex.Enabled = true;
                            /*textBox_Room.Enabled = true;
                            textBox_Bed.Enabled = true;*/
                            textBox_Patient_s_Clinical_History.Enabled = true;

                            /*textBox_Client.Enabled = true;
                            textBox_Institute.Enabled = true;*/
                            textBox_Ref_No.Enabled = true;
                            //textBox_Dr_I_C_Free_Text.Enabled = true;
                            textBox_Doctor_I_C.Enabled = true;
                            textBox_Doctor_I_C_ID_1.Enabled = true;
                            //textBox_Doctor_I_C_2.Enabled = true;
                            /*textBox_Doctor_I_C_ID_2.Enabled = true;
                            textBox_Doctor_I_C_3.Enabled = true;
                            textBox_Doctor_I_C_ID_3.Enabled = true;*/

                            //textBox_Involce_No.Enabled = true;
                            //textBox_Receipt.Enabled = true;
                            /*textBox_Invoice_Date.Enabled = true;
                            textBox_Amount_HK.Enabled = true;
                            textBox_Paid_Up.Enabled = true;
                            textBox_Paid_Date.Enabled = true;*/

                            textBox_Rpt_Date.Enabled = true;
                            comboBox_Snop_T1.Enabled = true;
                            comboBox_Snop_T2.Enabled = true;
                            comboBox_Snop_T3.Enabled = true;
                            comboBox_Sign_By_Dr_1.Enabled = true;
                            comboBox_Snop_M1.Enabled = true;
                            comboBox_Snop_M2.Enabled = true;
                            comboBox_Snop_M3.Enabled = true;
                            comboBox_Sign_By_Dr_2.Enabled = true;
                            //comboBox_HistoType.Enabled = true;

                            textBox_Remarks.Enabled = true;
                            textBox_Cytology.Enabled = true;

                            label_New_Record.Text = "<Edit Record>";
                            label_New_Record.Visible = true;

                            /*button_Shif.Enabled = true;
                            button_F9_2.Enabled = true;
                            button_Shif_2.Enabled = true;
                            button_Shif_3.Enabled = true;
                            button3.Enabled = true;
                            button_F9_3.Enabled = true;*/
                            button_Advance.Enabled = false;

                            button_Rpt_Date_Tick.Enabled = true;
                            //checkBox_Uploaded.Enabled = true;

                            edit_modle();
                        }
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
            button_Edit.Image = Image.FromFile("Resources/editGra.png");
            button_Edit.ForeColor = Color.Gray;
            button_Delete.Image = Image.FromFile("Resources/deleteGra.png");
            button_Delete.ForeColor = Color.Gray;
            button_Undo.Image = Image.FromFile("Resources/undo.png");
            button_Undo.ForeColor = Color.Black;
            button_Exit.Image = Image.FromFile("Resources/exitGra.png");
            button_Exit.ForeColor = Color.Gray;
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
            button_Edit.Image = Image.FromFile("Resources/edit.png");
            button_Edit.ForeColor = Color.Black;
            button_Delete.Image = Image.FromFile("Resources/delete.png");
            button_Delete.ForeColor = Color.Black;
            button_Undo.Image = Image.FromFile("Resources/undoGra.png");
            button_Undo.ForeColor = Color.Gray;
            button_Exit.Image = Image.FromFile("Resources/exit.png");
            button_Exit.ForeColor = Color.Black;
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            Form_SelectPatient open = new Form_SelectPatient();
            open.OnPatientSelectedMore += OnPatientSelected;
            open.Show();
        }

        private void OnPatientSelected(string str)
        {
            if (str != null)
            {
                string sql = string.Format("SELECT patient,seq,cname,hkid,birth,age,sex FROM patient WHERE id={0}", str);

                SqlCommand command = new SqlCommand(sql, DBConn.getConnection());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    textBox_Patient.Text = reader.GetValue(0).ToString();
                    textBox_PatSeq.Text = reader.GetValue(1).ToString();
                    textBox_Chinese_Name.Text = reader.GetValue(2).ToString();
                    textBox_HKID.Text = reader.GetValue(3).ToString();
                    DateTime recordDate;
                    if (DateTime.TryParse(reader.GetValue(4).ToString(), out recordDate))
                    {
                        textBox_DOB.Text = recordDate.ToString("yyyy/MM/dd");
                    }
                    textBox_Age.Text = reader.GetValue(5).ToString();
                    textBox_Sex.Text = reader.GetValue(6).ToString();
                }
                reader.Close();
            }
        }

        private void button_Clinical_History_Click(object sender, EventArgs e)
        {
            Form_ClinicalHistoryEditLog open = new Form_ClinicalHistoryEditLog(textBox_Case_No.Text.Trim());
            open.Show();
        }

        private void button_F3_Surgical_Click(object sender, EventArgs e)
        {
            Form_SurgicalProcedure open = new Form_SurgicalProcedure(textBox_Surgical.Text);
            open.OnSurgicalSelectedSingle += OnSurgicalSelected;
            open.Show();
        }

        private void OnSurgicalSelected(string str)
        {
            if (str != null)
            {
                textBox_Surgical.Text = str;

                textBox_Surgical.Focus();
                textBox_Surgical.Select(textBox_Surgical.TextLength, 0);
                textBox_Surgical.ScrollToCaret();
            }
        }

        private void button_F4_Nature_Click(object sender, EventArgs e)
        {
            Form_NatureOfSpecimen open = new Form_NatureOfSpecimen(textBox_Nature.Text);
            open.OnNatureSelectedSingle += OnNatureSelected;
            open.Show();
        }

        private void OnNatureSelected(string str)
        {
            if (str != null)
            {
                textBox_Nature.Text = str;

                textBox_Nature.Focus();
                textBox_Nature.Select(textBox_Nature.TextLength, 0);
                textBox_Nature.ScrollToCaret();
            }
        }

        private void button_F2_Previous_Click(object sender, EventArgs e)
        {
            Form_PrevoiusCasesCondition open = new Form_PrevoiusCasesCondition(textBox_HKID.Text.Trim(), textBox_ID.Text.Trim());
            open.Show();
        }

        private void button_F7_Click(object sender, EventArgs e)
        {
            Form_SelectClient open = new Form_SelectClient();
            open.OnClientSelectedSingle += OnClientSelected;
            open.Show();
        }

        private void OnClientSelected(string str)
        {
            if (str != null)
            {
                textBox_LabHCIName.Text = str;
            }
        }

        private void button_F9_Click(object sender, EventArgs e)
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.OnDoctorSelectedWithNameAndId += OnDoctorSelected;
            open.Show();
        }

        private void OnDoctorSelected(string doctorNameStr, string doctroIdStr)
        {
            if (doctorNameStr != null)
            {
                textBox_Doctor_I_C.Text = doctorNameStr;
            }

            if (doctroIdStr != null)
            {
                textBox_Doctor_I_C_ID_1.Text = doctroIdStr;
            }
        }

        private void button_Sign_By_Dr_1_Click(object sender, EventArgs e)
        {
            Form_DoctorsSignatureMaintenance open = new Form_DoctorsSignatureMaintenance();
            open.Show();
        }

        private void button_Sign_By_Dr_2_Click(object sender, EventArgs e)
        {
            Form_DoctorsSignatureMaintenance open = new Form_DoctorsSignatureMaintenance();
            open.Show();
        }

        private void button_Cytology_Click(object sender, EventArgs e)
        {
            Form_CytologyFindings open = new Form_CytologyFindings();
            open.Show();
        }

        private void button_Printed_Click(object sender, EventArgs e)
        {
            string message = string.Format("Last Printed By: {0}" +
                "\nLast Printed At: {1}" +
                "\nTotal Printed Counter: {2}", label_Print_By.Text.Trim(), label_Print_At.Text.Trim(), label_Printed.Text.Trim());
            MessageBox.Show(message, "Report Printing Staticstic");
        }

        private void button_Rpt_Date_Tick_Click(object sender, EventArgs e)
        {
            textBox_Rpt_Date.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            textBox_Rpt_Date.Focus();
            textBox_Rpt_Date.Select(textBox_Rpt_Date.TextLength, 0);
            textBox_Rpt_Date.ScrollToCaret();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string message = string.Format("Uploaded Record(s) With PDF File To STH's Database Server:\n" +
                "Uploaded At       Uploaded By       Version\n" +
                "===========================================\n" +
                "{0}{1}{2}", textBox_Updated_At.Text.Trim().PadRight(20, ' '), textBox_Updated_By_1.Text.Trim().PadRight(24, ' '), label_Version.Text.Trim());
            MessageBox.Show(message, "Uploaded Record(s)");
        }

        private void setPreviousRecordMark()
        {
            DataSet bxcyDataSet = new DataSet();
            string sql = string.Format("select * From [BXCY_SPECIMEN] bs Where bs.pat_hkid = '{0}' and id <> {1}", textBox_HKID.Text.Trim(), textBox_ID.Text.Trim());
            DBConn.fetchDataIntoDataSetSelectOnly(sql, bxcyDataSet, "BXCY_SPECIMEN");

            if (bxcyDataSet.Tables["BXCY_SPECIMEN"].Rows.Count > 0)
            {
                pictureBox_Has_Previous.Visible = true;
            }
            else
            {
                pictureBox_Has_Previous.Visible = false;
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

        private void textBox_Case_No_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox_Case_No.Text.Trim().ToLower() == "b")
            {
                textBox_Case_No.Text = string.Format("BX{0}/", DateTime.Now.ToString("yyyy").Substring(2));
            }
            else
            {
                if (textBox_Case_No.Text.Trim().ToLower() == "c")
                {
                    textBox_Case_No.Text = string.Format("CY{0}-", DateTime.Now.ToString("yyyy").Substring(2));
                }
                else
                {
                    if (textBox_Case_No.Text.Trim().ToLower() == "m")
                    {
                        textBox_Case_No.Text = string.Format("MP{0}-", DateTime.Now.ToString("yyyy").Substring(2));
                    }
                    else
                    {
                        if (textBox_Case_No.Text.Trim().ToLower() == "d")
                        {
                            textBox_Case_No.Text = string.Format("D{0}-", DateTime.Now.ToString("yyyy").Substring(2));
                        }
                    }
                }
            }
        }
    }
}
