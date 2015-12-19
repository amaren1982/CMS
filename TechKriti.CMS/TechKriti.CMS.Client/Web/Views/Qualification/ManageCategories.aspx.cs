using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Controllers.Qualification;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;

namespace TechKriti.CMS.Client.Web.Views.Qualification
{
    public partial class ManageCategories : BasePage
    {
        public const string EditCommandName = "EditCategory";
        public const string DeleteCommandName = "DeleteCategory";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageCategories; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;           

            if (!Page.IsPostBack)
            {
                linkAddCategory.NavigateUrl = Pages.AddCategory;
                RefreshCategories(0);               
            } 
        }

        private void RefreshCategories(int? startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;

                this.gridCategories.DataSource =
                QualificationsController.GetCategories(txtSearchCategoryName.Text, startIndex, PageSize, out totalNumberOfRecords);

                this.gridCategories.VirtualItemCount = totalNumberOfRecords;
                this.gridCategories.DataBind();
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
            }
            catch (Exception e)
            {
                lblStatus.Text = "Failed to get categories";
                lblStatus.Visible = true;
            }
        }

        protected void gridCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int categoryId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName) Response.Redirect(Pages.AddCategory + "?categoryId=" + categoryId);
            else if (e.CommandName == DeleteCommandName) DeleteCategory(categoryId);
        }

        private void DeleteCategory(int categoryId)
        {
            try
            {
                string errorMessage = string.Empty;
                lblStatus.Visible = true;

                bool isDeleted = QualificationsController.DeleteCategory(categoryId, out errorMessage);

                if (isDeleted)
                {
                    RefreshCategories(0);
                    lblStatus.Text = "Category deleted successfully";
                }
                else lblStatus.Text = "Failed to delete category " + errorMessage;
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete category";
            }
        }

        protected void gridCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridCategories.PageIndex = e.NewPageIndex;

            RefreshCategories(startIndex);
        }

        protected void btnCategorySearch_Click(object sender, EventArgs e) { RefreshCategories(0); }

        private int PageSize { get { return this.gridCategories.PageSize; } }
    }
}