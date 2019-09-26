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
    public partial class Form_SurgicalProcedure : Form
    {
        private DataSet SurgicalProcedureDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataSet SurgicalProcedureDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void SurgicalSelectedSingle(string str);
        public SurgicalSelectedSingle OnSurgicalSelectedSingle;

        public Form_SurgicalProcedure(string str)
        {
            InitializeComponent();
            textBox_Surgical_Procedure.Text = str;

            reloadAndBindingDBData();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            if (OnSurgicalSelectedSingle != null)
            {
                OnSurgicalSelectedSingle(textBox_Surgical_Procedure.Text);
            }
            this.Close();
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_SurgicalProcedureReportMaintenance open = new Form_SurgicalProcedureReportMaintenance();
            open.Show();
        }

        private void comboBox_Surgical_Procedure_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox_Surgical_Procedure.Text += comboBox_Surgical_Procedure.SelectedValue.ToString();
        }

        private void reloadAndBindingDBData()
        {
            string sqlFull = "SELECT * FROM [SurgicalProcedure] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, SurgicalProcedureDataSetFull, "SurgicalProcedure");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("SurgicalProcedureVal");

            foreach (DataRow mDr in SurgicalProcedureDataSetFull.Tables["SurgicalProcedure"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["SurgicalProcedureVal"] });
            }

            comboBox_Surgical_Procedure.DataSource = newDt;
        }
    }
}
