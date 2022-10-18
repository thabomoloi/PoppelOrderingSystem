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
    public class AddressDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "Addresses";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM Addresses";
        /// <summary>
        /// Collection of addresses
        /// </summary>
        private Collection<Address> addresses;

        #endregion

        #region Get All Addresses
        /// <summary>
        /// Get all addresses
        /// </summary>
        public Collection<Address> AllAddresses
        {
            get { return addresses; }
        }
        #endregion
        
        #region Constructor 
        /// <summary>
        /// Create new instance of address database
        /// </summary>
        public AddressDB() : base()
        {
            // instatiate addresses
            addresses = new Collection<Address>();

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
        /// Reads addresses from the table and add them to collection.
        /// </summary>
        /// <param name="table">Name of the database table</param>
        private void Add2Collection(string table)
        {
            DataRow myRow = null;   // Reference to DataRow object
            Address anAddr;         // Reference to Address object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new Address object
                    anAddr = new Address();
                    // Obtain each Address attribute from the specific field in the row in the table
                    anAddr.AddressID = Convert.ToInt32(myRow["AddressID"]);
                    anAddr.Street = Convert.ToString(myRow["Street"]).TrimEnd();
                    anAddr.Suburb = Convert.ToString(myRow["Suburb"]).TrimEnd();
                    anAddr.City = Convert.ToString(myRow["City"]).TrimEnd();
                    anAddr.Province = Convert.ToString(myRow["Province"]).TrimEnd();
                    anAddr.PostalCode = Convert.ToString(myRow["PostalCode"]);
                    anAddr.CustomerNumber = Convert.ToString(myRow["CustomerNumber"]);

                    // Add addresses to collection
                    addresses.Add(anAddr);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with address information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="anAddr">The address</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, Address anAddr, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["AddressID"] = anAddr.AddressID;
            }
            aRow["Street"] = anAddr.Street;
            aRow["Suburb"] = anAddr.Suburb;
            aRow["Province"] = anAddr.Province;
            aRow["City"] = anAddr.City;
            aRow["PostalCode"] = anAddr.PostalCode;
            aRow["CustomerNumber"] = anAddr.CustomerNumber;
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the address is found.
        /// </summary>
        /// <param name="anAddr">The address</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(Address anAddr, string table)
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
                    // Assign rowIndex to returnValue if address number is found
                    if (anAddr.AddressID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["AddressID"]))
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
        /// <param name="anAddr">Address</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(Address anAddr, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anAddr, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anAddr, dataTable)];
                    FillRow(aRow, anAddr, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anAddr, dataTable)];
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

            param = new SqlParameter("@AddressID", SqlDbType.NVarChar, 15, "AddressID");
            daMain.InsertCommand.Parameters.Add(param); //Add the parameter to the Parameters collection.

            param = new SqlParameter("@Street", SqlDbType.NVarChar, 50, "Street");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Suburb", SqlDbType.NVarChar, 50, "Suburb");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Province", SqlDbType.NVarChar, 50, "Province");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@City", SqlDbType.NVarChar, 50, "City");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 4, "PostalCode");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerNumber", SqlDbType.NVarChar, 15, "CustomerNumber");
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

            param = new SqlParameter("@Street", SqlDbType.NVarChar, 50, "Street");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Suburb", SqlDbType.NVarChar, 50, "Suburb");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Province", SqlDbType.NVarChar, 50, "Province");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@City", SqlDbType.NVarChar, 50, "City");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 4, "PostalCode");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerNumber", SqlDbType.NVarChar, 15, "CustomerNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "AddressID");
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
            param = new SqlParameter("@AddressID", SqlDbType.NVarChar, 15, "AddressID");
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
        /// <param name="anAddr"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into Addresses (Street, Suburb, Province, City, PostalCode, CustomerNumber)" +
                " VALUES (@Street, @Suburb, @Province, @City, @PostalCode, @CustomerNumber)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="anAddr"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the address number
            daMain.UpdateCommand = new SqlCommand("UPDATE Addresses SET Street =@Street, Suburb =@Suburb, Province =@Province, City =@City, PostalCode =@PostalCode, CustomerNumber =@CustomerNumber " + "WHERE AddressID = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Addresses WHERE AddressID = @AddressID", cnMain);
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
