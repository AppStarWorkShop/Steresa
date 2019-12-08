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
    public partial class Form_NatureOfSpecimen : Form
    {
        private DataSet NatureOfSpecimenDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataSet NatureOfSpecimenDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void NatureSelectedSingle(string str);
        public NatureSelectedSingle OnNatureSelectedSingle;

        private bool m_isEntering = false;

        public Form_NatureOfSpecimen(string str)
        {
            InitializeComponent();
            textBox_Nature_Of_Specimen.Text = str;
            reloadAndBindingDBData();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            if (OnNatureSelectedSingle != null)
            {
                OnNatureSelectedSingle(textBox_Nature_Of_Specimen.Text);
            }
            this.Close();
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_NatureOfSpecimenReportMaintenance open = new Form_NatureOfSpecimenReportMaintenance();
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

        private void reloadAndBindingDBData()
        {
            string sqlFull = "SELECT * FROM [NatureOfSpecimen] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, NatureOfSpecimenDataSetFull, "NatureOfSpecimen");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("Description");
            newDt.Columns.Add("SurgicalProcedureVal");

            foreach (DataRow mDr in NatureOfSpecimenDataSetFull.Tables["NatureOfSpecimen"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["Description"], mDr["SurgicalProcedureVal"] });
            }

            comboBox_Nature_Of_Specimen.DataSource = newDt;
        }

        private void comboBox_Nature_Of_Specimen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox_Nature_Of_Specimen.Text += comboBox_Nature_Of_Specimen.SelectedValue.ToString();
        }

        private void comboBox_Nature_Of_Specimen_TextChanged(object sender, EventArgs e)
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

                string sqlFull = string.Format("SELECT * FROM [NatureOfSpecimen] WHERE SurgicalProcedureVal LIKE '{0}%' ORDER BY ID", search);
                dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, NatureOfSpecimenDataSetFull, "NatureOfSpecimen");

                DataTable newDt = new DataTable();
                newDt.Columns.Add("Description");
                newDt.Columns.Add("SurgicalProcedureVal");

                foreach (DataRow mDr in NatureOfSpecimenDataSetFull.Tables["NatureOfSpecimen"].Rows)
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

        private void Form_NatureOfSpecimen_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox_Nature_Of_Specimen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering = true;
        }
    }
}
