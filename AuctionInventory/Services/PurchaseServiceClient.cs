using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class PurchaseServiceClient
    {

        public List<Purchase> GetAllPurchase()
        {
            List<Purchase> listPurchase = new List<Purchase>();
            PurchaseRepository repo = new PurchaseRepository();
            dynamic pur = repo.GetAll();
            listPurchase = ParserGetAllPurchase(pur);
            return listPurchase;
        }
        public bool SaveData(Purchase purchase, List<Vehicles> griddata)
        {
            bool status = true;
            Purchase Pur = new Purchase();
            PurchaseRepository repo = new PurchaseRepository();
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
                    mVehicle.iModel = item.iModel ?? " ";
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
                    mVehicle.iDuty = item.iDuty;
                    mVehicle.iCustomValInJPY = item.iCustomValInJPY;
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
                tPurchase.strInvoiceValue = purchase.strInvoiceValue ?? " ";
                tPurchase.dmlConversionRate = purchase.dmlConversionRate;
                tPurchase.iAED = purchase.iAED;
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
                    purchase.iAED = data.iAED ?? 0;
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
                purchase.iAED = data.iAED ;
            }
            return purchase;
        }




        #endregion
    }

}