using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Staff
    {
        public string FullName { get; set; }
        public int iStaffID { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string strLastName { get; set; }

           
        public string strNationalityAddress { get; set; }
         [Required(ErrorMessage = "Nationality is required")]   
        public Nullable<int> iNationality { get; set; }
        public Nullable<int> iNationalityContact { get; set; }
        [Display(Name = "Email address")]
        //[Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string strEmailID { get; set; }
        public Nullable<int> iIDNO { get; set; }
        public string strMISC { get; set; }
        public string strPassport { get; set; }
        public string strPassportExpiry { get; set; }
        public string strVisa { get; set; }
        public string strVisaExpiry { get; set; }
        public string strCurrentAddress { get; set; }
        public Nullable<int> iDesignation { get; set; }
        public Nullable<decimal> dmlSalary { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string strRemark { get; set; }
    }
}