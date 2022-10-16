using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class CustomerController
    {
        #region Data Members
        private ICollection<Customer> customers;

        #endregion

        #region Poperties
        public ICollection<Customer> AllCustomers
        {
            get { return customers; }
        }
        #endregion

        #region Constructor 
        public CustomerController()
        {

        }
        #endregion
    }
}
