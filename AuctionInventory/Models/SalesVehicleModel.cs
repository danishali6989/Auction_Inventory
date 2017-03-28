using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class SalesVehicleModel
    {
        public long iSalesVehicleID { get; set; }
        public Nullable<int> iSaleFrontEndID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
    }
}