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
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace AuctionInventory.Controllers
{
    [Permissions(Permissions.View)]
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
            dynamic currency = 0;
           
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CurrencyServiceClient currencyServiceClient = new Services.CurrencyServiceClient();
                    currency = currencyServiceClient.GetAllCurrency();
                    //if (currency.Count == 0 || currency == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                    
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                currency = null;
                throw e;

            }
            return Json(currency, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(String ID)
        {
            int id = 0;
            if (ID != "0")//ID=0 for new record
            {
                id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            }
           Currency currency = new Currency();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CurrencyServiceClient currencyServiceClient = new Services.CurrencyServiceClient();
                    
                    currency = currencyServiceClient.GetCurrency(id);
                    //ViewBag.Status = "Save";
                    //ViewBag.Status = "Update";
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
        public ActionResult Delete(String ID)
        {

            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));//Decrypt ID
            
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
        public ActionResult DeleteCurrency(String ID)
        {

            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));//Decrypt ID
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