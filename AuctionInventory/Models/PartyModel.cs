using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class PartyModel   
    {
        public int iPartyID { get; set; }
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }
        public string strLastName { get; set; }
        public Nullable<int> iCountry { get; set; }
        public Nullable<int> iCity { get; set; }
        public string strEmailID { get; set; }
        public string strAddress { get; set; }
        public string iPincode { get; set; }
        public string strPhoneNumber { get; set; }
    }
}