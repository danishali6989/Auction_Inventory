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

        public List<MCustomer> GetAll()
        {
            List<MCustomer> listCustomer = new List<MCustomer>();
            listCustomer = (from r in auctionContext.MCustomers select r).OrderBy(a => a.strFirstName).ToList();
            return listCustomer;
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
                    cust.iPersonID = customer.iPersonID;
                    cust.strPersonFirstName = customer.strPersonFirstName;
                    cust.strPersonMiddleName = customer.strPersonMiddleName;
                    cust.strPersonLastName = customer.strPersonLastName;
                    cust.strCompanyName = customer.strCompanyName;
                    cust.CustomerPhoto = customer.CustomerPhoto;
                    cust.CustomerDate = customer.CustomerDate;

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
