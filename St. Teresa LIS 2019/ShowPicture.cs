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
    public partial class ShowPicture : Form
    {
        public ShowPicture()
        {
            InitializeComponent();
        }

        public ShowPicture(string pictureName)
        {
            InitializeComponent();

            pictureBox1.ImageLocation = CurrentUser.picturePath + "\\" + pictureName;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
