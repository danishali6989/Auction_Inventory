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
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace AuctionInventory.Controllers
{
   // [Authorize]
    //[Permissions(Permissions.View)]

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
        public ActionResult Save(String ID)
        {
            int id = 0;
            if (ID != "0")
            {
                id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            }
            Supplier supplier = new Supplier();

           // ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
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
           // ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
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
        public ActionResult Delete(String ID)
        {
            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            Supplier supplier = new Supplier();

            //ViewBag.category = new SelectList(db.MCategories, "iCategoryID", "strCategoryName", supplier.iSupplierCategory);
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
        public ActionResult DeleteSupplier(String ID)
        {
            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
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


        [HttpGet]
        public ActionResult GetAllSupplierBankDetails()
        {

            dynamic listSupplierBankDetails = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    listSupplierBankDetails = supplierServiceClient.GetAllSupplierBankDetails();
                    //ViewBag.ImageData = listSupplier.SupplierPhoto;
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                listSupplierBankDetails = null;
                throw e;

            }
            return Json(listSupplierBankDetails, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SupplierBankDetails()
        {
            
            return View();

        }

        #endregion



        //for image Retrieve from db  
        [HttpPost]
        //public ActionResult RetrieveImage(String ID)
        //{
        //  int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));

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