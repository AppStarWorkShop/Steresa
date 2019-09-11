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
    public partial class Form_OperationFileMaintenance : Form
    {
        private DataSet operationDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private operationStr copyoperation;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchoperation;

        private DataSet operationDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void RecordUpdateDone(bool isUpdted);
        public RecordUpdateDone OnRecordUpdateDone;

        private bool isNeedRefreshMotherPage = false;

        public class operation
        {
            public int id { get; set; }
            public string OPERATION { get; set; }
            public string DESC { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public class operationStr
        {
            public int id { get; set; }
            public string OPERATION { get; set; }
            public string DESC { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public Form_OperationFileMaintenance()
        {
            InitializeComponent();

            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (OnRecordUpdateDone != null)
            {
                OnRecordUpdateDone(isNeedRefreshMotherPage);
            }
            this.Close();
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            string countSql = string.Format(" [operation] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [operation] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, operationDataSet, "operation");
            }

            if (operationDataSet != null && operationDataSet != null && operationDataSet.Tables["operation"].Rows.Count > 0)
            {
                resetDDLValue(operationDataSet.Tables["operation"].Rows[0]["operation"].ToString());
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            string countSql = string.Format(" [operation] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [operation] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, operationDataSet, "operation");
            }

            if (operationDataSet != null && operationDataSet != null && operationDataSet.Tables["operation"].Rows.Count > 0)
            {
                resetDDLValue(operationDataSet.Tables["operation"].Rows[0]["operation"].ToString());
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [operation] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, operationDataSet, "operation");

            if (operationDataSet != null && operationDataSet != null && operationDataSet.Tables["operation"].Rows.Count > 0)
            {
                resetDDLValue(operationDataSet.Tables["operation"].Rows[0]["operation"].ToString());
            }
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [operation] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, operationDataSet, "operation");

            if (operationDataSet != null && operationDataSet != null && operationDataSet.Tables["operation"].Rows.Count > 0)
            {
                resetDDLValue(operationDataSet.Tables["operation"].Rows[0]["operation"].ToString());
            }
        }

        private void resetDDLValue(string searchoperation)
        {
            if (searchoperation != null)
            {
                comboBox_Operation.SelectedValue = searchoperation;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = CurrentUser.currentUserName;
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    currentEditRow["operation"] = comboBox_Operation.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, operationDataSet, "operation"))
                    {
                        reloadAndBindingDBData();
                        isNeedRefreshMotherPage = true;
                        MessageBox.Show("New operation saved");
                    }
                    else
                    {
                        MessageBox.Show("operation saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = operationDataSet.Tables["operation"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserName;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["operation"] = comboBox_Operation.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, operationDataSet, "operation"))
                        {
                            reloadAndBindingDBData();
                            isNeedRefreshMotherPage = true;
                            MessageBox.Show("operation updated");
                        }
                        else
                        {
                            MessageBox.Show("operation updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            //currentPosition = currencyManager.Count - 1;
            if (comboBox_Operation.Items.Count > 0)
            {
                comboBox_Operation.SelectedIndex = 0;
            }
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_Operation.Text = "";
            textBox_ChineseDescription.Text = "";

            currentEditRow = operationDataSet.Tables["operation"].NewRow();
            currentEditRow["id"] = -1;

            operationDataSet.Clear();
            operationDataSet.Tables["operation"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copyoperation = new operationStr();
            copyoperation.OPERATION = comboBox_Operation.Text;
            copyoperation.DESC = textBox_ChineseDescription.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM operation WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    MessageBox.Show("operation deleted");
                }
                else
                {
                    MessageBox.Show("operation deleted fail, please contact Admin");
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
                    operationDataSet.Tables["operation"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyoperation != null)
                    {
                        comboBox_Operation.Text = copyoperation.OPERATION;
                        textBox_ChineseDescription.Text = copyoperation.DESC;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
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

                textBox_ChineseDescription.Enabled = false;

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

                    textBox_ChineseDescription.Enabled = true;

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

                        textBox_ChineseDescription.Enabled = true;

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

        private void reloadAndBindingDBData(string searchoperation = null)
        {
            string sql = "SELECT TOP 1 * FROM [operation] ORDER BY ID";
            if (searchoperation != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [operation] WHERE operation = '{0}' ORDER BY ID", searchoperation);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, operationDataSet, "operation");

            textBox_ID.DataBindings.Clear();
            textBox_ChineseDescription.DataBindings.Clear();
            comboBox_Operation.DataBindings.Clear();

            dt = operationDataSet.Tables["operation"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_ChineseDescription.DataBindings.Add("Text", dt, "DESC", false);
            comboBox_Operation.DataBindings.Add("Text", dt, "operation", false);

            string sqlFull = "SELECT * FROM [operation] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, operationDataSetFull, "operation");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("operation");

            foreach (DataRow mDr in operationDataSetFull.Tables["operation"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["operation"] });
            }

            comboBox_Operation.DataSource = newDt;

            if (comboBox_Operation.Items.Count > 0)
            {
                comboBox_Operation.SelectedIndex = 0;
            }

            if (searchoperation != null && comboBox_Operation.Items.Count > 0)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in dt.Rows)
                {
                    if (mDr["operation"].ToString().Trim() == searchoperation.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }
                comboBox_Operation.SelectedIndex = currentPosition;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [operation] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, operationDataSet, "operation");

            dt = operationDataSet.Tables["operation"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            string sqlFull = "SELECT * FROM [operation] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, operationDataSetFull, "operation");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("operation");

            foreach (DataRow mDr in operationDataSetFull.Tables["operation"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["operation"] });
            }

            comboBox_Operation.DataSource = newDt;
            if (comboBox_Operation.Items.Count > 0)
            {
                comboBox_Operation.SelectedIndex = 0;
            }
        }

        private void comboBox_Operation_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [operation] WHERE operation = '{0}' ORDER BY ID", comboBox_Operation.SelectedValue.ToString());
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, operationDataSet, "operation");

            textBox_ID.DataBindings.Clear();
            textBox_ChineseDescription.DataBindings.Clear();

            dt = operationDataSet.Tables["operation"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_ChineseDescription.DataBindings.Add("Text", dt, "DESC", false);
        }
    }
}
