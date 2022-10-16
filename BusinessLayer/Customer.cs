using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Customer : Person
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
        #endregion

        #region Constructor
        /*
         * Include the constructor of the class.                                                                                                           
            The constructor should have one argument roleValue of type Role. 
            This is because upon the invocation of this class, the role of the employee should be determined.
            Use a switch statement to find the specific role as follows (for more on switch statements):
            If there is no role yet, then:                  role = new Role ();
            If the role is Headwaiter, then:                     role = new HeadWaiter ();

         */

        public Customer(CreditStatus.Status statusValue)
        {
            switch (statusValue)
            {
                case CreditStatus.Status.NoStatus:
                    creditStatus = new CreditStatus();
                    break;
                case CreditStatus.Status.Success:
                    Console.WriteLine("Released");
                    break;
                case CreditStatus.Status.Failure:
                    Console.WriteLine("On Hold");
                    break;
            }
        }
        #endregion
    }
}