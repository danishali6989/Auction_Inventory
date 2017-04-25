using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Customer
    {
        public int iCustomerID { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please use letters only ")]
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please use letters only ")]
        public string strLastName { get; set; }

         [Required(ErrorMessage = "Your must select country")]
        public Nullable<int> iCountry { get; set; }
       [Required(ErrorMessage = "Your must select city")]
        public Nullable<int> iCity { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
       
        public string strEmailID { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]       
        public Nullable<int> iPhoneNumber { get; set; }
        public string strAddress { get; set; }
        public Nullable<int> iPincode { get; set; }
         [Required(ErrorMessage = "Your must provide a Credit Limit")]
        public string strCreditLimit { get; set; }
        public Nullable<int> iPersonID { get; set; }
        public string strPersonFirstName { get; set; }
        public string strPersonMiddleName { get; set; }
        public string strPersonLastName { get; set; }
        public string strCompanyName { get; set; }
        public string CustomerPhoto { get; set; }
        public string CustomerDate { get; set; }
    }
}