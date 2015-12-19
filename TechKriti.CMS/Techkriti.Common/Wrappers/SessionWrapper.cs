using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Techkriti.Common.Keys;
using System.Security.Principal;
using Datacontracts.UserManagement;

namespace Techkriti.Common.Wrappers
{
    public class SessionWrapper
    {
        public static string CaptchaImageText
        {
            get
            {
                if (HttpContext.Current.Session[SessionKeys.CaptchaImageString] == null) return string.Empty;
                return HttpContext.Current.Session[SessionKeys.CaptchaImageString].ToString();
            }
            set { HttpContext.Current.Session[SessionKeys.CaptchaImageString] = value; }
        }

        public static List<Permissions> UserPermissions
        {
            get
            {
                if (HttpContext.Current.Session[SessionKeys.UserPermissions] == null) return new List<Permissions>();
                return (List<Permissions>)HttpContext.Current.Session[SessionKeys.UserPermissions];
            }
            set
            {
                HttpContext.Current.Session[SessionKeys.UserPermissions] = value;
            }
        }

        static public IPrincipal CurrentPrincipal
        {
            set { HttpContext.Current.Session[SessionKeys.CurrentPrincipal] = value; }
            get
            {
                if (HttpContext.Current.Session[SessionKeys.CurrentPrincipal] == null) return null;
                return (IPrincipal)HttpContext.Current.Session[SessionKeys.CurrentPrincipal];
            }
        }       

        public static UserTypeDataContract LoggedInUser
        {
            get
            {
                if (HttpContext.Current.Session[SessionKeys.LoggedInUser] == null) return new UserTypeDataContract();
                return (UserTypeDataContract)HttpContext.Current.Session[SessionKeys.LoggedInUser];
            }
            set
            {
                HttpContext.Current.Session[SessionKeys.LoggedInUser] = value;
            }
        }
    }
}