using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;
using AuctionInventory.Helpers;

namespace AuctionInventory.Services
{
    public class PurchaseServiceClient
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public dynamic GetAllPurchase()
        {
            
            PurchaseRepository repo = new PurchaseRepository();
            var listPurchase = repo.GetAll();          
            return listPurchase;
        }

        //public dynamic GetAllPurchaseReportByDate(DateTime fromDate, DateTime toDate)
        //{

        //    PurchaseRepository repo = new PurchaseRepository();
        //    var listPurchase = repo.GetAllPurchaseReportByDate(fromDate, toDate);
        //    return listPurchase;
        //}


        public dynamic GetAllPurchaseReportByDate(DateTime fromDate, DateTime toDate, string supplierName)
        {
            dynamic listPurchase = 0;
            PurchaseRepository repo = new PurchaseRepository();
            if (supplierName != "")
            {
                listPurchase = repo.GetAllPurchaseReportByDateAndSuppier(fromDate, toDate, supplierName);
            }
            else
            {
                listPurchase = repo.GetAllPurchaseReportByDate(fromDate, toDate);
            }

            return listPurchase;
        }


        //public dynamic GetAllPurchaseReport()
        //{

        //    PurchaseRepository repo = new PurchaseRepository();
        //    var listPurchase = repo.GetAllPurchaseReport();
        //    return listPurchase;
        //}

        public bool SaveData(Purchase purchase, List<Vehicles> griddata)
        {
            bool status = true;
            //Purchase Pur = new Purchase();
            PurchaseRepository repo = new PurchaseRepository();
          //  string purchaseInvoice=CommonMethods.GetPurchaseInvoiceNumber(PurchaseInvoiceNum.PurchaseInvoice,)
           
            status = repo.SaveEdit(ParserAddPurchase(purchase), ParserAddListVehicle(griddata));
            return status;
        }

        private List<Vehicle> ParserAddListVehicle(List<Vehicles> vehicles)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            foreach (var item in vehicles)
            {
                if (item != null)
                {
                    Vehicle mVehicle = new Vehicle();
                    mVehicle.iVehicleID = item.iVehicleID;
                    mVehicle.iLotNum = item.iLotNum;
                    mVehicle.strGrade = item.strGrade ?? " ";
                    mVehicle.strChassisNum = item.strChassisNum ?? " ";
                    mVehicle.strCategory = item.strCategory ?? " ";
                    mVehicle.strMake = item.strMake ?? " ";
                    mVehicle.iModel = item.iModel;
                    mVehicle.iYear = item.iYear ?? " ";
                    mVehicle.strColor = item.strColor;
                    mVehicle.dmlKM = item.dmlKM;
                    mVehicle.strOrigin = item.strOrigin ?? " ";
                    mVehicle.iDoor = item.iDoor;
                    mVehicle.strLocation = item.strLocation ?? " ";
                    mVehicle.weight = item.weight ?? " ";
                    mVehicle.strHSCode = item.strHSCode ?? " ";
                    mVehicle.ATMT = item.ATMT ?? " ";
                    mVehicle.iCustomAssesVal = item.iCustomAssesVal;
                    mVehicle.dmlDuty = item.dmlDuty;
                    mVehicle.iCustomValInJPY = item.iCustomValInJPY;


                     mVehicle.strGradeA = item.strGradeA ?? " ";
                    mVehicle.strGradeB = item.strGradeB ?? " ";
                    mVehicle.dmlLitter = item.dmlLitter;
                    mVehicle.strTrans = item.strTrans;
                    mVehicle.iMileage = item.iMileage;
                  


                    listVehicle.Add(mVehicle);
                }
            }
            return listVehicle;
        }


        public dynamic GetDataVehiclelist(int id)
        {

            PurchaseRepository repo = new PurchaseRepository();
            dynamic listVehicle = repo.GetDataVehiclelist(id);
            return listVehicle;
        }

        public dynamic GetInvoiceID()
        {
            
            PurchaseRepository repo = new PurchaseRepository();
           
            return repo.GetInvoiceRepo();
        }


        public dynamic AutoCompleteService(string prefix)
        {
           
            PurchaseRepository repo = new PurchaseRepository();           
            return repo.AutoCompleteRepo(prefix);
        }

        
        public dynamic GenerateCustomPDF()
        {
           
            PurchaseRepository repo = new PurchaseRepository();

             var vehicle= repo.GenerateCustomPDF();
             return vehicle;
        }

        public dynamic GenerateInvoicePDF()
        {
           
            PurchaseRepository repo = new PurchaseRepository();

            var vehicle = repo.GenerateInvoicePDF();
             return vehicle;
        }
        public Purchase GetPurchase(int id)
        {

            Purchase purchase = new Purchase();
            PurchaseRepository repo = new PurchaseRepository();

            var TPurchase = repo.Get(id);
            purchase = ParserPurchase(TPurchase);

            return purchase;

        }


        public bool Delete(int id)
        {
            bool status = false;
            PurchaseRepository repo = new PurchaseRepository();
            status = repo.Delete(id);
            return status;
        }


        #region Lots
        public dynamic GetAllLots()
        {

            PurchaseRepository repo = new PurchaseRepository();
            var listLot = repo.GetAllLots();
            return listLot;
        }

        public bool SavePurchaseLot(Lots lot)
        {
            bool status = true;

            PurchaseRepository repo = new PurchaseRepository();
            status = repo.PurchaseLotSaveEdit(ParserAddPurchaseLot(lot));
            return status;
        }

        public Lots GetLots(int id)
        {

            Lots lots = new Lots();
            PurchaseRepository repo = new PurchaseRepository();
            if (lots != null)
            {
                lots = ParserGetPurchaseLot(repo.GetLot(id));
            }
            return lots;

        }
        public bool DeletePurchaseLot(int id)
        {
            bool status = false;
            PurchaseRepository repo = new PurchaseRepository();
            status = repo.DeletePurchaseLot(id);
            return status;
        }
        private MLot ParserAddPurchaseLot(Lots lot)
        {
            MLot mlot = new MLot();

            if (mlot != null)
            {
                mlot.iLotID = lot.iLotID;
                mlot.strLotName = lot.strLotName ?? " ";
                mlot.strFromDate = lot.strFromDate ?? " ";
                mlot.dtFromDate = lot.dtFromDate;
                mlot.strToDate = lot.strToDate;
                mlot.dtToDate = lot.dtToDate;
                mlot.chLotType = lot.chLotType ?? " ";

            }
            return mlot;
        }

        private Lots ParserGetPurchaseLot(dynamic data)
        {
            Lots lot = new Lots();

            if (data != null)
            {

                lot.iLotID = data.iLotID;
                lot.strLotName = data.strLotName ?? " ";
                lot.strFromDate = data.strFromDate ?? " ";
                lot.dtFromDate = data.dtFromDate ?? " ";
                lot.strToDate = data.strToDate;
                lot.dtToDate = data.dtToDate;
                lot.chLotType = data.chLotType ?? " ";

            }
            return lot;
        }
        #endregion


        #region Parser

        private TPurchase ParserAddPurchase(Purchase purchase)
        {
            TPurchase tPurchase = new TPurchase();

            if (purchase != null)
            {
                tPurchase.PurchaseID = purchase.PurchaseID;
                tPurchase.iPurchaseInvoiceNo = purchase.iPurchaseInvoiceNo;
                tPurchase.strPurchaseInvoiceDate = purchase.strPurchaseInvoiceDate ?? " ";
                tPurchase.strSupplierName = purchase.strSupplierName;
                tPurchase.strMasterDecNo = purchase.strMasterDecNo ?? " ";
                tPurchase.strBLNo = purchase.strBLNo ?? " ";
                tPurchase.strArrivalDate = purchase.strArrivalDate ?? " ";
                tPurchase.strPurchaseInvoiceNo = purchase.strPurchaseInvoiceNo ?? " ";
                tPurchase.dmlConversionRate = purchase.dmlConversionRate;
                tPurchase.dcmlAED = purchase.dcmlAED;
                tPurchase.dcmlJYP = purchase.dcmlJYP;
                tPurchase.strPurchaseInvoiceNo = purchase.strPurchaseInvoiceNo ?? " ";
                tPurchase.dtPurchaseInvoiceDate = purchase.dtPurchaseInvoiceDate;
            }
            return tPurchase;
        }

        private List<Purchase> ParserGetAllPurchase(dynamic responseData)
        {
            List<Purchase> listPurchase = new List<Purchase>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Purchase purchase = new Purchase();
                    purchase.PurchaseID = data.PurchaseID ?? -1;
                    purchase.iPurchaseInvoiceNo = data.iPurchaseInvoiceNo ?? -1;
                    purchase.strPurchaseInvoiceDate = data.strPurchaseInvoiceDate ?? " ";
                    purchase.strSupplierName = data.strSupplierName;
                    purchase.strMasterDecNo = data.strMasterDecNo ?? " ";
                    purchase.strBLNo = data.strBLNo ?? " ";
                    purchase.strArrivalDate = data.strArrivalDate ?? " ";
                    purchase.strInvoiceValue = data.strInvoiceValue ?? " ";
                    purchase.dmlConversionRate = data.dmlConversionRate ?? 0;
                    purchase.dcmlAED = data.dcmlAED ?? 0;
                    purchase.dcmlJYP = data.dcmlJYP ?? 0;
                    purchase.strPurchaseInvoiceNo = data.strPurchaseInvoiceNo ?? " ";
                    purchase.dtPurchaseInvoiceDate = data.dtPurchaseInvoiceDate;
                    listPurchase.Add(purchase);

                }
            }
            return listPurchase;
        }


        private Purchase ParserPurchase(dynamic data)
        {
            Purchase purchase = new Purchase();

            if (data != null)
            {
                purchase.PurchaseID = data.PurchaseID ?? -1;
                purchase.iPurchaseInvoiceNo = data.iPurchaseInvoiceNo ?? -1;
                purchase.strPurchaseInvoiceDate = data.strPurchaseInvoiceDate ?? " ";
                purchase.strSupplierName = data.strSupplierName;
                purchase.strMasterDecNo = data.strMasterDecNo ?? " ";
                purchase.strBLNo = data.strBLNo ?? " ";
                purchase.strArrivalDate = data.strArrivalDate ?? " ";
                purchase.strInvoiceValue = data.strInvoiceValue ?? " ";
                purchase.dmlConversionRate = data.dmlConversionRate ?? 0;
                purchase.dcmlAED = data.dcmlAED ?? 0;
                purchase.dcmlJYP = data.dcmlJYP ?? 0;
                purchase.strPurchaseInvoiceNo = data.strPurchaseInvoiceNo ?? " ";
                purchase.dtPurchaseInvoiceDate = data.dtPurchaseInvoiceDate;

                  
            }
            return purchase;
        }




        #endregion
    }

}