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
    public partial class Form_EBVFile : Form
    {
        public Form_EBVFile()
        {
            InitializeComponent();
        }

        private void button_F_S_Detail_Click(object sender, EventArgs e)
        {
            Form_EBVDiagnosisFileMaintenance open = new Form_EBVDiagnosisFileMaintenance();
            open.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
        }

        private void button_F7_Click(object sender, EventArgs e)
        {
            Form_SelectClient open = new Form_SelectClient();
            open.Show();
        }

        private void button_F9_Click(object sender, EventArgs e)
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.Show();
        }

        private void button_Sign_By_Dr_1_Click(object sender, EventArgs e)
        {
            Form_DoctorsSignatureMaintenance open = new Form_DoctorsSignatureMaintenance();
            open.Show();
        }

        private void button_F2_Previous_Click(object sender, EventArgs e)
        {
            Form_PrevoiusCasesCondition open = new Form_PrevoiusCasesCondition();
            open.Show();
        }

        private void checkBox_TumourMarker_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            textBox_Paid_Date.Text = DateTime.DaysInMonth(dt.Year, dt.Month) + dt.ToString("MM/YYYY");
        }

        private void button_Amount_HK_Detail_Click(object sender, EventArgs e)
        {
            Form_STHDiagnosticAmount open = new Form_STHDiagnosticAmount();
            open.Show();
        }

        private void button_Label_Click(object sender, EventArgs e)
        {
            Form_PathologyReportEBV open = new Form_PathologyReportEBV();
            open.Show();
        }
    }
}
