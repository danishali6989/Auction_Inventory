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
        [HttpPost]
        public ActionResult VehiclesByInvoiceID(int request)
        {
            TPurchase purchase = new TPurchase();
            purchase = auctionContext.TPurchases.Where(a => a.iPurchaseInvoiceNo == request).SingleOrDefault();
            var VehiclePurID = purchase.PurchaseID;
            var VehicleByInvoice = auctionContext.Vehicles.Where(a => a.PurchaseID == VehiclePurID);
            return Json(VehicleByInvoice , JsonRequestBehavior.AllowGet);
        }






    }
}