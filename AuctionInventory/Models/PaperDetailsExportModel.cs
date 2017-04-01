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
        public Nullable<int> iDeduction { get; set; }
        public Nullable<int> iFine { get; set; }
        public Nullable<int> iMisc { get; set; }
        public Nullable<int> iExportDeposit { get; set; }
        public Nullable<int> iExportBalance { get; set; }
    }
}