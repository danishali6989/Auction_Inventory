﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.CommonMethods;
using System.Web;
namespace AuctionInventoryDAL.Repositories
{
    public class CurrencyRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public dynamic GetAll()
        {
            //List<MCurrency> listcurrency = new List<MCurrency>();
            //listcurrency = (from r in auctionContext.MCurrencies select r).OrderBy(a => a.strCurrencyName).ToList();
            //return listcurrency;

            var jsonData = new
            {
                total = 1,
                page = 1,
                records = auctionContext.MCurrencies.ToList().Count,
                rows = (
                  from currency in
                      (from AM in auctionContext.MCurrencies

                       select new
                       {
                           CurrencyID = AM.CurrencyID,
                           strCurrencyName = AM.strCurrencyName,
                           strCurrencyShortName = AM.strCurrencyShortName

                       }).OrderBy(a => a.strCurrencyName).ToList()
                  select new
                  {
                      //id = currency.CurrencyID,
                      id = HttpUtility.UrlEncode(Encryption.Encrypt(Convert.ToString(currency.CurrencyID))),
                     
                      cell = new string[] {
               Convert.ToString(currency.CurrencyID),Convert.ToString(currency.strCurrencyName),Convert.ToString(currency.strCurrencyShortName)
                        }
                  }).ToArray()
            };
            return jsonData;


        }
        public MCurrency Get(int id)
        {
            MCurrency currency = new MCurrency();
            currency = auctionContext.MCurrencies.Where(a => a.CurrencyID == id).FirstOrDefault();
            return currency;
        }
        public bool SaveEdit(MCurrency currency)
        {
            bool status = false;
            if (currency.CurrencyID > 0)
            {
                //Edit Existing Record
                var cur = auctionContext.MCurrencies.Where(a => a.CurrencyID == currency.CurrencyID).FirstOrDefault();
                if (cur != null)
                {
                    cur.strCurrencyName = currency.strCurrencyName;
                    cur.strCurrencyShortName = currency.strCurrencyShortName;

                }
            }
            else
            {
                //Save
                auctionContext.MCurrencies.Add(currency);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }
        public bool Delete(int id)
        {
            bool status = false;
            var cur = auctionContext.MCurrencies.Where(a => a.CurrencyID == id).FirstOrDefault();
            if (cur != null)
            {
                auctionContext.MCurrencies.Remove(cur);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }

       
        #endregion
    }
}
