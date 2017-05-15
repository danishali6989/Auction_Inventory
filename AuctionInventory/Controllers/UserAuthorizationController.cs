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
    public class UserAuthorizationController : Controller
    {

        AuctionInventoryEntities dc = new AuctionInventoryEntities();
        //
        // GET: /UserAuthorization/
        public ActionResult Index()
        {






            var listUserRole = (from a in dc.tbl_UserRoles select a).ToList();



            ViewBag.listUserRole = new SelectList(listUserRole, "Id", "Name");



            return View();
        }

        [HttpPost]
        public JsonResult GetPageAccessByRole(int roleId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pageName = (from a in dc.tbl_Pages select a).ToList();

                    List<PageModel> authorizedPages = (from a in pageName
                                                       select new PageModel
                                                           {
                                                               PageId = a.PageId,
                                                               PageName = a.PageNameController,
                                                               IsChecked = (dc.tbl_AuthorizedPages.Where(x => x.RoleId == roleId && x.PageId == a.PageId).Any())
                                                           }
                        ).ToList();

                    return Json(new { authorizedPages = authorizedPages }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                throw e;
            }
            return Json(new { authorizedPages = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SavePageAccessByRole(int roleId, int[] pageValue)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //dc.tbl_AuthorizedPages.RemoveRange(dc.tbl_AuthorizedPages.Where(x => x.RoleId == roleId));
                    //dc.SaveChanges();
                    AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
                    for (int i = 0; i < pageValue.Length; i++)
                    {
                        tbl_AuthorizedPages authorizedPages = new tbl_AuthorizedPages();
                        authorizedPages.RoleId = roleId;
                        authorizedPages.PageId = pageValue[i];
                        authorizedPages.PageName = "salman";
                        auctionContext.tbl_AuthorizedPages.Add(authorizedPages);
                        auctionContext.SaveChanges();
                    }
                   

                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                throw e;
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }



    }
}