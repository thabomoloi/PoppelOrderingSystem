using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem
{
    public class Person
    {

        #region data members
        private string firstName, lastName, phone, email;
        private string address;
        #endregion

        #region Properties

        public string Name
        {
            get { return firstName + " " + lastName; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Telephone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
       

       public string Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion

        #region Constructor
        public Person()
        {
            firstName = "";
            lastName = "";
            phone = "";
            email = "";
            address = "";
        }

        public Person(string fName, string lName, string pPhone, string pEmail, string pAddress)
        {
            firstName = fName;
            lastName = lName;
            phone = pPhone;
            email = pEmail;
            address = pAddress;
        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            return Name + '\n' + Telephone + '\n' + Email + '\n' + Address;
        }

        #endregion
    }

}

