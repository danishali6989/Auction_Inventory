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
    
    public partial class Sale
    {
        public long iSaleID { get; set; }
        public Nullable<int> iSaleFrontEndID { get; set; }
        public string strBuyerName { get; set; }
        public Nullable<int> iBuyerID { get; set; }
        public string strSalesDate { get; set; }
        public Nullable<decimal> dmlSellingPrice { get; set; }
        public Nullable<decimal> dmlDeposit { get; set; }
        public Nullable<decimal> dmlAdvance { get; set; }
        public Nullable<decimal> dmlBalance { get; set; }
        public Nullable<int> iInstallment { get; set; }
        public Nullable<int> iPaymentType { get; set; }
        public Nullable<int> iImpExpTransfer { get; set; }
        public Nullable<int> iSalesInvoiceID { get; set; }
    }
}