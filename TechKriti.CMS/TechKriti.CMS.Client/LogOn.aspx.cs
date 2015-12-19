using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Datacontracts.UserManagement;
using Techkriti.Common.Wrappers;
using Techkriti.Common.Authorization;
using System.Security.Principal;
using Common.UserManagement;
using Techkriti.Common.Encryption;
using Techkriti.Common.Proxy;

namespace TechKriti.CMS.Client.Public
{
    public partial class LogOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!(this.txtCaptcha.Text == SessionWrapper.CaptchaImageText))
            {
                lblErrorMessage.Text = "image code is not valid.";
                lblErrorMessage.Visible = true;
                return;
            }         

            AuthenticateUserRequest request = new AuthenticateUserRequest();
            AuthenticateUserResponse response = null;
            request.Username = txtUsername.Text;
            request.Password = ComputeMD5.MD5(txtPassword.Text);

            try
            {
                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())  
                { 
                    response = client.ServiceChannel.AuthenticateUser(request); 
                }

                if (response.IsUserAuthentic)
                {
                    HttpContext.Current.Session.Clear();

                    TechKritiPrincipal spPrincipal = new TechKritiPrincipal(new GenericIdentity(response.User.Username), response.Permissions);
                    SessionWrapper.CurrentPrincipal = spPrincipal;
                    SessionWrapper.LoggedInUser = response.User;

                    FormsAuthentication.SetAuthCookie(this.txtUsername.Text, false);
                    Response.Redirect(FormsAuthentication.DefaultUrl,false);
                }
                else
                {
                    lblErrorMessage.Text = response.FailureReason.ToString();
                    lblErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Could not validate user. Please contact System Administrator" + ex.Message;
                lblErrorMessage.Visible = true;
            }
        }

        protected void btnCaptchaRefresh_Click(object sender, EventArgs e) {  imageCaptcha.ImageUrl = "~/Web/Utilities/CImage.aspx?time="+ DateTime.Now.ToString(); ;  }
    }
}