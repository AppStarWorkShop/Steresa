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
    public partial class Form_CytologicalDiagnosis : Form
    {
        public Form_CytologicalDiagnosis()
        {
            InitializeComponent();
        }

        private void button_Image_Click(object sender, EventArgs e)
        {
            Form_Picture open = new Form_Picture();
            open.Show();
        }

        private void button_Confirm_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            Form_GynaecologicalCytologyReport open = new Form_GynaecologicalCytologyReport();
            open.Show();
        }
    }
}
