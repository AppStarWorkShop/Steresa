using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

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
            //textBox_Password.KeyUp += new KeyEventHandler(textBox_Password_KeyUp);
            //textBox_UserID.KeyUp += new KeyEventHandler(textBox_UserID_KeyUp);
        }

        private void textBox_Password_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (textBox_Password.Focused || textBox_UserID.Focused)
                {
                    if (textBox_Password.Text != "" && textBox_UserID.Text != "")
                    {
                        SqlConnection conn = DBConn.getConnection();
                        DataSet userDataSet = new DataSet();
                        string sql = string.Format("select * FROM [USER] where user_id = '{0}' and (password='{1}' OR (password2 is not null and password2='{1}' and level > 0))", textBox_UserID.Text.Trim(), textBox_Password.Text.Trim());
                        DBConn.fetchDataIntoDataSetSelectOnly(sql, userDataSet, "USER");

                        if (userDataSet.Tables["USER"].Rows.Count > 0)
                        {

                            DataRow mDr = userDataSet.Tables["USER"].Rows[0];

                            CurrentUser.currentUserLevel = int.Parse(mDr["LEVEL"].ToString());
                            CurrentUser.currentUserId = int.Parse(mDr["id"].ToString());
                            CurrentUser.picturePath = mDr["PIC_PATH"].ToString();
                            Form_MainMenu open = new Form_MainMenu();
                            open.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid user name or password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter the user name and password");
                    }
                }

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox_UserID_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (textBox_Password.Text == "sys" && textBox_UserID.Text == "SYS")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Form_MainMenu open = new Form_MainMenu();
                    open.Show();
                    this.Hide();
                }
            }*/

        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_UserID_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
