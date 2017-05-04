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

        public dynamic GetAll()
        {
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = auctionContext.TPurchases.ToList().Count,
                rows = (
                  from purchase in
                      (from AM in auctionContext.TPurchases

                       //join t1 in auctionContext.MCountries on AM.iCountry equals t1.iCountry
                       //join t2 in auctionContext.MCities on AM.iCity equals t2.iCity

                       select new
                       {
                           PurchaseID = AM.PurchaseID,
                           iPurchaseInvoiceNo = AM.iPurchaseInvoiceNo,
                           strPurchaseInvoiceNo = AM.strPurchaseInvoiceNo,

                           strPurchaseInvoiceDate = AM.strPurchaseInvoiceDate,
                           strSupplierName = AM.strSupplierName,
                           strMasterDecNo = AM.strMasterDecNo,
                           strBLNo = AM.strBLNo,
                           strArrivalDate = AM.strArrivalDate,
                           dmlConversionRate = AM.dmlConversionRate,
                           dcmlAED = AM.dcmlAED,
                           dcmlJYP = AM.dcmlJYP,


                       }).OrderBy(a => a.iPurchaseInvoiceNo).ToList()
                  select new
                  {
                      id = purchase.PurchaseID,
                      cell = new string[] {
               Convert.ToString(purchase.PurchaseID),Convert.ToString(purchase.iPurchaseInvoiceNo),
               Convert.ToString(purchase.strPurchaseInvoiceNo),Convert.ToString(purchase.strPurchaseInvoiceDate),
               Convert.ToString(purchase.strSupplierName),Convert.ToString(purchase.strMasterDecNo),
               Convert.ToString(purchase.strBLNo),Convert.ToString(purchase.strArrivalDate),
               Convert.ToString(purchase.dmlConversionRate),
               Convert.ToString(purchase.dcmlAED),
               Convert.ToString(purchase.dcmlJYP)
               
               //,Convert.ToString(customers.iPersonID),
               //Convert.ToString(customers.strPersonFirstName+" "+customers.strPersonLastName),Convert.ToString(customers.strCompanyName),
               //Convert.ToString(customers.CustomerPhoto),Convert.ToString(customers.CustomerDate)
                        }
                  }).ToArray()
            };
            return jsonData;
        }



        public dynamic GetAllPurchaseReportByDate(DateTime fromDate, DateTime toDate)
        {

            var purchaseReportByDate = (from AM in auctionContext.TPurchases

                                      where (AM.dtPurchaseInvoiceDate) >= (fromDate) && (AM.dtPurchaseInvoiceDate) <= (toDate)

                                      select new
                                      {
                                          //PurchaseID = AM.PurchaseID,
                                          //iPurchaseInvoiceNo = AM.iPurchaseInvoiceNo,
                                          strPurchaseInvoiceNo = AM.strPurchaseInvoiceNo,

                                          strPurchaseInvoiceDate = AM.strPurchaseInvoiceDate,
                                          strSupplierName = AM.strSupplierName,
                                          strMasterDecNo = AM.strMasterDecNo,
                                          strBLNo = AM.strBLNo,
                                          strArrivalDate = AM.strArrivalDate,
                                          //dmlConversionRate = AM.dmlConversionRate,
                                          dcmlAED = AM.dcmlAED,
                                          dcmlJYP = AM.dcmlJYP,


                                      }).OrderBy(a => a.strPurchaseInvoiceNo).ToList();

            var sumOfAED = purchaseReportByDate.Sum(x => x.dcmlAED);
            var sumOfJYP = purchaseReportByDate.Sum(x => x.dcmlJYP);
            return new { purchaseReportByDate, sumOfAED, sumOfJYP };
            //return purchaseReportByDate;

        }


        //public dynamic GetAllPurchaseReport()
        //{
        //    var jsonData = new
        //    {
        //        total = 1,
        //        page = 1,
        //        records = auctionContext.TPurchases.ToList().Count,
        //        rows = (
        //          from purchase in
        //              (from AM in auctionContext.TPurchases

        //               //join t1 in auctionContext.MCountries on AM.iCountry equals t1.iCountry
        //               //join t2 in auctionContext.MCities on AM.iCity equals t2.iCity

        //               select new
        //               {
        //                   PurchaseID = AM.PurchaseID,
        //                   iPurchaseInvoiceNo = AM.iPurchaseInvoiceNo,
        //                   strPurchaseInvoiceNo = AM.strPurchaseInvoiceNo,

        //                   strPurchaseInvoiceDate = AM.strPurchaseInvoiceDate,
        //                   strSupplierName = AM.strSupplierName,
        //                   strMasterDecNo = AM.strMasterDecNo,
        //                   strBLNo = AM.strBLNo,
        //                   strArrivalDate = AM.strArrivalDate,
        //                   dmlConversionRate = AM.dmlConversionRate,
        //                   dcmlAED = AM.dcmlAED,
        //                   dcmlJYP = AM.dcmlJYP,


        //               }).OrderBy(a => a.iPurchaseInvoiceNo).ToList()
        //          select new
        //          {
        //              id = purchase.PurchaseID,
        //              cell = new string[] {
        //       Convert.ToString(purchase.PurchaseID),Convert.ToString(purchase.iPurchaseInvoiceNo),
        //       Convert.ToString(purchase.strPurchaseInvoiceNo),Convert.ToString(purchase.strPurchaseInvoiceDate),
        //       Convert.ToString(purchase.strSupplierName),Convert.ToString(purchase.strMasterDecNo),
        //       Convert.ToString(purchase.strBLNo),Convert.ToString(purchase.strArrivalDate),
        //       Convert.ToString(purchase.dmlConversionRate),
        //       Convert.ToString(purchase.dcmlAED),
        //       Convert.ToString(purchase.dcmlJYP)
               
        //       //,Convert.ToString(customers.iPersonID),
        //       //Convert.ToString(customers.strPersonFirstName+" "+customers.strPersonLastName),Convert.ToString(customers.strCompanyName),
        //       //Convert.ToString(customers.CustomerPhoto),Convert.ToString(customers.CustomerDate)
        //                }
        //          }).ToArray()
        //    };
        //    return jsonData;
        //}

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


           

            //var test = (from max in auctionContext.TPurchases
            //            where !String.IsNullOrEmpty(max.strPurchaseInvoiceNo)
            //            select Convert.ToInt32(max.strPurchaseInvoiceNo)).Max();


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
                    pur.dcmlAED = purchase.dcmlAED;
                    pur.dcmlJYP = purchase.dcmlJYP;
                    pur.dtPurchaseInvoiceDate = purchase.dtPurchaseInvoiceDate;

                }
            }
            else
            {
               

                //Save
                purchase.iPurchaseInvoiceNo = invNo;
                //purchase.strPurchaseInvoiceNo = invNo;
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
