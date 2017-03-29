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
    public class PapersController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        //
        // GET: /Papers/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaperDetails()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetSalesVehicleByPapertype(int paperTypeID)
        {
            //var vehiclePaperByType = auctionContext.Sales.Where(a => a.iImpExpTransfer == paperTypeID);




            var vehiclePaperByType = (from sale in auctionContext.Sales
                                      join saleVehicle in auctionContext.SalesVehicles on sale.iSaleFrontEndID equals saleVehicle.iSaleFrontEndID
                                      join vehicle in auctionContext.Vehicles on saleVehicle.iVehicleID equals vehicle.iVehicleID
                                      where sale.iImpExpTransfer == paperTypeID
                                      select new
                                      {
                                          iVehicleID = vehicle.iVehicleID,
                                          iLotNum = vehicle.iLotNum,
                                          strChassisNum = vehicle.strChassisNum,
                                          iModel = vehicle.iModel,
                                          iYear = vehicle.iYear,
                                          color = vehicle.strColor,
                                          iCustomValInJPY = vehicle.iCustomValInJPY


                                      }).ToList();

            //return Json(vehiclePaperByType, JsonRequestBehavior.AllowGet);
            return Json(new { vehiclePaperByType }, JsonRequestBehavior.AllowGet);
        }



         [HttpPost]
         public JsonResult EditImportExportVehicle(int vehicleID)
         {
             var importExportVehicleByID = (from vehicle in auctionContext.Vehicles
                                            where vehicle.iVehicleID == vehicleID
                                       select new
                                       {
                                           iVehicleID = vehicle.iVehicleID,                                           
                                           strChassisNum = vehicle.strChassisNum,

                                           iDuty = vehicle.iDuty,
                                           iYear = vehicle.iYear,
                                           color = vehicle.strColor,
                                           iCustomValInJPY = vehicle.iCustomValInJPY


                                       });

             //return Json(vehiclePaperByType, JsonRequestBehavior.AllowGet);
             return Json(new {importExportVehicleByID }, JsonRequestBehavior.AllowGet);
         }

        //[HttpPost]
        //public ActionResult GetSalesVehicleByPapertype(int paperTypeID)
        //{

        //    using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
        //    {
        //        var jsonData = new
        //        {
        //            total = 1,
        //            page = 1,
        //            records = dc.Vehicles.ToList().Count,
        //            rows = (
        //              from vehi in
        //                  (from sale in dc.Sales
        //                   join saleVehicle in dc.SalesVehicles on sale.iSaleFrontEndID equals saleVehicle.iSaleFrontEndID
        //                   join vehicle in dc.Vehicles on saleVehicle.iVehicleID equals vehicle.iVehicleID
        //                   where sale.iImpExpTransfer == paperTypeID
        //                   select new
        //                   {
        //                       iVehicleID = vehicle.iVehicleID,
        //                       iLotNum = vehicle.iLotNum,
        //                       strChassisNum = vehicle.strChassisNum,
        //                       iModel = vehicle.iModel,
        //                       iYear = vehicle.iYear,
        //                       color = vehicle.strColor,
        //                       iCustomValInJPY = vehicle.iCustomValInJPY

        //                   }).ToList()
        //              select new
        //              {
        //                  id = vehi.iVehicleID,
        //                  cell = new string[] {
        //       Convert.ToString(vehi.iVehicleID),Convert.ToString( vehi.iLotNum),Convert.ToString(vehi.strChassisNum),Convert.ToString(vehi.iModel),Convert.ToString( vehi.iYear),Convert.ToString(vehi.color),Convert.ToString( vehi.iCustomValInJPY)
        //                }
        //              }).ToArray()
        //        };
        //        return Json(jsonData, JsonRequestBehavior.AllowGet);
        //    }
        //    //return View();
        //}

    }
}