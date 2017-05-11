using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Permissions;
using Microsoft.AspNet.Identity;

namespace AuctionInventory.MyRoleProvider
{
    public class SiteRole : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            // http://localhost:1302/TESTERS/Default6.aspx

            string path = HttpContext.Current.Request.Url.AbsolutePath;
            // /TESTERS/Default6.aspx

            string host = HttpContext.Current.Request.Url.Host;
            // localhost


            AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            string data = auctionContext.UserLogins.Where(x => x.UserName == username).FirstOrDefault().RoleId.ToString();
            string[] results = { data };
            return results;
        }

        public override string[] GetUsersInRole(string roleName)
        {


            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }


    public class PermissionsAttribute : ActionFilterAttribute
    {
        private readonly Permissions required;

        public PermissionsAttribute(Permissions required)
        {
            this.required = required;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var user = (UserLogin)HttpContext.Current.Session["UserProfile"];// filterContext.HttpContext.Session.GetUser();
            int roleId = 0;
            int.TryParse(user.RoleId.ToString(), out roleId);

            AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            bool IsPageAuthorize = auctionContext.tbl_AuthorizedPages.Where(x => x.RoleId == roleId && x.PageName == controllerName).Any();
            if (user == null)
            {
                //send them off to the login page
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = url.Content("~/Home/Login");
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }

            if (!IsPageAuthorize)
            {

                throw new AuthenticationException("You do not have the necessary permission to perform this action");
            }
            //Do Not Delete -- Will use in future for addtional permissions
            //else
            //{
            //    if (!user.HasPermissions(required))
            //    {
            //        throw new AuthenticationException("You do not have the necessary permission to perform this action");
            //    }
            //}
        }
    }


    [Flags]
    public enum Permissions
    {
        View = (1 << 0),
        Add = (1 << 1),
        Edit = (1 << 2),
        Delete = (1 << 3),
        Admin = (View | Add | Edit | Delete)
    }
}