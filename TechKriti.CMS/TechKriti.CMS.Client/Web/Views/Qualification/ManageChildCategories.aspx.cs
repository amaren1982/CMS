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
    public partial class ManageChildCategories : BasePage
    {      
        public const string EditCommandName = "EditCategory";
        public const string DeleteCommandName = "DeleteCategory";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageSubCategories; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;           

            if (!Page.IsPostBack)
            {
                linkAddSubCategory.NavigateUrl = Pages.AddChildCategory;
                RefreshCategories(0);               
            } 
        }

        private void RefreshCategories(int? startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;

                this.gridCategories.DataSource =
                QualificationsController.GetChildCategories( txtSearchSubCategoryName.Text, txtSearchCode.Text, startIndex, 
                                                             PageSize, default(Nullable<int>), out totalNumberOfRecords);

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

            if (e.CommandName == EditCommandName) Response.Redirect(Pages.AddChildCategory + "?categoryId=" + categoryId);
            else if (e.CommandName == DeleteCommandName) DeleteCategory(categoryId);
        }

        private void DeleteCategory(int categoryId)
        {
            try
            {
                string errorMessage = string.Empty;
                lblStatus.Visible = true;

                bool isDeleted = QualificationsController.DeleteChildCategory(categoryId, out errorMessage);

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

        protected void btnChildCategorySearch_Click(object sender, EventArgs e) { RefreshCategories(0); }

        private int PageSize { get { return this.gridCategories.PageSize; } }
    }
    
}