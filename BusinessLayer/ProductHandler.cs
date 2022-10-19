using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class ProductHandler
    {
        #region Data members
        /// <summary>
        /// Reference to product database
        /// </summary>
        private ProductDB productDB;
        /// <summary>
        /// Collection of products
        /// </summary>
        private Collection<Product> products;
        /// <summary>
        /// Reference to product
        /// </summary>
        private Product product;
        #endregion

        #region Properties
        public Collection<Product> AllProducts
        {
            get { return products; }
        }
        #endregion

        #region Constructor 
        public ProductHandler()
        {
            // Instatiate product DB to connect with the database
            productDB = new ProductDB();
            products = productDB.AllProducts;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(Product aProd, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            productDB.DataSetChange(aProd, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    products.Add(aProd);       // Add product to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aProd);
                    products[index] = aProd;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aProd);   // find the index of the specific Product in collection
                    products.RemoveAt(index);  // remove that Product form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return productDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find by product number
        /// <summary>
        /// Finds product by product number
        /// </summary>
        /// <param name="productNumber">Product number</param>
        /// <returns>Product collection</returns>
        public Product Find(string productNumber)
        {
            int index = 0;
            bool found = (products[index].ProductID == productNumber);  //check if it is the first record
            int count = products.Count;
            while (!(found) && (index < products.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (products[index].ProductID == productNumber);   // this will be TRUE if found
            }
            return products[index];
        }
        #endregion

        #region Find index of product
        /// <summary>
        /// Finds the index of a product
        /// </summary>
        /// <param name="aProd">Product</param>
        /// <returns>Index of a product if found, else -1</returns>
        public int FindIndex(Product aProd)
        {
            int index = -1;
            bool found = (aProd.ProductID == products[++index].ProductID);
            while (!(found) & index < products.Count - 1)
            {
                index += 1;
                found = (aProd.ProductID == products[index].ProductID);
            }
            return index;
        }
        #endregion

        #endregion
    }
}
