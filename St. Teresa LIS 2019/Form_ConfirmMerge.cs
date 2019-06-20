using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace St.Teresa_LIS_2019
{
    public partial class Form_ConfirmMerge : Form
    {
        private string masterIDStr;
        private string slaveIDStr;
        private DataSet patientDataSet = new DataSet();

        public delegate void PatientMerge(bool result);
        public PatientMerge OnPatientMerge;

        public Form_ConfirmMerge()
        {
            InitializeComponent();
        }

        public Form_ConfirmMerge(string masterIDStr, string slaveIDStr)
        {
            this.masterIDStr = masterIDStr;
            this.slaveIDStr = slaveIDStr;
            //this.dataSet = dataSet;
            InitializeComponent();
        }

        private void Form_ConfirmMerge_Load(object sender, EventArgs e)
        {
            dataGridViewInputTestDate();
            dataGridViewFormat();
        }

        private void dataGridViewInputTestDate()
        {
            string masterSql = string.Format("SELECT patient,cname,hkid,seq,sex,birth,age,id FROM [PATIENT] WHERE ID IN({0})", masterIDStr);
            DBConn.fetchDataIntoDataSetSelectOnly(masterSql, patientDataSet, "patient");

            if(patientDataSet.Tables["patient"].Rows.Count > 0)
            {
                DataRow mDr = patientDataSet.Tables["patient"].Rows[0];
                textBox_Patient.Text = mDr["patient"].ToString();
                textBox_Chinese_Name.Text = mDr["cname"].ToString();
                textBox_HKID.Text = mDr["hkid"].ToString();
                textBox_No.Text = mDr["seq"].ToString();
                textBox_Sex.Text = mDr["sex"].ToString();
                textBox_DOB.Text = mDr["birth"].ToString();
                textBox_Age.Text = mDr["age"].ToString();
                textBox_ID.Text = mDr["Id"].ToString();
            }

            string slaveSql = string.Format("SELECT patient,cname,hkid,seq,sex,birth,age,id FROM [PATIENT] WHERE ID IN({0})", slaveIDStr);
            DBConn.fetchDataIntoDataSetSelectOnly(slaveSql, patientDataSet, "patient");

            DataTable dt = new DataTable();

            dt.Columns.Add("Patient's Name");
            dt.Columns.Add("Chinese Name");
            dt.Columns.Add("HKid");
            dt.Columns.Add("No.");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Birth");
            dt.Columns.Add("Age");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in patientDataSet.Tables["patient"].Rows)
            {
                dt.Rows.Add(new object[] { mDr["patient"], mDr["cname"], mDr["hkid"], mDr["seq"], mDr["sex"], mDr["birth"], mDr["age"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 190;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 145;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 90;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 90;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 90;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 160;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 90;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 1;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            /*Form_PatientFileMaintenancecs.merge = true;
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
            this.Hide();*/
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            bool result = false;
            string updateMasterSql = string.Format("UPDATE [PATIENT] set [master] = null WHERE id={0}",textBox_ID.Text);
            string updateSlaveSql = string.Format("UPDATE [PATIENT] set [master] = {0} WHERE id in ({1})", textBox_ID.Text, slaveIDStr);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = DBConn.getConnection();
            SqlTransaction tran = sqlCmd.Connection.BeginTransaction();
            sqlCmd.Transaction = tran;
            try
            {
                sqlCmd.CommandText = updateMasterSql;
                if (sqlCmd.ExecuteNonQuery() > 0)
                {
                    sqlCmd.CommandText = updateSlaveSql;
                    if (sqlCmd.ExecuteNonQuery() > 0)
                    {
                        result = true;
                        tran.Commit();
                        MessageBox.Show("Merge finished");
                        OnPatientMerge(result);
                        this.Close();
                    }
                    else
                    {
                        tran.Rollback();
                        MessageBox.Show("Fail to merge the slave record");
                    }
                }
                else
                {
                    tran.Rollback();
                    MessageBox.Show("Fail to merge the master record");
                }
            }
            catch (Exception)
            {
                tran.Rollback();
                MessageBox.Show("Fail to merge the records");
            }
        }
    }
}
