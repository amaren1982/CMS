using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.UserManagement;
using System.Web;
using Techkriti.Common.Keys;
using System.Net;

namespace Techkriti.Common.Authorization
{
    public class TechKritiAuthorizationHelper
    {
        public static bool Authorize(Permissions userAction)
        {
            TechKritiPrincipal principal;

            //find the users principal. It is put in session on the first hit to a basepage
            if (HttpContext.Current.Session[SessionKeys.CurrentPrincipal] == null)
            {
                //this should not happen but experiense says it will.
                throw new HttpException(Convert.ToInt16(HttpStatusCode.Unauthorized), "Unauthorized access made");
            }

            principal = HttpContext.Current.Session[SessionKeys.CurrentPrincipal] as TechKritiPrincipal;

            return principal.HasPermisson(userAction);
        }
    }
}
