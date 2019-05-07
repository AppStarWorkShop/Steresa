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
    public partial class Form_UploadDateMenu : Form
    {
        public Form_UploadDateMenu()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_1_Upload_Date_To_STH_WS_Click(object sender, EventArgs e)
        {
            Form_UploadSTHSpecimensByWebService open = new Form_UploadSTHSpecimensByWebService();
            open.Show();
        }
    }
}
