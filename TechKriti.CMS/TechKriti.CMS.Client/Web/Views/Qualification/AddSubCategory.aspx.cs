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
    public partial class AddSubCategory : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddSubCategory; } }

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
                LoadCategories();
                BuildView();
            }
        }

        private void LoadCategories()
        {
            try
            {
                List<CategoryDataContract> source = new List<CategoryDataContract>();
                source.Add(new CategoryDataContract { Id = 0, Name = "Select" });

                drpDownCategories.DataTextField = "Name";
                drpDownCategories.DataValueField = "Id";
                source.AddRange(QualificationsController.GetCategories());
                drpDownCategories.DataSource = source;
                drpDownCategories.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load categories";
            }
        }

        private void SaveCategory()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildCategoryRequest();
                isCreated = QualificationsController.SaveSubCategory(CategoryModel);

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
            CategoryModel.Code = txtCode.Text;

            CategoryModel.ParentCategoryId = int.Parse(drpDownCategories.SelectedValue);
        }

        private void BuildView()
        {
            txtName.Text = CategoryModel.Name;
            txtCode.Text = CategoryModel.Code;

            if (CategoryModel.ParentCategoryId.HasValue) drpDownCategories.SelectedValue = CategoryModel.ParentCategoryId.Value.ToString();
            else drpDownCategories.SelectedValue = "0";

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
            txtName.Text = txtCode.Text = string.Empty;
        }

        private void GetCategoryModel()
        {
            if (CategoryToBeEdited > 0) CategoryModel = QualificationsController.GetSubCategoryById(CategoryToBeEdited);
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

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageSubCategories); } 
    }
}