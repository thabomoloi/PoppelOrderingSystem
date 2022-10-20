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
    public partial class EnterCustomerNumberDialog : Form
    {
        private CustomerController customerHandler;
        public static string customerNumber;

        public EnterCustomerNumberDialog()
        {
            customerHandler = new CustomerController();
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            if (custNoTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter the customer number.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Customer cust = new Customer
                {
                    CustomerNumber = custNoTextBox.Text.Trim()
                };
                int index = customerHandler.FindIndex(cust);
                if (index == -1)
                {
                    MessageBox.Show("Please enter a valid customer number.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            this.DialogResult = DialogResult.OK;

        }
    }
}
