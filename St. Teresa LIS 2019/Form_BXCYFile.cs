using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace St.Teresa_LIS_2019
{
    public partial class Form_BXCYFile : Form
    {
        public const string DEFAULT_CLIENT = "ST. TERESA'S HOSPITAL";
        public const string DEFAULT_INSTITUTE = "ST. TERESA'S HOSPITAL";

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
        //private string surgical;

        private bool isNewPatient = false;

        private DataSet existDiagDataSet = null;
        private SqlDataAdapter existDiagDataAdapter = null;

        private Boolean readOnly = false;

        private bool m_isEntering1 = false;
        private bool m_isEntering2 = false;

        DataSet doctorDataSet1 = new DataSet();
        SqlDataAdapter doctorDataAdapter1;

        DataSet doctorDataSet2 = new DataSet();
        SqlDataAdapter doctorDataAdapter2;

        private DataTable dtToDelete;

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
            public string sish { get; set; }
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
            public string sish { get; set; }
        }

        public string selected { get; private set; }

        public Form_BXCYFile()
        {
            InitializeComponent();
        }

        public Form_BXCYFile(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        public Form_BXCYFile(bool isNewPatient)
        {
            this.isNewPatient = isNewPatient;
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

        private void reloadAndBindingDBData(int position = 0, string caseNo = null)
        {
            string sql = "SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY case_no,id";
            if (this.id != null)
            {
                sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE id={0} AND case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY  case_no,id", this.id);
                id = null;
            }
            else
            {
                if (caseNo != null)
                {
                    sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no='{0}' AND case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY  case_no,id", caseNo);
                }
            }
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

            textBox_Surgical.DataBindings.Clear();
            textBox_Nature.DataBindings.Clear();

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

            textBox_Updated_By_1.DataBindings.Clear();
            textBox_Updated_At.DataBindings.Clear();
            textBox_Issued_At.DataBindings.Clear();
            textBox_Issued_By.DataBindings.Clear();

            textBox_ER.DataBindings.Clear();
            textBox_EM.DataBindings.Clear();
            textBox_SISH.DataBindings.Clear();

            checkBox_F_S.DataBindings.Clear();
            textBox_FZDetail.DataBindings.Clear();

            label_Printed.DataBindings.Clear();

            checkBox_Uploaded.DataBindings.Clear();

            /*label_Uploaded_At.DataBindings.Clear();
            label_Uploaded_By.DataBindings.Clear();*/
            label_Version.DataBindings.Clear();

            label_Print_At.DataBindings.Clear();
            label_Print_By.DataBindings.Clear();

            checkBox_Supp.DataBindings.Clear();

            dt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            DataTable cytoTypeDt = new DataTable();
            cytoTypeDt.Columns.Add("cytoType");
            cytoTypeDt.Rows.Add(new object[] { "F" });
            cytoTypeDt.Rows.Add(new object[] { "N" });
            cytoTypeDt.Rows.Add(new object[] { "G" });
            cytoTypeDt.Rows.Add(new object[] { "HS" });
            cytoTypeDt.Rows.Add(new object[] { "HQ" });

            comboBox_cytoType.DataSource = cytoTypeDt;

            string classSql = "SELECT [class_code],[class_name] FROM [sth_charge_classes] ORDER BY class_id";
            DataSet classDataSet = new DataSet();
            SqlDataAdapter classDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(classSql, classDataSet, "sth_charge_classes");

            DataTable classDt = new DataTable();
            classDt.Columns.Add("classCode");
            classDt.Columns.Add("className");
            foreach (DataRow mDr in classDataSet.Tables["sth_charge_classes"].Rows)
            {
                classDt.Rows.Add(new object[] { mDr["class_code"].ToString().Trim(), mDr["class_name"].ToString().Trim() });
            }

            comboBox_Class.DataSource = classDt;

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

            string ethnicSql = "SELECT PEOPLE FROM [ethnic] order by people ";
            DataSet ethnicDataSet = new DataSet();
            SqlDataAdapter ethnicDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(ethnicSql, ethnicDataSet, "ethnic");

            DataTable ethnicDt = new DataTable();
            ethnicDt.Columns.Add("PEOPLE");

            foreach (DataRow mDr in ethnicDataSet.Tables["ethnic"].Rows)
            {
                ethnicDt.Rows.Add(new object[] { mDr["PEOPLE"] });
            }

            comboBox_Ethnic.DataSource = ethnicDt;

            string doctorSql1 = "SELECT doctor FROM [sign_doctor] order by doctor";
            doctorDataSet1 = new DataSet();
            doctorDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql1, doctorDataSet1, "sign_doctor");

            DataTable doctorDt1 = new DataTable();
            doctorDt1.Columns.Add("doctor");

            foreach (DataRow mDr in doctorDataSet1.Tables["sign_doctor"].Rows)
            {
                doctorDt1.Rows.Add(new object[] { mDr["doctor"] });
            }

            comboBox_Sign_By_Dr_1.DataSource = doctorDt1;

            string doctorSql2 = "SELECT doctor FROM [sign_doctor] order by doctor";
            doctorDataSet2 = new DataSet();
            doctorDataAdapter2 = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql2, doctorDataSet2, "sign_doctor");

            DataTable doctorDt2 = new DataTable();
            doctorDt2.Columns.Add("doctor");

            foreach (DataRow mDr in doctorDataSet1.Tables["sign_doctor"].Rows)
            {
                doctorDt2.Rows.Add(new object[] { mDr["doctor"] });
            }

            comboBox_Sign_By_Dr_2.DataSource = doctorDt2;

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
            textBox_Patient_s_Clinical_History.DataBindings.Add("Text", dt, "Pat_hist", false);

            textBox_Surgical.DataBindings.Add("Text", dt, "surgical", false, DataSourceUpdateMode.OnPropertyChanged, "");
            textBox_Nature.DataBindings.Add("Text", dt, "nature", false, DataSourceUpdateMode.OnPropertyChanged, "");

            textBox_Client.DataBindings.Add("Text", dt, "CLIENT", false);
            textBox_Institute.DataBindings.Add("Text", dt, "Institute", false);
            textBox_Ref_No.DataBindings.Add("Text", dt, "LAB_REF", false);
            textBox_Dr_I_C_Free_Text.DataBindings.Add("Text", dt, "DOCTOR_O", false);

            textBox_Doctor_I_C.DataBindings.Add("Text", dt, "DOCTOR_IC", false);
            textBox_Doctor_I_C_ID_1.DataBindings.Add("Text", dt, "doctor_id", false);

            textBox_Doctor_I_C_2.DataBindings.Add("Text", dt, "doctor_ic2", false);
            textBox_Doctor_I_C_ID_2.DataBindings.Add("Text", dt, "doctor_id2", false);

            textBox_Doctor_I_C_3.DataBindings.Add("Text", dt, "doctor_ic3", false);
            textBox_Doctor_I_C_ID_3.DataBindings.Add("Text", dt, "doctor_id3", false);

            textBox_Involce_No.DataBindings.Add("Text", dt, "Inv_no", false);
            textBox_Receipt.DataBindings.Add("Text", dt, "RECEIPT", false);

            textBox_Invoice_Date.DataBindings.Add("Text", dt, "INV_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");
            textBox_Amount_HK.DataBindings.Add("Text", dt, "INV_AMT", false);
            textBox_Paid_Up.DataBindings.Add("Text", dt, "PAY_UP", false);
            textBox_Paid_Date.DataBindings.Add("Text", dt, "PAY_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy");

            textBox_Rpt_Date.DataBindings.Add("Text", dt, "Rpt_date", false);

            comboBox_Snop_T1.DataBindings.Add("SelectedValue", dt, "snopcode_t", false);
            comboBox_Snop_T2.DataBindings.Add("SelectedValue", dt, "snopcode_t2", false);
            comboBox_Snop_T3.DataBindings.Add("SelectedValue", dt, "snopcode_t3", false);
            comboBox_Sign_By_Dr_1.DataBindings.Add("Text", dt, "Sign_dr", false);
            comboBox_Snop_M1.DataBindings.Add("SelectedValue", dt, "Snopcode_m", false);
            comboBox_Snop_M2.DataBindings.Add("SelectedValue", dt, "Snopcode_m2", false);
            comboBox_Snop_M3.DataBindings.Add("SelectedValue", dt, "Snopcode_m3", false);
            comboBox_Sign_By_Dr_2.DataBindings.Add("Text", dt, "Sign_dr2", false);
            comboBox_HistoType.DataBindings.Add("SelectedValue", dt, "Histo", false);

            textBox_Remarks.DataBindings.Add("Text", dt, "Remark", false);
            textBox_Cytology.DataBindings.Add("Text", dt, "initial", false);

            textBox_Updated_By_1.DataBindings.Add("Text", dt, "update_by", false);

            textBox_Updated_At.DataBindings.Add("Text", dt, "update_at", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy HH:mm:ss");
            textBox_Issued_By.DataBindings.Add("Text", dt, "issue_by", false);
            textBox_Issued_At.DataBindings.Add("Text", dt, "issue_at", true, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy HH:mm:ss");

            textBox_ER.DataBindings.Add(new Binding("Text", dt, "er"));
            textBox_EM.DataBindings.Add("Text", dt, "em", false);
            textBox_SISH.DataBindings.Add("Text", dt, "sish", false);

            checkBox_F_S.DataBindings.Add("Checked", dt, "fz_section", false);
            textBox_FZDetail.DataBindings.Add("Text", dt, "fz_detail", false);
            label_Printed.DataBindings.Add("Text", dt, "print_ctr", false);
            checkBox_Uploaded.DataBindings.Add("Checked", dt, "uploaded", false);

            label_Version.DataBindings.Add("Text", dt, "update_ctr", false);

            label_Print_At.DataBindings.Add("Text", dt, "print_at", false);
            label_Print_By.DataBindings.Add("Text", dt, "print_by", false);

            checkBox_Supp.DataBindings.Add("Checked", dt, "supp", false);

            /*currencyManager = (CurrencyManager)this.BindingContext[dt];
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
            }*/

            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());

            setPreviousRecordMark();

            if (checkBox_F_S.Checked)
            {
                button_F_S_Detail.Enabled = true;
            }
            else
            {
                button_F_S_Detail.Enabled = false;
            }

            reloadDiagData();
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
            Form_CytologyFindings open = new Form_CytologyFindings(textBox_Case_No.Text.Trim(), textBox_ID.Text.Trim());
            open.OnBxcyDiagExit += OnRefreshReturn;
            open.Show();
        }

        private void OnRefreshReturn()
        {
            reloadAndBindingDBData(0, textBox_Case_No.Text.Trim());
        }

        private void button_F_S_Detail_Click(object sender, EventArgs e)
        {
            Form_FrozenSection open = new Form_FrozenSection(textBox_FZDetail.Text.Trim());
            open.OnNatureSelectedSingle += onFZDetailValueChange;
            open.Show();
        }

        private void onFZDetailValueChange(string val)
        {
            if (val != null)
            {
                textBox_FZDetail.Text = val;
                textBox_FZDetail.Focus();
                textBox_FZDetail.Select(textBox_FZDetail.TextLength, 0);
                textBox_FZDetail.ScrollToCaret();
            }
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
                        textBox_DOB.Text = recordDate.ToString("dd/MM/yyyy");
                    }
                    textBox_Age.Text = reader.GetValue(5).ToString();
                    textBox_Sex.Text = reader.GetValue(6).ToString();
                }
                reader.Close();
            }
        }

        private void button_F2_Previous_Click(object sender, EventArgs e)
        {
            Form_PrevoiusCasesCondition open = new Form_PrevoiusCasesCondition(textBox_HKID.Text.Trim(), textBox_ID.Text.Trim());
            open.setBxcyDetailFileForm(this);
            open.setCurrentStatus(currentStatus);
            //open.OnBxcySpecimentSelectedSingle += OnBxcySpecimentSelected;
            open.Show();
        }

        private void OnBxcySpecimentSelected(string idStr)
        {
            if (idStr != null)
            {
                this.id = idStr;
                reloadAndBindingDBData();
                setButtonStatus(PageStatus.STATUS_VIEW);
            }
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
        /*
        private void button_F3m()
        {
            Form_SurgicalProcedure open = new Form_SurgicalProcedure();
            open.Show();
        }*/

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
        /*private void button_F4m()
        {
            Form_NatureOfSpecimen open = new Form_NatureOfSpecimen();
            open.Show();
        }*/
        private void button_F5_Description_Click(object sender, EventArgs e)
        {
            //Form_Description open = new Form_Description(textBox_Case_No.Text.Trim(), textBox_ID.Text.Trim(), currentStatus, comboBox_Snop_T1.SelectedValue, comboBox_Snop_T2.SelectedValue, comboBox_Snop_T3.SelectedValue, comboBox_Snop_M1.SelectedValue, comboBox_Snop_M2.SelectedValue, comboBox_Snop_M3.SelectedValue, textBox_Patient.Text.Trim(), textBox_HKID.Text.Trim(), isNewPatient, existDiagDataSet);
            Form_Description open = new Form_Description(textBox_Case_No.Text.Trim(), textBox_ID.Text.Trim(), currentStatus, textBox_Patient.Text.Trim(), textBox_HKID.Text.Trim(), isNewPatient, bxcy_specimenDataSet, existDiagDataSet, existDiagDataAdapter);
            open.OnBxcyDiagExit += OnStatusReturn;
            //open.OnBxcyDiagSaveBoth += onBxcyDiagSaveBoth;
            if (currentStatus != PageStatus.STATUS_EDIT)
            {
                open.setReadOnly(readOnly);
            }
            
            open.Show();
            open.shiftFocusToMarco();
        }

        private void OnStatusReturn(int status, bool refresh, DataSet existDiagDataSet, SqlDataAdapter existDiagDataAdapter, DataTable dtToDelete, Object snopT1, Object snopT2, Object snopT3, Object snopM1, Object snopM2, Object snopM3, bool readOnly)
        {
            this.existDiagDataSet = existDiagDataSet;
            this.existDiagDataAdapter = existDiagDataAdapter;
            this.dtToDelete = dtToDelete;
            //this.bxcy_specimenDataSet = existBxcySpecimentDataSet;
            if (refresh)
            {
                reloadAndBindingDBData(0, textBox_Case_No.Text.Trim());
            }
            if (currentStatus != PageStatus.STATUS_NEW)
            {
                currentStatus = status;
            }
            setButtonStatus(currentStatus);
            if (readOnly)
            {
                this.disableEdit();
            }

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
        }

        private int onBxcyDiagSaveBoth(Object snopT1, Object snopT2, Object snopT3, Object snopM1, Object snopM2, Object snopM3)
        {
            return saveDataWithSnopCode(snopT1, snopT2, snopT3, snopM1, snopM2, snopM3);
        }

        private void button_F7_Click(object sender, EventArgs e)
        {
            Form_SelectClient open = new Form_SelectClient();
            open.OnClientSelected += OnClientSelected;
            open.Show();
        }

        private void OnClientSelected(string str, string idStr)
        {
            if (str != null)
            {
                if(textBox_Client.Text.Trim() != str)
                {
                    textBox_Client.Text = str;
                    if (str == DEFAULT_CLIENT)
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dt.Rows[0]["PRICE_BX"] = DBNull.Value;
                            dt.Rows[0]["PRICE_CORE_BX"] = DBNull.Value;
                            dt.Rows[0]["PRICE_CY"] = DBNull.Value;
                            dt.Rows[0]["PRICE_CY_NONGYNAE"] = DBNull.Value;
                            dt.Rows[0]["PRICE_CY_FNA"] = DBNull.Value;
                            dt.Rows[0]["PRICE_EBV"] = DBNull.Value;
                            dt.Rows[0]["PRICE_CYG"] = DBNull.Value;

                            dt.Rows[0]["chargeOther"] = DBNull.Value;
                            dt.Rows[0]["chargeTotal"] = DBNull.Value;
                        }
                    }
                    else
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dt.Rows[0]["classId"] = DBNull.Value;

                            dt.Rows[0]["codeId1"] = DBNull.Value;
                            dt.Rows[0]["codeId2"] = DBNull.Value;
                            dt.Rows[0]["codeId3"] = DBNull.Value;
                            dt.Rows[0]["codeId4"] = DBNull.Value;
                            dt.Rows[0]["codeId5"] = DBNull.Value;
                            dt.Rows[0]["codeId6"] = DBNull.Value;
                            dt.Rows[0]["codeId7"] = DBNull.Value;
                            dt.Rows[0]["codeId8"] = DBNull.Value;
                            dt.Rows[0]["codeId9"] = DBNull.Value;
                            dt.Rows[0]["codeId10"] = DBNull.Value;

                            dt.Rows[0]["charge1"] = DBNull.Value;
                            dt.Rows[0]["charge2"] = DBNull.Value;
                            dt.Rows[0]["charge3"] = DBNull.Value;
                            dt.Rows[0]["charge4"] = DBNull.Value;
                            dt.Rows[0]["charge5"] = DBNull.Value;
                            dt.Rows[0]["charge6"] = DBNull.Value;
                            dt.Rows[0]["charge7"] = DBNull.Value;
                            dt.Rows[0]["charge8"] = DBNull.Value;
                            dt.Rows[0]["charge9"] = DBNull.Value;
                            dt.Rows[0]["charge10"] = DBNull.Value;

                            dt.Rows[0]["chargeOther"] = DBNull.Value;
                            dt.Rows[0]["chargeTotal"] = DBNull.Value;

                            string clientSql = string.Format("SELECT * FROM [client] WHERE [id] = {0}", idStr);
                            DataSet clientDataSet = new DataSet();
                            SqlDataAdapter clientDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(clientSql, clientDataSet, "client");

                            if(clientDataSet != null)
                            {
                                DataTable clientDt = clientDataSet.Tables["client"];
                                if(clientDt != null && clientDt.Rows.Count > 0)
                                {
                                    if (clientDt.Rows[0]["PRICE_BX"] != null) dt.Rows[0]["PRICE_BX"] = clientDt.Rows[0]["PRICE_BX"];
                                    if (clientDt.Rows[0]["PRICE_CORE_BX"] != null) dt.Rows[0]["PRICE_CORE_BX"] = clientDt.Rows[0]["PRICE_CORE_BX"];
                                    if (clientDt.Rows[0]["PRICE_CY"] != null) dt.Rows[0]["PRICE_CY"] = clientDt.Rows[0]["PRICE_CY"];
                                    if (clientDt.Rows[0]["PRICE_CY_NONGYNAE"] != null) dt.Rows[0]["PRICE_CY_NONGYNAE"] = clientDt.Rows[0]["PRICE_CY_NONGYNAE"];
                                    if (clientDt.Rows[0]["PRICE_CY_FNA"] != null) dt.Rows[0]["PRICE_CY_FNA"] = clientDt.Rows[0]["PRICE_CY_FNA"];
                                    if (clientDt.Rows[0]["PRICE_EBV"] != null) dt.Rows[0]["PRICE_EBV"] = clientDt.Rows[0]["PRICE_EBV"];
                                    if (clientDt.Rows[0]["PRICE_CYG"] != null) dt.Rows[0]["PRICE_CYG"] = clientDt.Rows[0]["PRICE_CYG"];

                                    dt.Rows[0]["PRICE_BX_GRADE"] = DBNull.Value;
                                    dt.Rows[0]["PRICE_CORE_BX_GRADE"] = DBNull.Value;
                                    dt.Rows[0]["PRICE_CY_GRADE"] = DBNull.Value;
                                    dt.Rows[0]["PRICE_CY_NONGYNAE_GRADE"] = DBNull.Value;
                                    dt.Rows[0]["PRICE_CY_FNA_GRADE"] = DBNull.Value;
                                    dt.Rows[0]["PRICE_EBV_GRADE"] = DBNull.Value;
                                    dt.Rows[0]["PRICE_CYG_GRADE"] = DBNull.Value;

                                    dt.Rows[0]["chargeOther"] = DBNull.Value;
                                    dt.Rows[0]["chargeTotal"] = DBNull.Value;
                                }
                            } 
                        }
                    }
                }
                
                textBox_Institute.Text = str;

                textBox_Client.Focus();
                textBox_Client.Select(textBox_Client.TextLength, 0);
                textBox_Client.ScrollToCaret();

                textBox_Institute.Focus();
                textBox_Institute.Select(textBox_Institute.TextLength, 0);
                textBox_Institute.ScrollToCaret();
            }
        }

        private void button_F8_Click(object sender, EventArgs e)
        {
            Form_SelectClientInstitute open = new Form_SelectClientInstitute();
            open.OnClientInstituteSelectedSingle += OnClientInstituteSelected;
            open.Show();
        }

        private void OnClientInstituteSelected(string str)
        {
            if (str != null)
            {
                textBox_Institute.Text = str;

                textBox_Institute.Focus();
                textBox_Institute.Select(textBox_Institute.TextLength, 0);
                textBox_Institute.ScrollToCaret();
            }
        }

        private void button_F8m()
        {
            Form_SelectClientInstitute open = new Form_SelectClientInstitute();
            open.Show();
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

                textBox_Doctor_I_C.Focus();
                textBox_Doctor_I_C.Select(0, 0);
                textBox_Doctor_I_C.ScrollToCaret();
            }

            if (doctroIdStr != null)
            {
                textBox_Doctor_I_C_ID_1.Text = doctroIdStr;

                textBox_Doctor_I_C_ID_1.Focus();
                textBox_Doctor_I_C_ID_1.Select(0, 0);
                textBox_Doctor_I_C_ID_1.ScrollToCaret();
            }
        }

        private void button_F9_2_Click(object sender, EventArgs e)
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.OnDoctorSelectedWithNameAndId += OnDoctorSelected2;
            open.Show();
        }

        private void OnDoctorSelected2(string doctorNameStr, string doctroIdStr)
        {
            if (doctorNameStr != null)
            {
                textBox_Doctor_I_C_2.Text = doctorNameStr;

                textBox_Doctor_I_C_2.Focus();
                textBox_Doctor_I_C_2.Select(0, 0);
                textBox_Doctor_I_C_2.ScrollToCaret();
            }

            if (doctroIdStr != null)
            {
                textBox_Doctor_I_C_ID_2.Text = doctroIdStr;

                textBox_Doctor_I_C_ID_2.Focus();
                textBox_Doctor_I_C_ID_2.Select(0, 0);
                textBox_Doctor_I_C_ID_2.ScrollToCaret();
            }
        }

        private void button_F9_3_Click(object sender, EventArgs e)
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.OnDoctorSelectedWithNameAndId += OnDoctorSelected3;
            open.Show();
        }

        private void OnDoctorSelected3(string doctorNameStr, string doctroIdStr)
        {
            if (doctorNameStr != null)
            {
                textBox_Doctor_I_C_3.Text = doctorNameStr;

                textBox_Doctor_I_C_3.Focus();
                textBox_Doctor_I_C_3.Select(0, 0);
                textBox_Doctor_I_C_3.ScrollToCaret();
            }

            if (doctroIdStr != null)
            {
                textBox_Doctor_I_C_ID_3.Text = doctroIdStr;

                textBox_Doctor_I_C_ID_3.Focus();
                textBox_Doctor_I_C_ID_3.Select(0, 0);
                textBox_Doctor_I_C_ID_3.ScrollToCaret();
            }
        }

        private void button_F11_Add_test_Click(object sender, EventArgs e)
        {
            button_F11m();
        }
        private void button_F11m()
        {
            Form_AdditionalTests open = new Form_AdditionalTests(textBox_ER.Text.Trim(), textBox_EM.Text.Trim(), textBox_SISH.Text.Trim());
            open.OnValueUpdated += onAdditionalTestValueUpdated;
            open.Show();
        }

        private void onAdditionalTestValueUpdated(string er, string em, string sish)
        {
            if (er != null)
            {
                textBox_ER.Text = er;
                textBox_ER.Focus();
                textBox_ER.Select(textBox_ER.TextLength, 0);
                textBox_ER.ScrollToCaret();
            }

            if (em != null)
            {
                textBox_EM.Text = em;
                textBox_EM.Focus();
                textBox_EM.Select(textBox_EM.TextLength, 0);
                textBox_EM.ScrollToCaret();
            }

            if (sish != null)
            {
                textBox_SISH.Text = sish;
                textBox_SISH.Focus();
                textBox_SISH.Select(textBox_SISH.TextLength, 0);
                textBox_SISH.ScrollToCaret();
            }
        }

        private void button_CY_Report_Detail_Click(object sender, EventArgs e)
        {
            Form_CYReportMaintenance open = new Form_CYReportMaintenance();
            open.Show();
        }

        private void button_Fee_Click(object sender, EventArgs e)
        {
            if (textBox_Client.Text.Trim() == DEFAULT_CLIENT)
            {
                string classId = "";
                string codeId1 = "", codeId2 = "", codeId3 = "", codeId4 = "", codeId5 = "", codeId6 = "", codeId7 = "", codeId8 = "", codeId9 = "", codeId10 = "";
                string charge1 = "", charge2 = "", charge3 = "", charge4 = "", charge5 = "", charge6 = "", charge7 = "", charge8 = "", charge9 = "", charge10 = "";
                string chargeOther = "", chargeTotal = "";

                if(dt != null && dt.Rows.Count > 0)
                {
                    classId = dt.Rows[0]["classId"] == null ? "" : dt.Rows[0]["classId"].ToString();

                    codeId1 = dt.Rows[0]["codeId1"] == null ? "" : dt.Rows[0]["codeId1"].ToString();
                    codeId2 = dt.Rows[0]["codeId2"] == null ? "" : dt.Rows[0]["codeId2"].ToString();
                    codeId3 = dt.Rows[0]["codeId3"] == null ? "" : dt.Rows[0]["codeId3"].ToString();
                    codeId4 = dt.Rows[0]["codeId4"] == null ? "" : dt.Rows[0]["codeId4"].ToString();
                    codeId5 = dt.Rows[0]["codeId5"] == null ? "" : dt.Rows[0]["codeId5"].ToString();
                    codeId6 = dt.Rows[0]["codeId6"] == null ? "" : dt.Rows[0]["codeId6"].ToString();
                    codeId7 = dt.Rows[0]["codeId7"] == null ? "" : dt.Rows[0]["codeId7"].ToString();
                    codeId8 = dt.Rows[0]["codeId8"] == null ? "" : dt.Rows[0]["codeId8"].ToString();
                    codeId9 = dt.Rows[0]["codeId9"] == null ? "" : dt.Rows[0]["codeId9"].ToString();
                    codeId10 = dt.Rows[0]["codeId10"] == null ? "" : dt.Rows[0]["codeId10"].ToString();

                    charge1 = dt.Rows[0]["charge1"] == null ? null : dt.Rows[0]["charge1"].ToString();
                    charge2 = dt.Rows[0]["charge2"] == null ? null : dt.Rows[0]["charge2"].ToString();
                    charge3 = dt.Rows[0]["charge3"] == null ? null : dt.Rows[0]["charge3"].ToString();
                    charge4 = dt.Rows[0]["charge4"] == null ? null : dt.Rows[0]["charge4"].ToString();
                    charge5 = dt.Rows[0]["charge5"] == null ? null : dt.Rows[0]["charge5"].ToString();
                    charge6 = dt.Rows[0]["charge6"] == null ? null : dt.Rows[0]["charge6"].ToString();
                    charge7 = dt.Rows[0]["charge7"] == null ? null : dt.Rows[0]["charge7"].ToString();
                    charge8 = dt.Rows[0]["charge8"] == null ? null : dt.Rows[0]["charge8"].ToString();
                    charge9 = dt.Rows[0]["charge9"] == null ? null : dt.Rows[0]["charge9"].ToString();
                    charge10 = dt.Rows[0]["charge10"] == null ? null : dt.Rows[0]["charge10"].ToString();

                    chargeOther = dt.Rows[0]["chargeOther"] == null ? null : dt.Rows[0]["chargeOther"].ToString();
                    chargeTotal = dt.Rows[0]["chargeTotal"] == null ? null : dt.Rows[0]["chargeTotal"].ToString();
                }
                //classId = dt
                Form_FeeCalculationSTH open = new Form_FeeCalculationSTH(classId, codeId1, codeId2, codeId3, codeId4, codeId5, codeId6, codeId7, codeId8, codeId9, codeId10,
                    charge1, charge2, charge3, charge4, charge5, charge6, charge7, charge8, charge9, charge10,
                    chargeOther, chargeTotal);
                open.OnFeeCalculationConfirm += FeeReturn;
                open.Show();
            }
            else
            {
                string priceBXGrade = "", priceCoreBXGrade = "", priceCYGrade = "", priceCYNongynaeGrade = "", priceCYFNAGrade = "", priceEBVGrade = "", priceCYGGrade = "";
                string priceBX = "", priceCoreBX = "", priceCY = "", priceCYNongynae = "", priceCYFNA = "", priceEBV = "", priceCYG = "";
                string chargeOther = "", chargeTotal = "";

                if (dt != null && dt.Rows.Count > 0)
                {
                    priceBXGrade = dt.Rows[0]["PRICE_BX_GRADE"] == null ? "" : dt.Rows[0]["PRICE_BX_GRADE"].ToString();
                    priceCoreBXGrade = dt.Rows[0]["PRICE_CORE_BX_GRADE"] == null ? "" : dt.Rows[0]["PRICE_CORE_BX_GRADE"].ToString();
                    priceCYGrade = dt.Rows[0]["PRICE_CY_GRADE"] == null ? "" : dt.Rows[0]["PRICE_CY_GRADE"].ToString();
                    priceCYNongynaeGrade = dt.Rows[0]["PRICE_CY_NONGYNAE_GRADE"] == null ? "" : dt.Rows[0]["PRICE_CY_NONGYNAE_GRADE"].ToString();
                    priceCYFNAGrade = dt.Rows[0]["PRICE_CY_FNA_GRADE"] == null ? "" : dt.Rows[0]["PRICE_CY_FNA_GRADE"].ToString();
                    priceEBVGrade = dt.Rows[0]["PRICE_EBV_GRADE"] == null ? "" : dt.Rows[0]["PRICE_EBV_GRADE"].ToString();
                    priceCYGGrade = dt.Rows[0]["PRICE_CYG_GRADE"] == null ? "" : dt.Rows[0]["PRICE_CYG_GRADE"].ToString();

                    priceBX = dt.Rows[0]["PRICE_BX"] == null ? "" : dt.Rows[0]["PRICE_BX"].ToString();
                    priceCoreBX = dt.Rows[0]["PRICE_CORE_BX"] == null ? "" : dt.Rows[0]["PRICE_CORE_BX"].ToString();
                    priceCY = dt.Rows[0]["PRICE_CY"] == null ? "" : dt.Rows[0]["PRICE_CY"].ToString();
                    priceCYNongynae = dt.Rows[0]["PRICE_CY_NONGYNAE"] == null ? "" : dt.Rows[0]["PRICE_CY_NONGYNAE"].ToString();
                    priceCYFNA = dt.Rows[0]["PRICE_CY_FNA"] == null ? "" : dt.Rows[0]["PRICE_CY_FNA"].ToString();
                    priceEBV = dt.Rows[0]["PRICE_EBV"] == null ? "" : dt.Rows[0]["PRICE_EBV"].ToString();
                    priceCYG = dt.Rows[0]["PRICE_CYG"] == null ? "" : dt.Rows[0]["PRICE_CYG"].ToString();

                    chargeOther = dt.Rows[0]["chargeOther"] == null ? null : dt.Rows[0]["chargeOther"].ToString();
                    chargeTotal = dt.Rows[0]["chargeTotal"] == null ? null : dt.Rows[0]["chargeTotal"].ToString();
                }
                //classId = dt
                Form_FeeCalculationPrivate open = new Form_FeeCalculationPrivate(priceBXGrade, priceCoreBXGrade, priceCYGrade, priceCYNongynaeGrade, priceCYFNAGrade, priceEBVGrade, priceCYGGrade,
                    priceBX, priceCoreBX, priceCY, priceCYNongynae, priceCYFNA, priceEBV, priceCYG,
                    chargeOther, chargeTotal);
                open.OnFeeCalculationPrivateConfirm += FeePrivateReturn;
                open.Show();
            }

        }

        private void FeeReturn(string classId, string codeId1, string codeId2, string codeId3, string codeId4, string codeId5, string codeId6, string codeId7, string codeId8, string codeId9, string codeId10,
            string charge1, string charge2, string charge3, string charge4, string charge5, string charge6, string charge7, string charge8, string charge9, string charge10,
            string chargeOther, string chargeTotal)
        {
            decimal? price1 = null;
            decimal? price2 = null;
            decimal? price3 = null;
            decimal? price4 = null;
            decimal? price5 = null;
            decimal? price6 = null;
            decimal? price7 = null;
            decimal? price8 = null;
            decimal? price9 = null;
            decimal? price10 = null;

            decimal? priceOther = null;
            decimal? totalPrice = null;

            decimal price = 0;
            if(decimal.TryParse(charge1, out price))
            {
                price1 = price;
            }

            price = 0;
            if (decimal.TryParse(charge2, out price))
            {
                price2 = price;
            }

            price = 0;
            if (decimal.TryParse(charge3, out price))
            {
                price3 = price;
            }

            price = 0;
            if (decimal.TryParse(charge4, out price))
            {
                price4 = price;
            }

            price = 0;
            if (decimal.TryParse(charge5, out price))
            {
                price5 = price;
            }

            price = 0;
            if (decimal.TryParse(charge6, out price))
            {
                price6 = price;
            }

            price = 0;
            if (decimal.TryParse(charge7, out price))
            {
                price7 = price;
            }

            price = 0;
            if (decimal.TryParse(charge8, out price))
            {
                price8 = price;
            }

            price = 0;
            if (decimal.TryParse(charge9, out price))
            {
                price9 = price;
            }

            price = 0;
            if (decimal.TryParse(charge10, out price))
            {
                price10 = price;
            }

            price = 0;
            if (decimal.TryParse(chargeOther, out price))
            {
                priceOther = price;
            }

            price = 0;
            if (decimal.TryParse(chargeTotal, out price))
            {
                totalPrice = price;
            }

            int intCodeId1 = 0;
            int intCodeId2 = 0;
            int intCodeId3 = 0;
            int intCodeId4 = 0;
            int intCodeId5 = 0;
            int intCodeId6 = 0;
            int intCodeId7 = 0;
            int intCodeId8 = 0;
            int intCodeId9 = 0;
            int intCodeId10 = 0;

            int intClassId = 0;

            int.TryParse(codeId1, out intCodeId1);
            int.TryParse(codeId2, out intCodeId2);
            int.TryParse(codeId3, out intCodeId3);
            int.TryParse(codeId4, out intCodeId4);
            int.TryParse(codeId5, out intCodeId5);
            int.TryParse(codeId6, out intCodeId6);
            int.TryParse(codeId7, out intCodeId7);
            int.TryParse(codeId8, out intCodeId8);
            int.TryParse(codeId9, out intCodeId9);
            int.TryParse(codeId10, out intCodeId10);

            int.TryParse(classId, out intClassId);

            if (dt != null && dt.Rows.Count > 0)
            {
                if(intClassId != 0) dt.Rows[0]["classId"] = intClassId;

                if (intCodeId1 != 0) dt.Rows[0]["codeId1"] = intCodeId1;
                if (intCodeId2 != 0) dt.Rows[0]["codeId2"] = intCodeId2;
                if (intCodeId3 != 0) dt.Rows[0]["codeId3"] = intCodeId3;
                if (intCodeId4 != 0) dt.Rows[0]["codeId4"] = intCodeId4;
                if (intCodeId5 != 0) dt.Rows[0]["codeId5"] = intCodeId5;
                if (intCodeId6 != 0) dt.Rows[0]["codeId6"] = intCodeId6;
                if (intCodeId7 != 0) dt.Rows[0]["codeId7"] = intCodeId7;
                if (intCodeId8 != 0) dt.Rows[0]["codeId8"] = intCodeId8;
                if (intCodeId9 != 0) dt.Rows[0]["codeId9"] = intCodeId9;
                if (intCodeId10 != 0) dt.Rows[0]["codeId10"] = intCodeId10;

                if (price1 != null) dt.Rows[0]["charge1"] = price1;
                if (price2 != null) dt.Rows[0]["charge2"] = price2;
                if (price3 != null) dt.Rows[0]["charge3"] = price3;
                if (price4 != null) dt.Rows[0]["charge4"] = price4;
                if (price5 != null) dt.Rows[0]["charge5"] = price5;
                if (price6 != null) dt.Rows[0]["charge6"] = price6;
                if (price7 != null) dt.Rows[0]["charge7"] = price7;
                if (price8 != null) dt.Rows[0]["charge8"] = price8;
                if (price9 != null) dt.Rows[0]["charge9"] = price9;
                if (price10 != null) dt.Rows[0]["charge10"] = price10;

                if (priceOther != null) dt.Rows[0]["chargeOther"] = priceOther;
                if (totalPrice != null)
                {
                    dt.Rows[0]["chargeTotal"] = totalPrice;
                    textBox_Amount_HK.Text = totalPrice.ToString();
                }
                else
                {
                    textBox_Amount_HK.Text = "";
                }
            }
        }

        private void FeePrivateReturn(string priceBXGrade, string priceCoreBXGrade, string priceCYGrade, string priceCYNongynaeGrade, string priceCYFNAGrade, string priceEBVGrade, string priceCYGGrade,
            string priceBX, string priceCoreBX, string priceCY, string priceCYNongynae, string priceCYFNA, string priceEBV, string priceCYG,
            string chargeOther, string chargeTotal)
        {
            decimal? priceBXDec = null;
            decimal? priceCoreBXDec = null;
            decimal? priceCYDec = null;
            decimal? priceCYNongynaeDec = null;
            decimal? priceCYFNADec = null;
            decimal? priceEBVDec = null;
            decimal? priceCYGDec = null;

            decimal? priceOther = null;
            decimal? totalPrice = null;

            decimal price = 0;
            if (decimal.TryParse(priceBX, out price))
            {
                priceBXDec = price;
            }

            price = 0;
            if (decimal.TryParse(priceCoreBX, out price))
            {
                priceCoreBXDec = price;
            }

            price = 0;
            if (decimal.TryParse(priceCY, out price))
            {
                priceCYDec = price;
            }

            price = 0;
            if (decimal.TryParse(priceCYNongynae, out price))
            {
                priceCYNongynaeDec = price;
            }

            price = 0;
            if (decimal.TryParse(priceCYFNA, out price))
            {
                priceCYFNADec = price;
            }

            price = 0;
            if (decimal.TryParse(priceEBV, out price))
            {
                priceEBVDec = price;
            }

            price = 0;
            if (decimal.TryParse(priceCYG, out price))
            {
                priceCYGDec = price;
            }

            price = 0;
            if (decimal.TryParse(chargeOther, out price))
            {
                priceOther = price;
            }

            price = 0;
            if (decimal.TryParse(chargeTotal, out price))
            {
                totalPrice = price;
            }

            int priceBXGradeInt = -1;
            int priceCoreBXGradeInt = -1;
            int priceCYGradeInt = -1;
            int priceCYNongynaeGradeInt = -1;
            int priceCYFNAGradeInt = -1;
            int priceEBVGradeInt = -1;
            int priceCYGGradeInt = -1;

            int.TryParse(priceBXGrade, out priceBXGradeInt);
            int.TryParse(priceCoreBXGrade, out priceCoreBXGradeInt);
            int.TryParse(priceCYGrade, out priceCYGradeInt);
            int.TryParse(priceCYNongynaeGrade, out priceCYNongynaeGradeInt);
            int.TryParse(priceCYFNAGrade, out priceCYFNAGradeInt);
            int.TryParse(priceEBVGrade, out priceEBVGradeInt);
            int.TryParse(priceCYGGrade, out priceCYGGradeInt);

            if (dt != null && dt.Rows.Count > 0)
            {
                if(priceBXGradeInt != -1) dt.Rows[0]["PRICE_BX_GRADE"] = priceBXGradeInt;
                if (priceCoreBXGradeInt != -1) dt.Rows[0]["PRICE_CORE_BX_GRADE"] = priceCoreBXGradeInt;
                if (priceCYGradeInt != -1) dt.Rows[0]["PRICE_CY_GRADE"] = priceCYGradeInt;
                if (priceCYNongynaeGradeInt != -1) dt.Rows[0]["PRICE_CY_NONGYNAE_GRADE"] = priceCYNongynaeGradeInt;
                if (priceCYFNAGradeInt != -1) dt.Rows[0]["PRICE_CY_FNA_GRADE"] = priceCYFNAGradeInt;
                if (priceCYGGradeInt != -1) dt.Rows[0]["PRICE_EBV_GRADE"] = priceEBVGradeInt;
                if (priceCYGGradeInt != -1) dt.Rows[0]["PRICE_CYG_GRADE"] = priceCYGGradeInt;

                if (priceBXDec != null) dt.Rows[0]["PRICE_BX"] = priceBXDec;
                if (priceCoreBXDec != null) dt.Rows[0]["PRICE_CORE_BX"] = priceCoreBXDec;
                if (priceCYDec != null) dt.Rows[0]["PRICE_CY"] = priceCYDec;
                if (priceCYNongynaeDec != null) dt.Rows[0]["PRICE_CY_NONGYNAE"] = priceCYNongynaeDec;
                if (priceCYFNADec != null) dt.Rows[0]["PRICE_CY_FNA"] = priceCYFNADec;
                if (priceEBVDec != null) dt.Rows[0]["PRICE_EBV"] = priceEBVDec;
                if (priceCYGDec != null) dt.Rows[0]["PRICE_CYG"] = priceCYGDec;

                if (priceOther != null) dt.Rows[0]["chargeOther"] = priceOther;
                if (totalPrice != null)
                {
                    dt.Rows[0]["chargeTotal"] = totalPrice;
                    textBox_Amount_HK.Text = totalPrice.ToString();
                }
                else
                {
                    textBox_Amount_HK.Text = "";
                }
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
            Form_ClinicalHistoryEditLog open = new Form_ClinicalHistoryEditLog(textBox_Case_No.Text.Trim());
            open.Show();
        }

        private void button_Amount_HK_Detail_Click(object sender, EventArgs e)
        {
            Form_STHDiagnosticAmount open = new Form_STHDiagnosticAmount();
            open.Show();
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            //currencyManager.Position++;
            string countSql = string.Format(" [bxcy_specimen] WHERE (case_no = '{0}' and id > {1}) or case_no > '{0}'", textBox_Case_No.Text.Trim(), textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string selectOneSql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE ((case_no = '{0}' and id > {1}) or case_no > '{0}') ORDER BY  case_no,id", textBox_Case_No.Text.Trim(), textBox_ID.Text);
                DataSet selectOneDataSet = new DataSet();
                SqlDataAdapter selectOneDataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, selectOneDataSet, "bxcy_specimen");
                if (selectOneDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
                {
                    string selectOneCaseNo = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["case_no"].ToString();
                    string selectOnId = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["id"].ToString();

                    if (selectOneCaseNo == null || selectOneCaseNo.Trim() == "" || selectOneCaseNo.Trim().Length == 0)
                    {
                        //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] ORDER BY case_no,id");
                        dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                        button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                        setPreviousRecordMark();
                        reloadDiagData();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname(selectOnId);
                            open.Show();
                            this.Close();
                        }
                        else
                        {
                            if (selectOneCaseNo.Substring(0, 1).ToLower() == "d")
                            {
                                Form_BXeHRCCSPFile open = new Form_BXeHRCCSPFile(selectOnId);
                                open.Show();
                                this.Close();
                            }
                            else
                            {
                                //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY case_no,id");
                                dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                                button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                                setPreviousRecordMark();
                                reloadDiagData();
                            }
                        }
                    }
                }

                /*string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE ((case_no = '{0}' and id > {1}) or case_no > '{0}') ORDER BY  case_no,id", textBox_Case_No.Text.Trim(), textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

                button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                setPreviousRecordMark();
                reloadDiagData();*/
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            //currencyManager.Position--;
            string countSql = string.Format(" [bxcy_specimen] WHERE (case_no = '{0}' and id < {1}) or case_no < '{0}'", textBox_Case_No.Text.Trim(), textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string selectOneSql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE ((case_no = '{0}' and id < {1}) or case_no < '{0}') ORDER BY case_no DESC,id DESC", textBox_Case_No.Text.Trim(), textBox_ID.Text);
                DataSet selectOneDataSet = new DataSet();
                SqlDataAdapter selectOneDataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, selectOneDataSet, "bxcy_specimen");
                if (selectOneDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
                {
                    string selectOneCaseNo = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["case_no"].ToString();
                    string selectOnId = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["id"].ToString();

                    if (selectOneCaseNo == null || selectOneCaseNo.Trim() == "" || selectOneCaseNo.Trim().Length == 0)
                    {
                        //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] ORDER BY case_no,id");
                        dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                        button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                        setPreviousRecordMark();
                        reloadDiagData();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname(selectOnId);
                            open.Show();
                            this.Close();
                        }
                        else
                        {
                            if (selectOneCaseNo.Substring(0, 1).ToLower() == "d")
                            {
                                Form_BXeHRCCSPFile open = new Form_BXeHRCCSPFile(selectOnId);
                                open.Show();
                                this.Close();
                            }
                            else
                            {
                                //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY case_no,id");
                                dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                                button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                                setPreviousRecordMark();
                                reloadDiagData();
                            }
                        }
                    }
                }
                /*
                string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE ((case_no = '{0}' and id < {1}) or case_no < '{0}') AND case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY case_no DESC,id DESC", textBox_Case_No.Text.Trim(), textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

                button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                setPreviousRecordMark();
                reloadDiagData();*/
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            //currencyManager.Position = 0;
            string countSql = string.Format(" (SELECT top 1 case_no,id FROM [medlab].[dbo].[BXCY_SPECIMEN] order by case_no,id ) t1 WHERE t1.case_no <> '{0}' and t1.id <> {1}", textBox_Case_No.Text.Trim(), textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string selectOneSql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] ORDER BY case_no,id");
                DataSet selectOneDataSet = new DataSet();
                SqlDataAdapter selectOneDataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, selectOneDataSet, "bxcy_specimen");
                if(selectOneDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
                {
                    string selectOneCaseNo = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["case_no"].ToString();
                    string selectOnId = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["id"].ToString();

                    if (selectOneCaseNo == null || selectOneCaseNo.Trim() == "" || selectOneCaseNo.Trim().Length == 0)
                    {
                        //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] ORDER BY case_no,id");
                        dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                        button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                        setPreviousRecordMark();
                        reloadDiagData();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname(selectOnId);
                            open.Show();
                            this.Close();
                        }
                        else
                        {
                            if (selectOneCaseNo.Substring(0, 1).ToLower() == "d")
                            {
                                Form_BXeHRCCSPFile open = new Form_BXeHRCCSPFile(selectOnId);
                                open.Show();
                                this.Close();
                            }
                            else
                            {
                                //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY case_no,id");
                                dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                                button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                                setPreviousRecordMark();
                                reloadDiagData();
                            }
                        }
                    }
                } 
            }
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            //currencyManager.Position = currencyManager.Count - 1;
            string countSql = string.Format(" (SELECT top 1 case_no,id FROM [medlab].[dbo].[BXCY_SPECIMEN] order by case_no desc,id desc ) t1 WHERE t1.case_no <> '{0}' and t1.id <> {1}", textBox_Case_No.Text.Trim(), textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string selectOneSql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen]  ORDER BY case_no DESC,id DESC");
                DataSet selectOneDataSet = new DataSet();
                SqlDataAdapter selectOneDataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, selectOneDataSet, "bxcy_specimen");
                if (selectOneDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
                {
                    string selectOneCaseNo = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["case_no"].ToString();
                    string selectOnId = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["id"].ToString();

                    if (selectOneCaseNo == null || selectOneCaseNo.Trim() == "" || selectOneCaseNo.Trim().Length == 0)
                    {
                        //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] ORDER BY case_no,id");
                        dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                        button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                        setPreviousRecordMark();
                        reloadDiagData();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname(selectOnId);
                            open.Show();
                            this.Close();
                        }
                        else
                        {
                            if (selectOneCaseNo.Substring(0, 1).ToLower() == "d")
                            {
                                Form_BXeHRCCSPFile open = new Form_BXeHRCCSPFile(selectOnId);
                                open.Show();
                                this.Close();
                            }
                            else
                            {
                                //string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY case_no,id");
                                dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                                button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                                setPreviousRecordMark();
                                reloadDiagData();
                            }
                        }
                    }
                }
                /*
                string sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no NOT LIKE '%G' AND case_no NOT LIKE 'D%' ORDER BY case_no DESC,id DESC");
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_specimenDataSet, "bxcy_specimen");

                button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                setPreviousRecordMark();
                reloadDiagData();*/
            }
        }

        public bool checkDuplicateHKID()
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
                    result = true;
                    MessageBox.Show("Duplicate Patient's name and HKID, unable to save");
                }

            }

            return result;
        }

        public bool checkDuplicateCaseNo()
        {
            bool result = false;

            DataSet checkBxcy_specimenDataSet = new DataSet();
            SqlDataAdapter checkdataAdapter;
            string checkSql = string.Format("SELECT * FROM [bxcy_specimen] WHERE case_no = '{0}'", textBox_Case_No.Text.Trim());
            checkdataAdapter = DBConn.fetchDataIntoDataSet(checkSql, checkBxcy_specimenDataSet, "bxcy_specimen");

            if (checkBxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
            {
                result = true;
                MessageBox.Show("Duplicate case no., unable to save");
            }

            return result;
        }

        public bool checkDuplicateCaseNoWithUpdate()
        {
            bool result = false;

            DataSet checkBxcy_specimenDataSet = new DataSet();
            SqlDataAdapter checkdataAdapter;
            string checkSql = string.Format("SELECT * FROM [bxcy_specimen] WHERE case_no = '{0}' AND id <> {1}", textBox_Case_No.Text.Trim(), textBox_ID.Text.Trim());
            checkdataAdapter = DBConn.fetchDataIntoDataSet(checkSql, checkBxcy_specimenDataSet, "bxcy_specimen");

            if (checkBxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
            {
                result = true;
                MessageBox.Show("Duplicate case no., unable to save");
            }

            return result;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(textBox_Case_No.Text == "")
            {
                MessageBox.Show("Please input case no.");
                textBox_Case_No.Focus();
                return;
            }

            if (textBox_Case_No.Text.Trim().Substring(textBox_Case_No.Text.Trim().Length - 1, 1).ToLower() == "g" || textBox_Case_No.Text.Trim().Substring(0, 1).ToLower() == "d")
            {
                MessageBox.Show("It is not allow to input D or Cy-g case no. here");
                textBox_Case_No.Focus();
                return;
            }

            if (textBox_Case_No.Text != "" && textBox_Case_No.Text.Length > 1)
            {
                if ("CY".Equals(textBox_Case_No.Text.Substring(0, 2), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (comboBox_cytoType.Text == "")
                    {
                        MessageBox.Show("Please select a CY type.");
                        return;
                    }
                }
            }

            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    if (!checkDuplicateHKID())
                    {
                        if (!checkDuplicateCaseNo())
                        {
                            string currentCaseNo = textBox_Case_No.Text.Trim();
                            currentEditRow["ISSUE_BY"] = CurrentUser.currentUserId;
                            currentEditRow["ISSUE_AT"] = DateTime.Now.ToString("");
                            currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                            currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");

                            textBox_ID.BindingContext[dt].Position++;

                            if (DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
                            {
                                //button_End.PerformClick();
                                if (existDiagDataAdapter != null && existDiagDataSet != null)
                                {
                                    foreach (DataRow dr in existDiagDataSet.Tables["bxcy_diag"].Rows)
                                    {
                                        dr["barcode"] = dr["case_no"].ToString().Trim().Replace("/", "") + dr["group"].ToString().Trim();
                                        dr["case_no"] = currentCaseNo;
                                    }

                                    if (DBConn.updateObject(existDiagDataAdapter, existDiagDataSet, "bxcy_diag"))
                                    {
                                        MessageBox.Show("New case is saved");
                                    }
                                    else
                                    {
                                        MessageBox.Show("New case is saved, New diag save fail or no need to save");
                                    }                                    
                                }
                                else
                                {
                                    MessageBox.Show("New case is saved");
                                }

                                this.existDiagDataAdapter = null;
                                this.existDiagDataSet = null;
                                this.dtToDelete = null;

                                reloadAndBindingDBData(0, currentCaseNo);
                            }
                            else
                            {
                                MessageBox.Show("Case saved fail, please contact Admin");
                            }
                            setButtonStatus(PageStatus.STATUS_VIEW);
                        }
                    }
                }
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT || currentStatus == PageStatus.STATUS_ADVANCE_EDIT)
                {
                    string currentCaseNo = textBox_Case_No.Text.Trim();
                    DataRow drow = bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        if (currentStatus == PageStatus.STATUS_EDIT || !checkDuplicateCaseNoWithUpdate())
                        {
                            drow["UPDATE_BY"] = CurrentUser.currentUserId;
                            drow["UPDATE_AT"] = DateTime.Now.ToString("");

                            textBox_ID.BindingContext[dt].Position++;

                            bool bxcyUpdateResult = DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen");
                            bool diagUpdateResult = false;
                            if (existDiagDataAdapter != null && existDiagDataSet != null)
                            {
                                foreach (DataRow dr in existDiagDataSet.Tables["bxcy_diag"].Rows)
                                {
                                    dr["case_no"] = currentCaseNo;
                                }

                                if (DBConn.updateObject(existDiagDataAdapter, existDiagDataSet, "bxcy_diag"))
                                {
                                    diagUpdateResult = true;
                                }

                                if (dtToDelete != null)
                                {
                                    string idToDelete = "";
                                    foreach (DataRow drToDelete in dtToDelete.Rows)
                                    {
                                        if (drToDelete["case_no"].ToString() != "")
                                        {
                                            if (idToDelete == "")
                                            {
                                                idToDelete = drToDelete["id"].ToString();
                                            }
                                            else
                                            {
                                                idToDelete = idToDelete + "," + drToDelete["id"].ToString();
                                            }
                                        }
                                    }

                                    if (idToDelete != "")
                                    {
                                        string deleteSql = string.Format("DELETE FROM BXCY_DIAG WHERE id in ({0})", idToDelete);
                                        DBConn.executeUpdate(deleteSql);
                                    }
                                }
                            }

                            if (!bxcyUpdateResult && !diagUpdateResult)
                            {
                                MessageBox.Show("Case record updated fail or no record to update");
                            }
                            else
                            {
                                MessageBox.Show("Case record updated");
                            }

                            this.existDiagDataAdapter = null;
                            this.existDiagDataSet = null;
                            this.dtToDelete = null;

                            setButtonStatus(PageStatus.STATUS_VIEW);
                            reloadAndBindingDBData(0, currentCaseNo);
                        }
                    }
                }
            }
        }

        private int saveDataWithSnopCode(Object snopT1, Object snopT2, Object snopT3, Object snopM1, Object snopM2, Object snopM3)
        {
            int result = 0; //save success
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
                            result = 1; //new record fail
                        }
                        setButtonStatus(PageStatus.STATUS_VIEW);
                    }
                    else
                    {
                        result = 1; //new record fail
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
                        result = 2; //update record fail
                    }
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData(0, currentCaseNo);
            }

            return result;
        }

        public void processEdit()
        {
            button_Edit.PerformClick();
        }

        public void processNew()
        {
            button_New.PerformClick();
        }

        public void newRecord()
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";
            currentEditRow["CLIENT"] = DEFAULT_CLIENT;
            currentEditRow["Institute"] = DEFAULT_INSTITUTE;

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;
            currentEditRow["DATE"] = DateTime.Now;
            currentEditRow["INV_DATE"] = DateTime.Now;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existDiagDataSet = null;
            existDiagDataAdapter = null;
        }

        public void patientNameCopy(string patientName)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["patient"] = patientName;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";
            currentEditRow["CLIENT"] = DEFAULT_CLIENT;
            currentEditRow["Institute"] = DEFAULT_INSTITUTE;

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;
            currentEditRow["DATE"] = DateTime.Now;
            currentEditRow["INV_DATE"] = DateTime.Now;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existDiagDataSet = null;
            existDiagDataAdapter = null;
        }

        public void hisPatientCopy(HisPatient hp)
        {
            setButtonStatus(PageStatus.STATUS_NEW);
            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["CLIENT"] = DEFAULT_CLIENT;
            currentEditRow["Institute"] = DEFAULT_INSTITUTE;
            currentEditRow["DATE"] = DateTime.Now;
            currentEditRow["INV_DATE"] = DateTime.Now;

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;

            currentEditRow["DATE"] = DateTime.Now;

            currentEditRow["PATIENT"] = hp.getFullName();
            currentEditRow["CNAME"] = hp.pvChiName;
            if (hp.pvDob != null)
            {
                DateTime dob = DateTime.MinValue;
                try
                {

                    dob = DateTime.ParseExact(hp.pvDob, "yyyyMMdd", null);
                }
                catch (Exception ex)
                {

                }

                if (dob != DateTime.MinValue)
                {
                    currentEditRow["pat_birth"] = dob;
                    currentEditRow["pat_age"] = Math.Round(((DateTime.Now - dob).TotalDays / 365), 2);
                }

            }

            currentEditRow["pat_sex"] = hp.pvSex;
            currentEditRow["pat_hkid"] = hp.getFullHKID();
            currentEditRow["bed_room"] = hp.deptCode;
            currentEditRow["bed_no"] = hp.bedNo;
            currentEditRow["doctor_ic"] = hp.getDoctorFullName();
            currentEditRow["doctor_id"] = hp.doctorCode;
            currentEditRow["lab_ref"] = hp.visitNo;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existDiagDataSet = null;
            existDiagDataAdapter = null;
        }

        public void patientCopy(string caseNo)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";
            currentEditRow["CLIENT"] = DEFAULT_CLIENT;
            currentEditRow["Institute"] = DEFAULT_INSTITUTE;
            currentEditRow["Date"] = DateTime.Now;
            currentEditRow["INV_DATE"] = DateTime.Now;

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
                if (mDr["PAT_BIRTH"] != null)
                {
                    DateTime dob = (DateTime) mDr["PAT_BIRTH"];
                    Double age = PatientAgeCalculator.calculate(dob);
                    if (age != Double.NaN)
                    {
                        currentEditRow["PAT_AGE"] = age;
                    }
                }
            }

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existDiagDataSet = null;
            existDiagDataAdapter = null;
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            //this.existDiagDataSet = null;
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["date"] = DateTime.Now;
            currentEditRow["INV_DATE"] = DateTime.Now;
            currentEditRow["ethnic"] = comboBox_Ethnic.Text;
            currentEditRow["cyto_Type"] = comboBox_cytoType.Text;
            if (textBox_PatSeq.Text != "")
            {
                currentEditRow["pat_seq"] = Decimal.Parse(textBox_PatSeq.Text);
            }
            currentEditRow["patient"] = textBox_Patient.Text;
            currentEditRow["cname"] = textBox_Chinese_Name.Text;
            currentEditRow["pat_hkid"] = textBox_HKID.Text;
            CommonFunction.setDateWithStr(currentEditRow, "pat_birth", textBox_DOB.Text, "dd/MM/yyyy");
            currentEditRow["class"] = comboBox_Class.Text;
            currentEditRow["pat_age"] = textBox_Age.Text;
            currentEditRow["pat_sex"] = textBox_Sex.Text;
            currentEditRow["bed_room"] = textBox_Room.Text;
            currentEditRow["bed_no"] = textBox_Bed.Text;
            currentEditRow["client"] = textBox_Client.Text;
            currentEditRow["institute"] = textBox_Institute.Text;
            currentEditRow["lab_ref"] = textBox_Ref_No.Text;
            currentEditRow["doctor_o"] = textBox_Dr_I_C_Free_Text.Text;
            currentEditRow["doctor_ic"] = textBox_Doctor_I_C.Text;
            currentEditRow["doctor_id"] = textBox_Doctor_I_C_ID_1.Text;
            currentEditRow["doctor_ic2"] = textBox_Doctor_I_C_2.Text;
            currentEditRow["doctor_id2"] = textBox_Doctor_I_C_ID_2.Text;
            currentEditRow["doctor_ic3"] = textBox_Doctor_I_C_3.Text;
            currentEditRow["doctor_id3"] = textBox_Doctor_I_C_ID_3.Text;
            currentEditRow["inv_no"] = textBox_Involce_No.Text;
            currentEditRow["er"] = textBox_ER.Text;
            currentEditRow["em"] = textBox_EM.Text;
            currentEditRow["sish"] = textBox_SISH.Text;
            currentEditRow["fz_section"] = checkBox_F_S.Checked;
            currentEditRow["uploaded"] = checkBox_Uploaded.Checked;
            currentEditRow["supp"] = checkBox_Supp.Checked;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existDiagDataSet = null;
            existDiagDataAdapter = null;
            //currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_F6_Edit_Click(object sender, EventArgs e)
        {
            //currentPosition = currencyManager.Position;
            //this.existDiagDataSet = null;

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

            copybxcy_specimen.surgical = textBox_Surgical.Text;
            copybxcy_specimen.nature = textBox_Nature.Text;

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

            copybxcy_specimen.er = textBox_ER.Text;
            copybxcy_specimen.em = textBox_EM.Text;
            copybxcy_specimen.sish = textBox_SISH.Text;
            copybxcy_specimen.fz_section = checkBox_F_S.Checked;
            copybxcy_specimen.fz_detail = textBox_FZDetail.Text;
            copybxcy_specimen.uploaded = checkBox_Uploaded.Checked;
            copybxcy_specimen.supp = checkBox_Supp.Checked;

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
                    existDiagDataSet = null;
                    existDiagDataAdapter = null;
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    //currencyManager.Position = 0;
                    button_Top.PerformClick();
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
                    try
                    {
                        bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Remove(currentEditRow);
                    }catch(Exception ex)
                    {

                    }
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

                        textBox_Surgical.Text = copybxcy_specimen.surgical;
                        textBox_Nature.Text = copybxcy_specimen.nature;

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

                        textBox_ER.Text = copybxcy_specimen.er;
                        textBox_EM.Text = copybxcy_specimen.em;
                        textBox_SISH.Text = copybxcy_specimen.sish;
                        checkBox_F_S.Checked = copybxcy_specimen.fz_section.HasValue ? copybxcy_specimen.fz_section.Value : false;
                        textBox_FZDetail.Text = copybxcy_specimen.fz_detail;
                        checkBox_Uploaded.Checked = copybxcy_specimen.uploaded.HasValue ? copybxcy_specimen.uploaded.HasValue : false;
                        checkBox_Supp.Checked = copybxcy_specimen.supp.HasValue ? copybxcy_specimen.supp.Value : false;

                        textBox_Remarks.Text = copybxcy_specimen.remark;
                        textBox_Cytology.Text = copybxcy_specimen.initial;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }

            //this.existDiagDataAdapter = null;
            //this.existDiagDataSet = null;
            reloadDiagData();
            this.dtToDelete = null;
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
                button_F3_Surgical.Enabled = true;
                button_F4_Nature.Enabled = true;

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

                label_New_Record.Visible = false;

                button_Shif.Enabled = false;
                button_F9_2.Enabled = false;
                button_Shif_2.Enabled = false;
                button_Shif_3.Enabled = false;
                button3.Enabled = false;
                button_F9_3.Enabled = false;
                button_Advance.Enabled = true;

                button_Rpt_Date_Tick.Enabled = false;
                checkBox_Supp.Enabled = false;
                checkBox_F_S.Enabled = false;
                //checkBox_Uploaded.Enabled = false;
                button_Fee.Enabled = false;

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
                    button_F3_Surgical.Enabled = true;
                    button_F4_Nature.Enabled = true;

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

                    label_New_Record.Text = "<New Record>";
                    label_New_Record.Visible = true;

                    button_Shif.Enabled = true;
                    button_F9_2.Enabled = true;
                    button_Shif_2.Enabled = true;
                    button_Shif_3.Enabled = true;
                    button3.Enabled = true;
                    button_F9_3.Enabled = true;
                    button_Advance.Enabled = false;

                    button_Rpt_Date_Tick.Enabled = true;
                    checkBox_Supp.Enabled = true;
                    checkBox_F_S.Enabled = true;
                    //checkBox_Uploaded.Enabled = true;
                    button_Fee.Enabled = true;

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
                        button_F8.Enabled = false;
                        button_F9.Enabled = false;
                        button_F3_Surgical.Enabled = true;
                        button_F4_Nature.Enabled = true;

                        textBox_Case_No.Enabled = false;
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

                        label_New_Record.Text = "<Edit Record>";
                        label_New_Record.Visible = true;

                        button_Shif.Enabled = true;
                        button_F9_2.Enabled = true;
                        button_Shif_2.Enabled = true;
                        button_Shif_3.Enabled = true;
                        button3.Enabled = true;
                        button_F9_3.Enabled = true;
                        button_Advance.Enabled = true;

                        button_Rpt_Date_Tick.Enabled = true;
                        checkBox_Supp.Enabled = true;
                        checkBox_F_S.Enabled = true;
                        //checkBox_Uploaded.Enabled = true;
                        button_Fee.Enabled = true;

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
                            button_F8.Enabled = true;
                            button_F9.Enabled = true;
                            button_F3_Surgical.Enabled = true;
                            button_F4_Nature.Enabled = true;

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

                            label_New_Record.Text = "<Edit Record>";
                            label_New_Record.Visible = true;

                            button_Shif.Enabled = true;
                            button_F9_2.Enabled = true;
                            button_Shif_2.Enabled = true;
                            button_Shif_3.Enabled = true;
                            button3.Enabled = true;
                            button_F9_3.Enabled = true;
                            button_Advance.Enabled = false;

                            button_Rpt_Date_Tick.Enabled = true;
                            checkBox_Supp.Enabled = true;
                            checkBox_F_S.Enabled = true;
                            //checkBox_Uploaded.Enabled = true;
                            button_Fee.Enabled = true;

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
        /*
        private void jumpReverse()
        {
            Boolean notJumped = true;

            if (textBox_Date.Focused)
            {
                textBox_Case_No.Focus();
                notJumped = false;
            }

            if (notJumped)
            {
                if (comboBox_Ethnic.Focused)
                {
                    textBox_Date.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_cytoType.Focused)
                {
                    comboBox_Ethnic.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Patient.Focused)
                {
                    comboBox_cytoType.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Chinese_Name.Focused)
                {
                    textBox_Patient.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_HKID.Focused)
                {
                    textBox_Chinese_Name.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_DOB.Focused)
                {
                    textBox_HKID.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Class.Focused)
                {
                    textBox_DOB.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Age.Focused)
                {
                    comboBox_Class.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Sex.Focused)
                {
                    textBox_Age.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Room.Focused)
                {
                    textBox_Sex.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Bed.Focused)
                {
                    textBox_Room.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Patient_s_Clinical_History.Focused)
                {
                    textBox_Bed.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C.Focused)
                {
                    textBox_Ref_No.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Involce_No.Focused)
                {
                    textBox_Doctor_I_C.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Receipt.Focused)
                {
                    textBox_Involce_No.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Invoice_Date.Focused)
                {
                    textBox_Receipt.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Amount_HK.Focused)
                {
                    textBox_Invoice_Date.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Paid_Up.Focused)
                {
                    textBox_Amount_HK.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Paid_Date.Focused)
                {
                    textBox_Paid_Up.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_T1.Focused)
                {
                    textBox_Paid_Date.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_T2.Focused)
                {
                    comboBox_Snop_T1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_T3.Focused)
                {
                    comboBox_Snop_T2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_M1.Focused)
                {
                    comboBox_Snop_T3.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_M2.Focused)
                {
                    comboBox_Snop_M1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_M3.Focused)
                {
                    comboBox_Snop_M2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Sign_By_Dr_1.Focused)
                {
                    comboBox_Snop_M3.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Sign_By_Dr_2.Focused)
                {
                    comboBox_Sign_By_Dr_1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Remarks.Focused)
                {
                    textBox_Remarks.Focus();
                    comboBox_Sign_By_Dr_2.Focus();
                    notJumped = false;
                }
            }
        }

        private void jumpNext()
        {
            Boolean notJumped = true;

            if (textBox_Case_No.Focused)
            {
                textBox_Date.Focus();
                notJumped = false;
            }

            if (notJumped)
            {

                if (textBox_Date.Focused)
                {
                    comboBox_Ethnic.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Ethnic.Focused)
                {
                    comboBox_cytoType.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_cytoType.Focused)
                {
                    textBox_Patient.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Patient.Focused)
                {
                    textBox_Chinese_Name.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Chinese_Name.Focused)
                {
                    textBox_HKID.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_HKID.Focused)
                {
                    textBox_DOB.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_DOB.Focused)
                {
                    comboBox_Class.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Class.Focused)
                {
                    textBox_Age.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Age.Focused)
                {
                    textBox_Sex.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Sex.Focused)
                {
                    textBox_Room.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Room.Focused)
                {
                    textBox_Bed.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Bed.Focused)
                {
                    textBox_Patient_s_Clinical_History.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Ref_No.Focused)
                {
                    textBox_Doctor_I_C.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C.Focused)
                {
                    textBox_Involce_No.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Involce_No.Focused)
                {
                    textBox_Receipt.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Receipt.Focused)
                {
                    textBox_Invoice_Date.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Invoice_Date.Focused)
                {
                    textBox_Amount_HK.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Amount_HK.Focused)
                {
                    textBox_Paid_Up.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Paid_Up.Focused)
                {
                    textBox_Paid_Date.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Paid_Date.Focused)
                {
                    comboBox_Snop_T1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_T1.Focused)
                {
                    comboBox_Snop_T2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_T2.Focused)
                {
                    comboBox_Snop_T3.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_T3.Focused)
                {
                    comboBox_Snop_M1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_M1.Focused)
                {
                    comboBox_Snop_M2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_M2.Focused)
                {
                    comboBox_Snop_M3.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Snop_M3.Focused)
                {
                    comboBox_Sign_By_Dr_1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Sign_By_Dr_1.Focused)
                {
                    comboBox_Sign_By_Dr_2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Sign_By_Dr_2.Focused)
                {
                    textBox_Remarks.Focus();
                    notJumped = false;
                }
            }
        }*/

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.F1 && button_F1.Enabled)
            {
                button_F1.PerformClick();
                return true;
            }

            if (keyData == (Keys)Shortcut.F2 && button_F2_Previous.Enabled)
            {
                button_F2_Previous.PerformClick();
                return true;
            }

            if (keyData == (Keys)Shortcut.F3 && button_F3_Surgical.Enabled)
            {
                button_F3_Surgical.PerformClick();
                return true;
            }

            if (keyData == (Keys)Shortcut.F4 && button_F4_Nature.Enabled)
            {
                button_F4_Nature.PerformClick();
                return true;
            }

            if (keyData == (Keys)Shortcut.F5 && button_F5_Description.Enabled)
            {
                button_F5_Description.PerformClick();
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

            if (keyData == (Keys)Shortcut.F10 && button_Cytology.Enabled)
            {
                button_Cytology.PerformClick();
                return true;
            }

            // eric leung -- press enter to jump to next field
            /*if (keyData == (Keys.LButton | Keys.Shift | Keys.Enter))
            {
                this.jumpReverse();
                
            }
            else
            {
                if (keyData == Keys.Enter)
                {
                    this.jumpNext();
                }
            }   */   

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (textBox_Patient_s_Clinical_History.Focused || textBox_Remarks.Focused)
            {
                //MessageBox.Show("The ");
                if (keyData == (Keys.LButton | Keys.Shift | Keys.Enter))
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is System.Windows.Forms.TextBox || c is System.Windows.Forms.ComboBox || c is System.Windows.Forms.MaskedTextBox)
                        {
                            keyData = (Keys.LButton | Keys.Shift | Keys.Tab);
                        }
                    }
                }
            }
            else
            {
                if (keyData == Keys.Enter)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is System.Windows.Forms.TextBox || c is System.Windows.Forms.ComboBox || c is System.Windows.Forms.MaskedTextBox)
                        {

                            keyData = Keys.Tab;


                        }
                    }
                }
                else
                {
                    if (keyData == (Keys.LButton | Keys.Shift | Keys.Enter))
                    {
                        foreach (Control c in this.Controls)
                        {
                            if (c is System.Windows.Forms.TextBox || c is System.Windows.Forms.ComboBox || c is System.Windows.Forms.MaskedTextBox)
                            {
                                keyData = (Keys.LButton | Keys.Shift | Keys.Tab);
                            }
                        }
                    }
                }
            }

            
            return base.ProcessDialogKey(keyData);
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
                //this.existDiagDataSet = null;
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

                copybxcy_specimen.surgical = textBox_Surgical.Text;
                copybxcy_specimen.nature = textBox_Nature.Text;

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

                copybxcy_specimen.er = textBox_ER.Text;
                copybxcy_specimen.em = textBox_EM.Text;
                copybxcy_specimen.sish = textBox_SISH.Text;
                copybxcy_specimen.fz_section = checkBox_F_S.Checked;
                copybxcy_specimen.fz_detail = textBox_FZDetail.Text;
                copybxcy_specimen.uploaded = checkBox_Uploaded.Checked;
                copybxcy_specimen.supp = checkBox_Supp.Checked;

                copybxcy_specimen.remark = textBox_Remarks.Text;
                copybxcy_specimen.initial = textBox_Cytology.Text;

                setButtonStatus(PageStatus.STATUS_ADVANCE_EDIT);
            }
        }

        private void button_Rpt_Date_Tick_Click(object sender, EventArgs e)
        {
            textBox_Rpt_Date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            textBox_Rpt_Date.Focus();
            textBox_Rpt_Date.SelectionStart = 0;
            textBox_Rpt_Date.SelectionLength = 0;

        }

        private void button_Printed_Click(object sender, EventArgs e)
        {
            string message = string.Format("Last Printed By: {0}" +
                "\nLast Printed At: {1}" +
                "\nTotal Printed Counter: {2}", label_Print_By.Text.Trim(), label_Print_At.Text.Trim(), label_Printed.Text.Trim());
            MessageBox.Show(message, "Report Printing Staticstic");
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
            if (textBox_ID.Text.Trim() != "")
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
            else
            {
                pictureBox_Has_Previous.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Snop_T1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 4;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 4) * 3;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Snop_T2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 4;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 4) * 3;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Snop_T3_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 4;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 4) * 3;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Snop_M1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 4;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 4) * 3;
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
            r1.Width = r1.Width / 4;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 4) * 3;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void comboBox_Snop_M3_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 4;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = (r2.Width / 4) * 3;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }

        private void textBox_Case_No_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox_Case_No.Text.Trim().ToLower() == "bx")
            {
                if (textBox_Case_No.Text.Length == 2)
                {
                    textBox_Case_No.Text = string.Format("BX{0}/", DateTime.Now.ToString("yyyy").Substring(2));
                    textBox_Case_No.Focus();
                    textBox_Case_No.SelectionStart = textBox_Case_No.Text.Length;
                    textBox_Case_No.SelectionLength = 0;
                }

            }
            else
            {
                if (textBox_Case_No.Text.Trim().ToLower() == "c")
                {
                    if (textBox_Case_No.Text.Length == 1)
                    {
                        textBox_Case_No.Text = string.Format("CY{0}-", DateTime.Now.ToString("yyyy").Substring(2));
                        textBox_Case_No.Focus();
                        textBox_Case_No.SelectionStart = textBox_Case_No.Text.Length;
                        textBox_Case_No.SelectionLength = 0;
                    }

                }
                else
                {
                    if (textBox_Case_No.Text.Trim().ToLower() == "m")
                    {
                        if (textBox_Case_No.Text.Length == 1)
                        {
                            textBox_Case_No.Text = string.Format("MP{0}-", DateTime.Now.ToString("yyyy").Substring(2));
                            textBox_Case_No.Focus();
                            textBox_Case_No.SelectionStart = textBox_Case_No.Text.Length;
                            textBox_Case_No.SelectionLength = 0;
                        }

                    }
                    else
                    {
                        if (textBox_Case_No.Text.Trim().ToLower() == "d")
                        {
                            if (textBox_Case_No.Text.Length == 1)
                            {
                                textBox_Case_No.Text = string.Format("D{0}-", DateTime.Now.ToString("yyyy").Substring(2));
                                textBox_Case_No.Focus();
                                textBox_Case_No.SelectionStart = textBox_Case_No.Text.Length;
                                textBox_Case_No.SelectionLength = 0;
                            }

                        }
                    }
                }
            }
        }

        private void checkBox_F_S_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_F_S.Checked)
            {
                button_F_S_Detail.Enabled = true;
            }
            else
            {
                button_F_S_Detail.Enabled = false;
            }

        }

        private void textBox_Doctor_I_C_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C.Text == "")
            {
                textBox_Doctor_I_C_ID_1.Text = "";
            }
        }

        private void textBox_Doctor_I_C_2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C_2.Text == "")
            {
                textBox_Doctor_I_C_ID_2.Text = "";
            }
        }

        private void textBox_Doctor_I_C_3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C_3.Text == "")
            {
                textBox_Doctor_I_C_ID_3.Text = "";
            }
        }

        public void disableEdit()
        {
            button_Edit.Enabled = false;
            button_Advance.Enabled = false;
            button_Delete.Enabled = false;
            button_New.Enabled = false;
            readOnly = true;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboBox_Snop_T1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Sign_By_Dr_1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering1 = true;
        }

        private void comboBox_Sign_By_Dr_1_TextChanged(object sender, EventArgs e)
        {
            if (m_isEntering1)
            {
                m_isEntering1 = false;
                string search = ((ComboBox)sender).Text.Trim();

                string sqlFull = string.Format("SELECT TOP 1 doctor FROM [sign_doctor] WHERE doc_no = '{0}' order by doctor ", search);
                doctorDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(sqlFull, doctorDataSet1, "sign_doctor");

                if (doctorDataSet1.Tables["sign_doctor"].Rows.Count > 0)
                {
                    /*DataTable newDt = new DataTable();
                    newDt.Columns.Add("doctor");

                    foreach (DataRow mDr in doctorDataSet1.Tables["sign_doctor"].Rows)
                    {
                        newDt.Rows.Add(new object[] { mDr["doctor"] });
                    }*/
                    try
                    {
                        ((ComboBox)sender).SelectedValue = doctorDataSet1.Tables["sign_doctor"].Rows[0]["doctor"].ToString();
                    }catch(Exception ex)
                    {

                    }
                }
                /*else
                {
                    sqlFull = string.Format("SELECT doctor FROM [sign_doctor] WHERE doctor like '%{0}%' order by doctor ", search);
                    doctorDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(sqlFull, doctorDataSet1, "sign_doctor");

                    DataTable newDt = new DataTable();
                    newDt.Columns.Add("doctor");

                    foreach (DataRow mDr in doctorDataSet1.Tables["sign_doctor"].Rows)
                    {
                        newDt.Rows.Add(new object[] { mDr["doctor"] });
                    }

                    ((ComboBox)sender).DataSource = newDt;
                }

                ((ComboBox)sender).Text = search;
                ((ComboBox)sender).SelectionStart = search.Length;*/
            }
        }

        private void comboBox_Sign_By_Dr_2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering2 = true;
        }

        private void comboBox_Sign_By_Dr_2_TextChanged(object sender, EventArgs e)
        {
            if (m_isEntering2)
            {
                m_isEntering2 = false;
                string search = ((ComboBox)sender).Text.Trim();

                string sqlFull = string.Format("SELECT TOP 1 doctor FROM [sign_doctor] WHERE doc_no = '{0}' order by doctor ", search);
                doctorDataAdapter2 = DBConn.fetchDataIntoDataSetSelectOnly(sqlFull, doctorDataSet2, "sign_doctor");

                if (doctorDataSet2.Tables["sign_doctor"].Rows.Count > 0)
                {
                    /*DataTable newDt = new DataTable();
                    newDt.Columns.Add("doctor");

                    foreach (DataRow mDr in doctorDataSet2.Tables["sign_doctor"].Rows)
                    {
                        newDt.Rows.Add(new object[] { mDr["doctor"] });
                    }

                    ((ComboBox)sender).DataSource = newDt;*/

                    try
                    {
                        ((ComboBox)sender).SelectedValue = doctorDataSet2.Tables["sign_doctor"].Rows[0]["doctor"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                /*else
                {
                    sqlFull = string.Format("SELECT doctor FROM [sign_doctor] WHERE doctor like '%{0}%' order by doctor ", search);
                    doctorDataAdapter2 = DBConn.fetchDataIntoDataSetSelectOnly(sqlFull, doctorDataSet2, "sign_doctor");

                    DataTable newDt = new DataTable();
                    newDt.Columns.Add("doctor");

                    foreach (DataRow mDr in doctorDataSet2.Tables["sign_doctor"].Rows)
                    {
                        newDt.Rows.Add(new object[] { mDr["doctor"] });
                    }

                    ((ComboBox)sender).DataSource = newDt;
                }

                ((ComboBox)sender).Text = search;
                ((ComboBox)sender).SelectionStart = search.Length;*/
            }
        }
		
		private void textBox_Paid_Date_TextChanged(object sender, EventArgs e)
        {
            /*
            if (textBox_Paid_Date.Text == "")
            {
                textBox_Paid_Up.Text = "";
            }
            else
            {
                DateTime dDate;
                if (textBox_Paid_Date.Text.Length == 10 && DateTime.TryParse(textBox_Paid_Date.Text, out dDate))
                {
                    textBox_Paid_Up.Text = PaymentStatus.PAID_YES;
                }
                else
                {

                }
                
            }
            */
        }

        private void textBox_Paid_Date_Validating(object sender, CancelEventArgs e)
        {
            if (textBox_Paid_Date.Text == "  /  /")
            {
                
               
            }
            else
            {
                DateTime dDate;
                CultureInfo ci = new CultureInfo("en-IE");
                if (textBox_Paid_Date.Text.Length == 10 && DateTime.TryParseExact(textBox_Paid_Date.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out dDate))
                {
                    textBox_Paid_Up.Text = PaymentStatus.PAID_YES;
                    
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        private void comboBox_Sign_By_Dr_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_DOB_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //MessageBox.Show("input rejectd - " + textBox_DOB.Text);
        }

        private void textBox_DOB_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            //MessageBox.Show("textBox_DOB_TypeValidationCompleted - " + textBox_DOB.Text);
            if (textBox_DOB.Text != "")
            {
                DateTime dob = DateTime.MinValue;
                DateTime.TryParse(textBox_DOB.Text, out dob);
                if (dob != DateTime.MinValue)
                {
                    textBox_Age.Text = PatientAgeCalculator.calculate(dob).ToString();
                }
            }
        }

        private void textBox_Paid_Date_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form_BXCYFile_Activated(object sender, EventArgs e)
        {
            textBox_Case_No.Focus();
        }

        private void textBox_Rpt_Date_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (existDiagDataAdapter == null)
            {
                Console.WriteLine("Null dataAdapter");
            }

            if (existDiagDataSet == null)
            {
                Console.WriteLine("Null existDiagDataSet");
            }

            if (existDiagDataAdapter != null && existDiagDataSet != null)
            {
                var varList = from p in existDiagDataSet.Tables["bxcy_diag"].AsEnumerable()
                              orderby p.Field<string>("group") ascending, p.Field<int>("diagnosisId") ascending
                              select p;
                foreach (DataRow dr in varList)
                {
                    string rowMessage = string.Format("Group:{0}, diagnosis:{1}, macroDesc:{2}, microDesc:{3}, report_status{4}", dr["group"], dr["diagnosisId"], dr["macro_desc"], dr["micro_desc"], dr["report_status"]);
                    Console.WriteLine(rowMessage);
                }
            }

            if(bxcy_specimenDataSet != null)
            {
                foreach (DataRow dr in bxcy_specimenDataSet.Tables["BXCY_SPECIMEN"].Rows)
                {
                    string rowMessage = string.Format("Case No.:{0}", dr["case_no"]);
                    Console.WriteLine(rowMessage);
                }
                
            }
        }

        private void label_New_Record_Click(object sender, EventArgs e)
        {
            
        }

        private void label_BX_CY_SPECIMEN_Click(object sender, EventArgs e)
        {
            if (existDiagDataAdapter == null)
            {
                Console.WriteLine("Null dataAdapter");
            }

            if (existDiagDataSet == null)
            {
                Console.WriteLine("Null existDiagDataSet");
            }

            if (existDiagDataAdapter != null && existDiagDataSet != null)
            {
                var varList = from p in existDiagDataSet.Tables["bxcy_diag"].AsEnumerable()
                              orderby p.Field<string>("group") ascending, p.Field<int>("diagnosisId") ascending
                              select p;
                foreach (DataRow dr in varList)
                {
                    string rowMessage = string.Format("Group:{0}, diagnosis:{1}, macroDesc:{2}, microDesc:{3}, report status{4}, id:{5}, case no.:{6}", dr["group"], dr["diagnosisId"], dr["macro_desc"], dr["micro_desc"], dr["report_status"], dr["id"], dr["case_no"]);
                    Console.WriteLine(rowMessage);
                }
            }

            if (bxcy_specimenDataSet != null)
            {
                foreach (DataRow dr in bxcy_specimenDataSet.Tables["BXCY_SPECIMEN"].Rows)
                {
                    string rowMessage = string.Format("Case No.:{0}", dr["case_no"]);
                    Console.WriteLine(rowMessage);
                }

            }
        }

        private void reloadDiagData()
        {
            existDiagDataSet = null;
            existDiagDataAdapter = null;
            if (textBox_Case_No.Text.Trim() != "")
            {
                existDiagDataSet = new DataSet();
                string diagSql = string.Format("SELECT * FROM [bxcy_diag] WHERE case_no = '{0}' ORDER BY [group] , diagnosisid", textBox_Case_No.Text.Trim());
                existDiagDataAdapter = DBConn.fetchDataIntoDataSet(diagSql, existDiagDataSet, "bxcy_diag");
            }
        }
    }
}
