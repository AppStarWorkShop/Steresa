﻿using System;
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
    public partial class Form_CYTOLOGYFileGyname : Form
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

        private bool m_isEntering1 = false;
        private bool m_isEntering2 = false;
        private bool m_isEntering3 = false;

        private String reportWording = "";

        DataSet doctorDataSet1 = new DataSet();
        SqlDataAdapter doctorDataAdapter1;

        DataSet doctorDataSet2 = new DataSet();
        SqlDataAdapter doctorDataAdapter2;

        DataSet doctorDataSet3 = new DataSet();
        SqlDataAdapter doctorDataAdapter3;

        private Form_CytologicalDiagnosis diagForm;
        private DataSet existCyDiagDataSet1 = null;
        private SqlDataAdapter existCyDiagDataAdapter1 = null;

        private DataSet existCyDiagDataSet2 = null;
        private SqlDataAdapter existCyDiagDataAdapter2 = null;

        private DataSet existCyDiagDataSet3 = null;
        private SqlDataAdapter existCyDiagDataAdapter3 = null;

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

        public Form_CYTOLOGYFileGyname()
        {
            InitializeComponent();
        }

        public Form_CYTOLOGYFileGyname(bool isNewPatient)
        {
            this.isNewPatient = isNewPatient;
            InitializeComponent();
        }

        public Form_CYTOLOGYFileGyname(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (diagForm != null)
            {
                diagForm.Close();
            }
            this.Close();
        }

        private void button_F5_CY_Diagnosis_Click(object sender, EventArgs e)
        {
            Form_CytologicalDiagnosis open = new Form_CytologicalDiagnosis(textBox_Case_No.Text.Trim(), currentStatus, existCyDiagDataSet1, existCyDiagDataSet2, existCyDiagDataSet3, existCyDiagDataAdapter1, existCyDiagDataAdapter2, existCyDiagDataAdapter3);
            open.OnCyDiagExit += CyDiagReturn;
            open.Show();
            /*if (textBox_Case_No.Text != "")
            {
                String countSql = " cy_diag1 where case_no = '" + textBox_Case_No.Text.Trim() + "'";
                if (DBConn.getSqlRecordCount(countSql) == 0)
                {
                    open.setDefaultValue();
                }
            }*/


            //if (diagForm == null)
            //{
            //  Form_CytologicalDiagnosis open = new Form_CytologicalDiagnosis(textBox_Case_No.Text.Trim(), currentStatus, existCyDiagDataSet1, existCyDiagDataSet2, existCyDiagDataSet3, existCyDiagDataAdapter1, existCyDiagDataAdapter2, existCyDiagDataAdapter3);
            //  open.OnCyDiagExit += CyDiagReturn;

            //    //Form_CytologicalDiagnosis open = new Form_CytologicalDiagnosis();
            //    open.Show();
            //    open.setPreviousFileForm(this);
            //    if (currentStatus == PageStatus.STATUS_NEW)
            //    {
            //        open.setDefaultValue();
            //    }

            //    diagForm = open;
            //}
            //else
            //{
            //    diagForm.Show();
            //}

        }

        private void CyDiagReturn(DataSet existCyDiagDataSet1, DataSet existCyDiagDataSet2, DataSet existCyDiagDataSet3, SqlDataAdapter existCyDiagDataAdapter1, SqlDataAdapter existCyDiagDataAdapter2, SqlDataAdapter existCyDiagDataAdapter3)
        {
            this.existCyDiagDataAdapter1 = existCyDiagDataAdapter1;
            this.existCyDiagDataAdapter2 = existCyDiagDataAdapter2;
            this.existCyDiagDataAdapter3 = existCyDiagDataAdapter3;

            this.existCyDiagDataSet1 = existCyDiagDataSet1;
            this.existCyDiagDataSet2 = existCyDiagDataSet2;
            this.existCyDiagDataSet3 = existCyDiagDataSet3;

            if(existCyDiagDataSet1 != null)
            {
                if (existCyDiagDataSet1.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        comboBox_Sign_By_Dr_1.SelectedValue = existCyDiagDataSet1.Tables[0].Rows[0]["SIGN_BY"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            if (existCyDiagDataSet2 != null)
            {
                if (existCyDiagDataSet2.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        comboBox_Sign_By_Dr_2.SelectedValue = existCyDiagDataSet2.Tables[0].Rows[0]["SIGN_BY"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            if (existCyDiagDataSet3 != null)
            {
                if (existCyDiagDataSet3.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        comboBox_Sign_By_Dr_3.SelectedValue = existCyDiagDataSet3.Tables[0].Rows[0]["SIGN_BY"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void button_F6_Gynaecologl_Histoy_Click(object sender, EventArgs e)
        {
            Form_GynecologicalHistory open = new Form_GynecologicalHistory(textBox_ID.Text.Trim());
            open.Show();
        }

        private void button_F10_Findings_and_Comments_Click(object sender, EventArgs e)
        {
            Form_FindingComments open = new Form_FindingComments(currentStatus, existCyDiagDataSet3, existCyDiagDataAdapter3);
            open.OnFindingCommentsExit += FindingCommentsReturn;
            open.Show();
        }

        private void FindingCommentsReturn(DataSet existCyDiagDataSet3, SqlDataAdapter existCyDiagDataAdapter3)
        {
            this.existCyDiagDataAdapter3 = existCyDiagDataAdapter3;

            this.existCyDiagDataSet3 = existCyDiagDataSet3;
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
                        Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                        open.Show();
                        this.Close();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                            setPreviousRecordMark();
                            reloadCyDiagData();
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
                                Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                                open.Show();
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

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
                        Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                        open.Show();
                        this.Close();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                            setPreviousRecordMark();
                            reloadCyDiagData();
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
                                Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                                open.Show();
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            string countSql = string.Format(" (SELECT top 1 case_no,id FROM [medlab].[dbo].[BXCY_SPECIMEN] order by case_no,id ) t1 WHERE t1.case_no <> '{0}' and t1.id <> {1}", textBox_Case_No.Text.Trim(), textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string selectOneSql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] ORDER BY case_no,id");
                DataSet selectOneDataSet = new DataSet();
                SqlDataAdapter selectOneDataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, selectOneDataSet, "bxcy_specimen");
                if (selectOneDataSet.Tables["bxcy_specimen"].Rows.Count > 0)
                {
                    string selectOneCaseNo = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["case_no"].ToString();
                    string selectOnId = selectOneDataSet.Tables["bxcy_specimen"].Rows[0]["id"].ToString();

                    if (selectOneCaseNo == null || selectOneCaseNo.Trim() == "" || selectOneCaseNo.Trim().Length == 0)
                    {
                        Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                        open.Show();
                        this.Close();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                            setPreviousRecordMark();
                            reloadCyDiagData();
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
                                Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                                open.Show();
                                this.Close();
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
                        Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                        open.Show();
                        this.Close();
                    }
                    else
                    {
                        if (selectOneCaseNo.Substring(selectOneCaseNo.Length - 1, 1).ToLower() == "g")
                        {
                            dataAdapter = DBConn.fetchDataIntoDataSet(selectOneSql, bxcy_specimenDataSet, "bxcy_specimen");

                            button_Printed.Text = string.Format("Printed:{0}", label_Printed.Text.Trim() == "" ? "0" : label_Printed.Text.Trim());
                            setPreviousRecordMark();
                            reloadCyDiagData();
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
                                Form_BXCYFile open = new Form_BXCYFile(selectOnId);
                                open.Show();
                                this.Close();
                            }
                        }
                    }
                }
            }
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

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (textBox_Case_No.Text == "")
            {
                MessageBox.Show("Please input case no.");
                textBox_Case_No.Focus();
                return;
            }

            if (textBox_Case_No.Text.Trim().Substring(textBox_Case_No.Text.Trim().Length - 1, 1).ToLower() != "g")
            {
                MessageBox.Show("Please input Cy-g case no. here");
                textBox_Case_No.Focus();
                return;
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
                            currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                            currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                            textBox_ID.BindingContext[dt].Position++;

                            if (DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
                            {
                                
                                //button_End.PerformClick();

                                if (existCyDiagDataAdapter1 != null && existCyDiagDataSet1 != null && existCyDiagDataAdapter2 != null && existCyDiagDataSet2 != null && existCyDiagDataAdapter3 != null && existCyDiagDataSet3 != null)
                                {
                                    foreach (DataRow dr in existCyDiagDataSet1.Tables[0].Rows)
                                    {
                                        dr["case_no"] = currentCaseNo;
                                        dr["PRINT_BY"] = CurrentUser.currentUserId;
                                        dr["PRINT_AT"] = DateTime.Now.ToString("");
                                    }

                                    foreach (DataRow dr in existCyDiagDataSet2.Tables[0].Rows)
                                    {
                                        dr["case_no"] = currentCaseNo;
                                        dr["PRINT_BY"] = CurrentUser.currentUserId;
                                        dr["PRINT_AT"] = DateTime.Now.ToString("");
                                    }

                                    foreach (DataRow dr in existCyDiagDataSet3.Tables[0].Rows)
                                    {
                                        dr["case_no"] = currentCaseNo;
                                        dr["PRINT_BY"] = CurrentUser.currentUserId;
                                        dr["PRINT_AT"] = DateTime.Now.ToString("");
                                    }

                                    bool result1 = DBConn.updateObject(existCyDiagDataAdapter1, existCyDiagDataSet1, "cy_diag1");
                                    bool result2 = DBConn.updateObject(existCyDiagDataAdapter2, existCyDiagDataSet2, "cy_diag2");
                                    bool result3 = DBConn.updateObject(existCyDiagDataAdapter3, existCyDiagDataSet3, "cy_diag3");

                                    if (result1 || result2 || result3)
                                    {
                                        MessageBox.Show("New case is saved");
                                    }
                                    else
                                    {
                                        MessageBox.Show("New case is saved, New cy diag save fail or no need to save");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("New case is saved");
                                }

                                this.existCyDiagDataAdapter1 = null;
                                this.existCyDiagDataSet1 = null;

                                this.existCyDiagDataAdapter2 = null;
                                this.existCyDiagDataSet2 = null;

                                this.existCyDiagDataAdapter3 = null;
                                this.existCyDiagDataSet3 = null;

                                reloadAndBindingDBData(0, currentCaseNo);
                            }
                            else
                            {
                                MessageBox.Show("Bxcy_specimen saved fail, please contact Admin");
                            }
                            setButtonStatus(PageStatus.STATUS_VIEW);
                        }
                    }
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
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
                            //drow["UPDATE_BY"] = CurrentUser.currentUserId;
                            drow["UPDATE_BY"] = CurrentUser.currentUserId;
                            drow["UPDATE_AT"] = DateTime.Now.ToString("");
                            textBox_ID.BindingContext[dt].Position++;

                            bool bxcyUpdateResult = DBConn.updateObject(dataAdapter, bxcy_specimenDataSet, "bxcy_specimen");
                            bool diagUpdateResult = false;

                            if (existCyDiagDataAdapter1 != null && existCyDiagDataSet1 != null && existCyDiagDataAdapter2 != null && existCyDiagDataSet2 != null && existCyDiagDataAdapter3 != null && existCyDiagDataSet3 != null)
                            {
                                foreach (DataRow dr in existCyDiagDataSet1.Tables[0].Rows)
                                {
                                    dr["case_no"] = currentCaseNo;
                                    dr["PRINT_BY"] = CurrentUser.currentUserId;
                                    dr["PRINT_AT"] = DateTime.Now.ToString("");
                                }

                                foreach (DataRow dr in existCyDiagDataSet2.Tables[0].Rows)
                                {
                                    dr["case_no"] = currentCaseNo;
                                    dr["PRINT_BY"] = CurrentUser.currentUserId;
                                    dr["PRINT_AT"] = DateTime.Now.ToString("");
                                }

                                foreach (DataRow dr in existCyDiagDataSet3.Tables[0].Rows)
                                {
                                    dr["case_no"] = currentCaseNo;
                                    dr["PRINT_BY"] = CurrentUser.currentUserId;
                                    dr["PRINT_AT"] = DateTime.Now.ToString("");
                                }

                                bool result1 = DBConn.updateObject(existCyDiagDataAdapter1, existCyDiagDataSet1, "cy_diag1");
                                bool result2 = DBConn.updateObject(existCyDiagDataAdapter2, existCyDiagDataSet2, "cy_diag2");
                                bool result3 = DBConn.updateObject(existCyDiagDataAdapter3, existCyDiagDataSet3, "cy_diag3");

                                if (result1 || result2 || result3)
                                {
                                    diagUpdateResult = true;
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

                            this.existCyDiagDataAdapter1 = null;
                            this.existCyDiagDataSet1 = null;

                            this.existCyDiagDataAdapter2 = null;
                            this.existCyDiagDataSet2 = null;

                            this.existCyDiagDataAdapter3 = null;
                            this.existCyDiagDataSet3 = null;

                            setButtonStatus(PageStatus.STATUS_VIEW);
                            reloadAndBindingDBData(0, currentCaseNo);
                        }
                    }
                }
            }
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

        public void processEdit()
        {
            button_Edit.PerformClick();
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
            currentEditRow["INV_DATE"] = DateTime.Now;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existCyDiagDataSet1 = null;
            existCyDiagDataAdapter1 = null;

            existCyDiagDataSet2 = null;
            existCyDiagDataAdapter2 = null;

            existCyDiagDataSet3 = null;
            existCyDiagDataAdapter3 = null;
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

            existCyDiagDataSet1 = null;
            existCyDiagDataAdapter1 = null;

            existCyDiagDataSet2 = null;
            existCyDiagDataAdapter2 = null;

            existCyDiagDataSet3 = null;
            existCyDiagDataAdapter3 = null;
        }

        public void patientCopy(string caseNo)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";
            currentEditRow["CLIENT"] = Form_BXCYFile.DEFAULT_CLIENT;
            currentEditRow["Institute"] = Form_BXCYFile.DEFAULT_INSTITUTE;

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;

            currentEditRow["date"] = DateTime.Now;
            currentEditRow["INV_DATE"] = DateTime.Now;

            currentEditRow["Cyto_Type"] = "G";

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
                if (mDr["PAT_BIRTH"] != null)
                {
                    DateTime dob = (DateTime)mDr["PAT_BIRTH"];
                    Double age = PatientAgeCalculator.calculate(dob);
                    if (age != Double.NaN)
                    {
                        currentEditRow["PAT_AGE"] = age;
                    }
                }
                currentEditRow["PAT_SEX"] = mDr["PAT_SEX"];
                currentEditRow["PAT_HKID"] = mDr["PAT_HKID"];
            }

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existCyDiagDataSet1 = null;
            existCyDiagDataAdapter1 = null;

            existCyDiagDataSet2 = null;
            existCyDiagDataAdapter2 = null;

            existCyDiagDataSet3 = null;
            existCyDiagDataAdapter3 = null;
        }

        public void patientCopyWithPatientInfo(string patientNo, string patientHKID, string patientName)
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

            string sql = string.Format("SELECT TOP 1 * FROM [bxcy_specimen] WHERE pat_hkid = '{0}' AND patient = '{1}'", patientHKID, patientName);
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

            existCyDiagDataSet1 = null;
            existCyDiagDataAdapter1 = null;

            existCyDiagDataSet2 = null;
            existCyDiagDataAdapter2 = null;

            existCyDiagDataSet3 = null;
            existCyDiagDataAdapter3 = null;
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = bxcy_specimenDataSet.Tables["bxcy_specimen"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["Pat_age"] = 0;
            currentEditRow["Pat_sex"] = "M";

            currentEditRow["fz_section"] = 0;
            currentEditRow["uploaded"] = 0;
            currentEditRow["supp"] = 0;

            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Clear();
            bxcy_specimenDataSet.Tables["bxcy_specimen"].Rows.Add(currentEditRow);

            existCyDiagDataSet1 = null;
            existCyDiagDataAdapter1 = null;

            existCyDiagDataSet2 = null;
            existCyDiagDataAdapter2 = null;

            existCyDiagDataSet3 = null;
            existCyDiagDataAdapter3 = null;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
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
            //copybxcy_specimen.class1 = comboBox_Class.Text;
            copybxcy_specimen.pat_age = textBox_Age.Text;
            copybxcy_specimen.pat_sex = textBox_Sex.Text;
            copybxcy_specimen.bed_room = textBox_Room.Text;
            copybxcy_specimen.bed_no = textBox_Bed.Text;
            copybxcy_specimen.clinical_History = textBox_Patient_s_Clinical_History.Text;

            //copybxcy_specimen.surgical = textBox_Surgical.Text;
            copybxcy_specimen.nature = textBox_Nature.Text;

            copybxcy_specimen.client = textBox_Client.Text;
            copybxcy_specimen.institute = textBox_Institute.Text;
            copybxcy_specimen.lab_ref = textBox_Ref_No.Text;
            //copybxcy_specimen.doctor_o = textBox_Dr_I_C_Free_Text.Text;

            copybxcy_specimen.doctor_ic = textBox_Doctor_I_C.Text;
            copybxcy_specimen.doctor_id = textBox_Doctor_I_C_ID_1.Text;

            copybxcy_specimen.doctor_id2 = textBox_Doctor_I_C_2.Text;
            /*copybxcy_specimen.doctor_id2 = textBox_Doctor_I_C_ID_2.Text;

            copybxcy_specimen.doctor_id3 = textBox_Doctor_I_C_3.Text;
            copybxcy_specimen.doctor_id3 = textBox_Doctor_I_C_ID_3.Text;*/

            copybxcy_specimen.inv_no = textBox_Involce_No.Text;
            //copybxcy_specimen.receipt = textBox_Receipt.Text;
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
            //copybxcy_specimen.histo = comboBox_HistoType.Text;

            copybxcy_specimen.uploaded = checkBox_Uploaded.Checked;

            copybxcy_specimen.remark = textBox_Remarks.Text;
            copybxcy_specimen.initial = textBox_Cytology.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

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

            if (keyData == (Keys)Shortcut.F4 && button_F4_Nature.Enabled)
            {
                button_F4_Nature.PerformClick();
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
            }*/

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (textBox_Patient_s_Clinical_History.Focused || textBox_Remarks.Focused)
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

        /*private void jumpReverse()
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
                if (textBox_Age.Focused)
                {
                    textBox_DOB.Focus();
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

            // second part 

            if (notJumped)
            {
                if (textBox_Client.Focused)
                {
                    textBox_Bed.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Ref_No.Focused)
                {
                    textBox_Client.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Institute.Focused)
                {
                    textBox_Ref_No.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Remind.Focused)
                {
                    textBox_Institute.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C.Focused)
                {
                    textBox_Remind.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C_ID_1.Focused)
                {
                    textBox_Doctor_I_C.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C_2.Focused)
                {
                    textBox_Doctor_I_C_ID_1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Involce_No.Focused)
                {
                    textBox_Doctor_I_C_2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Ref_No_2.Focused)
                {
                    textBox_Involce_No.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Invoice_Date.Focused)
                {
                    textBox_Ref_No_2.Focus();
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
                if (comboBox_Sign_By_Dr_3.Focused)
                {
                    comboBox_Sign_By_Dr_2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Remarks.Focused)
                {
                    comboBox_Sign_By_Dr_3.Focus();
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

            // second part 

            if (notJumped)
            {
                if (textBox_Bed.Focused)
                {
                    textBox_Client.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Client.Focused)
                {
                    textBox_Ref_No.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Ref_No.Focused)
                {
                    textBox_Institute.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Institute.Focused)
                {
                    textBox_Remind.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Remind.Focused)
                {
                    textBox_Doctor_I_C.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C.Focused)
                {
                    textBox_Doctor_I_C_ID_1.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C_ID_1.Focused)
                {
                    textBox_Doctor_I_C_2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Doctor_I_C_2.Focused)
                {
                    textBox_Involce_No.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Involce_No.Focused)
                {
                    textBox_Ref_No_2.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (textBox_Ref_No_2.Focused)
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
                    comboBox_Sign_By_Dr_3.Focus();
                    notJumped = false;
                }
            }

            if (notJumped)
            {
                if (comboBox_Sign_By_Dr_3.Focused)
                {
                    textBox_Remarks.Focus();
                    notJumped = false;
                }
            }
        }*/

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
                copybxcy_specimen.date = textBox_Date.Text;
                copybxcy_specimen.ethnic = comboBox_Ethnic.Text;
                copybxcy_specimen.cyto_Type = comboBox_cytoType.Text;
                copybxcy_specimen.patient = textBox_Patient.Text;
                copybxcy_specimen.pat_seq = textBox_PatSeq.Text;
                copybxcy_specimen.cname = textBox_Chinese_Name.Text;
                copybxcy_specimen.pat_hkid = textBox_HKID.Text;
                copybxcy_specimen.pat_birth = textBox_DOB.Text;
                //copybxcy_specimen.class1 = comboBox_Class.Text;
                copybxcy_specimen.pat_age = textBox_Age.Text;
                copybxcy_specimen.pat_sex = textBox_Sex.Text;
                copybxcy_specimen.bed_room = textBox_Room.Text;
                copybxcy_specimen.bed_no = textBox_Bed.Text;
                copybxcy_specimen.clinical_History = textBox_Patient_s_Clinical_History.Text;

                //copybxcy_specimen.surgical = textBox_Surgical.Text;
                copybxcy_specimen.nature = textBox_Nature.Text;

                copybxcy_specimen.client = textBox_Client.Text;
                copybxcy_specimen.institute = textBox_Institute.Text;
                copybxcy_specimen.lab_ref = textBox_Ref_No.Text;
                //copybxcy_specimen.doctor_o = textBox_Dr_I_C_Free_Text.Text;

                copybxcy_specimen.doctor_ic = textBox_Doctor_I_C.Text;
                copybxcy_specimen.doctor_id = textBox_Doctor_I_C_ID_1.Text;

                copybxcy_specimen.doctor_id2 = textBox_Doctor_I_C_2.Text;
                /*copybxcy_specimen.doctor_id2 = textBox_Doctor_I_C_ID_2.Text;

                copybxcy_specimen.doctor_id3 = textBox_Doctor_I_C_3.Text;
                copybxcy_specimen.doctor_id3 = textBox_Doctor_I_C_ID_3.Text;*/

                copybxcy_specimen.inv_no = textBox_Involce_No.Text;
                //copybxcy_specimen.receipt = textBox_Receipt.Text;
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
                //copybxcy_specimen.histo = comboBox_HistoType.Text;

                copybxcy_specimen.uploaded = checkBox_Uploaded.Checked;

                copybxcy_specimen.remark = textBox_Remarks.Text;
                copybxcy_specimen.initial = textBox_Cytology.Text;

                setButtonStatus(PageStatus.STATUS_ADVANCE_EDIT);
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM BXCY_SPECIMEN WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    existCyDiagDataSet1 = null;
                    existCyDiagDataAdapter1 = null;

                    existCyDiagDataSet2 = null;
                    existCyDiagDataAdapter2 = null;

                    existCyDiagDataSet3 = null;
                    existCyDiagDataAdapter3 = null;
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
                        textBox_Date.Text = copybxcy_specimen.date;
                        comboBox_Ethnic.Text = copybxcy_specimen.ethnic;
                        comboBox_cytoType.Text = copybxcy_specimen.cyto_Type;
                        textBox_Patient.Text = copybxcy_specimen.patient;
                        textBox_PatSeq.Text = copybxcy_specimen.pat_seq;
                        textBox_Chinese_Name.Text = copybxcy_specimen.cname;
                        textBox_HKID.Text = copybxcy_specimen.pat_hkid;
                        textBox_DOB.Text = copybxcy_specimen.pat_birth;
                        //comboBox_Class.Text = copybxcy_specimen.class1;
                        textBox_Age.Text = copybxcy_specimen.pat_age;
                        textBox_Sex.Text = copybxcy_specimen.pat_sex;
                        textBox_Room.Text = copybxcy_specimen.bed_room;
                        textBox_Bed.Text = copybxcy_specimen.bed_no;
                        textBox_Patient_s_Clinical_History.Text = copybxcy_specimen.clinical_History;

                        //textBox_Surgical.Text = copybxcy_specimen.surgical;
                        textBox_Nature.Text = copybxcy_specimen.nature;

                        textBox_Client.Text = copybxcy_specimen.client;
                        textBox_Institute.Text = copybxcy_specimen.institute;
                        textBox_Ref_No.Text = copybxcy_specimen.lab_ref;
                        //textBox_Dr_I_C_Free_Text.Text = copybxcy_specimen.doctor_o;

                        textBox_Doctor_I_C.Text = copybxcy_specimen.doctor_ic;
                        textBox_Doctor_I_C_ID_1.Text = copybxcy_specimen.doctor_id;

                        textBox_Doctor_I_C_2.Text = copybxcy_specimen.doctor_id2;
                        /*textBox_Doctor_I_C_ID_2.Text = copybxcy_specimen.doctor_id2;

                        textBox_Doctor_I_C_3.Text = copybxcy_specimen.doctor_id3;
                        textBox_Doctor_I_C_ID_3.Text = copybxcy_specimen.doctor_id3;*/

                        textBox_Involce_No.Text = copybxcy_specimen.inv_no;
                        //textBox_Receipt.Text = copybxcy_specimen.receipt;
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
                        //comboBox_HistoType.Text = copybxcy_specimen.histo;

                        textBox_Remarks.Text = copybxcy_specimen.remark;
                        textBox_Cytology.Text = copybxcy_specimen.initial;

                        checkBox_Uploaded.Checked = copybxcy_specimen.uploaded.HasValue ? copybxcy_specimen.uploaded.HasValue : false;
                    }
                    reloadCyDiagData();
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_Label_Click(object sender, EventArgs e)
        {

        }

        private void Form_CYTOLOGYFileGyname_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void reloadAndBindingDBData(int position = 0, string caseNo = null)
        {
            string sql = "SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no LIKE '%G' ORDER BY case_no,id";
            if (this.id != null)
            {
                sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE id={0} AND case_no LIKE '%G' ORDER BY  case_no,id", this.id);
                id = null;
            }
            else
            {
                if (caseNo != null)
                {
                    sql = string.Format("SELECT TOP 1 *,(CASE WHEN PAY_DATE IS NULL THEN 'No' ELSE 'Yes' END) AS PAY_UP FROM [bxcy_specimen] WHERE case_no='{0}' AND case_no LIKE '%G' ORDER BY  case_no,id", caseNo);
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
            //comboBox_Class.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            textBox_Room.DataBindings.Clear();
            textBox_Bed.DataBindings.Clear();
            textBox_Patient_s_Clinical_History.DataBindings.Clear();

            //textBox_Surgical.DataBindings.Clear();
            textBox_Nature.DataBindings.Clear();

            textBox_Client.DataBindings.Clear();
            textBox_Institute.DataBindings.Clear();
            textBox_Ref_No.DataBindings.Clear();
            //textBox_Dr_I_C_Free_Text.DataBindings.Clear();
            textBox_Doctor_I_C.DataBindings.Clear();
            textBox_Doctor_I_C_ID_1.DataBindings.Clear();
            textBox_Doctor_I_C_2.DataBindings.Clear();
            /*textBox_Doctor_I_C_ID_2.DataBindings.Clear();
            textBox_Doctor_I_C_3.DataBindings.Clear();
            textBox_Doctor_I_C_ID_3.DataBindings.Clear();*/

            textBox_Involce_No.DataBindings.Clear();
            //textBox_Receipt.DataBindings.Clear();
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
            //comboBox_HistoType.DataBindings.Clear();

            textBox_Remarks.DataBindings.Clear();
            textBox_Cytology.DataBindings.Clear();

            textBox_Updated_By_1.DataBindings.Clear();
            textBox_Updated_At.DataBindings.Clear();
            textBox_Issued_By.DataBindings.Clear();
            textBox_Issued_At.DataBindings.Clear();

            label_Printed.DataBindings.Clear();

            checkBox_Uploaded.DataBindings.Clear();

            /*label_Uploaded_At.DataBindings.Clear();
            label_Uploaded_By.DataBindings.Clear();*/
            label_Version.DataBindings.Clear();

            label_Print_At.DataBindings.Clear();
            label_Print_By.DataBindings.Clear();
            //textBox_Rpt_Date.DataBindings.Clear();

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

            /*string doctorSql1 = "SELECT doctor FROM [sign_doctor] order by doctor";
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

            comboBox_Sign_By_Dr_2.DataSource = doctorDt2;*/

            String screenerSql = "select user_name as doctor from [user] where SCREENER1 = 'T' order by user_name";
            DataSet screenerDataSet1 = new DataSet();
            SqlDataAdapter screenerDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(screenerSql, screenerDataSet1, "user");

            DataTable doctorDt1 = new DataTable();
            doctorDt1.Columns.Add("doctor");
            DataTable doctorDt2 = doctorDt1.Clone();

            doctorDt1.Rows.Add(new object[] { "" });
            doctorDt2.Rows.Add(new object[] { "" });
            foreach (DataRow mDr in screenerDataSet1.Tables["user"].Rows)
            {
                doctorDt1.Rows.Add(new object[] { mDr["doctor"] });
                doctorDt2.Rows.Add(new object[] { mDr["doctor"] });
            }
            comboBox_Sign_By_Dr_1.DataSource = doctorDt1;
            comboBox_Sign_By_Dr_2.DataSource = doctorDt2;

            string doctorSql3 = "SELECT doctor FROM [sign_doctor] order by doctor";
            doctorDataSet3 = new DataSet();
            doctorDataAdapter3 = DBConn.fetchDataIntoDataSetSelectOnly(doctorSql3, doctorDataSet3, "sign_doctor");

            DataTable doctorDt3 = new DataTable();
            doctorDt3.Columns.Add("doctor");

            doctorDt3.Rows.Add(new object[] { "" });
            foreach (DataRow mDr in doctorDataSet3.Tables["sign_doctor"].Rows)
            {
                doctorDt3.Rows.Add(new object[] { mDr["doctor"] });
            }

            comboBox_Sign_By_Dr_3.DataSource = doctorDt3;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Case_No.DataBindings.Add("Text", dt, "CASE_NO", false);
            textBox_Date.DataBindings.Add("Text", dt, "DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", DateUtil.FORMAT_DEFAULT_DATE);
            comboBox_Ethnic.DataBindings.Add("SelectedValue", dt, "ETHNIC", false);
            comboBox_cytoType.DataBindings.Add("SelectedValue", dt, "Cyto_Type", false);
            textBox_Patient.DataBindings.Add("Text", dt, "PATIENT", false);
            textBox_PatSeq.DataBindings.Add("Text", dt, "PAT_SEQ", false);
            textBox_Chinese_Name.DataBindings.Add("Text", dt, "CNAME", false);
            textBox_HKID.DataBindings.Add("Text", dt, "PAT_HKID", false);

            textBox_DOB.DataBindings.Add("Text", dt, "PAT_BIRTH", true, DataSourceUpdateMode.OnPropertyChanged, "", DateUtil.FORMAT_DEFAULT_DATE);

            //comboBox_Class.DataBindings.Add("SelectedValue", dt, "Class", false);
            textBox_Age.DataBindings.Add("Text", dt, "PAT_AGE", false);
            textBox_Sex.DataBindings.Add("Text", dt, "PAT_SEX", false);
            textBox_Room.DataBindings.Add("Text", dt, "BED_ROOM", false);
            textBox_Bed.DataBindings.Add("Text", dt, "BED_NO", false);
            textBox_Patient_s_Clinical_History.DataBindings.Add("Text", dt, "Clinical_History", false);

            //textBox_Surgical.DataBindings.Add("Text", dt, "surgical", false, DataSourceUpdateMode.OnPropertyChanged, "");
            textBox_Nature.DataBindings.Add("Text", dt, "nature", false, DataSourceUpdateMode.OnPropertyChanged, "");

            textBox_Client.DataBindings.Add("Text", dt, "CLIENT", false);
            textBox_Institute.DataBindings.Add("Text", dt, "Institute", false);
            textBox_Ref_No.DataBindings.Add("Text", dt, "LAB_REF", false);
            //textBox_Dr_I_C_Free_Text.DataBindings.Add("Text", dt, "DOCTOR_O", false);

            textBox_Doctor_I_C.DataBindings.Add("Text", dt, "DOCTOR_IC", false);
            textBox_Doctor_I_C_ID_1.DataBindings.Add("Text", dt, "doctor_id", false);

            textBox_Doctor_I_C_2.DataBindings.Add("Text", dt, "doctor_id2", false);
            //textBox_Doctor_I_C_ID_2.DataBindings.Add("Text", dt, "doctor_id2", false);

            /*textBox_Doctor_I_C_3.DataBindings.Add("Text", dt, "doctor_id3", false);
            textBox_Doctor_I_C_ID_3.DataBindings.Add("Text", dt, "doctor_id3", false);*/

            textBox_Involce_No.DataBindings.Add("Text", dt, "Inv_no", false);
            //textBox_Receipt.DataBindings.Add("Text", dt, "RECEIPT", false);
            textBox_Invoice_Date.DataBindings.Add("Text", dt, "INV_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", DateUtil.FORMAT_DEFAULT_DATE);
            textBox_Amount_HK.DataBindings.Add("Text", dt, "INV_AMT", false);
            textBox_Paid_Up.DataBindings.Add("Text", dt, "PAY_UP", false);
            textBox_Paid_Date.DataBindings.Add("Text", dt, "PAY_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", DateUtil.FORMAT_DEFAULT_DATE);

            textBox_Rpt_Date.DataBindings.Add("Text", dt, "Rpt_date", false, DataSourceUpdateMode.Never, DateTime.Now.ToString(DateUtil.FORMAT_DEFAULT_DATE_TIME), DateUtil.FORMAT_DEFAULT_DATE_TIME, System.Globalization.CultureInfo.InvariantCulture);
            comboBox_Snop_T1.DataBindings.Add("SelectedValue", dt, "snopcode_t", false);
            comboBox_Snop_T2.DataBindings.Add("SelectedValue", dt, "snopcode_t2", false);
            comboBox_Snop_T3.DataBindings.Add("SelectedValue", dt, "snopcode_t3", false);
            comboBox_Sign_By_Dr_1.DataBindings.Add("Text", dt, "Sign_dr", false);
            comboBox_Snop_M1.DataBindings.Add("SelectedValue", dt, "Snopcode_m", false);
            comboBox_Snop_M2.DataBindings.Add("SelectedValue", dt, "Snopcode_m2", false);
            comboBox_Snop_M3.DataBindings.Add("SelectedValue", dt, "Snopcode_m3", false);
            comboBox_Sign_By_Dr_2.DataBindings.Add("Text", dt, "Sign_dr2", false);
            //comboBox_HistoType.DataBindings.Add("SelectedValue", dt, "Histo", false);

            textBox_Remarks.DataBindings.Add("Text", dt, "Remark", false);
            textBox_Cytology.DataBindings.Add("Text", dt, "initial", false);

            textBox_Updated_By_1.DataBindings.Add("Text", dt, "update_by", false);
            textBox_Updated_At.DataBindings.Add("Text", dt, "update_at", true, DataSourceUpdateMode.OnPropertyChanged, "", DateUtil.FORMAT_DEFAULT_DATE);
            textBox_Issued_By.DataBindings.Add("Text", dt, "issue_by", false);
            textBox_Issued_At.DataBindings.Add("Text", dt, "issue_at", true, DataSourceUpdateMode.OnPropertyChanged, "", DateUtil.FORMAT_DEFAULT_DATE);
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

            reloadCyDiagData();
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
                button_F8.Enabled = false;
                button_F9.Enabled = false;
                //button_F3_Surgical.Enabled = true;
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
                //comboBox_Class.Enabled = false;
                textBox_Age.Enabled = false;
                textBox_Sex.Enabled = false;
                textBox_Room.Enabled = false;
                textBox_Bed.Enabled = false;
                textBox_Patient_s_Clinical_History.Enabled = false;

                textBox_Client.Enabled = false;
                textBox_Institute.Enabled = false;
                textBox_Ref_No.Enabled = false;
                //textBox_Dr_I_C_Free_Text.Enabled = false;
                textBox_Doctor_I_C.Enabled = false;
                textBox_Doctor_I_C_ID_1.Enabled = false;
                textBox_Doctor_I_C_2.Enabled = false;
                /*textBox_Doctor_I_C_ID_2.Enabled = false;
                textBox_Doctor_I_C_3.Enabled = false;
                textBox_Doctor_I_C_ID_3.Enabled = false;*/

                textBox_Involce_No.Enabled = false;
                //textBox_Receipt.Enabled = false;
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
                comboBox_Sign_By_Dr_3.Enabled = false;
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
                    button_F8.Enabled = true;
                    button_F9.Enabled = true;
                    //button_F3_Surgical.Enabled = true;
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
                    //comboBox_Class.Enabled = true;
                    textBox_Age.Enabled = true;
                    textBox_Sex.Enabled = true;
                    textBox_Room.Enabled = true;
                    textBox_Bed.Enabled = true;
                    textBox_Patient_s_Clinical_History.Enabled = true;

                    textBox_Client.Enabled = true;
                    textBox_Institute.Enabled = true;
                    textBox_Ref_No.Enabled = true;
                    //textBox_Dr_I_C_Free_Text.Enabled = true;
                    textBox_Doctor_I_C.Enabled = true;
                    textBox_Doctor_I_C_ID_1.Enabled = true;
                    textBox_Doctor_I_C_2.Enabled = true;
                    /*textBox_Doctor_I_C_ID_2.Enabled = true;
                    textBox_Doctor_I_C_3.Enabled = true;
                    textBox_Doctor_I_C_ID_3.Enabled = true;*/

                    textBox_Involce_No.Enabled = true;
                    //textBox_Receipt.Enabled = true;
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
                    comboBox_Sign_By_Dr_3.Enabled = true;
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
                        button_F8.Enabled = false;
                        button_F9.Enabled = false;
                        //button_F3_Surgical.Enabled = true;
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
                        //comboBox_Class.Enabled = true;
                        textBox_Age.Enabled = true;
                        textBox_Sex.Enabled = true;
                        textBox_Room.Enabled = true;
                        textBox_Bed.Enabled = true;
                        textBox_Patient_s_Clinical_History.Enabled = true;

                        textBox_Client.Enabled = true;
                        textBox_Institute.Enabled = true;
                        textBox_Ref_No.Enabled = true;
                        //textBox_Dr_I_C_Free_Text.Enabled = true;
                        textBox_Doctor_I_C.Enabled = true;
                        textBox_Doctor_I_C_ID_1.Enabled = true;
                        textBox_Doctor_I_C_2.Enabled = true;
                        /*textBox_Doctor_I_C_ID_2.Enabled = true;
                        textBox_Doctor_I_C_3.Enabled = true;
                        textBox_Doctor_I_C_ID_3.Enabled = true;*/

                        textBox_Involce_No.Enabled = true;
                        //textBox_Receipt.Enabled = true;
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
                        comboBox_Sign_By_Dr_3.Enabled = true;
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
                        button_Advance.Enabled = true;

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
                            button_F8.Enabled = true;
                            button_F9.Enabled = true;
                            //button_F3_Surgical.Enabled = true;
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
                            //comboBox_Class.Enabled = true;
                            textBox_Age.Enabled = true;
                            textBox_Sex.Enabled = true;
                            textBox_Room.Enabled = true;
                            textBox_Bed.Enabled = true;
                            textBox_Patient_s_Clinical_History.Enabled = true;

                            textBox_Client.Enabled = true;
                            textBox_Institute.Enabled = true;
                            textBox_Ref_No.Enabled = true;
                            //textBox_Dr_I_C_Free_Text.Enabled = true;
                            textBox_Doctor_I_C.Enabled = true;
                            textBox_Doctor_I_C_ID_1.Enabled = true;
                            textBox_Doctor_I_C_2.Enabled = true;
                            /*textBox_Doctor_I_C_ID_2.Enabled = true;
                            textBox_Doctor_I_C_3.Enabled = true;
                            textBox_Doctor_I_C_ID_3.Enabled = true;*/

                            textBox_Involce_No.Enabled = true;
                            //textBox_Receipt.Enabled = true;
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
                            comboBox_Sign_By_Dr_3.Enabled = true;
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
                            //button_ad
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
                        textBox_DOB.Text = recordDate.ToString(DateUtil.FORMAT_DEFAULT_DATE);
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
            //open.OnBxcySpecimentSelectedSingle += OnBxcySpecimentSelected;
            open.Show();
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
            Form_SelectClientInstitute open = new Form_SelectClientInstitute();
            open.OnClientInstituteSelectedSingle += OnClientInstituteSelected;
            open.Show();
        }

        private void OnClientInstituteSelected(string str)
        {
            if (str != null)
            {
                textBox_Institute.Text = str;
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

        private void button_Play_Click(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C.Text != "")
            {
                if (textBox_Doctor_I_C_2.Text != "")
                {
                    /*if (textBox_Doctor_I_C_3.Text != "")
                    {
                        Shif_3_4();
                    }*/
                    Shif_2_3();
                }
                Shif_1_2();
            }
        }

        private void Shif_1_2()
        {
            textBox_Doctor_I_C_2.Text = textBox_Doctor_I_C.Text;
            //textBox_Doctor_I_C_ID_2.Text = textBox_Doctor_I_C_ID_1.Text;
            textBox_Doctor_I_C.Text = "";
            textBox_Doctor_I_C_ID_1.Text = "";
        }
        private void Shif_2_3()
        {
            /*textBox_Doctor_I_C_3.Text = textBox_Doctor_I_C_2.Text;
            textBox_Doctor_I_C_ID_3.Text = textBox_Doctor_I_C_ID_2.Text;
            textBox_Doctor_I_C_2.Text = "";
            textBox_Doctor_I_C_ID_2.Text = "";*/
        }
        private void Shif_3_4()
        {
            /*if (textBox_Doctor_I_C_3.Text != "")
            {
                textBox_Dr_I_C_Free_Text.Text += "\r\n" + textBox_Doctor_I_C_3.Text;
                textBox_Dr_I_C_Free_Text.Text += " (" + textBox_Doctor_I_C_ID_3.Text + ")";
                textBox_Doctor_I_C_3.Text = "";
                textBox_Doctor_I_C_ID_3.Text = "";

            }*/
        }

        private void button_Rpt_Date_Tick_Click(object sender, EventArgs e)
        {
            textBox_Rpt_Date.Text = DateTime.Now.ToString(DateUtil.FORMAT_DEFAULT_DATE_TIME);

            textBox_Rpt_Date.Focus();
            textBox_Rpt_Date.Select(textBox_Rpt_Date.TextLength, 0);
            textBox_Rpt_Date.ScrollToCaret();
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

        private void button_Sign_By_Dr_3_Click(object sender, EventArgs e)
        {
            Form_DoctorsSignatureMaintenance open = new Form_DoctorsSignatureMaintenance();
            open.Show();
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
            if (textBox_Case_No.Text.Trim().ToLower() == "c")
            {
                textBox_Case_No.Text = string.Format("CY{0}-", DateTime.Now.ToString(DateUtil.FORMAT_YEAR).Substring(2));
                textBox_Case_No.Focus();
                textBox_Case_No.SelectionStart = textBox_Case_No.Text.Length;
                textBox_Case_No.SelectionLength = 0;
            }

            
        }

        private void comboBox_Sign_By_Dr_1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering1 = true;
        }

        private void comboBox_Sign_By_Dr_1_TextChanged(object sender, EventArgs e)
        {
            /*if (m_isEntering1)
            {
                m_isEntering1 = false;
                string search = ((ComboBox)sender).Text.Trim();

                string sqlFull = string.Format("SELECT doctor FROM [sign_doctor] WHERE doc_no = '{0}' order by doctor ", search);
                doctorDataAdapter1 = DBConn.fetchDataIntoDataSetSelectOnly(sqlFull, doctorDataSet1, "sign_doctor");

                if (doctorDataSet1.Tables["sign_doctor"].Rows.Count > 0)
                {
                    try
                    {
                        ((ComboBox)sender).SelectedValue = doctorDataSet1.Tables["sign_doctor"].Rows[0]["doctor"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }*/
        }

        private void comboBox_Sign_By_Dr_2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering2 = true;
        }

        private void comboBox_Sign_By_Dr_2_TextChanged(object sender, EventArgs e)
        {
            /*if (m_isEntering2)
            {
                m_isEntering2 = false;
                string search = ((ComboBox)sender).Text.Trim();

                string sqlFull = string.Format("SELECT TOP 1 doctor FROM [sign_doctor] WHERE doc_no = '{0}' order by doctor ", search);
                doctorDataAdapter2 = DBConn.fetchDataIntoDataSetSelectOnly(sqlFull, doctorDataSet2, "sign_doctor");

                if (doctorDataSet2.Tables["sign_doctor"].Rows.Count > 0)
                {
                    try
                    {
                        ((ComboBox)sender).SelectedValue = doctorDataSet2.Tables["sign_doctor"].Rows[0]["doctor"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }*/
        }

        private void comboBox_Sign_By_Dr_3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering3 = true;
        }

        private void comboBox_Sign_By_Dr_3_TextChanged(object sender, EventArgs e)
        {
            if (m_isEntering3)
            {
                m_isEntering3 = false;
                string search = ((ComboBox)sender).Text.Trim();

                string sqlFull = string.Format("SELECT TOP 1 doctor FROM [sign_doctor] WHERE doc_no = '{0}' order by doctor ", search);
                doctorDataAdapter3 = DBConn.fetchDataIntoDataSetSelectOnly(sqlFull, doctorDataSet3, "sign_doctor");

                if (doctorDataSet3.Tables["sign_doctor"].Rows.Count > 0)
                {
                    try
                    {
                        ((ComboBox)sender).SelectedValue = doctorDataSet3.Tables["sign_doctor"].Rows[0]["doctor"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void textBox_Date_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox_DOB_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
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

        private void textBox_Paid_Date_Validating(object sender, CancelEventArgs e)
        {
            if (textBox_Paid_Date.Text == "  /  /")
            {

            }
            else
            {
                DateTime dDate;
                CultureInfo ci = new CultureInfo("en-IE");
                if (textBox_Paid_Date.Text.Length == 10 && DateTime.TryParseExact(textBox_Paid_Date.Text, DateUtil.FORMAT_DEFAULT_DATE, ci, DateTimeStyles.None, out dDate))
                {
                    textBox_Paid_Up.Text = PaymentStatus.PAID_YES;

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void label_BX_CY_SPECIMEN_Click(object sender, EventArgs e)
        {
            if (existCyDiagDataAdapter1 == null)
            {
                Console.WriteLine("Null existCyDiagDataAdapter1");
            }

            if (existCyDiagDataSet1 == null)
            {
                Console.WriteLine("Null existCyDiagDataSet1");
            }

            if (existCyDiagDataAdapter2 == null)
            {
                Console.WriteLine("Null existCyDiagDataAdapter2");
            }

            if (existCyDiagDataSet2 == null)
            {
                Console.WriteLine("Null existCyDiagDataSet2");
            }

            if (existCyDiagDataAdapter3 == null)
            {
                Console.WriteLine("Null existCyDiagDataAdapter3");
            }

            if (existCyDiagDataSet3 == null)
            {
                Console.WriteLine("Null existCyDiagDataSet3");
            }

            if (existCyDiagDataAdapter1 != null && existCyDiagDataSet1 != null)
            {
                var varList = from p in existCyDiagDataSet1.Tables[0].AsEnumerable()
                              orderby p.Field<int>("id") ascending
                              select p;
                foreach (DataRow dr in varList)
                {
                    string rowMessage = string.Format("id:{0}, case no.:{1}", dr["id"], dr["case_no"]);
                    Console.WriteLine(rowMessage);
                }
            }

            if (existCyDiagDataAdapter2 != null && existCyDiagDataSet2 != null)
            {
                var varList = from p in existCyDiagDataSet2.Tables[0].AsEnumerable()
                              orderby p.Field<int>("id") ascending
                              select p;
                foreach (DataRow dr in varList)
                {
                    string rowMessage = string.Format("id:{0}, case no.:{1}", dr["id"], dr["case_no"]);
                    Console.WriteLine(rowMessage);
                }
            }

            if (existCyDiagDataAdapter3 != null && existCyDiagDataSet3 != null)
            {
                var varList = from p in existCyDiagDataSet3.Tables[0].AsEnumerable()
                              orderby p.Field<int>("id") ascending
                              select p;
                foreach (DataRow dr in varList)
                {
                    string rowMessage = string.Format("id:{0}, case no.:{1}", dr["id"], dr["case_no"]);
                    Console.WriteLine(rowMessage);
                }
            }
        }

        private void reloadCyDiagData()
        {
            existCyDiagDataSet1 = null;
            existCyDiagDataAdapter1 = null;

            existCyDiagDataSet2 = null;
            existCyDiagDataAdapter2 = null;

            existCyDiagDataSet3 = null;
            existCyDiagDataAdapter3 = null;
            if (textBox_Case_No.Text.Trim() != "")
            {
                existCyDiagDataSet1 = new DataSet();
                string diagSql1 = string.Format("SELECT * FROM [cy_diag1] WHERE case_no = '{0}'", textBox_Case_No.Text.Trim());
                existCyDiagDataAdapter1 = DBConn.fetchDataIntoDataSet(diagSql1, existCyDiagDataSet1, "cy_diag1");

                existCyDiagDataSet2 = new DataSet();
                string diagSql2 = string.Format("SELECT * FROM [cy_diag2] WHERE case_no = '{0}'", textBox_Case_No.Text.Trim());
                existCyDiagDataAdapter2 = DBConn.fetchDataIntoDataSet(diagSql2, existCyDiagDataSet2, "cy_diag2");

                existCyDiagDataSet3 = new DataSet();
                string diagSql3 = string.Format("SELECT * FROM [cy_diag3] WHERE case_no = '{0}'", textBox_Case_No.Text.Trim());
                existCyDiagDataAdapter3 = DBConn.fetchDataIntoDataSet(diagSql3, existCyDiagDataSet3, "cy_diag3");
            }
        }

		public void setReportWording(String str)
        {
            reportWording = str;
        }

        private void label_Sign_By_Dr_3_Click(object sender, EventArgs e)
        {

        }
    }
}
