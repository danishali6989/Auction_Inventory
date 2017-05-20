using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class CustomersRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public dynamic GetAll()
        {
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = auctionContext.MCustomers.ToList().Count,
                rows = (
                  from customers in
                      (from AM in auctionContext.MCustomers
                      
                       join t1 in auctionContext.MCountries on AM.iCountry equals t1.iCountry
                       join t2 in auctionContext.MCities on AM.iCity equals t2.iCity

                       select new
                       {
                           iCustomerID = AM.iCustomerID,
                           strFirstName = AM.strFirstName,
                           strLastName = AM.strLastName,
                           iCountry = t1.strCountryName,
                           iCity = t2.strCityName,
                           strEmailID = AM.strEmailID,
                           iPhoneNumber = AM.iPhoneNumber,
                           strAddress = AM.strAddress,
                           iPincode = AM.iPincode,
                           strCreditLimit = AM.strCreditLimit,
                           //iPersonID = AM.iPersonID,
                           //strPersonFirstName = AM.strPersonFirstName,
                           //strPersonMiddleName = AM.strPersonMiddleName,
                           //strPersonLastName = AM.strPersonLastName,
                           //strCompanyName = AM.strCompanyName,
                           //CustomerPhoto = AM.CustomerPhoto,
                           //CustomerDate = AM.CustomerDate

                       }).OrderBy(a => a.strFirstName).ToList()
                  select new
                  {
                      id = customers.iCustomerID,
                      cell = new string[] {
               Convert.ToString(customers.iCustomerID),Convert.ToString(customers.strFirstName+" "+customers.strLastName),
               Convert.ToString(customers.iCountry),Convert.ToString(customers.iCity),
               Convert.ToString(customers.strEmailID),Convert.ToString(customers.iPhoneNumber),
               Convert.ToString(customers.iPincode),Convert.ToString(customers.strCreditLimit),
               Convert.ToString(customers.strAddress)
               
               //,Convert.ToString(customers.iPersonID),
               //Convert.ToString(customers.strPersonFirstName+" "+customers.strPersonLastName),Convert.ToString(customers.strCompanyName),
               //Convert.ToString(customers.CustomerPhoto),Convert.ToString(customers.CustomerDate)
                        }
                  }).ToArray()
            };
            return jsonData;
        }
        public MCustomer Get(int id)
        {
            MCustomer customer = new MCustomer();
            customer = auctionContext.MCustomers.Where(a => a.iCustomerID == id).FirstOrDefault();
            return customer;
        }
        public bool SaveEdit(MCustomer customer)
        {
            bool status = false;
            if (customer.iCustomerID > 0)
            {
                //Edit Existing Record
                var cust = auctionContext.MCustomers.Where(a => a.iCustomerID == customer.iCustomerID).FirstOrDefault();
                if (cust != null)
                {
                    cust.strFirstName = customer.strFirstName;
                    cust.strMiddleName = customer.strMiddleName;
                    cust.strLastName = customer.strLastName;
                    cust.iCountry = customer.iCountry;
                    cust.iCity = customer.iCity;
                    cust.strEmailID = customer.strEmailID;
                    cust.iPhoneNumber = customer.iPhoneNumber;
                    cust.strAddress = customer.strAddress;
                    cust.iPincode = customer.iPincode;
                    cust.strCreditLimit = customer.strCreditLimit;
                  
                    cust.strPersonFirstName = customer.strPersonFirstName;
                    cust.strPersonMiddleName = customer.strPersonMiddleName;
                    cust.strPersonLastName = customer.strPersonLastName;
                    cust.strCompanyName = customer.strCompanyName;
                    cust.CustomerPhoto = customer.CustomerPhoto;
                    cust.CustomerDate = customer.CustomerDate;
                    cust.iCreditCategoryID = customer.iCreditCategoryID;
                }
            }
            else
            {
                //Save
                auctionContext.MCustomers.Add(customer);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }
        public bool Delete(int id)
        {
            bool status = false;
            var cust = auctionContext.MCustomers.Where(a => a.iCustomerID == id).FirstOrDefault();
            if (cust != null)
            {
                auctionContext.MCustomers.Remove(cust);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion
    }
}
