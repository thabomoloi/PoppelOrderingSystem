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
    public class ProductDB: DB
    {
        #region Data Members 
        /// <summary>
        /// Name of the table
        /// </summary>
        private string table = "Products";
        /// <summary>
        /// SQL Select query
        /// </summary>
        private string sqlLocal = "SELECT * FROM Products";
        /// <summary>
        /// Collection of products
        /// </summary>
        private Collection<Product> products;

        #endregion

        #region Get All Products
        /// <summary>
        /// Get all products
        /// </summary>
        public Collection<Product> AllProducts
        {
            get { return products; }
        }
        #endregion

        #region Constructor 
        /// <summary>
        /// Create new instance of product database
        /// </summary>
        public ProductDB() : base()
        {
            // instatiate products
            products = new Collection<Product>();

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
            Product aProd;         // Reference to Product object

            // READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // Instantiate a new Product object
                    aProd = new Product();
                    // Obtain each Product attribute from the specific field in the row in the table
                    aProd.ProductID = Convert.ToString(myRow["ProductID"]).TrimEnd();
                    aProd.Description = Convert.ToString(myRow["Description"]).TrimEnd();
                    aProd.Barcode = Convert.ToString(myRow["Barcode"]).TrimEnd();
                    aProd.Supplier = Convert.ToString(myRow["Supplier"]).TrimEnd();
                    // Add products to collection
                    products.Add(aProd);
                }
            }
        }
        #endregion

        #region FillRow
        /// <summary>
        /// Fill the data row with product information
        /// </summary>
        /// <param name="aRow">The data row</param>
        /// <param name="aProd">The product</param>
        /// <param name="operation">The database operation</param>
        private void FillRow(DataRow aRow, Product aProd, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ProductID"] = aProd.ProductID;
            }
            aRow["Description"] = aProd.Description;
            aRow["Barcode"] = aProd.Barcode;
            aRow["Supplier"] = aProd.Supplier;
        }
        #endregion

        #region Find Row
        /// <summary>
        /// Finds the row in the table where the product is found.
        /// </summary>
        /// <param name="aProd">The product</param>
        /// <param name="table">Table name</param>
        /// <returns></returns>
        private int FindRow(Product aProd, string table)
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
                    if (aProd.ProductID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ProductID"]))
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
        /// <param name="aProd">Product</param>
        /// <param name="operation">Database operation</param>
        public void DataSetChange(Product aProd, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;

            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aProd, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aProd, dataTable)];
                    FillRow(aRow, aProd, operation);
                    break;
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aProd, dataTable)];
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

            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 15, "ProductID");
            daMain.InsertCommand.Parameters.Add(param); //Add the parameter to the Parameters collection.

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Barcode", SqlDbType.NVarChar, 50, "Barcode");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Supplier", SqlDbType.NVarChar, 50, "Supplier");
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

            param = new SqlParameter("@Barcode", SqlDbType.NVarChar, 50, "Barcode");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Supplier", SqlDbType.NVarChar, 50, "Supplier");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ProductID");
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
            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 15, "ProductID");
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
        /// <param name="aProd"></param>
        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            daMain.InsertCommand = new SqlCommand("INSERT into Products (Description, Barcode, Supplier)" +
                " VALUES (@Description, @Barcode,  @Supplier)", cnMain);
            Build_INSERT_Parameters();
        }
        #endregion

        #region Create update command
        /// <summary>
        /// Creates update command
        /// </summary>
        /// <param name="aProd"></param>
        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into table
            //Assumption is that the product number
            daMain.UpdateCommand = new SqlCommand("UPDATE Products SET Description =@Description, Barcode =@Barcode, Supplier =@Supplier" + "WHERE ProductID = @Original_ID", cnMain);
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
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", cnMain);
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
