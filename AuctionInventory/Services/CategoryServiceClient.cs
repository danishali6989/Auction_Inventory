using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

using System.Web.Mvc;

namespace AuctionInventory.Services
{
    public class CategoryServiceClient
    {


        public List<SelectListItem> CategoryDropDown()
        {
            AuctionInventoryEntities db = new AuctionInventoryEntities();

            var listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem { Text = "Upto", Value = "Upto" });
            listItems.Add(new SelectListItem { Text = "Greater Than", Value = "Greater Than" });
            listItems.Add(new SelectListItem { Text = "Less Than", Value = "Less Than" });
            listItems.Add(new SelectListItem { Text = "Between", Value = "Between" });
            return listItems;


            //var list = (from c in db.MCategories
            //            select new SelectListItem
            //            {
            //                Text = c.strCategoryName,
            //                Value = c.iCategoryID.ToString()
            //            }).ToList();
            //return list;
           
        }


        public dynamic GetAllCategory()
        {
            
            CategoryRepository repo = new CategoryRepository();
          
           var categoryList = repo.GetAll();
            return categoryList;
        }
        public bool SaveData(Category category)
        {
            bool status = true;            
            CategoryRepository repo = new CategoryRepository();
            status = repo.SaveEdit(ParserAddCategory(category));
            return status;
        }

        public Category GetCategory(int id)
        {

            Category category = new Category();
            CategoryRepository repo = new CategoryRepository();
            if (category != null)
            {
                category = ParserCategory(repo.Get(id));
            }
            return category;

        }

        public bool Delete(int id)
        {
            bool status = false;
            CategoryRepository repo = new CategoryRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private MCategory ParserAddCategory(Category category)
        {
            MCategory mCategory = new MCategory();

            if (category != null)
            {
               // mCategory.iCategoryID = category.iCategoryID;
                int iCategoryID = 0;
                int.TryParse(category.iCategoryID.ToString(), out iCategoryID);
                mCategory.iCategoryID = iCategoryID;
                mCategory.strCategoryName = category.strCategoryName ?? " ";
            }
            return mCategory;
        }

        private List<Category> ParserGetAllCategory(dynamic responseData)
        {
            List<Category> categoryList = new List<Category>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Category category = new Category();
                    category.iCategoryID = data.iCategoryID ?? -1;
                    category.strCategoryName = data.strCategoryName ?? " ";
                    categoryList.Add(category);
                }
            }
            return categoryList;
        }


        private Category ParserCategory(dynamic data)
        {
            Category category = new Category();

            if (data != null)
            {
                category.iCategoryID = data.iCategoryID ?? -1;
                category.strCategoryName = data.strCategoryName ?? " ";
            }
            return category;
        }

        #endregion
    }
}