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
    public partial class Form_PictureCaptionMaintenance : Form
    {
        private DataSet picture_capDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private picture_capStr copypicture_cap;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchpicture_cap;

        private DataSet picture_capDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void RecordUpdateDone(bool isUpdted);
        public RecordUpdateDone OnRecordUpdateDone;

        private bool isNeedRefreshMotherPage = false;

        public class picture_cap
        {
            public int id { get; set; }
            public string CAPTION { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public class picture_capStr
        {
            public int id { get; set; }
            public string CAPTION { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public Form_PictureCaptionMaintenance()
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
            string countSql = string.Format(" [picture_cap] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [picture_cap] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, picture_capDataSet, "picture_cap");
            }

            if (picture_capDataSet != null && picture_capDataSet != null && picture_capDataSet.Tables["picture_cap"].Rows.Count > 0)
            {
                resetDDLValue(picture_capDataSet.Tables["picture_cap"].Rows[0]["CAPTION"].ToString());
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            string countSql = string.Format(" [picture_cap] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [picture_cap] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, picture_capDataSet, "picture_cap");
            }

            if (picture_capDataSet != null && picture_capDataSet != null && picture_capDataSet.Tables["picture_cap"].Rows.Count > 0)
            {
                resetDDLValue(picture_capDataSet.Tables["picture_cap"].Rows[0]["CAPTION"].ToString());
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [picture_cap] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, picture_capDataSet, "picture_cap");

            if (picture_capDataSet != null && picture_capDataSet != null && picture_capDataSet.Tables["picture_cap"].Rows.Count > 0)
            {
                resetDDLValue(picture_capDataSet.Tables["picture_cap"].Rows[0]["CAPTION"].ToString());
            }
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [picture_cap] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, picture_capDataSet, "picture_cap");

            if (picture_capDataSet != null && picture_capDataSet != null && picture_capDataSet.Tables["picture_cap"].Rows.Count > 0)
            {
                resetDDLValue(picture_capDataSet.Tables["picture_cap"].Rows[0]["CAPTION"].ToString());
            }
        }

        private void resetDDLValue(string searchCaption)
        {
            if (searchCaption != null)
            {
                comboBox_Caption.SelectedValue = searchCaption;
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
                    currentEditRow["CAPTION"] = comboBox_Caption.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, picture_capDataSet, "picture_cap"))
                    {
                        reloadAndBindingDBData();
                        //comboBox_Diagnosis.SelectedIndex = currentPosition+1;
                        isNeedRefreshMotherPage = true;
                        MessageBox.Show("New Picture Cap saved");
                    }
                    else
                    {
                        MessageBox.Show("Picture Cap saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = picture_capDataSet.Tables["picture_cap"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["CAPTION"] = comboBox_Caption.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, picture_capDataSet, "picture_cap"))
                        {
                            reloadAndBindingDBData();
                            //comboBox_Diagnosis.SelectedIndex = currentPosition;
                            isNeedRefreshMotherPage = true;
                            MessageBox.Show("Picture Cap updated");
                        }
                        else
                        {
                            MessageBox.Show("Picture Cap updated fail, please contact Admin");
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
            if (comboBox_Caption.Items.Count > 0)
            {
                comboBox_Caption.SelectedIndex = 0;
            }
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_Caption.Text = "";

            currentEditRow = picture_capDataSet.Tables["picture_cap"].NewRow();
            currentEditRow["id"] = -1;

            picture_capDataSet.Clear();
            picture_capDataSet.Tables["picture_cap"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copypicture_cap = new picture_capStr();
            copypicture_cap.CAPTION = comboBox_Caption.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM picture_cap WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    isNeedRefreshMotherPage = true;
                    MessageBox.Show("Picture Cap deleted");
                }
                else
                {
                    MessageBox.Show("Picture Cap deleted fail, please contact Admin");
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
                    picture_capDataSet.Tables["picture_cap"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copypicture_cap != null)
                    {
                        comboBox_Caption.Text = copypicture_cap.CAPTION;
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

        private void reloadAndBindingDBData(string searchCaption = null)
        {
            string sql = "SELECT TOP 1 * FROM [picture_cap] ORDER BY ID";
            if (searchCaption != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [picture_cap] WHERE CAPTION = '{0}' ORDER BY ID", searchCaption);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, picture_capDataSet, "picture_cap");

            textBox_ID.DataBindings.Clear();
            comboBox_Caption.DataBindings.Clear();

            dt = picture_capDataSet.Tables["picture_cap"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            comboBox_Caption.DataBindings.Add("Text", dt, "CAPTION", false);

            string sqlFull = "SELECT * FROM [picture_cap] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, picture_capDataSetFull, "picture_cap");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("CAPTION");

            foreach (DataRow mDr in picture_capDataSetFull.Tables["picture_cap"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["CAPTION"] });
            }

            comboBox_Caption.DataSource = newDt;

            if (comboBox_Caption.Items.Count > 0)
            {
                comboBox_Caption.SelectedIndex = 0;
            }

            if (searchCaption != null && comboBox_Caption.Items.Count > 0)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in dt.Rows)
                {
                    if (mDr["CAPTION"].ToString().Trim() == searchCaption.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }
                comboBox_Caption.SelectedIndex = currentPosition;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [picture_cap] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, picture_capDataSet, "picture_cap");

            dt = picture_capDataSet.Tables["picture_cap"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            string sqlFull = "SELECT * FROM [picture_cap] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, picture_capDataSetFull, "picture_cap");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("CAPTION");

            foreach (DataRow mDr in picture_capDataSetFull.Tables["picture_cap"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["CAPTION"] });
            }

            comboBox_Caption.DataSource = newDt;
            if (comboBox_Caption.Items.Count > 0)
            {
                comboBox_Caption.SelectedIndex = 0;
            }
        }

        private void comboBox_Caption_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [picture_cap] WHERE CAPTION = '{0}' ORDER BY ID", comboBox_Caption.SelectedValue.ToString());
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, picture_capDataSet, "picture_cap");

            textBox_ID.DataBindings.Clear();

            dt = picture_capDataSet.Tables["picture_cap"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
        }
    }
}
