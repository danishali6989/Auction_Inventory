using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class SalesPaymentModel
    {
        public long iPaymentID { get; set; }
        public Nullable<long> iSaleID { get; set; }
        public Nullable<int> iCustomerID { get; set; }
        public string strPaymentDate { get; set; }
        public Nullable<System.DateTime> dtPaymentDate { get; set; }
        public Nullable<decimal> dmlPaidAmount { get; set; }
        public Nullable<decimal> dmlPrevBalance { get; set; }
        public Nullable<bool> ysnPaymentStatus { get; set; }
        public Nullable<int> iSalesInvoiceID { get; set; }
        public string strSalesInvoiceNo { get; set; }
    }
}