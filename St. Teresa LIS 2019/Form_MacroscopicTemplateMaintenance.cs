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
    public partial class Form_MacroscopicTemplateMaintenance : Form
    {
        private DataSet macro_templateDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private macro_templateStr copymacro_template;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchmacro_template;

        public class macro_template
        {
            public string DOCTOR { get; set; }
            public string ORGAN { get; set; }
            public string TEMPLATE { get; set; }
            public string MACRO_DESC { get; set; }
            public string SITE { get; set; }
            public string SITE2 { get; set; }
            public string OPERATION { get; set; }
            public string OPERATION2 { get; set; }
            public string DIAGNOSIS { get; set; }
            public string DIAG_DESC1 { get; set; }
            public string DIAG_DESC2 { get; set; }
            public float UPDATE_CTR { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATED { get; set; }
            public int id { get; set; }
        }

        public class macro_templateStr
        {
            public string DOCTOR { get; set; }
            public string ORGAN { get; set; }
            public string TEMPLATE { get; set; }
            public string MACRO_DESC { get; set; }
            public string SITE { get; set; }
            public string SITE2 { get; set; }
            public string OPERATION { get; set; }
            public string OPERATION2 { get; set; }
            public string DIAGNOSIS { get; set; }
            public string DIAG_DESC1 { get; set; }
            public string DIAG_DESC2 { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATED { get; set; }
            public int id { get; set; }
        }

        public Form_MacroscopicTemplateMaintenance()
        {
            InitializeComponent();
        }

        private void Form_MacroscopicTemplateMaintenance_Load(object sender, EventArgs e)
        {
            setButtonStatus(currentStatus);
            reloadAndBindingDBData();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Copy_To_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = macro_templateDataSet.Tables["macro_template"].NewRow();
            currentEditRow["id"] = -1;

            currentEditRow["DOCTOR"] = textBox_Doctor.Text;
            currentEditRow["ORGAN"] = textBox_Organ.Text;
            currentEditRow["TEMPLATE"] = textBox_Template.Text;
            currentEditRow["MACRO_DESC"] = textBox_Macroscopic_Description.Text;

            macro_templateDataSet.Tables["macro_template"].Rows.Clear();
            macro_templateDataSet.Tables["macro_template"].Rows.Add(currentEditRow);
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //currencyManager.Position++;
            string countSql = string.Format(" [macro_template] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [macro_template] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, macro_templateDataSet, "macro_template");
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            //currencyManager.Position--;
            string countSql = string.Format(" [macro_template] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [macro_template] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, macro_templateDataSet, "macro_template");
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [macro_template] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, macro_templateDataSet, "macro_template");
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 * FROM [macro_template] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, macro_templateDataSet, "macro_template");
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = CurrentUser.currentUserName;
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, macro_templateDataSet, "macro_template"))
                    {
                        reloadAndBindingDBData();
                        //comboBox_Diagnosis.SelectedIndex = currentPosition+1;
                        MessageBox.Show("New MACROSCOPIC Report saved");
                    }
                    else
                    {
                        MessageBox.Show("MACROSCOPIC Report saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = macro_templateDataSet.Tables["macro_template"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserName;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        //drow["MACROSCOPIC"] = comboBox_MACROSCOPIC.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, macro_templateDataSet, "macro_template"))
                        {
                            reloadAndBindingDBData();
                            //comboBox_Diagnosis.SelectedIndex = currentPosition;
                            MessageBox.Show("MACROSCOPIC Report updated");
                        }
                        else
                        {
                            MessageBox.Show("MACROSCOPIC Report updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    //reloadAndBindingDBData(currentPosition);
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = macro_templateDataSet.Tables["macro_template"].NewRow();
            currentEditRow["id"] = -1;

            macro_templateDataSet.Clear();
            macro_templateDataSet.Tables["macro_template"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copymacro_template = new macro_templateStr();
            copymacro_template.DOCTOR = textBox_Doctor.Text;
            copymacro_template.ORGAN = textBox_Organ.Text;
            copymacro_template.TEMPLATE = textBox_Template.Text;
            copymacro_template.MACRO_DESC = textBox_Macroscopic_Description.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM macro_template WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    MessageBox.Show("Macro template deleted");
                }
                else
                {
                    MessageBox.Show("Macro template deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
            }
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    macro_templateDataSet.Tables["macro_template"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copymacro_template != null)
                    {
                        textBox_Doctor.Text = copymacro_template.DOCTOR;
                        textBox_Organ.Text = copymacro_template.ORGAN;
                        textBox_Template.Text = copymacro_template.TEMPLATE;
                        textBox_Macroscopic_Description.Text = copymacro_template.MACRO_DESC;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void Form_MACROSCOPICReportMaintenance_Load(object sender, EventArgs e)
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

                textBox_Doctor.Enabled = false;
                textBox_Organ.Enabled = false;
                textBox_Template.Enabled = false;
                textBox_Macroscopic_Description.Enabled = false;

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

                    textBox_Doctor.Enabled = true;
                    textBox_Organ.Enabled = true;
                    textBox_Template.Enabled = true;
                    textBox_Macroscopic_Description.Enabled = true;

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

                        textBox_Doctor.Enabled = true;
                        textBox_Organ.Enabled = true;
                        textBox_Template.Enabled = true;
                        textBox_Macroscopic_Description.Enabled = true;

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

        private void reloadAndBindingDBData(string searchMACROSCOPIC = null)
        {
            string sql = "SELECT TOP 1 * FROM [macro_template] ORDER BY ID";
            if (searchMACROSCOPIC != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [macro_template] WHERE MACROSCOPIC = '{0}' ORDER BY ID", searchMACROSCOPIC);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, macro_templateDataSet, "macro_template");

            textBox_ID.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            textBox_Doctor.DataBindings.Clear();
            textBox_Organ.DataBindings.Clear();
            textBox_Template.DataBindings.Clear();
            textBox_Macroscopic_Description.DataBindings.Clear();

            dt = macro_templateDataSet.Tables["macro_template"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            //textBox_Desc.DataBindings.Add("Text", dt, "Description", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);

            textBox_Doctor.DataBindings.Add("Text", dt, "DOCTOR", false);
            textBox_Organ.DataBindings.Add("Text", dt, "ORGAN", false);
            textBox_Template.DataBindings.Add("Text", dt, "TEMPLATE", false);
            textBox_Macroscopic_Description.DataBindings.Add("Text", dt, "MACRO_DESC", false);
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [macro_template] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, macro_templateDataSet, "macro_template");

            dt = macro_templateDataSet.Tables["macro_template"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;
        }
    }
}
