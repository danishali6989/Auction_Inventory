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
    public class MCompanyController : Controller
    {
        // GET: MCompany
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        public ActionResult GetAllCompany()
        {
            List<Company> listcompany = new List<Company>();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CompanyServiceClient companyServiceClient = new Services.CompanyServiceClient();
                    listcompany = companyServiceClient.GetAllCompanies();
                    if (listcompany.Count == 0 || listcompany == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                listcompany = null;
                throw e;
            }
            return Json(new { data = listcompany }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            Company company = new Company();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CompanyServiceClient companyServiceClient = new Services.CompanyServiceClient();
                    company = companyServiceClient.GetCompany(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                company = null;
                throw e;
            }
            return View(company);
        }

        [HttpPost]
        public ActionResult Save(Company company)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CompanyServiceClient companyServiceClient = new Services.CompanyServiceClient();
                    status = companyServiceClient.SaveData(company);
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
            Company company = new Company();
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CompanyServiceClient companyServiceClient = new Services.CompanyServiceClient();
                    company = companyServiceClient.GetCompany(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                company = null;
                throw e;
            }
            return View(company);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCompany(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CompanyServiceClient companyServiceClient = new Services.CompanyServiceClient();
                    
                    status = companyServiceClient.Delete(id);
                }
            }
             catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View("Index");
           /// return new JsonResult { Data = new { status = status } };

        }

        #endregion
    }
}