using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class CreditCategoryModel
    {
        public long iCreditCategoryID { get; set; }
        public string strCategory { get; set; }
        public Nullable<int> iDays { get; set; }
    }
}