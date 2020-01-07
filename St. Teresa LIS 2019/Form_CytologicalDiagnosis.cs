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
      	private Form_CYTOLOGYFileGyname fileForm;
      	private String reportWording = "";

        private int currentStatus;
        private string caseNo;

        private DataSet cyDiagDataSet1 = new DataSet();
        private SqlDataAdapter cyDiagDataAdapter1;

        private DataSet cyDiagDataSet2 = new DataSet();
        private SqlDataAdapter cyDiagDataAdapter2;

        private DataSet cyDiagDataSet3 = new DataSet();
        private SqlDataAdapter cyDiagDataAdapter3;

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

        public void setPreviousFileForm(Form_CYTOLOGYFileGyname fileForm)
        {
            this.fileForm = fileForm;
        }

        private void initCurrentEditRow(DataRow currentEditRow)
        {
            currentEditRow["site1"] = false;
            currentEditRow["site2"] = false;
            currentEditRow["specimena1"] = false;
            currentEditRow["specimena2"] = false;
            currentEditRow["specimena3"] = false;
            currentEditRow["cellularc1"] = false;
            currentEditRow["cellularc2"] = false;
            currentEditRow["cellularc3"] = false;
            currentEditRow["cellularc4"] = false;
            currentEditRow["cellularc5"] = false;
            currentEditRow["prepair1"] = false;
            currentEditRow["prepair2"] = false;
            currentEditRow["prepair3"] = false;
            currentEditRow["prepair4"] = false;
            currentEditRow["specimenq1"] = false;
            currentEditRow["specimenq2"] = false;
            currentEditRow["specimenq3"] = false;
            currentEditRow["specimenq4"] = false;
            currentEditRow["specimenq5"] = false;
            currentEditRow["interneg"] = false;
            currentEditRow["interneg1"] = false;
            currentEditRow["interneg2"] = false;
            currentEditRow["interneg3"] = false;
            currentEditRow["interneg4"] = false;
            currentEditRow["interneg5"] = false;
            currentEditRow["interneg6"] = false;
            currentEditRow["interneg7"] = false;
            currentEditRow["interneg8"] = false;
            currentEditRow["interneg9"] = false;
            currentEditRow["hpv_dna"] = false;
            currentEditRow["interepi"] = false;
            currentEditRow["interepi1"] = false;
            currentEditRow["interepi1a"] = false;
            currentEditRow["interepi1b"] = false;
            currentEditRow["interepi2"] = false;
            currentEditRow["interepi2a"] = false;
            currentEditRow["interepi2b"] = false;
            currentEditRow["interepi2c"] = false;
            currentEditRow["interepi3"] = false;
            currentEditRow["interepi4"] = false;
            currentEditRow["interepi4a"] = false;
            currentEditRow["interepi4b"] = false;
            currentEditRow["interepi4c"] = false;
            currentEditRow["interepi5"] = false;
            currentEditRow["interepi5a"] = false;
            currentEditRow["interepi5b"] = false;
            currentEditRow["interepi5c"] = false;
            currentEditRow["interepi5d"] = false;
            currentEditRow["interepi6"] = false;
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
            setButtonStatus(currentStatus);

            if (currentStatus == PageStatus.STATUS_VIEW)
            {
                reloadAndBindingDBData();
            }
            else
            {
                if (existCyDiagDataSet1 != null && existCyDiagDataSet2 != null && existCyDiagDataSet3 != null)
                {
                    reloadAndBindingDBDataWithExistDataSet();
                }
                else
                {
                    reloadAndBindingDBData();
                }

                if ((currentStatus == PageStatus.STATUS_NEW && existCyDiagDataSet1 == null && existCyDiagDataSet2 == null && existCyDiagDataSet3 == null)
                    || ((currentStatus == PageStatus.STATUS_EDIT || currentStatus == PageStatus.STATUS_ADVANCE_EDIT ) && cyDiagDataSet1.Tables[0].Rows.Count == 0
                    && cyDiagDataSet2.Tables[0].Rows.Count == 0 && cyDiagDataSet3.Tables[0].Rows.Count == 0))
                {
                    currentEditRow1 = cyDiagDataSet1.Tables[0].NewRow();
                    initCurrentEditRow(currentEditRow1);
                    cyDiagDataSet1.Tables[0].Rows.Clear();
                    cyDiagDataSet1.Tables[0].Rows.Add(currentEditRow1);

                    currentEditRow2 = cyDiagDataSet2.Tables[0].NewRow();
                    initCurrentEditRow(currentEditRow2);
                    cyDiagDataSet2.Tables[0].Rows.Clear();
                    cyDiagDataSet2.Tables[0].Rows.Add(currentEditRow2);

                    currentEditRow3 = cyDiagDataSet3.Tables[0].NewRow();
                    initCurrentEditRow(currentEditRow3);
                    cyDiagDataSet3.Tables[0].Rows.Clear();
                    cyDiagDataSet3.Tables[0].Rows.Add(currentEditRow3);
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
            textBox_ID1.BindingContext[dt1].Position++;
            textBox_ID2.BindingContext[dt2].Position++;
            textBox_ID3.BindingContext[dt3].Position++;
            if (OnCyDiagExit != null)
            {
                OnCyDiagExit(cyDiagDataSet1, cyDiagDataSet2, cyDiagDataSet3, cyDiagDataAdapter1, cyDiagDataAdapter2, cyDiagDataAdapter3);
            }

            reportWording = "";
            generateReportWording();
            if (fileForm != null)
            {
                fileForm.setReportWording(reportWording);
            }
            
            //this.Hide();

            this.Close();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            Form_GynaecologicalCytologyReport open = new Form_GynaecologicalCytologyReport();
            open.Show();
        }


        private void checkBox_Cervix_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cervix_1.Checked)
            {
                checkBox_Vagina_Vault_1.Checked = false;
            }
        }

        private void checkBox_Vagina_Vault_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Vagina_Vault_1.Checked)
            {
                checkBox_Cervix_1.Checked = false;
            }
        }

        private void checkBox_Cervix_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cervix_2.Checked)
            {
                checkBox_Vagina_Vault_2.Checked = false;
            }
        }

        private void checkBox_Vagina_Vault_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Vagina_Vault_2.Checked)
            {
                checkBox_Cervix_2.Checked = false;
            }
        }

        private void checkBox_Cervix_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cervix_3.Checked)
            {
                checkBox_Vagina_Vault_3.Checked = false;
            }
        }

        private void checkBox_Vagina_Vault_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Vagina_Vault_3.Checked)
            {
                checkBox_Cervix_3.Checked = false;
            }
        }

        private void checkBox_Satisfactory_for_evaluation_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Satisfactory_for_evaluation_1.Checked)
            {
                checkBox_Satisfactory_for_evaluation_but_1.Checked = false;
                checkBox_Unsatisfactory_for_evaluation_1.Checked = false;
            }
        }

        private void checkBox_Satisfactory_for_evaluation_but_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Satisfactory_for_evaluation_but_1.Checked)
            {
                checkBox_Satisfactory_for_evaluation_1.Checked = false;
                checkBox_Unsatisfactory_for_evaluation_1.Checked = false;
            }
        }

        private void checkBox_Unsatisfactory_for_evaluation_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Unsatisfactory_for_evaluation_1.Checked)
            {
                checkBox_Satisfactory_for_evaluation_1.Checked = false;
                checkBox_Satisfactory_for_evaluation_but_1.Checked = false;
            }
        }

        private void checkBox_Satisfactory_for_evaluation_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Satisfactory_for_evaluation_2.Checked)
            {
                checkBox_Satisfactory_for_evaluation_but_2.Checked = false;
                checkBox_Unsatisfactory_for_evaluation_2.Checked = false;
            }
        }

        private void checkBox_Satisfactory_for_evaluation_but_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Satisfactory_for_evaluation_but_2.Checked)
            {
                checkBox_Satisfactory_for_evaluation_2.Checked = false;
                checkBox_Unsatisfactory_for_evaluation_2.Checked = false;
            }
        }

        private void checkBox_Unsatisfactory_for_evaluation_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Unsatisfactory_for_evaluation_2.Checked)
            {
                checkBox_Satisfactory_for_evaluation_2.Checked = false;
                checkBox_Satisfactory_for_evaluation_but_2.Checked = false;
            }
        }

        private void checkBox_Satisfactory_for_evaluation_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Satisfactory_for_evaluation_3.Checked)
            {
                checkBox_Satisfactory_for_evaluation_but_3.Checked = false;
                checkBox_Unsatisfactory_for_evaluation_3.Checked = false;
            }
        }

        private void checkBox_Satisfactory_for_evaluation_but_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Satisfactory_for_evaluation_but_3.Checked)
            {
                checkBox_Satisfactory_for_evaluation_3.Checked = false;
                checkBox_Unsatisfactory_for_evaluation_3.Checked = false;
            }
        }

        private void checkBox_Unsatisfactory_for_evaluation_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Unsatisfactory_for_evaluation_3.Checked)
            {
                checkBox_Satisfactory_for_evaluation_3.Checked = false;
                checkBox_Satisfactory_for_evaluation_but_3.Checked = false;
            }
        }

        private void checkBox_Mainly_superficial_and_intermediate_cells_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mainly_superficial_and_intermediate_cells_1.Checked)
            {
                checkBox_Mainly_intermediate_and_parabasal_cells_1.Checked = false;
                checkBox_trophic_pattern_in_menopause_1.Checked = false;
                checkBox_Post_partum_changes_1.Checked = false;
            }
        }

        private void checkBox_Mainly_intermediate_and_parabasal_cells_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mainly_intermediate_and_parabasal_cells_1.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_1.Checked = false;
                checkBox_trophic_pattern_in_menopause_1.Checked = false;
                checkBox_Post_partum_changes_1.Checked = false;
            }
        }

        private void checkBox_trophic_pattern_in_menopause_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_trophic_pattern_in_menopause_1.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_1.Checked = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_1.Checked = false;
                checkBox_Post_partum_changes_1.Checked = false;
            }
        }

        private void checkBox_Post_partum_changes_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Post_partum_changes_1.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_1.Checked = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_1.Checked = false;
                checkBox_trophic_pattern_in_menopause_1.Checked = false;
            }
        }

        private void checkBox_Mainly_superficial_and_intermediate_cells_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mainly_superficial_and_intermediate_cells_2.Checked)
            {
                checkBox_Mainly_intermediate_and_parabasal_cells_2.Checked = false;
                checkBox_trophic_pattern_in_menopause_2.Checked = false;
                checkBox_Post_partum_changes_2.Checked = false;
            }
        }

        private void checkBox_Mainly_intermediate_and_parabasal_cells_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mainly_intermediate_and_parabasal_cells_2.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_2.Checked = false;
                checkBox_trophic_pattern_in_menopause_2.Checked = false;
                checkBox_Post_partum_changes_2.Checked = false;
            }
        }

        private void checkBox_trophic_pattern_in_menopause_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_trophic_pattern_in_menopause_2.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_2.Checked = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_2.Checked = false;
                checkBox_Post_partum_changes_2.Checked = false;
            }
        }

        private void checkBox_Post_partum_changes_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Post_partum_changes_2.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_2.Checked = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_2.Checked = false;
                checkBox_trophic_pattern_in_menopause_2.Checked = false;
            }
        }

        private void checkBox_Mainly_superficial_and_intermediate_cells_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mainly_superficial_and_intermediate_cells_3.Checked)
            {
                checkBox_Mainly_intermediate_and_parabasal_cells_3.Checked = false;
                checkBox_trophic_pattern_in_menopause_3.Checked = false;
                checkBox_Post_partum_changes_3.Checked = false;
            }
        }

        private void checkBox_Mainly_intermediate_and_parabasal_cells_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mainly_intermediate_and_parabasal_cells_3.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_3.Checked = false;
                checkBox_trophic_pattern_in_menopause_3.Checked = false;
                checkBox_Post_partum_changes_3.Checked = false;
            }
        }

        private void checkBox_trophic_pattern_in_menopause_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_trophic_pattern_in_menopause_3.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_3.Checked = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_3.Checked = false;
                checkBox_Post_partum_changes_3.Checked = false;
            }
        }

        private void checkBox_Post_partum_changes_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Post_partum_changes_3.Checked)
            {
                checkBox_Mainly_superficial_and_intermediate_cells_3.Checked = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_3.Checked = false;
                checkBox_trophic_pattern_in_menopause_3.Checked = false;
            }
        }

        private void checkBox_Liquid_based_preparation_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Liquid_based_preparation_1.Checked)
            {
                checkBox_Liquid_based_preparations_1.Checked = false;
                checkBox_Conventional_Pap_smear_1.Checked = false;
                checkBox_Conventional_Pap_smears_1.Checked = false;
            }
        }

        private void checkBox_Liquid_based_preparations_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Liquid_based_preparations_1.Checked)
            {
                checkBox_Liquid_based_preparation_1.Checked = false;
                checkBox_Conventional_Pap_smear_1.Checked = false;
                checkBox_Conventional_Pap_smears_1.Checked = false;
            }
        }

        private void checkBox_Conventional_Pap_smear_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Conventional_Pap_smear_1.Checked)
            {
                checkBox_Liquid_based_preparation_1.Checked = false;
                checkBox_Liquid_based_preparations_1.Checked = false;
                checkBox_Conventional_Pap_smears_1.Checked = false;
            }
        }

        private void checkBox_Conventional_Pap_smears_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Conventional_Pap_smears_1.Checked)
            {
                checkBox_Liquid_based_preparation_1.Checked = false;
                checkBox_Liquid_based_preparations_1.Checked = false;
                checkBox_Conventional_Pap_smear_1.Checked = false;
            }
        }

        private void checkBox_Liquid_based_preparation_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Liquid_based_preparation_2.Checked)
            {
                checkBox_Liquid_based_preparations_2.Checked = false;
                checkBox_Conventional_Pap_smear_2.Checked = false;
                checkBox_Conventional_Pap_smears_2.Checked = false;
            }
        }

        private void checkBox_Liquid_based_preparations_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Liquid_based_preparations_2.Checked)
            {
                checkBox_Liquid_based_preparation_2.Checked = false;
                checkBox_Conventional_Pap_smear_2.Checked = false;
                checkBox_Conventional_Pap_smears_2.Checked = false;
            }
        }

        private void checkBox_Conventional_Pap_smear_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Conventional_Pap_smear_2.Checked)
            {
                checkBox_Liquid_based_preparation_2.Checked = false;
                checkBox_Liquid_based_preparations_2.Checked = false;
                checkBox_Conventional_Pap_smears_2.Checked = false;
            }
        }

        private void checkBox_Conventional_Pap_smears_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Conventional_Pap_smears_2.Checked)
            {
                checkBox_Liquid_based_preparation_2.Checked = false;
                checkBox_Liquid_based_preparations_2.Checked = false;
                checkBox_Conventional_Pap_smear_2.Checked = false;
            }
        }

        private void checkBox_Liquid_based_preparation_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Liquid_based_preparation_3.Checked)
            {
                checkBox_Liquid_based_preparations_3.Checked = false;
                checkBox_Conventional_Pap_smear_3.Checked = false;
                checkBox_Conventional_Pap_smears_3.Checked = false;
            }
        }

        private void checkBox_Liquid_based_preparations_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Liquid_based_preparations_3.Checked)
            {
                checkBox_Liquid_based_preparation_3.Checked = false;
                checkBox_Conventional_Pap_smear_3.Checked = false;
                checkBox_Conventional_Pap_smears_3.Checked = false;
            }
        }

        private void checkBox_Conventional_Pap_smear_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Conventional_Pap_smear_3.Checked)
            {
                checkBox_Liquid_based_preparation_3.Checked = false;
                checkBox_Liquid_based_preparations_3.Checked = false;
                checkBox_Conventional_Pap_smears_3.Checked = false;
            }
        }

        private void checkBox_Conventional_Pap_smears_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Conventional_Pap_smears_3.Checked)
            {
                checkBox_Liquid_based_preparation_3.Checked = false;
                checkBox_Liquid_based_preparations_3.Checked = false;
                checkBox_Conventional_Pap_smear_3.Checked = false;
            }
        }

        private void checkBox_Low_squamous_cellularity_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Low_squamous_cellularity_1.Checked)
            {
                checkBox_Air_drying_artifacts_1.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_1.Checked = false;
                checkBox_Obscured_by_blood_1.Checked = false;
                checkBox_Thick_smear_1.Checked = false;
            }
        }

        private void checkBox_Air_drying_artifacts_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Air_drying_artifacts_1.Checked)
            {
                checkBox_Low_squamous_cellularity_1.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_1.Checked = false;
                checkBox_Obscured_by_blood_1.Checked = false;
                checkBox_Thick_smear_1.Checked = false;
            }
        }

        private void checkBox_Obscured_by_inflammatory_exudates_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Obscured_by_inflammatory_exudates_1.Checked)
            {
                checkBox_Low_squamous_cellularity_1.Checked = false;
                checkBox_Air_drying_artifacts_1.Checked = false;
                checkBox_Obscured_by_blood_1.Checked = false;
                checkBox_Thick_smear_1.Checked = false;
            }
        }

        private void checkBox_Obscured_by_blood_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Obscured_by_blood_1.Checked)
            {
                checkBox_Low_squamous_cellularity_1.Checked = false;
                checkBox_Air_drying_artifacts_1.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_1.Checked = false;
                checkBox_Thick_smear_1.Checked = false;
            }
        }

        private void checkBox_Thick_smear_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Thick_smear_1.Checked)
            {
                checkBox_Low_squamous_cellularity_1.Checked = false;
                checkBox_Air_drying_artifacts_1.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_1.Checked = false;
                checkBox_Obscured_by_blood_1.Checked = false;
            }
        }

        private void checkBox_Low_squamous_cellularity_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Low_squamous_cellularity_2.Checked)
            {
                checkBox_Air_drying_artifacts_2.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_2.Checked = false;
                checkBox_Obscured_by_blood_2.Checked = false;
                checkBox_Thick_smear_2.Checked = false;
            }
        }

        private void checkBox_Air_drying_artifacts_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Air_drying_artifacts_2.Checked)
            {
                checkBox_Low_squamous_cellularity_2.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_2.Checked = false;
                checkBox_Obscured_by_blood_2.Checked = false;
                checkBox_Thick_smear_2.Checked = false;
            }
        }

        private void checkBox_Obscured_by_inflammatory_exudates_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Obscured_by_inflammatory_exudates_2.Checked)
            {
                checkBox_Low_squamous_cellularity_2.Checked = false;
                checkBox_Air_drying_artifacts_2.Checked = false;
                checkBox_Obscured_by_blood_2.Checked = false;
                checkBox_Thick_smear_2.Checked = false;
            }
        }

        private void checkBox_Obscured_by_blood_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Obscured_by_blood_2.Checked)
            {
                checkBox_Low_squamous_cellularity_2.Checked = false;
                checkBox_Air_drying_artifacts_2.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_2.Checked = false;
                checkBox_Thick_smear_2.Checked = false;
            }
        }

        private void checkBox_Thick_smear_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Thick_smear_2.Checked)
            {
                checkBox_Low_squamous_cellularity_2.Checked = false;
                checkBox_Air_drying_artifacts_2.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_2.Checked = false;
                checkBox_Obscured_by_blood_2.Checked = false;
            }
        }

        private void checkBox_Low_squamous_cellularity_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Low_squamous_cellularity_3.Checked)
            {
                checkBox_Air_drying_artifacts_3.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_3.Checked = false;
                checkBox_Obscured_by_blood_3.Checked = false;
                checkBox_Thick_smear_3.Checked = false;
            }
        }

        private void checkBox_Air_drying_artifacts_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Air_drying_artifacts_3.Checked)
            {
                checkBox_Low_squamous_cellularity_3.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_3.Checked = false;
                checkBox_Obscured_by_blood_3.Checked = false;
                checkBox_Thick_smear_3.Checked = false;
            }
        }

        private void checkBox_Obscured_by_inflammatory_exudates_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Obscured_by_inflammatory_exudates_3.Checked)
            {
                checkBox_Low_squamous_cellularity_3.Checked = false;
                checkBox_Air_drying_artifacts_3.Checked = false;
                checkBox_Obscured_by_blood_3.Checked = false;
                checkBox_Thick_smear_3.Checked = false;
            }
        }

        private void checkBox_Obscured_by_blood_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Obscured_by_blood_3.Checked)
            {
                checkBox_Low_squamous_cellularity_3.Checked = false;
                checkBox_Air_drying_artifacts_3.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_3.Checked = false;
                checkBox_Thick_smear_3.Checked = false;
            }
        }

        private void checkBox_Thick_smear_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Thick_smear_3.Checked)
            {
                checkBox_Low_squamous_cellularity_3.Checked = false;
                checkBox_Air_drying_artifacts_3.Checked = false;
                checkBox_Obscured_by_inflammatory_exudates_3.Checked = false;
                checkBox_Obscured_by_blood_3.Checked = false;
            }
        }

        private void checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked)
            {
                IEnumerable<CheckBox> checkBoxes = panel12.Controls.OfType<CheckBox>();
                foreach (CheckBox cb in checkBoxes)
                {
                    cb.Checked = false;
                }
            }
        }

        private void checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked)
            {
                IEnumerable<CheckBox> checkBoxes = panel2.Controls.OfType<CheckBox>();
                foreach (CheckBox cb in checkBoxes)
                {
                    cb.Checked = false;
                }
            }
        }

        private void checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked)
            {
                IEnumerable<CheckBox> checkBoxes = panel6.Controls.OfType<CheckBox>();
                foreach (CheckBox cb in checkBoxes)
                {
                    cb.Checked = false;
                }
            }
        }

        private void checkBox_Normal_flora_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Normal_flora_1.Checked)
            {
                checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1.Checked = false;
                checkBox_Herpes_simplex_virus_1.Checked = false;
                checkBox_Candida_Monilia_1.Checked = false;
                checkBox_Trichomonas_vaginalis_1.Checked = false;
                checkBox_Actinomyces_1.Checked = false;
            }
        }

        private void checkBox_Normal_flora_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Normal_flora_2.Checked)
            {
                checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2.Checked = false;
                checkBox_Herpes_simplex_virus_2.Checked = false;
                checkBox_Candida_Monilia_2.Checked = false;
                checkBox_Trichomonas_vaginalis_2.Checked = false;
                checkBox_Actinomyces_2.Checked = false;
            }
        }

        private void checkBox_Normal_flora_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Normal_flora_3.Checked)
            {
                checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.Checked = false;
                checkBox_Herpes_simplex_virus_3.Checked = false;
                checkBox_Candida_Monilia_3.Checked = false;
                checkBox_Trichomonas_vaginalis_3.Checked = false;
                checkBox_Actinomyces_3.Checked = false;
            }
        }

        private void checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1.Checked)
            {
                checkBox_Normal_flora_1.Checked = false;
            }
        }

        private void checkBox_Herpes_simplex_virus_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Herpes_simplex_virus_1.Checked)
            {
                checkBox_Normal_flora_1.Checked = false;
            }
        }

        private void checkBox_Candida_Monilia_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Candida_Monilia_1.Checked)
            {
                checkBox_Normal_flora_1.Checked = false;
            }
        }

        private void checkBox_Trichomonas_vaginalis_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Trichomonas_vaginalis_1.Checked)
            {
                checkBox_Normal_flora_1.Checked = false;
            }
        }

        private void checkBox_Actinomyces_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Actinomyces_1.Checked)
            {
                checkBox_Normal_flora_1.Checked = false;
            }
        }

        private void checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2.Checked)
            {
                checkBox_Normal_flora_2.Checked = false;
            }
        }

        private void checkBox_Herpes_simplex_virus_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Herpes_simplex_virus_2.Checked)
            {
                checkBox_Normal_flora_2.Checked = false;
            }
        }

        private void checkBox_Candida_Monilia_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Candida_Monilia_2.Checked)
            {
                checkBox_Normal_flora_2.Checked = false;
            }
        }

        private void checkBox_Trichomonas_vaginalis_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Trichomonas_vaginalis_2.Checked)
            {
                checkBox_Normal_flora_2.Checked = false;

            }
        }

        private void checkBox_Actinomyces_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Actinomyces_2.Checked)
            {
                checkBox_Normal_flora_2.Checked = false;
            }
        }

        private void checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.Checked)
            {
                checkBox_Normal_flora_3.Checked = false;
            }
        }

        private void checkBox_Herpes_simplex_virus_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Herpes_simplex_virus_3.Checked)
            {
                checkBox_Normal_flora_3.Checked = false;
            }
        }

        private void checkBox_Candida_Monilia_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Candida_Monilia_3.Checked)
            {
                checkBox_Normal_flora_3.Checked = false;
            }
        }

        private void checkBox_Trichomonas_vaginalis_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Trichomonas_vaginalis_3.Checked)
            {
                checkBox_Normal_flora_3.Checked = false;
            }
        }

        private void checkBox_Actinomyces_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Actinomyces_3.Checked)
            {
                checkBox_Normal_flora_3.Checked = false;
            }
        }

        private void checkBox_ASC_US_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ASC_US_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Atypical_squamous_cells_1.Checked = true;

                checkBox_ASC_H_1.Checked = false;
                checkBox_Low_grade_SIL_1.Checked = false;
                checkBox_High_grade_SIL_1.Checked = false;
                checkBox_HSIL_1.Checked = false;
                checkBox_Squamous_cell_carcinoma_1.Checked = false;
            }

            //update_checkBox_Atypical_squamous_cells_1();
            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();


        }

        private void checkBox_ASC_H_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ASC_H_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Atypical_squamous_cells_1.Checked = true;

                checkBox_ASC_US_1.Checked = false;
                checkBox_Low_grade_SIL_1.Checked = false;
                checkBox_High_grade_SIL_1.Checked = false;
                checkBox_HSIL_1.Checked = false;
                checkBox_Squamous_cell_carcinoma_1.Checked = false;
            }

            //update_checkBox_Atypical_squamous_cells_1();
            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Low_grade_SIL_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Low_grade_SIL_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_1.Checked = true;

                checkBox_ASC_US_1.Checked = false;
                checkBox_ASC_H_1.Checked = false;
                checkBox_High_grade_SIL_1.Checked = false;
                checkBox_HSIL_1.Checked = false;
                checkBox_Squamous_cell_carcinoma_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_High_grade_SIL_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_High_grade_SIL_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_1.Checked = true;

                checkBox_ASC_US_1.Checked = false;
                checkBox_ASC_H_1.Checked = false;
                checkBox_Low_grade_SIL_1.Checked = false;
                checkBox_HSIL_1.Checked = false;
                checkBox_Squamous_cell_carcinoma_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_HSIL_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HSIL_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_1.Checked = true;

                checkBox_ASC_US_1.Checked = false;
                checkBox_ASC_H_1.Checked = false;
                checkBox_Low_grade_SIL_1.Checked = false;
                checkBox_High_grade_SIL_1.Checked = false;
                checkBox_Squamous_cell_carcinoma_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Squamous_cell_carcinoma_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Squamous_cell_carcinoma_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;

                checkBox_ASC_US_1.Checked = false;
                checkBox_ASC_H_1.Checked = false;
                checkBox_Low_grade_SIL_1.Checked = false;
                checkBox_High_grade_SIL_1.Checked = false;
                checkBox_HSIL_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Atypical_glandular_cells_NOS_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_glandular_cells_NOS_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Atypical_glandular_cells_1.Checked = true;

                checkBox_Atypical_endocervical_cells_NOS_1.Checked = false;
                checkBox_Atypical_endometrial_cells_NOS_1.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_1.Checked = false;
                checkBox_Endocervial_adenocarcinoma_1.Checked = false;
                checkBox_Endometrial_adenocarcinoma_1.Checked = false;
                checkBox_Adenocarcinoma_NOS_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Atypical_endocervical_cells_NOS_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_endocervical_cells_NOS_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Atypical_glandular_cells_1.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_1.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_1.Checked = false;
                checkBox_Endocervial_adenocarcinoma_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Endocervial_adenocarcinoma_in_situ_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endocervial_adenocarcinoma_in_situ_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Adenocarcinoma_1.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_1.Checked = false;
                checkBox_Atypical_endocervical_cells_NOS_1.Checked = false;
                checkBox_Endocervial_adenocarcinoma_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Endocervial_adenocarcinoma_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endocervial_adenocarcinoma_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Adenocarcinoma_1.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_1.Checked = false;
                checkBox_Atypical_endocervical_cells_NOS_1.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Atypical_endometrial_cells_NOS_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_endometrial_cells_NOS_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Atypical_glandular_cells_1.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_1.Checked = false;
                checkBox_Endometrial_adenocarcinoma_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Endometrial_adenocarcinoma_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endometrial_adenocarcinoma_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
                checkBox_Adenocarcinoma_1.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_1.Checked = false;
                checkBox_Atypical_endometrial_cells_NOS_1.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void checkBox_Atypical_glandular_cells_1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_Adenocarcinoma_NOS_1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = true;
            checkBox_Adenocarcinoma_1.Checked = true;

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1();
        }

        private void update_checkBox_Atypical_squamous_cells_1()
        {
            checkBox_Atypical_squamous_cells_1.Checked = checkBox_ASC_US_1.Checked || checkBox_ASC_H_1.Checked;
        }

        private void update_checkBox_Squamous_intraepithelial_lesion_SIL_1()
        {
            checkBox_Squamous_intraepithelial_lesion_SIL_1.Checked = checkBox_Low_grade_SIL_1.Checked ||
                checkBox_High_grade_SIL_1.Checked ||
                checkBox_HSIL_1.Checked
                ;
        }

        private void update_checkBox_Atypical_glandular_cells_1()
        {
            checkBox_Atypical_glandular_cells_1.Checked = checkBox_Atypical_glandular_cells_NOS_1.Checked ||
                checkBox_Atypical_endocervical_cells_NOS_1.Checked ||
                checkBox_Atypical_endometrial_cells_NOS_1.Checked
                ;
        }

        private void update_checkBox_Adenocarcinoma_1()
        {
            checkBox_Adenocarcinoma_1.Checked = checkBox_Endocervial_adenocarcinoma_in_situ_1.Checked ||
                checkBox_Endocervial_adenocarcinoma_1.Checked ||
                checkBox_Endometrial_adenocarcinoma_1.Checked ||
                checkBox_Adenocarcinoma_NOS_1.Checked
                ;
        }

        private void update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_1()
        {
            update_checkBox_Atypical_squamous_cells_1();
            update_checkBox_Squamous_intraepithelial_lesion_SIL_1();
            update_checkBox_Atypical_glandular_cells_1();
            update_checkBox_Adenocarcinoma_1();

            checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked = checkBox_Atypical_squamous_cells_1.Checked ||
                checkBox_Squamous_intraepithelial_lesion_SIL_1.Checked ||
                checkBox_Squamous_cell_carcinoma_1.Checked ||
                checkBox_Atypical_glandular_cells_1.Checked ||
                checkBox_Adenocarcinoma_1.Checked
                ;

            if (checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = false;
            }
            else
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = true;
            }
        }

        private void update_checkBox_Atypical_squamous_cells_2()
        {
            checkBox_Atypical_squamous_cells_2.Checked = checkBox_ASC_US_2.Checked || checkBox_ASC_H_2.Checked;
        }

        private void update_checkBox_Squamous_intraepithelial_lesion_SIL_2()
        {
            checkBox_Squamous_intraepithelial_lesion_SIL_2.Checked = checkBox_Low_grade_SIL_2.Checked ||
                checkBox_High_grade_SIL_2.Checked ||
                checkBox_HSIL_2.Checked
                ;
        }

        private void update_checkBox_Atypical_glandular_cells_2()
        {
            checkBox_Atypical_glandular_cells_2.Checked = checkBox_Atypical_glandular_cells_NOS_2.Checked ||
                checkBox_Atypical_endocervical_cells_NOS_2.Checked ||
                checkBox_Atypical_endometrial_cells_NOS_2.Checked
                ;
        }

        private void update_checkBox_Adenocarcinoma_2()
        {
            checkBox_Adenocarcinoma_2.Checked = checkBox_Endocervial_adenocarcinoma_in_situ_2.Checked ||
                checkBox_Endocervial_adenocarcinoma_2.Checked ||
                checkBox_Endometrial_adenocarcinoma_2.Checked ||
                checkBox_Adenocarcinoma_NOS_2.Checked
                ;
        }

        private void update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2()
        {
            update_checkBox_Atypical_squamous_cells_2();
            update_checkBox_Squamous_intraepithelial_lesion_SIL_2();
            update_checkBox_Atypical_glandular_cells_2();
            update_checkBox_Adenocarcinoma_2();

            checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = checkBox_Atypical_squamous_cells_2.Checked ||
                checkBox_Squamous_intraepithelial_lesion_SIL_2.Checked ||
                checkBox_Squamous_cell_carcinoma_2.Checked ||
                checkBox_Atypical_glandular_cells_2.Checked ||
                checkBox_Adenocarcinoma_2.Checked
                ;

            if (checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;
            }
            else
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = true;
            }
        }

        private void checkBox_ASC_US_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ASC_US_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Atypical_squamous_cells_2.Checked = true;

                checkBox_ASC_H_2.Checked = false;
                checkBox_Low_grade_SIL_2.Checked = false;
                checkBox_High_grade_SIL_2.Checked = false;
                checkBox_HSIL_2.Checked = false;
                checkBox_Squamous_cell_carcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_ASC_H_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ASC_H_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Atypical_squamous_cells_2.Checked = true;

                checkBox_ASC_US_2.Checked = false;
                checkBox_Low_grade_SIL_2.Checked = false;
                checkBox_High_grade_SIL_2.Checked = false;
                checkBox_HSIL_2.Checked = false;
                checkBox_Squamous_cell_carcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Low_grade_SIL_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Low_grade_SIL_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_2.Checked = true;

                checkBox_ASC_US_2.Checked = false;
                checkBox_ASC_H_2.Checked = false;
                checkBox_High_grade_SIL_2.Checked = false;
                checkBox_HSIL_2.Checked = false;
                checkBox_Squamous_cell_carcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_High_grade_SIL_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_High_grade_SIL_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_2.Checked = true;

                checkBox_ASC_US_2.Checked = false;
                checkBox_ASC_H_2.Checked = false;
                checkBox_Low_grade_SIL_2.Checked = false;
                checkBox_HSIL_2.Checked = false;
                checkBox_Squamous_cell_carcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_HSIL_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HSIL_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_2.Checked = true;

                checkBox_ASC_US_2.Checked = false;
                checkBox_ASC_H_2.Checked = false;
                checkBox_Low_grade_SIL_2.Checked = false;
                checkBox_High_grade_SIL_2.Checked = false;
                checkBox_Squamous_cell_carcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Squamous_cell_carcinoma_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Squamous_cell_carcinoma_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;

                checkBox_ASC_US_2.Checked = false;
                checkBox_ASC_H_2.Checked = false;
                checkBox_Low_grade_SIL_2.Checked = false;
                checkBox_High_grade_SIL_2.Checked = false;
                checkBox_HSIL_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Atypical_glandular_cells_NOS_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_glandular_cells_NOS_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Atypical_glandular_cells_2.Checked = true;

                checkBox_Atypical_endocervical_cells_NOS_2.Checked = false;
                checkBox_Atypical_endometrial_cells_NOS_2.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_2.Checked = false;
                checkBox_Endocervial_adenocarcinoma_2.Checked = false;
                checkBox_Endometrial_adenocarcinoma_2.Checked = false;
                checkBox_Adenocarcinoma_NOS_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Atypical_endocervical_cells_NOS_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_endocervical_cells_NOS_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Atypical_glandular_cells_2.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_2.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_2.Checked = false;
                checkBox_Endocervial_adenocarcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Atypical_endometrial_cells_NOS_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_endometrial_cells_NOS_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Atypical_glandular_cells_2.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_2.Checked = false;
                checkBox_Endometrial_adenocarcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Endocervial_adenocarcinoma_in_situ_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endocervial_adenocarcinoma_in_situ_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Adenocarcinoma_2.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_2.Checked = false;
                checkBox_Atypical_endocervical_cells_NOS_2.Checked = false;
                checkBox_Endocervial_adenocarcinoma_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Endocervial_adenocarcinoma_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endocervial_adenocarcinoma_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Adenocarcinoma_2.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_2.Checked = false;
                checkBox_Atypical_endocervical_cells_NOS_2.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Endometrial_adenocarcinoma_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endometrial_adenocarcinoma_2.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
                checkBox_Adenocarcinoma_2.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_2.Checked = false;
                checkBox_Atypical_endometrial_cells_NOS_2.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        private void checkBox_Adenocarcinoma_NOS_2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Checked = true;
            checkBox_Adenocarcinoma_2.Checked = true;

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_2();
        }

        //--------------

        private void update_checkBox_Atypical_squamous_cells_3()
        {
            checkBox_Atypical_squamous_cells_3.Checked = checkBox_ASC_US_3.Checked || checkBox_ASC_H_3.Checked;
        }

        private void update_checkBox_Squamous_intraepithelial_lesion_SIL_3()
        {
            checkBox_Squamous_intraepithelial_lesion_SIL_3.Checked = checkBox_Low_grade_SIL_3.Checked ||
                checkBox_High_grade_SIL_3.Checked ||
                checkBox_HSIL_3.Checked
                ;
        }

        private void update_checkBox_Atypical_glandular_cells_3()
        {
            checkBox_Atypical_glandular_cells_3.Checked = checkBox_Atypical_glandular_cells_NOS_3.Checked ||
                checkBox_Atypical_endocervical_cells_NOS_3.Checked ||
                checkBox_Atypical_endometrial_cells_NOS_3.Checked
                ;
        }

        private void update_checkBox_Adenocarcinoma_3()
        {
            checkBox_Adenocarcinoma_3.Checked = checkBox_Endocervial_adenocarcinoma_in_situ_3.Checked ||
                checkBox_Endocervial_adenocarcinoma_3.Checked ||
                checkBox_Endometrial_adenocarcinoma_3.Checked ||
                checkBox_Adenocarcinoma_NOS_3.Checked
                ;
        }

        private void update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3()
        {
            update_checkBox_Atypical_squamous_cells_3();
            update_checkBox_Squamous_intraepithelial_lesion_SIL_3();
            update_checkBox_Atypical_glandular_cells_3();
            update_checkBox_Adenocarcinoma_3();

            checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = checkBox_Atypical_squamous_cells_3.Checked ||
                checkBox_Squamous_intraepithelial_lesion_SIL_3.Checked ||
                checkBox_Squamous_cell_carcinoma_3.Checked ||
                checkBox_Atypical_glandular_cells_3.Checked ||
                checkBox_Adenocarcinoma_3.Checked
                ;

            if (checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;
            }
            else
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = true;
            }
        }

        private void checkBox_ASC_US_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ASC_US_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Atypical_squamous_cells_3.Checked = true;

                checkBox_ASC_H_3.Checked = false;
                checkBox_Low_grade_SIL_3.Checked = false;
                checkBox_High_grade_SIL_3.Checked = false;
                checkBox_HSIL_3.Checked = false;
                checkBox_Squamous_cell_carcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_ASC_H_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ASC_H_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Atypical_squamous_cells_3.Checked = true;

                checkBox_ASC_US_3.Checked = false;
                checkBox_Low_grade_SIL_3.Checked = false;
                checkBox_High_grade_SIL_3.Checked = false;
                checkBox_HSIL_3.Checked = false;
                checkBox_Squamous_cell_carcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Low_grade_SIL_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Low_grade_SIL_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_3.Checked = true;

                checkBox_ASC_US_3.Checked = false;
                checkBox_ASC_H_3.Checked = false;
                checkBox_High_grade_SIL_3.Checked = false;
                checkBox_HSIL_3.Checked = false;
                checkBox_Squamous_cell_carcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_High_grade_SIL_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_High_grade_SIL_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_3.Checked = true;

                checkBox_ASC_US_3.Checked = false;
                checkBox_ASC_H_3.Checked = false;
                checkBox_Low_grade_SIL_3.Checked = false;
                checkBox_HSIL_3.Checked = false;
                checkBox_Squamous_cell_carcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_HSIL_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HSIL_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Squamous_intraepithelial_lesion_SIL_3.Checked = true;

                checkBox_ASC_US_3.Checked = false;
                checkBox_ASC_H_3.Checked = false;
                checkBox_Low_grade_SIL_3.Checked = false;
                checkBox_High_grade_SIL_3.Checked = false;
                checkBox_Squamous_cell_carcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Squamous_cell_carcinoma_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Squamous_cell_carcinoma_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;

                checkBox_ASC_US_3.Checked = false;
                checkBox_ASC_H_3.Checked = false;
                checkBox_Low_grade_SIL_3.Checked = false;
                checkBox_High_grade_SIL_3.Checked = false;
                checkBox_HSIL_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Atypical_glandular_cells_NOS_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_glandular_cells_NOS_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Atypical_glandular_cells_3.Checked = true;

                checkBox_Atypical_endocervical_cells_NOS_3.Checked = false;
                checkBox_Atypical_endometrial_cells_NOS_3.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_3.Checked = false;
                checkBox_Endocervial_adenocarcinoma_3.Checked = false;
                checkBox_Endometrial_adenocarcinoma_3.Checked = false;
                checkBox_Adenocarcinoma_NOS_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Atypical_endocervical_cells_NOS_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_endocervical_cells_NOS_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Atypical_glandular_cells_3.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_3.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_3.Checked = false;
                checkBox_Endocervial_adenocarcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Atypical_endometrial_cells_NOS_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Atypical_endometrial_cells_NOS_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Atypical_glandular_cells_3.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_3.Checked = false;
                checkBox_Endometrial_adenocarcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Endocervial_adenocarcinoma_in_situ_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endocervial_adenocarcinoma_in_situ_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Adenocarcinoma_3.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_3.Checked = false;
                checkBox_Atypical_endocervical_cells_NOS_3.Checked = false;
                checkBox_Endocervial_adenocarcinoma_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Endocervial_adenocarcinoma_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endocervial_adenocarcinoma_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Adenocarcinoma_3.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_3.Checked = false;
                checkBox_Atypical_endocervical_cells_NOS_3.Checked = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Endometrial_adenocarcinoma_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Endometrial_adenocarcinoma_3.Checked)
            {
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = false;

                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
                checkBox_Adenocarcinoma_3.Checked = true;

                checkBox_Atypical_glandular_cells_NOS_3.Checked = false;
                checkBox_Atypical_endometrial_cells_NOS_3.Checked = false;
            }

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        private void checkBox_Adenocarcinoma_NOS_3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Checked = true;
            checkBox_Adenocarcinoma_3.Checked = true;

            update_checkBox_EPITHELIAL_CELL_ABNORMALITIES_3();
        }

        public void setDefaultValue()
        {
            checkBox_Cervix_1.Checked = true;
            checkBox_Cervix_2.Checked = true;
            checkBox_Cervix_3.Checked = true;

            checkBox_Satisfactory_for_evaluation_1.Checked = true;
            checkBox_Satisfactory_for_evaluation_2.Checked = true;
            checkBox_Satisfactory_for_evaluation_3.Checked = true;

            checkBox_Transformation_zone_1.Checked = true;
            checkBox_Transformation_zone_2.Checked = true;
            checkBox_Transformation_zone_3.Checked = true;

            checkBox_Mainly_superficial_and_intermediate_cells_1.Checked = true;
            checkBox_Mainly_superficial_and_intermediate_cells_2.Checked = true;
            checkBox_Mainly_superficial_and_intermediate_cells_3.Checked = true;

            checkBox_Liquid_based_preparation_1.Checked = true;
            checkBox_Liquid_based_preparation_2.Checked = true;
            checkBox_Liquid_based_preparation_3.Checked = true;

            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Checked = true;
            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Checked = true;
            checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked = true;

            checkBox_Normal_flora_1.Checked = true;
            checkBox_Normal_flora_2.Checked = true;
            checkBox_Normal_flora_3.Checked = true;

            comboBox_SITE_TYPE_1.Text = "Cervical liquid-based preparation (ThinPrep)";
            comboBox_SITE_TYPE_2.Text = "Cervical liquid-based preparation (ThinPrep)";
            comboBox_SITE_TYPE_3.Text = "Cervical liquid-based preparation (ThinPrep)";

            textBox_SITE_TYPE_1.Text = "宮頸(ThinPrep)液基簿片技術";
            textBox_SITE_TYPE_2.Text = "宮頸(ThinPrep)液基簿片技術";
            textBox_SITE_TYPE_3.Text = "宮頸(ThinPrep)液基簿片技術";

            comboBox_DIAGNOSIS_1_1.Text = "Negative for intraepithelial lesion or malignancy";
            comboBox_DIAGNOSIS_1_2.Text = "Negative for intraepithelial lesion or malignancy";
            comboBox_DIAGNOSIS_1_3.Text = "Negative for intraepithelial lesion or malignancy";

            comboBox_DIAGNOSIS_2_1.Text = "";
            comboBox_DIAGNOSIS_3_1.Text = "";
            comboBox_DIAGNOSIS_2_2.Text = "";
            comboBox_DIAGNOSIS_3_2.Text = "";
            comboBox_DIAGNOSIS_2_3.Text = "";
            comboBox_DIAGNOSIS_3_3.Text = "";

            textBox_DIAGNOSIS_1_1.Text = "無癌或癌前期病變";
            textBox_DIAGNOSIS_1_2.Text = "無癌或癌前期病變";
            textBox_DIAGNOSIS_1_3.Text = "無癌或癌前期病變";
        }

        private void generateReportWording()
        {
            if (checkBox_Cervix_3.Checked)
            {
                addReportWording("The cervical");
            }
            if (checkBox_Vagina_Vault_3.Checked)
            {
                addReportWording("The vaginal/vault");
            }


            if (checkBox_Liquid_based_preparation_3.Checked)
            {
                addReportWording("liquid-based preparation is");
            }
            if (checkBox_Liquid_based_preparations_3.Checked)
            {
                addReportWording("liquid-based preparations are");
            }
            if (checkBox_Conventional_Pap_smear_3.Checked)
            {
                addReportWording("conventional Pap smear is");
            }
            if (checkBox_Conventional_Pap_smears_3.Checked)
            {
                addReportWording("conventional Pap smears are");
            }


            if (checkBox_Satisfactory_for_evaluation_3.Checked)
            {
                addReportWording("satisfactory for evaluation.");
            }
            if (checkBox_Satisfactory_for_evaluation_but_3.Checked)
            {
                addReportWording("satisfactory for evaluation but limited by");
            }
            if (checkBox_Unsatisfactory_for_evaluation_3.Checked)
            {
                addReportWording("unsatisfactory for evaluation due to");
            }


            if (checkBox_Low_squamous_cellularity_3.Checked)
            {
                addReportWording("low squamous cellularity.");
            }
            if (checkBox_Air_drying_artifacts_3.Checked)
            {
                addReportWording("air-drying artefacts.");
            }
            if (checkBox_Obscured_by_inflammatory_exudates_3.Checked)
            {
                addReportWording("obscuring inflammatory exudates.");
            }
            if (checkBox_Obscured_by_blood_3.Checked)
            {
                addReportWording("obscuring blood.");
            }
            if (checkBox_Thick_smear_3.Checked)
            {
                addReportWording("thick smear.");
            }


            if (checkBox_Transformation_zone_3.Checked)
            {
                addReportWording("Both ectocervical and transformation zone components are present.");
            }
            if (checkBox_Mainly_superficial_and_intermediate_cells_3.Checked)
            {
                addReportWording("The squamous cell population consists mainly of superficial and intermediate cells.");
            }
            if (checkBox_Mainly_intermediate_and_parabasal_cells_3.Checked)
            {
                addReportWording("The squamous cell population consists mainly of intermediate and parabasal cells.");
            }
            if (checkBox_trophic_pattern_in_menopause_3.Checked)
            {
                addReportWording("The squamous cell population shows a predominance of parabasal cells, consistent with atrophic pattern related to menopausal changes.");
            }
            if (checkBox_Post_partum_changes_3.Checked)
            {
                addReportWording("The squamous cell population shows a predominance of parabasal cells, consistent with post-partum status.");
            }


            if (checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Checked)
            {
                addReportWording("There is no cytological evidence of koilocytosis, significant nuclear atypia or malignancy.");
            }
            if (checkBox_Reactive_cellular_changes_associated_3.Checked)
            {
                addReportWording("Some of the squamous and metaplastic cells show reactive cellular changes secondary to inflammation.");
            }
            if (checkBox_Normal_flora_3.Checked)
            {
                addReportWording("The microbiological flora is within normal limits, with no Trichomonas, Herpes simplex virus, Candida or Actinomyces identified.");
            }
            if (checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.Checked)
            {
                addReportWording("\"Clue\" cells are present, consistent with a shift in flora to coccobacilli. The possibility of bacterial vaginosis needs to be excluded.");
            }
            if (checkBox_Herpes_simplex_virus_3.Checked)
            {
                addReportWording("Some of the squamous cells show cellular changes including ground-glass nuclei, nuclear molding and sometimes multinucleation. These findings are consistent with Herpes simplex virus infection.");
            }
            if (checkBox_Candida_Monilia_3.Checked)
            {
                addReportWording("Fungal organisms morphologically consistent with Candida species are identified.");
            }
            if (checkBox_Trichomonas_vaginalis_3.Checked)
            {
                addReportWording(" Trichomonas vaginalis are identified in the background.");
            }
            if (checkBox_Actinomyces_3.Checked)
            {
                addReportWording("Clumps of bacteria morphologically consistent with Actinomyces species are identified.");
            }
            if (checkBox_Endometrial_cells_3.Checked)
            {
                addReportWording("Small clumps of exfoliated bland-looking endometrial cells are present.");
            }


            if (checkBox_ASC_US_3.Checked)
            {
                addReportWording("Some squamous cells show mild nuclear atypia including nuclear enlargement. The significance is undetermined. Advise repeat gynaecological cytology at 4- to 6-month intervals and consider further diagnostic follow-up procedures (e.g. colposcopy) if the abnormality persists. Triage with HPV DNA testing may also be useful.");
            }
            if (checkBox_ASC_H_3.Checked)
            {
                addReportWording("Some squamous cells show nuclear atypia with enlarged hyperchromatic nuclei and increased nuclear-to-cytoplasmic ratio. The possibility of an underlying high-grade squamous intraepithelial lesion cannot be excluded. Advise colposcopy and biopsy as clinically indicated.");
            }
            if (checkBox_Low_grade_SIL_3.Checked)
            {
                addReportWording("Some abnormal squamous cells with koilocytosis and focal mild dyskaryosis are seen, consistent with low-grade squamous intraepithelial lesion. Advise further investigations (e.g. colposcopy and biopsy) as clinically indicated.");
            }
            if (checkBox_High_grade_SIL_3.Checked)
            {
                addReportWording("Some abnormal squamous cells with enlarged hyperchromatic nuclei, increased nuclear-to-cytoplasmic ratio, coarse chromatin and irregular nuclear outlines are seen, consistent with high-grade squamous intraepithelial lesion. Advise colposcopy as clinically indicated.");
            }
            if (checkBox_HSIL_3.Checked)
            {
                addReportWording("Some abnormal squamous cells with enlarged hyperchromatic nuclei, increased nuclear-to-cytoplasmic ratio, coarse chromatin and irregular nuclear outlines are seen, consistent with high-grade squamous intraepithelial lesion. Some of these cells also show suspicious cytological features, including dyskeratosis and focal presence of distinct nucleoli. The possibility of underlying stromal invasion cannot be excluded. Advise colposcopy as clinically indicated.");
            }
            if (checkBox_Squamous_cell_carcinoma_3.Checked)
            {
                addReportWording("Some abnormal squamous cells with enlarged hyperchromatic nuclei, increased nuclear-to-cytoplasmic ratio, coarse chromatin and irregular nuclear outlines are seen. In addition, some of these cells also contain distinct nucleoli and syncytial cytoplasm, associated with tumour diathesis. The overall features are compatible with squamous cell carcinoma. Advise biopsy if gross tumour is seen or refer for colposcopy if no gross abnormality is detected.");
            }
            if (checkBox_Atypical_glandular_cells_NOS_3.Checked)
            {
                addReportWording("Some clusters of atypical glandular cells with enlarged hyperchromatic nuclei, increased nuclear-to-cytoplasmic ratio, distinct nucleoli and focal nuclear overlapping are seen. As a significant percentage of patients with this interpretation have underlying high-grade squamous intraepithelial lesion or glandular abnormalities, further diagnostic follow-up procedures (e.g. colposcopy, endometrial sampling) are suggested as clinically indicated.");
            }
            if (checkBox_Atypical_endocervical_cells_NOS_3.Checked)
            {
                addReportWording("Some sheets of atypical glandular cells, likely of endocervical origin, with enlarged nuclei, increased nuclear-to-cytoplasmic ratio, distinct nucleoli and focal nuclear overlapping are seen. As a significant percentage of patients with this interpretation have underlying high-grade squamous intraepithelial lesion or glandular abnormalities, further diagnostic follow-up procedures (e.g. colposcopy) are suggested as clinically indicated.");
            }
            if (checkBox_Atypical_endometrial_cells_NOS_3.Checked)
            {
                addReportWording("Some clusters of atypical endometrial cells with slightly enlarged nuclei, distinct nucleoli and cytoplasmic vacuoles are seen. Advise endometrial sampling in order to rule out possible underlying endometrial pathology.");
            }
            if (checkBox_Endocervial_adenocarcinoma_in_situ_3.Checked)
            {
                addReportWording("Sheets of abnormal endocervical cells with enlarged nuclei, increased nuclear-to-cytoplasmic ratio, thickened nuclear outlines, distinct nucleoli, focal nuclear overlapping and sometimes feathery changes are seen. The overall features are highly suggestive of endocervical adenocarcinoma-in-situ. Advise colposcopy (with endocervical assessment) as clinically indicated.");
            }
            if (checkBox_Endocervial_adenocarcinoma_3.Checked)
            {
                addReportWording("Sheets of abnormal endocervical cells with enlarged nuclei, increased nuclear-to-cytoplasmic ratio, thickened nuclear outlines, distinct nucleoli, focal nuclear overlapping and sometimes feathery changes are seen. In addition, some of these cells are arranged in three-dimensional clusters, with increased nuclear pleomorphism and associated tumour diathesis. The overall features are highly suggestive of endocervical adenocarcinoma. Advise biopsy if gross tumour is seen or refer for colposcopy if no gross abnormality is detected.");
            }
            if (checkBox_Endometrial_adenocarcinoma_3.Checked)
            {
                addReportWording("Some clusters of atypical to suspicious endometrial cells with enlarged nuclei, distinct nucleoli, cytoplasmic vacuoles and engulfed polymorphs are seen. The overall features are highly suggestive of endometrial adenocarcinoma. Advise endometrial sampling.");
            }
            if (checkBox_Adenocarcinoma_NOS_3.Checked)
            {
                addReportWording("Some three-dimensional clusters of suspicious glandular cells with enlarged pleomorphic nuclei, increased nuclear-to-cytoplasmic ratio, prominent nucleoli and focal nuclear palisading are seen. The overall features are compatible with adenocarcinoma. The primary origin (endocervical versus endometrial) however cannot be ascertained here. Advise further investigation for histological assessment.");
            }
            if (checkBox_HPV_DNA_TESTING_3.Checked)
            {
                addReportWording("A further report on HPV DNA testing result will follow.");
            }
        }

        private void addReportWording(String i)
        {
            if (reportWording == "")
            {
                reportWording = i.Trim();
            }
            else
            {
                reportWording = reportWording + " " + i.Trim();
            }
        }

        private void Form_CytologicalDiagnosis_Load(object sender, EventArgs e)
        {
            //setButtonStatus(currentStatus);
        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;
            if (status == PageStatus.STATUS_VIEW)
            {
                checkBox_Cervix_1.Enabled = false;
                checkBox_Vagina_Vault_1.Enabled = false;
                checkBox_Satisfactory_for_evaluation_1.Enabled = false;
                checkBox_Satisfactory_for_evaluation_but_1.Enabled = false;
                checkBox_Unsatisfactory_for_evaluation_1.Enabled = false;
                checkBox_Transformation_zone_1.Enabled = false;
                checkBox_Mainly_superficial_and_intermediate_cells_1.Enabled = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_1.Enabled = false;
                checkBox_trophic_pattern_in_menopause_1.Enabled = false;
                checkBox_Post_partum_changes_1.Enabled = false;
                comboBox_SITE_TYPE_1.Enabled = false;
                textBox_SITE_TYPE_1.Enabled = false;
                checkBox_Liquid_based_preparation_1.Enabled = false;
                checkBox_Liquid_based_preparations_1.Enabled = false;
                checkBox_Conventional_Pap_smear_1.Enabled = false;
                checkBox_Conventional_Pap_smears_1.Enabled = false;
                checkBox_Low_squamous_cellularity_1.Enabled = false;
                checkBox_Air_drying_artifacts_1.Enabled = false;
                checkBox_Obscured_by_inflammatory_exudates_1.Enabled = false;
                checkBox_Obscured_by_blood_1.Enabled = false;
                checkBox_Thick_smear_1.Enabled = false;
                comboBox_DIAGNOSIS_1_1.Enabled = false;
                textBox_DIAGNOSIS_1_1.Enabled = false;
                comboBox_DIAGNOSIS_2_1.Enabled = false;
                textBox_DIAGNOSIS_2_1.Enabled = false;
                comboBox_DIAGNOSIS_3_1.Enabled = false;
                textBox_DIAGNOSIS_3_1.Enabled = false;
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Enabled = false;
                checkBox_Reactive_cellular_changes_associated_1.Enabled = false;
                checkBox_Normal_flora_1.Enabled = false;
                checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1.Enabled = false;
                checkBox_Herpes_simplex_virus_1.Enabled = false;
                checkBox_Candida_Monilia_1.Enabled = false;
                checkBox_Trichomonas_vaginalis_1.Enabled = false;
                checkBox_Actinomyces_1.Enabled = false;
                checkBox_Endometrial_cells_1.Enabled = false;
                checkBox_Others_eg_follicular_cervicitis_RT_effect_1.Enabled = false;
                checkBox_HPV_DNA_TESTING_1.Enabled = false;
                checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Enabled = false;
                checkBox_Atypical_squamous_cells_1.Enabled = false;
                checkBox_ASC_US_1.Enabled = false;
                checkBox_ASC_H_1.Enabled = false;
                checkBox_Squamous_intraepithelial_lesion_SIL_1.Enabled = false;
                checkBox_Low_grade_SIL_1.Enabled = false;
                checkBox_High_grade_SIL_1.Enabled = false;
                checkBox_HSIL_1.Enabled = false;
                checkBox_Squamous_cell_carcinoma_1.Enabled = false;
                checkBox_Atypical_glandular_cells_1.Enabled = false;
                checkBox_Atypical_glandular_cells_NOS_1.Enabled = false;
                checkBox_Atypical_endocervical_cells_NOS_1.Enabled = false;
                checkBox_Atypical_endometrial_cells_NOS_1.Enabled = false;
                checkBox_Adenocarcinoma_1.Enabled = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_1.Enabled = false;
                checkBox_Endocervial_adenocarcinoma_1.Enabled = false;
                checkBox_Endometrial_adenocarcinoma_1.Enabled = false;
                checkBox_Adenocarcinoma_NOS_1.Enabled = false;
                checkBox_Other_malignant_neoplasm_1.Enabled = false;

                textBox_Sign_At_2.Enabled = false;
                textBox_Sign_By_2.Enabled = false;
                comboBox_Sign_By_2.Enabled = false;

                checkBox_Cervix_2.Enabled = false;
                checkBox_Vagina_Vault_2.Enabled = false;
                checkBox_Satisfactory_for_evaluation_2.Enabled = false;
                checkBox_Satisfactory_for_evaluation_but_2.Enabled = false;
                checkBox_Unsatisfactory_for_evaluation_2.Enabled = false;
                checkBox_Transformation_zone_2.Enabled = false;
                checkBox_Mainly_superficial_and_intermediate_cells_2.Enabled = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_2.Enabled = false;
                checkBox_trophic_pattern_in_menopause_2.Enabled = false;
                checkBox_Post_partum_changes_2.Enabled = false;
                comboBox_SITE_TYPE_2.Enabled = false;
                textBox_SITE_TYPE_2.Enabled = false;
                checkBox_Liquid_based_preparation_2.Enabled = false;
                checkBox_Liquid_based_preparations_2.Enabled = false;
                checkBox_Conventional_Pap_smear_2.Enabled = false;
                checkBox_Conventional_Pap_smear_2.Enabled = false;
                checkBox_Low_squamous_cellularity_2.Enabled = false;
                checkBox_Air_drying_artifacts_2.Enabled = false;
                checkBox_Obscured_by_inflammatory_exudates_2.Enabled = false;
                checkBox_Obscured_by_blood_2.Enabled = false;
                checkBox_Thick_smear_2.Enabled = false;
                comboBox_DIAGNOSIS_1_2.Enabled = false;
                textBox_DIAGNOSIS_1_2.Enabled = false;
                comboBox_DIAGNOSIS_2_2.Enabled = false;
                textBox_DIAGNOSIS_2_2.Enabled = false;
                comboBox_DIAGNOSIS_3_2.Enabled = false;
                textBox_DIAGNOSIS_3_2.Enabled = false;
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Enabled = false;
                checkBox_Reactive_cellular_changes_associated_2.Enabled = false;
                checkBox_Normal_flora_2.Enabled = false;
                checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2.Enabled = false;
                checkBox_Herpes_simplex_virus_2.Enabled = false;
                checkBox_Candida_Monilia_2.Enabled = false;
                checkBox_Trichomonas_vaginalis_2.Enabled = false;
                checkBox_Actinomyces_2.Enabled = false;
                checkBox_Endometrial_cells_2.Enabled = false;
                checkBox_Others_eg_follicular_cervicitis_RT_effect_2.Enabled = false;
                checkBox_HPV_DNA_TESTING_2.Enabled = false;
                checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Enabled = false;
                checkBox_Atypical_squamous_cells_2.Enabled = false;
                checkBox_ASC_US_2.Enabled = false;
                checkBox_ASC_H_2.Enabled = false;
                checkBox_Squamous_intraepithelial_lesion_SIL_2.Enabled = false;
                checkBox_Low_grade_SIL_2.Enabled = false;
                checkBox_High_grade_SIL_2.Enabled = false;
                checkBox_HSIL_2.Enabled = false;
                checkBox_Squamous_cell_carcinoma_2.Enabled = false;
                checkBox_Atypical_glandular_cells_2.Enabled = false;
                checkBox_Atypical_glandular_cells_NOS_2.Enabled = false;
                checkBox_Atypical_endocervical_cells_NOS_2.Enabled = false;
                checkBox_Atypical_endometrial_cells_NOS_2.Enabled = false;
                checkBox_Adenocarcinoma_2.Enabled = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_2.Enabled = false;
                checkBox_Endocervial_adenocarcinoma_2.Enabled = false;
                checkBox_Endometrial_adenocarcinoma_2.Enabled = false;
                checkBox_Adenocarcinoma_NOS_2.Enabled = false;
                checkBox_Other_malignant_neoplasm_1.Enabled = false;

                textBox_Sign_At_3.Enabled = false;
                textBox_Sign_By_3.Enabled = false;
                comboBox_Sign_By_3.Enabled = false;

                checkBox_Cervix_3.Enabled = false;
                checkBox_Vagina_Vault_3.Enabled = false;
                checkBox_Satisfactory_for_evaluation_3.Enabled = false;
                checkBox_Satisfactory_for_evaluation_but_3.Enabled = false;
                checkBox_Unsatisfactory_for_evaluation_3.Enabled = false;
                checkBox_Transformation_zone_3.Enabled = false;
                checkBox_Mainly_superficial_and_intermediate_cells_3.Enabled = false;
                checkBox_Mainly_intermediate_and_parabasal_cells_3.Enabled = false;
                checkBox_trophic_pattern_in_menopause_3.Enabled = false;
                checkBox_Post_partum_changes_3.Enabled = false;
                comboBox_SITE_TYPE_3.Enabled = false;
                textBox_SITE_TYPE_3.Enabled = false;
                checkBox_Liquid_based_preparation_3.Enabled = false;
                checkBox_Liquid_based_preparations_3.Enabled = false;
                checkBox_Conventional_Pap_smear_3.Enabled = false;
                checkBox_Conventional_Pap_smear_3.Enabled = false;
                checkBox_Low_squamous_cellularity_3.Enabled = false;
                checkBox_Air_drying_artifacts_3.Enabled = false;
                checkBox_Obscured_by_inflammatory_exudates_3.Enabled = false;
                checkBox_Obscured_by_blood_3.Enabled = false;
                checkBox_Thick_smear_3.Enabled = false;
                comboBox_DIAGNOSIS_1_3.Enabled = false;
                textBox_DIAGNOSIS_1_3.Enabled = false;
                comboBox_DIAGNOSIS_2_3.Enabled = false;
                textBox_DIAGNOSIS_2_3.Enabled = false;
                comboBox_DIAGNOSIS_3_3.Enabled = false;
                textBox_DIAGNOSIS_3_3.Enabled = false;
                checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Enabled = false;
                checkBox_Reactive_cellular_changes_associated_3.Enabled = false;
                checkBox_Normal_flora_3.Enabled = false;
                checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.Enabled = false;
                checkBox_Herpes_simplex_virus_3.Enabled = false;
                checkBox_Candida_Monilia_3.Enabled = false;
                checkBox_Trichomonas_vaginalis_3.Enabled = false;
                checkBox_Actinomyces_3.Enabled = false;
                checkBox_Endometrial_cells_3.Enabled = false;
                checkBox_Others_eg_follicular_cervicitis_RT_effect_3.Enabled = false;
                checkBox_HPV_DNA_TESTING_3.Enabled = false;
                checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Enabled = false;
                checkBox_Atypical_squamous_cells_3.Enabled = false;
                checkBox_ASC_US_3.Enabled = false;
                checkBox_ASC_H_3.Enabled = false;
                checkBox_Squamous_intraepithelial_lesion_SIL_3.Enabled = false;
                checkBox_Low_grade_SIL_3.Enabled = false;
                checkBox_High_grade_SIL_3.Enabled = false;
                checkBox_HSIL_3.Enabled = false;
                checkBox_Squamous_cell_carcinoma_3.Enabled = false;
                checkBox_Atypical_glandular_cells_3.Enabled = false;
                checkBox_Atypical_glandular_cells_NOS_3.Enabled = false;
                checkBox_Atypical_endocervical_cells_NOS_3.Enabled = false;
                checkBox_Atypical_endometrial_cells_NOS_3.Enabled = false;
                checkBox_Adenocarcinoma_3.Enabled = false;
                checkBox_Endocervial_adenocarcinoma_in_situ_3.Enabled = false;
                checkBox_Endocervial_adenocarcinoma_3.Enabled = false;
                checkBox_Endometrial_adenocarcinoma_3.Enabled = false;
                checkBox_Adenocarcinoma_NOS_3.Enabled = false;
                checkBox_Other_malignant_neoplasm_3.Enabled = false;

                button_Sign_At_1.Enabled = false;
                button_Sign_At_2.Enabled = false;
                button_Sign_At_3.Enabled = false;
            }
            else
            {
                if (status == PageStatus.STATUS_NEW)
                {
                    checkBox_Cervix_1.Enabled = true;
                    checkBox_Vagina_Vault_1.Enabled = true;
                    checkBox_Satisfactory_for_evaluation_1.Enabled = true;
                    checkBox_Satisfactory_for_evaluation_but_1.Enabled = true;
                    checkBox_Unsatisfactory_for_evaluation_1.Enabled = true;
                    checkBox_Transformation_zone_1.Enabled = true;
                    checkBox_Mainly_superficial_and_intermediate_cells_1.Enabled = true;
                    checkBox_Mainly_intermediate_and_parabasal_cells_1.Enabled = true;
                    checkBox_trophic_pattern_in_menopause_1.Enabled = true;
                    checkBox_Post_partum_changes_1.Enabled = true;
                    comboBox_SITE_TYPE_1.Enabled = true;
                    textBox_SITE_TYPE_1.Enabled = true;
                    checkBox_Liquid_based_preparation_1.Enabled = true;
                    checkBox_Liquid_based_preparations_1.Enabled = true;
                    checkBox_Conventional_Pap_smear_1.Enabled = true;
                    checkBox_Conventional_Pap_smears_1.Enabled = true;
                    checkBox_Low_squamous_cellularity_1.Enabled = true;
                    checkBox_Air_drying_artifacts_1.Enabled = true;
                    checkBox_Obscured_by_inflammatory_exudates_1.Enabled = true;
                    checkBox_Obscured_by_blood_1.Enabled = true;
                    checkBox_Thick_smear_1.Enabled = true;
                    comboBox_DIAGNOSIS_1_1.Enabled = true;
                    textBox_DIAGNOSIS_1_1.Enabled = true;
                    comboBox_DIAGNOSIS_2_1.Enabled = true;
                    textBox_DIAGNOSIS_2_1.Enabled = true;
                    comboBox_DIAGNOSIS_3_1.Enabled = true;
                    textBox_DIAGNOSIS_3_1.Enabled = true;
                    checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Enabled = true;
                    checkBox_Reactive_cellular_changes_associated_1.Enabled = true;
                    checkBox_Normal_flora_1.Enabled = true;
                    checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1.Enabled = true;
                    checkBox_Herpes_simplex_virus_1.Enabled = true;
                    checkBox_Candida_Monilia_1.Enabled = true;
                    checkBox_Trichomonas_vaginalis_1.Enabled = true;
                    checkBox_Actinomyces_1.Enabled = true;
                    checkBox_Endometrial_cells_1.Enabled = true;
                    checkBox_Others_eg_follicular_cervicitis_RT_effect_1.Enabled = true;
                    checkBox_HPV_DNA_TESTING_1.Enabled = true;
                    checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Enabled = true;
                    checkBox_Atypical_squamous_cells_1.Enabled = true;
                    checkBox_ASC_US_1.Enabled = true;
                    checkBox_ASC_H_1.Enabled = true;
                    checkBox_Squamous_intraepithelial_lesion_SIL_1.Enabled = true;
                    checkBox_Low_grade_SIL_1.Enabled = true;
                    checkBox_High_grade_SIL_1.Enabled = true;
                    checkBox_HSIL_1.Enabled = true;
                    checkBox_Squamous_cell_carcinoma_1.Enabled = true;
                    checkBox_Atypical_glandular_cells_1.Enabled = true;
                    checkBox_Atypical_glandular_cells_NOS_1.Enabled = true;
                    checkBox_Atypical_endocervical_cells_NOS_1.Enabled = true;
                    checkBox_Atypical_endometrial_cells_NOS_1.Enabled = true;
                    checkBox_Adenocarcinoma_1.Enabled = true;
                    checkBox_Endocervial_adenocarcinoma_in_situ_1.Enabled = true;
                    checkBox_Endocervial_adenocarcinoma_1.Enabled = true;
                    checkBox_Endometrial_adenocarcinoma_1.Enabled = true;
                    checkBox_Adenocarcinoma_NOS_1.Enabled = true;
                    checkBox_Other_malignant_neoplasm_1.Enabled = true;

                    textBox_Sign_At_2.Enabled = true;
                    textBox_Sign_By_2.Enabled = true;
                    comboBox_Sign_By_2.Enabled = true;

                    checkBox_Cervix_2.Enabled = true;
                    checkBox_Vagina_Vault_2.Enabled = true;
                    checkBox_Satisfactory_for_evaluation_2.Enabled = true;
                    checkBox_Satisfactory_for_evaluation_but_2.Enabled = true;
                    checkBox_Unsatisfactory_for_evaluation_2.Enabled = true;
                    checkBox_Transformation_zone_2.Enabled = true;
                    checkBox_Mainly_superficial_and_intermediate_cells_2.Enabled = true;
                    checkBox_Mainly_intermediate_and_parabasal_cells_2.Enabled = true;
                    checkBox_trophic_pattern_in_menopause_2.Enabled = true;
                    checkBox_Post_partum_changes_2.Enabled = true;
                    comboBox_SITE_TYPE_2.Enabled = true;
                    textBox_SITE_TYPE_2.Enabled = true;
                    checkBox_Liquid_based_preparation_2.Enabled = true;
                    checkBox_Liquid_based_preparations_2.Enabled = true;
                    checkBox_Conventional_Pap_smear_2.Enabled = true;
                    checkBox_Conventional_Pap_smear_2.Enabled = true;
                    checkBox_Low_squamous_cellularity_2.Enabled = true;
                    checkBox_Air_drying_artifacts_2.Enabled = true;
                    checkBox_Obscured_by_inflammatory_exudates_2.Enabled = true;
                    checkBox_Obscured_by_blood_2.Enabled = true;
                    checkBox_Thick_smear_2.Enabled = true;
                    comboBox_DIAGNOSIS_1_2.Enabled = true;
                    textBox_DIAGNOSIS_1_2.Enabled = true;
                    comboBox_DIAGNOSIS_2_2.Enabled = true;
                    textBox_DIAGNOSIS_2_2.Enabled = true;
                    comboBox_DIAGNOSIS_3_2.Enabled = true;
                    textBox_DIAGNOSIS_3_2.Enabled = true;
                    checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Enabled = true;
                    checkBox_Reactive_cellular_changes_associated_2.Enabled = true;
                    checkBox_Normal_flora_2.Enabled = true;
                    checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2.Enabled = true;
                    checkBox_Herpes_simplex_virus_2.Enabled = true;
                    checkBox_Candida_Monilia_2.Enabled = true;
                    checkBox_Trichomonas_vaginalis_2.Enabled = true;
                    checkBox_Actinomyces_2.Enabled = true;
                    checkBox_Endometrial_cells_2.Enabled = true;
                    checkBox_Others_eg_follicular_cervicitis_RT_effect_2.Enabled = true;
                    checkBox_HPV_DNA_TESTING_2.Enabled = true;
                    checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Enabled = true;
                    checkBox_Atypical_squamous_cells_2.Enabled = true;
                    checkBox_ASC_US_2.Enabled = true;
                    checkBox_ASC_H_2.Enabled = true;
                    checkBox_Squamous_intraepithelial_lesion_SIL_2.Enabled = true;
                    checkBox_Low_grade_SIL_2.Enabled = true;
                    checkBox_High_grade_SIL_2.Enabled = true;
                    checkBox_HSIL_2.Enabled = true;
                    checkBox_Squamous_cell_carcinoma_2.Enabled = true;
                    checkBox_Atypical_glandular_cells_2.Enabled = true;
                    checkBox_Atypical_glandular_cells_NOS_2.Enabled = true;
                    checkBox_Atypical_endocervical_cells_NOS_2.Enabled = true;
                    checkBox_Atypical_endometrial_cells_NOS_2.Enabled = true;
                    checkBox_Adenocarcinoma_2.Enabled = true;
                    checkBox_Endocervial_adenocarcinoma_in_situ_2.Enabled = true;
                    checkBox_Endocervial_adenocarcinoma_2.Enabled = true;
                    checkBox_Endometrial_adenocarcinoma_2.Enabled = true;
                    checkBox_Adenocarcinoma_NOS_2.Enabled = true;
                    checkBox_Other_malignant_neoplasm_2.Enabled = true;

                    textBox_Sign_At_3.Enabled = true;
                    textBox_Sign_By_3.Enabled = true;
                    comboBox_Sign_By_3.Enabled = true;

                    checkBox_Cervix_3.Enabled = true;
                    checkBox_Vagina_Vault_3.Enabled = true;
                    checkBox_Satisfactory_for_evaluation_3.Enabled = true;
                    checkBox_Satisfactory_for_evaluation_but_3.Enabled = true;
                    checkBox_Unsatisfactory_for_evaluation_3.Enabled = true;
                    checkBox_Transformation_zone_3.Enabled = true;
                    checkBox_Mainly_superficial_and_intermediate_cells_3.Enabled = true;
                    checkBox_Mainly_intermediate_and_parabasal_cells_3.Enabled = true;
                    checkBox_trophic_pattern_in_menopause_3.Enabled = true;
                    checkBox_Post_partum_changes_3.Enabled = true;
                    comboBox_SITE_TYPE_3.Enabled = true;
                    textBox_SITE_TYPE_3.Enabled = true;
                    checkBox_Liquid_based_preparation_3.Enabled = true;
                    checkBox_Liquid_based_preparations_3.Enabled = true;
                    checkBox_Conventional_Pap_smear_3.Enabled = true;
                    checkBox_Conventional_Pap_smear_3.Enabled = true;
                    checkBox_Low_squamous_cellularity_3.Enabled = true;
                    checkBox_Air_drying_artifacts_3.Enabled = true;
                    checkBox_Obscured_by_inflammatory_exudates_3.Enabled = true;
                    checkBox_Obscured_by_blood_3.Enabled = true;
                    checkBox_Thick_smear_3.Enabled = true;
                    comboBox_DIAGNOSIS_1_3.Enabled = true;
                    textBox_DIAGNOSIS_1_3.Enabled = true;
                    comboBox_DIAGNOSIS_2_3.Enabled = true;
                    textBox_DIAGNOSIS_2_3.Enabled = true;
                    comboBox_DIAGNOSIS_3_3.Enabled = true;
                    textBox_DIAGNOSIS_3_3.Enabled = true;
                    checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Enabled = true;
                    checkBox_Reactive_cellular_changes_associated_3.Enabled = true;
                    checkBox_Normal_flora_3.Enabled = true;
                    checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.Enabled = true;
                    checkBox_Herpes_simplex_virus_3.Enabled = true;
                    checkBox_Candida_Monilia_3.Enabled = true;
                    checkBox_Trichomonas_vaginalis_3.Enabled = true;
                    checkBox_Actinomyces_3.Enabled = true;
                    checkBox_Endometrial_cells_3.Enabled = true;
                    checkBox_Others_eg_follicular_cervicitis_RT_effect_3.Enabled = true;
                    checkBox_HPV_DNA_TESTING_3.Enabled = true;
                    checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Enabled = true;
                    checkBox_Atypical_squamous_cells_3.Enabled = true;
                    checkBox_ASC_US_3.Enabled = true;
                    checkBox_ASC_H_3.Enabled = true;
                    checkBox_Squamous_intraepithelial_lesion_SIL_3.Enabled = true;
                    checkBox_Low_grade_SIL_3.Enabled = true;
                    checkBox_High_grade_SIL_3.Enabled = true;
                    checkBox_HSIL_3.Enabled = true;
                    checkBox_Squamous_cell_carcinoma_3.Enabled = true;
                    checkBox_Atypical_glandular_cells_3.Enabled = true;
                    checkBox_Atypical_glandular_cells_NOS_3.Enabled = true;
                    checkBox_Atypical_endocervical_cells_NOS_3.Enabled = true;
                    checkBox_Atypical_endometrial_cells_NOS_3.Enabled = true;
                    checkBox_Adenocarcinoma_3.Enabled = true;
                    checkBox_Endocervial_adenocarcinoma_in_situ_3.Enabled = true;
                    checkBox_Endocervial_adenocarcinoma_3.Enabled = true;
                    checkBox_Endometrial_adenocarcinoma_3.Enabled = true;
                    checkBox_Adenocarcinoma_NOS_3.Enabled = true;
                    checkBox_Other_malignant_neoplasm_3.Enabled = true;

                    button_Sign_At_1.Enabled = true;
                    button_Sign_At_2.Enabled = true;
                    button_Sign_At_3.Enabled = true;

                    // some check boxes should be updated by the system only
                    disableNonEditableCheckboxes();
                }
                else
                {
                    if (status == PageStatus.STATUS_EDIT)
                    {
                        checkBox_Cervix_1.Enabled = true;
                        checkBox_Vagina_Vault_1.Enabled = true;
                        checkBox_Satisfactory_for_evaluation_1.Enabled = true;
                        checkBox_Satisfactory_for_evaluation_but_1.Enabled = true;
                        checkBox_Unsatisfactory_for_evaluation_1.Enabled = true;
                        checkBox_Transformation_zone_1.Enabled = true;
                        checkBox_Mainly_superficial_and_intermediate_cells_1.Enabled = true;
                        checkBox_Mainly_intermediate_and_parabasal_cells_1.Enabled = true;
                        checkBox_trophic_pattern_in_menopause_1.Enabled = true;
                        checkBox_Post_partum_changes_1.Enabled = true;
                        comboBox_SITE_TYPE_1.Enabled = true;
                        textBox_SITE_TYPE_1.Enabled = true;
                        checkBox_Liquid_based_preparation_1.Enabled = true;
                        checkBox_Liquid_based_preparations_1.Enabled = true;
                        checkBox_Conventional_Pap_smear_1.Enabled = true;
                        checkBox_Conventional_Pap_smears_1.Enabled = true;
                        checkBox_Low_squamous_cellularity_1.Enabled = true;
                        checkBox_Air_drying_artifacts_1.Enabled = true;
                        checkBox_Obscured_by_inflammatory_exudates_1.Enabled = true;
                        checkBox_Obscured_by_blood_1.Enabled = true;
                        checkBox_Thick_smear_1.Enabled = true;
                        comboBox_DIAGNOSIS_1_1.Enabled = true;
                        textBox_DIAGNOSIS_1_1.Enabled = true;
                        comboBox_DIAGNOSIS_2_1.Enabled = true;
                        textBox_DIAGNOSIS_2_1.Enabled = true;
                        comboBox_DIAGNOSIS_3_1.Enabled = true;
                        textBox_DIAGNOSIS_3_1.Enabled = true;
                        checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_1.Enabled = true;
                        checkBox_Reactive_cellular_changes_associated_1.Enabled = true;
                        checkBox_Normal_flora_1.Enabled = true;
                        checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_1.Enabled = true;
                        checkBox_Herpes_simplex_virus_1.Enabled = true;
                        checkBox_Candida_Monilia_1.Enabled = true;
                        checkBox_Trichomonas_vaginalis_1.Enabled = true;
                        checkBox_Actinomyces_1.Enabled = true;
                        checkBox_Endometrial_cells_1.Enabled = true;
                        checkBox_Others_eg_follicular_cervicitis_RT_effect_1.Enabled = true;
                        checkBox_HPV_DNA_TESTING_1.Enabled = true;
                        checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Enabled = true;
                        checkBox_Atypical_squamous_cells_1.Enabled = true;
                        checkBox_ASC_US_1.Enabled = true;
                        checkBox_ASC_H_1.Enabled = true;
                        checkBox_Squamous_intraepithelial_lesion_SIL_1.Enabled = true;
                        checkBox_Low_grade_SIL_1.Enabled = true;
                        checkBox_High_grade_SIL_1.Enabled = true;
                        checkBox_HSIL_1.Enabled = true;
                        checkBox_Squamous_cell_carcinoma_1.Enabled = true;
                        checkBox_Atypical_glandular_cells_1.Enabled = true;
                        checkBox_Atypical_glandular_cells_NOS_1.Enabled = true;
                        checkBox_Atypical_endocervical_cells_NOS_1.Enabled = true;
                        checkBox_Atypical_endometrial_cells_NOS_1.Enabled = true;
                        checkBox_Adenocarcinoma_1.Enabled = true;
                        checkBox_Endocervial_adenocarcinoma_in_situ_1.Enabled = true;
                        checkBox_Endocervial_adenocarcinoma_1.Enabled = true;
                        checkBox_Endometrial_adenocarcinoma_1.Enabled = true;
                        checkBox_Adenocarcinoma_NOS_1.Enabled = true;
                        checkBox_Other_malignant_neoplasm_1.Enabled = true;

                        textBox_Sign_At_2.Enabled = true;
                        textBox_Sign_By_2.Enabled = true;
                        comboBox_Sign_By_2.Enabled = true;

                        checkBox_Cervix_2.Enabled = true;
                        checkBox_Vagina_Vault_2.Enabled = true;
                        checkBox_Satisfactory_for_evaluation_2.Enabled = true;
                        checkBox_Satisfactory_for_evaluation_but_2.Enabled = true;
                        checkBox_Unsatisfactory_for_evaluation_2.Enabled = true;
                        checkBox_Transformation_zone_2.Enabled = true;
                        checkBox_Mainly_superficial_and_intermediate_cells_2.Enabled = true;
                        checkBox_Mainly_intermediate_and_parabasal_cells_2.Enabled = true;
                        checkBox_trophic_pattern_in_menopause_2.Enabled = true;
                        checkBox_Post_partum_changes_2.Enabled = true;
                        comboBox_SITE_TYPE_2.Enabled = true;
                        textBox_SITE_TYPE_2.Enabled = true;
                        checkBox_Liquid_based_preparation_2.Enabled = true;
                        checkBox_Liquid_based_preparations_2.Enabled = true;
                        checkBox_Conventional_Pap_smear_2.Enabled = true;
                        checkBox_Conventional_Pap_smears_2.Enabled = true;
                        checkBox_Low_squamous_cellularity_2.Enabled = true;
                        checkBox_Air_drying_artifacts_2.Enabled = true;
                        checkBox_Obscured_by_inflammatory_exudates_2.Enabled = true;
                        checkBox_Obscured_by_blood_2.Enabled = true;
                        checkBox_Thick_smear_2.Enabled = true;
                        comboBox_DIAGNOSIS_1_2.Enabled = true;
                        textBox_DIAGNOSIS_1_2.Enabled = true;
                        comboBox_DIAGNOSIS_2_2.Enabled = true;
                        textBox_DIAGNOSIS_2_2.Enabled = true;
                        comboBox_DIAGNOSIS_3_2.Enabled = true;
                        textBox_DIAGNOSIS_3_2.Enabled = true;
                        checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_2.Enabled = true;
                        checkBox_Reactive_cellular_changes_associated_2.Enabled = true;
                        checkBox_Normal_flora_2.Enabled = true;
                        checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_2.Enabled = true;
                        checkBox_Herpes_simplex_virus_2.Enabled = true;
                        checkBox_Candida_Monilia_2.Enabled = true;
                        checkBox_Trichomonas_vaginalis_2.Enabled = true;
                        checkBox_Actinomyces_2.Enabled = true;
                        checkBox_Endometrial_cells_2.Enabled = true;
                        checkBox_Others_eg_follicular_cervicitis_RT_effect_2.Enabled = true;
                        checkBox_HPV_DNA_TESTING_2.Enabled = true;
                        checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Enabled = true;
                        checkBox_Atypical_squamous_cells_2.Enabled = true;
                        checkBox_ASC_US_2.Enabled = true;
                        checkBox_ASC_H_2.Enabled = true;
                        checkBox_Squamous_intraepithelial_lesion_SIL_2.Enabled = true;
                        checkBox_Low_grade_SIL_2.Enabled = true;
                        checkBox_High_grade_SIL_2.Enabled = true;
                        checkBox_HSIL_2.Enabled = true;
                        checkBox_Squamous_cell_carcinoma_2.Enabled = true;
                        checkBox_Atypical_glandular_cells_2.Enabled = true;
                        checkBox_Atypical_glandular_cells_NOS_2.Enabled = true;
                        checkBox_Atypical_endocervical_cells_NOS_2.Enabled = true;
                        checkBox_Atypical_endometrial_cells_NOS_2.Enabled = true;
                        checkBox_Adenocarcinoma_2.Enabled = true;
                        checkBox_Endocervial_adenocarcinoma_in_situ_2.Enabled = true;
                        checkBox_Endocervial_adenocarcinoma_2.Enabled = true;
                        checkBox_Endometrial_adenocarcinoma_2.Enabled = true;
                        checkBox_Adenocarcinoma_NOS_2.Enabled = true;
                        checkBox_Other_malignant_neoplasm_2.Enabled = true;

                        textBox_Sign_At_3.Enabled = true;
                        textBox_Sign_By_3.Enabled = true;
                        comboBox_Sign_By_3.Enabled = true;

                        checkBox_Cervix_3.Enabled = true;
                        checkBox_Vagina_Vault_3.Enabled = true;
                        checkBox_Satisfactory_for_evaluation_3.Enabled = true;
                        checkBox_Satisfactory_for_evaluation_but_3.Enabled = true;
                        checkBox_Unsatisfactory_for_evaluation_3.Enabled = true;
                        checkBox_Transformation_zone_3.Enabled = true;
                        checkBox_Mainly_superficial_and_intermediate_cells_3.Enabled = true;
                        checkBox_Mainly_intermediate_and_parabasal_cells_3.Enabled = true;
                        checkBox_trophic_pattern_in_menopause_3.Enabled = true;
                        checkBox_Post_partum_changes_3.Enabled = true;
                        comboBox_SITE_TYPE_3.Enabled = true;
                        textBox_SITE_TYPE_3.Enabled = true;
                        checkBox_Liquid_based_preparation_3.Enabled = true;
                        checkBox_Liquid_based_preparations_3.Enabled = true;
                        checkBox_Conventional_Pap_smear_3.Enabled = true;
                        checkBox_Conventional_Pap_smears_3.Enabled = true;
                        checkBox_Low_squamous_cellularity_3.Enabled = true;
                        checkBox_Air_drying_artifacts_3.Enabled = true;
                        checkBox_Obscured_by_inflammatory_exudates_3.Enabled = true;
                        checkBox_Obscured_by_blood_3.Enabled = true;
                        checkBox_Thick_smear_3.Enabled = true;
                        comboBox_DIAGNOSIS_1_3.Enabled = true;
                        textBox_DIAGNOSIS_1_3.Enabled = true;
                        comboBox_DIAGNOSIS_2_3.Enabled = true;
                        textBox_DIAGNOSIS_2_3.Enabled = true;
                        comboBox_DIAGNOSIS_3_3.Enabled = true;
                        textBox_DIAGNOSIS_3_3.Enabled = true;
                        checkBox_NEGATIVE_FOR_INTRAEPITHELIAL_3.Enabled = true;
                        checkBox_Reactive_cellular_changes_associated_3.Enabled = true;
                        checkBox_Normal_flora_3.Enabled = true;
                        checkBox_Shift_in_flora_suggestive_of_bacterial_vaginosis_3.Enabled = true;
                        checkBox_Herpes_simplex_virus_3.Enabled = true;
                        checkBox_Candida_Monilia_3.Enabled = true;
                        checkBox_Trichomonas_vaginalis_3.Enabled = true;
                        checkBox_Actinomyces_3.Enabled = true;
                        checkBox_Endometrial_cells_3.Enabled = true;
                        checkBox_Others_eg_follicular_cervicitis_RT_effect_3.Enabled = true;
                        checkBox_HPV_DNA_TESTING_3.Enabled = true;
                        checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Enabled = true;
                        checkBox_Atypical_squamous_cells_3.Enabled = true;
                        checkBox_ASC_US_3.Enabled = true;
                        checkBox_ASC_H_3.Enabled = true;
                        checkBox_Squamous_intraepithelial_lesion_SIL_3.Enabled = true;
                        checkBox_Low_grade_SIL_3.Enabled = true;
                        checkBox_High_grade_SIL_3.Enabled = true;
                        checkBox_HSIL_3.Enabled = true;
                        checkBox_Squamous_cell_carcinoma_3.Enabled = true;
                        checkBox_Atypical_glandular_cells_3.Enabled = true;
                        checkBox_Atypical_glandular_cells_NOS_3.Enabled = true;
                        checkBox_Atypical_endocervical_cells_NOS_3.Enabled = true;
                        checkBox_Atypical_endometrial_cells_NOS_3.Enabled = true;
                        checkBox_Adenocarcinoma_3.Enabled = true;
                        checkBox_Endocervial_adenocarcinoma_in_situ_3.Enabled = true;
                        checkBox_Endocervial_adenocarcinoma_3.Enabled = true;
                        checkBox_Endometrial_adenocarcinoma_3.Enabled = true;
                        checkBox_Adenocarcinoma_NOS_3.Enabled = true;
                        checkBox_Other_malignant_neoplasm_3.Enabled = true;

                        button_Sign_At_1.Enabled = true;
                        button_Sign_At_2.Enabled = true;
                        button_Sign_At_3.Enabled = true;

                        // some check boxes should be updated by the system only
                        disableNonEditableCheckboxes();
                    }
                }
            }
        }

        public void disableNonEditableCheckboxes()
        {
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_1.Enabled = false;
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_2.Enabled = false;
            checkBox_EPITHELIAL_CELL_ABNORMALITIES_3.Enabled = false;

            checkBox_Atypical_squamous_cells_1.Enabled = false;
            checkBox_Atypical_squamous_cells_2.Enabled = false;
            checkBox_Atypical_squamous_cells_3.Enabled = false;

            checkBox_Squamous_intraepithelial_lesion_SIL_1.Enabled = false;
            checkBox_Squamous_intraepithelial_lesion_SIL_2.Enabled = false;
            checkBox_Squamous_intraepithelial_lesion_SIL_3.Enabled = false;

            checkBox_Atypical_glandular_cells_1.Enabled = false;
            checkBox_Atypical_glandular_cells_2.Enabled = false;
            checkBox_Atypical_glandular_cells_3.Enabled = false;

            checkBox_Adenocarcinoma_1.Enabled = false;
            checkBox_Adenocarcinoma_2.Enabled = false;
            checkBox_Adenocarcinoma_3.Enabled = false;
        }

        private void comboBox_SITE_TYPE_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet siteResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_site] WHERE site ='{0}'", comboBox_SITE_TYPE_1.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, siteResultDataSet, "cy_site");

            if (siteResultDataSet.Tables["cy_site"].Rows.Count > 0)
            {
                DataRow mDr = siteResultDataSet.Tables["cy_site"].Rows[0];
                textBox_SITE_TYPE_1.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_SITE_TYPE_2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet siteResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_site] WHERE site ='{0}'", comboBox_SITE_TYPE_2.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, siteResultDataSet, "cy_site");

            if (siteResultDataSet.Tables["cy_site"].Rows.Count > 0)
            {
                DataRow mDr = siteResultDataSet.Tables["cy_site"].Rows[0];
                textBox_SITE_TYPE_2.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_SITE_TYPE_3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet siteResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_site] WHERE site ='{0}'", comboBox_SITE_TYPE_3.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, siteResultDataSet, "cy_site");

            if (siteResultDataSet.Tables["cy_site"].Rows.Count > 0)
            {
                DataRow mDr = siteResultDataSet.Tables["cy_site"].Rows[0];
                textBox_SITE_TYPE_3.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_1_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_1_1.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_1_1.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_2_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_2_1.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_2_1.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_3_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_3_1.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_3_1.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_1_2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_1_2.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_1_2.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_2_2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_2_2.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_2_2.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_3_2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_3_2.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_3_2.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_1_3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_1_3.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_1_3.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_2_3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_2_3.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_2_3.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void comboBox_DIAGNOSIS_3_3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet diagnosisResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_diag] WHERE diag ='{0}'", comboBox_DIAGNOSIS_3_3.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, diagnosisResultDataSet, "cy_diag");

            if (diagnosisResultDataSet.Tables["cy_diag"].Rows.Count > 0)
            {
                DataRow mDr = diagnosisResultDataSet.Tables["cy_diag"].Rows[0];
                textBox_DIAGNOSIS_3_3.Text = mDr["desc"].ToString().Trim();
            }
        }

        private void button_Sign_At_1_Click(object sender, EventArgs e)
        {
            textBox_Sign_At_1.Text = DateTime.Now.ToString(DateUtil.FORMAT_DEFAULT_DATE_TIME);
            textBox_Sign_By_1.Text = CurrentUser.currentUserId;

            //if (dt1 != null && dt1.Rows.Count == 0)
            //{
            //    MessageBox.Show("There are no existing row under");
            //    return;
            //}

            //if (dt1 != null)
            //{
            //    dt1.Rows[0]["sign_at"] = DateTime.Now;
            //    dt1.Rows[0]["sign_id"] = CurrentUser.currentUserId;
            //}

            if (dt1 != null && dt2 != null)
            {
                //dt2.Rows[0]["sign_at"] = dt1.Rows[0]["sign_at"];
                //dt2.Rows[0]["sign_id"] = dt1.Rows[0]["sign_id"];
                //dt2.Rows[0]["sign_by"] = dt1.Rows[0]["sign_by"];
                dt2.Rows[0]["site"] = dt1.Rows[0]["site"];
                dt2.Rows[0]["site_desc"] = dt1.Rows[0]["site_desc"];
                dt2.Rows[0]["diag1"] = dt1.Rows[0]["diag1"];
                dt2.Rows[0]["diag1_desc"] = dt1.Rows[0]["diag1_desc"];
                dt2.Rows[0]["diag2"] = dt1.Rows[0]["diag2"];
                dt2.Rows[0]["diag2_desc"] = dt1.Rows[0]["diag2_desc"];
                dt2.Rows[0]["diag3"] = dt1.Rows[0]["diag3"];
                dt2.Rows[0]["diag3_desc"] = dt1.Rows[0]["diag3_desc"];
                dt2.Rows[0]["site1"] = dt1.Rows[0]["site1"];
                dt2.Rows[0]["site2"] = dt1.Rows[0]["site2"];
                dt2.Rows[0]["specimena1"] = dt1.Rows[0]["specimena1"];
                dt2.Rows[0]["specimena2"] = dt1.Rows[0]["specimena2"];
                dt2.Rows[0]["specimena3"] = dt1.Rows[0]["specimena3"];
                dt2.Rows[0]["cellularc1"] = dt1.Rows[0]["cellularc1"];
                dt2.Rows[0]["cellularc2"] = dt1.Rows[0]["cellularc2"];
                dt2.Rows[0]["cellularc3"] = dt1.Rows[0]["cellularc3"];
                dt2.Rows[0]["cellularc4"] = dt1.Rows[0]["cellularc4"];
                dt2.Rows[0]["cellularc5"] = dt1.Rows[0]["cellularc5"];
                dt2.Rows[0]["prepair1"] = dt1.Rows[0]["prepair1"];
                dt2.Rows[0]["prepair2"] = dt1.Rows[0]["prepair2"];
                dt2.Rows[0]["prepair3"] = dt1.Rows[0]["prepair3"];
                dt2.Rows[0]["prepair4"] = dt1.Rows[0]["prepair4"];
                dt2.Rows[0]["specimenq1"] = dt1.Rows[0]["specimenq1"];
                dt2.Rows[0]["specimenq2"] = dt1.Rows[0]["specimenq2"];
                dt2.Rows[0]["specimenq3"] = dt1.Rows[0]["specimenq3"];
                dt2.Rows[0]["specimenq4"] = dt1.Rows[0]["specimenq4"];
                dt2.Rows[0]["specimenq5"] = dt1.Rows[0]["specimenq5"];
                dt2.Rows[0]["interneg"] = dt1.Rows[0]["interneg"];
                dt2.Rows[0]["interneg1"] = dt1.Rows[0]["interneg1"];
                dt2.Rows[0]["interneg2"] = dt1.Rows[0]["interneg2"];
                dt2.Rows[0]["interneg3"] = dt1.Rows[0]["interneg3"];
                dt2.Rows[0]["interneg4"] = dt1.Rows[0]["interneg4"];
                dt2.Rows[0]["interneg5"] = dt1.Rows[0]["interneg5"];
                dt2.Rows[0]["interneg6"] = dt1.Rows[0]["interneg6"];
                dt2.Rows[0]["interneg7"] = dt1.Rows[0]["interneg7"];
                dt2.Rows[0]["interneg8"] = dt1.Rows[0]["interneg8"];
                dt2.Rows[0]["interneg9"] = dt1.Rows[0]["interneg9"];
                dt2.Rows[0]["hpv_dna"] = dt1.Rows[0]["hpv_dna"];
                dt2.Rows[0]["interepi"] = dt1.Rows[0]["interepi"];
                dt2.Rows[0]["interepi1"] = dt1.Rows[0]["interepi1"];
                dt2.Rows[0]["interepi1a"] = dt1.Rows[0]["interepi1a"];
                dt2.Rows[0]["interepi1b"] = dt1.Rows[0]["interepi1b"];
                dt2.Rows[0]["interepi2"] = dt1.Rows[0]["interepi2"];
                dt2.Rows[0]["interepi2a"] = dt1.Rows[0]["interepi2a"];
                dt2.Rows[0]["interepi2b"] = dt1.Rows[0]["interepi2b"];
                dt2.Rows[0]["interepi2c"] = dt1.Rows[0]["interepi2c"];
                dt2.Rows[0]["interepi3"] = dt1.Rows[0]["interepi3"];
                dt2.Rows[0]["interepi4"] = dt1.Rows[0]["interepi4"];
                dt2.Rows[0]["interepi4a"] = dt1.Rows[0]["interepi4a"];
                dt2.Rows[0]["interepi4b"] = dt1.Rows[0]["interepi4b"];
                dt2.Rows[0]["interepi4c"] = dt1.Rows[0]["interepi4c"];
                dt2.Rows[0]["interepi5"] = dt1.Rows[0]["interepi5"];
                dt2.Rows[0]["interepi5a"] = dt1.Rows[0]["interepi5a"];
                dt2.Rows[0]["interepi5b"] = dt1.Rows[0]["interepi5b"];
                dt2.Rows[0]["interepi5c"] = dt1.Rows[0]["interepi5c"];
                dt2.Rows[0]["interepi5d"] = dt1.Rows[0]["interepi5d"];
                dt2.Rows[0]["interepi6"] = dt1.Rows[0]["interepi6"];
            }

            if (dt1 != null && dt3 != null)
            {
                //dt3.Rows[0]["sign_at"] = dt1.Rows[0]["sign_at"];
                //dt3.Rows[0]["sign_id"] = dt1.Rows[0]["sign_id"];
                //dt3.Rows[0]["sign_by"] = dt1.Rows[0]["sign_by"];
                dt3.Rows[0]["site"] = dt1.Rows[0]["site"];
                dt3.Rows[0]["site_desc"] = dt1.Rows[0]["site_desc"];
                dt3.Rows[0]["diag1"] = dt1.Rows[0]["diag1"];
                dt3.Rows[0]["diag1_desc"] = dt1.Rows[0]["diag1_desc"];
                dt3.Rows[0]["diag2"] = dt1.Rows[0]["diag2"];
                dt3.Rows[0]["diag2_desc"] = dt1.Rows[0]["diag2_desc"];
                dt3.Rows[0]["diag3"] = dt1.Rows[0]["diag3"];
                dt3.Rows[0]["diag3_desc"] = dt1.Rows[0]["diag3_desc"];
                dt3.Rows[0]["site1"] = dt1.Rows[0]["site1"];
                dt3.Rows[0]["site2"] = dt1.Rows[0]["site2"];
                dt3.Rows[0]["specimena1"] = dt1.Rows[0]["specimena1"];
                dt3.Rows[0]["specimena2"] = dt1.Rows[0]["specimena2"];
                dt3.Rows[0]["specimena3"] = dt1.Rows[0]["specimena3"];
                dt3.Rows[0]["cellularc1"] = dt1.Rows[0]["cellularc1"];
                dt3.Rows[0]["cellularc2"] = dt1.Rows[0]["cellularc2"];
                dt3.Rows[0]["cellularc3"] = dt1.Rows[0]["cellularc3"];
                dt3.Rows[0]["cellularc4"] = dt1.Rows[0]["cellularc4"];
                dt3.Rows[0]["cellularc5"] = dt1.Rows[0]["cellularc5"];
                dt3.Rows[0]["prepair1"] = dt1.Rows[0]["prepair1"];
                dt3.Rows[0]["prepair2"] = dt1.Rows[0]["prepair2"];
                dt3.Rows[0]["prepair3"] = dt1.Rows[0]["prepair3"];
                dt3.Rows[0]["prepair4"] = dt1.Rows[0]["prepair4"];
                dt3.Rows[0]["specimenq1"] = dt1.Rows[0]["specimenq1"];
                dt3.Rows[0]["specimenq2"] = dt1.Rows[0]["specimenq2"];
                dt3.Rows[0]["specimenq3"] = dt1.Rows[0]["specimenq3"];
                dt3.Rows[0]["specimenq4"] = dt1.Rows[0]["specimenq4"];
                dt3.Rows[0]["specimenq5"] = dt1.Rows[0]["specimenq5"];
                dt3.Rows[0]["interneg"] = dt1.Rows[0]["interneg"];
                dt3.Rows[0]["interneg1"] = dt1.Rows[0]["interneg1"];
                dt3.Rows[0]["interneg2"] = dt1.Rows[0]["interneg2"];
                dt3.Rows[0]["interneg3"] = dt1.Rows[0]["interneg3"];
                dt3.Rows[0]["interneg4"] = dt1.Rows[0]["interneg4"];
                dt3.Rows[0]["interneg5"] = dt1.Rows[0]["interneg5"];
                dt3.Rows[0]["interneg6"] = dt1.Rows[0]["interneg6"];
                dt3.Rows[0]["interneg7"] = dt1.Rows[0]["interneg7"];
                dt3.Rows[0]["interneg8"] = dt1.Rows[0]["interneg8"];
                dt3.Rows[0]["interneg9"] = dt1.Rows[0]["interneg9"];
                dt3.Rows[0]["hpv_dna"] = dt1.Rows[0]["hpv_dna"];
                dt3.Rows[0]["interepi"] = dt1.Rows[0]["interepi"];
                dt3.Rows[0]["interepi1"] = dt1.Rows[0]["interepi1"];
                dt3.Rows[0]["interepi1a"] = dt1.Rows[0]["interepi1a"];
                dt3.Rows[0]["interepi1b"] = dt1.Rows[0]["interepi1b"];
                dt3.Rows[0]["interepi2"] = dt1.Rows[0]["interepi2"];
                dt3.Rows[0]["interepi2a"] = dt1.Rows[0]["interepi2a"];
                dt3.Rows[0]["interepi2b"] = dt1.Rows[0]["interepi2b"];
                dt3.Rows[0]["interepi2c"] = dt1.Rows[0]["interepi2c"];
                dt3.Rows[0]["interepi3"] = dt1.Rows[0]["interepi3"];
                dt3.Rows[0]["interepi4"] = dt1.Rows[0]["interepi4"];
                dt3.Rows[0]["interepi4a"] = dt1.Rows[0]["interepi4a"];
                dt3.Rows[0]["interepi4b"] = dt1.Rows[0]["interepi4b"];
                dt3.Rows[0]["interepi4c"] = dt1.Rows[0]["interepi4c"];
                dt3.Rows[0]["interepi5"] = dt1.Rows[0]["interepi5"];
                dt3.Rows[0]["interepi5a"] = dt1.Rows[0]["interepi5a"];
                dt3.Rows[0]["interepi5b"] = dt1.Rows[0]["interepi5b"];
                dt3.Rows[0]["interepi5c"] = dt1.Rows[0]["interepi5c"];
                dt3.Rows[0]["interepi5d"] = dt1.Rows[0]["interepi5d"];
                dt3.Rows[0]["interepi6"] = dt1.Rows[0]["interepi6"];
            }
        }

        private void button_Sign_At_2_Click(object sender, EventArgs e)
        {
            textBox_Sign_At_2.Text = DateTime.Now.ToString(DateUtil.FORMAT_DEFAULT_DATE_TIME);
            textBox_Sign_By_2.Text = CurrentUser.currentUserId;
            if (dt2 != null)
            {
                dt2.Rows[0]["sign_at"] = DateTime.Now;
                dt2.Rows[0]["sign_id"] = CurrentUser.currentUserId;
            }

            if (dt2 != null && dt3 != null)
            {
                dt3.Rows[0]["site"] = dt2.Rows[0]["site"];
                dt3.Rows[0]["site_desc"] = dt2.Rows[0]["site_desc"];
                dt3.Rows[0]["diag1"] = dt2.Rows[0]["diag1"];
                dt3.Rows[0]["diag1_desc"] = dt2.Rows[0]["diag1_desc"];
                dt3.Rows[0]["diag2"] = dt2.Rows[0]["diag2"];
                dt3.Rows[0]["diag2_desc"] = dt2.Rows[0]["diag2_desc"];
                dt3.Rows[0]["diag3"] = dt2.Rows[0]["diag3"];
                dt3.Rows[0]["diag3_desc"] = dt2.Rows[0]["diag3_desc"];
                dt3.Rows[0]["site1"] = dt2.Rows[0]["site1"];
                dt3.Rows[0]["site2"] = dt2.Rows[0]["site2"];
                dt3.Rows[0]["specimena1"] = dt2.Rows[0]["specimena1"];
                dt3.Rows[0]["specimena2"] = dt2.Rows[0]["specimena2"];
                dt3.Rows[0]["specimena3"] = dt2.Rows[0]["specimena3"];
                dt3.Rows[0]["cellularc1"] = dt2.Rows[0]["cellularc1"];
                dt3.Rows[0]["cellularc2"] = dt2.Rows[0]["cellularc2"];
                dt3.Rows[0]["cellularc3"] = dt2.Rows[0]["cellularc3"];
                dt3.Rows[0]["cellularc4"] = dt2.Rows[0]["cellularc4"];
                dt3.Rows[0]["cellularc5"] = dt2.Rows[0]["cellularc5"];
                dt3.Rows[0]["prepair1"] = dt2.Rows[0]["prepair1"];
                dt3.Rows[0]["prepair2"] = dt2.Rows[0]["prepair2"];
                dt3.Rows[0]["prepair3"] = dt2.Rows[0]["prepair3"];
                dt3.Rows[0]["prepair4"] = dt2.Rows[0]["prepair4"];
                dt3.Rows[0]["specimenq1"] = dt2.Rows[0]["specimenq1"];
                dt3.Rows[0]["specimenq2"] = dt2.Rows[0]["specimenq2"];
                dt3.Rows[0]["specimenq3"] = dt2.Rows[0]["specimenq3"];
                dt3.Rows[0]["specimenq4"] = dt2.Rows[0]["specimenq4"];
                dt3.Rows[0]["specimenq5"] = dt2.Rows[0]["specimenq5"];
                dt3.Rows[0]["interneg"] = dt2.Rows[0]["interneg"];
                dt3.Rows[0]["interneg1"] = dt2.Rows[0]["interneg1"];
                dt3.Rows[0]["interneg2"] = dt2.Rows[0]["interneg2"];
                dt3.Rows[0]["interneg3"] = dt2.Rows[0]["interneg3"];
                dt3.Rows[0]["interneg4"] = dt2.Rows[0]["interneg4"];
                dt3.Rows[0]["interneg5"] = dt2.Rows[0]["interneg5"];
                dt3.Rows[0]["interneg6"] = dt2.Rows[0]["interneg6"];
                dt3.Rows[0]["interneg7"] = dt2.Rows[0]["interneg7"];
                dt3.Rows[0]["interneg8"] = dt2.Rows[0]["interneg8"];
                dt3.Rows[0]["interneg9"] = dt2.Rows[0]["interneg9"];
                dt3.Rows[0]["hpv_dna"] = dt2.Rows[0]["hpv_dna"];
                dt3.Rows[0]["interepi"] = dt2.Rows[0]["interepi"];
                dt3.Rows[0]["interepi1"] = dt2.Rows[0]["interepi1"];
                dt3.Rows[0]["interepi1a"] = dt2.Rows[0]["interepi1a"];
                dt3.Rows[0]["interepi1b"] = dt2.Rows[0]["interepi1b"];
                dt3.Rows[0]["interepi2"] = dt2.Rows[0]["interepi2"];
                dt3.Rows[0]["interepi2a"] = dt2.Rows[0]["interepi2a"];
                dt3.Rows[0]["interepi2b"] = dt2.Rows[0]["interepi2b"];
                dt3.Rows[0]["interepi2c"] = dt2.Rows[0]["interepi2c"];
                dt3.Rows[0]["interepi3"] = dt2.Rows[0]["interepi3"];
                dt3.Rows[0]["interepi4"] = dt2.Rows[0]["interepi4"];
                dt3.Rows[0]["interepi4a"] = dt2.Rows[0]["interepi4a"];
                dt3.Rows[0]["interepi4b"] = dt2.Rows[0]["interepi4b"];
                dt3.Rows[0]["interepi4c"] = dt2.Rows[0]["interepi4c"];
                dt3.Rows[0]["interepi5"] = dt2.Rows[0]["interepi5"];
                dt3.Rows[0]["interepi5a"] = dt2.Rows[0]["interepi5a"];
                dt3.Rows[0]["interepi5b"] = dt2.Rows[0]["interepi5b"];
                dt3.Rows[0]["interepi5c"] = dt2.Rows[0]["interepi5c"];
                dt3.Rows[0]["interepi5d"] = dt2.Rows[0]["interepi5d"];
                dt3.Rows[0]["interepi6"] = dt2.Rows[0]["interepi6"];
            }

        }

        private void button_Sign_At_3_Click(object sender, EventArgs e)
        {
            textBox_Sign_At_3.Text = DateTime.Now.ToString(DateUtil.FORMAT_DEFAULT_DATE_TIME);
            textBox_Sign_By_3.Text = CurrentUser.currentUserId;
            if (dt3 != null)
            {
                dt3.Rows[0]["sign_at"] = DateTime.Now;
                dt3.Rows[0]["sign_id"] = CurrentUser.currentUserId;
            }
        }

        private void comboBox_DIAGNOSIS_3_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reloadAndBindingDBData()
        {
            string sql1 = string.Format("SELECT TOP 1 * FROM [cy_diag1] WHERE case_no = '{0}'", caseNo);
            cyDiagDataAdapter1 = DBConn.fetchDataIntoDataSet(sql1, cyDiagDataSet1, "cy_diag1");

            string sql2 = string.Format("SELECT TOP 1 * FROM [cy_diag2] WHERE case_no = '{0}'", caseNo);
            cyDiagDataAdapter2 = DBConn.fetchDataIntoDataSet(sql2, cyDiagDataSet2, "cy_diag2");

            string sql3 = string.Format("SELECT TOP 1 * FROM [cy_diag3] WHERE case_no = '{0}'", caseNo);
            cyDiagDataAdapter3 = DBConn.fetchDataIntoDataSet(sql3, cyDiagDataSet3, "cy_diag3");

            dt1 = cyDiagDataSet1.Tables["cy_diag1"];
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["id"] };
            dt1.Columns["id"].AutoIncrement = true;
            dt1.Columns["id"].AutoIncrementStep = 1;

            dt2 = cyDiagDataSet2.Tables["cy_diag2"];
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["id"] };
            dt2.Columns["id"].AutoIncrement = true;
            dt2.Columns["id"].AutoIncrementStep = 1;

            dt3 = cyDiagDataSet3.Tables["cy_diag3"];
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
            checkBox_Conventional_Pap_smears_1.DataBindings.Clear();
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
            checkBox_Conventional_Pap_smears_2.DataBindings.Clear();
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
            checkBox_Other_malignant_neoplasm_2.DataBindings.Clear();

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
            checkBox_Conventional_Pap_smears_3.DataBindings.Clear();
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

            String screenerSql = "select user_name as doctor from [user] where SCREENER1 = 'T' order by user_name";
            DataSet screenerDataSet1 = new DataSet();
            SqlDataAdapter screenerDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(screenerSql, screenerDataSet1, "sign_doctor");
            DataTable doctorDt1 = new DataTable();
            doctorDt1.Columns.Add("doctor");
            DataTable doctorDt2 = doctorDt1.Clone();
            foreach (DataRow mDr in screenerDataSet1.Tables["sign_doctor"].Rows)
            {
                doctorDt1.Rows.Add(new object[] { mDr["doctor"] });
                doctorDt2.Rows.Add(new object[] { mDr["doctor"] });
            }

            string doctorSql1 = "SELECT doctor FROM [sign_doctor] order by doctor";
            DataSet doctorDataSet1 = new DataSet();
            SqlDataAdapter doctorDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql1, doctorDataSet1, "sign_doctor");

            DataTable doctorDt3 = new DataTable();
            doctorDt3.Columns.Add("doctor");

            foreach (DataRow mDr in doctorDataSet1.Tables["sign_doctor"].Rows)
            {
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

            comboBox_SITE_TYPE_1.DataSource = siteDt1;
            comboBox_SITE_TYPE_2.DataSource = siteDt2;
            comboBox_SITE_TYPE_3.DataSource = siteDt3;

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
            DataTable diagDt7 = diagDt1.Clone();
            DataTable diagDt8 = diagDt1.Clone();
            DataTable diagDt9 = diagDt1.Clone();

            foreach (DataRow mDr in diagDataSet.Tables["cy_diag"].Rows)
            {
                diagDt1.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt2.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt3.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt4.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt5.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt6.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt7.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt8.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt9.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
            }

            comboBox_DIAGNOSIS_1_1.DataSource = diagDt1;
            comboBox_DIAGNOSIS_1_2.DataSource = diagDt2;
            comboBox_DIAGNOSIS_1_3.DataSource = diagDt3;
            comboBox_DIAGNOSIS_2_1.DataSource = diagDt4;
            comboBox_DIAGNOSIS_2_2.DataSource = diagDt5;
            comboBox_DIAGNOSIS_2_3.DataSource = diagDt6;
            comboBox_DIAGNOSIS_3_1.DataSource = diagDt7;
            comboBox_DIAGNOSIS_3_2.DataSource = diagDt8;
            comboBox_DIAGNOSIS_3_3.DataSource = diagDt9;

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

        private void reloadAndBindingDBDataWithExistDataSet()
        {
            cyDiagDataSet1 = existCyDiagDataSet1;
            cyDiagDataSet2 = existCyDiagDataSet2;
            cyDiagDataSet3 = existCyDiagDataSet3;
            cyDiagDataAdapter1 = existCyDiagDataAdapter1;
            cyDiagDataAdapter2 = existCyDiagDataAdapter2;
            cyDiagDataAdapter3 = existCyDiagDataAdapter3;

            dt1 = cyDiagDataSet1.Tables["cy_diag1"];
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["id"] };
            dt1.Columns["id"].AutoIncrement = true;
            dt1.Columns["id"].AutoIncrementStep = 1;

            dt2 = cyDiagDataSet2.Tables["cy_diag2"];
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["id"] };
            dt2.Columns["id"].AutoIncrement = true;
            dt2.Columns["id"].AutoIncrementStep = 1;

            dt3 = cyDiagDataSet3.Tables["cy_diag3"];
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
            checkBox_Conventional_Pap_smears_1.DataBindings.Clear();
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
            checkBox_Conventional_Pap_smears_2.DataBindings.Clear();
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
            checkBox_Other_malignant_neoplasm_2.DataBindings.Clear();

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
            checkBox_Conventional_Pap_smears_3.DataBindings.Clear();
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

            String screenerSql = "select user_name as doctor from [user] where SCREENER1 = 'T' order by user_name";
            DataSet screenerDataSet1 = new DataSet();
            SqlDataAdapter screenerDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(screenerSql, screenerDataSet1, "sign_doctor");
            DataTable doctorDt1 = new DataTable();
            doctorDt1.Columns.Add("doctor");
            DataTable doctorDt2 = doctorDt1.Clone();
            foreach (DataRow mDr in screenerDataSet1.Tables["sign_doctor"].Rows)
            {
                doctorDt1.Rows.Add(new object[] { mDr["doctor"] });
                doctorDt2.Rows.Add(new object[] { mDr["doctor"] });
            }

            string doctorSql1 = "SELECT doctor FROM [sign_doctor] order by doctor";
            DataSet doctorDataSet1 = new DataSet();
            SqlDataAdapter doctorDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql1, doctorDataSet1, "sign_doctor");

            DataTable doctorDt3 = new DataTable();
            doctorDt3.Columns.Add("doctor");

            foreach (DataRow mDr in doctorDataSet1.Tables["sign_doctor"].Rows)
            {
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

            comboBox_SITE_TYPE_1.DataSource = siteDt1;
            comboBox_SITE_TYPE_2.DataSource = siteDt2;
            comboBox_SITE_TYPE_3.DataSource = siteDt3;

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
            DataTable diagDt7 = diagDt1.Clone();
            DataTable diagDt8 = diagDt1.Clone();
            DataTable diagDt9 = diagDt1.Clone();

            foreach (DataRow mDr in diagDataSet.Tables["cy_diag"].Rows)
            {
                diagDt1.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt2.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt3.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt4.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt5.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt6.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt7.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt8.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
                diagDt9.Rows.Add(new object[] { mDr["diag"].ToString().Trim(), mDr["desc"].ToString().Trim() });
            }

            comboBox_DIAGNOSIS_1_1.DataSource = diagDt1;
            comboBox_DIAGNOSIS_1_2.DataSource = diagDt2;
            comboBox_DIAGNOSIS_1_3.DataSource = diagDt3;
            comboBox_DIAGNOSIS_2_1.DataSource = diagDt4;
            comboBox_DIAGNOSIS_2_2.DataSource = diagDt5;
            comboBox_DIAGNOSIS_2_3.DataSource = diagDt6;
            comboBox_DIAGNOSIS_3_1.DataSource = diagDt7;
            comboBox_DIAGNOSIS_3_2.DataSource = diagDt8;
            comboBox_DIAGNOSIS_3_3.DataSource = diagDt9;

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
