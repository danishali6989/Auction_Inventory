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
    public class MExpensesController : Controller
    {
        AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        // GET: MExpenses
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        public ActionResult GetAllExpense()
        {
            List<Expenses> expense = new List<Expenses>();
            try
            {
                if (ModelState.IsValid)
                {
                    ExpensesServiceClient expensesServiceClient = new ExpensesServiceClient();
                    expense = expensesServiceClient.GetAllExpenses();
                    if (expense.Count == 0 || expense == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                expense = null;
                throw e;

            }
            return Json(new { data = expense }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            Expenses expense = new Expenses();
            try
            {
                if (ModelState.IsValid)
                {
                    ExpensesServiceClient service = new ExpensesServiceClient();
                    expense = service.GetExpenses(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                expense = null;
                throw e;
            }
            return View(expense);
        }

        [HttpPost]
        public ActionResult Save(Expenses expense)
        {
            bool status = false;
            try
            {
                //if (ModelState.IsValid)
                if (ModelState.IsValid)
                {
                    ExpensesServiceClient service = new ExpensesServiceClient();
                    status = service.SaveData(expense);
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



        [HttpPost]
        public ActionResult SaveAllExpenses(MExpense[] expense)
        { 
            
            try
            {
                //if (ModelState.IsValid)
                if (ModelState.IsValid)
                {
                    foreach (var item in expense)
                    {
                        
                       auctionContext.MExpenses.Add(item); 
                    }

                    auctionContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                
                throw e;


            }

            return View();
            // return new JsonResult { Data = new { status = status } };
        }

        //[HttpPost]
        //public ActionResult Save(Expenses expense)
        //{
        //    bool status = false;
        //    try
        //    {
        //        if (expense!=null && ModelState.IsValid)
        //        {
        //            ExpensesServiceClient service = new ExpensesServiceClient();
        //            status = service.SaveData(expense);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("error", "Something Went Wrong");
        //        status = false;
        //        throw e;


        //    }

        //    return View();
        //    // return new JsonResult { Data = new { status = status } };
        //}


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Expenses expense = new Expenses();
            try
            {
                if (ModelState.IsValid)
                {

                    ExpensesServiceClient service = new ExpensesServiceClient();
                    expense = service.GetExpenses(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                expense = null;
                throw e;
            }
            return View(expense);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteExpense(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {

                    ExpensesServiceClient service = new ExpensesServiceClient();
                    status = service.Delete(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View("Index");
            //return new JsonResult { Data = new { status = status } };

        }

        #endregion


        public ActionResult AllVehicleExpenses()
        {
            return View();
        }


        public ActionResult SingleVehicleExpenses()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult VehiclesByInvoiceID(int request)
        //{
        //    TPurchase purchase = new TPurchase();
        //    purchase = auctionContext.TPurchases.Where(a => a.iPurchaseInvoiceNo == request).SingleOrDefault();
        //    //var VehiclePurID = purchase.PurchaseID;
        //    //var VehicleByInvoice = auctionContext.Vehicles.Where(a => a.PurchaseID == VehiclePurID).ToList();
        //    //return Json(VehicleByInvoice, JsonRequestBehavior.AllowGet);
        //    var NoOfUnits = purchase.Vehicles.Count;
        //    return Json(new { purchase, NoOfUnits }, JsonRequestBehavior.AllowGet);
        //}





        //[HttpPost]
        //public ActionResult VehiclesByInvoiceID(int request)
        //{

        //    using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
        //    {
        //        var jsonData = new
        //        {
        //            //total = 1,
        //            //page = 1,
        //            //records = dc.Vehicles.ToList().Count,
        //            rows = (
        //              from expenseInvoice in
        //                  (from AM in dc.TPurchases
        //                   where AM.iPurchaseInvoiceNo == (request)

        //                   select new
        //                   {
        //                       iPurchaseInvoiceNo = AM.iPurchaseInvoiceNo,
        //                       strPurchaseInvoiceDate = AM.strPurchaseInvoiceDate,
        //                       NoOfUnits = AM.Vehicles.Count,
        //                       strMasterDecNo = AM.strMasterDecNo,
        //                       strBLNo = AM.strBLNo

        //                   }).ToList()
        //              select new
        //              {
        //                  id = expenseInvoice.iPurchaseInvoiceNo,
        //                  cell = new string[] {
        //       Convert.ToString(expenseInvoice.iPurchaseInvoiceNo),Convert.ToString( expenseInvoice.strPurchaseInvoiceDate),Convert.ToString(expenseInvoice.NoOfUnits),Convert.ToString( expenseInvoice.strMasterDecNo),Convert.ToString(expenseInvoice.strBLNo)
        //                }
        //              }).ToArray()
        //        };
        //        return Json(jsonData, JsonRequestBehavior.AllowGet);
        //    }
        //    //return View();
        //}




        [HttpPost]
        public JsonResult VehiclesByInvoiceID(int request)
        {
           
            AuctionInventoryEntities dc = new AuctionInventoryEntities();

            var listPurchase = (from t1 in dc.TPurchases
                                //join t2 in dc.MColors on t1.iColor equals t2.iColorID
                                where t1.iPurchaseInvoiceNo == request
                                select new
                                {
                                    iPurchaseInvoiceNo = t1.iPurchaseInvoiceNo,
                                    strPurchaseInvoiceDate = t1.strPurchaseInvoiceDate,
                                    NoOfUnits = t1.Vehicles.Count,
                                    strMasterDecNo = t1.strMasterDecNo,
                                    strBLNo = t1.strBLNo
                                    //,strCategory = t1.strCategory

                                });


            return Json(new { listPurchase }, JsonRequestBehavior.AllowGet);
        }

             [HttpPost]
        public JsonResult AutoCompleteExpense(string prefix)
        {
            var expenses = (from expense in auctionContext.MExpenses
                            where expense.strExpenseName.StartsWith(prefix)
                             //||
                             //supplier.strEmailID.StartsWith(prefix)||
                             //supplier.strLastName.StartsWith(prefix)
                             select new
                             {
                                 strExpenseName = expense.strExpenseName,                                 
                                 iExpenseID = expense.iExpenseID
                             }).ToList();

            return Json(expenses, JsonRequestBehavior.AllowGet);
        }



             [HttpPost]
             public JsonResult VehiclesByVehicleID(int request)
             {
                
                 AuctionInventoryEntities dc = new AuctionInventoryEntities();

                 var VehiclesList = (from t1 in dc.Vehicles
                                     //join t2 in dc.MColors on t1.iColor equals t2.iColorID
                                     where t1.iVehicleID == request
                                     select new
                                     {
                                         iLotNum = t1.iLotNum,
                                         strChassisNum = t1.strChassisNum,
                                         iModel = t1.iModel,
                                         iYear = t1.iYear,
                                         strColor = t1.strColor,
                                         iCustomValInJPY = t1.iCustomValInJPY


                                     });


                 return Json(new { VehiclesList }, JsonRequestBehavior.AllowGet);
             }



             [HttpPost]
             public JsonResult AutoCompleteVehicles(string prefix)
             {
                 var vehicles = (from vehicle in auctionContext.Vehicles
                                 where vehicle.strChassisNum.StartsWith(prefix)
                                 //||
                                 //supplier.strEmailID.StartsWith(prefix)||
                                 //supplier.strLastName.StartsWith(prefix)
                                 select new
                                 {
                                     strChassisNum = vehicle.strChassisNum,
                                     iVehicleID = vehicle.iVehicleID
                                 }).ToList();

                 return Json(vehicles, JsonRequestBehavior.AllowGet);
             }


    }
}