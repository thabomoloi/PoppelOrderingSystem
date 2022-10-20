using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelOrderingSystem.DatabaseLayer;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class CustomerController
    {
        #region Data Members
        /// <summary>
        /// Reference to customer database
        /// </summary>
        private CustomerDB customerDB;
        /// <summary>
        /// Collection of customers
        /// </summary>
        private Collection<Customer> customers;
        /// <summary>
        /// Reference to a customer
        /// </summary>
        private Customer customer;
        #endregion

        #region Poperties
        public Collection<Customer> AllCustomers
        {
            get { return customers; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Creates a new customer controller object
        /// </summary>
        public CustomerController()
        {
            // Instatiate customer DB to connect with the database
            customerDB = new CustomerDB();
            customers = customerDB.AllCustomers;
        }
        #endregion

        #region Database Communication

        #region Data Maintenance
        /// <summary>
        /// Add changes to the database.
        /// </summary>
        /// <param name="aCust">Customer object</param>
        /// <param name="operation">The database operation</param>
        public void DataMaintenance(Customer aCust, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            customerDB.DataSetChange(aCust, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    customers.Add(aCust);       // Add customer to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aCust);
                    customers[index] = aCust;  
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aCust);   // find the index of the specific Customer in collection
                    customers.RemoveAt(index);  // remove that Customer form the collection
                    break;
            }
        }

        
        #endregion

        #region Finalize Changes
        /// <summary>
        /// Commit the changes to the database
        /// </summary>
        /// <returns>true if successful, else false</returns>
        public bool FinalizeChanges()
        {
            //***call the CustomerDB method that will commit the changes to the database
            return customerDB.UpdateDataSource();

        }
        #endregion

        #endregion

        #region Search Methods
        
        #region Filter by credit status
        /// <summary>
        /// Looks of customers with a required credit status
        /// </summary>
        /// <param name="custs">Customer collection</param>
        /// <param name="status">Require credit status</param>
        /// <returns>customer collection</returns>
        public Collection<Customer> FilterByCreditStatus(Collection<Customer> custs, Customer.CreditStatus status)
        {
            Collection<Customer> matches = new Collection<Customer>();

            foreach (Customer cust in custs)
            {
                if (cust.CustCreditStatus == status)
                    matches.Add(cust);
            }
            return matches;
        }
        #endregion

        #region Find by customer number
        /// <summary>
        /// Finds customer by customer number
        /// </summary>
        /// <param name="customerNumber">Customer number</param>
        /// <returns>Customer collection</returns>
        public Customer Find(string customerNumber)
        {
            int index = 0;
            bool found = (customers[index].CustomerNumber == customerNumber);  //check if it is the first record
            int count = customers.Count;
            while (!(found) && (index < customers.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (customers[index].CustomerNumber == customerNumber);   // this will be TRUE if found
            }
            return customers[index];  
        }
        #endregion

        #region Find index of customer
        /// <summary>
        /// Finds the index of a customer
        /// </summary>
        /// <param name="aCust">Customer</param>
        /// <returns>Index of a customer if found, else -1</returns>
        public int FindIndex(Customer aCust)
        {
            int index = -1;
            bool found = (aCust.CustomerNumber == customers[++index].CustomerNumber);   
            while (!(found) & index < customers.Count - 1)
            {
                index += 1;
                found = (aCust.CustomerNumber == customers[index].CustomerNumber);
            }
            return found ? index : -1;
        }
        #endregion

        #endregion
    }
}