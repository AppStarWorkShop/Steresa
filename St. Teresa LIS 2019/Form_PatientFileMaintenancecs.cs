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
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.medlabConnectionString);
        private DataSet patientDataSet = new DataSet();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public static Boolean merge;
        public CurrencyManager currencyManager;
        private DataRow newDr;
        private DataRow copyDr;
        //private List<Patient> patientList;
        private int currentStatus;

        public class Patient
        {
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
            reloadDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void reloadDBData()
        {
            fetchDataIntoDataSet("SELECT TOP 10 * FROM [medlab].[dbo].[PATIENT]");
            /*patientList = getAllPatients(patientDataSet);

            textBox_Patient.DataBindings.Add("Text", patientList, "patientName", false);
            textBox_Chinese_Name.DataBindings.Add("Text", patientList, "patientChineseName", false);
            textBox_No.DataBindings.Add("Text", patientList, "sequence", false);
            textBox_Sex.DataBindings.Add("Text", patientList, "sex", false);
            textBox_DOB.DataBindings.Add("Text", patientList, "birthday", false);
            textBox_Age.DataBindings.Add("Text", patientList, "age", false);
            textBox_HKID.DataBindings.Add("Text", patientList, "hkid", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", patientList, "updateBy", false);
            textBox_Update_At.DataBindings.Add("Text", patientList, "updateAt", false);
            
             
             currencyManager = (CurrencyManager)this.BindingContext[patientList];*/


            DataTable dt = patientDataSet.Tables["patient"];

            textBox_Patient.DataBindings.Add("Text", dt, "PATIENT", false);
            textBox_Chinese_Name.DataBindings.Add("Text", dt, "CNAME", false);
            textBox_No.DataBindings.Add("Text", dt, "SEQ", false);
            textBox_Sex.DataBindings.Add("Text", dt, "SEX", false);
            textBox_DOB.DataBindings.Add("Text", dt, "BIRTH", false);
            textBox_Age.DataBindings.Add("Text", dt, "AGE", false);
            textBox_HKID.DataBindings.Add("Text", dt, "HKID", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);

            currencyManager = (CurrencyManager)this.BindingContext[dt];
        }

        private void fetchDataIntoDataSet(string selectCommand)
        {
            try
            {
                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connection);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                dataAdapter.Fill(patientDataSet, "patient");
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private List<Patient> getAllPatients(DataSet dataSet)
        {
            DataTable dt = patientDataSet.Tables["patient"];
            return dt.AsEnumerable().Select(dataRow => new Patient {
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
            /*newDr = patientDataSet.Tables["patient"].NewRow();
            int currentPosition = patientDataSet.Tables["patient"].Rows.IndexOf(newDr);
            currencyManager.Position = currentPosition;

            dataAdapter.Fill(patientDataSet, "patient");*/

            //patientList = new;

            /*Patient newPatient = new Patient();

            patientList.Add(newPatient);

            currencyManager.Position = currencyManager.Count - 1;

            button_Save.Enabled = true;*/

            //currencyManager.AddNew();

            setButtonStatus(PageStatus.STATUS_NEW);

            textBox_Patient.DataBindings.Clear();
            textBox_Chinese_Name.DataBindings.Clear();
            textBox_No.DataBindings.Clear();
            textBox_Sex.DataBindings.Clear();
            textBox_DOB.DataBindings.Clear();
            textBox_Age.DataBindings.Clear();
            textBox_HKID.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();

            textBox_Patient.Text = "";
            textBox_Chinese_Name.Text = "";
            textBox_No.Text = "";
            textBox_Sex.Text = "M";
            textBox_DOB.Text = "";
            textBox_Age.Text = "";
            textBox_HKID.Text = "";
            textBox_Last_Updated_By.Text = "";
            textBox_Update_At.Text = "";

            //this.BindingContext.
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            //dataAdapter.Update(patientDataSet, "patient");
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                DataRow drow = patientDataSet.Tables["patient"].NewRow();
                //int t = dataGridView1.Rows.Count;
                drow["PATIENT"] = textBox_Patient.Text;
                drow["CNAME"] = textBox_Chinese_Name.Text;
                drow["SEQ"] = textBox_No.Text;
                drow["SEX"] = textBox_Sex.Text;
                drow["BIRTH"] = textBox_DOB.Text;
                drow["AGE"] = textBox_Age.Text;
                drow["HKID"] = textBox_HKID.Text;
                drow["UPDATE_BY"] = "Addward";//TODO: set the current login user here
                drow["UPDATE_AT"] = DateTime.Now.ToString("");
                patientDataSet.Tables["patient"].Rows.Add(drow);
                dataAdapter.Update(patientDataSet, "patient");

                MessageBox.Show("New patient saved");

                reloadDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    //DataRow drow = patientDataSet.Tables["patient"].Rows.Find("LEUNG BARBARA JOYCE");
                    dataAdapter.Update(patientDataSet, "patient");
                    MessageBox.Show("patient updated");
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
                textBox_DOB.Enabled = false;
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
                    textBox_DOB.Enabled = true;
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
                        textBox_DOB.Enabled = true;
                        textBox_Age.Enabled = true;
                        textBox_HKID.Enabled = true;
                    }
                }
            }
        }

        public class PageStatus
        {
            public const int STATUS_VIEW = 1;
            public const int STATUS_NEW = 2;
            public const int STATUS_EDIT = 3;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            copyDr = patientDataSet.Tables["patient"].NewRow();
            copyDr["PATIENT"] = textBox_Patient.Text;
            copyDr["CNAME"] = textBox_Chinese_Name.Text;
            copyDr["SEQ"] = textBox_No.Text;
            copyDr["SEX"] = textBox_Sex.Text;
            copyDr["BIRTH"] = textBox_DOB.Text;
            copyDr["AGE"] = textBox_Age.Text;
            copyDr["HKID"] = textBox_HKID.Text;
            //copyDr["UPDATE_BY"] = textBox_Last_Updated_By;
            //copyDr["UPDATE_AT"] = textBox_Update_At;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                textBox_Patient.Text = "";
                textBox_Chinese_Name.Text = "";
                textBox_No.Text = "";
                textBox_Sex.Text = "M";
                textBox_DOB.Text = "";
                textBox_Age.Text = "";
                textBox_HKID.Text = "";
                textBox_Last_Updated_By.Text = "";
                textBox_Update_At.Text = "";
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if(copyDr != null)
                    {
                        textBox_Patient.Text = copyDr["PATIENT"].ToString();
                        textBox_Chinese_Name.Text = copyDr["CNAME"].ToString();
                        textBox_No.Text = copyDr["SEQ"].ToString();
                        textBox_Sex.Text = copyDr["SEX"].ToString();
                        textBox_DOB.Text = copyDr["BIRTH"].ToString();
                        textBox_Age.Text = copyDr["AGE"].ToString();
                        textBox_HKID.Text = copyDr["HKID"].ToString();
                    }
                }
            }
        }
    }
}
