using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderProject
{
    public partial class PiizzaMainForm: Form
    {
        public PiizzaMainForm()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();
            if(rbSmallPizza.Checked)
            {
                lblSetSize.Text = "Small";
                return;
            }
            if(rbMeduimPizza.Checked)
            {
                lblSetSize.Text = "Medium";
                return;
            }
            if(rbLargePizza.Checked)
            {
                lblSetSize.Text = "Large";
                return;
            }
        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if(rbCrustThick.Checked)
            {
                lblSetCrustType.Text = "Thick";
                return;
            }
            lblSetCrustType.Text = "Thin";

        }
        private void HandleWhereToEatOption()
        {
            if (rbEat_In.Checked)
                lblSetWhereToEat.Text = "Eat In";
            else
                lblSetWhereToEat.Text = "Take Out";

        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";
           
            if (chkToppExtraChees.Checked)
            {
                sToppings = "Extra Chees";
            }
            if (chkToppMushr.Checked)
            {
                sToppings += ", Mushrooms";
            }
            if (chkToppGrnPappers.Checked)
            {
                sToppings += ", Green Peppers";
            }
            if (chkToppOlives.Checked)
            {
                sToppings += ", Olives";
            }
            if (chkToppOnion.Checked)
            {
                sToppings += ", Onion";
            }
            if (chkToppTomato.Checked)
            {
                sToppings += ", Tomatos";
            }

            if(sToppings.StartsWith(","))
            {
                sToppings= sToppings.Substring(1, sToppings.Length - 1).Trim();
            }
            if(sToppings == "")
            {
                sToppings = "No Item Selected";
            }
            lblSetToppings.Text = sToppings;
        }
        float GetSelectedSizePrice()
        {
            if (rbSmallPizza.Checked)
            {
                return Convert.ToSingle(rbSmallPizza.Tag);
            } else if(rbMeduimPizza.Checked)
                return Convert.ToSingle(rbMeduimPizza.Tag);
            else
                return Convert.ToSingle(rbLargePizza.Tag);
        }
        float CalculateToppingsPrice()
        {
            float ToppPrice = 0;
            if(chkToppExtraChees.Checked)
            {
                ToppPrice += Convert.ToSingle(chkToppExtraChees.Tag);
            }
            if (chkToppMushr.Checked)
            {
                ToppPrice += Convert.ToSingle(chkToppMushr.Tag);
            }
            if (chkToppGrnPappers.Checked)
            {
                ToppPrice += Convert.ToSingle(chkToppGrnPappers.Tag);
            }
            if (chkToppOlives.Checked)
            {
                ToppPrice += Convert.ToSingle(chkToppOlives.Tag);
            }
            if (chkToppOnion.Checked)
            {
                ToppPrice += Convert.ToSingle(chkToppOnion.Tag);
            }
            if (chkToppTomato.Checked)
            {
                ToppPrice += Convert.ToSingle(chkToppTomato.Tag);
            }
            return ToppPrice;
        }
        float GetSelectedCrustPrice()
        {
            if (rbCrustThick.Checked)
                return Convert.ToSingle(rbCrustThick.Tag);
            else
                return Convert.ToSingle(rbCrustThin.Tag);
        }
        float CalculateTotalPrice()
        {

            return GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrustPrice();
        }
        void UpdateTotalPrice()
        {
            lblSetPrice.Text = "$" + CalculateTotalPrice().ToString();
        }
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateCrust();
            UpdateToppings();
            HandleWhereToEatOption();
            UpdateTotalPrice();
        }
        private void ResetForm()
        {
            
            rbMeduimPizza.Checked = true;
            rbEat_In.Checked = true;
            rbCrustThin.Checked = true;
        
            gbPizzaSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
   
            chkToppExtraChees.Checked = false;
            chkToppMushr.Checked = false;
            chkToppTomato.Checked = false;
            chkToppOnion.Checked = false;
            chkToppOlives.Checked = false;
            chkToppGrnPappers.Checked = false;

            btnOrderNow.Enabled = true;
        }
        private void rbSmallPizza_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbMeduimPizza_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbLargePizza_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbCrustThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }
        private void rbCrustThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEat_In_CheckedChanged(object sender, EventArgs e)
        {
            HandleWhereToEatOption();
        }
        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            HandleWhereToEatOption();
        }

        private void chkToppExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }
        private void chkToppMushr_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }
        private void chkToppTomato_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }
        private void chkToppOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }
        private void chkToppOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }
        private void chkToppGrnPappers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }

        private void btnOrderNow_Click(object sender, EventArgs e)
        {
           
            if(MessageBox.Show("Confirm Order","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Succecc",MessageBoxButtons.OK,MessageBoxIcon.Information);
                gbPizzaSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;

                btnOrderNow.Enabled = false;
            }else
            {
                MessageBox.Show("Order Canceled Successfully", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnResetOrder_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void PiizzaMainForm_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
