﻿using System;
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
        private DataRow currentEditRow;

        private DataSet bxcy_specimenDataSet = new DataSet();
        private DataTable bxcy_specimentDt;
        private SqlDataAdapter bxcy_specimentDataAdapter;

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
            cy_resultDt.Columns.Add("mix_desc");

            foreach (DataRow mDr in cy_resultDataSet.Tables["cy_result"].Rows)
            {
                cy_resultDt.Rows.Add(new object[] { mDr["id"].ToString().Trim(), string.Format("{0}-{1}-{2}-{3}", mDr["code"].ToString().Trim(), mDr["operation"].ToString().Trim(), mDr["snop_m"].ToString().Trim(), mDr["diag_desc1"].ToString().Trim()) });
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

            string snopcodeMSql = "SELECT [desc],snopcode FROM [snopcode] WHERE SNOPTYPE = 'M' ";
            DataSet snopcodeMDataSet = new DataSet();
            SqlDataAdapter snopcodeMDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(snopcodeMSql, snopcodeMDataSet, "snopcode");

            DataTable snopcodeMDt1 = new DataTable();
            snopcodeMDt1.Columns.Add("desc");
            snopcodeMDt1.Columns.Add("snopcodeAndDesc");

            foreach (DataRow mDr in snopcodeMDataSet.Tables["snopcode"].Rows)
            {
                snopcodeMDt1.Rows.Add(new object[] { mDr["desc"], string.Format("{0}--{1}", mDr["snopcode"].ToString().Trim(), mDr["desc"].ToString().Trim()) });
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

            comboBox_Snop_M.DataBindings.Add("SelectedValue", bxcy_specimentDt, "Snopcode_m", false);
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
                }
                catch(Exception ex)
                {

                }

                textBox_Diagnosis.Text = mDr["DIAGNOSIS"] == null ? "" : mDr["DIAGNOSIS"].ToString();

                /*try
                {
                    comboBox_Description.SelectedValue = mDr["DIAG_DESC1"] == null ? "" : mDr["DIAG_DESC1"].ToString();
                }
                catch (Exception ex)
                {

                }*/

                textBox_Microscoplc.Text = mDr["MICRO_DESC"] == null ? "" : mDr["MICRO_DESC"].ToString();

                try
                {
                    comboBox_Snop_T.SelectedValue = mDr["DIAG_DESC1"] == null ? "" : mDr["DIAG_DESC1"].ToString();
                }
                catch (Exception ex)
                {

                }

                try
                {
                    comboBox_Snop_M.SelectedValue = mDr["SNOP_M"] == null ? "" : mDr["SNOP_M"].ToString();
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
    }
}
