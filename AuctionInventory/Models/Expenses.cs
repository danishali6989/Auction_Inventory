using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{






    public class Expenses
    {
        public int iExpenseID { get; set; }
        //[Required(ErrorMessage = "Expense Name is required")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Use Letters Only ")]
        public string strExpenseName { get; set; }

        public int iPurchaseInvoiceID { get; set; }
        public Nullable<int> iCategoryID { get; set; }
        public Nullable<int> iSubCategoryID { get; set; }
        public Nullable<int> iExpenseAmount { get; set; }

    }
}