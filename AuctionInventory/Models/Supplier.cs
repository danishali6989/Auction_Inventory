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

        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string strFirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string strMiddleName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string strLastName { get; set; }

        public Nullable<int> iSupplierCategory { get; set; }
        public Nullable<int> iSupplierServiceType { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string strEmailID { get; set; }
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        public Nullable<int> iPhoneNumber { get; set; }
        public string strAddress { get; set; }

        public Nullable<int> iPincode { get; set; }
        public Nullable<int> iCurrency { get; set; }
        public string SupplierPhoto { get; set; }
        [Required(ErrorMessage = "Plese select Supplier Date ")]

        public string SupplierDate { get; set; }

        public IEnumerable<SelectListItem> SupplierCategoryList { get; set; }

        public IEnumerable<SelectListItem> SupplierCurrencyList { get; set; }






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