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

    public partial class Form_PatientFileMaintenancecs : Form
    {
        public static Boolean merge;
        public Form_PatientFileMaintenancecs()
        {
            InitializeComponent();
        }

        private void button_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            merge = false;
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            merge = true;
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
        }

    }
}
