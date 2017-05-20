using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class CustomerServiceClient
    {

        public dynamic GetAllCustomers()
        {
           
            CustomersRepository repo = new CustomersRepository();           
           var listCustomers = repo.GetAll();
            return listCustomers;
        }
        public bool SaveData(Customer customer)
        {
            bool status = true;
            Customer cust = new Customer();
            CustomersRepository repo = new CustomersRepository();
            status = repo.SaveEdit(ParserAddCustomer(customer));
            return status;
        }

        public Customer GetCustomer(int id)
        {

            Customer customer = new Customer();
            CustomersRepository repo = new CustomersRepository();
            if (customer != null)
            {
                customer = ParserCustomer(repo.Get(id));
            }
            return customer;

        }

        public bool Delete(int id)
        {
            bool status = false;
            CustomersRepository repo = new CustomersRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private MCustomer ParserAddCustomer(Customer customer)
        {
            MCustomer mCustomer = new MCustomer();

            if (customer != null)
            {
                mCustomer.iCustomerID = customer.iCustomerID;
                mCustomer.strFirstName = customer.strFirstName ?? " ";
                mCustomer.strMiddleName = customer.strMiddleName ?? " ";
                mCustomer.strLastName = customer.strLastName ?? " ";
                mCustomer.iCountry = customer.iCountry;
                mCustomer.iCity = customer.iCity ;
                mCustomer.strEmailID = customer.strEmailID ?? " ";
                mCustomer.iPhoneNumber = customer.iPhoneNumber;
                mCustomer.strAddress = customer.strAddress ?? " ";
                mCustomer.iPincode = customer.iPincode;
                mCustomer.strCreditLimit = customer.strCreditLimit ?? " ";
              
                mCustomer.strPersonFirstName = customer.strPersonFirstName ?? " ";
                mCustomer.strPersonMiddleName = customer.strPersonMiddleName ?? " ";
                mCustomer.strPersonLastName = customer.strPersonLastName ?? " ";
                mCustomer.strCompanyName = customer.strCompanyName ?? " ";
              
                mCustomer.CustomerPhoto = customer.CustomerPhoto ?? " ";
                mCustomer.CustomerDate = customer.CustomerDate ?? " ";
                mCustomer.iCreditCategoryID = customer.iCreditCategoryID;
            }
            return mCustomer;
        }

        private List<Customer> ParserGetAllCustomers(dynamic responseData)
        {
            List<Customer> listCustomer = new List<Customer>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Customer customer = new Customer();
                    customer.iCustomerID = data.iCustomerID;
                    customer.strFirstName = data.strFirstName ?? " ";
                    customer.strMiddleName = data.strMiddleName ?? " ";
                    customer.strLastName = data.strLastName ?? " ";
                    customer.iCountry = data.iCountry;
                    customer.iCity = data.iCity;
                    customer.strEmailID = data.strEmailID ?? " ";
                    customer.iPhoneNumber = data.iPhoneNumber;
                    customer.strAddress = data.strAddress ?? " ";
                    customer.iPincode = data.iPincode;
                    customer.strCreditLimit = data.strCreditLimit ?? " ";
                 
                    customer.strPersonFirstName = data.strPersonFirstName ?? " ";
                    customer.strPersonMiddleName = data.strPersonMiddleName ?? " ";
                    customer.strPersonLastName = data.strPersonLastName ?? " ";
                    customer.strCompanyName = data.strCompanyName ?? " ";
                 
                    customer.CustomerPhoto = data.CustomerPhoto ?? " ";
                    customer.CustomerDate = data.CustomerDate ?? " ";
                    listCustomer.Add(customer);
                }
            }
            return listCustomer;
        }


        private Customer ParserCustomer(dynamic data)
        {
            Customer customer = new Customer();

            if (data != null)
            {
                customer.iCustomerID = data.iCustomerID;
                customer.strFirstName = data.strFirstName ?? " ";
                customer.strMiddleName = data.strMiddleName ?? " ";
                customer.strLastName = data.strLastName ?? " ";
                customer.iCountry = data.iCountry;
                customer.iCity = data.iCity;
                customer.strEmailID = data.strEmailID ?? " ";
                customer.iPhoneNumber = data.iPhoneNumber;
                customer.strAddress = data.strAddress ?? " ";
                customer.iPincode = data.iPincode;
                customer.strCreditLimit = data.strCreditLimit ?? " ";
            
                customer.strPersonFirstName = data.strPersonFirstName ?? " ";
                customer.strPersonMiddleName = data.strPersonMiddleName ?? " ";
                customer.strPersonLastName = data.strPersonLastName ?? " ";
                customer.strCompanyName = data.strCompanyName ?? " ";
             
                customer.CustomerPhoto = data.CustomerPhoto ?? " ";
                customer.CustomerDate = data.CustomerDate ?? " ";

                customer.iCreditCategoryID = data.iCreditCategoryID;
            }
            return customer;
        }

        #endregion
    }
}