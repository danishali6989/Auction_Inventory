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
        [Permissions(Permissions.View)]
    public class MColorController : Controller
    {
        // GET: MColor
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        public ActionResult GetAllColor()
        {
            List<Color> color = new List<Color>();
            try
            {
                if (ModelState.IsValid)
                {
                    ColorServiceClient colorServiceClient = new ColorServiceClient();
                    color = colorServiceClient.GetAllColors();
                    if (color.Count == 0 || color == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                color = null;
                throw e;
            }
            return Json(new { data = color }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            Color color = new Color();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.ColorServiceClient ColorServiceClient = new Services.ColorServiceClient();
                    color = ColorServiceClient.GetColor(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                color = null;
                throw e;
            }
            return View("save",color);
        }

        [HttpPost]
        public ActionResult Save(Color color)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.ColorServiceClient colorServiceClient = new Services.ColorServiceClient();
                    status = colorServiceClient.SaveData(color);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            //return RedirectToAction("Index");
            return View();
            //return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Color color = new Color();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.ColorServiceClient ColorServiceClient = new Services.ColorServiceClient();
                    color = ColorServiceClient.GetColor(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                color = null;
                throw e;
            }
            return View(color);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteColor(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.ColorServiceClient colorServiceClient = new ColorServiceClient();

                    status = colorServiceClient.Delete(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View("Index");
          //  return new JsonResult { Data = new { status = status } };

        }

        #endregion
    }
}