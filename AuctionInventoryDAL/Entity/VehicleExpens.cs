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
    
    public partial class VehicleExpens
    {
        public long iVehicleExpenseID { get; set; }
        public Nullable<int> iPurchaseInvoiceID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public Nullable<int> iExpenseID { get; set; }
        public Nullable<int> iExpenseAmount { get; set; }
        public Nullable<int> iTotalExpenseAmounrt { get; set; }
        public string strRemarks { get; set; }
        public string strExpenseKey { get; set; }
    }
}
