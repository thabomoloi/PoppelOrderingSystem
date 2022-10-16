using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        #region Property methods
        public string CustomerNo
        {
            get { return customerNo; }
            set { customerNo = value; }
        }
        public double CreditLimit
        {
            get { return creditLimit; }
            set { creditLimit = value; }
        }
    }
}
