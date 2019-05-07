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
    public partial class Form_DigitalSignature : Form
    {
        public Form_DigitalSignature()
        {
            InitializeComponent();
        }

        private void Form_DigitalSignature_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(" ", typeof(Boolean));
            dt.Columns.Add("Case No.");
            dt.Columns.Add("Report No.");
            dt.Columns.Add("Report Date");
            dt.Columns.Add("Name");
            dt.Columns.Add("HKID No.");

            dt.Rows.Add(new object[] {0 , "BX18/654321", "1234567", "2018/02/11", "Chan Tai Man" , "D1234567(8)" });
            dt.Rows.Add(new object[] {0 , "BX18/654322", "1234566", "2018/02/11", "Chan Tai Man" , "D1234567(8)" });

            dataGridView1.DataSource = dt;
            dataGridViewFormat();
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 25;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 130;
            column1.ReadOnly = true;
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 130;
            column2.ReadOnly = true;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 130;
            column3.ReadOnly = true;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 240;
            column4.ReadOnly = true;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 185;
            column5.ReadOnly = true;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);


            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;


            // center text

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
private void button_Sign_Selected_Cases_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Are you Sure to \n" +
             "\n" +
             "Digitally sign the\n" +
             "\n" +
             "Selected case?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        private void button_F6_View_Record_Click(object sender, EventArgs e)
        {
            Form_BXCYFile open = new Form_BXCYFile();
            open.Show();
        }
    }
}
