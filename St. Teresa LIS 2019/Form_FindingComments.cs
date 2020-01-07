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
    public partial class Form_FindingComments : Form
    {
        
        private Form_CYTOLOGYFileGyname previousForm;

        public Form_FindingComments()
        {
            InitializeComponent();
        }

        public void setPreviousForm(Form_CYTOLOGYFileGyname previousForm)
        {
            this.previousForm = previousForm;
        }

        public void setReportWording(String w)
        {
            textBox_Gynecological_History.Text = w;
        }

        private void button_F8_Confirm_Exit_Click(object sender, EventArgs e)
        {
            if (previousForm != null)
            {
                previousForm.setReportWording(textBox_Gynecological_History.Text);
            }
            this.Close();
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_FindingCommentsReportMaintenance open = new Form_FindingCommentsReportMaintenance();
            open.Show();
        }
    }
}
