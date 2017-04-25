using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AuctionInventoryDAL.Entity;
using AuctionInventory.Models;

//using MongoAndMVC.Models;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using MongoDB.Driver.Builders;

namespace AuctionInventory.Controllers
{
    //public class GalleryController : Controller
    //{
    //    //
    //    // GET: /Gallery/
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}



    public class GalleryController : Controller
    {
        AuctionInventoryEntities db = new AuctionInventoryEntities();
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult FileUpload()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {
            if (uploadFile.ContentLength > 0)
            {
                string relativePath = "~/img/" + Path.GetFileName(uploadFile.FileName);
                string physicalPath = Server.MapPath(relativePath);
                uploadFile.SaveAs(physicalPath);
                return View((object)relativePath);
            }
            return View();
        }
    }

}





