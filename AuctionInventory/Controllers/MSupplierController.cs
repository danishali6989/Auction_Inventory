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
using AuctionInventory.MyRoleProvider;

namespace AuctionInventory.Controllers
{
   // [Authorize]
    [Permissions(Permissions.View)]

    public class MSupplierController : Controller, IDisposable
    {
        private AuctionInventoryEntities db = new AuctionInventoryEntities();
        // GET: MSupplier
        //   [Authorize(Roles = "1")]
        // [Permissions(Permissions.View)]
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD

        public ActionResult GetAllSuppliers()
        {
            dynamic listSupplier = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    listSupplier = supplierServiceClient.GetAllSuppliers();
                    //ViewBag.ImageData = listSupplier.SupplierPhoto;
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                listSupplier = null;
                throw e;

            }
            return Json(listSupplier, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            Supplier supplier = new Supplier();

            ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
            ViewBag.currency = new SelectList(db.MCurrencies, "CurrencyID", "strCurrencyName", supplier.iCurrency);

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

            // return View()
            return View(supplier);
            // return View(supplier);
        }


        [HttpPost]
        public ActionResult Save(Supplier supplier)
        {
            bool status = false;
            ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
            ViewBag.currency = new SelectList(db.MCurrencies, "CurrencyID", "strCurrencyName", supplier.iCurrency);
            using (var trans = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        // Adding Supplier Code

                        HttpPostedFileBase file = Request.Files["ImageData"];

                        Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();

                        status = supplierServiceClient.SaveEdit(supplier, file);


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
            return View(supplier);
            // return View("Index");

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Supplier supplier = new Supplier();

            ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
            ViewBag.currency = new SelectList(db.MCurrencies, "CurrencyID", "strCurrencyName", supplier.iCurrency);
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
                    return RedirectToAction("Index");
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



        //for image Retrieve from db  
        [HttpPost]
        public ActionResult RetrieveImage(int id)
        {
            dynamic cover = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    cover = supplierServiceClient.RetrieveImage(id);
                    if (cover != null)
                    {
                        //return File(cover, "image/jpg");
                        return Json(cover, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                cover = null;
                throw e;

            }
            return null;


        }



    }

    public static class Role
    {
        public const string Administrator = "Administrator";
        public const string Assistant = "Assistant";
    }
}