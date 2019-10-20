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
    public partial class Form_FrozenSectionDianosis : Form
    {
        private DataSet frozen_sectionDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private frozen_sectionStr copyfrozen_section;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchfrozen_section;

        private DataSet frozen_sectionDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void valueUpdated(string val);
        public valueUpdated OnValueUpdated;

        public class frozen_section
        {
            public int id { get; set; }
            public string FZ_DETAIL { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public class frozen_sectionStr
        {
            public int id { get; set; }
            public string FZ_DETAIL { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public Form_FrozenSectionDianosis()
        {
            InitializeComponent();
            reloadAndBindingDBData();
        }

        public Form_FrozenSectionDianosis(string searchStr)
        {
            InitializeComponent();
            reloadAndBindingDBData(searchStr);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if(OnValueUpdated != null)
            {
                OnValueUpdated(comboBox_FZ_Detail.SelectedValue.ToString());
            }
            this.Close();
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //currencyManager.Position++;
            string countSql = string.Format(" [frozen_section] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [frozen_section] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, frozen_sectionDataSet, "frozen_section");
            }

            if (frozen_sectionDataSet != null && frozen_sectionDataSet != null && frozen_sectionDataSet.Tables["frozen_section"].Rows.Count > 0)
            {
                resetDDLValue(frozen_sectionDataSet.Tables["frozen_section"].Rows[0]["FZ_DETAIL"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            //currencyManager.Position--;
            string countSql = string.Format(" [frozen_section] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [frozen_section] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, frozen_sectionDataSet, "frozen_section");
            }

            if (frozen_sectionDataSet != null && frozen_sectionDataSet != null && frozen_sectionDataSet.Tables["frozen_section"].Rows.Count > 0)
            {
                resetDDLValue(frozen_sectionDataSet.Tables["frozen_section"].Rows[0]["FZ_DETAIL"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [frozen_section] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, frozen_sectionDataSet, "frozen_section");

            if (frozen_sectionDataSet != null && frozen_sectionDataSet != null && frozen_sectionDataSet.Tables["frozen_section"].Rows.Count > 0)
            {
                resetDDLValue(frozen_sectionDataSet.Tables["frozen_section"].Rows[0]["FZ_DETAIL"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 * FROM [frozen_section] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, frozen_sectionDataSet, "frozen_section");

            if (frozen_sectionDataSet != null && frozen_sectionDataSet != null && frozen_sectionDataSet.Tables["frozen_section"].Rows.Count > 0)
            {
                resetDDLValue(frozen_sectionDataSet.Tables["frozen_section"].Rows[0]["FZ_DETAIL"].ToString());
            }
            //checkMasterEngName();
        }

        private void resetDDLValue(string searchFZ_DETAIL)
        {
            if (searchFZ_DETAIL != null)
            {
                comboBox_FZ_Detail.SelectedValue = searchFZ_DETAIL;
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
                    currentEditRow["FZ_DETAIL"] = comboBox_FZ_Detail.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, frozen_sectionDataSet, "frozen_section"))
                    {
                        reloadAndBindingDBData();
                        //comboBox_Diagnosis.SelectedIndex = currentPosition+1;
                        MessageBox.Show("New Frozen Section saved");
                    }
                    else
                    {
                        MessageBox.Show("Frozen Section saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = frozen_sectionDataSet.Tables["frozen_section"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["FZ_DETAIL"] = comboBox_FZ_Detail.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, frozen_sectionDataSet, "frozen_section"))
                        {
                            reloadAndBindingDBData();
                            //comboBox_Diagnosis.SelectedIndex = currentPosition;
                            MessageBox.Show("Frozen Section updated");
                        }
                        else
                        {
                            MessageBox.Show("Frozen Section updated fail, please contact Admin");
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
            if (comboBox_FZ_Detail.Items.Count > 0)
            {
                comboBox_FZ_Detail.SelectedIndex = 0;
            }
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_FZ_Detail.Text = "";

            currentEditRow = frozen_sectionDataSet.Tables["frozen_section"].NewRow();
            currentEditRow["id"] = -1;

            frozen_sectionDataSet.Clear();
            frozen_sectionDataSet.Tables["frozen_section"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copyfrozen_section = new frozen_sectionStr();
            copyfrozen_section.FZ_DETAIL = comboBox_FZ_Detail.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM frozen_section WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    MessageBox.Show("Frozen Section deleted");
                }
                else
                {
                    MessageBox.Show("Frozen Section deleted fail, please contact Admin");
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
                    frozen_sectionDataSet.Tables["frozen_section"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyfrozen_section != null)
                    {
                        comboBox_FZ_Detail.Text = copyfrozen_section.FZ_DETAIL;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void Form_MICROSCOPICReportMaintenance_Load(object sender, EventArgs e)
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

        private void reloadAndBindingDBData(string searchFZ_DETAIL = null)
        {
            string sql = "SELECT TOP 1 * FROM [frozen_section] ORDER BY ID";
            if (searchFZ_DETAIL != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [frozen_section] WHERE FZ_DETAIL = '{0}' ORDER BY ID", searchFZ_DETAIL);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, frozen_sectionDataSet, "frozen_section");

            textBox_ID.DataBindings.Clear();

            dt = frozen_sectionDataSet.Tables["frozen_section"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);

            string sqlFull = "SELECT * FROM [frozen_section] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, frozen_sectionDataSetFull, "frozen_section");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("FZ_DETAIL");

            foreach (DataRow mDr in frozen_sectionDataSetFull.Tables["frozen_section"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["FZ_DETAIL"] });
            }

            comboBox_FZ_Detail.DataSource = newDt;

            if (comboBox_FZ_Detail.Items.Count > 0)
            {
                comboBox_FZ_Detail.SelectedIndex = 0;
            }

            if (searchFZ_DETAIL != null && comboBox_FZ_Detail.Items.Count > 0)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in newDt.Rows)
                {
                    if (mDr["FZ_DETAIL"].ToString().Trim() == searchFZ_DETAIL.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }
                comboBox_FZ_Detail.SelectedIndex = currentPosition;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [frozen_section] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, frozen_sectionDataSet, "frozen_section");

            dt = frozen_sectionDataSet.Tables["frozen_section"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            string sqlFull = "SELECT * FROM [frozen_section] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, frozen_sectionDataSetFull, "frozen_section");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("FZ_DETAIL");

            foreach (DataRow mDr in frozen_sectionDataSetFull.Tables["frozen_section"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["FZ_DETAIL"] });
            }

            comboBox_FZ_Detail.DataSource = newDt;
            if (comboBox_FZ_Detail.Items.Count > 0)
            {
                comboBox_FZ_Detail.SelectedIndex = 0;
            }
        }
        /*
        private void comboBox_FZ_Detail_SelectionChangeCommitted(object sender, EventArgs e)
        {
            resetPageVal(comboBox_FZ_Detail.SelectedValue.ToString().Trim());
        }

        private void resetPageVal(string FZ_DETAILStr)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [frozen_section] WHERE FZ_DETAIL = '{0}' ORDER BY ID", FZ_DETAILStr);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, frozen_sectionDataSet, "frozen_section");
            textBox_ID.DataBindings.Clear();

            dt = frozen_sectionDataSet.Tables["frozen_section"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
        }*/

        private void button_Copy_To_New_Click(object sender, EventArgs e)
        {
            Form_SelectFrozenSection open = new Form_SelectFrozenSection();
            open.Onfrozen_sectionSelectedSingle += OnFrozenSectionSelected;
            open.Show();

        }

        private void OnFrozenSectionSelected(string nameStr)
        {
            if (nameStr != null)
            {
                comboBox_FZ_Detail.SelectedValue = nameStr.Trim();
            }
        }
    }
}
