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
using System.Transactions;

namespace AuctionInventory.Controllers
{
    //[Authorize]
    public class MSupplierController : Controller, IDisposable
    {
        private AuctionInventoryEntities db = new AuctionInventoryEntities();
        // GET: MSupplier
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }
               
        #region CRUD
        public ActionResult GetAllSuppliers()
        {
            List<Supplier> listSupplier = new List<Supplier>();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    listSupplier = supplierServiceClient.GetAllSuppliers();
                    if (listSupplier.Any())
                    {
                        listSupplier.ForEach(x => x.FullName = CommonMethods.GetFullName(x.strFirstName, x.strMiddleName, x.strLastName));
                    }
                    else
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Wrong");
                throw ex;
            }
            return Json(new { data = listSupplier }, JsonRequestBehavior.AllowGet);

        }
      
        [HttpGet]
        public ActionResult Save(int id)
        {
            Supplier supplier = new Supplier();

            //ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
            //ViewBag.currency = new SelectList(db.MCurrencies, "CurrencyID", "strCurrencyName", supplier.iCurrency);


            //var list = (from c in db.MCategories
            //            select new SelectListItem
            //            {
            //                Text = c.strCategoryName,
            //                Value = c.iCategoryID.ToString()
            //            }).ToList();
            //ViewBag.category = list;

            ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
            ViewBag.currency = new SelectList(db.MCurrencies, "CurrencyID", "strCurrencyName", supplier.iCurrency);


          
            //supplier.SupplierCategoryList = new SelectList(db.MCategories, "iCategoryID", "strCategoryName");
            //supplier.iSupplierCategory = db.MCategories.Find(id);
            try
            {
                if (ModelState.IsValid)
                {

                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    supplier = supplierServiceClient.GetSupplier(id);
                    //supplier.iSupplierCategory = db.MCategories.Find(id);
                    //ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
           
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                supplier = null;
                throw e;
            }

           // return View()
            return View("Save", supplier);
           // return View(supplier);
        }


        [HttpPost]
        public ActionResult Save(Supplier supplier)
        {
            bool status = false;
            using (var trans = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        // Adding Supplier Code
                        Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                       
                        status = supplierServiceClient.SaveEdit(supplier);
                        ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
                        ViewBag.currency = new SelectList(db.MCurrencies, "CurrencyID", "strCurrencyName", supplier.iCurrency);
                        
                        
                        //ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
                       

                        if (supplier == null)
                        {
                            ModelState.AddModelError("error", "No Record found");
                            trans.Dispose();
                        }
                        trans.Complete();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //supplier.SupplierCategoryList = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);

                        //return View(supplier);
                    }
                }
                catch (Exception e)
                {

                    trans.Dispose();
                    ModelState.AddModelError("error", "Something Went Wrong");
                    status = false;
                    throw e;

                }
            }
            return View();
           // return View("Index");

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Supplier supplier = new Supplier();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    supplier = supplierServiceClient.GetSupplier(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                supplier = null;
                throw e;
            }

            return View("Delete", supplier);
          
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteSupplier(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    if (id == 0)
                    {
                        ModelState.AddModelError("error", "Record Can not be Zero");
                    }
                    status = supplierServiceClient.Delete(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }

            return View("Index");

         

        }

        #endregion


    }

    public static class Role
    {
        public const string Administrator = "Administrator";
        public const string Assistant = "Assistant";
    }
}