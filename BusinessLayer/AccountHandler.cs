using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class AccountHandler
    {
        #region Data members
        /// <summary>
        /// Reference to account database
        /// </summary>
        private AccountDB accountDB;
        /// <summary>
        /// Collection of accounts
        /// </summary>
        private Collection<Account> accounts;
        /// <summary>
        /// Reference to account
        /// </summary>
        private Account account;
        #endregion

        #region Properties
        public Collection<Account> AllAccounts
        {
            get { return accounts; }
        }
        #endregion

        #region Constructor 
        public AccountHandler()
        {
            // Instatiate account DB to connect with the database
            accountDB = new AccountDB();
            accounts = accountDB.AllAccounts;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(Account anAcc, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            accountDB.DataSetChange(anAcc, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    accounts.Add(anAcc);       // Add account to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(anAcc);
                    accounts[index] = anAcc;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(anAcc);   // find the index of the specific Account in collection
                    accounts.RemoveAt(index);  // remove that Account form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return accountDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find By CustNo
        public Account FindByCustNo(Collection<Account> accs, string custNo)
        {
            foreach (Account acc in accs)
            {
                if (acc.CustomerNumber == custNo)
                    return acc;
            }
            return null;
        }
        #endregion

        #region Find by account number
        /// <summary>
        /// Finds account by account number
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <returns>Account collection</returns>
        public Account Find(int accountNumber)
        {
            int index = 0;
            bool found = (accounts[index].AccountNumber == accountNumber);  //check if it is the first record
            int count = accounts.Count;
            while (!(found) && (index < accounts.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (accounts[index].AccountNumber == accountNumber);   // this will be TRUE if found
            }
            return accounts[index];
        }
        #endregion

        #region Find index of account
        /// <summary>
        /// Finds the index of a account
        /// </summary>
        /// <param name="anAcc">Account</param>
        /// <returns>Index of a account if found, else -1</returns>
        public int FindIndex(Account anAcc)
        {
            int index = -1;
            bool found = (anAcc.AccountNumber == accounts[++index].AccountNumber);
            while (!(found) & index < accounts.Count - 1)
            {
                index += 1;
                found = (anAcc.AccountNumber == accounts[index].AccountNumber);
            }
            return index;
        }
        #endregion

        #endregion
    }
}
