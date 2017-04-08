using System;
using System.Linq;
using System.Web.Mvc;
using AuctionInventoryDAL.Entity;
using System.Web.Security;
using AuctionInventory.Helpers;

namespace AuctionInventory.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitLogin(UserLogin logins)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserLogin userLogin = CommonMethods.GetUserSession(logins);
                    if (userLogin != null)
                    {
                        FormsAuthentication.SetAuthCookie(userLogin.UserName, false);
                        Session["UserProfile"] = userLogin;
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