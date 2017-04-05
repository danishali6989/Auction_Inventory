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

        public bool SaveRepository(Sale sale, List<SalesVehicle> saleVehicles)
        {
            bool status = false;
            //var pur = auctionContext.TPurchases.Where(a => a.PurchaseID == sale.PurchaseID).FirstOrDefault();
            int? invNo = auctionContext.Sales.Max(i => i.iSalesInvoiceID) ?? 0;
            invNo = invNo + 1;
            int? salesFrontEndID = auctionContext.Sales.Max(i => i.iSaleFrontEndID) ?? 0;
            salesFrontEndID = salesFrontEndID + 1;
            //Save
            sale.iSalesInvoiceID = invNo;
            sale.iSaleFrontEndID = salesFrontEndID;
            auctionContext.Sales.Add(sale);

            foreach (var items in saleVehicles)
            {
                //Save
                items.iSaleFrontEndID = salesFrontEndID;
                auctionContext.SalesVehicles.Add(items);
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
                                 //Address = AM.Address

                             }).ToList();

            return customers;
        }
        
        public dynamic GetInvoice()
        {
            int? invNo = auctionContext.Sales.Max(i => i.iSalesInvoiceID) ?? 0;
            invNo = invNo + 1;
            return invNo;
        }
        public dynamic GetSalesFrontEndID()
        {
            int? SalesFrontEndID = auctionContext.Sales.Max(i => i.iSaleFrontEndID) ?? 0;
            SalesFrontEndID = SalesFrontEndID + 1;
            return SalesFrontEndID;
        }
    }
}
