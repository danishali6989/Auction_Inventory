using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class AllVehicleExpenseModel
    {
        public long iAllVehicleExpenseID { get; set; }
        public Nullable<int> iPurchaseInvoiceID { get; set; }
        public int iExpenseID { get; set; }
        public Nullable<int> iExpenseAmount { get; set; }
        public Nullable<int> iTotalExpenseAmounrt { get; set; }
    }
}