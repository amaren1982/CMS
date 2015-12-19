using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Techkriti.Common.Authorization;

namespace Techkriti.Common.Web.Shared
{
    public abstract class BasePage : System.Web.UI.Page, IAuthorizeAction
    {
        protected override void OnInit(EventArgs e)
        {
            AuthorizeBasedOnPermissions();

            base.OnInit(e);
        }

        #region View state helper methods

        protected V GetPropertyValue<V>(string propertyName, V nullValue)
        {
            if (ViewState[propertyName] == null)
            {
                return nullValue;
            }
            return (V)ViewState[propertyName];
        }

        protected void SetPropertyValue<V>(string propertyName, V value)
        {
            ViewState[propertyName] = value;
        }      

        #endregion View state helper methods

        #region IAuthorizeAction Members

        /// <summary>
        /// This property says what permission a user needs to  view the page. In the basepage it throws an exception
        /// to make sure that developers override it in their pages.
        /// </summary>
        public abstract Permissions RequiredActionPermission { get; }

        /// <summary>
        /// The method responnsible for restricting access to pages for all pages that inherrits from basepage(which should be all except the login page and the 
        /// forces password change page.
        /// </summary>
        public void AuthorizeBasedOnPermissions()
        {   
            bool auth = false;

            auth = RequiredActionPermission == Permissions.None ? true : TechKritiAuthorizationHelper.Authorize(RequiredActionPermission);     

            if (!auth) throw new HttpException(Convert.ToInt32(HttpStatusCode.Forbidden), "Access denied!! Required permission " + this.RequiredActionPermission.ToString());

        }

        #endregion
    }
}