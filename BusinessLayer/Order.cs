using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Order
    {
        #region Enumeration
        public enum OrderStatus
        {
            New = 0,
            OnHold = 1,
            Confirmed = 2,
            Cancelled = 3,
            Shipped = 4,
            Delivered = 5,
            Closed = 6
        }
        #endregion

        #region Data Members
        private int orderNumber;
        private DateTime orderDate;
        private DateTime deliveryDate;
        private OrderStatus orderStatus;
        private Double total;
        private string customerNumber;
        private string clerkID;

        private Collection<OrderItem> items;
        #endregion

        #region Properties
        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }
        public OrderStatus Status
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }
        public Double Total
        {
            get { return total; }
            set { total = value; }
        }
        public string CustomerNumber
        {
            get { return customerNumber; }
            set { customerNumber = value; }
        }
        public string ClerkID
        {
            get { return clerkID; }
            set { clerkID = value; }
        }
        #endregion

        public Order()
        {
            items = new Collection<OrderItem>();
            total = 0;
        }

        #region Methods
        public void add(OrderItem item)
        {
            if (item.Quantity != 0)
            {
                if (FindIndex(item) == -1)
                    items.Add(item);
                else
                    items[FindIndex(item)].Quantity += item.Quantity;
            }
        }
        public void remove(OrderItem item)
        {
            items.RemoveAt(FindIndex(item));
        }

        public double getTotal()
        {
            total = 0;
            foreach (OrderItem item in items)
            {
                total += item.getSubTotal();
            }
            return total;
        }
        public int FindIndex(OrderItem item)
        {
            int index = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].InventoryItemID == item.InventoryItemID)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public Collection<OrderItem> Items { get { return items; } set { items = value; } }
        public OrderItem this[int index] 
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        #endregion
    }
}
