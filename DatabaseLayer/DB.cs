using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelOrderingSystem.Properties;

namespace PoppelOrderingSystem.DatabaseLayer
{
    public class DB
    {
        #region Enumeration - CRUD Operations
        /// <summary>
        /// Represents database operations: Add, Edit and Delete
        /// </summary>
        public enum DBOperation 
        {
            Add = 0, 
            Edit = 1,
            Delete = 2
        }
        #endregion

        #region Variable declaration

        #region Private 
        ///<summary>Represents the connection string</summary> 
        private string strConn = Settings.Default.PoppelDatabaseConnectionString;
        #endregion

        #region Protected - To be inherited by subclassess
        ///<summary>Represents a connection to a SQL Server database.</summary>
        protected SqlConnection cnMain;

        ///<summary>Represents data from the database</summary>
        protected DataSet dsMain;

        ///<summary>Represensts set of SQL commands and data connection used to
        /// fill DataSet and update data source </summary>
        protected SqlDataAdapter daMain;
        #endregion

        #endregion

        #region Constructor 
        /// <summary>
        /// Creates a new DB object.
        /// </summary>
        public DB()
        {
            try
            {
                // Open a new connection object
                cnMain = new SqlConnection(strConn);
                // Create a new dataset object
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                // Show exception
                MessageBox.Show(e.Message, "Error");
                return;
            }
        }
        #endregion

        #region Fill dataset 
        /// <summary>
        /// Fills dataset fresh from the db for a specific table and with a specific Query
        /// </summary>
        /// <param name="aSQLstring">SQL query</param>
        /// <param name="aTable">Table name</param>
        public void FillDataSet(string aSQLstring, string aTable)
        {
            try
            {
                // Create an instance of the data adapter (daMain). 
                daMain = new SqlDataAdapter(aSQLstring, cnMain);
                // Opens a database connection with the property settings specified by the ConnectionString.
                cnMain.Open();

                //Adds or refreshes rows in the DataSet to match those in the data source
                //is used to populate a DataSet with the results of the SelectCommand of the DataAdapter.
                //Fill takes as its arguments a DataSet to be populated, and a DataTable object, or the name of the DataTable to be filled with the rows returned from the SelectCommand.
                daMain.Fill(dsMain, aTable);

                //close the connection              
                cnMain.Close();     
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }
        #endregion

        #region Update the data source
        /// <summary>
        /// Update the data source.
        /// </summary>
        /// <param name="sqlLocal">SQL statement to be used to do the update</param>
        /// <param name="table">The table which needs to be updated</param>
        /// <returns>true if the update was successfule, else false</returns>
        protected bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success; // Boolean variable success that will signal the successful update
            try
            {
                // open the connection
                cnMain.Open();   

                #region Update the database table via the data adapter
                daMain.Update(dsMain, table);
                /*
                 The Update method of the DataAdapter is called to resolve changes from a DataSet
                 back to the data source. The Update method, like the Fill method, takes as arguments
                 an instance of a DataSet, and an optional DataTable object or DataTable name.
                 When you call the Update method, the DataAdapter analyzes the changes that have been made and
                 executes the appropriate command (INSERT, UPDATE, or DELETE). When the DataAdapter encounters a 
                 change to a DataRow, it uses the InsertCommand, UpdateCommand, or DeleteCommand to process the change. 
                 */

                #endregion

                cnMain.Close(); // close the connection

                #region  Fill the dataset with the SQL statement sqlLocal and the specific table table
                FillDataSet(sqlLocal, table); //refresh the dataset using the SQL statement; and the Table from which the query will emanate from
                #endregion

                success = true;// The variable success returns true (Assign true to the variable success).
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally
            {
            }
            return success;
        }
        #endregion
    }
}
