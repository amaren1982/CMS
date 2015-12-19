using System;
using System.Web.Security;
using System.Web.UI;
using Techkriti.Common.Utilities;
using Techkriti.Common.Wrappers;

namespace TechKriti.CMS.Client.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Head1.DataBind();
            if (!Page.IsPostBack)
            {
                CustomizeLeftNavigationBar();
                lblUser.Text = SessionWrapper.LoggedInUser.Username;
            }
        }

        private void CustomizeLeftNavigationBar()
        {
            linkManageUsers.NavigateUrl = Pages.ManageUsers;
            linkManageRoles.NavigateUrl = Pages.ManageRoles;

            linkManageMenu.NavigateUrl = Pages.ManageMenus;
            linkManagePages.NavigateUrl = Pages.ManagePages;

            linkManageNews.NavigateUrl = Pages.ManageNews;
            linkManageCurrentOpenings.NavigateUrl = Pages.ManageCurrentOpenings;
            linkManageSectors.NavigateUrl = Pages.ManageSectors;
            linkManageTestimonials.NavigateUrl = Pages.ManageTestimonials;
            linkManagePhotoGallery.NavigateUrl = Pages.ManagePhotoGallery;
            linkManageDownloads.NavigateUrl = Pages.ManageDownloads;
            linkManageQualifications.NavigateUrl = Pages.ManageQualifications;

            linkManageCategories.NavigateUrl = Pages.ManageCategories;
            linkManageSubCategories.NavigateUrl = Pages.ManageSubCategories;
            linkManageChildCategories.NavigateUrl = Pages.ManageChildCategories;
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}