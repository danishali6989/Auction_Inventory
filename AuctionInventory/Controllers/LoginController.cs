using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;
using AuctionInventory.Models;
using System.Web.Security;

namespace AuctionInventory.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult SubmitLogin(UserLogin logins)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    // To Do -- Create method in common file and access service client from this method to get session
                    AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
                    UserLogin dataItem = auctionContext.UserLogins.Where(x => x.UserName == logins.UserName && x.Password == logins.Password).FirstOrDefault();

                    if (dataItem != null)
                    {
                        FormsAuthentication.SetAuthCookie(dataItem.UserName, false);

                        Session["UserProfile"] = dataItem;
                        
                        return RedirectToAction("DashBoard", "Home");
                    }
                    else
                    {
                        return RedirectToAction("WrongPassword", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Enter Different UserName");
                status = false;
                throw e;
            }
            return RedirectToAction("DashBoard", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            
            Session.Clear();

            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }



    }
}