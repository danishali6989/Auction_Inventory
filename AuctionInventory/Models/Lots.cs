using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Lots
    {
        public long iLotID { get; set; }
        public string strLotName { get; set; }
        public string strFromDate { get; set; }
        public Nullable<System.DateTime> dtFromDate { get; set; }
        public string strToDate { get; set; }
        public Nullable<System.DateTime> dtToDate { get; set; }
        public string chLotType { get; set; }
    }
}