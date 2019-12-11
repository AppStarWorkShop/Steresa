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
    public partial class Form_FrozenSection : Form
    {
        private DataSet FrozenSectionDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        private DataSet FrozenSectionDataSetFull = new DataSet();
        private SqlDataAdapter dataAdapterFull;

        public delegate void NatureSelectedSingle(string str);
        public NatureSelectedSingle OnNatureSelectedSingle;

        private bool m_isEntering = false;

        public Form_FrozenSection()
        {
            InitializeComponent();
        }

        public Form_FrozenSection(string str)
        {
            InitializeComponent();
            textBox_Frozen_Section_Detail.Text = str;
            reloadAndBindingDBData();
        }

        private void reloadAndBindingDBData()
        {
            string sqlFull = "SELECT * FROM [frozen_section] ORDER BY ID";
            dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, FrozenSectionDataSetFull, "frozen_section");

            DataTable newDt = new DataTable();
            newDt.Columns.Add("FZ_DETAIL");

            foreach (DataRow mDr in FrozenSectionDataSetFull.Tables["frozen_section"].Rows)
            {
                newDt.Rows.Add(new object[] { mDr["FZ_DETAIL"] });
            }

            comboBox_Frozen_Section_Detail.DataSource = newDt;
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_FrozenSectionDianosis open = new Form_FrozenSectionDianosis();
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

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            if (OnNatureSelectedSingle != null)
            {
                OnNatureSelectedSingle(textBox_Frozen_Section_Detail.Text);
            }
            this.Close();
        }

        private void comboBox_Frozen_Section_Detail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            m_isEntering = true;
        }

        private void comboBox_Frozen_Section_Detail_TextChanged(object sender, EventArgs e)
        {
            if (m_isEntering)
            {
                m_isEntering = false;
                string search = ((ComboBox)sender).Text.Trim();

                string sqlFull = string.Format("SELECT * FROM [frozen_section] WHERE FZ_DETAIL LIKE '{0}%' ORDER BY ID", search);
                dataAdapterFull = DBConn.fetchDataIntoDataSet(sqlFull, FrozenSectionDataSetFull, "frozen_section");

                DataTable newDt = new DataTable();
                newDt.Columns.Add("FZ_DETAIL");

                foreach (DataRow mDr in FrozenSectionDataSetFull.Tables["frozen_section"].Rows)
                {
                    newDt.Rows.Add(new object[] { mDr["FZ_DETAIL"] });
                }

                ((ComboBox)sender).DataSource = newDt;

                ((ComboBox)sender).Text = search;
                ((ComboBox)sender).SelectionStart = search.Length;
            }
        }

        private void comboBox_Frozen_Section_Detail_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox_Frozen_Section_Detail.Text += comboBox_Frozen_Section_Detail.SelectedValue.ToString();
        }
    }
}
