using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.Admin;

namespace TechKriti.CMS.Administration.Web.Views.Admin
{
    public partial class ManageUsers : BasePage
    {
        public const string EditCommandName = "EditUser";
        public const string DeleteCommandName = "DeleteUser";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageUsers; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            if (!Page.IsPostBack) 
            { 
                RefreshUsers(0);
                linkAddUser.NavigateUrl = Pages.AddUser;
            }
        }

        private void RefreshUsers(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;

                this.gridUsers.DataSource = UsersController.SearchUsers(txtUserName.Text, startIndex, PageSize, out totalNumberOfRecords);

                this.gridUsers.VirtualItemCount = totalNumberOfRecords;
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
                this.gridUsers.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to get users";
                lblStatus.Visible = true;
            }
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName)
            {
                Response.Redirect(Pages.AddUser + "?userId=" + userId);
            }
            else if (e.CommandName == DeleteCommandName) DeleteUser(userId);           
        }

        private void DeleteUser(int userId)
        {
            try
            {
                lblStatus.Visible = true;
                bool isDeleted = UsersController.DeleteUser(userId);

                if (isDeleted)
                {
                    RefreshUsers(0);
                    lblStatus.Text = "User deleted successfully";
                }
                else
                {
                    lblStatus.Text = "Failed to delete user";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete user.";
            }
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridUsers.PageIndex = e.NewPageIndex;

            RefreshUsers(startIndex);
        }

        protected void btnUsersSearch_Click(object sender, EventArgs e) { RefreshUsers(0); }

        private int PageSize { get { return this.gridUsers.PageSize; } }
    }
}