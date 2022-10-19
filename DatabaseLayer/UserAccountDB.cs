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
    public class UserAccountDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "UserAccounts";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM UserAccounts";
        /// <summary>
        /// Collection of accounts
        /// </summary>
        private Collection<UserAccount> accounts;

        #endregion

        #region Get All UserAccounts
        /// <summary>
        /// Get all accounts
        /// </summary>
        public Collection<UserAccount> AllUserAccounts
        {
            get { return accounts; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of address database
        /// </summary>
        public UserAccountDB() : base()
        {
            // instatiate accounts
            accounts = new Collection<UserAccount>();

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
        /// Reads accounts from the table and add them to collection.
        /// </summary>
        /// <param name="table">Name of the database table</param>
        private void Add2Collection(string table)
        {
            DataRow myRow = null;   // Reference to DataRow object
            UserAccount anAcc;         // Reference to UserAccount object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new UserAccount object
                    anAcc = new UserAccount();
                    // Obtain each UserAccount attribute from the specific field in the row in the table
                    anAcc.UserID = Convert.ToInt32(myRow["UserID"]);
                    anAcc.Password = Convert.ToString(myRow["Password"]).TrimEnd();

                    // Add accounts to collection
                    accounts.Add(anAcc);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with address information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="anAcc">The address</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, UserAccount anAcc, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["UserID"] = anAcc.UserID;
            }
            aRow["Password"] = anAcc.Password;
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the address is found.
        /// </summary>
        /// <param name="anAcc">The address</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(UserAccount anAcc, string table)
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
                    if (anAcc.UserID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["UserID"]))
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
        /// <param name="anAcc">UserAccount</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(UserAccount anAcc, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anAcc, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anAcc, dataTable)];
                    FillRow(aRow, anAcc, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anAcc, dataTable)];
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

            param = new SqlParameter("@Password", SqlDbType.NVarChar, 100, "Password");
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

            param = new SqlParameter("@Password", SqlDbType.NVarChar, 100, "Password");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.Int, 4, "UserID");
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
            param = new SqlParameter("@UserID", SqlDbType.Int, 4, "UserID");
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
        /// <param name="anAcc"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into UserAccounts (Password)" +
                " VALUES (@Password)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="anAcc"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the address number
            daMain.UpdateCommand = new SqlCommand("UPDATE UserAccounts SET Password =@Password " + "WHERE UserID = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM UserAccounts WHERE UserID = @UserID", cnMain);
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
