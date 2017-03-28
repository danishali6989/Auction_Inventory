using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace  AuctionInventory.Helpers
{
    public class CommonMethods
    {
        public static string GetFullName(string firstName, string middleName, string lastName)
        {
            string fullName = string.Empty;
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrEmpty(firstName))
            {
                fullName += firstName + " ";
            }
            if (!string.IsNullOrWhiteSpace(middleName) && !string.IsNullOrEmpty(middleName))
            {
                fullName += middleName + " ";
            }
            if (!string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrEmpty(lastName))
            {
                fullName += lastName + " ";
            }
            fullName = fullName.TrimEnd(' ');
            return fullName;
        }

        public static Menus GetMenuAuthorization()
        {
            Menus menus = new Menus();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // For Super Admin DAA
                if (HttpContext.Current.User.IsInRole("1"))
                {
                    menus.ShowDashBoard = true;
                    menus.ShowSupplier = true;
                    menus.ShowEmployee = true;
                    menus.ShowExpenses = true;
                    menus.ShowPurchase = true;
                    menus.ShowCategory = true;
                    menus.ShowCurrency = true;
                    menus.ShowSale = true;
                    menus.ShowAuction = true;
                    menus.ShowLedger = true;
                    menus.ShowProducts = true;
                    menus.ShowQueue = true;
                    menus.ShowReports = true;
                    menus.ShowCustomer = true;
                  
                }
                // For Admin Supplier
             else   if (HttpContext.Current.User.IsInRole("2"))
                {
                    menus.ShowDashBoard = true;
                    menus.ShowSupplier = false;
                    menus.ShowEmployee = false;
                    menus.ShowExpenses = true;
                    
                    menus.ShowSale = true;
                    menus.ShowLedger = true;
                    menus.ShowProducts = true;
                    menus.ShowQueue = true;
                    menus.ShowReports = true;
                    menus.ShowCustomer = true;
                }
                // For Accountant
                else if (HttpContext.Current.User.IsInRole("3"))
                {
                    menus.ShowDashBoard = true;
                    menus.ShowSupplier = true;
                    menus.ShowEmployee = true;
                    menus.ShowExpenses = true;
                    menus.ShowSale = true;
                    menus.ShowLedger = true;
                    menus.ShowProducts = true;
                    menus.ShowQueue = true;
                    menus.ShowReports = true;
                    menus.ShowCustomer = true;
                }
                // For Data Entry Operator
                else if (HttpContext.Current.User.IsInRole("4"))
                {
                    menus.ShowDashBoard = true;
                    menus.ShowSupplier = true;
                    menus.ShowEmployee = true;
                    menus.ShowExpenses = true;
                    menus.ShowSale = true;
                    menus.ShowLedger = true;
                    menus.ShowProducts = true;
                    menus.ShowQueue = true;
                    menus.ShowReports = true;
                    menus.ShowCustomer = true;
                }

                    // Need to ask Danish Bhai
                // For XYZ Role
                else if (HttpContext.Current.User.IsInRole("5"))
                {
                    menus.ShowDashBoard = true;
                    menus.ShowSupplier = true;
                    menus.ShowEmployee = true;
                    menus.ShowExpenses = true;
                    menus.ShowSale = true;
                    menus.ShowLedger = true;
                    menus.ShowProducts = true;
                    menus.ShowQueue = true;
                    menus.ShowReports = true;
                    menus.ShowCustomer = true;
                }
                else
                {
                    menus.ShowDashBoard = true;
                    menus.ShowSupplier = false;
                    menus.ShowEmployee = false;
                    menus.ShowExpenses = false;
                    menus.ShowSale = false;
                    menus.ShowLedger = false;
                    menus.ShowProducts = false;
                    menus.ShowQueue = false;
                    menus.ShowReports = false;
                    menus.ShowCustomer = false;
                }
            }
            return menus;
        }

        public static string DefaultConnection
        {
            get { return (string)System.Web.Configuration.WebConfigurationManager.AppSettings["DefaultConnection"]; }
        }


        public static string GetPassword()
        {
            ////string RandomPassword = string.Empty;
            //string password = Membership.GeneratePassword(12, 1);

            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < 12; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            return passwordString;
        }


    }
}