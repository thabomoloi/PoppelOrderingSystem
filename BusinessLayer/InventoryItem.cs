using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class InventoryItem
    {
        #region Data Members
        private string productID;
        private int id, qtyOnHand, qtyInStock;
        #endregion

        #region Poperties
        public int InventoryItemID
        {
            get { return id; }
            set { id = value; }
        }
        public int QuantityOnHand
        {
            get { return qtyOnHand; }
            set { qtyOnHand = value; }
        }
        public int QuantityInStock
        {
            get { return qtyInStock; }
            set { qtyInStock = value; }
        }
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        #endregion
    }
}
