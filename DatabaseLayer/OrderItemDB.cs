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
    class OrderItemDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "OrderItems";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM OrderItems";
        /// <summary>
        /// Collection of products
        /// </summary>
        private Collection<OrderItem> products;

        #endregion

        #region Get All OrderItems
        /// <summary>
        /// Get all products
        /// </summary>
        public Collection<OrderItem> AllOrderItems
        {
            get { return products; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of product database
        /// </summary>
        public OrderItemDB() : base()
        {
            // instatiate products
            products = new Collection<OrderItem>();

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
            OrderItem anOI;         // Reference to OrderItem object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new OrderItem object
                    anOI = new OrderItem();
                    // Obtain each OrderItem attribute from the specific field in the row in the table
                    anOI.OrderItemID = Convert.ToInt32(myRow["OrderItemID"]);
                    anOI.Quantity = Convert.ToInt32(myRow["Quantity"]);
                    anOI.Price = Convert.ToDouble((myRow["Price"]));
                    anOI.InventoryItemID = Convert.ToInt32(myRow["InventoryItemID"]);
                    // Add products to collection
                    products.Add(anOI);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with product information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="anOI">The product</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, OrderItem anOI, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["OrderItemID"] = anOI.OrderItemID;
            }
            aRow["Quantity"] = anOI.Quantity;
            aRow["Price"] = anOI.Price;
            aRow["InventoryItemID"] = anOI.InventoryItemID;
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the product is found.
        /// </summary>
        /// <param name="anOI">The product</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(OrderItem anOI, string table)
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
                    if (anOI.OrderItemID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["OrderItemID"]))
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
        /// <param name="anOI">OrderItem</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(OrderItem anOI, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anOI, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOI, dataTable)];
                    FillRow(aRow, anOI, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOI, dataTable)];
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

            param = new SqlParameter("@Quantity", SqlDbType.Int, 4, "Quantity");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Price", SqlDbType.Money, 8, "Price");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, "InventoryItemID");
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

            param = new SqlParameter("@Quantity", SqlDbType.Int, 4, "Quantity");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Price", SqlDbType.Money, 8, "Price");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, "InventoryItemID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.Int, 4, "OrderItemID");
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
            param = new SqlParameter("@OrderItemID", SqlDbType.Int, 4, "OrderItemID");
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
        /// <param name="anOI"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into OrderItems (Quantity, Price, InventoryItemID)" +
                " VALUES (@Quantity, @Price,  @InventoryItemID)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="anOI"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the product number
            daMain.UpdateCommand = new SqlCommand("UPDATE OrderItems SET Quantity =@Quantity, Price =@Price, InventoryItemID =@InventoryItemID " + "WHERE OrderItemID = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM OrderItems WHERE OrderItemID = @OrderItemID", cnMain);
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
