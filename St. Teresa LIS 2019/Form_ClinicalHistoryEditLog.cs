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
    public partial class Form_ClinicalHistoryEditLog : Form
    {
        public Form_ClinicalHistoryEditLog()
        {
            InitializeComponent();
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_ClinicalHistoryEditLog_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("User");
            dt.Columns.Add("DateTime");
            dt.Columns.Add("Content");

            dt.Rows.Add(new object[] { "ADMIN", "2018-10-29 10:22:10", "testestes" });
            dt.Rows.Add(new object[] { "TESTER", "2018-10-29 10:22:10", "dsjijdlkjfdjdjlkj" });

            dataGridView1.DataSource = dt;
            dataGridViewFormat();
        }
        private void dataGridViewFormat()
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);


            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;


            // center text

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
        }
    }
}
