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
using PoppelOrderingSystem.DatabaseLayer;

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
        private AccountHandler accountHandler;

        private Account account;
        private Address address;

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
        private bool ValidateInput(object myObject)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(myObject, null, null);
            bool success = Validator.TryValidateObject(myObject, context, results, true);

            if (!success)
            {
                foreach (ValidationResult result in results)
                {
                    MessageBox.Show(result.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return success;
                }
            }
            return success;
        }
        #endregion

        #region Populate object 
        private bool PopulateObject()
        {
            customer = new Customer(1500, Customer.CreditStatus.Released)
            {
                CustomerNumber = custNoTextBox.Text.Trim(),
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                Telephone = phoneNoTextBox.Text.Trim()
            };


            address = new Address
            {
                Street = streetTextBox.Text.Trim(),
                City = cityTextBox.Text.Trim(),
                Suburb = suburbTextBox.Text.Trim(),
                Province = provinceComboBox.SelectedItem.ToString(),
                PostalCode = postCodeTextBox.Text.Trim(),
                CustomerNumber = customer.CustomerNumber
            };

            account = new Account
            {
                CustomerNumber = customer.CustomerNumber,
                AvailableCredit = 1500,
                Balance = 0,
                IsOpen = true,
                DateOpened = DateTime.Now
            };

            bool validCustomer = ValidateInput(customer);
            return validCustomer;
        }
        #endregion

        #region Add to database 
        private void InsertDataToDatabse()
        {
            MessageBox.Show("To be submitted to the Database!");
            customerController.DataMaintenance(customer, DB.DBOperation.Add);
            customerController.FinalizeChanges();
            addressHandler.DataMaintenance(address, DB.DBOperation.Add);
            addressHandler.FinalizeChanges();
            accountHandler.DataMaintenance(account, DB.DBOperation.Add);
            accountHandler.FinalizeChanges();
        }
        #endregion

        #region Click Events
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        
        private void submitButton_Click(object sender, EventArgs e)
        {
            bool populated = PopulateObject();
            if (populated)
            {
                InsertDataToDatabse();
                ClearAll();
            }
            
        }
        #endregion

        #endregion
    }
}
