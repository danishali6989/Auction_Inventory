using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Currency
    {
        public int CurrencyID { get; set; }

        [Required(ErrorMessage = "Currency Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Use Letters Only ")]
        public string strCurrencyName { get; set; }
        public string strCurrencyShortName { get; set; }
    }
}