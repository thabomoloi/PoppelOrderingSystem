using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Customer:Person
    {
        #region Data Members
        //encapsulation
        private string customerNo;
        private double creditLimit;
        //need to define credit status here,the creditStatus data member of this class is of class type CreditStatus.
        public CreditStatus creditStatus;
        #endregion
    }
}
