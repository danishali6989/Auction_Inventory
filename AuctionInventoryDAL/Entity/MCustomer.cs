//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuctionInventoryDAL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class MCustomer
    {
        public int iCustomerID { get; set; }
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }
        public string strLastName { get; set; }
        public Nullable<int> iCountry { get; set; }
        public Nullable<int> iCity { get; set; }
        public string strEmailID { get; set; }
        public string strAddress { get; set; }
        public string strCreditLimit { get; set; }
        public string strPersonFirstName { get; set; }
        public string strPersonMiddleName { get; set; }
        public string strPersonLastName { get; set; }
        public string strCompanyName { get; set; }
        public string CustomerPhoto { get; set; }
        public string CustomerDate { get; set; }
        public Nullable<long> iCreditCategoryID { get; set; }
        public string iPincode { get; set; }
        public string iPhoneNumber { get; set; }
        public Nullable<bool> IsBlocked { get; set; }
    }
}
