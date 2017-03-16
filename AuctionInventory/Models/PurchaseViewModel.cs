using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;

namespace AuctionInventory.Models
{
    public class PurchaseViewModel
    {

        public PurchaseViewModel()
        {

        }


        public Vehicles vehiclesModel { get; set; }
        public Purchase purchaseModel { get; set; }


    }
}