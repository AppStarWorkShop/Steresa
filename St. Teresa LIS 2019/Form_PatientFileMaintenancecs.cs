using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace St.Teresa_LIS_2019
{

    public partial class Form_PatientFileMaintenancecs : Form
    {
        private DataSet patientDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        public static Boolean merge;
        public CurrencyManager currencyManager;
        private PatientStr copyPatient;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;

        public class Patient
        {
            public int id { get; set; }
            public string patientName { get; set; }
            public string patientChineseName { get; set; }
            public Double? sequence { get; set; }
            public string sex { get; set; }
            public DateTime? birthday { get; set; }
            public Double? age { get; set; }
            public string hkid { get; set; }
            public string updateBy { get; set; }
            public DateTime? updateAt { get; set; }
            public string updateCtr { get; set; }
            public string updated { get; set; }
        }

        public class PatientStr
        {
            public int id { get; set; }
            public string patientName { get; set; }
            public string patientChineseName { get; set; }
            public string sequence { get; set; }
            public string sex { get; set; }
            public string birthday { get; set; }
            public string age { get; set; }
            public string hkid { get; set; }
            public string updateBy { get; set; }
            public string updateAt { get; set; }
            public string updateCtr { get; set; }
            public string updated { get; set; }
        }

        public Form_PatientFileMaintenancecs()
        {
            InitializeComponent();
        }

        private void button_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            merge = false;
            Form_SelectPatient open = new Form_SelectPatient();
            open.OnPatientSelectedMore += OnPatientSelected;
            open.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.F1)
            {
                button_F1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OnPatientSelected(string idStr)
        {
            if (idStr != null)
            {
                string sql = string.Format("SELECT * FROM [PATIENT] WHERE ID IN({0})", idStr);
                DBConn.fetchDataIntoDataSet(sql, patientDataSet, "patient");

                DataTable dt = patientDataSet.Tables["patient"];
                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                dt.Columns["id"].AutoIncrement = true;
                dt.Columns["id"].AutoIncrementStep = 1;
                currencyManager = (CurrencyManager)this.BindingContext[dt];

                currencyManager.Position = 0;
            }
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            merge = true;
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
        }

        private void Form_PatientFileMaintenancecs_Load(object sender, EventArgs e)
        {
            // fetch patient data
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            //DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [PATIENT]",patientDataSet);
            string sql = "SELECT * FROM [PATIENT]";
            //string sql = string.Format("SELECT * FROM [PATIENT] WHERE ID IN({0})", "1,2,3,4,6,7,8,9,10");
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, patientDataSet, "patient");

            textBox_ID.DataBindings.Clear();
            textBox_Patient.DataBindings.Clear();
            textBox_Chinese_Name.DataBindings.Clear();
            textBox_No.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            datePicker_DOB.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_HKID.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            dt = patientDataSet.Tables["patient"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Patient.DataBindings.Add("Text", dt, "PATIENT", false);
            textBox_Chinese_Name.DataBindings.Add("Text", dt, "CNAME", false);
            textBox_No.DataBindings.Add("Text", dt, "SEQ", false);
            textBox_Sex.DataBindings.Add("Text", dt, "SEX", false);
            datePicker_DOB.DataBindings.Add("Text", dt, "BIRTH", false);
            textBox_Age.DataBindings.Add("Text", dt, "AGE", false);
            textBox_HKID.DataBindings.Add("Text", dt, "HKID", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);

            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;
        }

        private void reloadDBData(int position = 0)
        {
            //DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [PATIENT]", patientDataSet);
            string sql = "SELECT * FROM [PATIENT]";
            //string sql = string.Format("SELECT * FROM [PATIENT] WHERE ID IN({0})", "1,2,3,4,5,6,7,8,9,10");
            DBConn.fetchDataIntoDataSet(sql, patientDataSet,"patient");

            DataTable dt = patientDataSet.Tables["patient"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;
            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;
        }

        /*private List<Patient> getAllPatients(DataSet dataSet)
        {
            dt = patientDataSet.Tables["patient"];

            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };

            return dt.AsEnumerable().Select(dataRow => new Patient {
                id = dataRow.Field<int>("id"),
                patientName = dataRow.Field<string>("PATIENT"),
                patientChineseName = dataRow.Field<string>("CNAME"),
                sequence = dataRow.Field<double>("SEQ"),
                sex = dataRow.Field<string>("SEX"),
                birthday = dataRow.Field<DateTime?>("BIRTH"),
                age = dataRow.Field<Double?>("AGE"),
                hkid = dataRow.Field<string>("HKID"),
                updateBy = dataRow.Field<string>("UPDATE_BY"),
                updateAt = dataRow.Field<DateTime?>("UPDATE_AT"),
                updateCtr = dataRow.Field<string>("UPDATE_CTR"),
                updated = dataRow.Field<string>("UPDATED")
            }).ToList();
        }*/

        private void button_Next_Click(object sender, EventArgs e)
        {
            currencyManager.Position++;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            currencyManager.Position--;
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            currencyManager.Position = 0;
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            /*textBox_ID.DataBindings.Clear();
            textBox_Patient.DataBindings.Clear();
            textBox_Chinese_Name.DataBindings.Clear();
            textBox_No.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            datePicker_DOB.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_HKID.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();

            textBox_ID.Text = "";
            textBox_Patient.Text = "";
            textBox_Chinese_Name.Text = "";
            textBox_No.Text = "";
            textBox_Sex.Text = "M";
            datePicker_DOB.Text = "";
            textBox_Age.Text = "0";
            textBox_HKID.Text = "";
            textBox_Last_Updated_By.Text = "";
            textBox_Update_At.Text = "";*/

            currentEditRow = patientDataSet.Tables["patient"].NewRow();
            currentEditRow["id"] = -1;
            currentEditRow["AGE"] = 0;
            currentEditRow["SEX"] = "M";
            patientDataSet.Tables["patient"].Rows.Add(currentEditRow);

            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                //DateTime birthDate = DateTime.Parse(datePicker_DOB.Text.ToString());

                /*string insertSql = string.Format("INSERT INTO PATIENT(PATIENT,CNAME,SEQ,SEX,BIRTH,AGE,HKID,UPDATE_BY,UPDATE_AT) VALUES('{0}','{1}',{2},'{3}','{4}',{5},'{6}','{7}','{8}')", textBox_Patient.Text, textBox_Chinese_Name.Text, textBox_No.Text, textBox_Sex.Text, birthDate.ToString("yyyy-MM-dd"), textBox_Age.Text, textBox_HKID.Text, "Admin", DateTime.Now.ToString("yyyy-MM-dd HH:MM"));
                if (DBConn.executeUpdate(insertSql))
                {
                    MessageBox.Show("New patient saved");
                }
                else
                {
                    MessageBox.Show("Patient updated fail, please contact Admin");
                }*/

                /*DataRow drow = patientDataSet.Tables["patient"].NewRow();
                drow["PATIENT"] = textBox_Patient.Text;
                drow["CNAME"] = textBox_Chinese_Name.Text;
                drow["SEQ"] = textBox_No.Text;
                drow["SEX"] = textBox_Sex.Text;
                drow["BIRTH"] = birthDate;
                drow["AGE"] = textBox_Age.Text;
                drow["HKID"] = textBox_HKID.Text;*/

                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = "Admin";
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");
                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, patientDataSet, "patient"))
                    {
                        reloadDBData(currencyManager.Count - 1);
                        MessageBox.Show("New patient saved");
                    }
                    else
                    {
                        MessageBox.Show("Patient saved fail, please contact Admin");
                    }
                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
                //reloadAndBindingDBData(currencyManager.Count - 1);
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    //DateTime birthDate = DateTime.Parse(datePicker_DOB.Text.ToString());

                    /*string updateSql = string.Format("UPDATE PATIENT SET  PATIENT = '{0}',CNAME='{1}',SEQ={2},SEX='{3}',BIRTH='{4}',AGE={5},HKID='{6}',UPDATE_BY='{7}',UPDATE_AT='{8}' WHERE id={9}", textBox_Patient.Text, textBox_Chinese_Name.Text, textBox_No.Text, textBox_Sex.Text, birthDate.ToString("yyyy-MM-dd"), textBox_Age.Text, textBox_HKID.Text, "Admin", DateTime.Now.ToString("yyyy-MM-dd HH:MM"), textBox_ID.Text);

                    if (DBConn.executeUpdate(updateSql))
                    {
                        MessageBox.Show("Patient updated");
                    }
                    else
                    {
                        MessageBox.Show("Patient updated fail, please contact Admin");
                    }*/

                    DataRow drow = patientDataSet.Tables["patient"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        /*drow["PATIENT"] = textBox_Patient.Text;
                        drow["CNAME"] = textBox_Chinese_Name.Text;
                        drow["SEQ"] = textBox_No.Text;
                        drow["SEX"] = textBox_Sex.Text;
                        drow["BIRTH"] = birthDate;
                        drow["AGE"] = textBox_Age.Text;
                        drow["HKID"] = textBox_HKID.Text;*/
                        drow["UPDATE_BY"] = "Admin";
                        drow["UPDATE_AT"] = DateTime.Now.ToString("");
                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, patientDataSet, "patient"))
                        {
                            MessageBox.Show("Patient updated");
                        }
                        else
                        {
                            MessageBox.Show("Patient updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    //reloadAndBindingDBData(currentPosition);
                }
            }
        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;

            if (status == PageStatus.STATUS_VIEW) { 
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

                textBox_Patient.Enabled = false;
                textBox_Chinese_Name.Enabled = false;
                textBox_No.Enabled = false;
                textBox_Sex.Enabled = false;
                datePicker_DOB.Enabled = false;
                textBox_Age.Enabled = false;
                textBox_HKID.Enabled = false;
                textBox_Update_At.Enabled = false;

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

                    textBox_Patient.Enabled = true;
                    textBox_Chinese_Name.Enabled = true;
                    textBox_No.Enabled = true;
                    textBox_Sex.Enabled = true;
                    datePicker_DOB.Enabled = true;
                    textBox_Age.Enabled = true;
                    textBox_HKID.Enabled = true;
                    textBox_Update_At.Enabled = true;

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

                        textBox_Patient.Enabled = true;
                        textBox_Chinese_Name.Enabled = true;
                        textBox_No.Enabled = true;
                        textBox_Sex.Enabled = true;
                        datePicker_DOB.Enabled = true;
                        textBox_Age.Enabled = true;
                        textBox_HKID.Enabled = true;
                        textBox_Update_At.Enabled = false;

                        edit_modle();
                    }
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            currentPosition = currencyManager.Position;

            copyPatient = new PatientStr();
            copyPatient.patientName = textBox_Patient.Text;
            copyPatient.patientChineseName = textBox_Chinese_Name.Text;
            copyPatient.sequence = textBox_No.Text;
            copyPatient.sex = textBox_Sex.Text;
            copyPatient.birthday = datePicker_DOB.Text;
            copyPatient.age = textBox_Age.Text;
            copyPatient.hkid = textBox_HKID.Text;

            /*textBox_ID.DataBindings.Clear();
            textBox_Patient.DataBindings.Clear();
            textBox_Chinese_Name.DataBindings.Clear();
            textBox_No.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            datePicker_DOB.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_HKID.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();*/

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    patientDataSet.Tables["patient"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                //reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if(copyPatient != null)
                    {
                        textBox_Patient.Text = copyPatient.patientName;
                        textBox_Chinese_Name.Text = copyPatient.patientChineseName;
                        textBox_No.Text = copyPatient.sequence;
                        textBox_Sex.Text = copyPatient.sex;
                        datePicker_DOB.Text = copyPatient.birthday;
                        textBox_Age.Text = copyPatient.age;
                        textBox_HKID.Text = copyPatient.hkid;
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM PATIENT WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    currencyManager.Position = 0;

                    reloadDBData(0);
                    MessageBox.Show("Patient deleted");
                }
                else
                {
                    MessageBox.Show("Patient deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
                //reloadDBData();
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

        private void datePicker_DOB_ValueChanged(object sender, EventArgs e)
        {
            int age = CommonFunction.GetAgeByBirthdate(datePicker_DOB.Value);
            textBox_Age.Text = age.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadDBData();
        }
    }
}
