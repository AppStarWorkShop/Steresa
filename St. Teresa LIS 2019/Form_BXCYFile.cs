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
            public string clinical_History { get; set; }
            public string class1 { get; set; }
            public string doctor_ic2 { get; set; }
            public string doctor_id2 { get; set; }
            public string doctor_ic3 { get; set; }
            public string doctor_id3 { get; set; }
            public string histo { get; set; }
            public string cyto_Type { get; set; }
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
            public string clinical_History { get; set; }
            public string class1 { get; set; }
            public string doctor_ic2 { get; set; }
            public string doctor_id2 { get; set; }
            public string doctor_ic3 { get; set; }
            public string doctor_id3 { get; set; }
            public string histo { get; set; }
            public string cyto_Type { get; set; }
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

        private void reloadAndBindingDBData(int position = -0)
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

            DataTable cytoTypeDt = new DataTable();
            cytoTypeDt.Columns.Add("cytoType");
            cytoTypeDt.Rows.Add(new object[] { "G" });
            cytoTypeDt.Rows.Add(new object[] { "F" });
            cytoTypeDt.Rows.Add(new object[] { "N" });
            cytoTypeDt.Rows.Add(new object[] { "HS" });
            cytoTypeDt.Rows.Add(new object[] { "HQ" });

            comboBox_cytoType.DataSource = cytoTypeDt;

            DataTable classDt = new DataTable();
            classDt.Columns.Add("classValue");
            classDt.Rows.Add(new object[] { "classValue1" });
            classDt.Rows.Add(new object[] { "classValue2" });
            classDt.Rows.Add(new object[] { "classValue3" });

            comboBox_Class.DataSource = classDt;

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

            comboBox_Sign_By_Dr_1.DataSource = doctorDt;
            comboBox_Sign_By_Dr_2.DataSource = doctorDt;

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
            if (position != -1)
            {
                currencyManager.Position = position;
            }

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
            string sql = "SELECT * FROM [BXCY_SPECIMEN]";
            DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

            DataTable dt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;
            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;
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
            this.Close();
            //button_Escm();
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
            /*
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
                default:
                    break;
            }*/
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
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = "Admin";
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
                    {
                        reloadDBData(currencyManager.Count - 1);
                        //reloadAndBindingDBData(currencyManager.Count - 1);
                        MessageBox.Show("New ebv_specimen saved");
                    }
                    else
                    {
                        MessageBox.Show("Bxcy_specimen saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
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
                    reloadAndBindingDBData(currentPosition);
                }
            }
        }

        public void processEdit()
        {
            button_Edit.PerformClick();
        }

        public void processNew()
        {
            button_New.PerformClick();
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["case_no"] = textBox_Case_No.Text;
            currentEditRow["date"] = DateTime.ParseExact(textBox_Date.Text, "dd/MM/yyyy", null);
            currentEditRow["ethnic"] = comboBox_Ethnic.Text;
            currentEditRow["cyto_Type"] = comboBox_cytoType.Text;
            currentEditRow["patient"] = textBox_Patient.Text;
            currentEditRow["pat_seq"] = textBox_PatSeq.Text;
            currentEditRow["cname"] = textBox_Chinese_Name.Text;
            currentEditRow["pat_hkid"] = textBox_HKID.Text;
            currentEditRow["pat_birth"] = DateTime.ParseExact(textBox_DOB.Text, "dd/MM/yyyy", null);
            currentEditRow["class"] = comboBox_Class.Text;
            currentEditRow["pat_age"] = textBox_Age.Text;
            currentEditRow["pat_sex"] = textBox_Sex.Text;
            currentEditRow["bed_room"] = textBox_Room.Text;
            currentEditRow["bed_no"] = textBox_Bed.Text;
            currentEditRow["clinical_History"] = textBox_Patient_s_Clinical_History.Text;

            currentEditRow["client"] = textBox_Client.Text;
            currentEditRow["institute"] = textBox_Institute.Text;
            currentEditRow["lab_ref"] = textBox_Ref_No.Text;
            currentEditRow["doctor_o"] = textBox_Dr_I_C_Free_Text.Text;

            currentEditRow["doctor_ic"] = textBox_Doctor_I_C.Text;
            currentEditRow["doctor_id"] = textBox_Doctor_I_C_ID_1.Text;

            currentEditRow["doctor_id2"] = textBox_Doctor_I_C_2.Text;
            currentEditRow["doctor_id2"] = textBox_Doctor_I_C_ID_2.Text;

            currentEditRow["doctor_id3"] = textBox_Doctor_I_C_3.Text;
            currentEditRow["doctor_id3"] = textBox_Doctor_I_C_ID_3.Text;

            currentEditRow["inv_no"] = textBox_Involce_No.Text;
            currentEditRow["receipt"] = textBox_Receipt.Text;
            currentEditRow["inv_date"] = DateTime.ParseExact(textBox_Invoice_Date.Text, "dd/MM/yyyy", null);
            currentEditRow["inv_amt"] = textBox_Amount_HK.Text;

            currentEditRow["pay_date"] = DateTime.ParseExact(textBox_Paid_Date.Text, "dd/MM/yyyy", null); 

            currentEditRow["rpt_date"] = textBox_Rpt_Date.Text; 
            currentEditRow["snopcode_t"] = comboBox_Snop_T1.Text;
            currentEditRow["snopcode_t2"] = comboBox_Snop_T2.Text;
            currentEditRow["snopcode_t3"] = comboBox_Snop_T3.Text;
            currentEditRow["sign_dr"] = comboBox_Sign_By_Dr_1.Text;
            currentEditRow["snopcode_m"] = comboBox_Snop_M1.Text;
            currentEditRow["snopcode_m2"] = comboBox_Snop_M2.Text;
            currentEditRow["snopcode_m3"] = comboBox_Snop_M3.Text;
            currentEditRow["sign_dr2"] = comboBox_Sign_By_Dr_2.Text;
            currentEditRow["histo"] = comboBox_HistoType.Text;

            currentEditRow["remark"] = textBox_Remarks.Text;
            currentEditRow["initial"] = textBox_Cytology.Text;
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_F6_Edit_Click(object sender, EventArgs e)
        {
            currentPosition = currencyManager.Position;

            copybxcy_specimen = new Bxcy_specimenStr();
            copybxcy_specimen.case_no = textBox_Case_No.Text;
            copybxcy_specimen.date = textBox_Date.Text;
            copybxcy_specimen.ethnic = comboBox_Ethnic.Text;
            copybxcy_specimen.cyto_Type = comboBox_cytoType.Text;
            copybxcy_specimen.patient = textBox_Patient.Text;
            copybxcy_specimen.pat_seq = textBox_PatSeq.Text;
            copybxcy_specimen.cname = textBox_Chinese_Name.Text;
            copybxcy_specimen.pat_hkid = textBox_HKID.Text;
            copybxcy_specimen.pat_birth = textBox_DOB.Text;
            copybxcy_specimen.class1 = comboBox_Class.Text;
            copybxcy_specimen.pat_age = textBox_Age.Text;
            copybxcy_specimen.pat_sex = textBox_Sex.Text;
            copybxcy_specimen.bed_room = textBox_Room.Text;
            copybxcy_specimen.bed_no = textBox_Bed.Text;
            copybxcy_specimen.clinical_History = textBox_Patient_s_Clinical_History.Text;

            copybxcy_specimen.client = textBox_Client.Text;
            copybxcy_specimen.institute = textBox_Institute.Text;
            copybxcy_specimen.lab_ref = textBox_Ref_No.Text;
            copybxcy_specimen.doctor_o = textBox_Dr_I_C_Free_Text.Text;

            copybxcy_specimen.doctor_ic = textBox_Doctor_I_C.Text;
            copybxcy_specimen.doctor_id = textBox_Doctor_I_C_ID_1.Text;

            copybxcy_specimen.doctor_id2 = textBox_Doctor_I_C_2.Text;
            copybxcy_specimen.doctor_id2 = textBox_Doctor_I_C_ID_2.Text;

            copybxcy_specimen.doctor_id3 = textBox_Doctor_I_C_3.Text;
            copybxcy_specimen.doctor_id3 = textBox_Doctor_I_C_ID_3.Text;

            copybxcy_specimen.inv_no = textBox_Involce_No.Text;
            copybxcy_specimen.receipt = textBox_Receipt.Text;
            copybxcy_specimen.inv_date = textBox_Invoice_Date.Text;
            copybxcy_specimen.inv_amt = textBox_Amount_HK.Text;
            
            copybxcy_specimen.pay_date = textBox_Paid_Date.Text;

            copybxcy_specimen.rpt_date = textBox_Rpt_Date.Text;
            copybxcy_specimen.snopcode_t = comboBox_Snop_T1.Text;
            copybxcy_specimen.snopcode_t2 = comboBox_Snop_T2.Text;
            copybxcy_specimen.snopcode_t3 = comboBox_Snop_T3.Text;
            copybxcy_specimen.sign_dr = comboBox_Sign_By_Dr_1.Text;
            copybxcy_specimen.snopcode_m = comboBox_Snop_M1.Text;
            copybxcy_specimen.snopcode_m2 = comboBox_Snop_M2.Text;
            copybxcy_specimen.snopcode_m3 = comboBox_Snop_M3.Text;
            copybxcy_specimen.sign_dr2 = comboBox_Sign_By_Dr_2.Text;
            copybxcy_specimen.histo = comboBox_HistoType.Text;

            copybxcy_specimen.remark = textBox_Remarks.Text;
            copybxcy_specimen.initial = textBox_Cytology.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM BXCY_SPECIMEN WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    currencyManager.Position = 0;

                    reloadDBData(0);
                    MessageBox.Show("Bxcy_specimen deleted");
                }
                else
                {
                    MessageBox.Show("Bxcy_specimen deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
                //reloadDBData();
            }
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
                //reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copybxcy_specimen != null)
                    {
                        //textBox_ID.Text = copybxcy_specimen.id;
                        textBox_Case_No.Text = copybxcy_specimen.case_no;
                        textBox_Date.Text = copybxcy_specimen.date;
                        comboBox_Ethnic.Text = copybxcy_specimen.ethnic;
                        comboBox_cytoType.Text = copybxcy_specimen.cyto_Type;
                        textBox_Patient.Text = copybxcy_specimen.patient;
                        textBox_PatSeq.Text = copybxcy_specimen.pat_seq;
                        textBox_Chinese_Name.Text = copybxcy_specimen.cname;
                        textBox_HKID.Text = copybxcy_specimen.pat_hkid;
                        textBox_DOB.Text = copybxcy_specimen.pat_birth;
                        comboBox_Class.Text = copybxcy_specimen.class1;
                        textBox_Age.Text = copybxcy_specimen.pat_age;
                        textBox_Sex.Text = copybxcy_specimen.pat_sex;
                        textBox_Room.Text = copybxcy_specimen.bed_room;
                        textBox_Bed.Text = copybxcy_specimen.bed_no;
                        textBox_Patient_s_Clinical_History.Text = copybxcy_specimen.clinical_History;

                        textBox_Client.Text = copybxcy_specimen.client;
                        textBox_Institute.Text = copybxcy_specimen.institute;
                        textBox_Ref_No.Text = copybxcy_specimen.lab_ref;
                        textBox_Dr_I_C_Free_Text.Text = copybxcy_specimen.doctor_o;

                        textBox_Doctor_I_C.Text = copybxcy_specimen.doctor_ic;
                        textBox_Doctor_I_C_ID_1.Text = copybxcy_specimen.doctor_id;

                        textBox_Doctor_I_C_2.Text = copybxcy_specimen.doctor_id2;
                        textBox_Doctor_I_C_ID_2.Text = copybxcy_specimen.doctor_id2;

                        textBox_Doctor_I_C_3.Text = copybxcy_specimen.doctor_id3;
                        textBox_Doctor_I_C_ID_3.Text = copybxcy_specimen.doctor_id3;

                        textBox_Involce_No.Text = copybxcy_specimen.inv_no;
                        textBox_Receipt.Text = copybxcy_specimen.receipt;
                        textBox_Invoice_Date.Text = copybxcy_specimen.inv_date;
                        textBox_Amount_HK.Text = copybxcy_specimen.inv_amt;
                        //textBox_Paid_Up.Text = copybxcy_specimen.pay;
                        textBox_Paid_Date.Text = copybxcy_specimen.pay_date;

                        textBox_Rpt_Date.Text = copybxcy_specimen.rpt_date;
                        comboBox_Snop_T1.Text = copybxcy_specimen.snopcode_t;
                        comboBox_Snop_T2.Text = copybxcy_specimen.snopcode_t2;
                        comboBox_Snop_T3.Text = copybxcy_specimen.snopcode_t3;
                        comboBox_Sign_By_Dr_1.Text = copybxcy_specimen.sign_dr;
                        comboBox_Snop_M1.Text = copybxcy_specimen.snopcode_m;
                        comboBox_Snop_M2.Text = copybxcy_specimen.snopcode_m2;
                        comboBox_Snop_M3.Text = copybxcy_specimen.snopcode_m3;
                        comboBox_Sign_By_Dr_2.Text = copybxcy_specimen.sign_dr2;
                        comboBox_HistoType.Text = copybxcy_specimen.histo;

                        textBox_Remarks.Text = copybxcy_specimen.remark;
                        textBox_Cytology.Text = copybxcy_specimen.initial;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
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

                button_F1.Enabled = false;
                button_F7.Enabled = false;
                button_F8.Enabled = false;
                button_F9.Enabled = false;

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

                    button_F1.Enabled = true;
                    button_F7.Enabled = true;
                    button_F8.Enabled = true;
                    button_F9.Enabled = true;

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

                        button_F1.Enabled = true;
                        button_F7.Enabled = true;
                        button_F8.Enabled = true;
                        button_F9.Enabled = true;

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

            if (keyData == (Keys)Shortcut.F8 && button_F8.Enabled)
            {
                button_F8.PerformClick();
                return true;
            }

            if (keyData == (Keys)Shortcut.F9 && button_F9.Enabled)
            {
                button_F9.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
