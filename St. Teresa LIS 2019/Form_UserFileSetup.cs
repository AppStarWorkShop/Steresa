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
        private SqlDataAdapter systemDataAdapter;
        private SqlDataAdapter userDataAdapter;
        private DataTable systemDt;
        private DataTable userDt;
        private int currentStatus;
        private DataRow currentEditRow;

        public CurrencyManager currencyManager;
        private int currentPosition;
        private UserStr copyUser;

        public class User
        {
            public string userId { get; set; }
            public string userName { get; set; }
            public string department { get; set; }
            public string initial { get; set; }
            public string password { get; set; }
            public Double? level{ get; set; }
            public string password2 { get; set; }
            public string picPath { get; set; }
        }

        public class UserStr
        {
            public string userId { get; set; }
            public string userName { get; set; }
            public string department { get; set; }
            public string initial { get; set; }
            public string password { get; set; }
            public string level{ get; set; }
            public string password2 { get; set; }
            public string picPath { get; set; }
        }

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
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = CurrentUser.currentUserName;
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    textBox_ID.BindingContext[userDt].Position++;

                    if (DBConn.updateObject(userDataAdapter, userDataSet, "user"))
                    {
                        reloadDBData(currencyManager.Count - 1);
                        MessageBox.Show("New user saved");
                    }
                    else
                    {
                        MessageBox.Show("User saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = userDataSet.Tables["user"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserName;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        textBox_ID.BindingContext[userDt].Position++;

                        if (DBConn.updateObject(userDataAdapter, userDataSet, "user"))
                        {
                            MessageBox.Show("User updated");
                        }
                        else
                        {
                            MessageBox.Show("User updated fail, please contact Admin");
                        }
                    }

                    if (CurrentUser.currentUserLevel == 9)
                    {
                        DataRow drowSystem = systemDataSet.Tables["system_setting"].Rows.Find(textBox_SYSTEM_ID.Text);
                        if (drowSystem != null)
                        {
                            drowSystem["UPDATE_BY"] = CurrentUser.currentUserName;
                            drowSystem["UPDATE_AT"] = DateTime.Now.ToString("");
                            textBox_SYSTEM_ID.BindingContext[systemDt].Position++;

                            if (DBConn.updateObject(systemDataAdapter, systemDataSet, "system_setting"))
                            {
                                MessageBox.Show("System setting updated");
                            }
                            else
                            {
                                MessageBox.Show("System setting updated fail, please contact Admin");
                            }
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;
            if (CurrentUser.currentUserLevel == 9)
            {
                label_You_Can_Only_Change_Your_Own_Password_And_Initial.Visible = false;
            }
            else
            {
                label_You_Can_Only_Change_Your_Own_Password_And_Initial.Visible = true;
            }

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
                textBox_2nd_Level_Password.Enabled = false;
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

                disedit_modle();
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
                        button_Undo.Enabled = true;
                        button_Exit.Enabled = true;
                    }

                    textBox_Picture_Path_2.Enabled = false;
                    textBox_Invoice_Year.Enabled = false;
                    textBox_Next_Inv.Enabled = false;
                    textBox_Next_Receipt.Enabled = false;
                    checkBox_Activate_User_Level_Control.Enabled = false;
                    checkBox_Auto_Print_Barcode_For_STH_Cases.Enabled = false;
                    checkBox_Auto_Generate_PDF_When_Print_Report.Enabled = false;
                    textBox_2nd_Level_Password.Enabled = false;
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

                    edit_modle();
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

                            textBox_Picture_Path_2.Enabled = true;
                            textBox_Invoice_Year.Enabled = true;
                            textBox_Next_Inv.Enabled = true;
                            textBox_Next_Receipt.Enabled = true;
                            checkBox_Activate_User_Level_Control.Enabled = true;
                            checkBox_Auto_Print_Barcode_For_STH_Cases.Enabled = true;
                            checkBox_Auto_Generate_PDF_When_Print_Report.Enabled = true;
                            textBox_2nd_Level_Password.Enabled = true;
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
                            button_Undo.Enabled = true;
                            button_Exit.Enabled = true;

                            textBox_Picture_Path_2.Enabled = false;
                            textBox_Invoice_Year.Enabled = false;
                            textBox_Next_Inv.Enabled = false;
                            textBox_Next_Receipt.Enabled = false;
                            checkBox_Activate_User_Level_Control.Enabled = false;
                            checkBox_Auto_Print_Barcode_For_STH_Cases.Enabled = false;
                            checkBox_Auto_Generate_PDF_When_Print_Report.Enabled = false;
                            textBox_2nd_Level_Password.Enabled = true;
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
                            textBox_Password.Enabled = true;
                            numericUpDown_User_Level.Enabled = false;
                            checkBox_Pri_Screener.Enabled = false;
                            textBox_Picture_Path.Enabled = false;
                        }
                        edit_modle();
                    }
                }
            }

            
        }

        private void reloadAndBindingSystemDBData()
        {
            string userSql = "SELECT * FROM [USER]";

            if(CurrentUser.currentUserLevel == 9)
            {
                userSql = "SELECT * FROM [USER]";
            }
            else
            {
                userSql = string.Format("SELECT * FROM [USER] WHERE ID ={0}", CurrentUser.currentUserId);
            }

            userDataAdapter = DBConn.fetchDataIntoDataSet(userSql, userDataSet, "user");

            textBox_ID.DataBindings.Clear();
            textBox_User_ID.DataBindings.Clear();
            textBox_User_Name.DataBindings.Clear();
            textBox_Department.DataBindings.Clear();
            textBox_Initial.DataBindings.Clear();
            textBox_Password.DataBindings.Clear();
            numericUpDown_User_Level.DataBindings.Clear();
            checkBox_Pri_Screener.DataBindings.Clear();
            textBox_2nd_Level_Password.DataBindings.Clear();
            textBox_Picture_Path.DataBindings.Clear();

            userDt = userDataSet.Tables["user"];
            userDt.PrimaryKey = new DataColumn[] { userDt.Columns["id"] };
            userDt.Columns["id"].AutoIncrement = true;
            userDt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", userDt, "id", false);
            textBox_User_ID.DataBindings.Add("Text", userDt, "USER_ID", false);
            textBox_User_Name.DataBindings.Add("Text", userDt, "USER_NAME", false);
            textBox_Department.DataBindings.Add("Text", userDt, "DEPARTMENT", false);
            textBox_Initial.DataBindings.Add("Text", userDt, "INITIAL", false);
            textBox_Password.DataBindings.Add("Text", userDt, "PASSWORD", false);
            numericUpDown_User_Level.DataBindings.Add("Text", userDt, "LEVEL", false);
            textBox_2nd_Level_Password.DataBindings.Add("Text", userDt, "PASSWORD2", false);
            textBox_Picture_Path.DataBindings.Add("Text", userDt, "PIC_PATH", false);

            currencyManager = (CurrencyManager)this.BindingContext[userDt];

            //currencyManager.Position = position;

            string sql = "SELECT TOP 1 * FROM [system_setting]";
            systemDataAdapter = DBConn.fetchDataIntoDataSet(sql, systemDataSet, "system_setting");

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

            systemDt = systemDataSet.Tables["system_setting"];
            systemDt.PrimaryKey = new DataColumn[] { systemDt.Columns["id"] };
            systemDt.Columns["id"].AutoIncrement = true;
            systemDt.Columns["id"].AutoIncrementStep = 1;

            textBox_SYSTEM_ID.DataBindings.Add("Text", systemDt, "id", false);
            textBox_Picture_Path_2.DataBindings.Add("Text", systemDt, "picture_path", false);
            textBox_Invoice_Year.DataBindings.Add("Text", systemDt, "invoice_year", false);
            textBox_Next_Inv.DataBindings.Add("Text", systemDt, "next_inv", false);
            textBox_Next_Receipt.DataBindings.Add("Text", systemDt, "next_receipt", false);
            checkBox_Activate_User_Level_Control.DataBindings.Add("Checked", systemDt, "activate_user_level_control", false);
            checkBox_Auto_Print_Barcode_For_STH_Cases.DataBindings.Add("Checked", systemDt, "auto_print_barcode", false);
            checkBox_Auto_Generate_PDF_When_Print_Report.DataBindings.Add("Checked", systemDt, "auto_generate_PDF", false);
            textBox_BX.DataBindings.Add("Text", systemDt, "PRICE_BX", false);
            textBox_BB.DataBindings.Add("Text", systemDt, "PRICE_BB", false);
            textBox_CY.DataBindings.Add("Text", systemDt, "PRICE_CY", false);
            textBox_CC.DataBindings.Add("Text", systemDt, "PRICE_CC", false);
            textBox_CYG.DataBindings.Add("Text", systemDt, "PRICE_CYG", false);
            textBox_EBV.DataBindings.Add("Text", systemDt, "PRICE_EBV", false);

        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            currencyManager.Position = 0;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            currencyManager.Position--;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            currencyManager.Position++;
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = userDataSet.Tables["user"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["LEVEL"] = 1;
            userDataSet.Tables["user"].Rows.Add(currentEditRow);

            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            currentPosition = currencyManager.Position;

            copyUser = new UserStr();
            copyUser.userId = textBox_User_ID.Text;
            copyUser.userName = textBox_User_Name.Text;
            copyUser.department = textBox_Department.Text;
            copyUser.initial = textBox_Initial.Text;
            copyUser.password = textBox_Password.Text;
            copyUser.level = numericUpDown_User_Level.Text;
            copyUser.password2 = textBox_2nd_Level_Password.Text;
            copyUser.picPath = textBox_Picture_Path.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM USER WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = userDt.Rows.Find(textBox_User_ID.Text);
                    rowToDelete.Delete();
                    currencyManager.Position = 0;

                    reloadDBData(0);
                    MessageBox.Show("User deleted");
                }
                else
                {
                    MessageBox.Show("User deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
            }
        }

        private void reloadDBData(int position = 0)
        {
            string userSql = "SELECT * FROM [USER]";

            if (CurrentUser.currentUserLevel == 9)
            {
                userSql = "SELECT * FROM [USER]";
            }
            else
            {
                userSql = string.Format("SELECT * FROM [USER] WHERE ID ={0}", CurrentUser.currentUserId);
            }

            userDataAdapter = DBConn.fetchDataIntoDataSet(userSql, userDataSet, "user");

            textBox_User_ID.DataBindings.Clear();
            textBox_User_Name.DataBindings.Clear();
            textBox_Department.DataBindings.Clear();
            textBox_Initial.DataBindings.Clear();
            textBox_Password.DataBindings.Clear();
            numericUpDown_User_Level.DataBindings.Clear();
            checkBox_Pri_Screener.DataBindings.Clear();
            textBox_2nd_Level_Password.DataBindings.Clear();
            textBox_Picture_Path.DataBindings.Clear();

            userDt = userDataSet.Tables["user"];
            userDt.PrimaryKey = new DataColumn[] { userDt.Columns["id"] };
            userDt.Columns["id"].AutoIncrement = true;
            userDt.Columns["id"].AutoIncrementStep = 1;

            textBox_User_ID.DataBindings.Add("Text", userDt, "USER_ID", false);
            textBox_User_Name.DataBindings.Add("Text", userDt, "USER_NAME", false);
            textBox_Department.DataBindings.Add("Text", userDt, "DEPARTMENT", false);
            textBox_Initial.DataBindings.Add("Text", userDt, "INITIAL", false);
            textBox_Password.DataBindings.Add("Text", userDt, "PASSWORD", false);
            numericUpDown_User_Level.DataBindings.Add("Text", userDt, "LEVEL", false);
            textBox_2nd_Level_Password.DataBindings.Add("Text", userDt, "PASSWORD2", false);
            textBox_Picture_Path.DataBindings.Add("Text", userDt, "PIC_PATH", false);

            currencyManager = (CurrencyManager)this.BindingContext[userDt];
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    userDataSet.Tables["user"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyUser != null)
                    {
                        textBox_User_ID.Text = copyUser.userId;
                        textBox_User_Name.Text = copyUser.userName;
                        textBox_Department.Text = copyUser.department;
                        textBox_Initial.Text = copyUser.initial;
                        textBox_Password.Text = copyUser.password;
                        numericUpDown_User_Level.Text = copyUser.level;
                        textBox_2nd_Level_Password.Text = copyUser.password2;
                        textBox_Picture_Path.Text = copyUser.picPath;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
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
