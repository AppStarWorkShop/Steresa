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
    public partial class Form_Authorization : Form
    {
        public delegate void AuthorizationPass(bool authorizationResult);
        public AuthorizationPass OnAuthorizationPass;

        public Form_Authorization()
        {
            InitializeComponent();
            textBox_UserID.Text = CurrentUser.currentUserId.Trim();
        }

        private void label_Password_Click(object sender, EventArgs e)
        {

        }

        private void label_UserID_Click(object sender, EventArgs e)
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
                        string sql = string.Format("select * FROM [USER] where user_id = '{0}' and (password='{1}' OR (password2 is not null and password2='{1}'))", CurrentUser.currentUserId.Trim(), textBox_Password.Text.Trim());
                        DBConn.fetchDataIntoDataSetSelectOnly(sql, userDataSet, "USER");

                        if (userDataSet.Tables["USER"].Rows.Count > 0)
                        {
                            if(OnAuthorizationPass != null)
                            {
                                this.Close();
                                OnAuthorizationPass(true);
                            }
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

            if (keyData == Keys.Escape)
            {
                if (OnAuthorizationPass != null)
                {
                    OnAuthorizationPass(false);
                }
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
