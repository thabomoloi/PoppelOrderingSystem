using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Customer : Person
    {
        #region Enumeration
        public enum CreditStatus
        {
            OnHold = 1,
            Released = 2
        }
        #endregion
        #region Data Members
        //encapsulation
        private string customerNo;
        private double creditLimit;
        //need to define credit status here,the creditStatus data member of this class is of class type CreditStatus.
        public CreditStatus creditStatus;
        #endregion

        #region Property Methods
        [DisplayName("Customer Number")]
        [Required(ErrorMessage = "Customer number is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Customer number must be between 5 and 20 characters")]
        public string CustomerNumber 
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

        #region Constructors
        public Customer(double custCreditLimit, CreditStatus custCreditStatus)
        {
            creditLimit = custCreditLimit;
            creditStatus = custCreditStatus;
        }
        #endregion
    }
}
