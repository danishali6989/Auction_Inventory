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
            //bool status = false;
            //var invNo = auctionContext.TPurchases.Max(i => i.iPurchaseInvoiceNo) + 1;
            //status = true;
            //return status;
            var invNo = auctionContext.TPurchases.Max(i => i.iPurchaseInvoiceNo) + 1;
            return invNo;
        }


        public dynamic AutoCompleteRepo(string prefix)
        {
            //bool status = false;
            var suppliers = (from supplier in auctionContext.MSuppliers
                             where supplier.strFirstName.StartsWith(prefix)
                             select new
                             {
                                 strFirstName = supplier.strFirstName,
                                 iSupplierID = supplier.iSupplierID
                             }).ToList();

            //status = true;
            //return status;
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
