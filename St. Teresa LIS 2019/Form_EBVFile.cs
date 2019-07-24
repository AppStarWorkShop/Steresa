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
    public partial class Form_EBVFile : Form
    {
        private DataSet ebv_specimenDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        public static Boolean merge;
        public CurrencyManager currencyManager;
        private Ebv_specimenStr copyEbv_specimen;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string id;

        public class Ebv_specimen
        {
            public int id { get; set; }
            public string CASE_NO { get; set; }
            public string BARCODE { get; set; }
            public string VER { get; set; }
            public DateTime? DATE { get; set; }
            public string RPT_DATE { get; set; }
            public string SIGN_DR { get; set; }
            public string CLIENT { get; set; }
            public string DOCTOR_ID { get; set; }
            public string DOCTOR_IC { get; set; }
            public string DOCTOR_O { get; set; }
            public string LAB_REF { get; set; }
            public string ETHNIC { get; set; }
            public string PATIENT { get; set; }
            public string CNAME { get; set; }
            public Double? PAT_SEQ { get; set; }
            public string PAT_BIRTH { get; set; }
            public Double? PAT_AGE { get; set; }
            public string PAT_SEX { get; set; }
            public string PAT_HKID { get; set; }
            public string PAT_HIST { get; set; }
            public string BED_ROOM { get; set; }
            public string BED_NO { get; set; }
            public string DISCHARGE { get; set; }
            public string RECEIPT { get; set; }
            public string INV_NO { get; set; }
            public Double? INV_AMT { get; set; }
            public DateTime? INV_DATE { get; set; }
            public DateTime? PAY_DATE { get; set; }
            public string DIAGNOSIS { get; set; }
            public string RESULT { get; set; }
            public string RESULT1 { get; set; }
            public string RESULT2 { get; set; }
            public string RESULT3 { get; set; }
            public string RESULT4 { get; set; }
            public string RESULT5 { get; set; }
            public string RESULT6 { get; set; }
            public string REMIND { get; set; }
            public string INITIAL { get; set; }
            public Double? PRIV_CASE { get; set; }
            public string TUMOUR { get; set; }
            public string PRINT_BY { get; set; }
            public DateTime? PRINT_AT { get; set; }
            public Double? PRINT_CTR { get; set; }
            public string ISSUE_BY { get; set; }
            public string ISSUE_AT { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
            public string UPLOADED { get; set; }
        }

        public class Ebv_specimenStr
        {
            public int id { get; set; }
            public string CASE_NO { get; set; }
            public string BARCODE { get; set; }
            public string VER { get; set; }
            public string DATE { get; set; }
            public string RPT_DATE { get; set; }
            public string SIGN_DR { get; set; }
            public string CLIENT { get; set; }
            public string DOCTOR_ID { get; set; }
            public string DOCTOR_IC { get; set; }
            public string DOCTOR_O { get; set; }
            public string LAB_REF { get; set; }
            public string ETHNIC { get; set; }
            public string PATIENT { get; set; }
            public string CNAME { get; set; }
            public string PAT_SEQ { get; set; }
            public string PAT_BIRTH { get; set; }
            public string PAT_AGE { get; set; }
            public string PAT_SEX { get; set; }
            public string PAT_HKID { get; set; }
            public string PAT_HIST { get; set; }
            public string BED_ROOM { get; set; }
            public string BED_NO { get; set; }
            public string DISCHARGE { get; set; }
            public string RECEIPT { get; set; }
            public string INV_NO { get; set; }
            public string INV_AMT { get; set; }
            public string INV_DATE { get; set; }
            public string PAY_DATE { get; set; }
            public string DIAGNOSIS { get; set; }
            public string RESULT { get; set; }
            public string RESULT1 { get; set; }
            public string RESULT2 { get; set; }
            public string RESULT3 { get; set; }
            public string RESULT4 { get; set; }
            public string RESULT5 { get; set; }
            public string RESULT6 { get; set; }
            public string REMIND { get; set; }
            public string INITIAL { get; set; }
            public string PRIV_CASE { get; set; }
            public string TUMOUR { get; set; }
            public string PRINT_BY { get; set; }
            public string PRINT_AT { get; set; }
            public string PRINT_CTR { get; set; }
            public string ISSUE_BY { get; set; }
            public string ISSUE_AT { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
            public string UPLOADED { get; set; }
        }

        public Form_EBVFile(string id = null)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button_F_S_Detail_Click(object sender, EventArgs e)
        {
            Form_EBVDiagnosisFileMaintenance open = new Form_EBVDiagnosisFileMaintenance(comboBox_Diagnosis.Text);
            open.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            //DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [EBV_SPECIMEN]",ebv_specimenDataSet);
            string sql = "SELECT *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [EBV_SPECIMEN]";
            /*if (id != null)
            {
                sql = string.Format("SELECT * FROM [EBV_SPECIMEN] WHERE ID IN({0})", id);
            }*/
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, ebv_specimenDataSet, "ebv_specimen");

            textBox_ID.DataBindings.Clear();
            textBox_Case_No.DataBindings.Clear();
            textBox_Date.DataBindings.Clear();
            comboBox_Ethnic.DataBindings.Clear();
            textBox_Patient.DataBindings.Clear();
            textBox_PatSeq.DataBindings.Clear();
            textBox_Chinese_Name.DataBindings.Clear();
            textBox_DOB.DataBindings.Clear();
            textBox_HKID.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            textBox_Room.DataBindings.Clear();
            textBox_Bed.DataBindings.Clear();
            textBox_Patient_s_Clinical_History.DataBindings.Clear();
            textBox_Client.DataBindings.Clear();
            textBox_Doctor_I_C.DataBindings.Clear();
            
            textBox_Ref_No.DataBindings.Clear();
            textBox_DoctorId.DataBindings.Clear();
            textBox_DoctorO.DataBindings.Clear();
            textBox_Involce_No.DataBindings.Clear();
            textBox_Receipt.DataBindings.Clear();
            textBox_Invoice_Date.DataBindings.Clear();
            textBox_Amount_HK.DataBindings.Clear();
            textBox_Paid_Up.DataBindings.Clear();
            textBox_Paid_Date.DataBindings.Clear();
            comboBox_Result.DataBindings.Clear();
            textBox_Result1.DataBindings.Clear();
            textBox_Result2.DataBindings.Clear();
            textBox_Result3.DataBindings.Clear();
            textBox_Result4.DataBindings.Clear();
            textBox_Result5.DataBindings.Clear();
            textBox_Result6.DataBindings.Clear();
            textBox_Initial.DataBindings.Clear();
            textBox_ReportDate.DataBindings.Clear();
            comboBox_SignDr.DataBindings.Clear();
            comboBox_Diagnosis.DataBindings.Clear();
            textBox_Remind.DataBindings.Clear();

            dt = ebv_specimenDataSet.Tables["ebv_specimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            //dt.Rows.Find(id)           
            string diagnosisSql = "SELECT DIAGNOSIS FROM [diagnosis]";
            DataSet diagnosisDataSet = new DataSet();
            SqlDataAdapter diagnosisDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diagnosisSql, diagnosisDataSet, "diagnosis");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("DIAGNOSIS");

            foreach (DataRow mDr in diagnosisDataSet.Tables["diagnosis"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["DIAGNOSIS"] });
            }

            comboBox_Diagnosis.DataSource = newDt;

            string resultSql = "SELECT RESULT FROM [result]";
            DataSet resultDataSet = new DataSet();
            SqlDataAdapter resultDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(resultSql, resultDataSet, "result");

            DataTable resultDt = new DataTable();
            resultDt.Columns.Add("RESULT");

            foreach (DataRow mDr in resultDataSet.Tables["result"].Rows)
            {
                resultDt.Rows.Add(new object[] { mDr["RESULT"] });
            }

            comboBox_Result.DataSource = resultDt;

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

            string signDoctorSql = "SELECT doctor FROM sign_doctor WHERE DOC_NO IS NOT NULL";
            DataSet signDoctorDataSet = new DataSet();
            SqlDataAdapter doctorDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(signDoctorSql, signDoctorDataSet, "sign_doctor");

            DataTable signDoctorDt = new DataTable();
            signDoctorDt.Columns.Add("doctor");

            foreach (DataRow mDr in signDoctorDataSet.Tables["sign_doctor"].Rows)
            {
                signDoctorDt.Rows.Add(new object[] { mDr["doctor"] });
            }

            comboBox_SignDr.DataSource = signDoctorDt;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Case_No.DataBindings.Add("Text", dt, "CASE_NO", false);
            textBox_Date.DataBindings.Add("Text", dt, "DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            comboBox_Ethnic.DataBindings.Add("SelectedValue", dt, "ETHNIC", false);
            textBox_Patient.DataBindings.Add("Text", dt, "PATIENT", false);
            textBox_PatSeq.DataBindings.Add("Text", dt, "PAT_SEQ", false);
            textBox_Chinese_Name.DataBindings.Add("Text", dt, "CNAME", false);
            //textBox_DOB.DataBindings.Add("Text", dt, "PAT_BIRTH", false);
            textBox_DOB.DataBindings.Add("Text", dt, "PAT_BIRTH", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            textBox_HKID.DataBindings.Add("Text", dt, "PAT_HKID", false);
            textBox_Age.DataBindings.Add("Text", dt, "PAT_AGE", false);
            textBox_Sex.DataBindings.Add("Text", dt, "PAT_SEX", false);
            textBox_Room.DataBindings.Add("Text", dt, "BED_ROOM", false);
            textBox_Bed.DataBindings.Add("Text", dt, "BED_NO", false);
            textBox_Patient_s_Clinical_History.DataBindings.Add("Text", dt, "PAT_HIST", false);
            textBox_Client.DataBindings.Add("Text", dt, "CLIENT", false);
            textBox_Ref_No.DataBindings.Add("Text", dt, "LAB_REF", false);
            textBox_Doctor_I_C.DataBindings.Add("Text", dt, "DOCTOR_IC", false);

            textBox_DoctorId.DataBindings.Add("Text", dt, "DOCTOR_ID", false);
            textBox_DoctorO.DataBindings.Add("Text", dt, "DOCTOR_O", false);
            textBox_Involce_No.DataBindings.Add("Text", dt, "Inv_no", false);
            textBox_Receipt.DataBindings.Add("Text", dt, "RECEIPT", false);
            textBox_Invoice_Date.DataBindings.Add("Text", dt, "INV_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            textBox_Amount_HK.DataBindings.Add("Text", dt, "INV_AMT", false);
            textBox_Paid_Up.DataBindings.Add("Text", dt, "PAY_UP", false);
            textBox_Paid_Date.DataBindings.Add("Text", dt, "PAY_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            comboBox_Result.DataBindings.Add("SelectedValue", dt, "RESULT", false);
            textBox_Result1.DataBindings.Add("Text", dt, "RESULT1", false);
            textBox_Result2.DataBindings.Add("Text", dt, "RESULT2", false);
            textBox_Result3.DataBindings.Add("Text", dt, "RESULT3", false);
            textBox_Result4.DataBindings.Add("Text", dt, "RESULT4", false);
            textBox_Result5.DataBindings.Add("Text", dt, "RESULT5", false);
            textBox_Result6.DataBindings.Add("Text", dt, "RESULT6", false);
            textBox_Initial.DataBindings.Add("Text", dt, "INITIAL", false);
            textBox_ReportDate.DataBindings.Add("Text", dt, "RPT_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            comboBox_SignDr.DataBindings.Add("SelectedValue", dt, "SIGN_DR", false);
            comboBox_Diagnosis.DataBindings.Add("SelectedValue", dt, "DIAGNOSIS", false);
            textBox_Remind.DataBindings.Add("Text", dt, "REMIND", false);

            currencyManager = (CurrencyManager)this.BindingContext[dt];

            //currencyManager.List.

            currencyManager.Position = position;

            //currencyManager.mo

            if (id != null)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in dt.Rows)
                {
                    if (mDr["id"].ToString().Trim() == id.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }

                currencyManager.Position = currentPosition;
                id = null;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT * FROM [EBV_SPECIMEN]";
            DBConn.fetchDataIntoDataSet(sql, ebv_specimenDataSet, "ebv_specimen");

            DataTable dt = ebv_specimenDataSet.Tables["ebv_specimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;
            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            currencyManager.Position++;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            currencyManager.Position--;
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            currencyManager.Position = 0;
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = ebv_specimenDataSet.Tables["ebv_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";
            ebv_specimenDataSet.Tables["ebv_specimen"].Rows.Add(currentEditRow);

            currencyManager.Position = currencyManager.Count - 1;
        }

        public void processNew()
        {
            button_New.PerformClick();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = "Admin";
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, ebv_specimenDataSet, "ebv_specimen"))
                    {
                        reloadDBData(currencyManager.Count - 1);
                        //reloadAndBindingDBData(currencyManager.Count - 1);
                        MessageBox.Show("New ebv_specimen saved");
                    }
                    else
                    {
                        MessageBox.Show("Ebv_specimen saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = ebv_specimenDataSet.Tables["ebv_specimen"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, ebv_specimenDataSet, "ebv_specimen"))
                        {
                            MessageBox.Show("Ebv_specimen updated");
                        }
                        else
                        {
                            MessageBox.Show("Ebv_specimen updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    reloadAndBindingDBData(currentPosition);
                }
            }
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
                button_F9.Enabled = false;

                textBox_Case_No.Enabled = false;
                textBox_Date.Enabled = false;
                comboBox_Ethnic.Enabled = false;
                textBox_Patient.Enabled = false;
                textBox_PatSeq.Enabled = false;
                textBox_Chinese_Name.Enabled = false;
                textBox_DOB.Enabled = false;
                textBox_HKID.Enabled = false;
                textBox_Age.Enabled = false;
                textBox_Sex.Enabled = false;
                textBox_Room.Enabled = false;
                textBox_Bed.Enabled = false;
                textBox_Patient_s_Clinical_History.Enabled = false;
                textBox_Client.Enabled = false;
                textBox_Doctor_I_C.Enabled = false;

                textBox_Ref_No.Enabled = false;
                textBox_DoctorId.Enabled = false;
                textBox_DoctorO.Enabled = false;
                textBox_Involce_No.Enabled = false;
                textBox_Receipt.Enabled = false;
                textBox_Invoice_Date.Enabled = false;
                textBox_Amount_HK.Enabled = false;
                textBox_Paid_Up.Enabled = false;
                textBox_Paid_Date.Enabled = false;
                comboBox_Result.Enabled = false;
                textBox_Result1.Enabled = false;
                textBox_Result2.Enabled = false;
                textBox_Result3.Enabled = false;
                textBox_Result4.Enabled = false;
                textBox_Result5.Enabled = false;
                textBox_Result6.Enabled = false;
                textBox_Initial.Enabled = false;
                textBox_ReportDate.Enabled = false;
                comboBox_SignDr.Enabled = false;
                comboBox_Diagnosis.Enabled = false;
                textBox_Remind.Enabled = false;

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
                    button_F9.Enabled = true;

                    textBox_Case_No.Enabled = true;
                    textBox_Date.Enabled = true;
                    comboBox_Ethnic.Enabled = true;
                    textBox_Patient.Enabled = true;
                    textBox_PatSeq.Enabled = true;
                    textBox_Chinese_Name.Enabled = true;
                    textBox_DOB.Enabled = true;
                    textBox_HKID.Enabled = true;
                    textBox_Age.Enabled = true;
                    textBox_Sex.Enabled = true;
                    textBox_Room.Enabled = true;
                    textBox_Bed.Enabled = true;
                    textBox_Patient_s_Clinical_History.Enabled = true;
                    textBox_Client.Enabled = true;
                    textBox_Doctor_I_C.Enabled = true;

                    textBox_Ref_No.Enabled = true;
                    textBox_DoctorId.Enabled = true;
                    textBox_DoctorO.Enabled = true;
                    textBox_Involce_No.Enabled = true;
                    textBox_Receipt.Enabled = true;
                    textBox_Invoice_Date.Enabled = true;
                    textBox_Amount_HK.Enabled = true;
                    textBox_Paid_Up.Enabled = true;
                    textBox_Paid_Date.Enabled = true;
                    comboBox_Result.Enabled = true;
                    textBox_Result1.Enabled = true;
                    textBox_Result2.Enabled = true;
                    textBox_Result3.Enabled = true;
                    textBox_Result4.Enabled = true;
                    textBox_Result5.Enabled = true;
                    textBox_Result6.Enabled = true;
                    textBox_Initial.Enabled = true;
                    textBox_ReportDate.Enabled = true;
                    comboBox_SignDr.Enabled = true;
                    comboBox_Diagnosis.Enabled = true;
                    textBox_Remind.Enabled = true;

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
                        button_F1.Enabled = true;
                        button_F7.Enabled = true;
                        button_F9.Enabled = true;

                        textBox_Case_No.Enabled = true;
                        textBox_Date.Enabled = true;
                        comboBox_Ethnic.Enabled = true;
                        textBox_Patient.Enabled = true;
                        textBox_PatSeq.Enabled = true;
                        textBox_Chinese_Name.Enabled = true;
                        textBox_DOB.Enabled = true;
                        textBox_HKID.Enabled = true;
                        textBox_Age.Enabled = true;
                        textBox_Sex.Enabled = true;
                        textBox_Room.Enabled = true;
                        textBox_Bed.Enabled = true;
                        textBox_Patient_s_Clinical_History.Enabled = true;
                        textBox_Client.Enabled = true;
                        textBox_Doctor_I_C.Enabled = true;

                        textBox_Ref_No.Enabled = true;
                        textBox_DoctorId.Enabled = true;
                        textBox_DoctorO.Enabled = true;
                        textBox_Involce_No.Enabled = true;
                        textBox_Receipt.Enabled = true;
                        textBox_Invoice_Date.Enabled = true;
                        textBox_Amount_HK.Enabled = true;
                        textBox_Paid_Up.Enabled = true;
                        textBox_Paid_Date.Enabled = true;
                        comboBox_Result.Enabled = true;
                        textBox_Result1.Enabled = true;
                        textBox_Result2.Enabled = true;
                        textBox_Result3.Enabled = true;
                        textBox_Result4.Enabled = true;
                        textBox_Result5.Enabled = true;
                        textBox_Result6.Enabled = true;
                        textBox_Initial.Enabled = true;
                        textBox_ReportDate.Enabled = true;
                        comboBox_SignDr.Enabled = true;
                        comboBox_Diagnosis.Enabled = true;
                        textBox_Remind.Enabled = true;

                        edit_modle();
                    }
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            currentPosition = currencyManager.Position;

            copyEbv_specimen = new Ebv_specimenStr();
            copyEbv_specimen.CASE_NO = textBox_Case_No.Text;
            copyEbv_specimen.DATE = textBox_Date.Text;
            copyEbv_specimen.RPT_DATE = textBox_PatSeq.Text;
            copyEbv_specimen.SIGN_DR = comboBox_SignDr.Text;
            copyEbv_specimen.CLIENT = textBox_Client.Text;
            copyEbv_specimen.DOCTOR_ID = textBox_DoctorId.Text;
            copyEbv_specimen.DOCTOR_IC = textBox_Doctor_I_C.Text;
            copyEbv_specimen.DOCTOR_O = textBox_DoctorO.Text;
            copyEbv_specimen.LAB_REF = textBox_Ref_No.Text;
            copyEbv_specimen.ETHNIC = comboBox_Ethnic.Text;
            copyEbv_specimen.PATIENT = textBox_Patient.Text;
            copyEbv_specimen.CNAME = textBox_Chinese_Name.Text;
            copyEbv_specimen.PAT_SEQ = textBox_PatSeq.Text;
            copyEbv_specimen.PAT_BIRTH = textBox_DOB.Text;
            copyEbv_specimen.PAT_AGE = textBox_Age.Text;
            copyEbv_specimen.PAT_SEX = textBox_Sex.Text;
            copyEbv_specimen.PAT_HKID = textBox_HKID.Text;
            copyEbv_specimen.PAT_HIST = textBox_Patient_s_Clinical_History.Text;
            copyEbv_specimen.BED_ROOM = textBox_Room.Text;
            copyEbv_specimen.BED_NO = textBox_Bed.Text;
            copyEbv_specimen.RECEIPT = textBox_Receipt.Text;
            copyEbv_specimen.INV_NO = textBox_Involce_No.Text;
            copyEbv_specimen.INV_AMT = textBox_Amount_HK.Text;
            copyEbv_specimen.INV_DATE = textBox_Invoice_Date.Text;
            copyEbv_specimen.PAY_DATE = textBox_Paid_Date.Text;
            copyEbv_specimen.DIAGNOSIS = comboBox_Diagnosis.Text;
            copyEbv_specimen.RESULT = comboBox_Result.Text;
            copyEbv_specimen.RESULT1 = textBox_Result1.Text;
            copyEbv_specimen.RESULT2 = textBox_Result2.Text;
            copyEbv_specimen.RESULT3 = textBox_Result3.Text;
            copyEbv_specimen.RESULT4 = textBox_Result4.Text;
            copyEbv_specimen.RESULT5 = textBox_Result5.Text;
            copyEbv_specimen.RESULT6 = textBox_Result6.Text;
            copyEbv_specimen.REMIND = textBox_Remind.Text;
            copyEbv_specimen.INITIAL = textBox_Initial.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        public void processEdit()
        {
            button_Edit.PerformClick();
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    ebv_specimenDataSet.Tables["ebv_specimen"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                //reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyEbv_specimen != null)
                    {
                        textBox_Case_No.Text = copyEbv_specimen.CASE_NO;
                        textBox_Date.Text = copyEbv_specimen.DATE;
                        textBox_PatSeq.Text = copyEbv_specimen.RPT_DATE;
                        comboBox_SignDr.Text = copyEbv_specimen.SIGN_DR;
                        textBox_Client.Text = copyEbv_specimen.CLIENT;
                        textBox_DoctorId.Text = copyEbv_specimen.DOCTOR_ID;
                        textBox_Doctor_I_C.Text = copyEbv_specimen.DOCTOR_IC;
                        textBox_DoctorO.Text = copyEbv_specimen.DOCTOR_O;
                        textBox_Ref_No.Text = copyEbv_specimen.LAB_REF;
                        comboBox_Ethnic.Text = copyEbv_specimen.ETHNIC;
                        textBox_Patient.Text = copyEbv_specimen.PATIENT;
                        textBox_Chinese_Name.Text = copyEbv_specimen.CNAME;
                        textBox_PatSeq.Text = copyEbv_specimen.PAT_SEQ;
                        textBox_DOB.Text = copyEbv_specimen.PAT_BIRTH;
                        textBox_Age.Text = copyEbv_specimen.PAT_AGE;
                        textBox_Sex.Text = copyEbv_specimen.PAT_SEX;
                        textBox_HKID.Text = copyEbv_specimen.PAT_HKID;
                        textBox_Patient_s_Clinical_History.Text = copyEbv_specimen.PAT_HIST;
                        textBox_Room.Text = copyEbv_specimen.BED_ROOM;
                        textBox_Bed.Text = copyEbv_specimen.BED_NO;
                        textBox_Receipt.Text = copyEbv_specimen.RECEIPT;
                        textBox_Involce_No.Text = copyEbv_specimen.INV_NO;
                        textBox_Amount_HK.Text = copyEbv_specimen.INV_AMT;
                        textBox_Invoice_Date.Text = copyEbv_specimen.INV_DATE;
                        textBox_Paid_Date.Text = copyEbv_specimen.PAY_DATE;
                        comboBox_Diagnosis.Text = copyEbv_specimen.DIAGNOSIS;
                        comboBox_Result.Text = copyEbv_specimen.RESULT;
                        textBox_Result1.Text = copyEbv_specimen.RESULT1;
                        textBox_Result2.Text = copyEbv_specimen.RESULT2;
                        textBox_Result3.Text = copyEbv_specimen.RESULT3;
                        textBox_Result4.Text = copyEbv_specimen.RESULT4;
                        textBox_Result5.Text = copyEbv_specimen.RESULT5;
                        textBox_Result6.Text = copyEbv_specimen.RESULT6;
                        textBox_Remind.Text = copyEbv_specimen.REMIND;
                        textBox_Initial.Text = copyEbv_specimen.INITIAL;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM EBV_SPECIMEN WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    currencyManager.Position = 0;

                    reloadDBData(0);
                    MessageBox.Show("Ebv_specimen deleted");
                }
                else
                {
                    MessageBox.Show("Ebv_specimen deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
                //reloadDBData();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form_EBVFile_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void button_F2_Previous_Click(object sender, EventArgs e)
        {

        }

        private void button_Sign_By_Dr_1_Click(object sender, EventArgs e)
        {

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
                textBox_Client.Text = str;
            }
        }

        private void button_F9_Click(object sender, EventArgs e)
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.OnDoctorSelectedSingle += OnDoctorSelected;
            open.Show();
        }

        private void OnDoctorSelected(string str)
        {
            if (str != null)
            {
                textBox_Doctor_I_C.Text = str;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.F1 && button_F1.Enabled)
            {
                button_F1.PerformClick();
                return true;
            }

            if (keyData == (Keys)Shortcut.F7 && button_F7.Enabled)
            {
                button_F7.PerformClick();
                return true;
            }

            if (keyData == (Keys)Shortcut.F9 && button_F9.Enabled)
            {
                button_F9.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            Form_SelectPatient open = new Form_SelectPatient();
            open.OnPatientSelectedSingle += OnPatientSelected;
            open.Show();
        }

        private void OnPatientSelected(string str)
        {
            if (str != null)
            {
                textBox_Patient.Text = str;
            }
        }

        private void button_Printed_Click(object sender, EventArgs e)
        {

        }
    }
}
