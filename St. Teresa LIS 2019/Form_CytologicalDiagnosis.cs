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
    public partial class Form_CytologicalDiagnosis : Form
    {
        private int currentStatus;
        private string caseNo;

        private DataSet existCyDiagDataSet1 = new DataSet();
        private SqlDataAdapter existCyDiagDataAdapter1 = null;

        private DataSet existCyDiagDataSet2 = new DataSet();
        private SqlDataAdapter existCyDiagDataAdapter2 = null;

        private DataSet existCyDiagDataSet3 = new DataSet();
        private SqlDataAdapter existCyDiagDataAdapter3 = null;

        private DataTable dt1,dt2,dt3;

        private DataRow currentEditRow1;
        private DataRow currentEditRow2;
        private DataRow currentEditRow3;

        public delegate void CyDiagExit(DataSet existCyDiagDataSet1, DataSet existCyDiagDataSet2, DataSet existCyDiagDataSet3, SqlDataAdapter existCyDiagDataAdapter1, SqlDataAdapter existCyDiagDataAdapter2, SqlDataAdapter existCyDiagDataAdapter3);
        public CyDiagExit OnCyDiagExit;

        public Form_CytologicalDiagnosis()
        {
            InitializeComponent();
        }

        public Form_CytologicalDiagnosis(string caseNo, int status, DataSet existCyDiagDataSet1 = null, DataSet existCyDiagDataSet2 = null, DataSet existCyDiagDataSet3 = null, SqlDataAdapter existCyDiagDataAdapter1 = null, SqlDataAdapter existCyDiagDataAdapter2 = null, SqlDataAdapter existCyDiagDataAdapter3 = null)
        {
            this.caseNo = caseNo;
            this.currentStatus = status;
            this.existCyDiagDataSet1 = existCyDiagDataSet1;
            this.existCyDiagDataSet2 = existCyDiagDataSet2;
            this.existCyDiagDataSet3 = existCyDiagDataSet3;

            this.existCyDiagDataAdapter1 = existCyDiagDataAdapter1;
            this.existCyDiagDataAdapter2 = existCyDiagDataAdapter2;
            this.existCyDiagDataAdapter3 = existCyDiagDataAdapter3;
            InitializeComponent();

            reloadAndBindingDBData();

            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (existCyDiagDataSet1 != null && existCyDiagDataSet1.Tables[0].Rows.Count == 0)
                {
                    currentEditRow1 = existCyDiagDataSet1.Tables[0].NewRow();

                    existCyDiagDataSet1.Tables[0].Rows.Clear();
                    existCyDiagDataSet1.Tables[0].Rows.Add(currentEditRow1);
                }

                if (existCyDiagDataSet2 != null && existCyDiagDataSet2.Tables[0].Rows.Count == 0)
                {
                    currentEditRow2 = existCyDiagDataSet2.Tables[0].NewRow();

                    existCyDiagDataSet2.Tables[0].Rows.Clear();
                    existCyDiagDataSet2.Tables[0].Rows.Add(currentEditRow2);
                }

                if (existCyDiagDataSet3 != null && existCyDiagDataSet3.Tables[0].Rows.Count == 0)
                {
                    currentEditRow3 = existCyDiagDataSet3.Tables[0].NewRow();

                    existCyDiagDataSet3.Tables[0].Rows.Clear();
                    existCyDiagDataSet3.Tables[0].Rows.Add(currentEditRow3);
                }
            }
        }

        private void button_Image_Click(object sender, EventArgs e)
        {
            Form_Picture open = new Form_Picture();
            open.Show();
        }

        private void button_Confirm_Exit_Click(object sender, EventArgs e)
        {
            if(OnCyDiagExit != null)
            {
                OnCyDiagExit(existCyDiagDataSet1, existCyDiagDataSet2, existCyDiagDataSet3, existCyDiagDataAdapter1, existCyDiagDataAdapter2, existCyDiagDataAdapter3);
            }
            this.Close();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            Form_GynaecologicalCytologyReport open = new Form_GynaecologicalCytologyReport();
            open.Show();
        }

        private void reloadAndBindingDBData()
        {
            if (existCyDiagDataSet1 == null)
            {
                existCyDiagDataSet1 = new DataSet();
                string sql1 = string.Format("SELECT TOP 1 * FROM [cy_diag1] WHERE case_no = '{0}'", caseNo);
                existCyDiagDataAdapter1 = DBConn.fetchDataIntoDataSet(sql1, existCyDiagDataSet1, "cy_diag1");
            }

            if (existCyDiagDataSet2 == null)
            {
                existCyDiagDataSet2 = new DataSet();
                string sql2 = string.Format("SELECT TOP 1 * FROM [cy_diag2] WHERE case_no = '{0}'", caseNo);
                existCyDiagDataAdapter2 = DBConn.fetchDataIntoDataSet(sql2, existCyDiagDataSet2, "cy_diag2");
            }

            if (existCyDiagDataSet3 == null)
            {
                existCyDiagDataSet3 = new DataSet();
                string sql3 = string.Format("SELECT TOP 1 * FROM [cy_diag3] WHERE case_no = '{0}'", caseNo);
                existCyDiagDataAdapter3 = DBConn.fetchDataIntoDataSet(sql3, existCyDiagDataSet3, "cy_diag3");
            }

            dt1 = existCyDiagDataSet1.Tables["cy_diag1"];
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["id"] };
            dt1.Columns["id"].AutoIncrement = true;
            dt1.Columns["id"].AutoIncrementStep = 1;

            dt2 = existCyDiagDataSet2.Tables["cy_diag2"];
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["id"] };
            dt2.Columns["id"].AutoIncrement = true;
            dt2.Columns["id"].AutoIncrementStep = 1;

            dt3 = existCyDiagDataSet3.Tables["cy_diag3"];
            dt3.PrimaryKey = new DataColumn[] { dt3.Columns["id"] };
            dt3.Columns["id"].AutoIncrement = true;
            dt3.Columns["id"].AutoIncrementStep = 1;

            textBox_ID1.DataBindings.Clear();
            textBox_ID2.DataBindings.Clear();
            textBox_ID3.DataBindings.Clear();

            textBox_Sign_At_1.DataBindings.Clear();
            textBox_Sign_By_1.DataBindings.Clear();
            comboBox_Sign_By_1.DataBindings.Clear();

            checkBox_Cervix_1.DataBindings.Clear();
            checkBox_Vagina_Vault_1.DataBindings.Clear();
            checkBox_Satisfactory_for_evaluation_1.DataBindings.Clear();
            checkBox_Satisfactory_for_evaluation_but_1.DataBindings.Clear();
            checkBox_Unsatisfactory_for_evaluation_1.DataBindings.Clear();
            checkBox_Transformation_zone_1.DataBindings.Clear();
            checkBox_Mainly_superficial_and_intermediate_cells_1.DataBindings.Clear();
            checkBox_Mainly_intermediate_and_parabasal_cells_1.DataBindings.Clear();
            checkBox_trophic_pattern_in_menopause_1.DataBindings.Clear();
            checkBox_Post_partum_changes_1.DataBindings.Clear();
            comboBox_SITE_TYPE_1.DataBindings.Clear();
            textBox_SITE_TYPE_1.DataBindings.Clear();
            checkBox_Liquid_based_preparation_1.DataBindings.Clear();
            checkBox_Liquid_based_preparations_1.DataBindings.Clear();
            checkBox_Conventional_Pap_smear_1.DataBindings.Clear();
            checkBox_Conventional_Pap_smear_1.DataBindings.Clear();
            checkBox_Low_squamous_cellularity_1.DataBindings.Clear();
            checkBox_Air_drying_artifacts_1.DataBindings.Clear();
            checkBox_Obscured_by_inflammatory_exudates_1.DataBindings.Clear();
            checkBox_Obscured_by_blood_1.DataBindings.Clear();
            checkBox_Thick_smear_1.DataBindings.Clear();
            comboBox_DIAGNOSIS_1_1.DataBindings.Clear();
            textBox_DIAGNOSIS_1_1.DataBindings.Clear();
            comboBox_DIAGNOSIS_2_1.DataBindings.Clear();
            textBox_DIAGNOSIS_2_1.DataBindings.Clear();
            comboBox_DIAGNOSIS_3_1.DataBindings.Clear();
            textBox_DIAGNOSIS_3_1.DataBindings.Clear();
            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.DataBindings.Clear();
            checkBox_Reactive_cellular_changes_associated_1.DataBindings.Clear();
            checkBox_Normal_flora_1.DataBindings.Clear();
            checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1.DataBindings.Clear();
            checkBox_Herpes_simplex_virus_1.DataBindings.Clear();
            checkBox_Candida_Monilia_1.DataBindings.Clear();
            checkBox_Trichomonas_vaginalis_1.DataBindings.Clear();
            checkBox_Actinomyces_1.DataBindings.Clear();
            checkBox_Endometrial_cells_1.DataBindings.Clear();
            checkBox_Others_eg_follicular_cervicitis_RT_effect_1.DataBindings.Clear();
            checkBox_HPV_DNA_TESTING_1.DataBindings.Clear();
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.DataBindings.Clear();
            checkBox_Atypical_squamous_cells_1.DataBindings.Clear();
            checkBox_ASC_US_1.DataBindings.Clear();
            checkBox_ASC_H_1.DataBindings.Clear();
            checkBox_Squamous_intraepithelial_lesion_SIL_1.DataBindings.Clear();
            checkBox_Low_grade_SIL_1.DataBindings.Clear();
            checkBox_High_grade_SIL_1.DataBindings.Clear();
            checkBox_HSIL_1.DataBindings.Clear();
            checkBox_Squamous_cell_carcinoma_1.DataBindings.Clear();
            checkBox_Atypical_glandular_cells_1.DataBindings.Clear();
            checkBox_Atypical_glandular_cells_NOS_1.DataBindings.Clear();
            checkBox_Atypical_endocervical_cells_NOS_1.DataBindings.Clear();
            checkBox_Atypical_endometrial_cells_NOS_1.DataBindings.Clear();
            checkBox_Adenocarcinoma_1.DataBindings.Clear();
            checkBox_Endocervial_adenocarcinoma_in_situ_1.DataBindings.Clear();
            checkBox_Endocervial_adenocarcinoma_1.DataBindings.Clear();
            checkBox_Endometrial_adenocarcinoma_1.DataBindings.Clear();
            checkBox_Adenocarcinoma_NOS_1.DataBindings.Clear();
            checkBox_Other_malignant_neoplasm_1.DataBindings.Clear();

            label_Printed_By_No.DataBindings.Clear();
            label_Printed_At_Date.DataBindings.Clear();

            textBox_Sign_At_2.DataBindings.Clear();
            textBox_Sign_By_2.DataBindings.Clear();
            comboBox_Sign_By_2.DataBindings.Clear();

            checkBox_Cervix_2.DataBindings.Clear();
            checkBox_Vagina_Vault_2.DataBindings.Clear();
            checkBox_Satisfactory_for_evaluation_2.DataBindings.Clear();
            checkBox_Satisfactory_for_evaluation_but_2.DataBindings.Clear();
            checkBox_Unsatisfactory_for_evaluation_2.DataBindings.Clear();
            checkBox_Transformation_zone_2.DataBindings.Clear();
            checkBox_Mainly_superficial_and_intermediate_cells_2.DataBindings.Clear();
            checkBox_Mainly_intermediate_and_parabasal_cells_2.DataBindings.Clear();
            checkBox_trophic_pattern_in_menopause_2.DataBindings.Clear();
            checkBox_Post_partum_changes_2.DataBindings.Clear();
            comboBox_SITE_TYPE_2.DataBindings.Clear();
            textBox_SITE_TYPE_2.DataBindings.Clear();
            checkBox_Liquid_based_preparation_2.DataBindings.Clear();
            checkBox_Liquid_based_preparations_2.DataBindings.Clear();
            checkBox_Conventional_Pap_smear_2.DataBindings.Clear();
            checkBox_Conventional_Pap_smear_2.DataBindings.Clear();
            checkBox_Low_squamous_cellularity_2.DataBindings.Clear();
            checkBox_Air_drying_artifacts_2.DataBindings.Clear();
            checkBox_Obscured_by_inflammatory_exudates_2.DataBindings.Clear();
            checkBox_Obscured_by_blood_2.DataBindings.Clear();
            checkBox_Thick_smear_2.DataBindings.Clear();
            comboBox_DIAGNOSIS_1_2.DataBindings.Clear();
            textBox_DIAGNOSIS_1_2.DataBindings.Clear();
            comboBox_DIAGNOSIS_2_2.DataBindings.Clear();
            textBox_DIAGNOSIS_2_2.DataBindings.Clear();
            comboBox_DIAGNOSIS_3_2.DataBindings.Clear();
            textBox_DIAGNOSIS_3_2.DataBindings.Clear();
            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.DataBindings.Clear();
            checkBox_Reactive_cellular_changes_associated_2.DataBindings.Clear();
            checkBox_Normal_flora_2.DataBindings.Clear();
            checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2.DataBindings.Clear();
            checkBox_Herpes_simplex_virus_2.DataBindings.Clear();
            checkBox_Candida_Monilia_2.DataBindings.Clear();
            checkBox_Trichomonas_vaginalis_2.DataBindings.Clear();
            checkBox_Actinomyces_2.DataBindings.Clear();
            checkBox_Endometrial_cells_2.DataBindings.Clear();
            checkBox_Others_eg_follicular_cervicitis_RT_effect_2.DataBindings.Clear();
            checkBox_HPV_DNA_TESTING_2.DataBindings.Clear();
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.DataBindings.Clear();
            checkBox_Atypical_squamous_cells_2.DataBindings.Clear();
            checkBox_ASC_US_2.DataBindings.Clear();
            checkBox_ASC_H_2.DataBindings.Clear();
            checkBox_Squamous_intraepithelial_lesion_SIL_2.DataBindings.Clear();
            checkBox_Low_grade_SIL_2.DataBindings.Clear();
            checkBox_High_grade_SIL_2.DataBindings.Clear();
            checkBox_HSIL_2.DataBindings.Clear();
            checkBox_Squamous_cell_carcinoma_2.DataBindings.Clear();
            checkBox_Atypical_glandular_cells_2.DataBindings.Clear();
            checkBox_Atypical_glandular_cells_NOS_2.DataBindings.Clear();
            checkBox_Atypical_endocervical_cells_NOS_2.DataBindings.Clear();
            checkBox_Atypical_endometrial_cells_NOS_2.DataBindings.Clear();
            checkBox_Adenocarcinoma_2.DataBindings.Clear();
            checkBox_Endocervial_adenocarcinoma_in_situ_2.DataBindings.Clear();
            checkBox_Endocervial_adenocarcinoma_2.DataBindings.Clear();
            checkBox_Endometrial_adenocarcinoma_2.DataBindings.Clear();
            checkBox_Adenocarcinoma_NOS_2.DataBindings.Clear();
            checkBox_Other_malignant_neoplasm_1.DataBindings.Clear();

            textBox_Sign_At_3.DataBindings.Clear();
            textBox_Sign_By_3.DataBindings.Clear();
            comboBox_Sign_By_3.DataBindings.Clear();

            checkBox_Cervix_3.DataBindings.Clear();
            checkBox_Vagina_Vault_3.DataBindings.Clear();
            checkBox_Satisfactory_for_evaluation_3.DataBindings.Clear();
            checkBox_Satisfactory_for_evaluation_but_3.DataBindings.Clear();
            checkBox_Unsatisfactory_for_evaluation_3.DataBindings.Clear();
            checkBox_Transformation_zone_3.DataBindings.Clear();
            checkBox_Mainly_superficial_and_intermediate_cells_3.DataBindings.Clear();
            checkBox_Mainly_intermediate_and_parabasal_cells_3.DataBindings.Clear();
            checkBox_trophic_pattern_in_menopause_3.DataBindings.Clear();
            checkBox_Post_partum_changes_3.DataBindings.Clear();
            comboBox_SITE_TYPE_3.DataBindings.Clear();
            textBox_SITE_TYPE_3.DataBindings.Clear();
            checkBox_Liquid_based_preparation_3.DataBindings.Clear();
            checkBox_Liquid_based_preparations_3.DataBindings.Clear();
            checkBox_Conventional_Pap_smear_3.DataBindings.Clear();
            checkBox_Conventional_Pap_smear_3.DataBindings.Clear();
            checkBox_Low_squamous_cellularity_3.DataBindings.Clear();
            checkBox_Air_drying_artifacts_3.DataBindings.Clear();
            checkBox_Obscured_by_inflammatory_exudates_3.DataBindings.Clear();
            checkBox_Obscured_by_blood_3.DataBindings.Clear();
            checkBox_Thick_smear_3.DataBindings.Clear();
            comboBox_DIAGNOSIS_1_3.DataBindings.Clear();
            textBox_DIAGNOSIS_1_3.DataBindings.Clear();
            comboBox_DIAGNOSIS_2_3.DataBindings.Clear();
            textBox_DIAGNOSIS_2_3.DataBindings.Clear();
            comboBox_DIAGNOSIS_3_3.DataBindings.Clear();
            textBox_DIAGNOSIS_3_3.DataBindings.Clear();
            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.DataBindings.Clear();
            checkBox_Reactive_cellular_changes_associated_3.DataBindings.Clear();
            checkBox_Normal_flora_3.DataBindings.Clear();
            checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.DataBindings.Clear();
            checkBox_Herpes_simplex_virus_3.DataBindings.Clear();
            checkBox_Candida_Monilia_3.DataBindings.Clear();
            checkBox_Trichomonas_vaginalis_3.DataBindings.Clear();
            checkBox_Actinomyces_3.DataBindings.Clear();
            checkBox_Endometrial_cells_3.DataBindings.Clear();
            checkBox_Others_eg_follicular_cervicitis_RT_effect_3.DataBindings.Clear();
            checkBox_HPV_DNA_TESTING_3.DataBindings.Clear();
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.DataBindings.Clear();
            checkBox_Atypical_squamous_cells_3.DataBindings.Clear();
            checkBox_ASC_US_3.DataBindings.Clear();
            checkBox_ASC_H_3.DataBindings.Clear();
            checkBox_Squamous_intraepithelial_lesion_SIL_3.DataBindings.Clear();
            checkBox_Low_grade_SIL_3.DataBindings.Clear();
            checkBox_High_grade_SIL_3.DataBindings.Clear();
            checkBox_HSIL_3.DataBindings.Clear();
            checkBox_Squamous_cell_carcinoma_3.DataBindings.Clear();
            checkBox_Atypical_glandular_cells_3.DataBindings.Clear();
            checkBox_Atypical_glandular_cells_NOS_3.DataBindings.Clear();
            checkBox_Atypical_endocervical_cells_NOS_3.DataBindings.Clear();
            checkBox_Atypical_endometrial_cells_NOS_3.DataBindings.Clear();
            checkBox_Adenocarcinoma_3.DataBindings.Clear();
            checkBox_Endocervial_adenocarcinoma_in_situ_3.DataBindings.Clear();
            checkBox_Endocervial_adenocarcinoma_3.DataBindings.Clear();
            checkBox_Endometrial_adenocarcinoma_3.DataBindings.Clear();
            checkBox_Adenocarcinoma_NOS_3.DataBindings.Clear();
            checkBox_Other_malignant_neoplasm_3.DataBindings.Clear();

            string doctorSql1 = "SELECT doctor FROM [sign_doctor] order by doctor";
            DataSet doctorDataSet1 = new DataSet();
            SqlDataAdapter doctorDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql1, doctorDataSet1, "sign_doctor");

            DataTable doctorDt1 = new DataTable();
            doctorDt1.Columns.Add("doctor");
            DataTable doctorDt2 = doctorDt1.Clone();
            DataTable doctorDt3 = doctorDt1.Clone();

            foreach (DataRow mDr in doctorDataSet1.Tables["sign_doctor"].Rows)
            {
                doctorDt1.Rows.Add(new object[] { mDr["doctor"] });
                doctorDt2.Rows.Add(new object[] { mDr["doctor"] });
                doctorDt3.Rows.Add(new object[] { mDr["doctor"] });
            }

            comboBox_Sign_By_1.DataSource = doctorDt1;
            comboBox_Sign_By_2.DataSource = doctorDt2;
            comboBox_Sign_By_3.DataSource = doctorDt3;

            string siteSql = "SELECT [site],[desc] FROM [cy_site] WHERE site is not null ORDER BY site";
            DataSet siteDataSet = new DataSet();
            SqlDataAdapter siteDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(siteSql, siteDataSet, "cy_site");

            DataTable siteDt1 = new DataTable();
            siteDt1.Columns.Add("site");
            siteDt1.Columns.Add("Desc");
            DataTable siteDt2 = siteDt1.Clone();
            DataTable siteDt3 = siteDt1.Clone();

            foreach (DataRow mDr in siteDataSet.Tables["cy_site"].Rows)
            {
                siteDt1.Rows.Add(new object[] { mDr["site"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                siteDt2.Rows.Add(new object[] { mDr["site"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                siteDt3.Rows.Add(new object[] { mDr["site"].ToString().Trim(), mDr["desc"].ToString().Trim() });
            }

            comboBox_DIAGNOSIS_1_1.DataSource = siteDt1;
            comboBox_DIAGNOSIS_1_2.DataSource = siteDt2;
            comboBox_DIAGNOSIS_1_3.DataSource = siteDt3;

            string diagSql = "SELECT [diag],[desc] FROM [cy_diag] WHERE diag is not null ORDER BY diag";
            DataSet diagDataSet = new DataSet();
            SqlDataAdapter diagDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diagSql, diagDataSet, "cy_diag");

            DataTable diagDt1 = new DataTable();
            diagDt1.Columns.Add("diag");
            diagDt1.Columns.Add("Desc");
            DataTable diagDt2 = diagDt1.Clone();
            DataTable diagDt3 = diagDt1.Clone();
            DataTable diagDt4 = diagDt1.Clone();
            DataTable diagDt5 = diagDt1.Clone();
            DataTable diagDt6 = diagDt1.Clone();

            foreach (DataRow mDr in diagDataSet.Tables["cy_diag"].Rows)
            {
                diagDt1.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt2.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt3.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt4.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt5.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt6.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
            }

            comboBox_DIAGNOSIS_2_1.DataSource = diagDt1;
            comboBox_DIAGNOSIS_2_2.DataSource = diagDt2;
            comboBox_DIAGNOSIS_2_3.DataSource = diagDt3;
            comboBox_DIAGNOSIS_3_1.DataSource = diagDt4;
            comboBox_DIAGNOSIS_3_2.DataSource = diagDt5;
            comboBox_DIAGNOSIS_3_3.DataSource = diagDt6;

            textBox_ID1.DataBindings.Add("Text", dt1, "id", false);
            textBox_ID2.DataBindings.Add("Text", dt2, "id", false);
            textBox_ID3.DataBindings.Add("Text", dt3, "id", false);

            //sheet1
            textBox_Sign_At_1.DataBindings.Add("Text", dt1, "sign_at", false);
            textBox_Sign_By_1.DataBindings.Add("Text", dt1, "sign_id", false);
            comboBox_Sign_By_1.DataBindings.Add("SelectedValue", dt1, "sign_by", false);

            checkBox_Cervix_1.DataBindings.Add("Checked", dt1, "site1", false);
            checkBox_Vagina_Vault_1.DataBindings.Add("Checked", dt1, "site2", false);

            checkBox_Satisfactory_for_evaluation_1.DataBindings.Add("Checked", dt1, "specimena1", false);
            checkBox_Satisfactory_for_evaluation_but_1.DataBindings.Add("Checked", dt1, "specimena2", false);
            checkBox_Unsatisfactory_for_evaluation_1.DataBindings.Add("Checked", dt1, "specimena3", false);

            checkBox_Transformation_zone_1.DataBindings.Add("Checked", dt1, "cellularc1", false);
            checkBox_Mainly_superficial_and_intermediate_cells_1.DataBindings.Add("Checked", dt1, "cellularc2", false);
            checkBox_Mainly_intermediate_and_parabasal_cells_1.DataBindings.Add("Checked", dt1, "cellularc3", false);
            checkBox_trophic_pattern_in_menopause_1.DataBindings.Add("Checked", dt1, "cellularc4", false);
            checkBox_Post_partum_changes_1.DataBindings.Add("Checked", dt1, "cellularc5", false);

            comboBox_SITE_TYPE_1.DataBindings.Add("SelectedValue", dt1, "site", false);
            textBox_SITE_TYPE_1.DataBindings.Add("Text", dt1, "site_desc", false);

            checkBox_Liquid_based_preparation_1.DataBindings.Add("Checked", dt1, "prepair1", false);
            checkBox_Liquid_based_preparations_1.DataBindings.Add("Checked", dt1, "prepair2", false);
            checkBox_Conventional_Pap_smear_1.DataBindings.Add("Checked", dt1, "prepair3", false);
            checkBox_Conventional_Pap_smears_1.DataBindings.Add("Checked", dt1, "prepair4", false);

            checkBox_Low_squamous_cellularity_1.DataBindings.Add("Checked", dt1, "specimenq1", false);
            checkBox_Air_drying_artifacts_1.DataBindings.Add("Checked", dt1, "specimenq2", false);
            checkBox_Obscured_by_inflammatory_exudates_1.DataBindings.Add("Checked", dt1, "specimenq3", false);
            checkBox_Obscured_by_blood_1.DataBindings.Add("Checked", dt1, "specimenq4", false);
            checkBox_Thick_smear_1.DataBindings.Add("Checked", dt1, "specimenq5", false);

            comboBox_DIAGNOSIS_1_1.DataBindings.Add("SelectedValue", dt1, "diag1", false);
            textBox_DIAGNOSIS_1_1.DataBindings.Add("Text", dt1, "diag1_desc", false);
            comboBox_DIAGNOSIS_2_1.DataBindings.Add("SelectedValue", dt1, "diag2", false);
            textBox_DIAGNOSIS_2_1.DataBindings.Add("Text", dt1, "diag2_desc", false);
            comboBox_DIAGNOSIS_3_1.DataBindings.Add("SelectedValue", dt1, "diag3", false);
            textBox_DIAGNOSIS_3_1.DataBindings.Add("Text", dt1, "diag3_desc", false);

            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.DataBindings.Add("Checked", dt1, "interneg", false);
            checkBox_Reactive_cellular_changes_associated_1.DataBindings.Add("Checked", dt1, "interneg1", false);
            checkBox_Normal_flora_1.DataBindings.Add("Checked", dt1, "interneg2", false);
            checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1.DataBindings.Add("Checked", dt1, "interneg3", false);
            checkBox_Herpes_simplex_virus_1.DataBindings.Add("Checked", dt1, "interneg4", false);
            checkBox_Candida_Monilia_1.DataBindings.Add("Checked", dt1, "interneg5", false);
            checkBox_Trichomonas_vaginalis_1.DataBindings.Add("Checked", dt1, "interneg6", false);
            checkBox_Actinomyces_1.DataBindings.Add("Checked", dt1, "interneg7", false);
            checkBox_Endometrial_cells_1.DataBindings.Add("Checked", dt1, "interneg8", false);
            checkBox_Others_eg_follicular_cervicitis_RT_effect_1.DataBindings.Add("Checked", dt1, "interneg9", false);

            checkBox_HPV_DNA_TESTING_1.DataBindings.Add("Checked", dt1, "hpv_dna", false);

            checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.DataBindings.Add("Checked", dt1, "interepi", false);
            checkBox_Atypical_squamous_cells_1.DataBindings.Add("Checked", dt1, "interepi1", false);
            checkBox_ASC_US_1.DataBindings.Add("Checked", dt1, "interepi1a", false);
            checkBox_ASC_H_1.DataBindings.Add("Checked", dt1, "interepi1b", false);

            checkBox_Squamous_intraepithelial_lesion_SIL_1.DataBindings.Add("Checked", dt1, "interepi2", false);
            checkBox_Low_grade_SIL_1.DataBindings.Add("Checked", dt1, "interepi2a", false);
            checkBox_High_grade_SIL_1.DataBindings.Add("Checked", dt1, "interepi2b", false);
            checkBox_HSIL_1.DataBindings.Add("Checked", dt1, "interepi2c", false);

            checkBox_Squamous_cell_carcinoma_1.DataBindings.Add("Checked", dt1, "interepi3", false);

            checkBox_Atypical_glandular_cells_1.DataBindings.Add("Checked", dt1, "interepi4", false);
            checkBox_Atypical_glandular_cells_NOS_1.DataBindings.Add("Checked", dt1, "interepi4a", false);
            checkBox_Atypical_endocervical_cells_NOS_1.DataBindings.Add("Checked", dt1, "interepi4b", false);
            checkBox_Atypical_endometrial_cells_NOS_1.DataBindings.Add("Checked", dt1, "interepi4c", false);

            checkBox_Adenocarcinoma_1.DataBindings.Add("Checked", dt1, "interepi5", false);

            checkBox_Endocervial_adenocarcinoma_in_situ_1.DataBindings.Add("Checked", dt1, "interepi5a", false);
            checkBox_Endocervial_adenocarcinoma_1.DataBindings.Add("Checked", dt1, "interepi5b", false);
            checkBox_Endometrial_adenocarcinoma_1.DataBindings.Add("Checked", dt1, "interepi5c", false);
            checkBox_Adenocarcinoma_NOS_1.DataBindings.Add("Checked", dt1, "interepi5d", false);

            checkBox_Other_malignant_neoplasm_1.DataBindings.Add("Checked", dt1, "interepi6", false);

            label_Printed_By_No.DataBindings.Add("Text", dt1, "print_by", false);
            label_Printed_At_Date.DataBindings.Add("Text", dt1, "print_at", false);

            //sheet2
            textBox_Sign_At_2.DataBindings.Add("Text", dt2, "sign_at", false);
            textBox_Sign_By_2.DataBindings.Add("Text", dt2, "sign_id", false);
            comboBox_Sign_By_2.DataBindings.Add("SelectedValue", dt2, "sign_by", false);

            checkBox_Cervix_2.DataBindings.Add("Checked", dt2, "site1", false);
            checkBox_Vagina_Vault_2.DataBindings.Add("Checked", dt2, "site2", false);

            checkBox_Satisfactory_for_evaluation_2.DataBindings.Add("Checked", dt2, "specimena1", false);
            checkBox_Satisfactory_for_evaluation_but_2.DataBindings.Add("Checked", dt2, "specimena2", false);
            checkBox_Unsatisfactory_for_evaluation_2.DataBindings.Add("Checked", dt2, "specimena3", false);

            checkBox_Transformation_zone_2.DataBindings.Add("Checked", dt2, "cellularc1", false);
            checkBox_Mainly_superficial_and_intermediate_cells_2.DataBindings.Add("Checked", dt2, "cellularc2", false);
            checkBox_Mainly_intermediate_and_parabasal_cells_2.DataBindings.Add("Checked", dt2, "cellularc3", false);
            checkBox_trophic_pattern_in_menopause_2.DataBindings.Add("Checked", dt2, "cellularc4", false);
            checkBox_Post_partum_changes_2.DataBindings.Add("Checked", dt2, "cellularc5", false);

            comboBox_SITE_TYPE_2.DataBindings.Add("SelectedValue", dt2, "site", false);
            textBox_SITE_TYPE_2.DataBindings.Add("Text", dt2, "site_desc", false);

            checkBox_Liquid_based_preparation_2.DataBindings.Add("Checked", dt2, "prepair1", false);
            checkBox_Liquid_based_preparations_2.DataBindings.Add("Checked", dt2, "prepair2", false);
            checkBox_Conventional_Pap_smear_2.DataBindings.Add("Checked", dt2, "prepair3", false);
            checkBox_Conventional_Pap_smears_2.DataBindings.Add("Checked", dt2, "prepair4", false);

            checkBox_Low_squamous_cellularity_2.DataBindings.Add("Checked", dt2, "specimenq1", false);
            checkBox_Air_drying_artifacts_2.DataBindings.Add("Checked", dt2, "specimenq2", false);
            checkBox_Obscured_by_inflammatory_exudates_2.DataBindings.Add("Checked", dt2, "specimenq3", false);
            checkBox_Obscured_by_blood_2.DataBindings.Add("Checked", dt2, "specimenq4", false);
            checkBox_Thick_smear_2.DataBindings.Add("Checked", dt2, "specimenq5", false);

            comboBox_DIAGNOSIS_1_2.DataBindings.Add("SelectedValue", dt2, "diag1", false);
            textBox_DIAGNOSIS_1_2.DataBindings.Add("Text", dt2, "diag1_desc", false);
            comboBox_DIAGNOSIS_2_2.DataBindings.Add("SelectedValue", dt2, "diag2", false);
            textBox_DIAGNOSIS_2_2.DataBindings.Add("Text", dt2, "diag2_desc", false);
            comboBox_DIAGNOSIS_3_2.DataBindings.Add("SelectedValue", dt2, "diag3", false);
            textBox_DIAGNOSIS_3_2.DataBindings.Add("Text", dt2, "diag3_desc", false);

            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.DataBindings.Add("Checked", dt2, "interneg", false);
            checkBox_Reactive_cellular_changes_associated_2.DataBindings.Add("Checked", dt2, "interneg1", false);
            checkBox_Normal_flora_2.DataBindings.Add("Checked", dt2, "interneg2", false);
            checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2.DataBindings.Add("Checked", dt2, "interneg3", false);
            checkBox_Herpes_simplex_virus_2.DataBindings.Add("Checked", dt2, "interneg4", false);
            checkBox_Candida_Monilia_2.DataBindings.Add("Checked", dt2, "interneg5", false);
            checkBox_Trichomonas_vaginalis_2.DataBindings.Add("Checked", dt2, "interneg6", false);
            checkBox_Actinomyces_2.DataBindings.Add("Checked", dt2, "interneg7", false);
            checkBox_Endometrial_cells_2.DataBindings.Add("Checked", dt2, "interneg8", false);
            checkBox_Others_eg_follicular_cervicitis_RT_effect_2.DataBindings.Add("Checked", dt2, "interneg9", false);

            checkBox_HPV_DNA_TESTING_2.DataBindings.Add("Checked", dt2, "hpv_dna", false);

            checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.DataBindings.Add("Checked", dt2, "interepi", false);
            checkBox_Atypical_squamous_cells_2.DataBindings.Add("Checked", dt2, "interepi1", false);
            checkBox_ASC_US_2.DataBindings.Add("Checked", dt2, "interepi1a", false);
            checkBox_ASC_H_2.DataBindings.Add("Checked", dt2, "interepi1b", false);

            checkBox_Squamous_intraepithelial_lesion_SIL_2.DataBindings.Add("Checked", dt2, "interepi2", false);
            checkBox_Low_grade_SIL_2.DataBindings.Add("Checked", dt2, "interepi2a", false);
            checkBox_High_grade_SIL_2.DataBindings.Add("Checked", dt2, "interepi2b", false);
            checkBox_HSIL_2.DataBindings.Add("Checked", dt2, "interepi2c", false);

            checkBox_Squamous_cell_carcinoma_2.DataBindings.Add("Checked", dt2, "interepi3", false);

            checkBox_Atypical_glandular_cells_2.DataBindings.Add("Checked", dt2, "interepi4", false);
            checkBox_Atypical_glandular_cells_NOS_2.DataBindings.Add("Checked", dt2, "interepi4a", false);
            checkBox_Atypical_endocervical_cells_NOS_2.DataBindings.Add("Checked", dt2, "interepi4b", false);
            checkBox_Atypical_endometrial_cells_NOS_2.DataBindings.Add("Checked", dt2, "interepi4c", false);

            checkBox_Adenocarcinoma_2.DataBindings.Add("Checked", dt2, "interepi5", false);

            checkBox_Endocervial_adenocarcinoma_in_situ_2.DataBindings.Add("Checked", dt2, "interepi5a", false);
            checkBox_Endocervial_adenocarcinoma_2.DataBindings.Add("Checked", dt2, "interepi5b", false);
            checkBox_Endometrial_adenocarcinoma_2.DataBindings.Add("Checked", dt2, "interepi5c", false);
            checkBox_Adenocarcinoma_NOS_2.DataBindings.Add("Checked", dt2, "interepi5d", false);

            checkBox_Other_malignant_neoplasm_2.DataBindings.Add("Checked", dt2, "interepi6", false);


            //sheet3
            textBox_Sign_At_3.DataBindings.Add("Text", dt3, "sign_at", false);
            textBox_Sign_By_3.DataBindings.Add("Text", dt3, "sign_id", false);
            comboBox_Sign_By_3.DataBindings.Add("SelectedValue", dt3, "sign_by", false);

            checkBox_Cervix_3.DataBindings.Add("Checked", dt3, "site1", false);
            checkBox_Vagina_Vault_3.DataBindings.Add("Checked", dt3, "site2", false);

            checkBox_Satisfactory_for_evaluation_3.DataBindings.Add("Checked", dt3, "specimena1", false);
            checkBox_Satisfactory_for_evaluation_but_3.DataBindings.Add("Checked", dt3, "specimena2", false);
            checkBox_Unsatisfactory_for_evaluation_3.DataBindings.Add("Checked", dt3, "specimena3", false);

            checkBox_Transformation_zone_3.DataBindings.Add("Checked", dt3, "cellularc1", false);
            checkBox_Mainly_superficial_and_intermediate_cells_3.DataBindings.Add("Checked", dt3, "cellularc2", false);
            checkBox_Mainly_intermediate_and_parabasal_cells_3.DataBindings.Add("Checked", dt3, "cellularc3", false);
            checkBox_trophic_pattern_in_menopause_3.DataBindings.Add("Checked", dt3, "cellularc4", false);
            checkBox_Post_partum_changes_3.DataBindings.Add("Checked", dt3, "cellularc5", false);

            comboBox_SITE_TYPE_3.DataBindings.Add("SelectedValue", dt3, "site", false);
            textBox_SITE_TYPE_3.DataBindings.Add("Text", dt3, "site_desc", false);

            checkBox_Liquid_based_preparation_3.DataBindings.Add("Checked", dt3, "prepair1", false);
            checkBox_Liquid_based_preparations_3.DataBindings.Add("Checked", dt3, "prepair2", false);
            checkBox_Conventional_Pap_smear_3.DataBindings.Add("Checked", dt3, "prepair3", false);
            checkBox_Conventional_Pap_smears_3.DataBindings.Add("Checked", dt3, "prepair4", false);

            checkBox_Low_squamous_cellularity_3.DataBindings.Add("Checked", dt3, "specimenq1", false);
            checkBox_Air_drying_artifacts_3.DataBindings.Add("Checked", dt3, "specimenq2", false);
            checkBox_Obscured_by_inflammatory_exudates_3.DataBindings.Add("Checked", dt3, "specimenq3", false);
            checkBox_Obscured_by_blood_3.DataBindings.Add("Checked", dt3, "specimenq4", false);
            checkBox_Thick_smear_3.DataBindings.Add("Checked", dt3, "specimenq5", false);

            comboBox_DIAGNOSIS_1_3.DataBindings.Add("SelectedValue", dt3, "diag1", false);
            textBox_DIAGNOSIS_1_3.DataBindings.Add("Text", dt3, "diag1_desc", false);
            comboBox_DIAGNOSIS_2_3.DataBindings.Add("SelectedValue", dt3, "diag2", false);
            textBox_DIAGNOSIS_2_3.DataBindings.Add("Text", dt3, "diag2_desc", false);
            comboBox_DIAGNOSIS_3_3.DataBindings.Add("SelectedValue", dt3, "diag3", false);
            textBox_DIAGNOSIS_3_3.DataBindings.Add("Text", dt3, "diag3_desc", false);

            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.DataBindings.Add("Checked", dt3, "interneg", false);
            checkBox_Reactive_cellular_changes_associated_3.DataBindings.Add("Checked", dt3, "interneg1", false);
            checkBox_Normal_flora_3.DataBindings.Add("Checked", dt3, "interneg2", false);
            checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.DataBindings.Add("Checked", dt3, "interneg3", false);
            checkBox_Herpes_simplex_virus_3.DataBindings.Add("Checked", dt3, "interneg4", false);
            checkBox_Candida_Monilia_3.DataBindings.Add("Checked", dt3, "interneg5", false);
            checkBox_Trichomonas_vaginalis_3.DataBindings.Add("Checked", dt3, "interneg6", false);
            checkBox_Actinomyces_3.DataBindings.Add("Checked", dt3, "interneg7", false);
            checkBox_Endometrial_cells_3.DataBindings.Add("Checked", dt3, "interneg8", false);
            checkBox_Others_eg_follicular_cervicitis_RT_effect_3.DataBindings.Add("Checked", dt3, "interneg9", false);

            checkBox_HPV_DNA_TESTING_3.DataBindings.Add("Checked", dt3, "hpv_dna", false);

            checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.DataBindings.Add("Checked", dt3, "interepi", false);
            checkBox_Atypical_squamous_cells_3.DataBindings.Add("Checked", dt3, "interepi1", false);
            checkBox_ASC_US_3.DataBindings.Add("Checked", dt3, "interepi1a", false);
            checkBox_ASC_H_3.DataBindings.Add("Checked", dt3, "interepi1b", false);

            checkBox_Squamous_intraepithelial_lesion_SIL_3.DataBindings.Add("Checked", dt3, "interepi2", false);
            checkBox_Low_grade_SIL_3.DataBindings.Add("Checked", dt3, "interepi2a", false);
            checkBox_High_grade_SIL_3.DataBindings.Add("Checked", dt3, "interepi2b", false);
            checkBox_HSIL_3.DataBindings.Add("Checked", dt3, "interepi2c", false);

            checkBox_Squamous_cell_carcinoma_3.DataBindings.Add("Checked", dt3, "interepi3", false);

            checkBox_Atypical_glandular_cells_3.DataBindings.Add("Checked", dt3, "interepi4", false);
            checkBox_Atypical_glandular_cells_NOS_3.DataBindings.Add("Checked", dt3, "interepi4a", false);
            checkBox_Atypical_endocervical_cells_NOS_3.DataBindings.Add("Checked", dt3, "interepi4b", false);
            checkBox_Atypical_endometrial_cells_NOS_3.DataBindings.Add("Checked", dt3, "interepi4c", false);

            checkBox_Adenocarcinoma_3.DataBindings.Add("Checked", dt3, "interepi5", false);

            checkBox_Endocervial_adenocarcinoma_in_situ_3.DataBindings.Add("Checked", dt3, "interepi5a", false);
            checkBox_Endocervial_adenocarcinoma_3.DataBindings.Add("Checked", dt3, "interepi5b", false);
            checkBox_Endometrial_adenocarcinoma_3.DataBindings.Add("Checked", dt3, "interepi5c", false);
            checkBox_Adenocarcinoma_NOS_3.DataBindings.Add("Checked", dt3, "interepi5d", false);

            checkBox_Other_malignant_neoplasm_3.DataBindings.Add("Checked", dt3, "interepi6", false);
        }
    }
}
