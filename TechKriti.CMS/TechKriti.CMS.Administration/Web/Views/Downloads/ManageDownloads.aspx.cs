using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.Downloads;

namespace TechKriti.CMS.Client.Web.Views.Downloads
{
    public partial class ManageDownloads : BasePage
    {
        public const string EditCommandName = "EditDownload";
        public const string DeleteCommandName = "DeleteDownload";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageDownloads; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;

            if (!Page.IsPostBack) 
            {
                linkAddDownload.NavigateUrl = Pages.AddDownload;
                RefreshDownloads(0); 
            }           
        }

        private void RefreshDownloads(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;
                int sectionId = 0;
                if (!string.IsNullOrEmpty(drpDownSections.SelectedValue)) sectionId = int.Parse(drpDownSections.SelectedValue);

                this.gridDownloads.DataSource =
                DownloadsController.SearchDownloads(txtDisplayName.Text, startIndex, PageSize, sectionId, chkSearchIsActive.Checked, out totalNumberOfRecords);

                this.gridDownloads.VirtualItemCount = totalNumberOfRecords;
                this.gridDownloads.DataBind();
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
            }
            catch (Exception e)
            {
                lblStatus.Text = "Failed to get downloads";
                lblStatus.Visible = true;
            }
        }

        protected void gridDownloads_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int downloadId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName) Response.Redirect(Pages.AddDownload + "?downloadId=" + downloadId);
            else if (e.CommandName == DeleteCommandName) DeleteDownload(downloadId);
        }

        private void DeleteDownload(int downloadId)
        {
            try
            {
                lblStatus.Visible = true;

                bool isDeleted = DownloadsController.DeleteDownload(downloadId);

                if (isDeleted)
                {
                    RefreshDownloads(0);
                    lblStatus.Text = "Download deleted successfully";
                }
                else lblStatus.Text = "Failed to delete Download";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete Download";
            }
        }

        protected void gridDownloads_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridDownloads.PageIndex = e.NewPageIndex;

            RefreshDownloads(startIndex);
        }

        protected void btnSectorSearch_Click(object sender, EventArgs e) { RefreshDownloads(0); }

        private int PageSize { get { return this.gridDownloads.PageSize; } }
    }
}