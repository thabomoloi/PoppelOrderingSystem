using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PoppelOrderingSystem
{
    public class Person
    {

        #region data members
        private string firstName, lastName, phone, email;
        private string address;
        #endregion

        #region Properties
        [DisplayName("Name")]
        public string Name
        {
            get { return firstName + " " + lastName; }
        }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "First name must be between 3 and 50 characters")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 50 characters")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Phone number should only contain digits")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must only contain 10 digits")]
        public string Telephone
        {
            get { return phone; }
            set { phone = value; }
        }
        [DisplayName("Email")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Ivalid email, please enter a valid email")]
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

