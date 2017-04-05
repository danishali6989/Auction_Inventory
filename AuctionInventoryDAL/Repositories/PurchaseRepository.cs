using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AuctionInventoryDAL.Repositories
{
    public class PurchaseRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public List<TPurchase> GetAll()
        {
            List<TPurchase> listPurchase = new List<TPurchase>();
            listPurchase = (from r in auctionContext.TPurchases select r).OrderBy(a => a.PurchaseID).ToList();
            return listPurchase;
        }

        public TPurchase Get(int id)
        {
            TPurchase purchase = new TPurchase();

            //var test = from a in auctionContext.TPurchases
            //           where a.PurchaseID == id
            //           select a 
            //           ;
            purchase = auctionContext.TPurchases.Where(a => a.PurchaseID == id).SingleOrDefault();
            // purchase = auctionContext.TPurchases.Where(a => a.PurchaseID == id).FirstOrDefault();
            return purchase;
        }
        
        public dynamic GetInvoiceRepo()
        {
            
            var invNo = auctionContext.TPurchases.Max(i => i.iPurchaseInvoiceNo) + 1;
            return invNo;
        }


        public dynamic GetDataVehiclelist(int id)
        {
            //List<Vehicle> listVehicle = (from t1 in auctionContext.Vehicles
            var listVehicle = (from t1 in auctionContext.Vehicles
                               //join t2 in dc.MColors on t1.iColor equals t2.iColorID
                               where t1.PurchaseID == id
                               select new
                               {
                                   iVehicleID = t1.iVehicleID,
                                   iLotNum = t1.iLotNum,
                                   strChassisNum = t1.strChassisNum,
                                   strMake = t1.strMake,
                                   iModel = t1.iModel,
                                   strCategory = t1.strCategory,
                                   iYear = t1.iYear,
                                   strColor = t1.strColor,
                                   strOrigin = t1.strOrigin,
                                   strLocation = t1.strLocation,
                                   iCustomAssesVal = t1.iCustomAssesVal,
                                   iDuty = t1.iDuty,
                                   iCustomValInJPY = t1.iCustomValInJPY
                                   //,strGrade =t1.strGrade,                                             


                                   //dmlKM = t1.dmlKM,

                                   //iDoor = t1.iDoor,

                                   //weight = t1.weight,
                                   //strHSCode = t1.strHSCode,
                                   //ATMT = t1.ATMT,



                               }).ToList();

            var sumOfJPY = listVehicle.Sum(x => x.iCustomValInJPY);

            var sumOfAED = listVehicle.Sum(x => x.iCustomValInJPY) * Convert.ToDecimal(0.033);

            //return Json(new { listVehicle, sumOfJPY, sumOfAED }, JsonRequestBehavior.AllowGet);

            return new { listVehicle, sumOfJPY, sumOfAED };



            //var auction = (from t1 in auctionContext.AuctionLists
            //               join t2 in auctionContext.Vehicles on t1.iVehicleID equals t2.iVehicleID
            //               where t1.iAuctionFrontEndID == id

            //               select t2).OrderBy(a => a.iVehicleID).ToList();
            //var vehicle = auction.Select(i =>
            // new { LotNum = i.iLotNum, ChassisNum = i.strChassisNum, iModel = i.iModel, Year = i.iYear, color = i.strColor, JPY = i.iCustomAssesVal }).ToList();

            //return vehicle;


        }


        public dynamic GenerateInvoicePDF()
        {
            var vehicle = (from a in auctionContext.Vehicles select a).OrderBy(a => a.iLotNum).ToList();
            var catName = vehicle.Select(i =>
           new { LotNum = i.iLotNum, ChassisNum = i.strChassisNum, Make = i.strMake, iModel = i.iModel, Category = i.strCategory, Year = i.iYear, color = i.strColor, Origin = i.strOrigin, Location = i.strLocation, JPY = i.iCustomValInJPY }).ToList();

            return catName;
        }
        public dynamic GenerateCustomPDF()
        {
            var vehicle = (from a in auctionContext.Vehicles select a).OrderBy(a => a.iLotNum).ToList();
            var catNames = vehicle.Select(i =>
           new { LotNum = i.iLotNum, ChassisNum = i.strChassisNum, Make = i.strMake, iModel = i.iModel, Category = i.strCategory, Year = i.iYear, color = i.strColor, Origin = i.strOrigin, Location = i.strLocation, JPY = i.iCustomAssesVal }).ToList();

            return catNames;
        }
        public dynamic AutoCompleteRepo(string prefix)
        {
            
            var suppliers = (from supplier in auctionContext.MSuppliers
                             where supplier.strFirstName.StartsWith(prefix)
                             select new
                             {
                                 strFirstName = supplier.strFirstName,
                                 iSupplierID = supplier.iSupplierID
                             }).ToList();

           
            return suppliers;
        }
        public bool SaveEdit(TPurchase purchase, List<Vehicle> griddata)
        {
            bool status = false;
            var pur = auctionContext.TPurchases.Where(a => a.PurchaseID == purchase.PurchaseID).FirstOrDefault();
            int? invNo = auctionContext.TPurchases.Max(i => i.iPurchaseInvoiceNo) ?? 0;
            invNo = invNo + 1;

            if (purchase.PurchaseID > 0)
            {
                //Edit Existing Record

                if (pur != null && invNo > 0)
                {
                    pur.PurchaseID = purchase.PurchaseID;
                    // pur.iPurchaseInvoiceNo = invNo;
                    // pur.iPurchaseInvoiceNo = purchase.iPurchaseInvoiceNo;
                    pur.strPurchaseInvoiceDate = purchase.strPurchaseInvoiceDate;
                    pur.strSupplierName = purchase.strSupplierName;
                    pur.strMasterDecNo = purchase.strMasterDecNo;
                    pur.strBLNo = purchase.strBLNo;
                    pur.strArrivalDate = purchase.strArrivalDate;
                    pur.strInvoiceValue = purchase.strInvoiceValue;
                    pur.dmlConversionRate = purchase.dmlConversionRate;
                    pur.iAED = purchase.iAED;

                }
            }
            else
            {
                //Save
                purchase.iPurchaseInvoiceNo = invNo;
                auctionContext.TPurchases.Add(purchase);
            }
            auctionContext.SaveChanges();

            var id = purchase.PurchaseID;

            // Assiging Purchase id to vehicles data
            griddata.ForEach(x => x.PurchaseID = id);



            foreach (var item in griddata)
            {
                if (item.iVehicleID > 0)
                {
                    var vehicle = auctionContext.Vehicles.Where(a => a.iVehicleID == item.iVehicleID).FirstOrDefault();
                    if (vehicle != null)
                    {
                        vehicle.iLotNum = item.iLotNum;
                        vehicle.strGrade = item.strGrade;
                        vehicle.strChassisNum = item.strChassisNum;
                        vehicle.strCategory = item.strCategory;
                        vehicle.strMake = item.strMake;
                        vehicle.iModel = item.iModel;
                        vehicle.iYear = item.iYear;
                        vehicle.strColor = item.strColor;
                        vehicle.dmlKM = item.dmlKM;
                        vehicle.strOrigin = item.strOrigin;
                        vehicle.iDoor = item.iDoor;
                        vehicle.strLocation = item.strLocation;
                        vehicle.weight = item.weight;
                        vehicle.strHSCode = item.strHSCode;
                        vehicle.ATMT = item.ATMT;
                        vehicle.iCustomAssesVal = item.iCustomAssesVal;
                        vehicle.iDuty = item.iDuty;
                        vehicle.iCustomValInJPY = item.iCustomValInJPY;

                    }
                }
                else
                {
                    item.IsStockRecieved = false;
                    auctionContext.Vehicles.Add(item);
                    //Vehicle vehicle = new Vehicle();
                    
                    //    vehicle.IsStockRecieved = false;
                    
                }
            }

            auctionContext.SaveChanges();
            status = true;
            return status;

        }


        public bool Delete(int id)
        {
            bool status = false;
            var pur = auctionContext.TPurchases.Where(a => a.PurchaseID == id).FirstOrDefault();
            var vehicles = auctionContext.Vehicles.Where(a => a.PurchaseID == id);
            //foreach (var vehicleitems in vehicles)
            //{

            //}
            if (pur != null && vehicles!=null)
            {
                auctionContext.TPurchases.Remove(pur);
               

                auctionContext.Vehicles.RemoveRange(vehicles);
               
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }






        #endregion
    }
}
