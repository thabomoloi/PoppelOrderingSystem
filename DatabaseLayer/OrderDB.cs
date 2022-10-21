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
    public class OrderDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "Orders";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM Orders";
        /// <summary>
        /// Collection of orders
        /// </summary>
        private Collection<Order> orders;

        #endregion

        #region Get All Orders
        /// <summary>
        /// Get ll orders
        /// </summary>
        public Collection<Order> AllOrders
        {
            get { return orders; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of customer database
        /// </summary>
        public OrderDB() : base()
        {
            // instatiate orders
            orders = new Collection<Order>();

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
        /// Reads orders from the table and add them to collection.
        /// </summary>
        /// <param name="table">Name of the database table</param>
        private void Add2Collection(string table)
        {
            DataRow myRow = null;   // Reference to DataRow object
            Order anOrd;         // Reference to Order object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new Order object
                    anOrd = new Order();
                    // Obtain each Order attribute from the specific field in the row in the table
                    anOrd.OrderNumber = Convert.ToInt32(myRow["OrderNumber"]);
                    anOrd.OrderDate = Convert.ToDateTime(myRow["OrderDate"]);
                    anOrd.DeliveryDate = Convert.ToDateTime(myRow["DeliveryDate"]);
                    anOrd.Total = Convert.ToDouble(myRow["Total"]);
                    anOrd.CustomerNumber = Convert.ToString(myRow["CustomerNumber"]).TrimEnd();
                    anOrd.ClerkID = Convert.ToString(myRow["ClerkID"]).TrimEnd();

                    // Credit Status
                    switch (Convert.ToString(myRow["Status"]).TrimEnd())
                    {
                        case "New":
                            anOrd.Status = Order.OrderStatus.New;
                            break;
                        case "OnHold":
                            anOrd.Status = Order.OrderStatus.OnHold;
                            break;
                        case "Confirmed":
                            anOrd.Status = Order.OrderStatus.Confirmed;
                            break;
                        case "Cancelled":
                            anOrd.Status = Order.OrderStatus.Cancelled;
                            break;
                        case "Shipped":
                            anOrd.Status = Order.OrderStatus.Shipped;
                            break;
                        case "Delivered":
                            anOrd.Status = Order.OrderStatus.Delivered;
                            break;
                        case "Closed":
                            anOrd.Status = Order.OrderStatus.New;
                            break;
                    }
                    // Add orders to collection
                    orders.Add(anOrd);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with customer information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="anOrd">The customer</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, Order anOrd, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["OrderNumber"] = anOrd.OrderNumber;
            }
            aRow["OrderDate"] = anOrd.OrderDate;
            aRow["DeliveryDate"] = anOrd.DeliveryDate;
            aRow["CustomerNumber"] = anOrd.CustomerNumber;
            aRow["Total"] = anOrd.Total;
            aRow["ClerkID"] = anOrd.ClerkID;

            switch (anOrd.Status)
            {
                case Order.OrderStatus.OnHold:
                    aRow["Status"] = "OnHold";
                    break;
                case Order.OrderStatus.New:
                    aRow["Status"] = "New";
                    break;
                case Order.OrderStatus.Confirmed:
                    aRow["Status"] = "Confirmed";
                    break;
                case Order.OrderStatus.Cancelled:
                    aRow["Status"] = "Cancelled";
                    break;
                case Order.OrderStatus.Shipped:
                    aRow["Status"] = "Shipped";
                    break;
                case Order.OrderStatus.Delivered:
                    aRow["Status"] = "Delivered";
                    break;
                case Order.OrderStatus.Closed:
                    aRow["Status"] = "Closed";
                    break;
            }
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the customer is found.
        /// </summary>
        /// <param name="anOrd">The customer</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(Order anOrd, string table)
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
                    if (anOrd.OrderNumber == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["OrderNumber"]))
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
        /// <param name="anOrd">Order</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(Order anOrd, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anOrd, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOrd, dataTable)];
                    FillRow(aRow, anOrd, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOrd, dataTable)];
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

            param = new SqlParameter("@OrderDate", SqlDbType.Date, 3, "OrderDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@DeliveryDate", SqlDbType.Date, 3, "DeliveryDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerNumber", SqlDbType.NVarChar, 15, "CustomerNumber");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Money, 8, "Total");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ClerkID", SqlDbType.NVarChar, 15, "ClerkID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.NVarChar, 15, "Status");
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

            param = new SqlParameter("@OrderDate", SqlDbType.Date, 3, "OrderDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@DeliveryDate", SqlDbType.Date, 3, "DeliveryDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerNumber", SqlDbType.NVarChar, 15, "CustomerNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Money, 8, "Total");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ClerkID", SqlDbType.NVarChar, 15, "ClerkID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.NVarChar, 15, "Status");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.Int, 4, "OrderNumber");
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
            param = new SqlParameter("@OrderNumber", SqlDbType.Int, 4, "OrderNumber");
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
        /// <param name="anOrd"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into Orders (OrderDate, DeliveryDate, CustomerNumber, Total, ClerkID, Status)" +
                " VALUES (@OrderDate, @DeliveryDate, @CustomerNumber, @Total, @ClerkID, @Status)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="anOrd"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the customer number
            daMain.UpdateCommand = new SqlCommand("UPDATE Orders SET OrderDate =@OrderDate, DeliveryDate =@DeliveryDate, CustomerNumber =@CustomerNumber, Total =@Total, ClerkID =@ClerkID, Status =@Status " + "WHERE OrderNumber = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Orders WHERE OrderNumber = @OrderNumber", cnMain);
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
