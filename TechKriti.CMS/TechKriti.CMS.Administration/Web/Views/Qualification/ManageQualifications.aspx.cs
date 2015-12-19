using Common.UserManagement;
using Datacontracts.QualificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.Qualification;

namespace TechKriti.CMS.Client.Web.Views.Qualification
{
    public partial class ManageQualifications : BasePage
    {
        public const string EditCommandName = "EditQualification";
        public const string DeleteCommandName = "DeleteQualification";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageQualifications; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            linkAddQualification.NavigateUrl = Pages.AddQualification;

            if (!Page.IsPostBack) 
            { 
                RefreshQualifications(0);
                LoadSubCategories();
            }           
        }

        private void LoadSubCategories()
        {
            try
            {
                List<CategoryDataContract> source = new List<CategoryDataContract>();
                source.Add(new CategoryDataContract { Id = 0, Name = "Select" });               

                drpDownSubCategories.DataTextField = "Name";
                drpDownSubCategories.DataValueField = "Id";

                source.AddRange(QualificationsController.GetSubCategories( default(Nullable<int>)) );
                drpDownSubCategories.DataSource = source;
                drpDownSubCategories.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load categories";
            }
        }

        private void RefreshQualifications(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;
                int? subCategoryId = default(Nullable<int>);
                if (!string.IsNullOrEmpty(drpDownSubCategories.SelectedValue)) subCategoryId = int.Parse(drpDownSubCategories.SelectedValue);

                this.gridQualifications.DataSource =
                QualificationsController.SearchQualifications(txtDescription.Text, subCategoryId, startIndex, PageSize, out totalNumberOfRecords);

                this.gridQualifications.VirtualItemCount = totalNumberOfRecords;
                this.gridQualifications.DataBind();
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
            int qualificationId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName) Response.Redirect(Pages.AddQualification + "?qualificationId=" + qualificationId);
            else if (e.CommandName == DeleteCommandName) DeleteDownload(qualificationId);
        }

        private void DeleteDownload(int qualificationId)
        {
            try
            {
                lblStatus.Visible = true;

                bool isDeleted = QualificationsController.DeleteQualification(qualificationId);

                if (isDeleted)
                {
                    RefreshQualifications(0);
                    lblStatus.Text = "Qualification deleted successfully";
                }
                else lblStatus.Text = "Failed to delete Download";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete Qualification";
            }
        }

        protected void gridDownloads_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridQualifications.PageIndex = e.NewPageIndex;

            RefreshQualifications(startIndex);
        }

        protected void btnQualificationSearch_Click(object sender, EventArgs e) { RefreshQualifications(0); }

        private int PageSize { get { return this.gridQualifications.PageSize; } }
    }
}