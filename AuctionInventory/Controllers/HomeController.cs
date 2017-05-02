using AuctionInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.Repositories;

namespace AuctionInventory.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult SupplierDashBoard()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WrongPage()
        {
            return View();
        }
        #region CRUD

        public ActionResult GetEmployees()
        {
            List<AuctionInventoryDAL.Entity.Employee> listEmployee = new List<AuctionInventoryDAL.Entity.Employee>();
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    listEmployee = employeeRepository.GetAll();
                    if (listEmployee.Count == 0 || listEmployee == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                    
                }

            }
            catch(Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                listEmployee = null;
                throw e;
            }

            return Json(new { data = listEmployee }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            AuctionInventoryDAL.Entity.Employee employee = new AuctionInventoryDAL.Entity.Employee();
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (employee == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                    employee = employeeRepository.Get(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                employee = null;
                throw e;
            }
            return View(employee);


        }

        [HttpPost]
        public ActionResult Save(AuctionInventoryDAL.Entity.Employee emp)
        {

            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (emp == null)
                    {
                        ModelState.AddModelError("error", "Record Can not be null");
                    }
                    status = employeeRepository.SaveEdit(emp);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            AuctionInventoryDAL.Entity.Employee employee = new AuctionInventoryDAL.Entity.Employee();
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (employee == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                    employee = employeeRepository.Get(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                employee = null;
                throw e;
            }

            return View(employee);
           
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {

            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (id == 0)
                    {
                        ModelState.AddModelError("error", "Record Can not be Zero");
                    }
                    status = employeeRepository.DeleteEmployee(id);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }

            return new JsonResult { Data = new { status = status } };

        }

        #endregion

        public ActionResult WrongPassword()
        {
            return View();
        }

    }
}