using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Address
    {
        #region Data Members
        private string addressID, street, suburb, city, province, postalCode, customerNumber;
        #endregion

        #region Constrctors
        /// <summary>
        /// No arguments constructor
        /// </summary>
        public Address()
        {
            addressID = "";
            street = "";
            suburb = "";
            city = "";
            province = "";
            postalCode = "";
            customerNumber = "";
        }
        /// <summary>
        /// Create a new Address object given details
        /// </summary>
        /// <param name="addrID"></param>
        /// <param name="aStreet"></param>
        /// <param name="aSuburb"></param>
        /// <param name="aCity"></param>
        /// <param name="aProvince"></param>
        /// <param name="aPostalCode"></param>
        /// <param name="aCustNumber"></param>
        public Address(String addrID, String aStreet, String aSuburb, String aCity, String aProvince, String aPostalCode, string aCustNumber)
        {
            addressID = addrID;
            street = aStreet;
            suburb = aSuburb;
            city = aCity;
            province = aProvince;
            postalCode = aPostalCode;
            customerNumber = aCustNumber;
        }
        #endregion

        #region Property methods
        public string AddressID
        {
            get { return addressID; }
            set { addressID = value; }
        }
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public string CustomerNumber
        {
            get { return customerNumber; }
            set { customerNumber = value; }
        }
        #endregion
    }
}
