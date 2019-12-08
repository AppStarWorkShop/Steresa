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
    public partial class Form_SurgicalProcedure : Form
    {
        private DataSet SurgicalProcedureDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataSet SurgicalProcedureDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void SurgicalSelectedSingle(string str);
        public SurgicalSelectedSingle OnSurgicalSelectedSingle;

        private bool m_isEntering = false;

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
            open.OnRecordUpdateDone += onRecordUpdateDone;
            open.Show();
        }

        private void onRecordUpdateDone(bool isUpdated)
        {
            if (isUpdated)
            {
                reloadAndBindingDBData();
            }
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
            newDt.Columns.Add("Description");
            newDt.Columns.Add("SurgicalProcedureVal");

            foreach (DataRow mDr in SurgicalProcedureDataSetFull.Tables["SurgicalProcedure"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["Description"], mDr["SurgicalProcedureVal"] });
            }

            comboBox_Surgical_Procedure.DataSource = newDt;
        }

        private void comboBox_Surgical_Procedure_TextChanged(object sender, EventArgs e)
        {
            if (m_isEntering)
            {
                m_isEntering = false;
                string search = ((ComboBox)sender).Text.Trim();
                /*if (string.IsNullOrEmpty(search))
                {
                    return;
                }*/
                //((ComboBox)sender).Items.Clear();

                string sqlFull = string.Format("SELECT * FROM [SurgicalProcedure] WHERE SurgicalProcedureVal LIKE '{0}%' ORDER BY ID", search);
                dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, SurgicalProcedureDataSetFull, "SurgicalProcedure");

                DataTable newDt = new DataTable();
                newDt.Columns.Add("Description");
                newDt.Columns.Add("SurgicalProcedureVal");

                foreach (DataRow mDr in SurgicalProcedureDataSetFull.Tables["SurgicalProcedure"].Rows)
                {
                    newDt.Rows.Add(new object[] { mDr["Description"], mDr["SurgicalProcedureVal"] });
                }

                ((ComboBox)sender).DataSource = newDt;

                //((ComboBox)sender).DroppedDown = true;
                //this.Cursor = Cursors.Arrow;
                ((ComboBox)sender).Text = search;
                ((ComboBox)sender).SelectionStart = search.Length;
            }
        }

        private void comboBox_Surgical_Procedure_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering = true;
        }
    }
}
