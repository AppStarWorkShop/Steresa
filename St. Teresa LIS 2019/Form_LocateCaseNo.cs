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
    public partial class Form_LocateCaseNo : Form
    {
        public Form_LocateCaseNo()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_LocateCaseNo_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Case No.");
            dt.Columns.Add("Report Date");
            dt.Columns.Add("Patient");
            dt.Columns.Add(" ");
            dt.Columns.Add("Age");
            dt.Columns.Add("Sex");
            dt.Columns.Add("HKID No.");
            dt.Columns.Add("Client");

            dt.Rows.Add(new object[] { "S1912345", "1987 / 06 / 22", "Chan Tai Man", "1", "46.56", "M", "D1234567(8)", "ST. TERESA'S HOSPITAL" });

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_F6_View_Record_Click(object sender, EventArgs e)
        {
            Form_EBVFile open = new Form_EBVFile();
            open.Show();
        }
    }
}
