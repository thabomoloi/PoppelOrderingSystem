using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class OrderHandler
    {
        #region Data members
        /// <summary>
        /// Reference to order database
        /// </summary>
        private OrderDB orderDB;
        /// <summary>
        /// Collection of orders
        /// </summary>
        private Collection<Order> orders;
        /// <summary>
        /// Reference to order
        /// </summary>
        private Order order;
        #endregion

        #region Properties
        public Collection<Order> AllOrders
        {
            get { return orders; }
        }
        #endregion

        #region Constructor 
        public OrderHandler()
        {
            // Instatiate order DB to connect with the database
            orderDB = new OrderDB();
            orders = orderDB.AllOrders;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(Order anOrd, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            orderDB.DataSetChange(anOrd, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    orders.Add(anOrd);       // Add order to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(anOrd);
                    orders[index] = anOrd;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(anOrd);   // find the index of the specific Order in collection
                    orders.RemoveAt(index);  // remove that Order form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return orderDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find by order number
        /// <summary>
        /// Finds order by order number
        /// </summary>
        /// <param name="orderNumber">Order number</param>
        /// <returns>Order collection</returns>
        public Order Find(int orderNumber)
        {
            int index = 0;
            bool found = (orders[index].OrderNumber == orderNumber);  //check if it is the first record
            int count = orders.Count;
            while (!(found) && (index < orders.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (orders[index].OrderNumber == orderNumber);   // this will be TRUE if found
            }
            return orders[index];
        }
        #endregion

        #region Find index of order
        /// <summary>
        /// Finds the index of a order
        /// </summary>
        /// <param name="anOrd">Order</param>
        /// <returns>Index of a order if found, else -1</returns>
        public int FindIndex(Order anOrd)
        {
            int index = -1;
            bool found = (anOrd.OrderNumber == orders[++index].OrderNumber);
            while (!(found) & index < orders.Count - 1)
            {
                index += 1;
                found = (anOrd.OrderNumber == orders[index].OrderNumber);
            }
            return found ? index : -1;
        }
        #endregion

        #endregion
    }
}
