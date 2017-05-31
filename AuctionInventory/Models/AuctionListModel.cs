using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class AuctionListModel
    {
        public long iAuctionListID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public string strAuctionDate { get; set; }
        public Nullable<int> iAuctionFrontEndID { get; set; }
        public Nullable<System.DateTime> dtAuctionDate { get; set; }
    }
}