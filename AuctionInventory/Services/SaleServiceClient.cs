using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class SaleServiceClient
    {
        public bool SaveSalesData(SaleModel sale, List<SalesVehicleModel> saleVehicles, SalesPaymentModel salesPaymentModel)
        {
            bool status = true;

            SaleRepository repo = new SaleRepository();
            status = repo.SaveRepository(ParserAddSale(sale), ParserAddSalesVehicle(saleVehicles), ParserAddSalesPayment(salesPaymentModel));
            return status;
        }


        public bool UpdateOnlySalesPayment(SalesPaymentModel salesPaymentModel)
        {
            bool status = true;

            SaleRepository repo = new SaleRepository();
            status = repo.UpdateOnlySalesPayment(ParserAddSalesPayment(salesPaymentModel));
            return status;
        }

        public dynamic GetVehiclesDataBySalesDate(DateTime salesDate)
        {
            SaleRepository repo = new SaleRepository();
            var getvehiclelist = repo.GetVehiclesDataBySalesDate(salesDate);
            return getvehiclelist;

        }

        public dynamic GetAllSalesReportByDate(DateTime fromDate, DateTime toDate, int customerID)
        {
            dynamic listSales = 0;
            SaleRepository repo = new SaleRepository();
            if (customerID != 0)
            {
                listSales = repo.GetAllSalesReportByDateandCustomer(fromDate, toDate, customerID);
            }
            else
            {

                listSales = repo.GetAllSalesReportByDate(fromDate, toDate);
            }
            return listSales;
        }

        //public dynamic GetAllSalesReportByDate(DateTime fromDate, DateTime toDate)
        //{

        //    SaleRepository repo = new SaleRepository();
        //    var listSales = repo.GetAllSalesReportByDate(fromDate, toDate);
        //    return listSales;
        //}

        public bool SaveSlesLot(Lots lot)
        {
            bool status = true;
          
            SaleRepository repo = new SaleRepository();
            status = repo.SalesLotSaveEdit(ParserAddSalesLot(lot));
            return status;
        }

      

        public dynamic GetAllLots()
        {

            SaleRepository repo = new SaleRepository();
            var listLot = repo.GetAllLots();
            return listLot;
        }

        public Lots GetLots(int id)
        {

            Lots lots = new Lots();
            SaleRepository repo = new SaleRepository();
            if (lots != null)
            {
                lots = ParserGetSalesLot(repo.GetLot(id));
            }
            return lots;

        }

        public bool DeleteSalesLot(int id)
        {
            bool status = false;
            SaleRepository repo = new SaleRepository();
            status = repo.DeleteSalesLot(id);
            return status;
        }
        public bool CheckCustomerIsBlockOrNot()
        {
            bool status = true;

            SaleRepository repo = new SaleRepository();
            status = repo.CheckCustomerIsBlockOrNot();
            return status;
        }
        public dynamic GetSalesData()
        {
            SaleRepository repo = new SaleRepository();
            dynamic getvehiclelist = repo.GetSalesData();
            return getvehiclelist;

        }

        public dynamic GetAllSalesPaymentList()
        {
            SaleRepository repo = new SaleRepository();
            dynamic getSalesPaymentlist = repo.GetAllSalesPaymentList();
            return getSalesPaymentlist;

        }
        public dynamic GetCustomerDetails(string prefix)
        {
            SaleRepository repo = new SaleRepository();
            var customer = repo.GetCustomerDetails(prefix);
            return customer;

        }
        public dynamic GetInvoice()
        {
            SaleRepository repo = new SaleRepository();
            var invoiceID = repo.GetInvoice();
            return invoiceID;

        }


        public dynamic GetReceiptNo()
        {
            SaleRepository repo = new SaleRepository();
            var receiptNo = repo.GetReceiptNo();
            return receiptNo;

        }



      


        public dynamic GetSalesFrontEndID()
        {
            SaleRepository repo = new SaleRepository();
            var SalesFrontEndID = repo.GetSalesFrontEndID();
            return SalesFrontEndID;

        }


        //public bool Delete(string id)
        //{
        //    bool status = false;
        //    SaleRepository repo = new SaleRepository();
        //    status = repo.Delete(id);
        //    return status;
        //}

        #region Parser
        private Sale ParserAddSale(SaleModel mSale)
        {
            Sale eSale = new Sale();

            if (mSale != null)
            {
                eSale.iSaleID = mSale.iSaleID;
                eSale.iSaleFrontEndID = mSale.iSaleFrontEndID;
                eSale.strBuyerName = mSale.strBuyerName ?? " ";
                eSale.iCustomerID = mSale.iCustomerID;

                eSale.strSalesInvoiceNo = mSale.strSalesInvoiceNo ?? " ";

                eSale.strSalesDate = mSale.strSalesDate ?? " ";
                eSale.dmlSellingPrice = mSale.dmlSellingPrice;
                eSale.dmlDeposit = mSale.dmlDeposit;
                eSale.dmlAdvance = mSale.dmlAdvance;
                eSale.dmlBalance = mSale.dmlBalance;
                eSale.iInstallment = mSale.iInstallment;
                eSale.iPaymentType = mSale.iPaymentType;
                eSale.iImpExpTransfer = mSale.iImpExpTransfer;
                eSale.iSalesInvoiceID = mSale.iSalesInvoiceID;
                eSale.dtSalesDate = mSale.dtSalesDate;
                eSale.dtCreditLimitDate = mSale.dtCreditLimitDate;
                eSale.ysnPaymentStatus = mSale.ysnPaymentStatus;
            }
            return eSale;
        }


        private List<SalesVehicle> ParserAddSalesVehicle(List<SalesVehicleModel> mSaleVehicles)
        {
            List<SalesVehicle> ListSalesVehicle = new List<SalesVehicle>();



            foreach (var item in mSaleVehicles)
            {

                if (mSaleVehicles != null)
                {
                    SalesVehicle eSalesVehicle = new SalesVehicle();
                    eSalesVehicle.iSalesVehicleID = item.iSalesVehicleID;
                    eSalesVehicle.iSaleFrontEndID = item.iSaleFrontEndID;
                    eSalesVehicle.iVehicleID = item.iVehicleID;
                    ListSalesVehicle.Add(eSalesVehicle);
                }
            }
            return ListSalesVehicle;
        }


        private SalesPayment ParserAddSalesPayment(SalesPaymentModel mSalesPayment)
        {
            SalesPayment eSalesPayment = new SalesPayment();

            if (mSalesPayment != null)
            {

                eSalesPayment.iPaymentID = mSalesPayment.iPaymentID;
                eSalesPayment.iSaleID = mSalesPayment.iSaleID;
                eSalesPayment.iCustomerID = mSalesPayment.iCustomerID;
                eSalesPayment.strPaymentDate = mSalesPayment.strPaymentDate;
                eSalesPayment.dmlPaidAmount = mSalesPayment.dmlPaidAmount;
                eSalesPayment.dmlPrevBalance = mSalesPayment.dmlPrevBalance;
                eSalesPayment.ysnPaymentStatus = mSalesPayment.ysnPaymentStatus;
                eSalesPayment.dtPaymentDate = mSalesPayment.dtPaymentDate;
                eSalesPayment.iSalesInvoiceID = mSalesPayment.iSalesInvoiceID;
                eSalesPayment.strSalesInvoiceNo = mSalesPayment.strSalesInvoiceNo;
                eSalesPayment.iPaymentReceiptNo = mSalesPayment.iPaymentReceiptNo;
                eSalesPayment.strPaymentReceiptNo = mSalesPayment.strPaymentReceiptNo;

            }
            return eSalesPayment;
        }

        private MLot ParserAddSalesLot(Lots lot)
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
        private MLot ParserSalesLot(dynamic data)
        {
            MLot lot = new MLot();
            if (data != null)
            {
                // supplier.FullName = data.FullName;
                lot.iLotID = data.iLotID ?? -1;
                lot.strLotName = data.strLotName ?? " ";
                lot.strFromDate = data.strMiddleName ?? " ";
                lot.dtFromDate = data.dtFromDate ?? " ";
                lot.strToDate = data.strToDate ?? " ";
                lot.dtToDate = data.dtToDate ?? " ";
                lot.chLotType = data.chLotType ?? " ";

            }
            return lot;
        }

        private Lots ParserGetSalesLot(dynamic data)
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
    }
}