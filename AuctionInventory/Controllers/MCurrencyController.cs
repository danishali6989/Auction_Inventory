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
    public class MCurrencyController : Controller
    {
        // GET: MCurrency
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        public ActionResult GetAllCurrency()
        {
            List<Currency> currency = new List<Currency>();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CurrencyServiceClient currencyServiceClient = new Services.CurrencyServiceClient();
                    currency = currencyServiceClient.GetAllCurrency();
                    if (currency.Count == 0 || currency == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                    
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                currency = null;
                throw e;

            }
            return Json(new { data = currency }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
           Currency currency = new Currency();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CurrencyServiceClient currencyServiceClient = new Services.CurrencyServiceClient();
                    
                    currency = currencyServiceClient.GetCurrency(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                currency = null;
                throw e;
            }
            return View(currency);
        }

        [HttpPost]
        public ActionResult Save(Currency currency)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CurrencyServiceClient currencyServiceClient = new Services.CurrencyServiceClient();
                    
                    status = currencyServiceClient.SaveData(currency);
                    return RedirectToAction("Index");
                }
            }
             catch(Exception e)
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
            Currency currency = new Currency();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CurrencyServiceClient currencyServiceClient = new Services.CurrencyServiceClient();
                    
                    currency = currencyServiceClient.GetCurrency(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                currency = null;
                throw e;
            }
            return View(currency);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCurrency(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CurrencyServiceClient currencyServiceClient = new Services.CurrencyServiceClient();
                   
                    status = currencyServiceClient.Delete(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View("Index");
            //return new JsonResult { Data = new { status = status } };

        }

        #endregion
    }
}