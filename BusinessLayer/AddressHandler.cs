using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelOrderingSystem.DatabaseLayer;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class AddressHandler
    {
        #region Data members
        /// <summary>
        /// Reference to address database
        /// </summary>
        private AddressDB addressDB;
        /// <summary>
        /// Collection of addresses
        /// </summary>
        private Collection<Address> addresses;
        /// <summary>
        /// Reference to address
        /// </summary>
        private Address address;
        #endregion

        #region Properties
        public Collection<Address> AllAddresses
        {
            get { return addresses; }
        }
        #endregion

        #region Constructor 
        public AddressHandler()
        {
            // Instatiate address DB to connect with the database
            addressDB = new AddressDB();
            addresses = addressDB.AllAddresses;
        }
        #endregion

        #region Database communication

        #region Data Maintenance
        public void DataMaintenance(Address anAddr, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            addressDB.DataSetChange(anAddr, operation); //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    addresses.Add(anAddr);       // Add address to collection
                    break;
                    case DB.DBOperation.Edit:
                        index = FindIndex(anAddr);
                        addresses[index] = anAddr;
                        break;
                    case DB.DBOperation.Delete:
                        index = FindIndex(anAddr);   // find the index of the specific Address in collection
                        addresses.RemoveAt(index);  // remove that Address form the collection
                        break;
            }
        }
        #endregion

        #region Finalize Changes
        public bool FinalizeChanges()
        {
            return addressDB.UpdateDataSource();
        }
        #endregion

        #endregion

        #region Search Methods

        #region Find By CustNo
        public Collection<Address> FindByCustNo(Collection<Address> addrs, string custNo)
        {
            Collection<Address> matches = new Collection<Address>();

            foreach (Address addr in addrs)
            {
                if (addr.CustomerNumber == custNo)
                    matches.Add(addr);
            }
            return matches;
        }
        #endregion

        #region Find by address number
        /// <summary>
        /// Finds address by address number
        /// </summary>
        /// <param name="addressNumber">Address number</param>
        /// <returns>Address collection</returns>
        public Address Find(int addressNumber)
        {
            int index = 0;
            bool found = (addresses[index].AddressID == addressNumber);  //check if it is the first record
            int count = addresses.Count;
            while (!(found) && (index < addresses.Count - 1))                   //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (addresses[index].AddressID == addressNumber);   // this will be TRUE if found
            }
            return addresses[index];
        }
        #endregion

        #region Find index of address
        /// <summary>
        /// Finds the index of a address
        /// </summary>
        /// <param name="anAddr">Address</param>
        /// <returns>Index of a address if found, else -1</returns>
        public int FindIndex(Address anAddr)
        {
            int index = -1;
            bool found = (anAddr.AddressID == addresses[++index].AddressID);
            while (!(found) & index < addresses.Count - 1)
            {
                index += 1;
                found = (anAddr.AddressID == addresses[index].AddressID);
            }
            return index;
        }
        #endregion

        #endregion
    }
}
