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

    }
}
