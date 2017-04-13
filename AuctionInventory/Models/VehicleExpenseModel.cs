using System;
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
        public Nullable<int> iExpenseAmount { get; set; }
        public Nullable<int> iTotalExpenseAmounrt { get; set; }
        public string strRemarks { get; set; }
        public string strExpenseKey { get; set; }
    }
}