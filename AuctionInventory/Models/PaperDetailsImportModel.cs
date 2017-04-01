using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class PaperDetailsImportModel
    {
        public long iPaperDetailsForImportID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public Nullable<int> iDecNo { get; set; }
        public string strDecDate { get; set; }
        public Nullable<int> iImpDeposit { get; set; }
        public Nullable<int> iDuty { get; set; }
        public Nullable<int> iPaper { get; set; }
        public Nullable<int> iTotal { get; set; }
        public Nullable<int> iImpBalance { get; set; }
    }
}