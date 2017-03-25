using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class SingleVehicleExpenseModel
    {
        public long iSingleVehicleID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public int iExpenseID { get; set; }
        public Nullable<int> iExpenseAmount { get; set; }
        public Nullable<int> iTotalExpenseAmounrt { get; set; }
        public string strRemarks { get; set; }
    }
}