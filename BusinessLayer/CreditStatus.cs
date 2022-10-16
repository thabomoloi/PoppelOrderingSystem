using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class CreditStatus
    {


        public enum Status { NoStatus,Success, Failure }
        protected Status statusVal;
        protected string description;

        #region Property Methods
        /*Declare properties for the CreditStatus class */
        public Status getStatusValue
        {
            get { return statusVal; }
            set { statusVal = value; }
        }
        public string getDescription
        {
            get { return description; }
            set { description = value; }
        }
        #endregion

        #region Constructor
        /*A default constructor to initialise the values: 
         * Initialise the role ID (roleval) and the status description to Released. 
         * We assume until a credit status is assigned to a customer, they have no credit status
         */

        public CreditStatus()
        {
            statusVal = CreditStatus.Status.NoStatus;
            description = "Outstanding Credis status";
        }
        #endregion

    }
}
