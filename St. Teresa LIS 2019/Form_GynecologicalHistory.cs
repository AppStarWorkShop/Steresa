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
    public partial class Form_GynecologicalHistory : Form
    {
        private string caseNo;
        private SqlDataAdapter dataAdapter;
        private DataSet bxcy_diagDataSet = new DataSet();
        private DataTable dt;
        private DataRow currentEditRow;

        public Form_GynecologicalHistory()
        {
            InitializeComponent();
        }

        public Form_GynecologicalHistory(string caseNo)
        {
            this.caseNo = caseNo;
            InitializeComponent();
            reloadAndBindingDBData();
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Text.Trim() == "-1")
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("");

                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "cy_diag_hdr"))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Record updated fail, please contact Admin");
                        this.Close();
                    }
                }
            }
            else
            {
                DataRow drow = bxcy_diagDataSet.Tables["cy_diag_hdr"].Rows.Find(textBox_ID.Text);
                if (drow != null)
                {
                    drow["UPDATE_BY"] = CurrentUser.currentUserId;
                    drow["UPDATE_AT"] = DateTime.Now.ToString("");

                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, bxcy_diagDataSet, "cy_diag_hdr"))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Record updated fail, please contact Admin");
                        this.Close();
                    }
                }
            }
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            string sql = string.Format("SELECT TOP 1 * FROM [cy_diag_hdr] WHERE case_no = '{0}' ORDER BY id", caseNo);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, bxcy_diagDataSet, "cy_diag_hdr");

            dt = bxcy_diagDataSet.Tables["cy_diag_hdr"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Clear();
            textBox_LMP.DataBindings.Clear();
            checkBox_IUCD_in_situ.DataBindings.Clear();
            checkBox_On_Hormonal_Therapy.DataBindings.Clear();
            textBox_Pregnant.DataBindings.Clear();
            textBox_Post_natal.DataBindings.Clear();
            textBox_Menopause.DataBindings.Clear();
            comboBox_Cervical_Appearance.DataBindings.Clear();

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_LMP.DataBindings.Add("Text", dt, "LMP_DATE", true, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy/MM/dd");
            checkBox_IUCD_in_situ.DataBindings.Add("Checked", dt, "IUCD", false);
            checkBox_On_Hormonal_Therapy.DataBindings.Add("Checked", dt, "HORMONAL", false);
            textBox_Pregnant.DataBindings.Add("Text", dt, "PREG_WEEK", false);
            textBox_Post_natal.DataBindings.Add("Text", dt, "POST_WEEK", false);
            textBox_Menopause.DataBindings.Add("Text", dt, "MENO_YEAR", false);
            comboBox_Cervical_Appearance.DataBindings.Add("Text", dt, "CERVICAL", false);

            if (dt.Rows.Count == 0)
            {
                currentEditRow = bxcy_diagDataSet.Tables["cy_diag_hdr"].NewRow();
                currentEditRow["id"] = -1;
                currentEditRow["IUCD"] = 0;
                currentEditRow["HORMONAL"] = 0;
                currentEditRow["CASE_NO"] = caseNo;
                checkBox_Pregnan.Checked = false;
                checkBox_Post_natal.Checked = false;
                checkBox_Menopause.Checked = false;

                bxcy_diagDataSet.Tables["cy_diag_hdr"].Rows.Clear();
                bxcy_diagDataSet.Tables["cy_diag_hdr"].Rows.Add(currentEditRow);
            }
            else
            {
                
                if (dt.Rows[0]["PREG_WEEK"].ToString().Trim() != "")
                {
                    checkBox_Pregnan.Checked = true;
                }
                else
                {
                    checkBox_Pregnan.Checked = false;
                }

                if (dt.Rows[0]["POST_WEEK"].ToString().Trim() != "")
                {
                    checkBox_Post_natal.Checked = true;
                }
                else
                {
                    checkBox_Post_natal.Checked = false;
                }

                if (dt.Rows[0]["MENO_YEAR"].ToString().Trim() != "")
                {
                    checkBox_Menopause.Checked = true;
                }
                else
                {
                    checkBox_Menopause.Checked = false;
                }
            }
        }
    }
}
