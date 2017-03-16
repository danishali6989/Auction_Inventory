using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class CompanyRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public List<MCompany> GetAll()
        {
            List<MCompany> listcompany = new List<MCompany>();
            listcompany = (from r in auctionContext.MCompanies select r).OrderBy(a => a.strCompanyName).ToList();
            return listcompany;

        }
        public MCompany Get(int id)
        {
            MCompany company = new MCompany();
            company = auctionContext.MCompanies.Where(a => a.iCompanyID == id).FirstOrDefault();
            return company;

        }

        public bool SaveEdit(MCompany company)
        {
            bool status = false;
            if (company.iCompanyID > 0)
            {
                //Edit Existing Record
                var compny = auctionContext.MCompanies.Where(a => a.iCompanyID == company.iCompanyID).FirstOrDefault();
                if (compny != null)
                {
                    compny.strCompanyName = company.strCompanyName;
                    compny.strArea = company.strArea;
                    compny.iCountry = company.iCountry;
                    compny.iCity = company.iCity;
                    compny.strEmailID = company.strEmailID;
                    compny.strWebsites = company.strWebsites;
                    compny.iPhoneNumber = company.iPhoneNumber;
                    compny.iOfcPhoneNumber = company.iOfcPhoneNumber;
                    compny.strAddress = company.strAddress;

                }
            }
            else
            {
                //Save
                auctionContext.MCompanies.Add(company);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            var compny = auctionContext.MCompanies.Where(a => a.iCompanyID == id).FirstOrDefault();
            if (compny != null)
            {
                auctionContext.MCompanies.Remove(compny);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion
    }
}
