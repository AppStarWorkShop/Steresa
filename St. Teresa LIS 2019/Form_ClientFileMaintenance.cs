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
    public partial class Form_ClientFileMaintenance : Form
    {
        public Boolean edit;

        public Form_ClientFileMaintenance()
        {
            edit = false;
            InitializeComponent();
        }


        private void Form_ClientFileMaintenance_Load(object sender, EventArgs e)
        {

        }
        private void edit_modle()
        {
            button_Top.Image = Image.FromFile("Resources/topGra.png");
            button_Top.ForeColor = Color.Gray;
            button_Back.Image = Image.FromFile("Resources/backGra.png");
            button_Back.ForeColor = Color.Gray;
            button_Next.Image = Image.FromFile("Resources/nextGra.png");
            button_Next.ForeColor = Color.Gray;
            button_End.Image = Image.FromFile("Resources/endGra.png");
            button_End.ForeColor = Color.Gray;
            button_Save.Image = Image.FromFile("Resources/save.png");
            button_Save.ForeColor = Color.Black;
            button_New.Image = Image.FromFile("Resources/newGra.png");
            button_New.ForeColor = Color.Gray;
            button_Edit.Image = Image.FromFile("Resources/editGra.png");
            button_Edit.ForeColor = Color.Gray;
            button_Delete.Image = Image.FromFile("Resources/deleteGra.png");
            button_Delete.ForeColor = Color.Gray;
            button_Undo.Image = Image.FromFile("Resources/undo.png");
            button_Undo.ForeColor = Color.Black;
            button_Label.Image = Image.FromFile("Resources/printer-1Gra.png");
            button_Label.ForeColor = Color.Gray;
            button_Exit.Image = Image.FromFile("Resources/exitGra.png");
            button_Exit.ForeColor = Color.Gray;
            button_Excel.Image = Image.FromFile("Resources/excel-32Gra.png");
            button_Excel.ForeColor = Color.Gray;
            edit = true;
        }
        private void disedit_modle()
        {
            button_Top.Image = Image.FromFile("Resources/top.png");
            button_Top.ForeColor = Color.Black;
            button_Back.Image = Image.FromFile("Resources/back.png");
            button_Back.ForeColor = Color.Black;
            button_Next.Image = Image.FromFile("Resources/next.png");
            button_Next.ForeColor = Color.Black;
            button_End.Image = Image.FromFile("Resources/end.png");
            button_End.ForeColor = Color.Black;
            button_Save.Image = Image.FromFile("Resources/saveGra.png");
            button_Save.ForeColor = Color.Gray;
            button_New.Image = Image.FromFile("Resources/new.png");
            button_New.ForeColor = Color.Black;
            button_Edit.Image = Image.FromFile("Resources/edit.png");
            button_Edit.ForeColor = Color.Black;
            button_Delete.Image = Image.FromFile("Resources/delete.png");
            button_Delete.ForeColor = Color.Black;
            button_Undo.Image = Image.FromFile("Resources/undoGra.png");
            button_Undo.ForeColor = Color.Gray;
            button_Label.Image = Image.FromFile("Resources/printer-1.png");
            button_Label.ForeColor = Color.Black;
            button_Exit.Image = Image.FromFile("Resources/exit.png");
            button_Exit.ForeColor = Color.Black;
            button_Excel.Image = Image.FromFile("Resources/excel-32.png");
            button_Excel.ForeColor = Color.Black;
            edit = false;
        }
        private void button_Label_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                Form_LabelPrinting open = new Form_LabelPrinting();
                open.Show();
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                this.Hide();
            }
        }
        

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                edit_modle();
            }
            else if (edit)
            {

            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                edit_modle();
            }
            else if (edit)
            {

            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                disedit_modle();
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {

        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            Form_SelectClient open = new Form_SelectClient();
            open.Show();
        }
    }
}
