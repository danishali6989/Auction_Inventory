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
    public class CreditCategoryServiceClient
    {
       

        public dynamic GetAllCategory()
        {

            CreditCategoryRepository repo = new CreditCategoryRepository();

            var categoryList = repo.GetAll();
            return categoryList;
        }
        public bool SaveData(CreditCategoryModel category)
        {
            bool status = true;
            CreditCategoryRepository repo = new CreditCategoryRepository();

            status = repo.SaveEdit(ParserAddCategory(category));
            return status;
        }

        public CreditCategoryModel GetCategory(int id)
        {

            CreditCategoryModel category = new CreditCategoryModel();
            CreditCategoryRepository repo = new CreditCategoryRepository();
            if (category != null)
            {
                category = ParserCategory(repo.Get(id));
            }
            return category;

        }

        public bool Delete(int id)
        {
            bool status = false;
            CreditCategoryRepository repo = new CreditCategoryRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private CreditCategory ParserAddCategory(CreditCategoryModel category)
        {
            CreditCategory mCategory = new CreditCategory();

            if (category != null)
            {
                
                
                mCategory.iCreditCategoryID = category.iCreditCategoryID;
                mCategory.strCategory = category.strCategory;
                mCategory.iDays = category.iDays;
            }
            return mCategory;
        }

      


        private CreditCategoryModel ParserCategory(dynamic data)
        {
            CreditCategoryModel category = new CreditCategoryModel();

            if (data != null)
            {
                category.iCreditCategoryID = data.iCreditCategoryID;
                category.strCategory = data.strCategory;
                category.iDays = data.iDays;
                 
            }
            return category;
        }

        #endregion
    }
}