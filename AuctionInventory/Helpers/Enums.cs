﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Helpers
{
    public class Enums
    {

        public enum Roles
        {
            SuperAdmin = 1,
            AdminSupplier = 2,
            Accountant = 3,
            DataEntry = 4,
            XYZRole = 5
        }

        public enum VehicleExpenseType
        {
            AllVehicleExpense = 1,
            SingleVehicleExpense = 2
        }


        public enum Creditcategory
        {
            A = 10,
            B = 15,
            C = 20
        }
    }
}