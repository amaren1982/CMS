using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.UserManagement;
using Techkriti.Common.Controllers.CMS;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;

namespace TechKriti.CMS.Administration.Web.Views.CMS
{
    public partial class ManageMenu : BasePage
    {
        public const string EditCommandName = "EditMenu";
        public const string DeleteCommandName = "DeleteMenu";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageMenus; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            if (!Page.IsPostBack)
            {
                linkAddMenu.NavigateUrl = Pages.AddMenu;
                RefreshMenus(0);
            }  
        }

        private void RefreshMenus(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;

                this.gridMenus.DataSource = MenuController.SearchMenu(txtMenuName.Text, chkSearchIsActive.Checked, 
                                                                      startIndex, PageSize, out totalNumberOfRecords);

                this.gridMenus.VirtualItemCount = totalNumberOfRecords;
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
                this.gridMenus.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to get menus" + ex.Message;
                lblStatus.Visible = true;
            }
        }

        private void DeleteMenu(int roleId)
        {
            try
            {
                string errorMessage = string.Empty;
                lblStatus.Visible = true;
                bool isDeleted = MenuController.DeleteMenu(roleId, out errorMessage);

                if (isDeleted)
                {
                    RefreshMenus(0);
                    lblStatus.Text = "Menu deleted successfully";
                }
                else
                {
                    lblStatus.Text = "Failed to delete menu " + errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete role";
            }
        }

        protected void gridMenus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int menuId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName)  Response.Redirect(Pages.AddMenu + "?menuId=" + menuId);
            else if (e.CommandName == DeleteCommandName) DeleteMenu(menuId);           
        }

        protected void gridMenus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridMenus.PageIndex = e.NewPageIndex;

            RefreshMenus(startIndex);
        }       

        protected void btnMenuSearch_Click(object sender, EventArgs e) { RefreshMenus(0); }

        private int PageSize { get { return this.gridMenus.PageSize; } }
    }
}