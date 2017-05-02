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
        public bool SaveSalesData(SaleModel sale,List<SalesVehicleModel> saleVehicles)
        {
            bool status = true;

            SaleRepository repo = new SaleRepository();
            status = repo.SaveRepository(ParserAddSale(sale), ParserAddSalesVehicle(saleVehicles));
            return status;
        }
       public dynamic GetVehiclesData()
        {
            SaleRepository repo = new SaleRepository();
            var getvehiclelist = repo.GetVehiclesData();
            return getvehiclelist;

        }

       public dynamic GetAllSalesReportByDate(DateTime fromDate, DateTime toDate)
       {

           SaleRepository repo = new SaleRepository();
           var listSales = repo.GetAllSalesReportByDate(fromDate, toDate);
           return listSales;
       }

       public dynamic GetSalesData()
        {
            SaleRepository repo = new SaleRepository();
            dynamic getvehiclelist = repo.GetSalesData();
            return getvehiclelist;

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
       public dynamic GetSalesFrontEndID()
        {
            SaleRepository repo = new SaleRepository();
            var SalesFrontEndID = repo.GetSalesFrontEndID();
            return SalesFrontEndID;

        }


       //public bool Delete(int id)
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
                eSale.iBuyerID = mSale.iBuyerID;

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


        #endregion
    }
}