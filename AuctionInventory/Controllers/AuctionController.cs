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
        //
        // GET: /Auction/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuctionList()
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
        public ActionResult Save(List<AuctionListModel> auctionList)
        {
            bool status = false;
            try
            {
                if (auctionList != null && ModelState.IsValid)
                {
                    AuctionServiceClient service = new AuctionServiceClient();
                    status = service.SaveDataAuctionList(auctionList);
                    return RedirectToAction("Index");
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
        }


        [HttpPost]
        public ActionResult GenerateAuctionListPDF(int id)
        {
             AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            //List<AuctionList> auction = new List<AuctionList>();
           var auction = (from t1 in auctionContext.AuctionLists
                          join t2 in auctionContext.Vehicles on t1.iVehicleID equals t2.iVehicleID
                          where t1.iAuctionFrontEndID==id
                        
                          select t2).OrderBy(a => a.iVehicleID).ToList();
           var catNames = auction.Select(i =>
           new { LotNum = i.iLotNum, ChassisNum = i.strChassisNum, iModel = i.iModel, Year = i.iYear, color = i.strColor, JPY = i.iCustomAssesVal }).ToList();

           return Json(catNames, JsonRequestBehavior.AllowGet);
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