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
    public partial class Form_Cobas4800System : Form
    {
        private int currentStatus;
        private string caseNo;
        private string bxcy_diag_id;
        private DataSet bxcy_diagDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataTable dt;
        private DataRow currentEditRow;

        private DataSet bxcy_specimenDataSet = new DataSet();
        private DataTable bxcy_specimentDt;
        private SqlDataAdapter bxcy_specimentDataAdapter;

        public Form_Cobas4800System()
        {
            InitializeComponent();
        }

        public Form_Cobas4800System(string idStr)
        {
            bxcy_diag_id = idStr;
            InitializeComponent();
            reloadAndBindingDBData();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [BXCY_DIAG] ORDER BY ID");
            if (bxcy_diag_id != null && bxcy_diag_id != "")
            {
                sql = string.Format("SELECT TOP 1 * FROM [BXCY_DIAG] WHERE id = {0}", bxcy_diag_id);
            }
            
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");

            dt = bxcy_diagDataSet.Tables["bxcy_diag"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Clear();
            textBox_Test_Date.DataBindings.Clear();
            textBox_Test_Type.DataBindings.Clear();
            textBox_Test_Result.DataBindings.Clear();
            comboBox_HPVOHR.DataBindings.Clear();
            comboBox_HPV16.DataBindings.Clear();
            comboBox_HPV18.DataBindings.Clear();
            textBox_Test_result_was_downloaded_at.DataBindings.Clear();
            textBox_By.DataBindings.Clear();
            textBox_Remarks.DataBindings.Clear();

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Test_Date.DataBindings.Add("Text", dt, "Hpv_date", true, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy/MM/dd hh:mm:ss");
            textBox_Test_Type.DataBindings.Add("Text", dt, "Hpv_type", false);
            textBox_Test_Result.DataBindings.Add("Text", dt, "Hpv_result", false);
            comboBox_HPVOHR.DataBindings.Add("Text", dt, "Hpvohr", false);
            comboBox_HPV16.DataBindings.Add("Text", dt, "Hpv16", false);
            comboBox_HPV18.DataBindings.Add("Text", dt, "Hpv18", false);
            textBox_Test_result_was_downloaded_at.DataBindings.Add("Text", dt, "Hpv_Gen_at", false);
            textBox_By.DataBindings.Add("Text", dt, "Hpv_Gen_by", false);
            textBox_Remarks.DataBindings.Add("Text", dt, "Hpv_remark", false);
        }
    }
}
