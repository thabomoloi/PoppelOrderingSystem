using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class UserAccountHandler
    {
        #region Data members
        /// <summary>
        /// Reference to userAccount database
        /// </summary>
        private UserAccountDB userAccountDB;
        /// <summary>
        /// Collection of userAccounts
        /// </summary>
        private Collection<UserAccount> userAccounts;
        /// <summary>
        /// Reference to userAccount
        /// </summary>
        private UserAccount userAccount;
        #endregion

        #region Properties
        public Collection<UserAccount> AllUserAccounts
        {
            get { return userAccounts; }
        }
        #endregion

        #region Constructor 
        public UserAccountHandler()
        {
            // Instatiate userAccount DB to connect with the database
            userAccountDB = new UserAccountDB();
            userAccounts = userAccountDB.AllUserAccounts;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(UserAccount uAcc, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            userAccountDB.DataSetChange(uAcc, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    userAccounts.Add(uAcc);       // Add userAccount to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(uAcc);
                    userAccounts[index] = uAcc;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(uAcc);   // find the index of the specific UserAccount in collection
                    userAccounts.RemoveAt(index);  // remove that UserAccount form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return userAccountDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find by userAccount number
        /// <summary>
        /// Finds userAccount by userAccount number
        /// </summary>
        /// <param name="userAccountNumber">UserAccount number</param>
        /// <returns>UserAccount collection</returns>
        public UserAccount Find(int userAccountNumber)
        {
            int index = 0;
            bool found = (userAccounts[index].UserID == userAccountNumber);  //check if it is the first record
            int count = userAccounts.Count;
            while (!(found) && (index < userAccounts.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (userAccounts[index].UserID == userAccountNumber);   // this will be TRUE if found
            }
            return userAccounts[index];
        }
        #endregion

        #region Find index of userAccount
        /// <summary>
        /// Finds the index of a userAccount
        /// </summary>
        /// <param name="uAcc">UserAccount</param>
        /// <returns>Index of a userAccount if found, else -1</returns>
        public int FindIndex(UserAccount uAcc)
        {
            int index = -1;
            bool found = (uAcc.UserID == userAccounts[++index].UserID);
            while (!(found) & index < userAccounts.Count - 1)
            {
                index += 1;
                found = (uAcc.UserID == userAccounts[index].UserID);
            }
            return index;
        }
        #endregion

        #endregion
    }
}
