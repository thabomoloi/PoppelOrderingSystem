using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class InventoryItemHandler
    {
        #region Data members
        /// <summary>
        /// Reference to inventoryItem database
        /// </summary>
        private InventoryItemDB inventoryItemDB;
        /// <summary>
        /// Collection of inventoryItems
        /// </summary>
        private Collection<InventoryItem> inventoryItems;
        /// <summary>
        /// Reference to inventoryItem
        /// </summary>
        private InventoryItem inventoryItem;
        #endregion

        #region Properties
        public Collection<InventoryItem> AllInventoryItems
        {
            get { return inventoryItems; }
        }
        #endregion

        #region Constructor 
        public InventoryItemHandler()
        {
            // Instatiate inventoryItem DB to connect with the database
            inventoryItemDB = new InventoryItemDB();
            inventoryItems = inventoryItemDB.AllInventoryItems;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(InventoryItem anInv, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            inventoryItemDB.DataSetChange(anInv, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    inventoryItems.Add(anInv);       // Add inventoryItem to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(anInv);
                    inventoryItems[index] = anInv;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(anInv);   // find the index of the specific InventoryItem in collection
                    inventoryItems.RemoveAt(index);  // remove that InventoryItem form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return inventoryItemDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find By CustNo
        public InventoryItem FindByProdId(Collection<InventoryItem> invs, string prodId)
        {
            foreach (InventoryItem inv in invs)
            {
                if (inv.ProductID == prodId)
                    return inv;
            }
            return null;
        }
        #endregion

        #region Find by inventoryItem number
        /// <summary>
        /// Finds inventoryItem by inventoryItem number
        /// </summary>
        /// <param name="inventoryItemNumber">InventoryItem number</param>
        /// <returns>InventoryItem collection</returns>
        public InventoryItem Find(int inventoryItemNumber)
        {
            int index = 0;
            bool found = (inventoryItems[index].InventoryItemID == inventoryItemNumber);  //check if it is the first record
            int count = inventoryItems.Count;
            while (!(found) && (index < inventoryItems.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (inventoryItems[index].InventoryItemID == inventoryItemNumber);   // this will be TRUE if found
            }
            return inventoryItems[index];
        }
        #endregion

        #region Find index of inventoryItem
        /// <summary>
        /// Finds the index of a inventoryItem
        /// </summary>
        /// <param name="anInv">InventoryItem</param>
        /// <returns>Index of a inventoryItem if found, else -1</returns>
        public int FindIndex(InventoryItem anInv)
        {
            int index = -1;
            bool found = (anInv.InventoryItemID == inventoryItems[++index].InventoryItemID);
            while (!(found) & index < inventoryItems.Count - 1)
            {
                index += 1;
                found = (anInv.InventoryItemID == inventoryItems[index].InventoryItemID);
            }
            return found ? index : -1;
        }
        #endregion

        #endregion
    }
}
