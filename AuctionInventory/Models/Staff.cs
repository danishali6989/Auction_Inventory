using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Staff
    {
      

        public int iStaffID { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string strLastName { get; set; }
          [Required(ErrorMessage = "You must select country")] 
        public Nullable<int> iCountryID { get; set; }
          [Required(ErrorMessage = "You must select city")] 
        public Nullable<int> iCityID { get; set; }
        public string strArea { get; set; }
         [Required(ErrorMessage = "You Must Provide Phone Number")]
        public string iPhoneNumber { get; set; }
         [Display(Name = "Email address")]
         [Required(ErrorMessage = "The email address is required")]
         [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string strEmailID { get; set; }
        public Nullable<int> iIDNO { get; set; }
        public string strMISC { get; set; }
         [Required(ErrorMessage = "You must privide a passport number ")] 
        public string strPassport { get; set; }
        [Required(ErrorMessage = "You must privide a passport expiry date  ")]  
        public string strPassportExpiry { get; set; }
       [Required(ErrorMessage = "You must privide a visa number ")] 
        public string strVisa { get; set; }
        [Required(ErrorMessage = "You must privide a visa expiry date  ")] 
        public string strVisaExpiry { get; set; }
        public string strAddress { get; set; }
         [Required(ErrorMessage = "You must select Designation")] 
        public Nullable<int> iDesignation { get; set; }
        public Nullable<decimal> dmlSalary { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string strRemark { get; set; }


    }
}