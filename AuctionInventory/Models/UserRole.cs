using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PageModel
    {
        public long PageId { get; set; }
        public string PageName { get; set; }
        public bool IsChecked { get; set; }
    }
}