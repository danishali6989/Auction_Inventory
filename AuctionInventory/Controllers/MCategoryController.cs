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
    public class MCategoryController : Controller
    {
        // GET: MCategory
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        public ActionResult GetAllCategory()
        {
            dynamic category = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    CategoryServiceClient categoryServiceClient = new CategoryServiceClient();
                    category = categoryServiceClient.GetAllCategory();
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
        public ActionResult Save(String ID)
        {
            int id = 0;
            if (ID != "0")
            {
                id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            }
            Category category = new Category();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.CategoryServiceClient categoryServiceClient = new Services.CategoryServiceClient();
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
        public ActionResult Save(Category category)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CategoryServiceClient categoryServiceClient = new Services.CategoryServiceClient();
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
        public ActionResult Delete(String ID)
        {
            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            Category category = new Category();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.CategoryServiceClient categoryServiceClient = new Services.CategoryServiceClient();
                    category = categoryServiceClient.GetCategory(id);
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
        public ActionResult DeleteCategory(String ID)
        {
            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CategoryServiceClient categoryServiceClient = new Services.CategoryServiceClient();
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