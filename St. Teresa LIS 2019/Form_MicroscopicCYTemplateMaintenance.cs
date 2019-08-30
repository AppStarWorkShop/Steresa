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
    public partial class Form_MicroscopicCYTemplateMaintenance : Form
    {
        private DataSet micro_templateDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private micro_templateStr copymicro_template;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchmicro_template;

        public class micro_template
        {
            public string DOCTOR { get; set; }
            public string ORGAN { get; set; }
            public string TEMPLATE { get; set; }
            public string micro_DESC { get; set; }
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

        public class micro_templateStr
        {
            public string DOCTOR { get; set; }
            public string ORGAN { get; set; }
            public string TEMPLATE { get; set; }
            public string micro_DESC { get; set; }
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

        public Form_MicroscopicCYTemplateMaintenance()
        {
            InitializeComponent();
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Copy_To_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = micro_templateDataSet.Tables["micro_template"].NewRow();
            currentEditRow["id"] = -1;

            currentEditRow["DOCTOR"] = textBox_Doctor.Text;
            currentEditRow["ORGAN"] = textBox_Organ.Text;
            currentEditRow["TEMPLATE"] = textBox_Template.Text;
            currentEditRow["micro_DESC"] = textBox_microscopic_Description.Text;

            currentEditRow["SITE"] = comboBox_Site.Text;
            currentEditRow["SITE2"] = textBox_Site_Chinese_Desc.Text;
            currentEditRow["OPERATION"] = comboBox_Operation.Text;
            currentEditRow["OPERATION2"] = textBox_Operation_Chinese_Desc.Text;
            currentEditRow["DIAGNOSIS"] = textBox_Daignosis.Text;
            currentEditRow["DIAG_DESC1"] = comboBox_Daignosis_Chinese_Desc_1.Text;
            currentEditRow["DIAG_DESC2"] = comboBox_Daignosis_Chinese_Desc_2.Text;

            micro_templateDataSet.Tables["micro_template"].Rows.Clear();
            micro_templateDataSet.Tables["micro_template"].Rows.Add(currentEditRow);
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //currencyManager.Position++;
            string countSql = string.Format(" [micro_template] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [micro_template] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, micro_templateDataSet, "micro_template");
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            //currencyManager.Position--;
            string countSql = string.Format(" [micro_template] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [micro_template] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, micro_templateDataSet, "micro_template");
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [micro_template] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, micro_templateDataSet, "micro_template");
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 * FROM [micro_template] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, micro_templateDataSet, "micro_template");
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

                    if (DBConn.updateObject(dataAdapter, micro_templateDataSet, "micro_template"))
                    {
                        reloadAndBindingDBData();
                        //comboBox_Diagnosis.SelectedIndex = currentPosition+1;
                        MessageBox.Show("New microSCOPIC Report saved");
                    }
                    else
                    {
                        MessageBox.Show("Micro Template saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = micro_templateDataSet.Tables["micro_template"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserName;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        //drow["microSCOPIC"] = comboBox_microSCOPIC.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, micro_templateDataSet, "micro_template"))
                        {
                            reloadAndBindingDBData();
                            //comboBox_Diagnosis.SelectedIndex = currentPosition;
                            MessageBox.Show("microSCOPIC Report updated");
                        }
                        else
                        {
                            MessageBox.Show("Micro Template updated fail, please contact Admin");
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

            currentEditRow = micro_templateDataSet.Tables["micro_template"].NewRow();
            currentEditRow["id"] = -1;

            micro_templateDataSet.Clear();
            micro_templateDataSet.Tables["micro_template"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copymicro_template = new micro_templateStr();
            copymicro_template.DOCTOR = textBox_Doctor.Text;
            copymicro_template.ORGAN = textBox_Organ.Text;
            copymicro_template.TEMPLATE = textBox_Template.Text;
            copymicro_template.micro_DESC = textBox_microscopic_Description.Text;

            copymicro_template.SITE = comboBox_Site.Text;
            copymicro_template.SITE2 = textBox_Site_Chinese_Desc.Text;
            copymicro_template.OPERATION = comboBox_Operation.Text;
            copymicro_template.OPERATION2 = textBox_Operation_Chinese_Desc.Text;
            copymicro_template.DIAGNOSIS = textBox_Daignosis.Text;
            copymicro_template.DIAG_DESC1 = comboBox_Daignosis_Chinese_Desc_1.Text;
            copymicro_template.DIAG_DESC2 = comboBox_Daignosis_Chinese_Desc_2.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM micro_template WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    MessageBox.Show("micro template deleted");
                }
                else
                {
                    MessageBox.Show("micro template deleted fail, please contact Admin");
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
                    micro_templateDataSet.Tables["micro_template"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copymicro_template != null)
                    {
                        textBox_Doctor.Text = copymicro_template.DOCTOR;
                        textBox_Organ.Text = copymicro_template.ORGAN;
                        textBox_Template.Text = copymicro_template.TEMPLATE;
                        textBox_microscopic_Description.Text = copymicro_template.micro_DESC;

                        comboBox_Site.Text = copymicro_template.SITE;
                        textBox_Site_Chinese_Desc.Text = copymicro_template.SITE2;
                        comboBox_Operation.Text = copymicro_template.OPERATION;
                        textBox_Operation_Chinese_Desc.Text = copymicro_template.OPERATION2;
                        textBox_Daignosis.Text = copymicro_template.DIAGNOSIS;
                        comboBox_Daignosis_Chinese_Desc_1.Text = copymicro_template.DIAG_DESC1;
                        comboBox_Daignosis_Chinese_Desc_2.Text = copymicro_template.DIAG_DESC2;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void Form_microSCOPICReportMaintenance_Load(object sender, EventArgs e)
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
                textBox_microscopic_Description.Enabled = false;

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
                    textBox_microscopic_Description.Enabled = true;

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
                        textBox_microscopic_Description.Enabled = true;

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

        private void reloadAndBindingDBData(string searchmicroSCOPIC = null)
        {
            string sql = "SELECT TOP 1 * FROM [micro_template] ORDER BY ID";
            if (searchmicroSCOPIC != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [micro_template] WHERE microSCOPIC = '{0}' ORDER BY ID", searchmicroSCOPIC);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, micro_templateDataSet, "micro_template");

            textBox_ID.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            textBox_Doctor.DataBindings.Clear();
            textBox_Organ.DataBindings.Clear();
            textBox_Template.DataBindings.Clear();

            comboBox_Site.DataBindings.Clear();
            textBox_Site_Chinese_Desc.DataBindings.Clear();
            comboBox_Operation.DataBindings.Clear();
            textBox_Operation_Chinese_Desc.DataBindings.Clear();
            textBox_Daignosis.DataBindings.Clear();
            comboBox_Daignosis_Chinese_Desc_1.DataBindings.Clear();
            comboBox_Daignosis_Chinese_Desc_2.DataBindings.Clear();

            textBox_microscopic_Description.DataBindings.Clear();

            string siteSql = "SELECT site FROM [site]";
            DataSet siteDataSet = new DataSet();
            SqlDataAdapter siteDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(siteSql, siteDataSet, "site");

            DataTable siteDt = new DataTable();
            siteDt.Columns.Add("site");

            foreach (DataRow mDr in siteDataSet.Tables["site"].Rows)
            {
                siteDt.Rows.Add(new object[] { mDr["site"] });
            }

            comboBox_Site.DataSource = siteDt;


            string operationSql = "SELECT operation FROM [operation]";
            DataSet operationDataSet = new DataSet();
            SqlDataAdapter operationDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(operationSql, operationDataSet, "operation");

            DataTable operationDt = new DataTable();
            operationDt.Columns.Add("operation");

            foreach (DataRow mDr in operationDataSet.Tables["operation"].Rows)
            {
                operationDt.Rows.Add(new object[] { mDr["operation"] });
            }

            comboBox_Operation.DataSource = operationDt;


            string diag_descSql = "SELECT C_DESC FROM [diag_desc]";
            DataSet diag_descDataSet = new DataSet();
            SqlDataAdapter diag_descDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(diag_descSql, diag_descDataSet, "diag_desc");

            DataTable diag_descDt = new DataTable();
            diag_descDt.Columns.Add("C_DESC");

            foreach (DataRow mDr in diag_descDataSet.Tables["diag_desc"].Rows)
            {
                diag_descDt.Rows.Add(new object[] { mDr["C_DESC"] });
            }

            comboBox_Daignosis_Chinese_Desc_1.DataSource = diag_descDt;
            comboBox_Daignosis_Chinese_Desc_2.DataSource = diag_descDt;


            dt = micro_templateDataSet.Tables["micro_template"];
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
            textBox_microscopic_Description.DataBindings.Add("Text", dt, "micro_DESC", false);

            comboBox_Site.DataBindings.Add("Text", dt, "SITE", false);
            textBox_Site_Chinese_Desc.DataBindings.Add("Text", dt, "SITE2", false);
            comboBox_Operation.DataBindings.Add("Text", dt, "OPERATION", false);
            textBox_Operation_Chinese_Desc.DataBindings.Add("Text", dt, "OPERATION2", false);
            textBox_Daignosis.DataBindings.Add("Text", dt, "DIAGNOSIS", false);
            comboBox_Daignosis_Chinese_Desc_1.DataBindings.Add("Text", dt, "DIAG_DESC1", false);
            comboBox_Daignosis_Chinese_Desc_2.DataBindings.Add("Text", dt, "DIAG_DESC2", false);
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [micro_template] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, micro_templateDataSet, "micro_template");

            dt = micro_templateDataSet.Tables["micro_template"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;
        }
    }
}
