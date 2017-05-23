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

        public ActionResult UpdateSaleVehicle(int id)
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
        public ActionResult GetSaleVehicleBySalesFrntID(int id)
        {
            AuctionInventoryEntities dc = new AuctionInventoryEntities();
            //List<Vehicle> listVehicle = (from t1 in auctionContext.Vehicles
            var listVehicle = (
                from t1 in dc.SalesVehicles
                join t2 in dc.Vehicles on t1.iVehicleID equals t2.iVehicleID

                where t1.iSaleFrontEndID == id

               
                               select new
                               {

                                   iSalesVehicleID = t1.iSalesVehicleID,
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


        //  [HttpPost]
        //public ActionResult GetSaleVehicleBySalesFrntID(int id)
        //{
        //    //AuctionInventoryEntities dc = new AuctionInventoryEntities();
        //    //var rows = (from AM in dc.SalesVehicles
        //    //            where (AM.iSaleFrontEndID == id)
        //    //            select new
        //    //            {

        //    //                iVehicleID = AM.iVehicleID
        //    //            }).ToList();
        //    //return Json(rows, JsonRequestBehavior.AllowGet);






        //    using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
        //    {
        //        var jsonData = new
        //        {
        //            total = 1,
        //            page = 1,
        //            records = dc.Vehicles.ToList().Count,
        //            rows = (
        //              from vehi in
        //                  (from t1 in dc.SalesVehicles
        //                   join t2 in dc.Vehicles on t1.iVehicleID equals t2.iVehicleID 
        //                   where t1.iSaleFrontEndID == id

        //                   select new
        //                   {
        //                       iVehicleID = t2.iVehicleID,
        //                       iLotNum = t2.iLotNum,
        //                       strChassisNum = t2.strChassisNum,
        //                       iModel = t2.iModel,
        //                       iYear = t2.iYear,
        //                       color = t2.strColor,
        //                       iCustomValInJPY = t2.iCustomValInJPY
        //                       //,iCustomAssesVal = t2.iCustomAssesVal

        //                   }).ToList()
        //              select new
        //              {
        //                  id = vehi.iVehicleID,
        //                  cell = new string[] {
        //       Convert.ToString(vehi.iVehicleID),Convert.ToString(vehi.iLotNum),Convert.ToString( vehi.strChassisNum),Convert.ToString(vehi.iModel),Convert.ToString( vehi.iYear),Convert.ToString(vehi.color),Convert.ToString( vehi.iCustomValInJPY)
        //                }
        //              }).ToArray()
        //        };
        //        return Json(jsonData, JsonRequestBehavior.AllowGet);
        //    }
        //    //return View();


        //}


        [HttpGet]
        public ActionResult GetSalesData()
        {
            dynamic salesList = 0;
            try
            {
                if(ModelState.IsValid)
                {
                    SaleServiceClient service = new SaleServiceClient();
                    salesList = service.GetSalesData();
                    //return Json(vehicleList, JsonRequestBehavior.AllowGet);
                }
               
            }
            catch(Exception ex)
            {
                
                ModelState.AddModelError("error", "Something Went Wrong");
                salesList = null;
                throw ex;
            }
            return Json(salesList, JsonRequestBehavior.AllowGet);

            
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
        public JsonResult GetCustomerDetailsBYCustomerID(int id)
        {
              AuctionInventoryEntities dc = new AuctionInventoryEntities();

              var customer = (
                from t1 in dc.MCustomers                
                where t1.iCustomerID == id

               
                               select new
                               {

                                   //iCustomerID = t1.iCustomerID,
                                   //strFirstName = t1.strFirstName,
                                   //strMiddleName = t1.strMiddleName,
                                   //strLastName = t1.strLastName,
                                   iPhoneNumber = t1.iPhoneNumber,
                                   strCreditLimit = t1.strCreditLimit,
                                   //Address = t1.Address


                               }).ToList();


              return Json(customer, JsonRequestBehavior.AllowGet);
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
        public ActionResult Save(SaleModel sale, List<SalesVehicleModel> saleVehicles, SalesPaymentModel salesPaymentModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    SaleServiceClient saleServiceClient = new SaleServiceClient();
                    status = saleServiceClient.SaveSalesData(sale, saleVehicles, salesPaymentModel);

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

        public ActionResult SalesReport()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllSalesReportByDate(DateTime fromDate, DateTime toDate)
        {
            dynamic salesReportByDate = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    SaleServiceClient saleServiceClient = new SaleServiceClient();
                    salesReportByDate = saleServiceClient.GetAllSalesReportByDate(fromDate, toDate);

                   
                    //if (purchase.Count == 0 || purchase == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                salesReportByDate = null;
                throw e;
            }

            //return Json(purchaseReportByDate, JsonRequestBehavior.AllowGet);
            return Json(new { salesReportByDate }, JsonRequestBehavior.AllowGet);

        }

        //[HttpPost]       
        //public ActionResult Delete(int id)
        //{
        //    bool status = false;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            SaleServiceClient saleServiceClient = new SaleServiceClient();
        //            status = saleServiceClient.Delete(id);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("error", "Something Went Wrong!");
        //        status = false;
        //        throw e;
        //    }

        //    return new JsonResult { Data = new { status = status } };

        //}


        [HttpGet]
        public JsonResult CheckCustomerIsBlockOrNot()
        {
            bool status = false;

            try
            {
                if (ModelState.IsValid)
                {
                    SaleServiceClient saleServiceClient = new SaleServiceClient();
                    status = saleServiceClient.CheckCustomerIsBlockOrNot();


                    //if (purchase.Count == 0 || purchase == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                status = false;
                throw e;
            }

            //return Json(purchaseReportByDate, JsonRequestBehavior.AllowGet);
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);

        }

    }
}