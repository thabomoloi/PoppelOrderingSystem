using PoppelOrderingSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class MarketingClerkHandler
    {
        #region Data members
        /// <summary>
        /// Reference to marketingClerk database
        /// </summary>
        private MarketingClerkDB marketingClerkDB;
        /// <summary>
        /// Collection of marketingClerks
        /// </summary>
        private Collection<MarketingClerk> marketingClerks;
        /// <summary>
        /// Reference to marketingClerk
        /// </summary>
        private MarketingClerk marketingClerk;
        #endregion

        #region Properties
        public Collection<MarketingClerk> AllMarketingClerks
        {
            get { return marketingClerks; }
        }
        #endregion

        #region Constructor 
        public MarketingClerkHandler()
        {
            // Instatiate marketingClerk DB to connect with the database
            marketingClerkDB = new MarketingClerkDB();
            marketingClerks = marketingClerkDB.AllMarketingClerks;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(MarketingClerk clerk, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            marketingClerkDB.DataSetChange(clerk, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    marketingClerks.Add(clerk);       // Add marketingClerk to collection
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(clerk);
                    marketingClerks[index] = clerk;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(clerk);   // find the index of the specific MarketingClerk in collection
                    marketingClerks.RemoveAt(index);  // remove that MarketingClerk form the collection
                    break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return marketingClerkDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find By CustNo
        public MarketingClerk FindUserID(Collection<MarketingClerk> clerks, int userID)
        {
            foreach (MarketingClerk clerk in clerks)
            {
                if (clerk.UserID == userID)
                    return clerk;
            }
            return null;
        }
        #endregion

        #region Find by marketingClerk number
        /// <summary>
        /// Finds marketingClerk by marketingClerk number
        /// </summary>
        /// <param name="marketingClerkNumber">MarketingClerk number</param>
        /// <returns>MarketingClerk collection</returns>
        public MarketingClerk Find(string marketingClerkNumber)
        {
            int index = 0;
            bool found = (marketingClerks[index].ClerkID == marketingClerkNumber);  //check if it is the first record
            int count = marketingClerks.Count;
            while (!(found) && (index < marketingClerks.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (marketingClerks[index].ClerkID == marketingClerkNumber);   // this will be TRUE if found
            }
            return marketingClerks[index];
        }
        #endregion

        #region Find index of marketingClerk
        /// <summary>
        /// Finds the index of a marketingClerk
        /// </summary>
        /// <param name="clerk">MarketingClerk</param>
        /// <returns>Index of a marketingClerk if found, else -1</returns>
        public int FindIndex(MarketingClerk clerk)
        {
            int index = -1;
            bool found = (clerk.ClerkID == marketingClerks[++index].ClerkID);
            while (!(found) & index < marketingClerks.Count - 1)
            {
                index += 1;
                found = (clerk.ClerkID == marketingClerks[index].ClerkID);
            }
            return index;
        }
        #endregion

        #endregion
    }
}
