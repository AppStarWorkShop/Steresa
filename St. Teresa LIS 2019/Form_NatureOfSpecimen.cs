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
    public partial class Form_NatureOfSpecimen : Form
    {
        public Form_NatureOfSpecimen()
        {
            InitializeComponent();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_NatureOfSpecimenReportMaintenance open = new Form_NatureOfSpecimenReportMaintenance();
            open.Show();
        }
    }
}
