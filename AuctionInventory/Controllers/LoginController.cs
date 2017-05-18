using System;
using System.Linq;
using System.Web.Mvc;
using AuctionInventoryDAL.Entity;
using System.Web.Security;
using AuctionInventory.Helpers;
using AuctionInventory.MyRoleProvider;

namespace AuctionInventory.Controllers
{
    //[Permissions(Permissions.View)]
    //[Authorize]
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

                        if (userLogin.RoleId == (int)Helpers.Enums.Roles.SuperAdmin)
                        {
                            return RedirectToAction("DashBoard", "Home");
                        }
                        else if (userLogin.RoleId == (int)Helpers.Enums.Roles.AdminSupplier)
                        {
                            return RedirectToAction("SupplierDashBoard", "Home");
                        }
                        else
                        {
                            return RedirectToAction("WrongPage", "Home");
                        }

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