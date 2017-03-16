using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;


namespace AuctionInventoryDAL.Repositories
{



    public class LoginRepository
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public bool SaveLoginDetails(UserLogin userLogin)
        {
            bool status = false;

            //Save
            auctionContext.UserLogins.Add(userLogin);
            auctionContext.SaveChanges();
            status = true;
            return status;
        }


        //#region CRUD
        //private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        //public List<UserLogin> GetAll()
        //{
        //    List<UserLogin> lists = new List<UserLogin>();
        //    lists = (from r in auctionContext.UserLogins select r).OrderBy(a => a.UserName).ToList();
        //    return lists;
        //}

        //public UserLogin Get(int id)
        //{
        //    UserLogin login = new UserLogin();
        //    login = auctionContext.UserLogins.Where(a => a.UserID == id).FirstOrDefault();
        //    return login;
        //}

        //public bool SaveEdit(UserLogin login)
        //{
        //    bool status = false;
        //    if (login.UserID > 0)
        //    {
        //        //Edit Existing Record
        //        var logins = auctionContext.UserLogins.Where(a => a.UserID == login.UserID).FirstOrDefault();
        //        if (logins != null)
        //        {
        //            logins.UserName = login.UserName;
        //            logins.Password = login.Password;
        //        }
        //    }
        //    else
        //    {
        //        //Save
        //        auctionContext.UserLogins.Add(login);
        //    }
        //    auctionContext.SaveChanges();
        //    status = true;
        //    return status;
        //}



        //public bool Delete(int id)
        //{
        //    bool status = false;
        //    var logins = auctionContext.UserLogins.Where(a => a.UserID == id).FirstOrDefault();
        //    if (logins != null)
        //    {
        //        auctionContext.UserLogins.Remove(logins);
        //        auctionContext.SaveChanges();
        //        status = true;
        //    }
        //    return status;
        //}
        //#endregion
    }

}
