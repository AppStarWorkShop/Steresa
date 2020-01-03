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
    public partial class Form_FeeCalculationPrivate : Form
    {
        private bool isPrice1Entering = false;
        private bool isPrice2Entering = false;
        private bool isPrice3Entering = false;
        private bool isPrice4Entering = false;
        private bool isPrice5Entering = false;
        private bool isPrice6Entering = false;
        private bool isPrice7Entering = false;

        string priceBXGrade = "", priceCoreBXGrade = "", priceCYGrade = "", priceCYNongynaeGrade = "", priceCYFNAGrade = "", priceEBVGrade = "", priceCYGGrade = "";
        string priceBX = "", priceCoreBX = "", priceCY = "", priceCYNongynae = "", priceCYFNA = "", priceEBV = "", priceCYG = "";

        string chargeOther = "", chargeTotal = "";

        public delegate void FeeCalculationPrivateConfirm(string priceBXGrade, string priceCoreBXGrade, string priceCYGrade, string priceCYNongynaeGrade, string priceCYFNAGrade, string priceEBVGrade, string priceCYGGrade,
            string priceBX, string priceCoreBX, string priceCY, string priceCYNongynae, string priceCYFNA, string priceEBV, string priceCYG,
            string chargeOther, string chargeTotal);
        public FeeCalculationPrivateConfirm OnFeeCalculationPrivateConfirm;

        private void textBox_CY_NONGYNAE_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice4Entering = true;
        }

        private void textBox_CY_FNA_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice5Entering = true;
        }

        private void textBox_EBV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice6Entering = true;
        }

        private void textBox_CYG_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice7Entering = true;
        }

        private void textBox_BX_TextChanged(object sender, EventArgs e)
        {
            if (isPrice1Entering)
            {
                isPrice1Entering = false;
                recalSum();
            }
        }

        private void textBox_CY_HPV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice3Entering = true;
        }

        private void textBox_CORE_BX_TextChanged(object sender, EventArgs e)
        {
            if (isPrice2Entering)
            {
                isPrice2Entering = false;
                recalSum();
            }
        }

        private void textBox_CY_HPV_TextChanged(object sender, EventArgs e)
        {
            if (isPrice3Entering)
            {
                isPrice3Entering = false;
                recalSum();
            }
        }

        private void textBox_CY_NONGYNAE_TextChanged(object sender, EventArgs e)
        {
            if (isPrice4Entering)
            {
                isPrice4Entering = false;
                recalSum();
            }
        }

        private void textBox_CY_FNA_TextChanged(object sender, EventArgs e)
        {
            if (isPrice5Entering)
            {
                isPrice5Entering = false;
                recalSum();
            }
        }

        private void textBox_EBV_TextChanged(object sender, EventArgs e)
        {
            if (isPrice6Entering)
            {
                isPrice6Entering = false;
                recalSum();
            }
        }

        private void textBox_CYG_TextChanged(object sender, EventArgs e)
        {
            if (isPrice7Entering)
            {
                isPrice7Entering = false;
                recalSum();
            }
        }

        private void comboBox_BX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalSum();
        }

        private void comboBox_CORE_BX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalSum();
        }

        private void comboBox_CY_HPV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalSum();
        }

        private void comboBox_CY_NONGYNAE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalSum();
        }

        private void comboBox_CY_FNA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalSum();
        }

        private void comboBox_EBV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalSum();
        }

        private void comboBox_CYG_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalSum();
        }

        private void textBox_Other_TextChanged(object sender, EventArgs e)
        {
            recalSum();
        }

        private void textBox_CORE_BX_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice2Entering = true;
        }

        private void textBox_BX_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice1Entering = true;
        }

        public Form_FeeCalculationPrivate()
        {
            InitializeComponent();
        }

        public Form_FeeCalculationPrivate(string priceBXGrade, string priceCoreBXGrade, string priceCYGrade, string priceCYNongynaeGrade, string priceCYFNAGrade, string priceEBVGrade, string priceCYGGrade,
            string priceBX, string priceCoreBX, string priceCY, string priceCYNongynae, string priceCYFNA, string priceEBV, string priceCYG,
            string chargeOther, string chargeTotal)
        {
            this.priceBXGrade = priceBXGrade;
            this.priceCoreBXGrade = priceCoreBXGrade;
            this.priceCYGrade = priceCYGrade;
            this.priceCYNongynaeGrade = priceCYNongynaeGrade;
            this.priceCYFNAGrade = priceCYFNAGrade;
            this.priceEBVGrade = priceEBVGrade;
            this.priceCYGGrade = priceCYGGrade;

            this.priceBX = priceBX;
            this.priceCoreBX = priceCoreBX;
            this.priceCY = priceCY;
            this.priceCYNongynae = priceCYNongynae;
            this.priceCYFNA = priceCYFNA;
            this.priceEBV = priceEBV;
            this.priceCYG = priceCYG;

            this.chargeOther = chargeOther;
            this.chargeTotal = chargeTotal;
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            if (OnFeeCalculationPrivateConfirm != null)
            {
                string priceBXGrade = "", priceCoreBXGrade = "", priceCYGrade = "", priceCYNongynaeGrade = "", priceCYFNAGrade = "", priceEBVGrade = "", priceCYGGrade = "";
                string priceBX = "", priceCoreBX = "", priceCY = "", priceCYNongynae = "", priceCYFNA = "", priceEBV = "", priceCYG = "";
                string chargeOther = "", chargeTotal = "";

                priceBXGrade = comboBox_BX.SelectedValue == null ? "" : comboBox_BX.SelectedValue.ToString();
                priceCoreBXGrade = comboBox_CORE_BX.SelectedValue == null ? "" : comboBox_CORE_BX.SelectedValue.ToString();
                priceCYGrade = comboBox_CYG.SelectedValue == null ? "" : comboBox_CYG.SelectedValue.ToString();
                priceCYNongynaeGrade = comboBox_CY_NONGYNAE.SelectedValue == null ? "" : comboBox_CY_NONGYNAE.SelectedValue.ToString();
                priceCYFNAGrade = comboBox_CY_FNA.SelectedValue == null ? "" : comboBox_CY_FNA.SelectedValue.ToString();
                priceEBVGrade = comboBox_EBV.SelectedValue == null ? "" : comboBox_EBV.SelectedValue.ToString();
                priceCYGGrade = comboBox_CYG.SelectedValue == null ? "" : comboBox_CYG.SelectedValue.ToString();

                priceBX = textBox_BX.Text.Trim();
                priceCoreBX = textBox_CORE_BX.Text.Trim();
                priceCY = textBox_CY_HPV.Text.Trim();
                priceCYNongynae = textBox_CY_NONGYNAE.Text.Trim();
                priceCYFNA = textBox_CY_FNA.Text.Trim();
                priceEBV = textBox_EBV.Text.Trim();
                priceCYG = textBox_CYG.Text.Trim();

                chargeOther = textBox_Other.Text.Trim();
                chargeTotal = textBox_Total.Text.Trim();

                OnFeeCalculationPrivateConfirm(priceBXGrade, priceCoreBXGrade, priceCYGrade, priceCYNongynaeGrade, priceCYFNAGrade, priceEBVGrade, priceCYGGrade,
                    priceBX, priceCoreBX, priceCY, priceCYNongynae, priceCYFNA, priceEBV, priceCYG,
                    chargeOther, chargeTotal);
            }
            this.Close();
        }

        private void Form_FeeCalculationPrivate_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
        }

        private void reloadAndBindingDBData()
        {
            DataTable gradeDt1 = new DataTable();
            gradeDt1.Columns.Add("gradeVal");
            gradeDt1.Columns.Add("gradeName");

            DataTable gradeDt2 = gradeDt1.Clone();
            DataTable gradeDt3 = gradeDt1.Clone();
            DataTable gradeDt4 = gradeDt1.Clone();
            DataTable gradeDt5 = gradeDt1.Clone();
            DataTable gradeDt6 = gradeDt1.Clone();
            DataTable gradeDt7 = gradeDt1.Clone();

            for(int i=0; i<=10; i++)
            {
                gradeDt1.Rows.Add(i, i);
                gradeDt2.Rows.Add(i, i);
                gradeDt3.Rows.Add(i, i);
                gradeDt4.Rows.Add(i, i);
                gradeDt5.Rows.Add(i, i);
                gradeDt6.Rows.Add(i, i);
                gradeDt7.Rows.Add(i, i);
            }

            comboBox_BX.DataSource = gradeDt1;
            comboBox_CORE_BX.DataSource = gradeDt2;
            comboBox_CY_HPV.DataSource = gradeDt3;
            comboBox_CY_NONGYNAE.DataSource = gradeDt4;
            comboBox_CY_FNA.DataSource = gradeDt5;
            comboBox_EBV.DataSource = gradeDt6;
            comboBox_CYG.DataSource = gradeDt7;

            try
            {
                comboBox_BX.SelectedValue = priceBXGrade;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_CORE_BX.SelectedValue = priceCoreBXGrade;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_CY_HPV.SelectedValue = priceCYGrade;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_CY_NONGYNAE.SelectedValue = priceCYNongynaeGrade;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_CY_FNA.SelectedValue = priceCYFNAGrade;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_EBV.SelectedValue = priceEBVGrade;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_CYG.SelectedValue = priceCYGGrade;
            }
            catch (Exception ex)
            {

            }

            textBox_BX.Text = priceBX;
            textBox_CORE_BX.Text = priceCoreBX;
            textBox_CY_HPV.Text = priceCY;
            textBox_CY_NONGYNAE.Text = priceCYNongynae;
            textBox_CY_FNA.Text = priceCYFNA;
            textBox_EBV.Text = priceEBV;
            textBox_CYG.Text = priceCYG;

            textBox_Other.Text = chargeOther;
            textBox_Total.Text = chargeTotal;
        }

        private void recalSum()
        {
            decimal price1 = 0;
            decimal price2 = 0;
            decimal price3 = 0;
            decimal price4 = 0;
            decimal price5 = 0;
            decimal price6 = 0;
            decimal price7 = 0;

            int priceGrade1 = 0;
            int priceGrade2 = 0;
            int priceGrade3 = 0;
            int priceGrade4 = 0;
            int priceGrade5 = 0;
            int priceGrade6 = 0;
            int priceGrade7 = 0;

            decimal priceOther = 0;
            decimal totalPrice = 0;

            decimal.TryParse(textBox_BX.Text.Trim(), out price1);
            decimal.TryParse(textBox_CORE_BX.Text.Trim(), out price2);
            decimal.TryParse(textBox_CY_HPV.Text.Trim(), out price3);
            decimal.TryParse(textBox_CY_NONGYNAE.Text.Trim(), out price4);
            decimal.TryParse(textBox_CY_FNA.Text.Trim(), out price5);
            decimal.TryParse(textBox_EBV.Text.Trim(), out price6);
            decimal.TryParse(textBox_CYG.Text.Trim(), out price7);

            int.TryParse(comboBox_BX.SelectedValue == null ? null : comboBox_BX.SelectedValue.ToString().Trim(), out priceGrade1);
            int.TryParse(comboBox_CORE_BX.SelectedValue == null ? null : comboBox_CORE_BX.SelectedValue.ToString().Trim(), out priceGrade2);
            int.TryParse(comboBox_CY_HPV.SelectedValue == null ? null : comboBox_CY_HPV.SelectedValue.ToString().Trim(), out priceGrade3);
            int.TryParse(comboBox_CY_NONGYNAE.SelectedValue == null ? null : comboBox_CY_NONGYNAE.SelectedValue.ToString().Trim(), out priceGrade4);
            int.TryParse(comboBox_CY_FNA.SelectedValue == null ? null : comboBox_CY_FNA.SelectedValue.ToString().Trim(), out priceGrade5);
            int.TryParse(comboBox_EBV.SelectedValue == null ? null : comboBox_EBV.SelectedValue.ToString().Trim(), out priceGrade6);
            int.TryParse(comboBox_CYG.SelectedValue == null ? null : comboBox_CYG.SelectedValue.ToString().Trim(), out priceGrade7);

            decimal.TryParse(textBox_Other.Text.Trim(), out priceOther);

            totalPrice = price1 * priceGrade1 + price2 * priceGrade2 + price3 * priceGrade3 + price4 * priceGrade4 + price5 * priceGrade5 + price6 * priceGrade6 + price7 * priceGrade7 + priceOther;

            textBox_Total.Text = totalPrice.ToString();
        }
    }
}
