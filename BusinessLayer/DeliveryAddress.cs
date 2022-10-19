using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class DeliveryAddress: Address
    {
        #region Data Member
        private int orderNumber;
        #endregion

        #region Constructor 
        public DeliveryAddress() : base()
        {
            
        }
        #endregion

        #region Properties 
        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }
        #endregion
    }
}
