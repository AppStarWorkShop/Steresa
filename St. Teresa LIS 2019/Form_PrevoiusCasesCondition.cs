using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace St.Teresa_LIS_2019
{
    public partial class Form_PrevoiusCasesCondition : Form
    {
        public Form_PrevoiusCasesCondition()
        {
            InitializeComponent();
        }

        private void Form_PrevoiusCasesCondition_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Case No.");
            dt.Columns.Add("Date");
            dt.Columns.Add("T-code");
            dt.Columns.Add("M-code");
            dt.Columns.Add("Site");
            dt.Columns.Add("Diagnosis");

            dt.Rows.Add(new object[] { "BX18/654321", "2018/02/11", "BREAST (04)" + Environment.NewLine + "VAGINA  (81)" + Environment.NewLine + "CERVICAL SMEAR  (8X32)", "ATROPHY (7100)" + Environment.NewLine + "LEIOMYOMA  (8890)" + Environment.NewLine + "INADEQUATE SPECIMEN  (0006)", "cerebral hemorrhage", "testtesttesttesttesttesttesttesttesttesttesttesttesttesttest" });
            dt.Rows.Add(new object[] { "BX18/654322", "2018/02/11", "BREAST (04)" + Environment.NewLine + "CERVICAL SMEAR  (8X32)", "ATROPHY (7100)" , "cerebral hemorrhage", "testtesttesttesttesttesttesttesttesttesttesttesttesttesttest" });

            dataGridView1.DataSource = dt;
            dataGridViewFormat();
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F7_View_Details_Click(object sender, EventArgs e)
        {
            Form_BXCYFile2 open = new Form_BXCYFile2();
            open.Show();
        }
        private void dataGridViewFormat()
        {
            /*DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 130;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 110;*/
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            //column2.Width = 170;
            column2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
           DataGridViewColumn column3 = dataGridView1.Columns[3];
            //column3.Width = 170;
            column3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            /*DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 170;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 300;*/

            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);


            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;


            // center text

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void button_F6_View_Diagnosis_Click(object sender, EventArgs e)
        {

        }
    }
}
