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
        private List<Patient> patientList;

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
        }

        private void reloadDBData()
        {
            fetchDataIntoDataSet("SELECT TOP 10 * FROM [medlab].[dbo].[PATIENT]");
            patientList = getAllPatients(patientDataSet);

            textBox_Patient.DataBindings.Add("Text", patientList, "patientName", false);
            textBox_Chinese_Name.DataBindings.Add("Text", patientList, "patientChineseName", false);
            textBox_No.DataBindings.Add("Text", patientList, "sequence", false);
            textBox_Sex.DataBindings.Add("Text", patientList, "sex", false);
            textBox_DOB.DataBindings.Add("Text", patientList, "birthday", false);
            textBox_Age.DataBindings.Add("Text", patientList, "age", false);
            textBox_HKID.DataBindings.Add("Text", patientList, "hkid", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", patientList, "updateBy", false);
            textBox_Update_At.DataBindings.Add("Text", patientList, "updateAt", false);

            currencyManager = (CurrencyManager)this.BindingContext[patientList];
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

            dataAdapter.Fill(patientDataSet, "patient");

            button_Save.Enabled = true;*/

            //patientList = new;

            /*Patient newPatient = new Patient();

            patientList.Add(newPatient);

            currencyManager.Position = currencyManager.Count - 1;

            button_Save.Enabled = true;*/

            //currencyManager.AddNew();

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
            textBox_Sex.Text = "";
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
            DataRow drow = patientDataSet.Tables["patient"].NewRow();
            //int t = dataGridView1.Rows.Count;
            drow["PATIENT"] = textBox_Patient.Text;
            drow["CNAME"] = textBox_Chinese_Name.Text;
            drow["SEQ"] = textBox_No.Text;
            drow["SEX"] = textBox_Sex.Text;
            drow["BIRTH"] = textBox_DOB.Text;
            drow["AGE"] = textBox_Age.Text;
            drow["HKID"] = textBox_HKID.Text;
            drow["UPDATE_BY"] = "Addward";
            drow["UPDATE_AT"] = DateTime.Now.ToString("");
            patientDataSet.Tables["patient"].Rows.Add(drow);

            dataAdapter.Update(patientDataSet, "patient");

            MessageBox.Show("New patient saved");

            reloadDBData();
        }
    }
}
