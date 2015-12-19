using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.ContentManagement;
using Common.UserManagement;
using Techkriti.Common.Controllers.CMS;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;

namespace TechKriti.CMS.Administration.Web.Views.CMS
{
    public partial class ManagePages : BasePage
    {
        public const string EditCommandName = "EditPage";
        public const string DeleteCommandName = "DeletePage";

        public override Permissions RequiredActionPermission { get { return Permissions.ManagePages; } }

        protected void Page_Load(object sender, EventArgs e)
        {
           lblStatus.Visible = false;
            if (!Page.IsPostBack)
            {
                linkAddPage.NavigateUrl = Pages.AddPage;
                RefreshPages(0);
            }
        }

        private void RefreshPages(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;
                PageStatus pageStatus = PageStatus.All;

                if (drpDownStatus.SelectedValue == "1") pageStatus = PageStatus.Draft;
                else if ((drpDownStatus.SelectedValue == "2")) pageStatus = PageStatus.Published;

                this.gridPages.DataSource = PageController.SearchPages(txtMenuName.Text, pageStatus, startIndex, PageSize, out totalNumberOfRecords);

                this.gridPages.VirtualItemCount = totalNumberOfRecords;
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
                this.gridPages.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to get pages";
                lblStatus.Visible = true;
            }
        }

        private void DeletePage(int pageId)
        {
            try
            { 
                lblStatus.Visible = true;
                bool isDeleted = PageController.DeletePage(pageId);

                if (isDeleted)
                {
                    RefreshPages(0);
                    lblStatus.Text = "Page deleted successfully";
                }
                else
                {
                    lblStatus.Text = "Failed to delete page ";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete page";
            }
        }

        protected void gridPages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int pageId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName) Response.Redirect(Pages.AddPage + "?pageId=" + pageId);
            else if (e.CommandName == DeleteCommandName)
            {
                DeletePage(pageId);
            }
        }

        protected void gridPages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridPages.PageIndex = e.NewPageIndex;

            RefreshPages(startIndex);
        }

        protected void btnPageSearch_Click(object sender, EventArgs e) { RefreshPages(0); }

        private int PageSize { get { return this.gridPages.PageSize; } }
    }
}