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
    
    public partial class MParty
    {
        public int iPartyID { get; set; }
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }
        public string strLastName { get; set; }
        public Nullable<int> iCountry { get; set; }
        public Nullable<int> iCity { get; set; }
        public string strEmailID { get; set; }
        public string strAddress { get; set; }
        public string strPhoneNumber { get; set; }
        public string iPincode { get; set; }
    }
}
