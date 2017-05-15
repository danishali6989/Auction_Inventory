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
    public class AuctionController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
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
        public ActionResult GetAuctionListData()
        {
            dynamic auctionList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    AuctionServiceClient service = new AuctionServiceClient();

                    auctionList = service.GetAuctionListData();


                    //var jsonData = new
                    //{
                    //    total = 1,
                    //    page = 1,
                    //    // records = dc.Vehicles.ToList().Count,
                    //    rows = test
                    //};



                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Wrong");
                auctionList = null;
                throw ex;
            }
            return Json(auctionList, JsonRequestBehavior.AllowGet);
            //return Json(null, JsonRequestBehavior.AllowGet);
            // return Json(listVehicles, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult GetGetAuctionListDataBYAuctionFrntID(int id)
        {
            AuctionInventoryEntities dc = new AuctionInventoryEntities();
            //List<Vehicle> listVehicle = (from t1 in auctionContext.Vehicles
            var listVehicle = (
                from t1 in dc.AuctionLists
                join t2 in dc.Vehicles on t1.iVehicleID equals t2.iVehicleID

                where t1.iAuctionFrontEndID == id


                select new
                {

                    iAuctionFrontEndID = t1.iAuctionFrontEndID,
                    iVehicleID = t2.iVehicleID,
                    iLotNum = t2.iLotNum,
                    strChassisNum = t2.strChassisNum,
                    //strMake = t2.strMake,
                    iModel = t2.iModel,
                    //strCategory = t2.strCategory,
                    iYear = t2.iYear,
                    strColor = t2.strColor,
                    // strOrigin = t2.strOrigin,
                    //strLocation = t2.strLocation,
                    //iCustomAssesVal = t2.iCustomAssesVal,
                    //iDuty = t2.iDuty,
                    iCustomValInJPY = t2.iCustomValInJPY
                    //,strGrade =t1.strGrade,                                             


                    //dmlKM = t1.dmlKM,

                    //iDoor = t1.iDoor,

                    //weight = t1.weight,
                    //strHSCode = t1.strHSCode,
                    //ATMT = t1.ATMT,



                }).ToList();


            return Json(new { listVehicle }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult GetData()
        {
            dynamic listVehicles = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    AuctionServiceClient service = new AuctionServiceClient();

                    listVehicles = service.GetAuctionListVehicles();


                    //var jsonData = new
                    //{
                    //    total = 1,
                    //    page = 1,
                    //    // records = dc.Vehicles.ToList().Count,
                    //    rows = test
                    //};



                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Wrong");
                listVehicles = null;
                throw ex;
            }
            return Json(listVehicles, JsonRequestBehavior.AllowGet);
            //return Json(null, JsonRequestBehavior.AllowGet);
            // return Json(listVehicles, JsonRequestBehavior.AllowGet);

        }


        //[HttpGet]
        //public ActionResult GetData()
        //{

        //    AuctionInventoryEntities dc = new AuctionInventoryEntities();

        //    List<Vehicles> listVehicle = (from t1 in dc.Vehicles


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
        //                                      //strOrigin = t1.strOrigin,
        //                                      //strLocation = t1.strLocation,
        //                                      //iCustomAssesVal = t1.iCustomAssesVal,
        //                                      //iDuty = t1.iDuty,
        //                                      iCustomValInJPY = t1.iCustomValInJPY
        //                                      //,strGrade =t1.strGrade,                                             


        //                                      //dmlKM = t1.dmlKM,

        //                                      //iDoor = t1.iDoor,

        //                                      //weight = t1.weight,
        //                                      //strHSCode = t1.strHSCode,
        //                                      //ATMT = t1.ATMT,



        //                                  }).ToList();



        //    return Json(new { listVehicle}, JsonRequestBehavior.AllowGet);

        //}


        //[HttpGet]
        //public ActionResult GetData()
        //{

        //    using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
        //    {





        //        var jsonData = new
        //        {
        //            total = 1,
        //            page = 1,
        //            records = dc.Vehicles.ToList().Count,
        //            rows = test
        //        };


        //       // var jsonData = new
        //       // {
        //       //     total = 1,
        //       //     page = 1,
        //       //     records = dc.Vehicles.ToList().Count,
        //       //     rows = (
        //       //       from vehi in
        //       //           (from AM in dc.Vehicles


        //       //            select new
        //       //            {
        //       //                iVehicleID = AM.iVehicleID,
        //       //                iLotNum = AM.iLotNum,
        //       //                strChassisNum = AM.strChassisNum,
        //       //                iModel = AM.iModel,
        //       //                iYear = AM.iYear,
        //       //                color = AM.strColor,
        //       //                iCustomValInJPY = AM.iCustomValInJPY,
        //       //                iCustomAssesVal = AM.iCustomAssesVal

        //       //            }).ToList()
        //       //       select new
        //       //       {
        //       //           id = vehi.iVehicleID,
        //       //           cell = new string[] {
        //       //Convert.ToString(vehi.iVehicleID),Convert.ToString(vehi.iLotNum),Convert.ToString( vehi.strChassisNum),Convert.ToString(vehi.iModel),Convert.ToString( vehi.iYear),Convert.ToString(vehi.color),Convert.ToString( vehi.iCustomValInJPY),Convert.ToString(vehi.iCustomAssesVal)
        //       //         }
        //       //       }).ToArray()
        //       // };





        //        return Json(jsonData, JsonRequestBehavior.AllowGet);
        //    }
        //    //return View();
        //}



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
            //List<Vehicles> vehicles = new List<Vehicles>();

            dynamic vehicles = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    AuctionServiceClient service = new AuctionServiceClient();
                    vehicles = service.GetVehiclesForPDF(id);


                }
            }
            // Please through Exeption Everywhere
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehicles = null;
                throw e;
            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public ActionResult GetAuctionFrontEndID()
        {
            dynamic AuctionID = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    AuctionServiceClient service = new AuctionServiceClient();
                    AuctionID = service.AuctionFrontEndID();
                    //return Json(AuctionID, JsonRequestBehavior.AllowGet);
                }
            }
            // Please through Exeption Everywhere
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                AuctionID = null;
                throw e;
            }
            return Json(AuctionID, JsonRequestBehavior.AllowGet);



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