using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Address
    {
        #region Data Members
        private int addressID;
        private string street, suburb, city, province, postalCode, customerNumber;
        #endregion

        #region Constrctors
        /// <summary>
        /// No arguments constructor
        /// </summary>
        public Address()
        { 
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
        public Address(int addrID, String aStreet, String aSuburb, String aCity, String aProvince, String aPostalCode, string aCustNumber)
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
        public int AddressID
        {
            get { return addressID; }
            set { addressID = value; }
        }
        [Required(AllowEmptyStrings =false, ErrorMessage = "Street is required")]
        [StringLength(50, MinimumLength = 3,ErrorMessage = "Street must be between 3 and 50 characters")]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surbub is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Surbub must be between 3 and 50 characters")]
        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "City must be between 5 and 50 characters")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postal code is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid postal code")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Postal code must only have 4 digits")]
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

        #region ToString 
        public override string ToString()
        {
            return string.Join("\n", Street, Suburb, City, PostalCode, Province);
        }
        #endregion
    }
}
