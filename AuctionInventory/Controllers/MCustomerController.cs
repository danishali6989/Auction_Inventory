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
        // GET: MCustomer
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        public ActionResult GetAllCustomers()
        {
            List<Customer> customer = new List<Customer>();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetAllCustomers();
                    if (customer.Count == 0 || customer == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                    

                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                customer = null;
                throw e;

            }
            return Json(new { data = customer }, JsonRequestBehavior.AllowGet);

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
                }
            }
             catch(Exception e)
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
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();
                    status = customerServiceClient.SaveData(customers);
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
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetCustomer(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                customer = null;
                throw e;
            }
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
             catch(Exception e)
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