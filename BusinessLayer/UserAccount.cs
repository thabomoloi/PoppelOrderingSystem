using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class UserAccount
    {
        #region Data Members
        private int userID;
        private string pass;
        #endregion

        #region Properties
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string Password
        {
            get { return pass; }
            set { pass = value; }
        }
        #endregion
    }
}
