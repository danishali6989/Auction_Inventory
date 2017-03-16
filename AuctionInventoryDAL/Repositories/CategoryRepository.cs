using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInventoryDAL.Repositories
{
   public class CategoryRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public List<MCategory> GetAll()
        {
            List<MCategory> categoryList = new List<MCategory>();
            categoryList = (from r in auctionContext.MCategories select r).OrderBy(a => a.strCategoryName).ToList();
            return categoryList;
        }

        public MCategory Get(int id)
        {
            MCategory category = new MCategory();
            category = auctionContext.MCategories.Where(a => a.iCategoryID == id).FirstOrDefault();
            return category;
        }

        public bool SaveEdit(MCategory category)
        {
            bool status = false;
            if (category.iCategoryID > 0)
            {
                //Edit Existing Record
                var UpdateCategory = auctionContext.MCategories.Where(a => a.iCategoryID == category.iCategoryID).FirstOrDefault();
                if (UpdateCategory != null)
                {
                    UpdateCategory.strCategoryName = category.strCategoryName;
                }
            }
            else
            {
                //Save
                auctionContext.MCategories.Add(category);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }


        public bool Delete(int id)
        {
            bool status = false;
            var category = auctionContext.MCategories.Where(a => a.iCategoryID == id).FirstOrDefault();
            if (category != null)
            {
                auctionContext.MCategories.Remove(category);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion
    }
}
