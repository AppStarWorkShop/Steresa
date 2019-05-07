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
    public partial class Form_ConfirmMerge : Form
    {
        public Form_ConfirmMerge()
        {
            InitializeComponent();
        }

        private void Form_ConfirmMerge_Load(object sender, EventArgs e)
        {
            dataGridViewInputTestDate();
            dataGridViewFormat();
        }
        private void dataGridViewInputTestDate()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Patient's Name");
            dt.Columns.Add("Chinese Name");
            dt.Columns.Add("HKid");
            dt.Columns.Add("No.");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Birth");
            dt.Columns.Add("Age");

            dt.Rows.Add(new object[] { "CHAN TAI MAN", "陳大文", "D1234567(8)", "1", "M", "25/06/1987", "46.56" });
            dt.Rows.Add(new object[] { "CHAN Taai Man, Tom", "陳太文", "D1234567(8)", "1", "M", "22/09/1982", "41.56" });

            dataGridView1.DataSource = dt;
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 190;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 145;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 130;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 30;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 30;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 80;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 60;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Form_PatientFileMaintenancecs.merge = true;
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
            this.Hide();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
