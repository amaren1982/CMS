using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.Sectors;

namespace TechKriti.CMS.Client.Web.Views.Sectors
{
    public partial class ManageSectors : BasePage
    {
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

                this.gridSectors.DataSource =
                SectorsController.SearchSectors(txtSectorName.Text, startIndex, PageSize, false, out totalNumberOfRecords);

                this.gridSectors.VirtualItemCount = totalNumberOfRecords;
                this.gridSectors.DataBind();
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
            }
            catch (Exception e)
            {
                lblStatus.Text = "Failed to get sectors";
                lblStatus.Visible = true;
            }
        }

        protected void gridSectors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int sectorId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommand) Response.Redirect(Pages.AddSector +"?sectorId=" + sectorId);
            else if (e.CommandName == DeleteCommand) DeleteSector(sectorId);
        }

        private void DeleteSector(int sectorId)
        {
            try
            {
                string errorMessage = string.Empty;
                lblStatus.Visible = true;

                bool isDeleted = SectorsController.DeleteSector(sectorId, out errorMessage);

                if (isDeleted)
                {
                    RefreshSectors(0);
                    lblStatus.Text = "Sector deleted successfully";
                }
                else lblStatus.Text = "Failed to delete Sector " + errorMessage;
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

        protected void gridSectors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}