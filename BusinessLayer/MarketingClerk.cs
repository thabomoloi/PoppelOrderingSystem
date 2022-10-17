using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class MarketingClerk : Person
    {

        #region data members
        private string clerkID;
        #endregion

        #region Property Methods
        public string ClerkID
        {
            get { return clerkID; }
            set { clerkID = value; }
        }
        #endregion
    }



}