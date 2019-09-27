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
    public partial class Form_NatureOfSpecimenReportMaintenance : Form
    {
        private DataSet NatureOfSpecimenDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private NatureOfSpecimenStr copyNatureOfSpecimen;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchNatureOfSpecimen;

        private DataSet NatureOfSpecimenDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void RecordUpdateDone(bool isUpdted);
        public RecordUpdateDone OnRecordUpdateDone;

        private bool isNeedRefreshMotherPage = false;

        public class NatureOfSpecimen
        {
            public int id { get; set; }
            public string SurgicalProcedureVal { get; set; }
            public string Description { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
        }

        public class NatureOfSpecimenStr
        {
            public int id { get; set; }
            public string SurgicalProcedureVal { get; set; }
            public string Description { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
        }

        public Form_NatureOfSpecimenReportMaintenance()
        {
            InitializeComponent();

            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }
            //currencyManager.Position++;
            string countSql = string.Format(" [NatureOfSpecimen] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [NatureOfSpecimen] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, NatureOfSpecimenDataSet, "NatureOfSpecimen");
            }

            if (NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows.Count > 0)
            {
                resetDDLValue(NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows[0]["SurgicalProcedureVal"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            //currencyManager.Position--;
            if (textBox_ID.Text.Trim() == "")
            {
                return;
            }

            string countSql = string.Format(" [NatureOfSpecimen] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [NatureOfSpecimen] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, NatureOfSpecimenDataSet, "NatureOfSpecimen");
            }

            if (NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows.Count > 0)
            {
                resetDDLValue(NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows[0]["SurgicalProcedureVal"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [NatureOfSpecimen] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, NatureOfSpecimenDataSet, "NatureOfSpecimen");

            if (NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows.Count > 0)
            {
                resetDDLValue(NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows[0]["SurgicalProcedureVal"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 * FROM [NatureOfSpecimen] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, NatureOfSpecimenDataSet, "NatureOfSpecimen");

            if (NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet != null && NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows.Count > 0)
            {
                resetDDLValue(NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows[0]["SurgicalProcedureVal"].ToString());
            }
            //checkMasterEngName();
        }

        private void resetDDLValue(string searchNatureOfSpecimen)
        {
            if (searchNatureOfSpecimen != null)
            {
                comboBox_Nature_Of_Specimen.SelectedValue = searchNatureOfSpecimen;
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
                    currentEditRow["SurgicalProcedureVal"] = comboBox_Nature_Of_Specimen.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, NatureOfSpecimenDataSet, "NatureOfSpecimen"))
                    {
                        reloadAndBindingDBData();
                        //comboBox_Diagnosis.SelectedIndex = currentPosition+1;
                        isNeedRefreshMotherPage = true;
                        MessageBox.Show("New NatureOfSpecimen saved");
                    }
                    else
                    {
                        MessageBox.Show("NatureOfSpecimen saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserName;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["SurgicalProcedureVal"] = comboBox_Nature_Of_Specimen.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, NatureOfSpecimenDataSet, "NatureOfSpecimen"))
                        {
                            reloadAndBindingDBData();
                            isNeedRefreshMotherPage = true;
                            //comboBox_Diagnosis.SelectedIndex = currentPosition;
                            MessageBox.Show("NatureOfSpecimen updated");
                        }
                        else
                        {
                            MessageBox.Show("NatureOfSpecimen updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    //reloadAndBindingDBData(currentPosition);
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            if (comboBox_Nature_Of_Specimen.Items.Count > 0)
            {
                comboBox_Nature_Of_Specimen.SelectedIndex = 0;
            }
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_Nature_Of_Specimen.Text = "";
            textBox_Desc.Text = "";

            currentEditRow = NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].NewRow();
            currentEditRow["id"] = -1;

            NatureOfSpecimenDataSet.Clear();
            NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copyNatureOfSpecimen = new NatureOfSpecimenStr();
            copyNatureOfSpecimen.SurgicalProcedureVal = comboBox_Nature_Of_Specimen.Text;
            copyNatureOfSpecimen.Description = textBox_Desc.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM NatureOfSpecimen WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    isNeedRefreshMotherPage = true;
                    MessageBox.Show("NatureOfSpecimen deleted");
                }
                else
                {
                    MessageBox.Show("NatureOfSpecimen deleted fail, please contact Admin");
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
                    NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyNatureOfSpecimen != null)
                    {
                        comboBox_Nature_Of_Specimen.Text = copyNatureOfSpecimen.SurgicalProcedureVal;
                        textBox_Desc.Text = copyNatureOfSpecimen.Description;
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

                textBox_Desc.Enabled = false;

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

                    textBox_Desc.Enabled = true;

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

                        textBox_Desc.Enabled = true;

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

        private void reloadAndBindingDBData(string searchNatureOfSpecimen = null)
        {
            string sql = "SELECT TOP 1 * FROM [NatureOfSpecimen] ORDER BY ID";
            if (searchNatureOfSpecimen != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [NatureOfSpecimen] WHERE MACROSCOPIC = '{0}' ORDER BY ID", searchNatureOfSpecimen);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, NatureOfSpecimenDataSet, "NatureOfSpecimen");

            textBox_ID.DataBindings.Clear();
            textBox_Desc.DataBindings.Clear();
            textBox_Desc.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            dt = NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Desc.DataBindings.Add("Text", dt, "Description", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);

            string sqlFull = "SELECT * FROM [NatureOfSpecimen] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, NatureOfSpecimenDataSetFull, "NatureOfSpecimen");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("SurgicalProcedureVal");

            foreach (DataRow mDr in NatureOfSpecimenDataSetFull.Tables["NatureOfSpecimen"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["SurgicalProcedureVal"] });
            }

            comboBox_Nature_Of_Specimen.DataSource = newDt;

            if (comboBox_Nature_Of_Specimen.Items.Count > 0)
            {
                comboBox_Nature_Of_Specimen.SelectedIndex = 0;
            }

            if (searchNatureOfSpecimen != null && comboBox_Nature_Of_Specimen.Items.Count > 0)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in dt.Rows)
                {
                    if (mDr["SurgicalProcedureVal"].ToString().Trim() == searchNatureOfSpecimen.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }
                comboBox_Nature_Of_Specimen.SelectedIndex = currentPosition;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [NatureOfSpecimen] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, NatureOfSpecimenDataSet, "NatureOfSpecimen");

            dt = NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            string sqlFull = "SELECT * FROM [NatureOfSpecimen] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, NatureOfSpecimenDataSetFull, "NatureOfSpecimen");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("SurgicalProcedureVal");

            foreach (DataRow mDr in NatureOfSpecimenDataSetFull.Tables["NatureOfSpecimen"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["SurgicalProcedureVal"] });
            }

            comboBox_Nature_Of_Specimen.DataSource = newDt;
            if (comboBox_Nature_Of_Specimen.Items.Count > 0)
            {
                comboBox_Nature_Of_Specimen.SelectedIndex = 0;
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

        private void comboBox_Nature_Of_Specimen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [NatureOfSpecimen] WHERE SurgicalProcedureVal = '{0}' ORDER BY ID", comboBox_Nature_Of_Specimen.SelectedValue.ToString());
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, NatureOfSpecimenDataSet, "NatureOfSpecimen");

            textBox_ID.DataBindings.Clear();
            textBox_Desc.DataBindings.Clear();
            textBox_Desc.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            dt = NatureOfSpecimenDataSet.Tables["NatureOfSpecimen"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Desc.DataBindings.Add("Text", dt, "Description", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);
        }
    }
}
