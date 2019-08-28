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
    public partial class Form_SiteFileMaintenance : Form
    {
        private DataSet siteDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private siteStr copysite;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchsite;

        private DataSet siteDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public class site
        {
            public int id { get; set; }
            public string SITE { get; set; }
            public string DESC { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public class siteStr
        {
            public int id { get; set; }
            public string SITE { get; set; }
            public string DESC { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public Form_SiteFileMaintenance()
        {
            InitializeComponent();

            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            string countSql = string.Format(" [site] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [site] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, siteDataSet, "site");
            }

            if (siteDataSet != null && siteDataSet != null && siteDataSet.Tables["site"].Rows.Count > 0)
            {
                resetDDLValue(siteDataSet.Tables["site"].Rows[0]["SITE"].ToString());
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            string countSql = string.Format(" [site] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [site] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, siteDataSet, "site");
            }

            if (siteDataSet != null && siteDataSet != null && siteDataSet.Tables["site"].Rows.Count > 0)
            {
                resetDDLValue(siteDataSet.Tables["site"].Rows[0]["SITE"].ToString());
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [site] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, siteDataSet, "site");

            if (siteDataSet != null && siteDataSet != null && siteDataSet.Tables["site"].Rows.Count > 0)
            {
                resetDDLValue(siteDataSet.Tables["site"].Rows[0]["SITE"].ToString());
            }
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [site] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, siteDataSet, "site");

            if (siteDataSet != null && siteDataSet != null && siteDataSet.Tables["site"].Rows.Count > 0)
            {
                resetDDLValue(siteDataSet.Tables["site"].Rows[0]["SITE"].ToString());
            }
        }

        private void resetDDLValue(string searchSite)
        {
            if (searchSite != null)
            {
                comboBox_Site.SelectedValue = searchSite;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = "Admin";
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    currentEditRow["SITE"] = comboBox_Site.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, siteDataSet, "site"))
                    {
                        reloadAndBindingDBData();
                        MessageBox.Show("New Site saved");
                    }
                    else
                    {
                        MessageBox.Show("Site saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = siteDataSet.Tables["site"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = "Admin";
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["SITE"] = comboBox_Site.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, siteDataSet, "site"))
                        {
                            reloadAndBindingDBData();
                            MessageBox.Show("Site updated");
                        }
                        else
                        {
                            MessageBox.Show("Site updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            //currentPosition = currencyManager.Count - 1;
            if (comboBox_Site.Items.Count > 0)
            {
                comboBox_Site.SelectedIndex = 0;
            }
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_Site.Text = "";
            textBox_ChineseDescription.Text = "";

            currentEditRow = siteDataSet.Tables["site"].NewRow();
            currentEditRow["id"] = -1;

            siteDataSet.Clear();
            siteDataSet.Tables["site"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copysite = new siteStr();
            copysite.SITE = comboBox_Site.Text;
            copysite.DESC = textBox_ChineseDescription.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM site WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    MessageBox.Show("Site deleted");
                }
                else
                {
                    MessageBox.Show("Site deleted fail, please contact Admin");
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
                    siteDataSet.Tables["site"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copysite != null)
                    {
                        comboBox_Site.Text = copysite.SITE;
                        textBox_ChineseDescription.Text = copysite.DESC;
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

        private void reloadAndBindingDBData(string searchSite = null)
        {
            string sql = "SELECT TOP 1 * FROM [site] ORDER BY ID";
            if (searchSite != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [site] WHERE site = '{0}' ORDER BY ID", searchSite);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, siteDataSet, "site");

            textBox_ID.DataBindings.Clear();
            textBox_ChineseDescription.DataBindings.Clear();
            comboBox_Site.DataBindings.Clear();

            dt = siteDataSet.Tables["site"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_ChineseDescription.DataBindings.Add("Text", dt, "DESC", false);
            comboBox_Site.DataBindings.Add("Text", dt, "SITE", false);

            string sqlFull = "SELECT * FROM [site] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, siteDataSetFull, "site");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("site");

            foreach (DataRow mDr in siteDataSetFull.Tables["site"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["site"] });
            }

            comboBox_Site.DataSource = newDt;

            if (comboBox_Site.Items.Count > 0)
            {
                comboBox_Site.SelectedIndex = 0;
            }

            if (searchSite != null && comboBox_Site.Items.Count > 0)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in dt.Rows)
                {
                    if (mDr["site"].ToString().Trim() == searchSite.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }
                comboBox_Site.SelectedIndex = currentPosition;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [site] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, siteDataSet, "site");

            dt = siteDataSet.Tables["site"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            string sqlFull = "SELECT * FROM [site] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, siteDataSetFull, "site");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("site");

            foreach (DataRow mDr in siteDataSetFull.Tables["site"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["site"] });
            }

            comboBox_Site.DataSource = newDt;
            if (comboBox_Site.Items.Count > 0)
            {
                comboBox_Site.SelectedIndex = 0;
            }
        }

        private void comboBox_Site_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [site] WHERE site = '{0}' ORDER BY ID", comboBox_Site.SelectedValue.ToString());
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, siteDataSet, "site");

            textBox_ID.DataBindings.Clear();
            textBox_ChineseDescription.DataBindings.Clear();

            dt = siteDataSet.Tables["site"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_ChineseDescription.DataBindings.Add("Text", dt, "DESC", false);
        }
    }
}
