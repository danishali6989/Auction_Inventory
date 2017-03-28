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
               
                eSale.strSalesDate = mSale.strSalesDate ?? " ";
                eSale.dmlSellingPrice = mSale.dmlSellingPrice;
                eSale.dmlDeposit = mSale.dmlDeposit;
                eSale.dmlAdvance = mSale.dmlAdvance;
                eSale.dmlBalance = mSale.dmlBalance;
                eSale.iInstallment = mSale.iInstallment;
                eSale.iPaymentType = mSale.iPaymentType;
                eSale.iImpExpTransfer = mSale.iImpExpTransfer;
                eSale.iSalesInvoiceID = mSale.iSalesInvoiceID;
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