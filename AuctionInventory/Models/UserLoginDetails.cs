using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class UserLoginDetails
    {
        public long UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Nullable<long> SupplierId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public Nullable<int> RoleId { get; set; }
    }
}