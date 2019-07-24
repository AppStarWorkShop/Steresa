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
        public delegate void NatureSelectedSingle(string str);
        public NatureSelectedSingle OnNatureSelectedSingle;

        public Form_NatureOfSpecimen(string str)
        {
            InitializeComponent();
            textBox_Nature_Of_Specimen.Text = str;
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            if (OnNatureSelectedSingle != null)
            {
                OnNatureSelectedSingle(textBox_Nature_Of_Specimen.Text);
            }
            this.Close();
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_NatureOfSpecimenReportMaintenance open = new Form_NatureOfSpecimenReportMaintenance();
            open.Show();
        }
    }
}
