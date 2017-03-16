﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;
using AuctionInventory.Helpers;

namespace AuctionInventory.Services
{
    public class SupplierServiceClient
    {
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> listSupplier = new List<Supplier>();
            SupplierRepository repo = new SupplierRepository();
            dynamic supplier = repo.GetAll();
            listSupplier = ParserGetAllSuppliers(supplier);
            return listSupplier;
        }

        public Supplier GetSupplier(int id)
        {
            Supplier supplier = new Supplier();
            SupplierRepository repo = new SupplierRepository();
            if (id != 0)
            {
                supplier = ParserGetSupplier(repo.Get(id));
            }
            return supplier;
        }

        public bool SaveEdit(Supplier supplier)
        {
            AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            SupplierRepository repoSupplier = new SupplierRepository();
            string password = CommonMethods.GetPassword();

            if (repoSupplier.SaveEdit(GetMSupplier(supplier), password)) //Checking Supplkier insert status

            {

                UserLogin userLogin = new UserLogin();
                userLogin.Email = supplier.strEmailID;
                userLogin.Password = password;
                userLogin.UserName = supplier.strEmailID;
                userLogin.RoleId = 2;
                userLogin.IsActive = true;
                userLogin.IsDeleted = false;
                userLogin.IsValid = true;

                LoginRepository repoLogin = new LoginRepository();

                return repoLogin.SaveLoginDetails(userLogin);

            }
            return false;
        }

        public bool Delete(int id)
        {
            SupplierRepository repo = new SupplierRepository();
            return repo.Delete(id);
        }


        #region Parser


        private List<Supplier> ParserGetAllSuppliers(dynamic responseData)
        {
            List<Supplier> listSupplier = new List<Supplier>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Supplier supplier = new Supplier();
                    // supplier.FullName = data.FullName;
                    supplier.iSupplierID = data.iSupplierID ?? -1;
                    supplier.strFirstName = data.strFirstName ?? " ";
                    supplier.strMiddleName = data.strMiddleName ?? " ";
                    supplier.strLastName = data.strLastName ?? " ";
                    supplier.iSupplierCategory = data.iSupplierCategory ?? -1;
                    supplier.iSupplierServiceType = data.iSupplierServiceType ?? -1;
                    supplier.strEmailID = data.strEmailID ?? " ";
                    supplier.iPhoneNumber = data.iPhoneNumber ?? " ";
                    supplier.strAddress = data.strAddress ?? " ";
                    supplier.iPincode = data.iPincode ?? " ";
                    supplier.iCurrency = data.iCurrency ?? " ";
                    supplier.SupplierPhoto = data.SupplierPhoto ?? " ";
                    supplier.SupplierDate = data.SupplierDate ?? " ";

                    listSupplier.Add(supplier);
                }
            }
            return listSupplier;
        }

        private Supplier ParserGetSupplier(dynamic data)
        {
            Supplier supplier = new Supplier();
            if (data != null)
            {
                // supplier.FullName = data.FullName;
                supplier.iSupplierID = data.iSupplierID ?? -1;
                supplier.strFirstName = data.strFirstName ?? " ";
                supplier.strMiddleName = data.strMiddleName ?? " ";
                supplier.strLastName = data.strLastName ?? " ";
                supplier.iSupplierCategory = data.iSupplierCategory ?? -1;
                supplier.iSupplierServiceType = data.iSupplierServiceType ?? -1;
                supplier.strEmailID = data.strEmailID ?? " ";
                supplier.iPhoneNumber = data.iPhoneNumber ?? " ";
                supplier.strAddress = data.strAddress ?? " ";
                supplier.iPincode = data.iPincode ?? " ";
                supplier.iCurrency = data.iCurrency ?? " ";
                supplier.SupplierPhoto = data.SupplierPhoto ?? " ";
                supplier.SupplierDate = data.SupplierDate ?? " ";
            }
            return supplier;
        }

        private MSupplier GetMSupplier(dynamic data)
        {
            MSupplier supplier = new MSupplier();
            if (data != null)
            {
                // supplier.FullName = data.FullName;
                supplier.iSupplierID = data.iSupplierID ?? -1;
                supplier.strFirstName = data.strFirstName ?? " ";
                supplier.strMiddleName = data.strMiddleName ?? " ";
                supplier.strLastName = data.strLastName ?? " ";
                supplier.iSupplierCategory = data.iSupplierCategory ?? -1;
                supplier.iSupplierServiceType = data.iSupplierServiceType ?? -1;
                supplier.strEmailID = data.strEmailID ?? " ";
                supplier.iPhoneNumber = data.iPhoneNumber ?? " ";
                supplier.strAddress = data.strAddress ?? " ";
                supplier.iPincode = data.iPincode ?? " ";
                supplier.iCurrency = data.iCurrency ?? " ";
                supplier.SupplierPhoto = data.SupplierPhoto ?? " ";
                supplier.SupplierDate = data.SupplierDate ?? " ";
            }
            return supplier;
        }

        #endregion

    }
}