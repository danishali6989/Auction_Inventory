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
            dynamic vehicleList = 0;
            try
            {
                if(ModelState.IsValid)
                {
                    SaleServiceClient service = new SaleServiceClient();
                     vehicleList = service.GetVehiclesData();
                    //return Json(vehicleList, JsonRequestBehavior.AllowGet);
                }
               
            }
            catch(Exception ex)
            {
                
                ModelState.AddModelError("error", "Something Went Wrong");
                vehicleList = null;
                throw ex;
            }
            return Json(vehicleList, JsonRequestBehavior.AllowGet);

            
        }


        [HttpPost]
        public JsonResult GetCustomerDetails(string prefix)
        {
            dynamic customers = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    SaleServiceClient service = new SaleServiceClient();
                     customers = service.GetCustomerDetails(prefix);
                    //return Json(customers, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                customers = null;
                throw ex;
            }
           return Json(customers, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetInvoice()
        {
            dynamic invNo = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    SaleServiceClient service = new SaleServiceClient();
                     invNo = service.GetInvoice();
                    //return Json(invNo, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                invNo = null;
                throw ex;
            }
            return Json(invNo, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetSalesFrontEndID()
        {
            dynamic SalesFrontEndID = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    SaleServiceClient service = new SaleServiceClient();
                     SalesFrontEndID = service.GetSalesFrontEndID();
                    //return Json(SalesFrontEndID, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                SalesFrontEndID = null;
                throw ex;
            }
            return Json(SalesFrontEndID, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Save(SaleModel sale, List<SalesVehicleModel> saleVehicles)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    SaleServiceClient saleServiceClient = new SaleServiceClient();
                    status = saleServiceClient.SaveSalesData(sale, saleVehicles);

                }
                // return RedirectToAction("GetPurchaseList", "TPurchase");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;
            }

            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = new { status = status ,purID=purchase.PurchaseID} };

        }




    }
}