using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Color
    {
        public int iColorID { get; set; }
        [Required(ErrorMessage = "Color Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Use Letters Only ")]
        public string strColorName { get; set; }
    }
}