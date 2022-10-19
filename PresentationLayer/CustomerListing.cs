using PoppelOrderingSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem.PresentationLayer
{
    public partial class CustomerListing : Form
    {
        private class CustomerDataView
        {
            public CustomerDataView()
            {

            }
            public string CustomerNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string AccountStatus { get; set; }
            public string CreditStatus { get; set; }
            public string AvailableCredit { get; set; }
            public string Balance { get; set; }
        }

        CustomerController customerController;
        AccountHandler accountHandler;
        AddressHandler addressHandler;


        public Collection<Customer> Customers { get; set; }
        private Collection<CustomerDataView> CustomerDataViews { get; set; }
        public CustomerListing()
        {
            customerController = new CustomerController();
            accountHandler = new AccountHandler();
            addressHandler = new AddressHandler();

            Customers = customerController.AllCustomers;
            CustomerDataViews = new Collection<CustomerDataView>();
            InitializeComponent();
        }

        private void CustomerListing_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                Customers[i].Address = addressHandler.FindByCustNo(addressHandler.AllAddresses, Customers[i].CustomerNumber);
                Customers[i].Account = accountHandler.FindByCustNo(accountHandler.AllAccounts, Customers[i].CustomerNumber);

                CustomerDataView custDataView = new CustomerDataView
                {
                    CustomerNumber = Customers[i].CustomerNumber,
                    FirstName = Customers[i].FirstName,
                    LastName = Customers[i].LastName,
                    Address = Customers[i].Address.ToString(),
                    AccountStatus = Customers[i].Account.IsOpen ? "Open" : "Closed",
                    CreditStatus = Customers[i].CustCreditStatus == Customer.CreditStatus.OnHold ? "On Hold" : "Released",
                    AvailableCredit = Customers[i].Account.AvailableCredit.ToString(),
                    Balance = Customers[i].Account.Balance.ToString()
                };

                CustomerDataViews.Add(custDataView);
            }
            customerDataGridView.DataSource = CustomerDataViews;
        }
    }
}
