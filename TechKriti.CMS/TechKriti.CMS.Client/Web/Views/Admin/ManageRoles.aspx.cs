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
    public partial class ManageRoles : BasePage
    {
        public const string EditCommandName = "EditRole";
        public const string DeleteCommandName = "DeleteRole";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageRoles; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            if (!Page.IsPostBack) 
            {
                linkAddRole.NavigateUrl = Pages.AddRole;
                RefreshNews(0); 
            }            
        }

        private void RefreshNews(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;

                this.gridRoles.DataSource = RolesController.SearchRoles(txtRoleName.Text, startIndex, PageSize, out totalNumberOfRecords);

                this.gridRoles.VirtualItemCount = totalNumberOfRecords;
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
                this.gridRoles.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to get news";
                lblStatus.Visible = true;
            }
        }

        private void DeleteRole(int roleId)
        {
            try
            {
                string errorMessage = string.Empty;
                lblStatus.Visible = true;
                bool isDeleted = RolesController.DeleteRole(roleId, out errorMessage);

                if (isDeleted)
                {
                    RefreshNews(0);
                    lblStatus.Text = "Role deleted successfully";
                }
                else
                {
                    lblStatus.Text = "Failed to delete role " + errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete role";
            }
        }

        protected void gridRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int newsId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName)
            {
                Response.Redirect(Pages.AddRole + "?roleId=" + newsId);
            }
            else if (e.CommandName == DeleteCommandName)
            {

                DeleteRole(newsId);
            }
        }

        protected void gridRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridRoles.PageIndex = e.NewPageIndex;

            RefreshNews(startIndex);
        }

        protected void btnRolesSearch_Click(object sender, EventArgs e) { RefreshNews(0); }

        private int PageSize { get { return this.gridRoles.PageSize; } }
    }
}