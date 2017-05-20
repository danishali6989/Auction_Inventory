using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInventoryDAL.Repositories
{
    public class CreditCategoryRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public dynamic GetAll()
        {
            //List<MCategory> categoryList = new List<MCategory>();
            //categoryList = (from r in auctionContext.MCategories select r).OrderBy(a => a.strCategoryName).ToList();
            //return categoryList;

            var jsonData = new
            {
                total = 1,
                page = 1,
                records = auctionContext.CreditCategories.ToList().Count,
                rows = (
                  from category in
                      (from AM in auctionContext.CreditCategories

                       select new
                       {
                           iCreditCategoryID = AM.iCreditCategoryID,
                           strCategory = AM.strCategory,
                           iDays = AM.iDays

                       }).OrderBy(a => a.strCategory).ToList()
                  select new
                  {
                      id = category.iCreditCategoryID,
                      cell = new string[] {
               Convert.ToString(category.iCreditCategoryID),Convert.ToString(category.strCategory),Convert.ToString(category.iDays)
                        }
                  }).ToArray()
            };
            return jsonData;

            //return View();
        }




        public CreditCategory Get(int id)
        {
            CreditCategory category = new CreditCategory();
            category = auctionContext.CreditCategories.Where(a => a.iCreditCategoryID == id).FirstOrDefault();
            return category;
        }

        public bool SaveEdit(CreditCategory category)
        {
            bool status = false;
            if (category.iCreditCategoryID > 0)
            {
                //Edit Existing Record
                var UpdateCategory = auctionContext.CreditCategories.Where(a => a.iCreditCategoryID == category.iCreditCategoryID).FirstOrDefault();
                if (UpdateCategory != null)
                {
                    UpdateCategory.strCategory = category.strCategory;
                    UpdateCategory.iDays = category.iDays;
                }
            }
            else
            {
                //Save
                auctionContext.CreditCategories.Add(category);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }


        public bool Delete(int id)
        {
            bool status = false;
            var category = auctionContext.CreditCategories.Where(a => a.iCreditCategoryID == id).FirstOrDefault();
            if (category != null)
            {
                auctionContext.CreditCategories.Remove(category);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion
    }
}
