using PoppelOrderingSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.DatabaseLayer
{
    public class CustomerDB : DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "Customers";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM Customers";
        /// <summary>
        /// Collection of customers
        /// </summary>
        private Collection<Customer> customers;

        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of customer database
        /// </summary>
        public CustomerDB() : base()
        {
            // instatiate customers
            customers = new Collection<Customer>();

            FillDataSet(sqlLocal, table);
            Add2Collection(table);
        }
        #endregion

        #region Utility Methods

        #region GetDataSet
        /// <summary>
        /// Retrieves the data set.
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            return dsMain;
        }
        #endregion

        #region Add2Collection
        /// <summary>
        /// Reads customers from the table and add them to collection.
        /// </summary>
        /// <param name="table">Name of the database table</param>
        private void Add2Collection(string table)
        {
            DataRow myRow = null;   // Reference to DataRow object
            Customer aCust;         // Reference to Customer object
            
            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new Customer object
                    aCust = new Customer(0, Customer.CreditStatus.NoCredit);
                    // Obtain each Customer attribute from the specific field in the row in the table
                    aCust.CustomerNumber = Convert.ToString(myRow["CustomerNumber"]).TrimEnd();
                    aCust.FirstName = Convert.ToString(myRow["FirstName"]).TrimEnd();
                    aCust.LastName = Convert.ToString(myRow["LastName"]).TrimEnd();
                    aCust.Email = Convert.ToString(myRow["Email"]).TrimEnd();
                    aCust.Telephone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    aCust.CreditLimit = Convert.ToDouble(myRow["CreditLimit"]);

                    // Credit Status
                    switch (Convert.ToString(myRow["CreditStatus"]).TrimEnd())
                    {
                        case "OnHold":
                            aCust.CustCreditStatus = Customer.CreditStatus.OnHold;
                            break;
                        case "Released":
                            aCust.CustCreditStatus = Customer.CreditStatus.Released;
                            break;
                        case "NoCredit":
                            aCust.CustCreditStatus = Customer.CreditStatus.NoCredit;
                            break;
                    }
                    // Add customers to collection
                    customers.Add(aCust);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with customer information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="aCust">The customer</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, Customer aCust, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["CustomerNumber"] = aCust.CustomerNumber;
            }
            aRow["FirstName"] = aCust.FirstName;
            aRow["LastName"] = aCust.LastName;
            aRow["Phone"] = aCust.Telephone;
            aRow["Email"] = aCust.Email;
            aRow["CreditLimit"] = aCust.CreditLimit;

            switch (aCust.CustCreditStatus)
            {
                case Customer.CreditStatus.OnHold:
                    aRow["CreditStatus"] = "OnHold";
                    break;
                case Customer.CreditStatus.Released:
                    aRow["CreditStatus"] = "Released";
                    break;
                case Customer.CreditStatus.NoCredit:
                    aRow["CreditStatus"] = "NoCredit";
                    break;
            }
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the customer is found.
        /// </summary>
        /// <param name="aCust">The customer</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(Customer aCust, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Assign rowIndex to returnValue if customer number is found
                    if (aCust.CustomerNumber == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["CustomerNumber"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }
        #endregion

        #endregion
    }
}
