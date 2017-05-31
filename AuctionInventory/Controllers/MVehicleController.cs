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
    public class MVehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult GetData(int id)
        //{

        //    using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
        //    {
        //        var jsonData = new
        //        {
        //            total = 1,
        //            page = 1,
        //            records = dc.Vehicles.ToList().Count,
        //            rows = (
        //              from vehi in (from AM in dc.Vehicles
        //                            where AM.PurchaseID == (id)
        //                            join CM in dc.MColors on AM.iColor equals CM.iColorID
        //                            select new
        //                            {
        //                                iVehicleID = AM.iVehicleID,
        //                                iLotNum = AM.iLotNum,
        //                                strChassisNum = AM.strChassisNum,
        //                                iModel = AM.iModel,
        //                                iYear = AM.iYear,
        //                                color = CM.strColorName,
        //                                iCustomValInJPY = AM.iCustomValInJPY,
        //                                iCustomAssesVal = AM.iCustomAssesVal

        //                            }).ToList()
        //              select new
        //              {
        //                  id = vehi.iVehicleID,
        //                  cell = new string[] {
        //       Convert.ToString(vehi.iLotNum),Convert.ToString( vehi.strChassisNum),Convert.ToString(vehi.iModel),Convert.ToString( vehi.iYear),Convert.ToString(vehi.color),Convert.ToString( vehi.iCustomValInJPY),Convert.ToString(vehi.iCustomAssesVal)
        //                }
        //              }).ToArray()
        //        };
        //        return Json(jsonData, JsonRequestBehavior.AllowGet);
        //    }
        //    //return View();
        //}




        private List<Vehicles> ParserGetAllVehicles(List<Vehicle> listVehicle)
        {
            List<Vehicles> listVehicles = new List<Vehicles>();

            foreach (var data in listVehicle)
            {
                if (data != null)
                {
                    Vehicles vehicle = new Vehicles();
                    vehicle.iVehicleID = data.iVehicleID;
                    vehicle.iLotNum = data.iLotNum;
                    vehicle.strGrade = data.strGrade ?? " ";
                    vehicle.strChassisNum = data.strChassisNum ?? " ";
                    vehicle.strCategory = data.strCategory ?? " ";
                    vehicle.strMake = data.strMake ?? " ";
                    vehicle.iModel = data.iModel;
                    vehicle.iYear = data.iYear ?? " ";
                    vehicle.strColor = data.strColor;
                    vehicle.dmlKM = data.dmlKM;
                    vehicle.strOrigin = data.strOrigin ?? " ";
                    vehicle.iDoor = data.iDoor;
                    vehicle.strLocation = data.strLocation ?? " ";
                    vehicle.weight = data.weight ?? " ";
                    vehicle.strHSCode = data.strHSCode ?? " ";
                    vehicle.ATMT = data.ATMT ?? " ";
                    vehicle.iCustomAssesVal = data.iCustomAssesVal;
                    vehicle.dmlDuty = data.dmlDuty;
                    vehicle.iCustomValInJPY = data.iCustomValInJPY;
                    listVehicles.Add(vehicle);
                }
            }
            return listVehicles;
        }

        [HttpPost]
        public ActionResult PassGriddata(List<Vehicles> griddata)
        {

            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleServiceClient vehicleServiceClient = new VehicleServiceClient();
                    status = vehicleServiceClient.GriddataService(griddata);

                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;
            }
            return new JsonResult { Data = new { status = status } };

        }

        #region CRUD
        public ActionResult GetAllVehicle()
        {
            dynamic vehicle = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    VehicleServiceClient vehicleServiceClient = new VehicleServiceClient();
                    vehicle = vehicleServiceClient.GetAllVehicle();
                    //if (vehicle.Count == 0 || vehicle == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                }
            }
            // Please through Exeption Everywhere
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehicle = null;
                throw e;

            }
            return Json(vehicle, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            Vehicles vehicle = new Vehicles();
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleServiceClient vehicleServiceClient = new VehicleServiceClient();
                    vehicle = vehicleServiceClient.GetVehicles(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                vehicle = null;
                throw e;
            }
            return View(vehicle);
        }

        [HttpPost]
        public ActionResult Save(Vehicles vehicle)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleServiceClient vehicleServiceClient = new VehicleServiceClient();
                    status = vehicleServiceClient.SaveData(vehicle);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;
            }
            return View();
            // return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Vehicles vehicle = new Vehicles();
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleServiceClient vehicleServiceClient = new VehicleServiceClient();
                    vehicle = vehicleServiceClient.GetVehicles(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                vehicle = null;
                throw e;
            }
            return View(vehicle);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteVehicle(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleServiceClient vehicleServiceClient = new VehicleServiceClient();
                    status = vehicleServiceClient.Delete(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View("Index");
            // return new JsonResult { Data = new { status = status } };

        }




        #endregion
    }
}