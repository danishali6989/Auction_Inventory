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
        AuctionInventoryEntities db = new AuctionInventoryEntities();
       
        // GET: MStaff
        public ActionResult Index()
        {
            UserLogin profile = (UserLogin)Session["UserProfile"];
            return View();
        }


        #region CRUD
        public ActionResult GetAllStaff()
        {
            dynamic staff = 0;
           
            try
            {
                if (ModelState.IsValid)
                {
                    StaffServiceClient staffServiceClient = new StaffServiceClient();
                    staff = staffServiceClient.GetAllStaff();
                   
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                staff = null;
                throw e;

            }
            return Json(staff, JsonRequestBehavior.AllowGet);

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

                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", staff.iCountryID);
                    var countryList = db.MCities.Where(x => x.iCountry == staff.iCountryID).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", staff.iCityID);

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
            ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", staff.iCountryID);
            var countryList = db.MCities.Where(x => x.iCountry == staff.iCountryID).ToList();

            ViewBag.City = new SelectList(countryList, "iCity", "strCityName", staff.iCityID);
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
            return View(staff);
         //   return new JsonResult { Data = new { status = status } };
        }


        [HttpPost]
        public ActionResult GetCity(string countryID)
        {

            // ViewBag.City = new SelectList(db.MCities, "iCity", "strCityName", customers.iCity);


            int countryId;
            List<SelectListItem> cityNames = new List<SelectListItem>();

            //ViewBag.City = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(countryID))
            {
                countryId = Convert.ToInt32(countryID);
                List<MCity> cityLists = db.MCities.Where(x => x.iCountry == countryId).ToList();
                cityLists.ForEach(x =>
                {
                    cityNames.Add(new SelectListItem { Text = x.strCityName, Value = x.iCity.ToString() });
                });
            }
            ViewBag.City = cityNames;
            return Json(ViewBag.City, JsonRequestBehavior.AllowGet);
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
                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", staff.iCountryID);
                    var countryList = db.MCities.Where(x => x.iCountry == staff.iCountryID).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", staff.iCityID);
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
                    return RedirectToAction("Index");
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View();
            //return new JsonResult { Data = new { status = status } };

        }

        #endregion
    }
}