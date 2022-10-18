using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelOrderingSystem.BusinessLayer;

namespace PoppelOrderingSystem.PresentationLayer
{
    public partial class CustomerForm : Form
    {
        #region Data Members
        /// <summary>
        /// Customer controller reference
        /// </summary>
        private CustomerController customerController;
        /// <summary>
        /// Reference to customer
        /// </summary>
        private Customer customer;

        private AddressHandler addressHandler;
        private Address address;

        private AccountHandler accountHandler;
        private Account account;

        private bool custFormClosed = false;
        #endregion

        #region Constructor

        public CustomerForm(CustomerController aCustController, AccountHandler anAccHandler, AddressHandler anAddrHandler)
        {
            InitializeComponent();
            provinceComboBox.SelectedItem = provinceComboBox.Items[0];
            customerController = aCustController;
            addressHandler = anAddrHandler;
            accountHandler = anAccHandler;
        }

        #endregion

        #region Utility methods

        #region Clear All TextBox Controls
        private void ClearAll()
        {
            custNoTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            phoneNoTextBox.Text = "";
            emailTextBox.Text = "";
            streetTextBox.Text = "";
            cityTextBox.Text = "";
            suburbTextBox.Text = "";
            postCodeTextBox.Text = "";
            provinceComboBox.SelectedItem = provinceComboBox.Items[0];
        }
        #endregion

        #region Validate input
        private void ValidateInput(object myObject)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(myObject, null, null);
            bool success = Validator.TryValidateObject(myObject, context, results);

            if (!success)
            {
                foreach (ValidationResult result in results)
                    MessageBox.Show(result.ErrorMessage);
            }
        }
        #endregion
        #region Populate the objects
        private void PopulateObjects()
        {
            // Allocate credit limit of 1500 to customer
            customer = new Customer(1500, Customer.CreditStatus.OnHold);
            address = new Address();
            account = new Account();

            #region Populate customer object

            customer.CustomerNumber = custNoTextBox.Text.Trim();
            customer.FirstName = firstNameTextBox.Text.Trim();
            customer.LastName = lastNameTextBox.Text.Trim();
            customer.Telephone = phoneNoTextBox.Text.Trim();
            customer.Email = emailTextBox.Text.Trim();

            ValidateInput(customer);
            #endregion

            #region Populate the account object

            account.CustomerNumber = customer.CustomerNumber;
            account.DateOpened = DateTime.Now;
            account.IsOpen = true;
            account.AvailableCredit = 1500; // credit
            account.Balance = 0;

            #endregion

            #region Populate address object

            address.Street = streetTextBox.Text.Trim();
            address.Suburb = suburbTextBox.Text.Trim();
            address.City = cityTextBox.Text.Trim();
            address.Province = provinceComboBox.SelectedItem.ToString().Trim();
            address.PostalCode = postCodeTextBox.Text.Trim();

            #endregion

        }
        #endregion

        #endregion

        #region Click Events
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        
        private void submitButton_Click(object sender, EventArgs e)
        {
            PopulateObjects();
        }
        #endregion
    }
}
