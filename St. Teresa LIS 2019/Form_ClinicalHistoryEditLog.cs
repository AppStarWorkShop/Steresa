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
    public partial class Form_ClinicalHistoryEditLog : Form
    {
        private DataTable dt;
        private DataSet clinical_history_edit_logDataSet = new DataSet();
        private string case_no;

        public Form_ClinicalHistoryEditLog()
        {
            InitializeComponent();
        }

        public Form_ClinicalHistoryEditLog(string case_no)
        {
            InitializeComponent();
            loadDataGridViewDate(case_no);
            dataGridViewFormat();
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_ClinicalHistoryEditLog_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewFormat()
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void loadDataGridViewDate(string searchCaseNo)
        {
            string sql = string.Format("select [id],[case_no],[Update_Content],[UPDATE_BY],[UPDATE_AT] From [Clinical_History_Edit_Log] Where [case_no]='{0}'", searchCaseNo);
            SqlCommand checkCmd = new SqlCommand(sql, DBConn.getConnection());
            checkCmd.CommandType = CommandType.Text;

            checkCmd.CommandTimeout = 600;
            SqlDataAdapter sdap = new SqlDataAdapter();
            sdap.SelectCommand = checkCmd;
            DataTable dtDb = new DataTable();
            sdap.Fill(dtDb);

            dt = new DataTable();
            dt.Columns.Add("User");
            dt.Columns.Add("DateTime");
            dt.Columns.Add("Content");

            foreach (DataRow mDr in dtDb.Rows)
            {
                dt.Rows.Add(new object[] { mDr["update_by"], mDr["update_at"], mDr["Update_Content"] });
            }
            dataGridView1.DataSource = dt;
            dataGridViewFormat();
        }
    }
}
