using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Category
    {
        public int iCategoryID { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Use Letters Only ")]
        public string strCategoryName { get; set; }
    }
}