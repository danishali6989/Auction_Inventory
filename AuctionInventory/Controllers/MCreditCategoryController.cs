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
    public class MCreditCategoryController : Controller
    {
        //
        // GET: /MCreditCategory/
        public ActionResult Index()
        {
            return View();
        }


        #region CRUD
        public ActionResult GetAllCreditCategory()
        {
            dynamic category = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    CreditCategoryServiceClient service = new CreditCategoryServiceClient();
                    category = service.GetAllCategory();
                    //if (category.Count == 0 || category == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                category = null;
                throw e;
            }
            return Json(category, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            CreditCategoryModel category = new CreditCategoryModel();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.CreditCategoryServiceClient categoryServiceClient = new Services.CreditCategoryServiceClient();
                    category = categoryServiceClient.GetCategory(id);
                    //ViewBag.Status = "Update";
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                category = null;
                throw e;
            }
            return View("Save", category);
            //return View(category);
        }

        [HttpPost]
        public ActionResult Save(CreditCategoryModel category)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CreditCategoryServiceClient categoryServiceClient = new Services.CreditCategoryServiceClient();
                    status = categoryServiceClient.SaveData(category);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            return View(category);

            //return View();
            // return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CreditCategoryModel category = new CreditCategoryModel();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.CreditCategoryServiceClient categoryServiceClient = new Services.CreditCategoryServiceClient();
                    category = categoryServiceClient.GetCategory(id);
                    //ViewBag.Status = "Update";
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                category = null;
                throw e;
            }
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCategory(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CreditCategoryServiceClient categoryServiceClient = new Services.CreditCategoryServiceClient();
                    status = categoryServiceClient.Delete(id);
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
	}
}