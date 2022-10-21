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
    public class InventoryItemDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "InventoryItems";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM InventoryItems";
        /// <summary>
        /// Collection of products
        /// </summary>
        private Collection<InventoryItem> products;

        #endregion

        #region Get All InventoryItems
        /// <summary>
        /// Get all products
        /// </summary>
        public Collection<InventoryItem> AllInventoryItems
        {
            get { return products; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of product database
        /// </summary>
        public InventoryItemDB() : base()
        {
            // instatiate products
            products = new Collection<InventoryItem>();

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
        /// Reads products from the table and add them to collection.
        /// </summary>
        /// <param name="table">Name of the database table</param>
        private void Add2Collection(string table)
        {
            DataRow myRow = null;   // Reference to DataRow object
            InventoryItem anInv;         // Reference to InventoryItem object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new InventoryItem object
                    anInv = new InventoryItem();
                    // Obtain each InventoryItem attribute from the specific field in the row in the table
                    anInv.InventoryItemID = Convert.ToInt32(myRow["InventoryItemID"]);
                    anInv.QuantityOnHand = Convert.ToInt32(myRow["QuantityOnHand"]);
                    anInv.QuantityInStock = Convert.ToInt32((myRow["QuantityInStock"]));
                    anInv.ProductID = Convert.ToString(myRow["ProductID"]).TrimEnd();
                    // Add products to collection
                    products.Add(anInv);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with product information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="anInv">The product</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, InventoryItem anInv, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["InventoryItemID"] = anInv.InventoryItemID;
            }
            aRow["QuantityOnHand"] = anInv.QuantityOnHand;
            aRow["QuantityInStock"] = anInv.QuantityInStock;
            aRow["ProductID"] = anInv.ProductID;
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the product is found.
        /// </summary>
        /// <param name="anInv">The product</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(InventoryItem anInv, string table)
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
                    // Assign rowIndex to returnValue if product number is found
                    if (anInv.InventoryItemID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["InventoryItemID"]))
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
        /// <param name="anInv">InventoryItem</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(InventoryItem anInv, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anInv, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anInv, dataTable)];
                    FillRow(aRow, anInv, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anInv, dataTable)];
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

            param = new SqlParameter("@QuantityOnHand", SqlDbType.Int, 4, "QuantityOnHand");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@QuantityInStock", SqlDbType.Int, 4, "QuantityInStock");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 15, "ProductID");
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

            param = new SqlParameter("@QuantityOnHand", SqlDbType.Int, 4, "QuantityOnHand");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@QuantityInStock", SqlDbType.Int, 4, "QuantityInStock");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 15, "ProductID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "InventoryItemID");
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
            param = new SqlParameter("@InventoryItemID", SqlDbType.NVarChar, 15, "InventoryItemID");
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
        /// <param name="anInv"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into InventoryItems (QuantityOnHand, QuantityInStock, ProductID)" +
                " VALUES (@QuantityOnHand, @QuantityInStock,  @ProductID)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="anInv"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the product number
            daMain.UpdateCommand = new SqlCommand("UPDATE InventoryItems SET QuantityOnHand =@QuantityOnHand, QuantityInStock =@QuantityInStock, ProductID =@ProductID " + "WHERE InventoryItemID = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM InventoryItems WHERE InventoryItemID = @InventoryItemID", cnMain);
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
