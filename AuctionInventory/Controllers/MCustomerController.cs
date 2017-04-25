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
    public class MCustomerController : Controller
    {
        AuctionInventoryEntities db = new AuctionInventoryEntities();
        // GET: MCustomer
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        
        public ActionResult GetAllCustomers()
        {
            dynamic customer = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetAllCustomers();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                customer = null;
                throw e;

            }
            return Json(customer, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            Customer customer = new Customer();

            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();
                    customer = customerServiceClient.GetCustomer(id);
                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customer.iCountry);
                    var countryList = db.MCities.Where(x => x.iCountry == customer.iCountry).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", customer.iCity);

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                customer = null;
                throw e;
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customers)
        {
            bool status = false;
            //ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customers.iCountry);
            //ViewBag.City = new SelectList(db.MCities, "iCity", "strCityName", customers.iCity);


            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();
                    status = customerServiceClient.SaveData(customers);

                    //ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customers.iCountry);
                    //ViewBag.City = new SelectList(db.MCities, "iCity", "strCityName", customers.iCity);


                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            return View(customers);
            // return new JsonResult { Data = new { status = status } };
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
            Customer customer = new Customer();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetCustomer(id);
                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customer.iCountry);
                    var countryList = db.MCities.Where(x => x.iCountry == customer.iCountry).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", customer.iCity);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                customer = null;
                throw e;
            }
            //return View("Save", customer);
            return View(customer);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCustomers(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();
                    status = customerServiceClient.Delete(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View("Index");
            // return new JsonResult { Data = new { status = status } };

        }

        #endregion
    }
}