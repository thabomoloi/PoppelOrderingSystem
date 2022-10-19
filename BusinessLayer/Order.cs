using System;
using System.Collections.Generic;
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
            set { total = value;  }
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
    }
}
