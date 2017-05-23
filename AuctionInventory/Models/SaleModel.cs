using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class SaleModel
    {
        public long iSaleID { get; set; }
        public Nullable<int> iSaleFrontEndID { get; set; }
        public string strBuyerName { get; set; }
       
        public Nullable<int> iCustomerID { get; set; }
        public string strSalesDate { get; set; }
        public Nullable<decimal> dmlSellingPrice { get; set; }
        public Nullable<decimal> dmlDeposit { get; set; }
        public Nullable<decimal> dmlAdvance { get; set; }
        public Nullable<decimal> dmlBalance { get; set; }
        public Nullable<int> iInstallment { get; set; }
        public Nullable<int> iPaymentType { get; set; }
        public Nullable<int> iImpExpTransfer { get; set; }
        public Nullable<int> iSalesInvoiceID { get; set; }
        public string strSalesInvoiceNo { get; set; }
        public Nullable<System.DateTime> dtSalesDate { get; set; }
        public Nullable<System.DateTime> dtCreditLimitDate { get; set; }
        public Nullable<bool> ysnPaymentStatus { get; set; }
    }
}