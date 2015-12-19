using Common.UserManagement;
using Datacontracts.QualificationManagement;
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
    public partial class AddCategory : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddCategory; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateCategoryId = Request.Params["categoryId"];

                if (!string.IsNullOrEmpty(candidateCategoryId))
                {
                    int result;
                    if (int.TryParse(candidateCategoryId, out result))
                    {
                        CategoryToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetCategoryModel();
                BuildView();
            }
        }

        private void SaveCategory()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildCategoryRequest();
               isCreated = QualificationsController.SaveCategory(CategoryModel);

                if (isCreated) { lblStatus.Text = "Category saved successfully"; }
                else lblStatus.Text = "Failed to save category";

                ClearForm();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save category";
            }
        }

        private void BuildCategoryRequest()
        {
            CategoryModel.Name = txtName.Text;           
        }

        private void BuildView()
        {
            txtName.Text = CategoryModel.Name;         

            if (IsEditMode.HasValue && IsEditMode.Value)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveCategory(); }

        private void ClearForm()
        {
            txtName.Text = string.Empty;           
        }

        private void GetCategoryModel()
        {
            if (CategoryToBeEdited > 0) CategoryModel = QualificationsController.GetCategoryById(CategoryToBeEdited);
            else CategoryModel = new CategoryDataContract();
        }

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        public int CategoryToBeEdited
        {
            get { return GetPropertyValue<int>("CategoryToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("CategoryToBeEdited", value); }
        }

        public CategoryDataContract CategoryModel
        {
            get { return GetPropertyValue<CategoryDataContract>("CategoryModel", null); }
            set { SetPropertyValue<CategoryDataContract>("CategoryModel", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageCategories); }  
    }
}