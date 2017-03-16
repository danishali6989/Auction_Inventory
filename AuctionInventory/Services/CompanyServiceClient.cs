using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class CompanyServiceClient
    {
        public List<Company> GetAllCompanies()
        {
            List<Company> listCompany = new List<Company>();
            CompanyRepository repo = new CompanyRepository();
            dynamic company = repo.GetAll();
            listCompany = ParserGetAllCompanies(company);
            return listCompany;
        }

        public bool SaveData(Company company)
        {
            bool status = true;
            Company Comp = new Company();
            CompanyRepository repo = new CompanyRepository();
            status = repo.SaveEdit(ParserAddCompany(company));
            return status;
        }

        public Company GetCompany(int id)
        {

            Company comp = new Company();
            CompanyRepository repo = new CompanyRepository();

            if (comp != null)
            {
                comp = ParserCompany(repo.Get(id));
            }
            return comp;

        }

        public bool Delete(int id)
        {
            bool status = false;
            CompanyRepository repo = new CompanyRepository();
            status = repo.Delete(id);
            return status;
        }
        
        #region Parser

        private MCompany ParserAddCompany(Company company)
        {
            MCompany mComp = new MCompany();

            if (company != null)
            {
                mComp.iCompanyID = company.iCompanyID;
                mComp.strCompanyName = company.strCompanyName ?? " ";
                mComp.strArea = company.strArea ?? " ";
                mComp.iCity = company.iCity ?? -1;
                mComp.iCountry = company.iCountry ?? -1;
                mComp.strEmailID = company.strEmailID ?? " ";
                mComp.iPhoneNumber = company.iPhoneNumber ;
                mComp.strAddress = company.strAddress ?? " ";
                mComp.strWebsites = company.strWebsites ?? " ";
                mComp.iOfcPhoneNumber = company.iOfcPhoneNumber ;
            }
            return mComp;
        }
        
        private Company ParserCompany(dynamic data)
        {
            Company company = new Company();

            if (data != null)
            {
                company.iCompanyID = data.iCompanyID ?? -1;
                company.strCompanyName = data.strCompanyName ?? " ";
                company.strArea = data.strArea ?? " ";
                company.iCity = data.iCity ?? -1;
                company.iCountry = data.iCountry ?? -1;
                company.strEmailID = data.strEmailID ?? " ";
                company.iPhoneNumber = data.iPhoneNumber ?? " ";
                company.strAddress = data.strAddress ?? " ";
                company.strWebsites = data.strWebsites ?? " ";
                company.iOfcPhoneNumber = data.iOfcPhoneNumber ?? " ";
            }
            return company;
        }

        private List<Company> ParserGetAllCompanies(dynamic responseData)
        {
            List<Company> listCompany = new List<Company>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Company company = new Company();
                    company.iCompanyID = data.iCompanyID ?? -1;
                    company.strCompanyName = data.strCompanyName ?? " ";
                    company.strArea = data.strArea ?? " ";
                    company.iCity = data.iCity ?? -1;
                    company.iCountry = data.iCountry ?? -1;
                    company.strEmailID = data.strEmailID ?? " ";
                    company.iPhoneNumber = data.iPhoneNumber ?? " ";
                    company.strAddress = data.strAddress ?? " ";
                    company.strWebsites = data.strWebsites ?? " ";
                    company.iOfcPhoneNumber = data.iOfcPhoneNumber ?? " ";

                    listCompany.Add(company);
                }
            }
            return listCompany;
        }

        #endregion
    }
}