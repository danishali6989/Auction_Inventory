using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Vehicles
    {

        public int iVehicleID { get; set; }
        public Nullable<int> iLotNum { get; set; }
        public string strGrade { get; set; }
        public string strChassisNum { get; set; }
        public string strCategory { get; set; }
        public string strMake { get; set; }
       
        public string iYear { get; set; }

        public Nullable<int> iModel { get; set; }
        public string strColor { get; set; }
        public Nullable<decimal> dmlKM { get; set; }
        public string strOrigin { get; set; }
        public Nullable<int> iDoor { get; set; }
        public string strLocation { get; set; }
        public string weight { get; set; }
        public string strHSCode { get; set; }
        public string ATMT { get; set; }
        public Nullable<decimal> iCustomAssesVal { get; set; }
        public Nullable<decimal> dmlDuty { get; set; }
    
        public Nullable<decimal> iCustomValInJPY { get; set; }
        public Nullable<bool> IsStockRecieved { get; set; }
        public long PurchaseID { get; set; }
        public Nullable<decimal> dcmlExpenseAmount { get; set; }
        public string strGradeA { get; set; }
        public string strGradeB { get; set; }
        public Nullable<decimal> dmlLitter { get; set; }
        public string strTrans { get; set; }
        public Nullable<int> iMileage { get; set; }

        public virtual TPurchase TPurchase { get; set; }

    }
}