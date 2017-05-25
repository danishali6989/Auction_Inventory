using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace AuctionInventoryDAL.Repositories
{
    public class SaleRepository
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public bool SaveRepository(Sale sale, List<SalesVehicle> saleVehicles, SalesPayment salesPayment)
        {
            bool status = false;

            var sales = auctionContext.Sales.Where(a => a.iSaleID == sale.iSaleID).FirstOrDefault();


            int? invNo = auctionContext.Sales.Max(i => i.iSalesInvoiceID) ?? 0;
            invNo = invNo + 1;
            int? salesFrontEndID = auctionContext.Sales.Max(i => i.iSaleFrontEndID) ?? 0;
            salesFrontEndID = salesFrontEndID + 1;


            //int? receiptNo = auctionContext.SalesPayments.Max(i => i.iPaymentReceiptNo) ?? 0;
            //receiptNo = receiptNo + 1;

            if (sale.iSaleID > 0)
            {
                //Edit Existing Record

                if (sales != null)
                {

                    sales.iSaleID = sale.iSaleID;
                    sales.iSaleFrontEndID = sale.iSaleFrontEndID;
                    sales.strBuyerName = sale.strBuyerName;
                    sales.iCustomerID = sale.iCustomerID;
                    sales.strSalesDate = sale.strSalesDate;

                    sales.dmlSellingPrice = sale.dmlSellingPrice;
                    sales.dmlDeposit = sale.dmlDeposit;
                    sales.dmlAdvance = sale.dmlAdvance;
                    sales.dmlBalance = sale.dmlBalance;

                    sales.strSalesInvoiceNo = sale.strSalesInvoiceNo;

                    sales.iInstallment = sale.iInstallment;
                    sales.iPaymentType = sale.iPaymentType;
                    sales.iImpExpTransfer = sale.iImpExpTransfer;
                    sales.iSalesInvoiceID = sale.iSalesInvoiceID;
                    sales.dtSalesDate = sale.dtSalesDate;
                    sales.dtCreditLimitDate = sale.dtCreditLimitDate;
                    sales.ysnPaymentStatus = sale.ysnPaymentStatus;


                }
            }

            else
            {
                //Save
                sale.iSalesInvoiceID = invNo;
                sale.iSaleFrontEndID = salesFrontEndID;
                auctionContext.Sales.Add(sale);
            }
            auctionContext.SaveChanges();

            var SaleID = sale.iSaleID;

            {
                //Save

              
                salesPayment.iSaleID = SaleID;              
                auctionContext.SalesPayments.Add(salesPayment);
            }

            auctionContext.SaveChanges();


            foreach (var items in saleVehicles)
            {
                var salesVehicle = auctionContext.SalesVehicles.Where(a => a.iSaleFrontEndID == items.iSaleFrontEndID).ToList();

                if (salesVehicle.Count > 0)
                {
                    foreach (var deletesaleVehicle in salesVehicle)
                    {
                        auctionContext.SalesVehicles.Remove(deletesaleVehicle);
                    }
                    //auctionContext.SaveChanges();
                }
            }
            foreach (var item in saleVehicles)
            {
                //Save
                ///////items.iSaleFrontEndID = salesFrontEndID;
                auctionContext.SalesVehicles.Add(item);
            }

            auctionContext.SaveChanges();
            status = true;
            return status;

        }


        ////old code for save before 18-04-17
        //public bool SaveRepository(Sale sale, List<SalesVehicle> saleVehicles)
        //{
        //    bool status = false;

        //    var sales = auctionContext.Sales.Where(a => a.iSaleID == sale.iSaleID).FirstOrDefault();




        //    int? invNo = auctionContext.Sales.Max(i => i.iSalesInvoiceID) ?? 0;
        //    invNo = invNo + 1;
        //    int? salesFrontEndID = auctionContext.Sales.Max(i => i.iSaleFrontEndID) ?? 0;
        //    salesFrontEndID = salesFrontEndID + 1;

        //    if (sale.iSaleID > 0)
        //    {
        //        //Edit Existing Record

        //        if (sales != null)
        //        {

        //            sales.iSaleID = sale.iSaleID;
        //            sales.iSaleFrontEndID = sale.iSaleFrontEndID;
        //            sales.strBuyerName = sale.strBuyerName;
        //            sales.iCustomerID = sale.iCustomerID;
        //            sales.strSalesDate = sale.strSalesDate;

        //            sales.dmlSellingPrice = sale.dmlSellingPrice;
        //            sales.dmlDeposit = sale.dmlDeposit;
        //            sales.dmlAdvance = sale.dmlAdvance;
        //            sales.dmlBalance = sale.dmlBalance;


        //            sales.iInstallment = sale.iInstallment;
        //            sales.iPaymentType = sale.iPaymentType;
        //            sales.iImpExpTransfer = sale.iImpExpTransfer;
        //            sales.iSalesInvoiceID = sale.iSalesInvoiceID;


        //        }
        //    }

        //    else
        //    {
        //        //Save
        //        sale.iSalesInvoiceID = invNo;
        //        sale.iSaleFrontEndID = salesFrontEndID;
        //        auctionContext.Sales.Add(sale);
        //    }


        //    foreach (var items in saleVehicles)
        //    {

        //        var salesVehicle = auctionContext.SalesVehicles.Where(a => a.iSaleFrontEndID == items.iSaleFrontEndID).FirstOrDefault();

        //        var deleteSalesVehicle = auctionContext.SalesVehicles.Where(a => a.iSaleFrontEndID == items.iSaleFrontEndID).ToList();
        //        if (salesVehicle.iSaleFrontEndID > 0)
        //        {
        //            //Edit Existing Record

        //            foreach (var del in deleteSalesVehicle)
        //            {
        //                auctionContext.SalesVehicles.Remove(del);
        //            }


        //            if (salesVehicle != null)
        //            {


        //                items.iSaleFrontEndID = salesVehicle.iSaleFrontEndID;
        //                auctionContext.SalesVehicles.Add(items);


        //            }

        //        }

        //        else
        //        {
        //            //Save
        //            items.iSaleFrontEndID = salesFrontEndID;
        //            auctionContext.SalesVehicles.Add(items);
        //        }
        //    }

        //    auctionContext.SaveChanges();
        //    status = true;
        //    return status;

        //}


        public dynamic GetAllSalesReportByDate(DateTime fromDate, DateTime toDate)
        {

            var salesReportByDate = (from AM in auctionContext.Sales
                                     join t2 in auctionContext.PaperTypes on AM.iImpExpTransfer equals t2.iPaperModeID
                                     join t3 in auctionContext.PaymentTypes on AM.iPaymentType equals t3.iCashID
                                     where (AM.dtSalesDate) >= (fromDate) && (AM.dtSalesDate) <= (toDate)

                                     select new
                                     {
                                         //iSaleID = AM.iSaleID,
                                         //iSaleFrontEndID = AM.iSaleFrontEndID,
                                         //iSalesInvoiceID = AM.iSalesInvoiceID,

                                         strSalesInvoiceNo = AM.strSalesInvoiceNo,

                                         //iImpExpTransfer = AM.iImpExpTransfer,
                                         //iPaymentType = AM.iPaymentType,

                                         //iCustomerID = AM.iCustomerID,

                                         strBuyerName = AM.strBuyerName,
                                         strSalesDate = AM.strSalesDate,
                                         dmlSellingPrice = AM.dmlSellingPrice,
                                         dmlDeposit = AM.dmlDeposit,
                                         dmlAdvance = AM.dmlAdvance,
                                         dmlBalance = AM.dmlBalance,
                                         iInstallment = AM.iInstallment,
                                         strCashName = t3.strCashName,
                                         strPaperModeName = t2.strPaperModeName

                                     }).OrderBy(a => a.strSalesInvoiceNo).ToList();

            var sumOfSellingPrice = salesReportByDate.Sum(x => x.dmlSellingPrice);

            return new { salesReportByDate, sumOfSellingPrice };

        }


        public bool CheckCustomerIsBlockOrNot()
        {
            bool status = false;

            MCustomer cust = new MCustomer();


            //var checkCustomer = auctionContext.Sales.Where(x=>x.dtCreditLimitDate>DateTime.Now);

            var checkCustomer = (from AM in auctionContext.Sales
                                 join t1 in auctionContext.MCustomers on AM.iCustomerID equals t1.iCustomerID
                                 where (AM.dtCreditLimitDate) < DateTime.Now
                                 //yourDate.Date >= DateTime.Now.Date

                                 select t1
             ).ToList();

            if (checkCustomer != null)
            {
                foreach (var item in checkCustomer)
                {
                    //Save
                    // var customer = auctionContext.MCustomers.Where(x => x.iCustomerID==item.iCustomerID).FirstOrDefault();
                    //customer.IsBlocked = true;
                    //auctionContext.MCustomers.Add(item);

                    item.IsBlocked = true;
                }
            }

            auctionContext.SaveChanges();
            status = true;
            return status;

        }

        public dynamic GetVehiclesData()
        {
            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.Vehicles.ToList().Count,
                    rows = (
                      from vehi in
                          (from AM in dc.Vehicles


                           select new
                           {
                               iVehicleID = AM.iVehicleID,
                               iLotNum = AM.iLotNum,
                               strChassisNum = AM.strChassisNum,
                               iModel = AM.iModel,
                               iYear = AM.iYear,
                               color = AM.strColor,
                               iCustomValInJPY = AM.iCustomValInJPY,
                               iCustomAssesVal = AM.iCustomAssesVal

                           }).ToList()
                      select new
                      {
                          id = vehi.iVehicleID,
                          cell = new string[] {
               Convert.ToString(vehi.iVehicleID),Convert.ToString(vehi.iLotNum),Convert.ToString( vehi.strChassisNum),Convert.ToString(vehi.iModel),Convert.ToString( vehi.iYear),Convert.ToString(vehi.color),Convert.ToString( vehi.iCustomValInJPY),Convert.ToString(vehi.iCustomAssesVal)
                        }
                      }).ToArray()
                };
                return jsonData;
            }
            //return View();
        }

        public dynamic GetSalesData()
        {
            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.Sales.ToList().Count,
                    rows = (
                      from sales in
                          (from AM in dc.Sales
                           join t2 in dc.PaperTypes on AM.iImpExpTransfer equals t2.iPaperModeID
                           join t3 in dc.PaymentTypes on AM.iPaymentType equals t3.iCashID

                           select new
                           {
                               iSaleID = AM.iSaleID,
                               iSaleFrontEndID = AM.iSaleFrontEndID,
                               iSalesInvoiceID = AM.iSalesInvoiceID,

                               strSalesInvoiceNo = AM.strSalesInvoiceNo,

                               iImpExpTransfer = AM.iImpExpTransfer,
                               iPaymentType = AM.iPaymentType,

                               iCustomerID = AM.iCustomerID,

                               strBuyerName = AM.strBuyerName,
                               strSalesDate = AM.strSalesDate,
                               dmlSellingPrice = AM.dmlSellingPrice,
                               dmlDeposit = AM.dmlDeposit,
                               dmlAdvance = AM.dmlAdvance,
                               dmlBalance = AM.dmlBalance,
                               iInstallment = AM.iInstallment,
                               strCashName = t3.strCashName,
                               strPaperModeName = t2.strPaperModeName

                           }).OrderBy(a => a.strSalesInvoiceNo).ToList()
                      select new
                      {
                          id = sales.iSaleID,
                          cell = new string[] {
               Convert.ToString(sales.iSaleID),Convert.ToString(sales.iSaleFrontEndID),Convert.ToString(sales.iSalesInvoiceID),
               Convert.ToString(sales.strSalesInvoiceNo),
               Convert.ToString(sales.iImpExpTransfer),Convert.ToString(sales.iPaymentType),Convert.ToString(sales.iCustomerID)
               ,Convert.ToString( sales.strBuyerName),Convert.ToString(sales.strSalesDate)
               ,Convert.ToString( sales.dmlSellingPrice),Convert.ToString(sales.dmlDeposit),Convert.ToString( sales.dmlAdvance),Convert.ToString(sales.dmlBalance)
                ,Convert.ToString( sales.iInstallment),Convert.ToString(sales.strCashName),Convert.ToString( sales.strPaperModeName)
                        }
                      }).ToArray()
                };
                return jsonData;
            }
            //return View();
        }




        public dynamic GetAllSalesPaymentList()
        {
            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.SalesPayments.ToList().Count,
                    rows = (
                      from salesPayment in
                          (from t2 in dc.Sales
                           join t1 in dc.MCustomers on t2.iCustomerID equals t1.iCustomerID
                          // join t3 in dc.SalesPayments on t2.iCustomerID equals t3.iCustomerID



                           where t2.ysnPaymentStatus==false

                           select new
                           {
                               IsBlocked = t1.IsBlocked,
                               iSaleID = t2.iSaleID,

                               iSalesInvoiceID = t2.iSalesInvoiceID,
                               strSalesInvoiceNo = t2.strSalesInvoiceNo,

                               iCustomerID = t2.iCustomerID,
                               ////strFirstName = t1.strFirstName,
                               ////strLastName = t1.strLastName,


                               //iPaymentReceiptNo = t3.iPaymentReceiptNo,
                               //strPaymentReceiptNo = t3.strPaymentReceiptNo,

                               strSalesDate = t2.strSalesDate,

                               //ysnPaymentStatus = t2.ysnPaymentStatus,
                               dmlSellingPrice = t2.dmlSellingPrice,
                               dmlBalance = t2.dmlBalance,
                               dmlAdvance = t2.dmlAdvance,

                           }).OrderBy(a => a.iSaleID).ToList()
                      select new
                      {
                          id = salesPayment.iSaleID,
                          cell = new string[] {
               Convert.ToString(salesPayment.iSaleID),
               //Convert.ToString(salesPayment.iSaleID),
               Convert.ToString(salesPayment.iCustomerID),Convert.ToString(salesPayment.iSalesInvoiceID),
             Convert.ToString(salesPayment.IsBlocked),

             //Convert.ToString( salesPayment.iPaymentReceiptNo), 
             //    Convert.ToString(salesPayment.strPaymentReceiptNo),

                Convert.ToString( salesPayment.strSalesInvoiceNo), 
                 Convert.ToString(salesPayment.strSalesDate),
                Convert.ToString(salesPayment.dmlSellingPrice),
              
               Convert.ToString(salesPayment.dmlAdvance),
                Convert.ToString(salesPayment.dmlBalance),

                
               //Convert.ToString(salesPayment.strFirstName+" "+salesPayment.strLastName),
             
              
              // Convert.ToString(salesPayment.ysnPaymentStatus),
               
              
                        }
                      }).ToArray()
                };
                return jsonData;
            }
            //return View();
        }


        public bool UpdateOnlySalesPayment(SalesPayment salesPayment)
        {
            bool status = false;

            var eSalesPayment = auctionContext.Sales.Where(a => a.iSaleID == salesPayment.iSaleID).FirstOrDefault();


            if (salesPayment.iSaleID > 0)
            {
                //Adding paid amount into sales table

                if (eSalesPayment != null)
                {
                    var paid = eSalesPayment.dmlAdvance + salesPayment.dmlPaidAmount;
                    eSalesPayment.dmlBalance = salesPayment.dmlPrevBalance;

                    eSalesPayment.dmlAdvance = paid;
                }
            }

            if (salesPayment.ysnPaymentStatus == true && salesPayment!=null)
            {
                //Adding paid amount into sales table

                var customer = auctionContext.MCustomers.Where(a => a.iCustomerID == salesPayment.iCustomerID).FirstOrDefault();

                if (eSalesPayment != null)
                {
                    eSalesPayment.ysnPaymentStatus = true;
                    customer.IsBlocked = false;
                }
            }



            //if (salesPayment.iPaymentID > 0)
            //{
            //    //Edit Existing Record

            //    if (eSalesPayment != null)
            //    {

                   
            //        eSalesPayment.iSaleID = salesPayment.iSaleID;
            //        eSalesPayment.iCustomerID = salesPayment.iCustomerID;
            //        eSalesPayment.strPaymentDate = salesPayment.strPaymentDate;
            //        eSalesPayment.dmlPaidAmount = salesPayment.dmlPaidAmount;
            //        eSalesPayment.dmlPrevBalance = salesPayment.dmlPrevBalance;
            //        eSalesPayment.ysnPaymentStatus = salesPayment.ysnPaymentStatus;
            //        eSalesPayment.dtPaymentDate = salesPayment.dtPaymentDate;
            //        eSalesPayment.iSalesInvoiceID = salesPayment.iSalesInvoiceID;
            //        eSalesPayment.strSalesInvoiceNo = salesPayment.strSalesInvoiceNo;
            //    }
            //}
            auctionContext.SalesPayments.Add(salesPayment);
            auctionContext.SaveChanges();
            status = true;
            return status;

        }
        public dynamic GetCustomerDetails(string prefix)
        {
            var customers = (from AM in auctionContext.MCustomers
                             where AM.strFirstName.StartsWith(prefix)
                             select new
                             {
                                 iCustomerID = AM.iCustomerID,
                                 strFirstName = AM.strFirstName,
                                 strMiddleName = AM.strMiddleName,
                                 strLastName = AM.strLastName,
                                 iPhoneNumber = AM.iPhoneNumber,
                                 strCreditLimit = AM.strCreditLimit,
                                 iCreditCategoryID = AM.iCreditCategoryID,
                                 IsBlocked = AM.IsBlocked,
                                 //Address = AM.Address

                             }).ToList();


            //var chkCreditLimitDate=auctionContext.Sales.Where(a=>a.iCustomerID==customers.Select(x=>x.iCustomerID));

            return customers;
        }

        public dynamic GetInvoice()
        {
            int? invNo = auctionContext.Sales.Max(i => i.iSalesInvoiceID) ?? 0;
            invNo = invNo + 1;
            return invNo;
        }


        public dynamic GetReceiptNo()
        {
            int? receiptNo = auctionContext.SalesPayments.Max(i => i.iPaymentReceiptNo) ?? 0;
            receiptNo = receiptNo + 1;
            return receiptNo;
        }


       

        public dynamic GetSalesFrontEndID()
        {
            int? SalesFrontEndID = auctionContext.Sales.Max(i => i.iSaleFrontEndID) ?? 0;
            SalesFrontEndID = SalesFrontEndID + 1;
            return SalesFrontEndID;
        }

        //public bool Delete(int id)
        //{
        //    bool status = false;
        //    var deleteSale = auctionContext.Sales.Where(a => a.iSaleID == id).FirstOrDefault();
        //    var saleVehicles = auctionContext.SalesVehicles.Where(a => a.PurchaseID == id);
        //    //foreach (var vehicleitems in vehicles)
        //    //{

        //    //}
        //    if (deleteSale != null && saleVehicles != null)
        //    {
        //        auctionContext.TPurchases.Remove(deleteSale);


        //        auctionContext.Vehicles.RemoveRange(saleVehicles);

        //        auctionContext.SaveChanges();
        //        status = true;
        //    }
        //    return status;
        //}

    }
}
