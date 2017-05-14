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
using AuctionInventory.MyRoleProvider;
namespace AuctionInventory.Controllers
{
    [Permissions(Permissions.View)]
    public class PapersController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        //
        // GET: /Papers/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PapersList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateImportIndex(PaperDetailsImportModel impUpdateModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.UpdateImportData(impUpdateModel);
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
        public ActionResult UpdateExportIndex(PaperDetailsExportModel expUpdateModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.UpdateExportData(expUpdateModel);
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


        [HttpGet]
        public ActionResult GetImportData()
        {
            dynamic importData = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient papersServiceClient = new PapersServiceClient();
                    importData = papersServiceClient.GetImportData();

                    //return Json(new { importData }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                importData = null;
                throw e;
            }
            return Json(importData, JsonRequestBehavior.AllowGet);

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



        [HttpGet]
        public ActionResult GetExportData()
        {
            dynamic exportData = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient papersServiceClient = new PapersServiceClient();
                    exportData = papersServiceClient.GetExportData();

                    //return Json(new { exportData }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                exportData = null;
                throw e;
            }
            return Json(exportData, JsonRequestBehavior.AllowGet);
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
            dynamic vehiclePaperByType = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient papersServiceClient = new PapersServiceClient();
                    vehiclePaperByType = papersServiceClient.GetSalesVehicleByPapertype(paperTypeID);

                    //return Json(new { vehiclePaperByType }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehiclePaperByType = null;
                throw e;
            }
            return Json(new { vehiclePaperByType }, JsonRequestBehavior.AllowGet);
        }


    }
}