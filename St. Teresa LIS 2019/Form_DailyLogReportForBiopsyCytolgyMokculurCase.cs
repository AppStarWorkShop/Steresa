using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace St.Teresa_LIS_2019
{
    public partial class Form_DailyLogReportForBiopsyCytolgyMokculurCase : Form
    {
        public Form_DailyLogReportForBiopsyCytolgyMokculurCase()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "報表文件(*.csv)|*.csv";
                sfd.RestoreDirectory = true;
                sfd.FileName = "report.csv";
                string localFilePath = "c:\\temp\\report.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString();
                    string receiptDateFrom = "";
                    string receiptDateTo = "";
                    string reportDateFrom = "";
                    string reportDateTo = "";
                    string caseNoFrom = "";
                    string caseNoTo = "";

                    if (radioButton_By_Case_Receipt_Date.Checked)
                    {
                        receiptDateFrom = textBox_ReceiptDateFrom.Text.Trim();
                        receiptDateTo = textBox_ReceiptDateTo.Text.Trim();
                    }

                    if (radioButton_By_Case_Report_Date.Checked)
                    {
                        reportDateFrom = textBox_ReportDateFrom.Text.Trim();
                        reportDateTo = textBox_ReportDateTo.Text.Trim();
                    }

                    if (radioButton_By_Case_Number.Checked)
                    {
                        caseNoFrom = textBox_CaseNoFrom.Text.Trim();
                        caseNoTo = textBox_CaseNoTo.Text.Trim();
                    }

                    string group = textBox_Group.Text.Trim();
                    string tCode1 = textBox_T_code_1.Text.Trim();
                    string tCode2 = textBox_T_code_2.Text.Trim();
                    string tCode3 = textBox_T_code_3.Text.Trim();
                    string mCode1 = textBox_M_code_1.Text.Trim();
                    string mCode2 = textBox_M_code_2.Text.Trim();
                    string mCode3 = textBox_M_code_3.Text.Trim();
                    string cytoType = textBox_Cyto_type.Text.Trim();
                    string histoType = textBox_Histo_type.Text.Trim();
                    string frozenSection = "";
                    if (checkBox_Frozen_Section.Checked)
                    {
                        frozenSection = "Y";
                    }
                    else
                    {
                        frozenSection = "N";
                    }
                    string keywordInSite = textBox_Keyword_in_site.Text.Trim();
                    string keywordInOperation = textBox_Keyword_in_operation.Text.Trim();
                    string keywordInDiagnos = textBox_Keyword_in_diagnos.Text.Trim();

                    string checkSql = string.Format("EXEC [sp_searchBXCYSpecimentRecord] '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}'", receiptDateFrom, receiptDateTo, reportDateFrom, reportDateTo, caseNoFrom, caseNoTo, group, tCode1, tCode2, tCode3, mCode1, mCode2, mCode3, cytoType, histoType, frozenSection, keywordInSite, keywordInOperation, keywordInDiagnos);
                    SqlCommand checkCmd = new SqlCommand(checkSql, DBConn.getConnection());
                    checkCmd.CommandTimeout = 600;

                    SqlDataAdapter sdap = new SqlDataAdapter();
                    sdap.SelectCommand = checkCmd;

                    DataTable dt = new DataTable();
                    sdap.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("gb2312"));
                        sw.WriteLine("case no,barcode");

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            DataRow item = dt.Rows[j];
                            string rowValue = "";
                            rowValue += item["case_no"] + "," + item["barcode"] + "," + item["ver"] + "," + item["date"] + "," + item["rpt_date"] + "," + item["sign_dr"] + "," + item["sign_dr2"] + "," + item["client"] + "," + item["institute"] + "," + item["doctor_id"] + "," + item["doctor_ic"] + "," + item["doctor_o"] + "," + item["lab_ref"] + "," + item["ethnic"] + "," + item["patient"] + "," + item["cname"] + "," + item["pat_seq"] + "," + item["pat_birth"] + "," + item["pat_age"] + "," + item["pat_sex"] + "," + item["pat_hkid"] + "," + item["bed_room"] + "," + item["bed_no"] + "," + item["discharge"] + "," + item["receipt"] + "," + item["inv_no"] + "," + item["inv_amt"] + "," + item["inv_date"] + "," + item["pay_date"] + "," + item["fz_section"] + "," + item["fz_detail"] + "," + item["cy_type"] + "," + item["cy_report"] + "," + item["snopcode_t"] + "," + item["desc_t"] + "," + item["snopcode_m"] + "," + item["desc_m"] + "," + item["er"] + "," + item["em"] + "," + item["remind"] + "," + item["initial"] + "," + item["priv_case"] + "," + item["supp"] + "," + item["mt"] + "," + item["print_by"] + "," + item["print_at"] + "," + item["print_ctr"] + "," + item["issue_by"] + "," + item["issue_at"] + "," + item["update_by"] + "," + item["update_at"] + "," + item["update_ctr"] + "," + item["updated"] + "," + item["uploaded"];
                            //rowValue += item["shopName"] + "," + item["orderDatetime"] + "," + item["productCode"] + "," + item["productName"] + "," + item["isConsignment"] + "," + item["categoryCode"] + "," + item["mainCategoryCode"] + "," + item["brandCode"] + "," + item["supplierCode"] + "," + item["extRefCode"] + "," + item["orderDatetime"] + "," + item["receiptCode"] + "," + item["noOfItem"] + "," + item["productCost"] + "," + item["stockCostValue"] + "," + item["itemAmountOrg"] + "," + item["itemAmountReal"] + "," + item["totalAmountReal"] + "," + item["stockInDatetime"] + "," + item["stockInCode"] + "," + item["tripName"];
                            //rowValue += "," + item["travelAgencyCode"] + "," + item["tourGuideCode"] + "," + item["tourGuideTel"] + "," + item["arrivalTime"] + "," + item["departureTime"] + "," + item["passportId"] + "," + item["tourguideGroup"] + "," + item["staffCode"] + "," + item["discountRate"] + "," + item["buyingMode"] + "," + item["productCommC1Rate"] + "," + item["productCommTourguideRate"] + "," + item["productCommEscortRate"] + "," + item["productCommC1Bonus"] + "," + item["productCommTourguideBonus"] + "," + item["productCommEscortBonus"] + "," + item["categoryCommC1Rate"] + "," + item["categoryCommTourguideRate"] + "," + item["categoryCommEscortRate"];
                            //rowValue += "," + item["categoryCommC1Bonus"] + "," + item["categoryCommTourguideBonus"] + "," + item["categoryCommEscortBonus"] + "," + item["mainCategoryCommC1Rate"] + "," + item["mainCategoryCommTourguideRate"] + "," + item["mainCategoryCommEscortRate"] + "," + item["mainCategoryCommC1Bonus"] + "," + item["mainCategoryCommTourguideBonus"] + "," + item["mainCategoryCommEscortBonus"] + "," + item["itemAmountReal"] + "," + item["totalAmountReal"] + "," + item["commC1Real"] + "," + item["commTourGuideReal"] + "," + item["commEscortReal"] + "," + item["totalItemCommReal"] + "," + item["totalCommReal"] + "," + item["mappingCommRateC1"] + "," + item["mappingCommRateTourGuide"] + "," + item["mappingCommRateEscort"] + "," + item["remark"] + "," + item["mappingCommType"] + "," + item["mappingCommEffectDate"];
                            
                            sw.WriteLine(rowValue);
                        }

                        //sw.WriteLine(",,,,,,,,,,,Sub-total:," + SubNoOfItem.ToString() + ",," + subStockCostValue.ToString() + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,," + subTotalAmountReal.ToString() + "," + subCommC1Real.ToString() + "," + subCommTourGuideReal.ToString() + "," + subCommEscortReal.ToString() + ",," + subTotalCommReal.ToString());
                        sw.Close();
                        MessageBox.Show("Export done");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void Form_DailyLogReportForBiopsyCytolgyMokculurCase_Load(object sender, EventArgs e)
        {
            radioButton_By_Case_Receipt_Date.Checked = true;
            setFieldStatus();
        }

        private void radioButton_By_Case_Report_Date_CheckedChanged(object sender, EventArgs e)
        {
            setFieldStatus();
        }

        private void radioButton_By_Case_Number_CheckedChanged(object sender, EventArgs e)
        {
            setFieldStatus();
        }

        private void radioButton_By_Case_Receipt_Date_CheckedChanged(object sender, EventArgs e)
        {
            setFieldStatus();
        }

        private void setFieldStatus()
        {
            if (radioButton_By_Case_Receipt_Date.Checked)
            {
                textBox_ReceiptDateFrom.Enabled = true;
                textBox_ReceiptDateTo.Enabled = true;
            }
            else
            {
                textBox_ReceiptDateFrom.Enabled = false;
                textBox_ReceiptDateTo.Enabled = false;
            }

            if (radioButton_By_Case_Report_Date.Checked)
            {
                textBox_ReportDateFrom.Enabled = true;
                textBox_ReportDateTo.Enabled = true;
            }
            else
            {
                textBox_ReportDateFrom.Enabled = false;
                textBox_ReportDateTo.Enabled = false;
            }

            if (radioButton_By_Case_Number.Checked)
            {
                textBox_CaseNoFrom.Enabled = true;
                textBox_CaseNoTo.Enabled = true;
            }
            else
            {
                textBox_CaseNoFrom.Enabled = false;
                textBox_CaseNoTo.Enabled = false;
            }
        }
    }
}
