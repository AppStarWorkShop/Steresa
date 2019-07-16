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
    public partial class Form_BXCYFile : Form
    {
        private DataSet bxcy_specimenDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        public static Boolean merge;
        public CurrencyManager currencyManager;
        private Bxcy_specimenStr copybxcy_specimen;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string id;

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
            public string fz_section { get; set; }
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
            public Double? supp { get; set; }
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
            public string uploaded { get; set; }
            public string snopcode_t2 { get; set; }
            public string desc_t2 { get; set; }
            public string snopcode_t3 { get; set; }
            public string desc_t3 { get; set; }
            public string snopcode_m2 { get; set; }
            public string desc_m2 { get; set; }
            public string snopcode_m3 { get; set; }
            public string desc_m3 { get; set; }

        }

        public class Bxcy_specimenStr{
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
            public string fz_section { get; set; }
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
            public string supp { get; set; }
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
            public string uploaded { get; set; }
            public string snopcode_t2 { get; set; }
            public string desc_t2 { get; set; }
            public string snopcode_t3 { get; set; }
            public string desc_t3 { get; set; }
            public string snopcode_m2 { get; set; }
            public string desc_m2 { get; set; }
            public string snopcode_m3 { get; set; }
            public string desc_m3 { get; set; }
        }

        public string selected { get; private set; }

        public Form_BXCYFile(string id = null)
        {
            this.id = id;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkGreen, ButtonBorderStyle.Solid);
        }

        private void Form_BXCYFile_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            string sql = "SELECT *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen]";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

            textBox_ID.DataBindings.Clear();
            textBox_Case_No.DataBindings.Clear();
            textBox_Date.DataBindings.Clear();
            comboBox_Ethnic.DataBindings.Clear();
            comboBox_cytoType.DataBindings.Clear();
            textBox_Patient.DataBindings.Clear();
            textBox_PatSeq.DataBindings.Clear();
            textBox_Chinese_Name.DataBindings.Clear();
            textBox_HKID.DataBindings.Clear();
            textBox_DOB.DataBindings.Clear();
            comboBox_Class.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            textBox_Room.DataBindings.Clear();
            textBox_Bed.DataBindings.Clear();
            textBox_Patient_s_Clinical_History.DataBindings.Clear();

            textBox_Client.DataBindings.Clear();
            textBox_Institute.DataBindings.Clear();
            textBox_Ref_No.DataBindings.Clear();
            textBox_Dr_I_C_Free_Text.DataBindings.Clear();
            textBox_Doctor_I_C.DataBindings.Clear();
            textBox_Doctor_I_C_ID_1.DataBindings.Clear();
            textBox_Doctor_I_C_2.DataBindings.Clear();
            textBox_Doctor_I_C_ID_2.DataBindings.Clear();
            textBox_Doctor_I_C_3.DataBindings.Clear();
            textBox_Doctor_I_C_ID_3.DataBindings.Clear();

            textBox_Involce_No.DataBindings.Clear();
            textBox_Receipt.DataBindings.Clear();
            textBox_Invoice_Date.DataBindings.Clear();
            textBox_Amount_HK.DataBindings.Clear();
            textBox_Paid_Up.DataBindings.Clear();
            textBox_Paid_Date.DataBindings.Clear();

            textBox_Rpt_Date.DataBindings.Clear();
            comboBox_Snop_T1.DataBindings.Clear();
            comboBox_Snop_T2.DataBindings.Clear();
            comboBox_Snop_T3.DataBindings.Clear();
            comboBox_Sign_By_Dr_1.DataBindings.Clear();
            comboBox_Snop_M1.DataBindings.Clear();
            comboBox_Snop_M2.DataBindings.Clear();
            comboBox_Snop_M3.DataBindings.Clear();
            comboBox_Sign_By_Dr_2.DataBindings.Clear();
            comboBox_HistoType.DataBindings.Clear();

            textBox_Remarks.DataBindings.Clear();
            textBox_Cytology.DataBindings.Clear();

            dt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            //dt.Rows.Find(id)
            /*string diagnosisSql = "SELECT DIAGNOSIS FROM [diagnosis]";
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

            string doctorSql = "SELECT doctor FROM [doctor]";
            DataSet doctorDataSet = new DataSet();
            SqlDataAdapter doctorDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql, doctorDataSet, "doctor");

            DataTable doctorDt = new DataTable();
            doctorDt.Columns.Add("doctor");

            foreach (DataRow mDr in doctorDataSet.Tables["doctor"].Rows)
            {
                doctorDt.Rows.Add(new object[] { mDr["doctor"] });
            }

            comboBox_SignDr.DataSource = doctorDt;*/

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Case_No.DataBindings.Add("Text", dt, "CASE_NO", false);
            textBox_Date.DataBindings.Add("Text", dt, "DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            comboBox_Ethnic.DataBindings.Add("SelectedValue", dt, "ETHNIC", false);
            comboBox_cytoType.DataBindings.Add("SelectedValue", dt, "Cyto_Type", false);
            textBox_Patient.DataBindings.Add("Text", dt, "PATIENT", false);
            textBox_PatSeq.DataBindings.Add("Text", dt, "PAT_SEQ", false);
            textBox_Chinese_Name.DataBindings.Add("Text", dt, "CNAME", false);
            textBox_HKID.DataBindings.Add("Text", dt, "PAT_HKID", false);
            textBox_DOB.DataBindings.Add("Text", dt, "PAT_BIRTH", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            comboBox_Class.DataBindings.Add("SelectedValue", dt, "Class", false);
            textBox_Age.DataBindings.Add("Text", dt, "PAT_AGE", false);
            textBox_Sex.DataBindings.Add("Text", dt, "PAT_SEX", false);
            textBox_Room.DataBindings.Add("Text", dt, "BED_ROOM", false);
            textBox_Bed.DataBindings.Add("Text", dt, "BED_NO", false);
            textBox_Patient_s_Clinical_History.DataBindings.Add("Text", dt, "Clinical_History", false);

            textBox_Client.DataBindings.Add("Text", dt, "CLIENT", false);
            textBox_Institute.DataBindings.Add("Text", dt, "Institute", false);
            textBox_Ref_No.DataBindings.Add("Text", dt, "LAB_REF", false);
            textBox_Dr_I_C_Free_Text.DataBindings.Add("Text", dt, "DOCTOR_O", false);

            textBox_Doctor_I_C.DataBindings.Add("Text", dt, "DOCTOR_IC", false);
            textBox_Doctor_I_C_ID_1.DataBindings.Add("Text", dt, "doctor_id", false);

            textBox_Doctor_I_C_2.DataBindings.Add("Text", dt, "doctor_id2", false);
            textBox_Doctor_I_C_ID_2.DataBindings.Add("Text", dt, "doctor_id2", false);

            textBox_Doctor_I_C_3.DataBindings.Add("Text", dt, "doctor_id3", false);
            textBox_Doctor_I_C_ID_3.DataBindings.Add("Text", dt, "doctor_id3", false);

            textBox_Involce_No.DataBindings.Add("Text", dt, "Inv_no", false);
            textBox_Receipt.DataBindings.Add("Text", dt, "RECEIPT", false);
            textBox_Invoice_Date.DataBindings.Add("Text", dt, "INV_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            textBox_Amount_HK.DataBindings.Add("Text", dt, "INV_AMT", false);
            textBox_Paid_Up.DataBindings.Add("Text", dt, "PAY_UP", false);
            textBox_Paid_Date.DataBindings.Add("Text", dt, "PAY_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");

            textBox_Rpt_Date.DataBindings.Add("Text", dt, "Rpt_date", false);
            comboBox_Snop_T1.DataBindings.Add("Text", dt, "snopcode_t", false);
            comboBox_Snop_T2.DataBindings.Add("Text", dt, "snopcode_t2", false);
            comboBox_Snop_T3.DataBindings.Add("Text", dt, "snopcode_t3", false);
            comboBox_Sign_By_Dr_1.DataBindings.Add("Text", dt, "Sign_dr", false);
            comboBox_Snop_M1.DataBindings.Add("Text", dt, "Snopcode_m", false);
            comboBox_Snop_M2.DataBindings.Add("Text", dt, "Snopcode_m2", false);
            comboBox_Snop_M3.DataBindings.Add("Text", dt, "Snopcode_m3", false);
            comboBox_Sign_By_Dr_2.DataBindings.Add("Text", dt, "Sign_dr2", false);
            comboBox_HistoType.DataBindings.Add("SelectedValue", dt, "Histo", false);

            textBox_Remarks.DataBindings.Add("Text", dt, "Remark", false);
            textBox_Cytology.DataBindings.Add("Text", dt, "initial", false);

            currencyManager = (CurrencyManager)this.BindingContext[dt];
            currencyManager.Position = position;

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

        private void LoadDateMDR()
        {
            /*Console.WriteLine("testtesttest123");
            this.selected = Form_BXCYRecordSearch.selected;
            connection.Open();
            string selectQuery = "SELECT * FROM [medlab].[dbo].[BXCY_SPECIMEN] WHERE case_no = '" + selected+"'";
            command = new SqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {

                textBox_Case_No.Text = mdr.GetString(0);
            }
            connection.Close();*/
        }


        private void button_Exit_Click(object sender, EventArgs e)
        {
            button_Escm();
        }
        private void button_Escm()
        {
            this.Close();
        }

        private void button_Cytology_Click(object sender, EventArgs e)
        {
            button_F10m();
        }
        private void button_F10m()
        {
            Form_CytologyFindings open = new Form_CytologyFindings();
            open.Show();
        }

        private void button_F_S_Detail_Click(object sender, EventArgs e)
        {
            Form_FrozenSectionDianosis open = new Form_FrozenSectionDianosis();
            open.Show();
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            button_F1m();
        }

        private void button_F1m()
        {
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
        }

        private void button_F2_Previous_Click(object sender, EventArgs e)
        {
            button_F2m();
        }
        private void button_F2m()
        {
            Form_PrevoiusCasesCondition open = new Form_PrevoiusCasesCondition();
            open.Show();
        }

        private void button_F3_Surgical_Click(object sender, EventArgs e)
        {
            button_F3m();
        }
        private void button_F3m()
        {
            Form_SurgicalProcedure open = new Form_SurgicalProcedure();
            open.Show();
        }

        private void button_F4_Nature_Click(object sender, EventArgs e)
        {
            button_F4m();
        }
        private void button_F4m()
        {
            Form_NatureOfSpecimen open = new Form_NatureOfSpecimen();
            open.Show();
        }
        private void button_F5_Description_Click(object sender, EventArgs e)
        {
            button_F5m();
        }
        private void button_F5m()
        {
            Form_Description open = new Form_Description();
            open.Show();
        }

        private void button_F7_Click(object sender, EventArgs e)
        {
            button_F7m();
        }
        private void button_F7m()
        {
            Form_SelectClient open = new Form_SelectClient();
            open.Show();
        }

        private void button_F8_Click(object sender, EventArgs e)
        {
            button_F8m();
        }
        private void button_F8m()
        {
            Form_SelectClientInstitute open = new Form_SelectClientInstitute();
            open.Show();
        }

        private void button_F9_Click(object sender, EventArgs e)
        {
            button_F9m();
        }
        private void button_F9_2_Click(object sender, EventArgs e)
        {
            button_F9m();
        }
        private void button_F9_3_Click(object sender, EventArgs e)
        {
            button_F9m();
        }
        private void button_F9m()
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.Show();
        }
        private void button_F11_Add_test_Click(object sender, EventArgs e)
        {
            button_F11m();
        }
        private void button_F11m()
        {
            Form_AdditionalTests open = new Form_AdditionalTests();
            open.Show();
        }

        private void button_CY_Report_Detail_Click(object sender, EventArgs e)
        {
            Form_CYReportMaintenance open = new Form_CYReportMaintenance();
            open.Show();
        }

        private void button_Fee_Click(object sender, EventArgs e)
        {
            if (textBox_Client.Text == "ST. TERESA'S HOSPITAL")
            {
                Form_FeeCalculationSTH open = new Form_FeeCalculationSTH();
                open.Show();
            }
            else
            {
                Form_FeeCalculationPrivate open = new Form_FeeCalculationPrivate();
                open.Show();
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



        private void Form_BXCYFile_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
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
                 // button_F6m();
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
                case Keys.F11:
                    button_F11m();
                    break;
                case Keys.Escape:
                    button_Escm();
                    break;
                case Keys.Right:
                    if (textBox_Doctor_I_C.Focused || textBox_Doctor_I_C_2.Focused || textBox_Doctor_I_C_3.Focused || textBox_Dr_I_C_Free_Text.Focused || textBox_Doctor_I_C_ID_1.Focused || textBox_Doctor_I_C_ID_2.Focused || textBox_Doctor_I_C_ID_3.Focused)
                    {
                    Shif_3_4();
                    Shif_2_3();
                    Shif_1_2();
                    }
                    
                    break;
                //// etc
                default:
                    // do nothing
                    break;
            }
        }

        private void button_Shif_Click(object sender, EventArgs e)
        {
            
            if (textBox_Doctor_I_C.Text != "")
            {
                if (textBox_Doctor_I_C_2.Text != "")
                {
                    if (textBox_Doctor_I_C_3.Text != "")
                    {
                        Shif_3_4();
                    }
                    Shif_2_3();
                }  
                Shif_1_2();
            }
        }

        private void button_Shif_2_Click(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C_2.Text != "")
            {
                if (textBox_Doctor_I_C_3.Text != "")
                {
                    Shif_3_4();
                }
                Shif_2_3();
            }
            
        }

        private void button_Shif_3_Click(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C_3.Text != "")
            {
                Shif_3_4();
            }
        }

        private void Shif_1_2()
        {
            textBox_Doctor_I_C_2.Text = textBox_Doctor_I_C.Text;
            textBox_Doctor_I_C_ID_2.Text = textBox_Doctor_I_C_ID_1.Text;
            textBox_Doctor_I_C.Text = "";
            textBox_Doctor_I_C_ID_1.Text = "";
        }
        private void Shif_2_3()
        {
            textBox_Doctor_I_C_3.Text = textBox_Doctor_I_C_2.Text;
            textBox_Doctor_I_C_ID_3.Text = textBox_Doctor_I_C_ID_2.Text;
            textBox_Doctor_I_C_2.Text = "";
            textBox_Doctor_I_C_ID_2.Text = "";
        }
        private void Shif_3_4()
        {
            if (textBox_Doctor_I_C_3.Text != "")
            {
            textBox_Dr_I_C_Free_Text.Text += "\r\n" + textBox_Doctor_I_C_3.Text;
            textBox_Dr_I_C_Free_Text.Text += " (" + textBox_Doctor_I_C_ID_3.Text + ")";
            textBox_Doctor_I_C_3.Text = "";
            textBox_Doctor_I_C_ID_3.Text = "";

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_ClinicalHistoryEditLog open = new Form_ClinicalHistoryEditLog();
            open.Show();
        }

        private void button_Amount_HK_Detail_Click(object sender, EventArgs e)
        {
            Form_STHDiagnosticAmount open = new Form_STHDiagnosticAmount();
            open.Show();
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

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void button_New_Click(object sender, EventArgs e)
        {

        }

        private void button_F6_Edit_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {

        }

        private void button_Undo_Click(object sender, EventArgs e)
        {

        }

        private void button_Label_Click(object sender, EventArgs e)
        {

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

                textBox_Case_No.Enabled = false;
                textBox_Date.Enabled = false;
                comboBox_Ethnic.Enabled = false;
                comboBox_cytoType.Enabled = false;
                textBox_Patient.Enabled = false;
                textBox_PatSeq.Enabled = false;
                textBox_Chinese_Name.Enabled = false;
                textBox_HKID.Enabled = false;
                textBox_DOB.Enabled = false;
                comboBox_Class.Enabled = false;
                textBox_Age.Enabled = false;
                textBox_Sex.Enabled = false;
                textBox_Room.Enabled = false;
                textBox_Bed.Enabled = false;
                textBox_Patient_s_Clinical_History.Enabled = false;

                textBox_Client.Enabled = false;
                textBox_Institute.Enabled = false;
                textBox_Ref_No.Enabled = false;
                textBox_Dr_I_C_Free_Text.Enabled = false;
                textBox_Doctor_I_C.Enabled = false;
                textBox_Doctor_I_C_ID_1.Enabled = false;
                textBox_Doctor_I_C_2.Enabled = false;
                textBox_Doctor_I_C_ID_2.Enabled = false;
                textBox_Doctor_I_C_3.Enabled = false;
                textBox_Doctor_I_C_ID_3.Enabled = false;

                textBox_Involce_No.Enabled = false;
                textBox_Receipt.Enabled = false;
                textBox_Invoice_Date.Enabled = false;
                textBox_Amount_HK.Enabled = false;
                textBox_Paid_Up.Enabled = false;
                textBox_Paid_Date.Enabled = false;

                textBox_Rpt_Date.Enabled = false;
                comboBox_Snop_T1.Enabled = false;
                comboBox_Snop_T2.Enabled = false;
                comboBox_Snop_T3.Enabled = false;
                comboBox_Sign_By_Dr_1.Enabled = false;
                comboBox_Snop_M1.Enabled = false;
                comboBox_Snop_M2.Enabled = false;
                comboBox_Snop_M3.Enabled = false;
                comboBox_Sign_By_Dr_2.Enabled = false;
                comboBox_HistoType.Enabled = false;

                textBox_Remarks.Enabled = false;
                textBox_Cytology.Enabled = false;

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

                    textBox_Case_No.Enabled = true;
                    textBox_Date.Enabled = true;
                    comboBox_Ethnic.Enabled = true;
                    comboBox_cytoType.Enabled = true;
                    textBox_Patient.Enabled = true;
                    textBox_PatSeq.Enabled = true;
                    textBox_Chinese_Name.Enabled = true;
                    textBox_HKID.Enabled = true;
                    textBox_DOB.Enabled = true;
                    comboBox_Class.Enabled = true;
                    textBox_Age.Enabled = true;
                    textBox_Sex.Enabled = true;
                    textBox_Room.Enabled = true;
                    textBox_Bed.Enabled = true;
                    textBox_Patient_s_Clinical_History.Enabled = true;

                    textBox_Client.Enabled = true;
                    textBox_Institute.Enabled = true;
                    textBox_Ref_No.Enabled = true;
                    textBox_Dr_I_C_Free_Text.Enabled = true;
                    textBox_Doctor_I_C.Enabled = true;
                    textBox_Doctor_I_C_ID_1.Enabled = true;
                    textBox_Doctor_I_C_2.Enabled = true;
                    textBox_Doctor_I_C_ID_2.Enabled = true;
                    textBox_Doctor_I_C_3.Enabled = true;
                    textBox_Doctor_I_C_ID_3.Enabled = true;

                    textBox_Involce_No.Enabled = true;
                    textBox_Receipt.Enabled = true;
                    textBox_Invoice_Date.Enabled = true;
                    textBox_Amount_HK.Enabled = true;
                    textBox_Paid_Up.Enabled = true;
                    textBox_Paid_Date.Enabled = true;

                    textBox_Rpt_Date.Enabled = true;
                    comboBox_Snop_T1.Enabled = true;
                    comboBox_Snop_T2.Enabled = true;
                    comboBox_Snop_T3.Enabled = true;
                    comboBox_Sign_By_Dr_1.Enabled = true;
                    comboBox_Snop_M1.Enabled = true;
                    comboBox_Snop_M2.Enabled = true;
                    comboBox_Snop_M3.Enabled = true;
                    comboBox_Sign_By_Dr_2.Enabled = true;
                    comboBox_HistoType.Enabled = true;

                    textBox_Remarks.Enabled = true;
                    textBox_Cytology.Enabled = true;

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

                        textBox_Case_No.Enabled = true;
                        textBox_Date.Enabled = true;
                        comboBox_Ethnic.Enabled = true;
                        comboBox_cytoType.Enabled = true;
                        textBox_Patient.Enabled = true;
                        textBox_PatSeq.Enabled = true;
                        textBox_Chinese_Name.Enabled = true;
                        textBox_HKID.Enabled = true;
                        textBox_DOB.Enabled = true;
                        comboBox_Class.Enabled = true;
                        textBox_Age.Enabled = true;
                        textBox_Sex.Enabled = true;
                        textBox_Room.Enabled = true;
                        textBox_Bed.Enabled = true;
                        textBox_Patient_s_Clinical_History.Enabled = true;

                        textBox_Client.Enabled = true;
                        textBox_Institute.Enabled = true;
                        textBox_Ref_No.Enabled = true;
                        textBox_Dr_I_C_Free_Text.Enabled = true;
                        textBox_Doctor_I_C.Enabled = true;
                        textBox_Doctor_I_C_ID_1.Enabled = true;
                        textBox_Doctor_I_C_2.Enabled = true;
                        textBox_Doctor_I_C_ID_2.Enabled = true;
                        textBox_Doctor_I_C_3.Enabled = true;
                        textBox_Doctor_I_C_ID_3.Enabled = true;

                        textBox_Involce_No.Enabled = true;
                        textBox_Receipt.Enabled = true;
                        textBox_Invoice_Date.Enabled = true;
                        textBox_Amount_HK.Enabled = true;
                        textBox_Paid_Up.Enabled = true;
                        textBox_Paid_Date.Enabled = true;

                        textBox_Rpt_Date.Enabled = true;
                        comboBox_Snop_T1.Enabled = true;
                        comboBox_Snop_T2.Enabled = true;
                        comboBox_Snop_T3.Enabled = true;
                        comboBox_Sign_By_Dr_1.Enabled = true;
                        comboBox_Snop_M1.Enabled = true;
                        comboBox_Snop_M2.Enabled = true;
                        comboBox_Snop_M3.Enabled = true;
                        comboBox_Sign_By_Dr_2.Enabled = true;
                        comboBox_HistoType.Enabled = true;

                        textBox_Remarks.Enabled = true;
                        textBox_Cytology.Enabled = true;

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
    }
}
