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
    class CatalogDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "Catalogs";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM Catalogs";
        /// <summary>
        /// Collection of catalogs
        /// </summary>
        private Collection<Catalog> catalogs;

        #endregion

        #region Get All Catalogs
        /// <summary>
        /// Get all catalogs
        /// </summary>
        public Collection<Catalog> AllCatalogs
        {
            get { return catalogs; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of catalog database
        /// </summary>
        public CatalogDB() : base()
        {
            // instatiate catalogs
            catalogs = new Collection<Catalog>();

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
        /// Reads catalogs from the table and add them to collection.
        /// </summary>
        /// <param name="table">Name of the database table</param>
        private void Add2Collection(string table)
        {
            DataRow myRow = null;   // Reference to DataRow object
            Catalog aCat;         // Reference to Catalog object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new Catalog object
                    aCat = new Catalog();
                    // Obtain each Catalog attribute from the specific field in the row in the table
                    aCat.CatalogID = Convert.ToString(myRow["CatalogID"]).TrimEnd();
                    aCat.Description = Convert.ToString(myRow["Description"]).TrimEnd();
                    aCat.Year = Convert.ToInt32(myRow["Year"]);
                    aCat.EffectiveDate = Convert.ToDateTime(myRow["EffectiveDate"]);
                    aCat.EndDate = Convert.ToDateTime(myRow["EndDate"]);
                    // Add catalogs to collection
                    catalogs.Add(aCat);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with catalog information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="aCat">The catalog</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, Catalog aCat, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["CatalogID"] = aCat.CatalogID;
            }
            aRow["Description"] = aCat.Description;
            aRow["Year"] = aCat.Year;
            aRow["EndDate"] = aCat.EndDate;
            aRow["EffectiveDate"] = aCat.EffectiveDate;
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the catalog is found.
        /// </summary>
        /// <param name="aCat">The catalog</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(Catalog aCat, string table)
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
                    // Assign rowIndex to returnValue if catalog number is found
                    if (aCat.CatalogID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["CatalogID"]).TrimEnd())
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
        /// <param name="aCat">Catalog</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(Catalog aCat, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aCat, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCat, dataTable)];
                    FillRow(aRow, aCat, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCat, dataTable)];
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

            param = new SqlParameter("@CatalogID", SqlDbType.NVarChar, 15, "CatalogID");
            daMain.InsertCommand.Parameters.Add(param); //Add the parameter to the Parameters collection.

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Year", SqlDbType.Int, 4, "Year");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.Date, 3, "EndDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@EffectiveDate", SqlDbType.Date, 3, "EffectiveDate");
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

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Year", SqlDbType.Int, 4, "Year");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.Date, 3, "EndDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@EffectiveDate", SqlDbType.Date, 3, "EffectiveDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "CatalogID");
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
            param = new SqlParameter("@CatalogID", SqlDbType.NVarChar, 15, "CatalogID");
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
        /// <param name="aCat"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into Catalogs (Description, Year, EndDate, EffectiveDate)" +
                " VALUES (@Description, @Year, @EndDate, @EffectiveDate)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="aCat"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the catalog number
            daMain.UpdateCommand = new SqlCommand("UPDATE Catalogs SET Description =@Description, Year =@Year, EndDate =@EndDate, EffectiveDate =@EffectiveDate " + "WHERE CatalogID = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Catalogs WHERE CatalogID = @CatalogID", cnMain);
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
