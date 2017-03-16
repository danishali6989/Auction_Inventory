using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Company
    {
        public int iCompanyID { get; set; }
        public string strCompanyName { get; set; }
        public string strArea { get; set; }
        public Nullable<int> iCountry { get; set; }
        public Nullable<int> iCity { get; set; }
        public string strEmailID { get; set; }
        public string strWebsites { get; set; }
        public Nullable<int> iPhoneNumber { get; set; }
        public Nullable<int> iOfcPhoneNumber { get; set; }
        public string strAddress { get; set; }
    }
}