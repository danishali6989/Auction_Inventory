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
    public class AuctionController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        //
        // GET: /Auction/
        public ActionResult Index()
        {
            return View();
        }

     
        [HttpGet]
        public ActionResult GetData()
        {
            List<Vehicles> listVehicles = new List<Vehicles>();
            try
            {
                if (ModelState.IsValid)
                {
                    AuctionServiceClient service = new AuctionServiceClient();
                    listVehicles = service.GetAuctionListData();
                   
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Wrong");
                throw ex;
            }
            return Json(new { data = listVehicles }, JsonRequestBehavior.AllowGet);
           
        }

        [HttpPost]
        public ActionResult Save(List<AuctionListModel> auctionList)
        {
            bool status = false;
            try
            {
                if (auctionList != null && ModelState.IsValid)
                {
                    AuctionServiceClient service = new AuctionServiceClient();
                    status = service.SaveDataAuctionList(auctionList);
                    //return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;


            }

            //return View();
            return new JsonResult { Data = new { status = status } };
            //return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GenerateAuctionListPDF(int id)
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            AuctionServiceClient service = new AuctionServiceClient();
            vehicles=service.GetVehiclesForPDF(id);          
        
           return Json(vehicles, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult GetAuctionFrontEndID()
        {
            var AuctionID = auctionContext.AuctionLists.Max(i => i.iAuctionFrontEndID) + 1;
            return Json(AuctionID);
        }

        //[HttpPost]
        //public JsonResult GetDataByVehicleID(int id)
        //{

        //    AuctionInventoryEntities dc = new AuctionInventoryEntities();

        //    var SingleVehicle = (from t1 in dc.Vehicles
        //                                  //join t2 in dc.MColors on t1.iColor equals t2.iColorID
        //                                  where t1.iVehicleID == id
        //                                  select new Vehicles
        //                                  {
        //                                      iVehicleID = t1.iVehicleID,
        //                                      iLotNum = t1.iLotNum,
        //                                      strChassisNum = t1.strChassisNum,
        //                                      //strMake = t1.strMake,
        //                                      iModel = t1.iModel,
        //                                      //strCategory = t1.strCategory,
        //                                      iYear = t1.iYear,
        //                                      strColor = t1.strColor,
        //                                     // strOrigin = t1.strOrigin,
        //                                      //strLocation = t1.strLocation,
        //                                      iCustomAssesVal = t1.iCustomAssesVal,
        //                                      //iDuty = t1.iDuty,
        //                                      iCustomValInJPY = t1.iCustomValInJPY
        //                                      //,strGrade =t1.strGrade,                                             


        //                                      //dmlKM = t1.dmlKM,

        //                                      //iDoor = t1.iDoor,

        //                                      //weight = t1.weight,
        //                                      //strHSCode = t1.strHSCode,
        //                                      //ATMT = t1.ATMT,



        //                                  });

          
        //    return Json(new { SingleVehicle }, JsonRequestBehavior.AllowGet);

        //}


	}
}