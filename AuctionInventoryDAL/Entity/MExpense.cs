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
    
    public partial class MExpense
    {
        public int iExpenseID { get; set; }
        public string strExpenseName { get; set; }
        public int iPurchaseInvoiceID { get; set; }
        public Nullable<int> iCategoryID { get; set; }
        public Nullable<int> iSubCategoryID { get; set; }
        public Nullable<decimal> dcmlExpenseAmount { get; set; }
    }
}
