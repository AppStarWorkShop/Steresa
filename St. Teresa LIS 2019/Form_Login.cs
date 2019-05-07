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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkRed, ButtonBorderStyle.Solid);
        }

        private void FromLogin_Load(object sender, EventArgs e)
        {
            textBox_Password.KeyUp += new KeyEventHandler(textBox_Password_KeyUp);
            textBox_UserID.KeyUp += new KeyEventHandler(textBox_UserID_KeyUp);
        }

        private void textBox_Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox_Password.Text == "sys" && textBox_UserID.Text == "SYS")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Form_MainMenu open = new Form_MainMenu();
                    open.Show();
                    this.Hide();
                }
            }

        }
        private void textBox_UserID_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox_Password.Text == "sys" && textBox_UserID.Text == "SYS")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Form_MainMenu open = new Form_MainMenu();
                    open.Show();
                    this.Hide();
                }
            }

        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_UserID_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
