using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace St.Teresa_LIS_2019
{

    public partial class Form_PatientFileMaintenancecs : Form
    {
        private DataSet patientDataSet = new DataSet();
        //private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public static Boolean merge;
        public CurrencyManager currencyManager;
        private PatientStr copyPatient;
        private int currentStatus;
        private DataTable dt;

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
            open.Show();
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

        private void reloadAndBindingDBData()
        {
            //DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [PATIENT]",patientDataSet);
            DBConn.fetchDataIntoDataSet("SELECT * FROM [PATIENT]",patientDataSet);

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

            dt = patientDataSet.Tables["patient"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };

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

            currencyManager = (CurrencyManager)this.BindingContext[dt];
        }

        private void reloadDBData()
        {
            //DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [PATIENT]", patientDataSet);
            DBConn.fetchDataIntoDataSet("SELECT * FROM [PATIENT]", patientDataSet);
            DataTable dt = patientDataSet.Tables["patient"];
            currencyManager = (CurrencyManager)this.BindingContext[dt];
        }

        private List<Patient> getAllPatients(DataSet dataSet)
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
        }

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

            textBox_ID.Text = "";
            textBox_Patient.Text = "";
            textBox_Chinese_Name.Text = "";
            textBox_No.Text = "";
            textBox_Sex.Text = "M";
            datePicker_DOB.Text = "";
            textBox_Age.Text = "";
            textBox_HKID.Text = "";
            textBox_Last_Updated_By.Text = "";
            textBox_Update_At.Text = "";
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                DateTime birthDate = DateTime.Parse(datePicker_DOB.Text.ToString());

                string insertSql = string.Format("INSERT INTO PATIENT(PATIENT,CNAME,SEQ,SEX,BIRTH,AGE,HKID,UPDATE_BY,UPDATE_AT) VALUES('{0}','{1}',{2},'{3}','{4}',{5},'{6}','{7}','{8}')", textBox_Patient.Text, textBox_Chinese_Name.Text, textBox_No.Text, textBox_Sex.Text, birthDate.ToString("yyyy-MM-dd"), textBox_Age.Text, textBox_HKID.Text, "Admin", DateTime.Now.ToString("yyyy-MM-dd HH:MM"));
                if (DBConn.executeUpdate(insertSql))
                {
                    MessageBox.Show("New patient saved");
                }
                else
                {
                    MessageBox.Show("Patient updated fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DateTime birthDate = DateTime.Parse(datePicker_DOB.Text.ToString());

                    string updateSql = string.Format("UPDATE PATIENT SET  PATIENT = '{0}',CNAME='{1}',SEQ={2},SEX='{3}',BIRTH='{4}',AGE={5},HKID='{6}',UPDATE_BY='{7}',UPDATE_AT='{8}' WHERE id={9}", textBox_Patient.Text, textBox_Chinese_Name.Text, textBox_No.Text, textBox_Sex.Text, birthDate.ToString("yyyy-MM-dd"), textBox_Age.Text, textBox_HKID.Text, "Admin", DateTime.Now.ToString("yyyy-MM-dd HH:MM"), textBox_ID.Text);

                    if (DBConn.executeUpdate(updateSql))
                    {
                        MessageBox.Show("Patient updated");
                    }
                    else
                    {
                        MessageBox.Show("Patient updated fail, please contact Admin");
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
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

                textBox_Patient.Enabled = false;
                textBox_Chinese_Name.Enabled = false;
                textBox_No.Enabled = false;
                textBox_Sex.Enabled = false;
                datePicker_DOB.Enabled = false;
                textBox_Age.Enabled = false;
                textBox_HKID.Enabled = false;
                
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

                    textBox_Patient.Enabled = true;
                    textBox_Chinese_Name.Enabled = true;
                    textBox_No.Enabled = true;
                    textBox_Sex.Enabled = true;
                    datePicker_DOB.Enabled = true;
                    textBox_Age.Enabled = true;
                    textBox_HKID.Enabled = true;
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

                        textBox_Patient.Enabled = true;
                        textBox_Chinese_Name.Enabled = true;
                        textBox_No.Enabled = true;
                        textBox_Sex.Enabled = true;
                        datePicker_DOB.Enabled = true;
                        textBox_Age.Enabled = true;
                        textBox_HKID.Enabled = true;
                    }
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copyPatient = new PatientStr();
            copyPatient.patientName = textBox_Patient.Text;
            copyPatient.patientChineseName = textBox_Chinese_Name.Text;
            copyPatient.sequence = textBox_No.Text;
            copyPatient.sex = textBox_Sex.Text;
            copyPatient.birthday = datePicker_DOB.Text;
            copyPatient.age = textBox_Age.Text;
            copyPatient.hkid = textBox_HKID.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
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
    }
}
