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
    [Authorize]
    public class MStaffController : Controller
    {
        // GET: MStaff
        public ActionResult Index()
        {
            UserLogin profile = (UserLogin)Session["UserProfile"];
            return View();
        }


        #region CRUD
        public ActionResult GetAllStaff()
        {
            List<Staff> staff = new List<Staff>();
            try
            {
                if (ModelState.IsValid)
                {
                    StaffServiceClient staffServiceClient = new StaffServiceClient();
                    staff = staffServiceClient.GetAllStaff();
                    if (staff.Any())
                    {
                        staff.ForEach(x => x.FullName = CommonMethods.GetFullName(x.strFirstName, x.strMiddleName, x.strLastName));
                    }
                    else
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }


                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                staff = null;
                throw e;

            }
            return Json(new { data = staff }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            Staff staff = new Staff();
            try
            {
                if (ModelState.IsValid)
                {
                    StaffServiceClient staffServiceClient = new StaffServiceClient();
                   
                    staff = staffServiceClient.GetStaff(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                staff = null;
                throw e;
            }
            return View(staff);
        }

        [HttpPost]
        public ActionResult Save(Staff staff)
        {
            UserLogin profile = (UserLogin)Session["UserProfile"];
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    StaffServiceClient staffServiceClient = new StaffServiceClient();

                    status = staffServiceClient.SaveData(staff);
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
         //   return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Staff staff = new Staff();
            try
            {
                if (ModelState.IsValid)
                {
                    StaffServiceClient staffServiceClient = new StaffServiceClient();

                    staff = staffServiceClient.GetStaff(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                staff = null;
                throw e;
            }
            return View(staff);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteStaff(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    StaffServiceClient staffServiceClient = new StaffServiceClient();

                    status = staffServiceClient.Delete(id);
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