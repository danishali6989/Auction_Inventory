using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionInventory.Models
{

    public class Supplier
    {

        public string FullName { get; set; }



        public int iSupplierID { get; set; }

        [Required(ErrorMessage = "First Name Is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters Only")]
        public string strFirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters Only")]
        public string strMiddleName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters Only")]
        public string strLastName { get; set; }

        public Nullable<int> iSupplierCategory { get; set; }
        public Nullable<int> iSupplierServiceType { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email Address Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string strEmailID { get; set; }

       [Required(ErrorMessage = "You Must Provide Phone Number")] 

        //[Display(Name = "PhoneNumber")]
        //[DataType(DataType.PhoneNumber)]
       // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        public string iPhoneNumber { get; set; }
        public string strAddress { get; set; }

        public string iPincode { get; set; }
        public Nullable<int> iCurrency { get; set; }
        public string SupplierPhoto { get; set; }
        [Required(ErrorMessage = "Plese Select Supplier Date ")]

        public string SupplierDate { get; set; }

        public IEnumerable<SelectListItem> SupplierCategoryList { get; set; }

        public IEnumerable<SelectListItem> SupplierCurrencyList { get; set; }

          [Required(ErrorMessage = "You Must Provide Person Phone Number")]
        public string iPersonPhoneNumber { get; set; }
        public string strPersonEmailID { get; set; }
          [Required(ErrorMessage = "Company Name Is Required")]
        public string strCompanyName { get; set; }
         
        public string strWebsites { get; set; }

        public string strPicName { get; set; }

        //[ScaffoldColumn(false)]
        //public int iSupplierID { get; set; }

        //[Required(ErrorMessage = "The First Name is required")]

        //public string strFirstName { get; set; }
        //public string strMiddleName { get; set; }
        //[Required(ErrorMessage = "The Last Name is required")]
        //public string strLastName { get; set; }
        //public Nullable<int> iSupplierCategory { get; set; }
        //public Nullable<int> iSupplierServiceType { get; set; }
        //[Display(Name = "Email address")]
        //[Required(ErrorMessage = "The email address is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        //public string strEmailID { get; set; }
        //[Required(ErrorMessage = "Your must provide a PhoneNumber")]
        //[Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        //public Nullable<int> iPhoneNumber { get; set; }
        //public string strAddress { get; set; }
        //public Nullable<int> iPincode { get; set; }
        //public Nullable<int> iCurrency { get; set; }
        //public string SupplierPhoto { get; set; }
        //public string SupplierDate { get; set; }


        //public IEnumerable<SelectListItem> SupplierCategoryList { get; set; }



    }

}