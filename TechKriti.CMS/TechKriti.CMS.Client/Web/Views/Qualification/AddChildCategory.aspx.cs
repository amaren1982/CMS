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
    public partial class AddChildCategory : BasePage
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

        private void SaveCategory()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildCategoryRequest();
                isCreated = QualificationsController.SaveChildCategory(CategoryModel);

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

            CategoryModel.ParentCategoryId = int.Parse(drpDownSubCategories.SelectedValue);
        }

        private void BuildView()
        {
            txtName.Text = CategoryModel.Name;
            txtCode.Text = CategoryModel.Code;

            if (IsEditMode.HasValue && IsEditMode.Value)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                drpDownSubCategories.Enabled = true;

                LoadSubCategories(default(Nullable<int>));

                drpDownSubCategories.SelectedValue = CategoryModel.ParentCategoryId.ToString();
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }

            if (MainCategoryId.HasValue) drpDownCategories.SelectedValue = MainCategoryId.Value.ToString();
            else drpDownCategories.SelectedValue = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveCategory(); }

        private void ClearForm()
        {
            txtName.Text = txtCode.Text = string.Empty;
        }

        private void GetCategoryModel()
        {
            if (CategoryToBeEdited > 0) CategoryModel = QualificationsController.GetChildCategoryById(CategoryToBeEdited);
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

        public Nullable<int> ParentSubCategoryId
        {
            get { return GetPropertyValue<Nullable<int>>("ParentSubCategoryId", default(Nullable<int>)); }
            set
            {
                SetPropertyValue<Nullable<int>>("ParentSubCategoryId", value);               
            }
        }

        public Nullable<int> MainCategoryId
        {
            get { return GetPropertyValue<Nullable<int>>("MainCategoryId", default(Nullable<int>)); }
            set { SetPropertyValue<Nullable<int>>("MainCategoryId", value); }
        }

        protected void drpDownCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpDownSubCategories.Enabled = true;
            drpDownSubCategories.Items.Clear();

            int selectedCategoryId = int.Parse(drpDownCategories.SelectedValue);

            if (selectedCategoryId > 0) LoadSubCategories(selectedCategoryId);
            else
            {
                drpDownSubCategories.Items.Clear();
            }
        }

        private void LoadSubCategories(int? selectedCategoryId)
        {
            try
            {
                int totalRecords = 0;
                List<CategoryDataContract> source = new List<CategoryDataContract>();
                source.AddRange(QualificationsController.GetSubCategories(selectedCategoryId, out totalRecords));

                if (IsEditMode.HasValue && IsEditMode.Value)
                {
                    CategoryDataContract selectedSubCategory = source.Find(i => i.Id == CategoryModel.ParentCategoryId);
                    if (selectedSubCategory != null) MainCategoryId = selectedSubCategory.ParentCategoryId;
                }
                else
                {
                    source.Insert(0, new CategoryDataContract { Id = 0, Name = "Select" });
                }

                drpDownSubCategories.DataTextField = "Name";
                drpDownSubCategories.DataValueField = "Id";
                drpDownSubCategories.DataSource = source;
                drpDownSubCategories.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load sub categories";
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

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageChildCategories); } 
    }
}