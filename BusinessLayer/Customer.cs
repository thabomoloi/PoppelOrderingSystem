using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Customer : Person 
    {
        #region Enumeration
        /// <summary>
        /// Customer's credit status
        /// </summary>
        public enum CreditStatus
        {
            OnHold = 1,
            Released = 2,
            NoCredit = 3
        }
        #endregion

        #region Data Members
        //encapsulation
        private string customerNo;
        private double creditLimit;
        //need to define credit status here,the creditStatus data member of this class is of class type CreditStatus.
        private CreditStatus creditStatus;

        private Address address;
        private Account account;
        #endregion

        #region Property Methods
        [DisplayName("Customer Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer number is required.")]
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

        public CreditStatus CustCreditStatus
        {
            get { return creditStatus; }
            set { creditStatus = value;  }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public Account Account
        {
            get { return account; }
            set { account = Account;  }
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