using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Web;

namespace AuctionInventory.Helpers
{
    public class Menus
    {

        public bool ShowDashBoard { get; set; }
        public bool ShowSupplier { get; set; }
        public bool ShowEmployee { get; set; }
        public bool ShowExpenses { get; set; }
        public bool ShowPurchase { get; set; }
        public bool ShowCurrency { get; set; }
        public bool ShowCategory { get; set; }
        public bool ShowSale { get; set; }
        public bool ShowPapers { get; set; }
        public bool ShowAuction { get; set; }
        public bool ShowLedger { get; set; }
        public bool ShowProducts { get; set; }
        public bool ShowQueue { get; set; }
        public bool ShowReports { get; set; }
        public bool ShowCustomer { get; set; }

      
    }
}