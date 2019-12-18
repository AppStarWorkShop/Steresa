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
    public partial class Form_LoginDigitalSignature : Form
    {
        public Form_LoginDigitalSignature()
        {
            InitializeComponent();
            loadDataGridViewDate();
            comboBox_Dr.Enabled = true;
            textBox_Password.Focus();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if (textBox_Password.Text != "")
            {
                SqlConnection conn = DBConn.getConnection();
                DataSet userDataSet = new DataSet();
                string sql = string.Format("select * FROM [USER] where user_id = '{0}' and (password='{1}' OR (password2 is not null and password2='{1}' and level > 0))", CurrentUser.currentUserId.Trim(), textBox_Password.Text.Trim());
                DBConn.fetchDataIntoDataSetSelectOnly(sql, userDataSet, "USER");

                if (userDataSet.Tables["USER"].Rows.Count > 0)
                {
                    /*
                    string selectedDoctor = "";
                    if (radioButton_Self_Cases.Checked)
                    {
                        selectedDoctor = CurrentUser.currentUserName;
                    }
                    else
                    {
                        selectedDoctor = comboBox_Dr.SelectedValue.ToString();
                    }
                    */
                    Form_DigitalSignature open = new Form_DigitalSignature(comboBox_Dr.SelectedValue.ToString());
                    open.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password");
                    textBox_Password.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please enter the password");
                textBox_Password.Focus();
            }
        }

        private void loadDataGridViewDate()
        {
            string sql = "SELECT DOCTOR FROM [sign_doctor]";
            DataSet sign_doctorDataSet = new DataSet();
            SqlDataAdapter sign_doctorDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(sql, sign_doctorDataSet, "sign_doctor");

            DataTable sign_doctorDt = new DataTable();
            sign_doctorDt.Columns.Add("DOCTOR");

            foreach (DataRow mDr in sign_doctorDataSet.Tables["sign_doctor"].Rows)
            {
                sign_doctorDt.Rows.Add(new object[] { mDr["DOCTOR"] });
            }

            comboBox_Dr.DataSource = sign_doctorDt;
        }

        
    }
}
