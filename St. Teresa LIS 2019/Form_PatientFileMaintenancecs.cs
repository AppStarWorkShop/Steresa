using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Collections.Generic;

namespace St.Teresa_LIS_2019
{

    public partial class Form_PatientFileMaintenancecs : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.medlabConnectionString);
        private DataSet patientDataSet = new DataSet();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public static Boolean merge;
        List<Patient> patientList { get; set; }
        public CurrencyManager bm;

        public class Patient
        {
            public string name { get; set; }
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
            // TODO: 这行代码将数据加载到表“medlabDataSet2.PATIENT”中。您可以根据需要移动或删除它。
            initDataSet("SELECT * FROM [medlab].[dbo].[PATIENT]");
            patientList = getAllPatients(patientDataSet);

            textBox_Patient.DataBindings.Add("Text", patientList, "name", false);

            bm = (CurrencyManager)this.BindingContext[patientList];
            /*
            connection.Open();
            string selectQuery = "SELECT * FROM [medlab].[dbo].[PATIENT]";
            command = new SqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {

            }
            connection.Close();
            */
        }

        private void initDataSet(string selectCommand) 
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

                // Resize the DataGridView columns to fit the newly loaded content.
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
            patientList = new List<Patient>();
            DataTable dt = patientDataSet.Tables["patient"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["PATIENT"].ToString();
                Patient p = new Patient();
                p.name = name;
                patientList.Add(p);
            }
            
            return patientList;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            bm.Position++;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            bm.Position--;
        }
    }
}
