using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelOrderingSystem.DatabaseLayer;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class CatalogHandler
    {
        #region Data members
        /// <summary>
        /// Reference to catalog database
        /// </summary>
        private CatalogDB catalogDB;
        /// <summary>
        /// Collection of catalogs
        /// </summary>
        private Collection<Catalog> catalogs;
        /// <summary>
        /// Reference to catalog
        /// </summary>
        private Catalog catalog;
        #endregion

        #region Properties
        public Collection<Catalog> AllCatalogs
        {
            get { return catalogs; }
        }
        #endregion

        #region Constructor 
        public CatalogHandler()
        {
            // Instatiate catalog DB to connect with the database
            catalogDB = new CatalogDB();
            catalogs = catalogDB.AllCatalogs;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(Catalog aCat, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            catalogDB.DataSetChange(aCat, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    catalogs.Add(aCat);       // Add catalog to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aCat);
                    catalogs[index] = aCat;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aCat);   // find the index of the specific Catalog in collection
                    catalogs.RemoveAt(index);  // remove that Catalog form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return catalogDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find by catalog number
        /// <summary>
        /// Finds catalog by catalog number
        /// </summary>
        /// <param name="catalogNumber">Catalog number</param>
        /// <returns>Catalog collection</returns>
        public Catalog Find(string catalogNumber)
        {
            int index = 0;
            bool found = (catalogs[index].CatalogID == catalogNumber);  //check if it is the first record
            int count = catalogs.Count;
            while (!(found) && (index < catalogs.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (catalogs[index].CatalogID == catalogNumber);   // this will be TRUE if found
            }
            return catalogs[index];
        }
        #endregion

        #region Find index of catalog
        /// <summary>
        /// Finds the index of a catalog
        /// </summary>
        /// <param name="aCat">Catalog</param>
        /// <returns>Index of a catalog if found, else -1</returns>
        public int FindIndex(Catalog aCat)
        {
            int index = -1;
            bool found = (aCat.CatalogID == catalogs[++index].CatalogID);
            while (!(found) & index < catalogs.Count - 1)
            {
                index += 1;
                found = (aCat.CatalogID == catalogs[index].CatalogID);
            }
            return index;
        }
        #endregion

        #endregion
    }
}
