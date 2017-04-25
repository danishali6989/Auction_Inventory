using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class CurrencyServiceClient
    {
        public dynamic GetAllCurrency()
        {
           
            CurrencyRepository repo = new CurrencyRepository();
            var currency = repo.GetAll();
            return currency;
        }
        public bool SaveData(Currency currency)
        {
            bool status = true;
            Currency currencies = new Currency();
            CurrencyRepository repo = new CurrencyRepository();
            status = repo.SaveEdit(ParserAddCurrency(currency));
            return status;
        }

        public Currency GetCurrency(int id)
        {

            Currency currency = new Currency();
            CurrencyRepository repo = new CurrencyRepository();
            if (currency != null)
            {
                currency = ParserCurrency(repo.Get(id));
            }
            return currency;

        }

        public bool Delete(int id)
        {
            bool status = false;
            CurrencyRepository repo = new CurrencyRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private MCurrency ParserAddCurrency(Currency currency)
        {
            MCurrency mCurrency = new MCurrency();

            if (currency != null)
            {
                mCurrency.CurrencyID = currency.CurrencyID ;
                mCurrency.strCurrencyName = currency.strCurrencyName ?? " ";
                mCurrency.strCurrencyShortName = currency.strCurrencyShortName ?? " ";

            }
            return mCurrency;
        }

        private Currency ParserCurrency(dynamic data)
        {
            Currency currency = new Currency();

            if (data != null)
            {
                currency.CurrencyID = data.CurrencyID ?? -1;
                currency.strCurrencyName = data.strCurrencyName ?? " ";
                currency.strCurrencyShortName = data.strCurrencyShortName ?? " ";
            }
            return currency;
        }
        private List<Currency> ParserGetAllCurrency(dynamic responseData)
        {
            List<Currency> listCurrency = new List<Currency>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Currency currency = new Currency();

                    currency.CurrencyID = data.CurrencyID ?? -1;
                    currency.strCurrencyName = data.strCurrencyName ?? " ";
                    currency.strCurrencyShortName = data.strCurrencyShortName ?? " ";
                   

                    listCurrency.Add(currency);
                }
            }
            return listCurrency;
        }

        #endregion

    }
}