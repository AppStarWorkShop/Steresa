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
    public partial class Form_ChangePicturePath : Form
    {
        public Form_ChangePicturePath()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string updateSql = string.Format("UPDATE [USER] SET [PIC_PATH] = '{0}' WHERE id = {1}", textBox_Picture_Path.Text, CurrentUser.currentId.ToString());
            if (DBConn.executeUpdate(updateSql))
            {
                CurrentUser.picturePath = textBox_Picture_Path.Text;
                MessageBox.Show("Picture saved");
            }
            else
            {
                MessageBox.Show("Fail to save the picture, please contact Admin");
            }
            //textBox_Picture_Path.Text
        }

        private void Form_ChangePicturePath_Load(object sender, EventArgs e)
        {
            textBox_Picture_Path.Text = CurrentUser.picturePath;
        }
    }
}
