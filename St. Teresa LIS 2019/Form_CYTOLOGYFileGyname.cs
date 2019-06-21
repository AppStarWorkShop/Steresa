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
    public partial class Form_CYTOLOGYFileGyname : Form
    {
        public Form_CYTOLOGYFileGyname()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F5_CY_Diagnosis_Click(object sender, EventArgs e)
        {
            Form_CytologicalDiagnosis open = new Form_CytologicalDiagnosis();
            open.Show();
        }

        private void button_F6_Gynaecologl_Histoy_Click(object sender, EventArgs e)
        {
            Form_GynecologicalHistory open = new Form_GynecologicalHistory();
            open.Show();
        }

        private void button_F10_Findings_and_Comments_Click(object sender, EventArgs e)
        {
            Form_FindingComments open = new Form_FindingComments();
            open.Show();
        }

        private void button_Amount_HK_Detail_Click(object sender, EventArgs e)
        {
            Form_STHDiagnosticAmount open = new Form_STHDiagnosticAmount();
            open.Show();
        }
    }
}
