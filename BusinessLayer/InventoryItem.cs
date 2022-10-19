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
        private string id, productID;
        private int qtyOnHand, qtyInStock;
        #endregion

        #region Poperties
        public string InventoryItemID
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
            set { qtyOnHand = value; }
        }
        public string ProductId
        {
            get { return productID; }
            set { productID = value; }
        }
        #endregion
    }
}
