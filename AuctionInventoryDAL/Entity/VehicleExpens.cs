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
        public string strExpenseDate { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public Nullable<int> iExpenseID { get; set; }
        public Nullable<decimal> dcmlExpenseAmount { get; set; }
        public Nullable<decimal> dcmlTotalExpenseAmount { get; set; }
        public string strRemarks { get; set; }
        public string strExpenseKey { get; set; }
        public Nullable<int> iVehicleExpenseTypeID { get; set; }
        public Nullable<decimal> dcmlSpreadAmount { get; set; }
        public Nullable<bool> isSpread { get; set; }
        public string strPurchaseInvoiceNo { get; set; }
        public Nullable<decimal> dcmlDOExpenseAmount { get; set; }
        public Nullable<decimal> dcmlDPAExpenseAmount { get; set; }
        public Nullable<decimal> dcmlTRANSPORTExpenseAmount { get; set; }
        public Nullable<decimal> dcmlRAMPExpenseAmount { get; set; }
        public Nullable<decimal> dcmlRECOVERYExpenseAmount { get; set; }
    }
}
