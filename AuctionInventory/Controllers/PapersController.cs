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



        [HttpPost]
        public ActionResult SaveImport(List<PaperDetailsImportModel> importModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.SaveImportData(importModel);
                    //return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            //return RedirectToAction("Index");
            //return View();
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult SaveExport(List<PaperDetailsExportModel> exportModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.SaveExportData(exportModel);
                    //return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            //return RedirectToAction("Index");
            //return View();
            return new JsonResult { Data = new { status = status } };
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

      

    }
}