using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class PaperDetailsExportModel
    {
        public long iPaperDetailsForExportID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public string strReceivingDate { get; set; }
        public string strSubmitDate { get; set; }
        public Nullable<int> iCustApproval { get; set; }
        public Nullable<decimal> dcmlDeduction { get; set; }
        public Nullable<decimal> dcmlFine { get; set; }
        public Nullable<decimal> dcmlMisc { get; set; }
        public Nullable<decimal> dcmlExportDeposit { get; set; }
        public Nullable<decimal> dcmlExportBalance { get; set; }
    }
}