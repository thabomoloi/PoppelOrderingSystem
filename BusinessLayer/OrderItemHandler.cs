using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class OrderItemHandler
    {
        #region Data members
        /// <summary>
        /// Reference to orderItem database
        /// </summary>
        private OrderItemDB orderItemDB;
        /// <summary>
        /// Collection of orderItems
        /// </summary>
        private Collection<OrderItem> orderItems;
        /// <summary>
        /// Reference to orderItem
        /// </summary>
        private OrderItem orderItem;
        #endregion

        #region Properties
        public Collection<OrderItem> AllOrderItems
        {
            get { return orderItems; }
        }
        #endregion

        #region Constructor 
        public OrderItemHandler()
        {
            // Instatiate orderItem DB to connect with the database
            orderItemDB = new OrderItemDB();
            orderItems = orderItemDB.AllOrderItems;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(OrderItem anOI, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            orderItemDB.DataSetChange(anOI, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    orderItems.Add(anOI);       // Add orderItem to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(anOI);
                    orderItems[index] = anOI;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(anOI);   // find the index of the specific OrderItem in collection
                    orderItems.RemoveAt(index);  // remove that OrderItem form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return orderItemDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find By C
        public OrderItem FindByInvId(Collection<OrderItem> oItems, int invId)
        {
            foreach (OrderItem oItem in oItems)
            {
                if (oItem.InventoryItemID == invId)
                    return oItem;
            }
            return null;
        }
        #endregion

        #region Find by orderItem number
        /// <summary>
        /// Finds orderItem by orderItem number
        /// </summary>
        /// <param name="orderItemNumber">OrderItem number</param>
        /// <returns>OrderItem collection</returns>
        public OrderItem Find(int orderItemNumber)
        {
            int index = 0;
            bool found = (orderItems[index].OrderItemID == orderItemNumber);  //check if it is the first record
            int count = orderItems.Count;
            while (!(found) && (index < orderItems.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (orderItems[index].OrderItemID == orderItemNumber);   // this will be TRUE if found
            }
            return orderItems[index];
        }
        #endregion

        #region Find index of orderItem
        /// <summary>
        /// Finds the index of a orderItem
        /// </summary>
        /// <param name="anOI">OrderItem</param>
        /// <returns>Index of a orderItem if found, else -1</returns>
        public int FindIndex(OrderItem anOI)
        {
            int index = -1;
            bool found = (anOI.OrderItemID == orderItems[++index].OrderItemID);
            while (!(found) & index < orderItems.Count - 1)
            {
                index += 1;
                found = (anOI.OrderItemID == orderItems[index].OrderItemID);
            }
            return found ? index : -1;
        }
        #endregion

        #endregion
    }
}
