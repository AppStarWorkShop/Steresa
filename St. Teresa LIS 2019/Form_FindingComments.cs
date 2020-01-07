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
    public partial class Form_FindingComments : Form
    {
        string reportWording;
        private int currentStatus;

        private DataSet cyDiagDataSet3 = new DataSet();
        private SqlDataAdapter cyDiagDataAdapter3;

        private DataSet existCyDiagDataSet3 = new DataSet();
        private SqlDataAdapter existCyDiagDataAdapter3 = null;

        private DataTable dt3;

        public delegate void FindingCommentsExit(DataSet existCyDiagDataSet3, SqlDataAdapter existCyDiagDataAdapter3);
        public FindingCommentsExit OnFindingCommentsExit;

        public Form_FindingComments()
        {
            InitializeComponent();
        }

        public Form_FindingComments(int status, DataSet existCyDiagDataSet3 = null, SqlDataAdapter existCyDiagDataAdapter3 = null)
        {
            this.currentStatus = status;
            this.existCyDiagDataSet3 = existCyDiagDataSet3;

            this.existCyDiagDataAdapter3 = existCyDiagDataAdapter3;
            InitializeComponent();
            reloadAndBindingDBDataWithExistDataSet();
            setButtonStatus(currentStatus);
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            textBox_Gynecological_History.BindingContext[dt3].Position++;
            if (OnFindingCommentsExit != null)
            {
                OnFindingCommentsExit(existCyDiagDataSet3, existCyDiagDataAdapter3);
            }
            this.Close();
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_FindingCommentsReportMaintenance open = new Form_FindingCommentsReportMaintenance();
            open.OnRecordUpdateDone += onFindingCommentsReportUpdateDone;
            open.Show();
        }

        private void onFindingCommentsReportUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadFindingCommentsReport();
            }
        }

        private void reloadFindingCommentsReport()
        {
            string findingCommentsReportSql = "SELECT [key],[description] FROM [findingCommentsReport]";
            DataSet findingCommentsReportDataSet = new DataSet();
            SqlDataAdapter findingCommentsReportDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(findingCommentsReportSql, findingCommentsReportDataSet, "findingCommentsReport");

            DataTable findingCommentsReportDt = new DataTable();
            findingCommentsReportDt.Columns.Add("key");
            findingCommentsReportDt.Columns.Add("description");

            foreach (DataRow mDr in findingCommentsReportDataSet.Tables["findingCommentsReport"].Rows)
            {
                findingCommentsReportDt.Rows.Add(new object[] { mDr["key"], mDr["description"] });
            }

            comboBox_Add.DataSource = findingCommentsReportDt;
        }

        private void reloadAndBindingDBDataWithExistDataSet()
        {
            cyDiagDataSet3 = existCyDiagDataSet3;
            cyDiagDataAdapter3 = existCyDiagDataAdapter3;

            dt3 = cyDiagDataSet3.Tables["cy_diag3"];
            dt3.PrimaryKey = new DataColumn[] { dt3.Columns["id"] };
            dt3.Columns["id"].AutoIncrement = true;
            dt3.Columns["id"].AutoIncrementStep = 1;

            textBox_Gynecological_History.DataBindings.Clear();
            comboBox_Add.DataBindings.Clear();

            string findingCommentsSql = "SELECT [key],description FROM [findingCommentsReport] order by [key]";
            DataSet findingCommentsDataSet = new DataSet();
            SqlDataAdapter findingCommentsDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(findingCommentsSql, findingCommentsDataSet, "findingCommentsReport");

            DataTable findingCommentsDt = new DataTable();
            findingCommentsDt.Columns.Add("key");
            findingCommentsDt.Columns.Add("description");

            foreach (DataRow mDr in findingCommentsDataSet.Tables["findingCommentsReport"].Rows)
            {
                findingCommentsDt.Rows.Add(new object[] { mDr["key"], mDr["description"] });
            }

            comboBox_Add.DataSource = findingCommentsDt;


            textBox_Gynecological_History.DataBindings.Add("Text", dt3, "reportContent", false);
        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;
            if (status == PageStatus.STATUS_VIEW)
            {
                textBox_Gynecological_History.Enabled = false;
                comboBox_Add.Enabled = false;
            }
            else
            {
                if (status == PageStatus.STATUS_NEW)
                {
                    textBox_Gynecological_History.Enabled = true;
                    comboBox_Add.Enabled = true;
                }
                else
                {
                    if (status == PageStatus.STATUS_EDIT)
                    {
                        textBox_Gynecological_History.Enabled = true;
                        comboBox_Add.Enabled = true;
                    }
                }
            }
        }

        private void comboBox_Add_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox_Gynecological_History.Text += comboBox_Add.SelectedValue;
        }
    }
}
