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
    public partial class Form_DiagnosisDictionaryMaintenance : Form
    {
        private DataSet diag_descDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private diag_descStr copydiag_desc;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchdiag_desc;

        private DataSet diag_descDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void RecordUpdateDone(bool isUpdted);
        public RecordUpdateDone OnRecordUpdateDone;

        private bool isNeedRefreshMotherPage = false;

        public class diag_desc
        {
            public int id { get; set; }
            public string E_DESC { get; set; }
            public string C_DESC { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public class diag_descStr
        {
            public int id { get; set; }
            public string E_DESC { get; set; }
            public string C_DESC { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public Form_DiagnosisDictionaryMaintenance()
        {
            InitializeComponent();

            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //currencyManager.Position++;
            string countSql = string.Format(" [diag_desc] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [diag_desc] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, diag_descDataSet, "diag_desc");
            }

            if (diag_descDataSet != null && diag_descDataSet != null && diag_descDataSet.Tables["diag_desc"].Rows.Count > 0)
            {
                resetDDLValue(diag_descDataSet.Tables["diag_desc"].Rows[0]["C_DESC"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            //currencyManager.Position--;
            string countSql = string.Format(" [diag_desc] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [diag_desc] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, diag_descDataSet, "diag_desc");
            }

            if (diag_descDataSet != null && diag_descDataSet != null && diag_descDataSet.Tables["diag_desc"].Rows.Count > 0)
            {
                resetDDLValue(diag_descDataSet.Tables["diag_desc"].Rows[0]["C_DESC"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [diag_desc] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, diag_descDataSet, "diag_desc");

            if (diag_descDataSet != null && diag_descDataSet != null && diag_descDataSet.Tables["diag_desc"].Rows.Count > 0)
            {
                resetDDLValue(diag_descDataSet.Tables["diag_desc"].Rows[0]["C_DESC"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 * FROM [diag_desc] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, diag_descDataSet, "diag_desc");

            if (diag_descDataSet != null && diag_descDataSet != null && diag_descDataSet.Tables["diag_desc"].Rows.Count > 0)
            {
                resetDDLValue(diag_descDataSet.Tables["diag_desc"].Rows[0]["C_DESC"].ToString());
            }
            //checkMasterEngName();
        }

        private void resetDDLValue(string searchDescription)
        {
            if (searchDescription != null)
            {
                comboBox_Description.SelectedValue = searchDescription;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    currentEditRow["C_DESC"] = comboBox_Description.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, diag_descDataSet, "diag_desc"))
                    {
                        reloadAndBindingDBData();
                        //comboBox_Diagnosis.SelectedIndex = currentPosition+1;
                        isNeedRefreshMotherPage = true;
                        MessageBox.Show("New Diag Desc saved");
                    }
                    else
                    {
                        MessageBox.Show("Diag Desc saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = diag_descDataSet.Tables["diag_desc"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["C_DESC"] = comboBox_Description.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, diag_descDataSet, "diag_desc"))
                        {
                            reloadAndBindingDBData();
                            //comboBox_Diagnosis.SelectedIndex = currentPosition;
                            isNeedRefreshMotherPage = true;
                            MessageBox.Show("Diag Desc updated");
                        }
                        else
                        {
                            MessageBox.Show("Diag Desc updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    //reloadAndBindingDBData(currentPosition);
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            //currentPosition = currencyManager.Count - 1;
            if (comboBox_Description.Items.Count > 0)
            {
                comboBox_Description.SelectedIndex = 0;
            }
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_Description.Text = "";
            textBox_ChineseDescription.Text = "";

            currentEditRow = diag_descDataSet.Tables["diag_desc"].NewRow();
            currentEditRow["id"] = -1;

            diag_descDataSet.Clear();
            diag_descDataSet.Tables["diag_desc"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copydiag_desc = new diag_descStr();
            copydiag_desc.C_DESC = comboBox_Description.Text;
            copydiag_desc.E_DESC = textBox_ChineseDescription.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM diag_desc WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    isNeedRefreshMotherPage = true;
                    MessageBox.Show("Diag Desc Report deleted");
                }
                else
                {
                    MessageBox.Show("Diag Desc deleted fail, please contact Admin");
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
                    diag_descDataSet.Tables["diag_desc"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copydiag_desc != null)
                    {
                        comboBox_Description.Text = copydiag_desc.C_DESC;
                        textBox_ChineseDescription.Text = copydiag_desc.E_DESC;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (OnRecordUpdateDone != null)
            {
                OnRecordUpdateDone(isNeedRefreshMotherPage);
            }
            this.Close();
        }

        private void button_Select_Click(object sender, EventArgs e)
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

        private void reloadAndBindingDBData(string searchDescription = null)
        {
            string sql = "SELECT TOP 1 * FROM [diag_desc] ORDER BY ID";
            if (searchDescription != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [diag_desc] WHERE MACROSCOPIC = '{0}' ORDER BY ID", searchDescription);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, diag_descDataSet, "diag_desc");

            textBox_ID.DataBindings.Clear();
            textBox_ChineseDescription.DataBindings.Clear();
            comboBox_Description.DataBindings.Clear();

            string sqlFull = "SELECT * FROM [diag_desc] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, diag_descDataSetFull, "diag_desc");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("C_DESC");

            foreach (DataRow mDr in diag_descDataSetFull.Tables["diag_desc"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["C_DESC"] });
            }

            comboBox_Description.DataSource = newDt;

            if (comboBox_Description.Items.Count > 0)
            {
                comboBox_Description.SelectedIndex = 0;
            }

            /*textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();*/

            dt = diag_descDataSet.Tables["diag_desc"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            comboBox_Description.DataBindings.Add("Text", dt, "C_DESC", false);
            textBox_ChineseDescription.DataBindings.Add("Text", dt, "E_DESC", false);
            /*textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);*/

            if (searchDescription != null && comboBox_Description.Items.Count > 0)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in dt.Rows)
                {
                    if (mDr["C_DESC"].ToString().Trim() == searchDescription.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }
                comboBox_Description.SelectedIndex = currentPosition;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [diag_desc] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, diag_descDataSet, "diag_desc");

            dt = diag_descDataSet.Tables["diag_desc"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            string sqlFull = "SELECT * FROM [diag_desc] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, diag_descDataSetFull, "diag_desc");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("C_DESC");

            foreach (DataRow mDr in diag_descDataSetFull.Tables["diag_desc"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["C_DESC"] });
            }

            comboBox_Description.DataSource = newDt;
            if (comboBox_Description.Items.Count > 0)
            {
                comboBox_Description.SelectedIndex = 0;
            }
        }

        private void comboBox_Description_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [diag_desc] WHERE C_DESC = '{0}' ORDER BY ID", comboBox_Description.SelectedValue.ToString());
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, diag_descDataSet, "diag_desc");

            textBox_ID.DataBindings.Clear();
            textBox_ChineseDescription.DataBindings.Clear();

            dt = diag_descDataSet.Tables["diag_desc"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_ChineseDescription.DataBindings.Add("Text", dt, "E_DESC", false);
        }
    }
}
