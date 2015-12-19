using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.UserManagement;
using Techkriti.Common.Authorization;

namespace TechKriti.Custom.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:HyperlinkControl runat=server></{0}:HyperlinkControl>")]
    public class HyperlinkControl : HyperLink, IAuthorizeAction
    {
        private Permissions requiredPermission = Permissions.None;

        public Permissions RequiredActionPermission
        {
            get { return requiredPermission; }
            set { requiredPermission = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            AuthorizeBasedOnPermissions();
            base.OnPreRender(e);
        }

        public void AuthorizeBasedOnPermissions()
        {
            bool auth = false;

            try
            {
                auth = RequiredActionPermission == Permissions.None ? true : TechKritiAuthorizationHelper.Authorize(RequiredActionPermission);
            }
            catch (Exception ex)
            {
                //just swallow the exception for now. Makes sure authorized is false;
                auth = false;
            }

            if (!auth)
            {
                this.Visible = false;
            }
        }  
    }
}
