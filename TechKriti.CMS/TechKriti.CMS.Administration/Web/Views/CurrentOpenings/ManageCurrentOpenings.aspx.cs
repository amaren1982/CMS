using Common.UserManagement;
using Datacontracts.CurrentOpeningManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.CurrentOpening;

namespace TechKriti.CMS.Client.Web.Views.CurrentOpenings
{
    public partial class CurrentOpenings : BasePage
    {
        public const string EditCommandName = "EditCurrentOpening";
        public const string DeleteCommandName = "DeleteCurrentOpening";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageCurrentOpenings; } }

        protected void Page_Load(object sender, EventArgs e) 
        {
            lblStatus.Visible = false;
            if (!Page.IsPostBack) 
            { 
                RefreshCurrentOpenings(0); 
            }           
        }

        private void RefreshCurrentOpenings(int startIndex)
        {
            try
            {
                  int totalNumberOfRecords = 0;
               
                this.gridCurrentOpenings.DataSource = 
                CurrentOpeningController.Search(txtSearchCompany.Text, txtSearchPosition.Text, txtSearchQualification.Text, txtSearchSkillSet.Text, txtSearchEmailPhone.Text,
                                                Helper.ConvertStringToDate(txtSearchOpenTillDate.Text), chkSearchIsActive.Checked, startIndex, PageSize, out totalNumberOfRecords);

                this.gridCurrentOpenings.VirtualItemCount = totalNumberOfRecords;
                this.gridCurrentOpenings.DataBind();
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
            int currentOpeningId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName)  Response.Redirect("~/Web/Views/CurrentOpenings/AddCurrentOpening.aspx?currentOpeningId=" + currentOpeningId);           
            else if (e.CommandName == DeleteCommandName)  DeleteCurrentOpening(currentOpeningId);
        }

        private void DeleteCurrentOpening(int currentOpeningId)
        {
            try
            {
                lblStatus.Visible = true;

                bool isDeleted = CurrentOpeningController.Delete(currentOpeningId);

                if (isDeleted)
                {
                    RefreshCurrentOpenings(0);
                    lblStatus.Text = "Current opening deleted successfully";
                }
                else lblStatus.Text = "Failed to delete Current opening";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete Current opening";
            }
        }

        protected void gridNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridCurrentOpenings.PageIndex = e.NewPageIndex;

            RefreshCurrentOpenings(startIndex);
        }

        protected void btnCurrentOpeningSearch_click(object sender, EventArgs e) { RefreshCurrentOpenings(0); }

        private int PageSize { get { return this.gridCurrentOpenings.PageSize; } }
    }
}