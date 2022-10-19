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
    class MarketingClerkDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "MarketingClerks";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM MarketingClerks";
        /// <summary>
        /// Collection of clerks
        /// </summary>
        private Collection<MarketingClerk> clerks;

        #endregion

        #region Get All MarketingClerks
        /// <summary>
        /// Get ll clerks
        /// </summary>
        public Collection<MarketingClerk> AllMarketingClerks
        {
            get { return clerks; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of clerk database
        /// </summary>
        public MarketingClerkDB() : base()
        {
            // instatiate clerks
            clerks = new Collection<MarketingClerk>();

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
        /// Reads clerks from the table and add them to collection.
        /// </summary>
        /// <param name="table">Name of the database table</param>
        private void Add2Collection(string table)
        {
            DataRow myRow = null;   // Reference to DataRow object
            MarketingClerk aMC;         // Reference to MarketingClerk object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new MarketingClerk object
                    aMC = new MarketingClerk();
                    // Obtain each MarketingClerk attribute from the specific field in the row in the table
                    aMC.ClerkID = Convert.ToString(myRow["ClerkID"]).TrimEnd();
                    aMC.FirstName = Convert.ToString(myRow["FirstName"]).TrimEnd();
                    aMC.LastName = Convert.ToString(myRow["LastName"]).TrimEnd();
                    aMC.Email = Convert.ToString(myRow["Email"]).TrimEnd();
                    aMC.Telephone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    aMC.UserID = Convert.ToInt32(myRow["UserID"]);
                    // Add clerks to collection
                    clerks.Add(aMC);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with clerk information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="aMC">The clerk</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, MarketingClerk aMC, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ClerkID"] = aMC.ClerkID;
            }
            aRow["FirstName"] = aMC.FirstName;
            aRow["LastName"] = aMC.LastName;
            aRow["Phone"] = aMC.Telephone;
            aRow["Email"] = aMC.Email;
            aRow["UserID"] = aMC.UserID;
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the clerk is found.
        /// </summary>
        /// <param name="aMC">The clerk</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(MarketingClerk aMC, string table)
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
                    // Assign rowIndex to returnValue if clerk number is found
                    if (aMC.ClerkID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ClerkID"]))
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
        /// <param name="aMC">MarketingClerk</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(MarketingClerk aMC, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aMC, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aMC, dataTable)];
                    FillRow(aRow, aMC, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aMC, dataTable)];
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

            param = new SqlParameter("@ClerkID", SqlDbType.NVarChar, 15, "ClerkID");
            daMain.InsertCommand.Parameters.Add(param); //Add the parameter to the Parameters collection.

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@LastName", SqlDbType.NVarChar, 50, "LastName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 50, "Email");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int, 4 , "UserID");
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

            param = new SqlParameter("@UserID", SqlDbType.Int, 4 , "UserID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);


            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ClerkID");
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
            param = new SqlParameter("@ClerkID", SqlDbType.NVarChar, 15, "ClerkID");
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
        /// <param name="aMC"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into MarketingClerks (ClerkID, FirstName, LastName, Phone, Email, UserID)" +
                " VALUES (@ClerkID, @FirstName, @LastName, @Phone, @Email, @UserID)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="aMC"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the clerk number
            daMain.UpdateCommand = new SqlCommand("UPDATE MarketingClerks SET FirstName =@FirstName, LastName =@LastNme, Phone =@Phone, Email =@Email, UserID =@UserID " + "WHERE ClerkID = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM MarketingClerks WHERE ClerkID = @ClerkID", cnMain);
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
