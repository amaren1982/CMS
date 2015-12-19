using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.Sectors;

namespace TechKriti.CMS.Client.Web.Views.Sectors
{
    public partial class ManageSectors : BasePage
    {
        public const string EditCommandName = "EditCurrentOpening";
        public const string DeleteCommandName = "DeleteCurrentOpening";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageSectors; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;

            if (!Page.IsPostBack) 
            {
                linkAddSector.NavigateUrl = Pages.AddSector;
                RefreshSectors(0); 
            }            
        }

        private void RefreshSectors(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;
                int sectionId = 0;
                if (!string.IsNullOrEmpty(drpDownSections.SelectedValue)) sectionId = int.Parse(drpDownSections.SelectedValue);

                this.gridSectors.DataSource =
                SectorsController.SearchSectors(txtDisplayName.Text, txtPath.Text, startIndex, PageSize, sectionId, out totalNumberOfRecords);

                this.gridSectors.VirtualItemCount = totalNumberOfRecords;
                this.gridSectors.DataBind();
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
            }
            catch (Exception e)
            {
                lblStatus.Text = "Failed to get Current opening";
                lblStatus.Visible = true;
            }
        }

        protected void gridCurrentOpenings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int sectorId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName) Response.Redirect("~/Web/Views/Sectors/AddSector.aspx?sectorId=" + sectorId);
            else if (e.CommandName == DeleteCommandName) DeleteSector(sectorId);
        }

        private void DeleteSector(int sectorId)
        {
            try
            {
                lblStatus.Visible = true;

                bool isDeleted = SectorsController.DeleteSector(sectorId);

                if (isDeleted)
                {
                    RefreshSectors(0);
                    lblStatus.Text = "Sector deleted successfully";
                }
                else lblStatus.Text = "Failed to delete Sector";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete Sector";
            }
        }

        protected void gridSectors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridSectors.PageIndex = e.NewPageIndex;

            RefreshSectors(startIndex);
        }

        protected void btnSectorSearch_Click(object sender, EventArgs e) { RefreshSectors(0); }

        private int PageSize { get { return this.gridSectors.PageSize; } }
    }
}