using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.Repositories;
using AuctionInventory.Services;
using AuctionInventory.Models;
using AuctionInventory.Helpers;

namespace AuctionInventory.Controllers
{
    public class SalesController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        //
        // GET: /Sales/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaleVehicle()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetData()
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
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            //return View();
        }


        [HttpPost]
        public JsonResult GetCustomerDetails(string prefix)
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

            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        // [HttpPost]
        //public ActionResult GetInvoice()
        //{
        //    var invNo = auctionContext.TPurchases.Max(i => i.iPurchaseInvoiceNo) + 1;
        //    return Json(invNo);
        //}

	}
}