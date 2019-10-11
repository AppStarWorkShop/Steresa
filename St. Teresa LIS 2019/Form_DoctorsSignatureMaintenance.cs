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
    public partial class Form_DoctorsSignatureMaintenance : Form
    {
        private DataSet sign_doctorDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private sign_doctorStr copysign_doctor;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;
        private string searchsign_doctor;

        private DataSet sign_doctorDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public class sign_doctor
        {
            public int id { get; set; }
            public string DOC_NO { get; set; }
            public string DOCTOR { get; set; }
            public string SIGN_IMG { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public class sign_doctorStr
        {
            public int id { get; set; }
            public string DOC_NO { get; set; }
            public string DOCTOR { get; set; }
            public string SIGN_IMG { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
        }

        public Form_DoctorsSignatureMaintenance()
        {
            InitializeComponent();
            reloadAndBindingDBData();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //currencyManager.Position++;
            string countSql = string.Format(" [sign_doctor] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [sign_doctor] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, sign_doctorDataSet, "sign_doctor");
            }

            if (sign_doctorDataSet != null && sign_doctorDataSet != null && sign_doctorDataSet.Tables["sign_doctor"].Rows.Count > 0)
            {
                resetDDLValue(sign_doctorDataSet.Tables["sign_doctor"].Rows[0]["DOCTOR"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            //currencyManager.Position--;
            string countSql = string.Format(" [sign_doctor] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [sign_doctor] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, sign_doctorDataSet, "sign_doctor");
            }

            if (sign_doctorDataSet != null && sign_doctorDataSet != null && sign_doctorDataSet.Tables["sign_doctor"].Rows.Count > 0)
            {
                resetDDLValue(sign_doctorDataSet.Tables["sign_doctor"].Rows[0]["MICROSCOPIC"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [sign_doctor] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, sign_doctorDataSet, "sign_doctor");

            if (sign_doctorDataSet != null && sign_doctorDataSet != null && sign_doctorDataSet.Tables["sign_doctor"].Rows.Count > 0)
            {
                resetDDLValue(sign_doctorDataSet.Tables["sign_doctor"].Rows[0]["MICROSCOPIC"].ToString());
            }
            //checkMasterEngName();
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 * FROM [sign_doctor] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, sign_doctorDataSet, "sign_doctor");

            if (sign_doctorDataSet != null && sign_doctorDataSet != null && sign_doctorDataSet.Tables["sign_doctor"].Rows.Count > 0)
            {
                resetDDLValue(sign_doctorDataSet.Tables["sign_doctor"].Rows[0]["MICROSCOPIC"].ToString());
            }
            //checkMasterEngName();
        }

        private void resetDDLValue(string searchDOCTOR)
        {
            if (searchDOCTOR != null)
            {
                comboBox_Doctor.SelectedValue = searchDOCTOR;
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
                    currentEditRow["MICROSCOPIC"] = comboBox_Doctor.Text;
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, sign_doctorDataSet, "sign_doctor"))
                    {
                        reloadAndBindingDBData();
                        //comboBox_Diagnosis.SelectedIndex = currentPosition+1;
                        MessageBox.Show("New MICROSCOPIC Report saved");
                    }
                    else
                    {
                        MessageBox.Show("MICROSCOPIC Report saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = sign_doctorDataSet.Tables["sign_doctor"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        drow["MICROSCOPIC"] = comboBox_Doctor.Text;
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, sign_doctorDataSet, "sign_doctor"))
                        {
                            reloadAndBindingDBData();
                            //comboBox_Diagnosis.SelectedIndex = currentPosition;
                            MessageBox.Show("MICROSCOPIC Report updated");
                        }
                        else
                        {
                            MessageBox.Show("MICROSCOPIC Report updated fail, please contact Admin");
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
            if (comboBox_Doctor.Items.Count > 0)
            {
                comboBox_Doctor.SelectedIndex = 0;
            }
            setButtonStatus(PageStatus.STATUS_NEW);

            comboBox_Doctor.Text = "";
            textBox_Doctor_No.Text = "";
            textBox_Sign_Img.Text = "";

            currentEditRow = sign_doctorDataSet.Tables["sign_doctor"].NewRow();
            currentEditRow["id"] = -1;

            sign_doctorDataSet.Clear();
            sign_doctorDataSet.Tables["sign_doctor"].Rows.Add(currentEditRow);
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copysign_doctor = new sign_doctorStr();
            copysign_doctor.DOCTOR = comboBox_Doctor.Text;
            copysign_doctor.DOC_NO = textBox_Doctor_No.Text;
            copysign_doctor.SIGN_IMG = textBox_Sign_Img.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM sign_doctor WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();

                    reloadDBData();
                    MessageBox.Show("MICROSCOPIC Report deleted");
                }
                else
                {
                    MessageBox.Show("MICROSCOPIC Report deleted fail, please contact Admin");
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
                    sign_doctorDataSet.Tables["sign_doctor"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copysign_doctor != null)
                    {
                        comboBox_Doctor.Text = copysign_doctor.DOCTOR;
                        textBox_Doctor_No.Text = copysign_doctor.DOC_NO;
                        textBox_Sign_Img.Text = copysign_doctor.SIGN_IMG;
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

                textBox_Doctor_No.Enabled = false;
                textBox_Sign_Img.Enabled = false;

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

                    textBox_Doctor_No.Enabled = true;
                    textBox_Sign_Img.Enabled = true;

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

                        textBox_Doctor_No.Enabled = true;
                        textBox_Sign_Img.Enabled = true;

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

        private void reloadAndBindingDBData(string searchDoctor = null)
        {
            string sql = "SELECT TOP 1 * FROM [sign_doctor] ORDER BY ID";
            if (searchDoctor != null)
            {
                sql = string.Format("SELECT TOP 1 * FROM [sign_doctor] WHERE Doctor = '{0}' ORDER BY ID", searchDoctor);
            }
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, sign_doctorDataSet, "sign_doctor");

            textBox_ID.DataBindings.Clear();
            textBox_Doctor_No.DataBindings.Clear();
            textBox_Sign_Img.DataBindings.Clear();
            /*textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();*/

            dt = sign_doctorDataSet.Tables["sign_doctor"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Doctor_No.DataBindings.Add("Text", dt, "DOC_NO", false);
            textBox_Sign_Img.DataBindings.Add("Text", dt, "SIGN_IMG", false);
            /*textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);*/

            string sqlFull = "SELECT * FROM [sign_doctor] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, sign_doctorDataSetFull, "sign_doctor");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("DOCTOR");

            foreach (DataRow mDr in sign_doctorDataSetFull.Tables["sign_doctor"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Doctor.DataSource = newDt;

            if (comboBox_Doctor.Items.Count > 0)
            {
                comboBox_Doctor.SelectedIndex = 0;
            }

            if (searchDoctor != null && comboBox_Doctor.Items.Count > 0)
            {
                int currentPosition = 0;
                foreach (DataRow mDr in dt.Rows)
                {
                    if (mDr["DOCTOR"].ToString().Trim() == searchDoctor.Trim())
                    {
                        break;
                    }
                    currentPosition++;
                }
                comboBox_Doctor.SelectedIndex = currentPosition;
            }
        }

        private void reloadDBData(int position = 0)
        {
            string sql = "SELECT TOP 1 * FROM [sign_doctor] ORDER BY ID";
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, sign_doctorDataSet, "sign_doctor");

            dt = sign_doctorDataSet.Tables["sign_doctor"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            string sqlFull = "SELECT * FROM [sign_doctor] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, sign_doctorDataSetFull, "sign_doctor");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("DOCTOR");

            foreach (DataRow mDr in sign_doctorDataSetFull.Tables["sign_doctor"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Doctor.DataSource = newDt;
            if (comboBox_Doctor.Items.Count > 0)
            {
                comboBox_Doctor.SelectedIndex = 0;
            }
        }

        private void comboBox_Doctor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [sign_doctor] WHERE DOCTOR = '{0}' ORDER BY ID", comboBox_Doctor.SelectedValue.ToString());
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, sign_doctorDataSet, "sign_doctor");
            textBox_ID.DataBindings.Clear();
            textBox_Doctor_No.DataBindings.Clear();
            textBox_Sign_Img.DataBindings.Clear();

            dt = sign_doctorDataSet.Tables["sign_doctor"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Doctor_No.DataBindings.Add("Text", dt, "DOC_NO", false);
            textBox_Sign_Img.DataBindings.Add("Text", dt, "SIGN_IMG", false);
        }
    }
}
