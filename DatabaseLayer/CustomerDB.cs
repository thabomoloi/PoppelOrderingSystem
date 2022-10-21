using PoppelOrderingSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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

        #region Get All Customers
        /// <summary>
        /// Get ll customers
        /// </summary>
        public Collection<Customer> AllCustomers
        {
            get { return customers;  }
        }
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

        #region Database Operations CRUD
        /// <summary>
        /// Add changes to dataset.
        /// </summary>
        /// <param name="aCust">Customer</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(Customer aCust, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation .Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aCust, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation .Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCust, dataTable)];
                    FillRow(aRow, aCust, operation);
                    break;
                case DBOperation .Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCust, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database

        #region Build parameters

        #region Build insert parameters
        /// <summary>
        /// Builds insert parameters 
        /// </summary>
        private void Build_INSERT_Parameters()
        {
            // Create Parameters to communicate with SQL INSERT add the input parameter and set its properties.             
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@CustomerNumber", SqlDbType.NVarChar, 15, "CustomerNumber");
            daMain.InsertCommand.Parameters.Add(param); //Add the parameter to the Parameters collection.

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@LastName", SqlDbType.NVarChar, 50, "LastName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 50, "Email");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditLimit", SqlDbType.Money, 8, "CreditLimit");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditStatus", SqlDbType.NVarChar, 15, "CreditStatus");
            daMain.InsertCommand.Parameters.Add(param);
        }
        #endregion

        #region Build update parameters
        /// <summary>
        /// Builds update parameters
        /// </summary>
        private void Build_UPDATE_Parameters()
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@LastName", SqlDbType.NVarChar, 50, "LastName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 50, "Email");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditLimit", SqlDbType.Money, 8, "CreditLimit");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditStatus", SqlDbType.NVarChar, 15, "CreditStatus");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "CustomerNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }
        #endregion

        #region Build delete parameters
        /// <summary>
        /// Builds the delete parameters
        /// </summary>
        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@CustomerNumber", SqlDbType.NVarChar, 15, "CustomerNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }
        #endregion

        #endregion

        #region Create Commands

        #region Create insert command
        /// <summary>
        /// Create  an insert command
        /// </summary>
        /// <param name="aCust"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into Customers (CustomerNumber, FirstName, LastName, Phone, Email, CreditLimit, CreditStatus)" +
                " VALUES (@CustomerNumber, @FirstName, @LastName, @Phone, @Email, @CreditLimit, @CreditStatus)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="aCust"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the customer number
            daMain.UpdateCommand = new SqlCommand("UPDATE Customers SET FirstName =@FirstName, LastName =@LastName, Phone =@Phone, Email =@Email, CreditLimit =@CreditLimit, CreditStatus =@CreditStatus " + "WHERE CustomerNumber = @Original_ID", cnMain);
            Build_UPDATE_Parameters();
        }
        #endregion

        #region Create delete command
        /// <summary>
        /// Creates a delete command
        /// </summary>
        /// <returns>error string</returns>
        private string Create_DELETE_Command()
        {
            string errorString = null;
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Customers WHERE CustomerNumber = @CustomerNumber", cnMain);
            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }
        #endregion

        #endregion

        #region Update data source
        /// <summary>
        /// Updates the data source
        /// </summary>
        /// <returns>true if successful update, else false</returns>
        public bool UpdateDataSource()
        {
            Create_INSERT_Command();
            Create_UPDATE_Command();
            Create_DELETE_Command();
            bool success = UpdateDataSource(sqlLocal, table);
            return success;
        }
        #endregion

        #endregion
    }
}
