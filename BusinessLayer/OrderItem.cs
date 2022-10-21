using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class OrderItem
    {
        #region Data Members 
        private int id, quantity, orderNumber, inventoryItemID;
        private double price;
        #endregion

        #region Properties 
        public int OrderItemID
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }
        public int Quantity 
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int InventoryItemID
        {
            get { return inventoryItemID; }
            set { inventoryItemID = value; }
        }
        #endregion

        public double getSubTotal()
        {
            return price * quantity;
        }
    }
}
