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
    public partial class Form_ResultFileMaintenance : Form
    {
        private DataSet resultDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        public static Boolean merge;
        public CurrencyManager currencyManager;
        private ResultStr copyResult;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;

        public class Result
        {
            public int id { get; set; }
            public string result { get; set; }
            public string desc1 { get; set; }
            public string desc2 { get; set; }
            public string desc3 { get; set; }
            public string updateBy { get; set; }
            public DateTime? updateAt { get; set; }
            public string updateCtr { get; set; }
            public string updated { get; set; }
        }

        public class ResultStr
        {
            public int id { get; set; }
            public string result { get; set; }
            public string desc1 { get; set; }
            public string desc2 { get; set; }
            public string desc3 { get; set; }
            public string updateBy { get; set; }
            public string updateAt { get; set; }
            public string updateCtr { get; set; }
            public string updated { get; set; }
        }

        public Form_ResultFileMaintenance()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            currencyManager.Position = 0;
            comboBox_Report_Code.SelectedIndex = 0;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            currencyManager.Position--;
            comboBox_Report_Code.SelectedIndex = currencyManager.Position;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            currencyManager.Position++;
            comboBox_Report_Code.SelectedIndex = currencyManager.Position;
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            currencyManager.Position = currencyManager.Count - 1;
            comboBox_Report_Code.SelectedIndex = currencyManager.Position;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    currentEditRow["RESULT"] = comboBox_Report_Code.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, resultDataSet, "result"))
                    {
                        reloadAndBindingDBData(currentPosition + 1);
                        //comboBox_Report_Code.SelectedIndex = currentPosition+1;
                        MessageBox.Show("New result saved");
                    }
                    else
                    {
                        MessageBox.Show("Result saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = resultDataSet.Tables["result"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["RESULT"] = comboBox_Report_Code.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, resultDataSet, "result"))
                        {
                            reloadAndBindingDBData(currentPosition);
                            //comboBox_Report_Code.SelectedIndex = currentPosition;
                            MessageBox.Show("Result updated");
                        }
                        else
                        {
                            MessageBox.Show("Result updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    //reloadAndBindingDBData(currentPosition);
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            currentPosition = currencyManager.Count - 1;
            comboBox_Report_Code.SelectedIndex = 0;
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_Report_Code.Text = "";

            currentEditRow = resultDataSet.Tables["result"].NewRow();
            currentEditRow["id"] = -1;
            resultDataSet.Tables["result"].Rows.Add(currentEditRow);

            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            currentPosition = currencyManager.Position;

            copyResult = new ResultStr();
            copyResult.result = comboBox_Report_Code.Text;
            copyResult.desc1 = textBox_Desc1.Text;
            copyResult.desc2 = textBox_Desc2.Text;
            copyResult.desc3 = textBox_Desc3.Text;

            comboBox_Report_Code.Text = comboBox_Report_Code.SelectedValue.ToString();

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM result WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    //currencyManager.Position = 0;

                    reloadDBData();
                    MessageBox.Show("Result deleted");
                }
                else
                {
                    MessageBox.Show("Result deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
                //reloadDBData();
            }
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    resultDataSet.Tables["result"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);

                currencyManager.Position = currencyManager.Count - 1;
                comboBox_Report_Code.SelectedIndex = currencyManager.Position;
                //reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyResult != null)
                    {
                        comboBox_Report_Code.Text = copyResult.result;
                        textBox_Desc1.Text = copyResult.desc1;
                        textBox_Desc2.Text = copyResult.desc2;
                        textBox_Desc3.Text = copyResult.desc3;

                        //comboBox_Report_Code.Text = copyResult.result;
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

                //comboBox_Report_Code.Enabled = false;
                textBox_Desc1.Enabled = false;
                textBox_Desc2.Enabled = false;
                textBox_Desc3.Enabled = false;

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

                    //comboBox_Report_Code.Enabled = true;
                    textBox_Desc1.Enabled = true;
                    textBox_Desc2.Enabled = true;
                    textBox_Desc3.Enabled = true;

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

                        //comboBox_Report_Code.Enabled = true;
                        textBox_Desc1.Enabled = true;
                        textBox_Desc2.Enabled = true;
                        textBox_Desc3.Enabled = true;

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

        private void reloadAndBindingDBData(int position = 0)
        {
            string sql = "SELECT * FROM [result]";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, resultDataSet, "result");

            textBox_ID.DataBindings.Clear();
            comboBox_Report_Code.DataBindings.Clear();
            textBox_Desc1.DataBindings.Clear();
            textBox_Desc2.DataBindings.Clear();
            textBox_Desc3.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            dt = resultDataSet.Tables["result"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            //comboBox_Report_Code.DataBindings.Add("Text", dt, "RESULT", false);
            textBox_Desc1.DataBindings.Add("Text", dt, "DESC1", false);
            textBox_Desc2.DataBindings.Add("Text", dt, "DESC2", false);
            textBox_Desc3.DataBindings.Add("Text", dt, "DESC3", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);

            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;

            DataTable newDt = new DataTable();
            newDt.Columns.Add("DESC");
            newDt.Columns.Add("RESULT");

            foreach (DataRow mDr in resultDataSet.Tables["result"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["RESULT"] + "-" + mDr["DESC1"] , mDr["RESULT"] });
            }

            comboBox_Report_Code.DataSource = newDt;

            comboBox_Report_Code.SelectedIndex = currencyManager.Position;
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT * FROM [result]";
            DBConn.fetchDataIntoDataSet(sql, resultDataSet, "result");

            DataTable dt = resultDataSet.Tables["result"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;
            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;

            DataTable newDt = new DataTable();
            newDt.Columns.Add("DESC");
            newDt.Columns.Add("RESULT");

            foreach (DataRow mDr in resultDataSet.Tables["result"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["RESULT"] + "-" + mDr["DESC1"], mDr["RESULT"] });
            }

            comboBox_Report_Code.DataSource = newDt;

            comboBox_Report_Code.SelectedIndex = currencyManager.Position;
        }

        private void Form_ResultFileMaintenance_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void comboBox_Report_Code_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Console.WriteLine("comboBox_Report_Code_SelectionChangeCommitted");
            try
            {
                if (currencyManager.Position != comboBox_Report_Code.SelectedIndex)
                {
                    currencyManager.Position = comboBox_Report_Code.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
