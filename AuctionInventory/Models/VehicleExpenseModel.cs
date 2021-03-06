﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class VehicleExpenseModel
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
        public Nullable<int> iPartyID { get; set; }
    }
}