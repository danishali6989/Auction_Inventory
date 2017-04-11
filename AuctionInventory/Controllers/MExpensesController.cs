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



        //[HttpPost]
        //public ActionResult SaveAllExpenses(MExpense[] expense)
        //{

        //    try
        //    {
        //        //if (ModelState.IsValid)
        //        if (ModelState.IsValid)
        //        {
        //            foreach (var item in expense)
        //            {

        //                auctionContext.MExpenses.Add(item);
        //            }

        //            auctionContext.SaveChanges();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("error", "Something Went Wrong");

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

        public ActionResult AllVehicleExpensesList()
        {
            return View();
        }


        public ActionResult SingleVehicleExpensesList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllVehicleExpensesListData()
        {


            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.VehicleExpenses.ToList().Count,
                    rows = (
                      from vehi in
                          (from AM in dc.VehicleExpenses

                           join t2 in dc.MExpenses on AM.iExpenseID equals t2.iExpenseID
                           where AM.iPurchaseInvoiceID != null && AM.iPurchaseInvoiceID != 0


                           select new
                           {
                               iVehicleExpenseID = AM.iVehicleExpenseID,

                               iExpenseID = AM.iExpenseID,
                               iPurchaseInvoiceID = AM.iPurchaseInvoiceID,

                              
                               strExpenseName = t2.strExpenseName,

                               iExpenseAmount = AM.iExpenseAmount,
                               iTotalExpenseAmounrt = AM.iTotalExpenseAmounrt,
                               iSpreadAmountPerVehicle = AM.iTotalExpenseAmounrt

                           }).ToList()
                      select new
                      {
                          id = vehi.iVehicleExpenseID,
                          cell = new string[] {
               Convert.ToString(vehi.iVehicleExpenseID),Convert.ToString(vehi.iExpenseID),Convert.ToString(vehi.iPurchaseInvoiceID),Convert.ToString( vehi.strExpenseName),Convert.ToString( vehi.iExpenseAmount),Convert.ToString(vehi.iTotalExpenseAmounrt)
                        }
                      }).ToArray()
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            //return View();
        }


        [HttpGet]
        public ActionResult GetSingleVehicleExpensesListData()
        {

            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.VehicleExpenses.ToList().Count,
                    rows = (
                      from vehi in
                          (from AM in dc.VehicleExpenses
                           join t2 in dc.MExpenses on AM.iExpenseID equals t2.iExpenseID
                           join t3 in dc.Vehicles on AM.iVehicleID equals t3.iVehicleID

                           where AM.iVehicleID != null && AM.iVehicleID != 0


                           select new
                           {
                               iVehicleExpenseID = AM.iVehicleExpenseID,

                               strRemarks = AM.strRemarks,

                               iVehicleID = AM.iVehicleID,

                               iExpenseID = AM.iExpenseID,
                               strChassisNum = t3.strChassisNum,
                               strExpenseName = t2.strExpenseName,


                               iExpenseAmount = AM.iExpenseAmount,
                               iTotalExpenseAmounrt = AM.iTotalExpenseAmounrt
                               

                           }).ToList()
                      select new
                      {
                          id = vehi.iVehicleExpenseID,
                          cell = new string[] {
               Convert.ToString(vehi.iVehicleExpenseID),Convert.ToString(vehi.strRemarks),Convert.ToString(vehi.iExpenseID),Convert.ToString(vehi.iVehicleID),Convert.ToString(vehi.strChassisNum),Convert.ToString( vehi.strExpenseName),Convert.ToString( vehi.iExpenseAmount),Convert.ToString(vehi.iTotalExpenseAmounrt)
               
                        }
                      }).ToArray()
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            //return View();
        }

        //[HttpGet]
        //public ActionResult GetAllVehicleExpensesListData()
        //{

        //    List<VehicleExpens> test = new List<VehicleExpens>();

        //    var results = test.GroupBy(x => x.iPurchaseInvoiceID).Select(y => new { iPurchaseInvoiceID = y.Key, iExpenseAmount = y.Sum(x => x.iExpenseAmount) });

        //    return Json(results, JsonRequestBehavior.AllowGet);


        //    //var result = from c in auctionContext.VehicleExpenses
        //    //             group c by new
        //    //             {
        //    //                 c.iPurchaseInvoiceID,
        //    //                 //c.iExpenseAmount,
        //    //                 //c.iTotalExpenseAmounrt,
        //    //                 //c.iExpenseID,

        //    //             } into grp
        //    //             select grp.First().iPurchaseInvoiceID;

        //    //return Json(result, JsonRequestBehavior.AllowGet);


        //    //var result = test.GroupBy(g => new { g.iPurchaseInvoiceID })
        //    //            .Select(g => g.First())
        //    //            .ToList();

        //    //return Json(result, JsonRequestBehavior.AllowGet);

        //    //var results = from p in auctionContext.VehicleExpenses
        //    //              group p.iExpenseAmount by p.iPurchaseInvoiceID into g
        //    //              select new { iPurchaseInvoiceID = g.Key, ExpenseAmount = g.ToList() };

        //    //return Json(results, JsonRequestBehavior.AllowGet);



        //    //using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
        //    //{
        //    //    var jsonData = new
        //    //    {
        //    //        total = 1,
        //    //        page = 1,
        //    //        records = dc.VehicleExpenses.ToList().Count,
        //    //        rows = (
        //    //          from vehi in
        //    //              (from AM in dc.VehicleExpenses
        //    //               where AM.iPurchaseInvoiceID != null && AM.iPurchaseInvoiceID != 0
        //    //               group AM.iExpenseAmount by AM.iPurchaseInvoiceID into g

        //    //               select new
        //    //               {
        //    //                   //iVehicleExpenseID = AM.iVehicleExpenseID,
        //    //                   //iPurchaseInvoiceID = AM.iPurchaseInvoiceID,
        //    //                   iPurchaseInvoiceID = g.Key,

        //    //                   //iExpenseID = AM.iExpenseID,
        //    //                   iExpenseAmount = g.ToList(),
        //    //                   //iExpenseAmount = AM.iExpenseAmount,
        //    //                   //iTotalExpenseAmounrt = AM.iTotalExpenseAmounrt,
        //    //                   //iSpreadAmountPerVehicle = AM.iTotalExpenseAmounrt

        //    //               }).ToList()
        //    //          select new
        //    //          {
        //    //              id = vehi.iVehicleExpenseID,
        //    //              cell = new string[] {
        //    //   Convert.ToString(vehi.iVehicleExpenseID),Convert.ToString(vehi.iPurchaseInvoiceID),Convert.ToString( vehi.iExpenseID),Convert.ToString( vehi.iExpenseAmount),Convert.ToString(vehi.iTotalExpenseAmounrt)
        //    //            }
        //    //          }).ToArray()
        //    //    };
        //    //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //    //}
        //    ////return View();
        //}


        [HttpPost]
        public ActionResult GetExpenseByInvoiceID(int id)
        {
            var listExpense = (from AM in auctionContext.VehicleExpenses
                               join t2 in auctionContext.MExpenses on AM.iExpenseID equals t2.iExpenseID
                                where AM.iPurchaseInvoiceID == id
                                
                                select new
                                {
                                    iVehicleExpenseID = AM.iVehicleExpenseID,
                                    iPurchaseInvoiceID = AM.iPurchaseInvoiceID,
                                    iExpenseID = AM.iExpenseID,

                                    strExpenseName = t2.strExpenseName,

                                    iExpenseAmount = AM.iExpenseAmount,
                                    iTotalExpenseAmounrt = AM.iTotalExpenseAmounrt,

                                }).ToList();

            return Json(listExpense, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult GetExpenseByVehicleID(int id)
        {
            var listExpense = (from AM in auctionContext.VehicleExpenses
                               join t2 in auctionContext.MExpenses on AM.iExpenseID equals t2.iExpenseID
                               where AM.iVehicleID == id

                               select new
                               {
                                   iVehicleExpenseID = AM.iVehicleExpenseID,
                                   iVehicleID = AM.iVehicleID,
                                   iExpenseID = AM.iExpenseID,
                                   strExpenseName = t2.strExpenseName,
                                   strRemarks = AM.strRemarks,

                                   iExpenseAmount = AM.iExpenseAmount,
                                   iTotalExpenseAmounrt = AM.iTotalExpenseAmounrt,

                               }).ToList();

            return Json(listExpense, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetAllVehicleExpensesByInvoiceID(int id)
        {
            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.VehicleExpenses.ToList().Count,
                    rows = (
                      from vehi in
                          (from AM in dc.VehicleExpenses
                           where AM.iPurchaseInvoiceID == id

                           select new
                           {
                               iVehicleExpenseID = AM.iVehicleExpenseID,
                               iPurchaseInvoiceID = AM.iPurchaseInvoiceID,
                               iExpenseID = AM.iExpenseID,
                               iExpenseAmount = AM.iExpenseAmount,
                               iTotalExpenseAmounrt = AM.iTotalExpenseAmounrt,
                               //iSpreadAmountPerVehicle = AM.iTotalExpenseAmounrt

                           }).ToList()
                      select new
                      {
                          id = vehi.iVehicleExpenseID,
                          cell = new string[] {
               Convert.ToString(vehi.iVehicleExpenseID),Convert.ToString(vehi.iPurchaseInvoiceID),Convert.ToString( vehi.iExpenseID),Convert.ToString( vehi.iExpenseAmount),Convert.ToString(vehi.iTotalExpenseAmounrt)
                        }
                      }).ToArray()
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            //return View();
        }


        public ActionResult SingleVehicleExpenses()
        {
            return View();
        }




        [HttpPost]
        public JsonResult VehiclesByInvoiceID(int request)
        {
            dynamic listPurchase = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ExpensesServiceClient service = new ExpensesServiceClient();

                    listPurchase = service.VehiclesByInvoiceID(request);

                    //return Json(new { listPurchase }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                listPurchase = null;
                throw e;
            }
            return Json(new { listPurchase }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult AutoCompleteExpense(string prefix)
        {
            dynamic expenses = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ExpensesServiceClient service = new ExpensesServiceClient();

                    expenses = service.AutoCompleteExpense(prefix);

                    //return Json(new { expenses }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                expenses = null;
                throw e;
            }
            return Json(expenses, JsonRequestBehavior.AllowGet);




        }



        [HttpPost]
        public JsonResult VehiclesByVehicleID(int request)
        {
            dynamic VehiclesList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ExpensesServiceClient service = new ExpensesServiceClient();

                    VehiclesList = service.VehiclesByVehicleID(request);

                    //return Json(new { VehiclesList }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                VehiclesList = null;
                throw e;
            }
            return Json(new { VehiclesList }, JsonRequestBehavior.AllowGet);



        }



        [HttpPost]
        public JsonResult AutoCompleteVehicles(string prefix)
        {
            dynamic vehicles = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    ExpensesServiceClient service = new ExpensesServiceClient();

                    vehicles = service.AutoCompleteVehicles(prefix);

                    //return Json(new { vehicles }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehicles = null;
                throw e;
            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);




        }



        [HttpPost]
        // public ActionResult SaveAllVehicleExpense(string expense)
        //public ActionResult SaveAllVehicleExpense(List<AllVehicleExpenseModel> expense)
        public ActionResult SaveVehicleExpense(List<VehicleExpenseModel> expense)
        {
            bool status = false;
            try
            {
                if (expense != null && ModelState.IsValid)
                {
                    ExpensesServiceClient service = new ExpensesServiceClient();
                    status = service.SaveDataVehicleExpense(expense);
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
        }


        //[HttpPost]
        //public ActionResult SaveSingleVehicleExpense(List<VehicleExpenseModel> expense)
        //{
        //    bool status = false;
        //    try
        //    {
        //        if (expense != null && ModelState.IsValid)
        //        {
        //            ExpensesServiceClient service = new ExpensesServiceClient();
        //            status = service.SaveDataSingleVehicleExpense(expense);
        //            //return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("error", "Something Went Wrong");
        //        status = false;
        //        throw e;


        //    }

        //    //return View();
        //    return new JsonResult { Data = new { status = status } };
        //}



    }
}