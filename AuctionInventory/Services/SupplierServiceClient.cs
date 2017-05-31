using System;
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

        public dynamic RetrieveImage(int id)
        {

            SupplierRepository repo = new SupplierRepository();

            var ImageSupplierlist = repo.RetrieveImage(id);
            return ImageSupplierlist;
        }
        public dynamic GetAllSuppliers()
        {
            
            SupplierRepository repo = new SupplierRepository();
           
           var listSupplier = repo.GetAll();
            return listSupplier;
        }

        public dynamic GetAllSupplierBankDetails()
        {

            SupplierRepository repo = new SupplierRepository();

            var listSupplierBankDetails = repo.GetAllSupplierBankDetails();
            return listSupplierBankDetails;
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

        public bool SaveEdit(Supplier supplier, HttpPostedFileBase file)
        {
            AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            SupplierRepository repoSupplier = new SupplierRepository();
            string password = CommonMethods.GetPassword();

            if (repoSupplier.SaveEdit(GetMSupplier(supplier), file, password)) //Checking Supplier insert status

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
                    supplier.SupplierPhoto = data.SupplierPhoto;
                    supplier.SupplierDate = data.SupplierDate ?? " ";


                    supplier.iPersonPhoneNumber = data.iPersonPhoneNumber;
                    supplier.strPersonEmailID = data.strPersonEmailID;
                    supplier.strCompanyName = data.strCompanyName;
                    supplier.strWebsites = data.strWebsites;
                    supplier.strPicName = data.strPicName;

               

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
                supplier.SupplierPhoto = data.SupplierPhoto;
                supplier.SupplierDate = data.SupplierDate ?? " ";


                supplier.iPersonPhoneNumber = data.iPersonPhoneNumber;
                supplier.strPersonEmailID = data.strPersonEmailID;
                supplier.strCompanyName = data.strCompanyName;
                supplier.strWebsites = data.strWebsites;
                supplier.strPicName = data.strPicName;

                supplier.AccountNumber = data.AccountNumber;
                supplier.strBankName = data.strBankName;
                supplier.strBranchName = data.strBranchName;
                supplier.strSwiftCode = data.strSwiftCode;
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
                supplier.SupplierPhoto = data.SupplierPhoto;
                supplier.SupplierDate = data.SupplierDate ?? " ";

                supplier.iPersonPhoneNumber = data.iPersonPhoneNumber;
                supplier.strPersonEmailID = data.strPersonEmailID;
                supplier.strCompanyName = data.strCompanyName;
                supplier.strWebsites = data.strWebsites;
                supplier.strPicName = data.strPicName;

                supplier.AccountNumber = data.AccountNumber;
                supplier.strBankName = data.strBankName;
                supplier.strBranchName = data.strBranchName;
                supplier.strSwiftCode = data.strSwiftCode;
            }
            return supplier;
        }

        #endregion

    }
}