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
    public partial class Form_UserFileSetup : Form
    {
        private DataSet systemDataSet = new DataSet();
        private DataSet userDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataTable dt;
        private int currentStatus;

        public Form_UserFileSetup()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_User_Level_Guidelines_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gudelines For User Security Level Contril :\n " +
                            "\n" +
                            "9 = System Administrator - the MOST powerful uesr who can control the whole system.\n " +
                            "8 = Powerful User - can Add/ Change / Delete all EXCEPT user control setup(here).\n" +
                            "6 = Advanced User - can Add / Change / Delete all date EXCEPT signing of report.\n " +
                            "5 = Stadard User - can Add / Change all non-advanced-edit date EXCEPT Delete right.\n " +
                            "4 = Low-level User - can View/Print reports, change non-sensitive data EXCEPT master files.\n" +
                            "3 = Limited User - can View/Print reports only, but NO Edit right.\n" +
                            "2 = Guest User - can View reports only, but NO Edit right.\n" +
                            "1 = Restricted User - can View reports on screen, but CAN'T print and NO Edit right.\n" +
                            "0 = Non-System User - CAN'T entry system.", "System Security");
        }

        private void button_Invoice_Year_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If You Want To Back Date The Invice Year\n" +
                "\n" +
                "To Last Year, Please Change WINDOW's System Date\n" +
                "\n" +
                "Manually And Then Restart This LIS System.", "Help Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button_Next_Inv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Next New Invoice No. Will Be : "+ DateTime.Now.ToString("yy")+"-"+ textBox_Next_Inv.Text, "Help Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button_Next_Receipt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Next New Receipt No. Will Be : " + "R" + DateTime.Now.ToString("yy") + "-" + textBox_Next_Receipt.Text , "Help Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button_STH_DIA_Amount_Auto_Fill_Setting_Click(object sender, EventArgs e)
        {
            Form_STHDiagnosticAmount open = new Form_STHDiagnosticAmount();
            open.Show();
        }

        private void textBox_BX_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_UserFileSetup_Load(object sender, EventArgs e)
        {
            reloadAndBindingSystemDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;

            if (status == PageStatus.STATUS_VIEW)
            {
                if (CurrentUser.currentUserLevel == 9)
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
                }
                else
                {
                    button_Top.Enabled = false;
                    button_Back.Enabled = false;
                    button_Next.Enabled = false;
                    button_End.Enabled = false;
                    button_Save.Enabled = true;
                    button_New.Enabled = false;
                    button_Edit.Enabled = true;
                    button_Delete.Enabled = false;
                    button_Undo.Enabled = false;
                    button_Exit.Enabled = true;
                }
                

                textBox_Picture_Path_2.Enabled = false;
                textBox_Invoice_Year.Enabled = false;
                textBox_Next_Inv.Enabled = false;
                textBox_Next_Receipt.Enabled = false;
                checkBox_Activate_User_Level_Control.Enabled = false;
                checkBox_Auto_Print_Barcode_For_STH_Cases.Enabled = false;
                checkBox_Auto_Generate_PDF_When_Print_Report.Enabled = false;
                textBox_BX.Enabled = false;
                textBox_BB.Enabled = false;
                textBox_CY.Enabled = false;
                textBox_CC.Enabled = false;
                textBox_CYG.Enabled = false;
                textBox_EBV.Enabled = false;

                textBox_User_ID.Enabled = false;
                textBox_User_Name.Enabled = false;
                textBox_Department.Enabled = false;
                textBox_Initial.Enabled = false;
                textBox_Password.Enabled = false;
                numericUpDown_User_Level.Enabled = false;
                checkBox_Pri_Screener.Enabled = false;
                textBox_Picture_Path.Enabled = false;
            }
            else
            {
                if (status == PageStatus.STATUS_NEW)
                {
                    if (CurrentUser.currentUserLevel == 9)
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
                    }
                    else
                    {
                        button_Top.Enabled = false;
                        button_Back.Enabled = false;
                        button_Next.Enabled = false;
                        button_End.Enabled = false;
                        button_Save.Enabled = true;
                        button_New.Enabled = false;
                        button_Edit.Enabled = true;
                        button_Delete.Enabled = false;
                        button_Undo.Enabled = false;
                        button_Exit.Enabled = true;
                    }

                    textBox_Picture_Path_2.Enabled = false;
                    textBox_Invoice_Year.Enabled = false;
                    textBox_Next_Inv.Enabled = false;
                    textBox_Next_Receipt.Enabled = false;
                    checkBox_Activate_User_Level_Control.Enabled = false;
                    checkBox_Auto_Print_Barcode_For_STH_Cases.Enabled = false;
                    checkBox_Auto_Generate_PDF_When_Print_Report.Enabled = false;
                    textBox_BX.Enabled = false;
                    textBox_BB.Enabled = false;
                    textBox_CY.Enabled = false;
                    textBox_CC.Enabled = false;
                    textBox_CYG.Enabled = false;
                    textBox_EBV.Enabled = false;

                    textBox_User_ID.Enabled = false;
                    textBox_User_Name.Enabled = false;
                    textBox_Department.Enabled = false;
                    textBox_Initial.Enabled = false;
                    textBox_Password.Enabled = false;
                    numericUpDown_User_Level.Enabled = false;
                    checkBox_Pri_Screener.Enabled = false;
                    textBox_Picture_Path.Enabled = false;
                }
                else
                {
                    if (status == PageStatus.STATUS_EDIT)
                    {
                        if (CurrentUser.currentUserLevel == 9)
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
                        }
                        else
                        {
                            button_Top.Enabled = false;
                            button_Back.Enabled = false;
                            button_Next.Enabled = false;
                            button_End.Enabled = false;
                            button_Save.Enabled = true;
                            button_New.Enabled = false;
                            button_Edit.Enabled = true;
                            button_Delete.Enabled = false;
                            button_Undo.Enabled = false;
                            button_Exit.Enabled = true;
                        }

                        textBox_Picture_Path_2.Enabled = true;
                        textBox_Invoice_Year.Enabled = true;
                        textBox_Next_Inv.Enabled = true;
                        textBox_Next_Receipt.Enabled = true;
                        checkBox_Activate_User_Level_Control.Enabled = true;
                        checkBox_Auto_Print_Barcode_For_STH_Cases.Enabled = true;
                        checkBox_Auto_Generate_PDF_When_Print_Report.Enabled = true;
                        textBox_BX.Enabled = true;
                        textBox_BB.Enabled = true;
                        textBox_CY.Enabled = true;
                        textBox_CC.Enabled = true;
                        textBox_CYG.Enabled = true;
                        textBox_EBV.Enabled = true;

                        textBox_User_ID.Enabled = true;
                        textBox_User_Name.Enabled = true;
                        textBox_Department.Enabled = true;
                        textBox_Initial.Enabled = true;
                        textBox_Password.Enabled = true;
                        numericUpDown_User_Level.Enabled = true;
                        checkBox_Pri_Screener.Enabled = true;
                        textBox_Picture_Path.Enabled = true;
                    }
                }
            }

            
        }

        private void reloadAndBindingSystemDBData()
        {
            string sql = "SELECT TOP 1 * FROM [system_setting]";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, systemDataSet, "system_setting");

            textBox_Picture_Path_2.DataBindings.Clear();
            textBox_Invoice_Year.DataBindings.Clear();
            textBox_Next_Inv.DataBindings.Clear();
            textBox_Next_Receipt.DataBindings.Clear();
            checkBox_Activate_User_Level_Control.DataBindings.Clear();
            checkBox_Auto_Print_Barcode_For_STH_Cases.DataBindings.Clear();
            checkBox_Auto_Generate_PDF_When_Print_Report.DataBindings.Clear();
            textBox_BX.DataBindings.Clear();
            textBox_BB.DataBindings.Clear();
            textBox_CY.DataBindings.Clear();
            textBox_CC.DataBindings.Clear();
            textBox_CYG.DataBindings.Clear();
            textBox_EBV.DataBindings.Clear();

            dt = systemDataSet.Tables["system_setting"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_Picture_Path_2.DataBindings.Add("Text", dt, "picture_path", false);
            textBox_Invoice_Year.DataBindings.Add("Text", dt, "invoice_year", false);
            textBox_Next_Inv.DataBindings.Add("Text", dt, "next_inv", false);
            textBox_Next_Receipt.DataBindings.Add("Text", dt, "next_receipt", false);
            checkBox_Activate_User_Level_Control.DataBindings.Add("Checked", dt, "activate_user_level_control", false);
            checkBox_Auto_Print_Barcode_For_STH_Cases.DataBindings.Add("Checked", dt, "auto_print_barcode", false);
            checkBox_Auto_Generate_PDF_When_Print_Report.DataBindings.Add("Checked", dt, "auto_generate_PDF", false);
            textBox_BX.DataBindings.Add("Text", dt, "PRICE_BX", false);
            textBox_BB.DataBindings.Add("Text", dt, "PRICE_BB", false);
            textBox_CY.DataBindings.Add("Text", dt, "PRICE_CY", false);
            textBox_CC.DataBindings.Add("Text", dt, "PRICE_CC", false);
            textBox_CYG.DataBindings.Add("Text", dt, "PRICE_CYG", false);
            textBox_EBV.DataBindings.Add("Text", dt, "PRICE_EBV", false);

        }
    }
}
