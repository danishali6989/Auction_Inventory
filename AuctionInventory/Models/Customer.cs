using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Customer
    {
        public int iCustomerID { get; set; }
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }
        public string strLastName { get; set; }
        public Nullable<int> iCountry { get; set; }
        public Nullable<int> iCity { get; set; }
        public string strEmailID { get; set; }
        public Nullable<int> iPhoneNumber { get; set; }
        public string strAddress { get; set; }
        public Nullable<int> iPincode { get; set; }
        public string strCreditLimit { get; set; }
        public Nullable<int> iPersonID { get; set; }
        public string strPersonFirstName { get; set; }
        public string strPersonMiddleName { get; set; }
        public string strPersonLastName { get; set; }
        public string strCompanyName { get; set; }
        public string CustomerPhoto { get; set; }
        public string CustomerDate { get; set; }
    }
}