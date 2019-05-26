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
            fetchDataIntoDataSet("SELECT * FROM [medlab].[dbo].[PATIENT]");
            List<Patient> patientList = getAllPatients(patientDataSet);

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
    }
}
