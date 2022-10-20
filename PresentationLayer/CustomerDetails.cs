using PoppelOrderingSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem.PresentationLayer
{
    public partial class CustomerDetails : Form
    {
        private Customer cust;
        public CustomerDetails(Customer customer)
        {
            cust = customer;
            InitializeComponent();
        }

        private void newOrderBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            custNoLabel.Text = cust.CustomerNumber;
            nameLabel.Text = cust.Name;
            creditLabel.Text = "R" + cust.Account.AvailableCredit.ToString();
            balanceLabel.Text = "R" + Math.Abs(cust.Account.Balance).ToString();
            addressLabel.Text = cust.Address.ToString();
            
            switch (cust.CustCreditStatus)
            {
                case Customer.CreditStatus.OnHold:
                    statusLabel.Text = Customer.CreditStatus.OnHold.ToString();
                    statusLabel.ForeColor = Color.Red;
                    newOrderBtn.Visible = false;
                    break;
                case Customer.CreditStatus.Released:
                    statusLabel.Text = Customer.CreditStatus.Released.ToString();
                    statusLabel.ForeColor = Color.Green;
                    newOrderBtn.Visible = true;
                    break;
            }
        }
    }
}
