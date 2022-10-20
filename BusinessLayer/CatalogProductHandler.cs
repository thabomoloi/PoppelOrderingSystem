using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class CatalogProductHandler
    {
        #region Data members
        /// <summary>
        /// Reference to catalog database
        /// </summary>
        private CatalogProductDB catalogProductDB;
        /// <summary>
        /// Collection of catalogProducts
        /// </summary>
        private Collection<CatalogProduct> catalogProducts;
        /// <summary>
        /// Reference to catalogProduct
        /// </summary>
        private CatalogProduct catalogProduct;
        #endregion

        #region Properties
        public Collection<CatalogProduct> AllCatalogProducts
        {
            get { return catalogProducts; }
        }
        #endregion

        #region Constructor 
        public CatalogProductHandler()
        {
            // Instatiate catalogProduct DB to connect with the database
            catalogProductDB = new CatalogProductDB();
            catalogProducts = catalogProductDB.AllCatalogProducts;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(CatalogProduct aCP, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            catalogProductDB.DataSetChange(aCP, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    catalogProducts.Add(aCP);       // Add catalogProduct to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aCP);
                    catalogProducts[index] = aCP;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aCP);   // find the index of the specific Catalog in collection
                    catalogProducts.RemoveAt(index);  // remove that Catalog form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return catalogProductDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find by catalogProduct number
        /// <summary>
        /// Finds catalogProduct by catalogProduct number
        /// </summary>
        /// <param name="catalogNumber">Catalog number</param>
        /// <returns>Catalog collection</returns>
        public CatalogProduct Find(string catalogID, string productID)
        {
            int index = 0;
            bool found = (catalogProducts[index].CatalogID == catalogID) && (catalogProducts[index].ProductID == productID);  //check if it is the first record
            int count = catalogProducts.Count;
            while (!(found) && (index < catalogProducts.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (catalogProducts[index].CatalogID == catalogID) && (catalogProducts[index].ProductID == productID);
            }
            return catalogProducts[index];
        }
        #endregion

        #region Find index of catalogProduct
        /// <summary>
        /// Finds the index of a catalogProduct
        /// </summary>
        /// <param name="aCP">Catalog</param>
        /// <returns>Index of a catalogProduct if found, else -1</returns>
        public int FindIndex(CatalogProduct aCP)
        {
            int index = -1;
            bool found = (catalogProducts[index].CatalogID == aCP.CatalogID) && (catalogProducts[index].ProductID == aCP.ProductID);
            while (!(found) & index < catalogProducts.Count - 1)
            {
                index += 1;
                found = (catalogProducts[index].CatalogID == aCP.CatalogID) && (catalogProducts[index].ProductID == aCP.ProductID);
            }
            return found ? index : -1;
        }
        #endregion

        #endregion
    }
}
