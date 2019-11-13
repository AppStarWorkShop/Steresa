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
    public partial class Form_CytologyFindings : Form
    {
        private int currentStatus;
        private string caseNo;
        private string bxcy_id;
        private DataSet bxcy_diagDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataTable dt;

        private DataSet bxcy_specimenDataSet = new DataSet();
        private DataTable bxcy_specimentDt;
        private SqlDataAdapter bxcy_specimentDataAdapter;

        private DataRow currentEditRow;

        public delegate void BxcyDiagExit();
        public BxcyDiagExit OnBxcyDiagExit;

        public Form_CytologyFindings()
        {
            InitializeComponent();
        }

        public Form_CytologyFindings(string caseNo, string bxcy_id)
        {
            this.caseNo = caseNo;
            this.bxcy_id = bxcy_id;
            InitializeComponent();
        }

        private void button_Back_To_Main_Click(object sender, EventArgs e)
        {
            bool updated = true;
            bool refreshMainPage = false;
            if (textBox_ID.Text.Trim() == "-1")
            {
                if (currentEditRow != null)
                {
                    currentEditRow["case_no"] = this.caseNo;

                    textBox_ID.BindingContext[dt].Position++;

                    if (!DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "BXCY_DIAG"))
                    {
                        updated = false;
                    }
                }
            }
            else
            {
                DataRow drow = bxcy_diagDataSet.Tables["BXCY_DIAG"].Rows.Find(textBox_ID.Text);
                if (drow != null)
                {
                    textBox_ID.BindingContext[dt].Position++;

                    if (!DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "BXCY_DIAG"))
                    {
                        updated = false;
                    }
                }
            }

            textBox_specimenID.BindingContext[bxcy_specimentDt].Position++;
            if (DBConn.updateObject(bxcy_specimentDataAdapter, bxcy_specimenDataSet, "bxcy_specimen"))
            {
                refreshMainPage = true;
                if (!updated)
                {
                    updated = true;
                }
            }

            if (!updated)
            {
                MessageBox.Show("Record updated fail or nothing to update");
            }

            if (refreshMainPage)
            {
                OnBxcyDiagExit();
            }

            this.Close();
        }

        private void button_Cobas_4800_System_Click(object sender, EventArgs e)
        {
            Form_Cobas4800System open = new Form_Cobas4800System(textBox_ID.Text);
            open.Show();
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [BXCY_DIAG] WHERE case_no = '{0}' ORDER BY ID", caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "bxcy_diag");

            dt = bxcy_diagDataSet.Tables["bxcy_diag"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Clear();
            comboBox_Description.DataBindings.Clear();
            textBox_Microscoplc.DataBindings.Clear();
            comboBox_Operation.DataBindings.Clear();
            textBox_Diagnosis.DataBindings.Clear();
            comboBox_Snop_T.DataBindings.Clear();
            comboBox_Snop_M.DataBindings.Clear();

            string cy_resultSql = "SELECT * FROM [cy_result] ORDER BY code";
            DataSet cy_resultDataSet = new DataSet();
            SqlDataAdapter cy_resultDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(cy_resultSql, cy_resultDataSet, "cy_result");

            DataTable cy_resultDt = new DataTable();
            cy_resultDt.Columns.Add("id");
            cy_resultDt.Columns.Add("code");
            cy_resultDt.Columns.Add("operation");
            cy_resultDt.Columns.Add("snop_m");
            cy_resultDt.Columns.Add("diag_desc1");

            cy_resultDt.Rows.Add(new object[] { "","","","","" });

            foreach (DataRow mDr in cy_resultDataSet.Tables["cy_result"].Rows)
            {
                cy_resultDt.Rows.Add(new object[] { mDr["id"].ToString().Trim(), mDr["code"].ToString().Trim(), mDr["operation"].ToString().Trim(), mDr["snop_m"].ToString().Trim(), mDr["diag_desc1"].ToString().Trim() });
                //cy_resultDt.Rows.Add(new object[] { mDr["id"].ToString().Trim(), mDr["code"].ToString().Trim() });
            }

            comboBox_cy_result.DataSource = cy_resultDt;

            string operationSql = "SELECT [operation],[desc] FROM [operation] WHERE operation is not null ORDER BY operation";
            DataSet operationDataSet = new DataSet();
            SqlDataAdapter operationDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(operationSql, operationDataSet, "operation");

            DataTable operationDt = new DataTable();
            operationDt.Columns.Add("operation");
            operationDt.Columns.Add("operationAndDesc");

            foreach (DataRow mDr in operationDataSet.Tables["operation"].Rows)
            {
                operationDt.Rows.Add(new object[] { mDr["operation"], string.Format("{0}--{1}", mDr["operation"].ToString().Trim(), mDr["desc"].ToString().Trim()) });
            }

            comboBox_Operation.DataSource = operationDt;

            string marco_nameSql = "SELECT [marco_name] FROM [marco_name]";
            DataSet marco_nameDataSet = new DataSet();
            SqlDataAdapter marco_nameDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(marco_nameSql, marco_nameDataSet, "marco_name");

            DataTable marco_nameDt = new DataTable();
            marco_nameDt.Columns.Add("marco_name");

            foreach (DataRow mDr in marco_nameDataSet.Tables["marco_name"].Rows)
            {
                marco_nameDt.Rows.Add(new object[] { mDr["marco_name"] });
            }

            comboBox_Description.DataSource = marco_nameDt;

            //string snopcodeTSql = "SELECT [desc],snopcode FROM [snopcode] WHERE SNOPTYPE = 'T' ";
            string snopcodeTSql = "SELECT [C_DESC] FROM [diag_desc] WHERE [C_DESC] IS NOT NULL ORDER BY [C_DESC]";
            DataSet snopcodeTDataSet = new DataSet();
            SqlDataAdapter snopcodeTDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeTSql, snopcodeTDataSet, "diag_desc");

            DataTable snopcodeTDt1 = new DataTable();
            snopcodeTDt1.Columns.Add("C_DESC");

            foreach (DataRow mDr in snopcodeTDataSet.Tables["diag_desc"].Rows)
            {
                snopcodeTDt1.Rows.Add(new object[] { mDr["C_DESC"]});
            }

            comboBox_Snop_T.DataSource = snopcodeTDt1;

            string snopcodeMSql = "SELECT [desc],snopcode,id FROM [snopcode] WHERE SNOPTYPE = 'M' ";
            DataSet snopcodeMDataSet = new DataSet();
            SqlDataAdapter snopcodeMDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeMSql, snopcodeMDataSet, "snopcode");

            DataTable snopcodeMDt1 = new DataTable();
            snopcodeMDt1.Columns.Add("snopcode");
            snopcodeMDt1.Columns.Add("Desc");
            snopcodeMDt1.Columns.Add("id");

            foreach (DataRow mDr in snopcodeMDataSet.Tables["snopcode"].Rows)
            {
                snopcodeMDt1.Rows.Add(new object[] { mDr["snopcode"], mDr["desc"].ToString().Trim(), mDr["id"].ToString() });
            }

            comboBox_Snop_M.DataSource = snopcodeMDt1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            comboBox_Description.DataBindings.Add("SelectedValue", dt, "macro_name", false);
            textBox_Microscoplc.DataBindings.Add("Text", dt, "Micro_desc", false);
            comboBox_Operation.DataBindings.Add("SelectedValue", dt, "Operation", false);
            textBox_Diagnosis.DataBindings.Add("Text", dt, "Diagnosis", false);
            comboBox_Snop_T.DataBindings.Add("SelectedValue", dt, "diag_desc1", false);

            string bxcy_sql = string.Format("SELECT * FROM [bxcy_specimen] WHERE id={0}", bxcy_id);
            bxcy_specimentDataAdapter = DBConn.fetchDataIntoDataSet(bxcy_sql, bxcy_specimenDataSet, "bxcy_specimen");

            bxcy_specimentDt = bxcy_specimenDataSet.Tables["bxcy_specimen"];
            bxcy_specimentDt.PrimaryKey = new DataColumn[] { bxcy_specimentDt.Columns["id"] };
            bxcy_specimentDt.Columns["id"].AutoIncrement = true;
            bxcy_specimentDt.Columns["id"].AutoIncrementStep = 1;

            textBox_specimenID.DataBindings.Add("Text", bxcy_specimentDt, "id", false);
            comboBox_Snop_M.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m", false);

            if (dt.Rows.Count == 0)
            {
                currentEditRow = bxcy_diagDataSet.Tables["bxcy_diag"].NewRow();
                currentEditRow["id"] = -1;

                bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Clear();
                bxcy_diagDataSet.Tables["bxcy_diag"].Rows.Add(currentEditRow);
            }
        }

        private void Form_CytologyFindings_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
        }

        private void comboBox_cy_result_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet cyResultDataSet = new DataSet();

            string sql = string.Format("SELECT * FROM [cy_result] WHERE id ={0}", comboBox_cy_result.SelectedValue);
            DBConn.fetchDataIntoDataSetSelectOnly(sql, cyResultDataSet, "cy_result");

            if(cyResultDataSet.Tables["cy_result"].Rows.Count > 0)
            {
                DataRow mDr = cyResultDataSet.Tables["cy_result"].Rows[0];

                try
                {
                    comboBox_Operation.SelectedValue = mDr["OPERATION"] == null ? "" : mDr["OPERATION"].ToString();

                    comboBox_Operation.Focus();
                }
                catch(Exception ex)
                {

                }

                textBox_Diagnosis.Text = mDr["DIAGNOSIS"] == null ? "" : mDr["DIAGNOSIS"].ToString();

                textBox_Microscoplc.Text = mDr["MICRO_DESC"] == null ? "" : mDr["MICRO_DESC"].ToString();

                textBox_Diagnosis.Focus();
                textBox_Diagnosis.Select(textBox_Diagnosis.TextLength, 0);
                textBox_Diagnosis.ScrollToCaret();

                textBox_Microscoplc.Focus();
                textBox_Microscoplc.Select(textBox_Microscoplc.TextLength, 0);
                textBox_Microscoplc.ScrollToCaret();

                try
                {
                    comboBox_Snop_T.SelectedValue = mDr["DIAG_DESC1"] == null ? "" : mDr["DIAG_DESC1"].ToString();
                    comboBox_Snop_T.Focus();
                }
                catch (Exception ex)
                {

                }

                try
                {
                    comboBox_Snop_M.SelectedValue = mDr["SNOP_M"] == null ? "" : mDr["SNOP_M"].ToString();
                    comboBox_Snop_M.Focus();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void comboBox_Description_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //textBox_Microscoplc.Text = textBox_Microscoplc.Text + comboBox_Description.SelectedValue.ToString();
        }

        private void comboBox_Operation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //textBox_Diagnosis.Text = textBox_Diagnosis.Text + comboBox_Operation.SelectedValue.ToString();
        }

        private void comboBox_cy_result_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string code = drv.Row["code"].ToString();
            string operation = drv.Row["operation"].ToString();
            string snop_m = drv.Row["snop_m"].ToString();
            string diag_desc1 = drv.Row["diag_desc1"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 4;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(code, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 4;
            e.Graphics.DrawString(operation, e.Font, sb, r2);

            Rectangle r3 = e.Bounds;
            r3.X = r1.Width + r2.Width + 1;
            r3.Width = r3.Width / 4;
            e.Graphics.DrawString(snop_m, e.Font, sb, r3);

            Rectangle r4 = e.Bounds;
            r4.X = r1.Width + r2.Width + r3.Width + 1;
            r4.Width = e.Bounds.Width / 4;
            e.Graphics.DrawString(diag_desc1, e.Font, sb, r4);
        }

        private void comboBox_Snop_M_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DataRowView drv = (DataRowView)((ComboBox)sender).Items[e.Index];
            string snopcode = drv.Row["snopcode"].ToString();
            string desc = drv.Row["desc"].ToString();

            Rectangle r1 = e.Bounds;
            r1.Width = r1.Width / 2;
            SolidBrush sb = new SolidBrush(Color.Black);
            e.Graphics.DrawString(snopcode, e.Font, sb, r1);

            Rectangle r2 = e.Bounds;
            r2.X = r1.Width + 1;
            r2.Width = r2.Width / 2;
            e.Graphics.DrawString(desc, e.Font, sb, r2);
        }
    }
}
