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
using OfficeOpenXml;

namespace AuctionInventory.Controllers
{
    public class TPurchaseController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        // GET: TPurchase
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PurchaseReport()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GenerateCustomPDF()
        {
            dynamic vehicle = 0;
            try
            {
                if (ModelState.IsValid)
                {

                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    vehicle = purchaseServiceClient.GenerateCustomPDF();
                   //return Json(vehicle, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                vehicle = null;
                throw e;
            }

            return Json(vehicle, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GenerateInvoicePDF()
        {
            dynamic vehicle = 0;
            try
            {
                if (ModelState.IsValid)
                {

                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                     vehicle = purchaseServiceClient.GenerateInvoicePDF();
                    //return Json(vehicle, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                vehicle = null;
                throw e;
            }
            return Json(vehicle, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetData(int id)
        {
            dynamic listVehicle = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    listVehicle = purchaseServiceClient.GetDataVehiclelist(id);

                    //return Json(new { vehicle }, JsonRequestBehavior.AllowGet);
                }
            }
            // Please through Exeption Everywhere
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                listVehicle = null;
                throw e;
            }
            return Json(listVehicle, JsonRequestBehavior.AllowGet);
            //return vehicle;
        }


        [HttpGet]
        public ActionResult UpdateIndex(int id)
        {
            Purchase purchase = new Purchase();
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    purchase = purchaseServiceClient.GetPurchase(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                purchase = null;
                throw e;
            }
            return View(purchase);
        }


        //[HttpPost]
        //public ActionResult UpdateIndex(Purchase purchase, List<Vehicles> griddata)
        //{
        //    bool status = false;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
        //            status = purchaseServiceClient.SaveData(purchase, griddata);
        //            return RedirectToAction("GetPurchaseList", "TPurchase");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("error", "Something Went Wrong");
        //        status = false;
        //        throw e;
        //    }

        //    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        //    //return new JsonResult { Data = new { status = status ,purID=purchase.PurchaseID} };

        //}

        public ActionResult Upload()
        {
            return View();
        }

        #region CRUD
        public ActionResult GetAllPurchase()
        {
            dynamic purchase = 0;
          
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    purchase = purchaseServiceClient.GetAllPurchase();
                    //if (purchase.Count == 0 || purchase == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                purchase = null;
                throw e;
            }
            return Json(purchase, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetAllPurchaseReport()
        {
            dynamic purchase = 0;
          
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    purchase = purchaseServiceClient.GetAllPurchaseReport();
                    //if (purchase.Count == 0 || purchase == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                purchase = null;
                throw e;
            }
            return Json(purchase, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetAllPurchaseReportByDate(string fromDate, string toDate)
        {
            dynamic purchase = 0;
            
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    purchase = purchaseServiceClient.GetAllPurchaseReportByDate(fromDate, toDate);
                    //if (purchase.Count == 0 || purchase == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                purchase = null;
                throw e;
            }
            return Json(purchase, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult Save(int id)
        {
            Purchase purchase = new Purchase();
            try
            {
                if (ModelState.IsValid)
                {

                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    purchase = purchaseServiceClient.GetPurchase(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                purchase = null;
                throw e;
            }
            return View(purchase);
        }

        [HttpPost]
        public ActionResult Save(Purchase purchase, List<Vehicles> griddata)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    status = purchaseServiceClient.SaveData(purchase, griddata);

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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Purchase purchase = new Purchase();
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    purchase = purchaseServiceClient.GetPurchase(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                purchase = null;
                throw e;
            }
            return View(purchase);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePurchase(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();
                    status = purchaseServiceClient.Delete(id);
                    return RedirectToAction("GetPurchaseList");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }

            return new JsonResult { Data = new { status = status } };

        }
        //[HttpPost]
        //public ActionResult GetInvoice()
        //{
        //    bool status = false;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();

        //            status = purchaseServiceClient.GetInvoiceID();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("error", "Something Went Wrong");
        //        status = false;
        //        throw e;

        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}


        //[HttpPost]
        //public JsonResult AutoComplete(string prefix)
        //{

        //    bool status = false;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            PurchaseServiceClient purchaseServiceClient = new PurchaseServiceClient();

        //            status = purchaseServiceClient.AutoCompleteService(prefix);

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("error", "Something Went Wrong");
        //        status = false;
        //        throw e;

        //    }
        //    return new JsonResult { Data = new { status = status } };

        //}



        //[HttpPost]
        //public ActionResult Upload(FormCollection formCollection)
        //{
        //    if (Request != null)
        //    {
        //        HttpPostedFileBase file = Request.Files["UploadedFile"];
        //        if ((file != null) && !string.IsNullOrEmpty(file.FileName))
        //        {
        //            string fileName = file.FileName;
        //            string fileContentType = file.ContentType;
        //            byte[] fileBytes = new byte[file.ContentLength];
        //            var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

        //            using (var package = new ExcelPackage(file.InputStream))
        //            {
        //                var currentSheet = package.Workbook.Worksheets;
        //                var workSheet = currentSheet.First();
        //                var noOfCol = workSheet.Dimension.End.Column;
        //                var noOfRow = workSheet.Dimension.End.Row;
        //                List<Vehicles> listVehicle = new List<Vehicles>();
        //                for (int i = 1; i < noOfRow; i++)
        //                {
        //                    Vehicles vehicle = new Vehicles();
        //                    int lotNumber = 0;
        //                    int.TryParse(workSheet.Cells[i, 1].Value.ToString(), out lotNumber);
        //                    vehicle.iLotNum = lotNumber;
        //                    vehicle.strChassisNum = workSheet.Cells[i, 2].Value.ToString();
        //                    vehicle.iModel = workSheet.Cells[i, 3].Value.ToString();
        //                    vehicle.iYear = workSheet.Cells[i, 4].Value.ToString();
        //                    vehicle.strColor = workSheet.Cells[i, 5].Value.ToString();
        //                    decimal customValueInPY = 0;
        //                    decimal.TryParse(workSheet.Cells[i, 6].Value.ToString(), out customValueInPY);
        //                    vehicle.iCustomValInJPY = customValueInPY;

        //                    listVehicle.Add(vehicle);
        //                }

        //                var sumOfJPY = listVehicle.Sum(x => x.iCustomValInJPY);

        //                return View();
        //                // return View("Index", listVehicle);

        //                return Json(new { listVehicle, sumOfJPY }, JsonRequestBehavior.AllowGet);
        //            }

        //        }
        //    }
        //    return Json(new { result = string.Empty, sumOfJPY = 0 }, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int j = 0; j < files.Count; j++)
                    {

                        HttpPostedFileBase file = files[j];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            List<Vehicles> listVehicle = new List<Vehicles>();
                            for (int i = 2; i <= noOfRow; i++)
                            {
                                Vehicles vehicle = new Vehicles();
                                int lotNumber = 0;
                                int.TryParse(workSheet.Cells[i, 1].Value.ToString(), out lotNumber);
                                vehicle.iLotNum = lotNumber;
                                vehicle.strChassisNum = workSheet.Cells[i, 2].Value.ToString();
                                vehicle.iModel = workSheet.Cells[i, 3].Value.ToString();
                                vehicle.iYear = workSheet.Cells[i, 4].Value.ToString();
                                vehicle.strColor = workSheet.Cells[i, 5].Value.ToString();
                                decimal customValueInPY = 0;
                                decimal.TryParse(workSheet.Cells[i, 6].Value.ToString(), out customValueInPY);
                                vehicle.iCustomValInJPY = customValueInPY;

                                listVehicle.Add(vehicle);
                            }
                            decimal twe = 1;
                            decimal.TryParse("", out twe);

                            var sumOfJPY = listVehicle.Sum(x => x.iCustomValInJPY);

                            //var sumOfAED = listVehicle.Sum(x => x.iCustomValInJPY) * twe;

                            var sumOfAED = listVehicle.Sum(x => x.iCustomValInJPY) * Convert.ToDecimal(0.033);

                            return Json(new { listVehicle, sumOfJPY, sumOfAED }, JsonRequestBehavior.AllowGet);

                        }

                    }
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
            return Json("No files selected.");
        }


        public ActionResult GetPurchaseList()
        {
            return View();

        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    PurchaseServiceClient service=new PurchaseServiceClient();
                    var suppliers =service.AutoCompleteService(prefix);
                    return Json(suppliers, JsonRequestBehavior.AllowGet);

                }
            }
            
            catch(Exception ex)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                throw ex;
            }
            
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetInvoice()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PurchaseServiceClient service = new PurchaseServiceClient();
                    var invNo= service.GetInvoiceID();
                    return Json(invNo, JsonRequestBehavior.AllowGet);

                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                throw ex;
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        #endregion

    }
}