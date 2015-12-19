using Common.UserManagement;
using Datacontracts.QualificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.Qualification;

namespace TechKriti.CMS.Client.Web.Views.Qualification
{
    public partial class AddQualification : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddQualification; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateQualificationId = Request.Params["qualificationId"];

                if (!string.IsNullOrEmpty(candidateQualificationId))
                {
                    int result;
                    if (int.TryParse(candidateQualificationId, out result))
                    {
                        QualificationToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetDownloadModel();

                LoadCategories();               
                BuildView();
            }
        }

        private void BuildView()
        {
            LoadCategories();
          
            if (IsEditMode.HasValue && IsEditMode.Value)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;               
                drpDownSubCategory.Enabled = true;
                drpDownChildCategory.Enabled = true;

                LoadChildCategories(QualificationModel.Category.ParentCategoryId);              
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }

            txtDescription.Text = QualificationModel.Description;
             drpDownChildCategory.SelectedValue = QualificationModel.ChildCategoryId.ToString();

            if (ParentSubCategoryId.HasValue) drpDownSubCategory.SelectedValue = ParentSubCategoryId.Value.ToString();
            else drpDownSubCategory.SelectedValue = "0";

            if (MainCategoryId.HasValue) drpDownCategories.SelectedValue = MainCategoryId.Value.ToString();
            else drpDownCategories.SelectedValue = "0";
        }       

        protected void btnSave_Click(object sender, EventArgs e) { SaveDownload(); }

        private void SaveDownload()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildNewsRequest();
                isCreated = QualificationsController.SaveQualification(QualificationModel);

                if (isCreated) { lblStatus.Text = "Qualification saved successfully"; }
                else lblStatus.Text = "Failed to save Qualification";

                ClearForm();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save Qualification";
            }
        }

        private void BuildNewsRequest()
        {
            QualificationModel.Description = txtDescription.Text;
            QualificationModel.ChildCategoryId = int.Parse(drpDownChildCategory.SelectedValue);
        }

        private void ClearForm()
        {
            txtDescription.Text = string.Empty;
            drpDownCategories.Items.Clear();
            drpDownSubCategory.Items.Clear();
            drpDownChildCategory.Items.Clear();
        }

        private void GetDownloadModel()
        {
            if (QualificationToBeEdited > 0) QualificationModel = QualificationsController.GetQualificationById(QualificationToBeEdited);
            else QualificationModel = new QualificationDataContract();
        }

        public int QualificationToBeEdited
        {
            get { return GetPropertyValue<int>("QualificationToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("QualificationToBeEdited", value); }
        }

        public QualificationDataContract QualificationModel
        {
            get { return GetPropertyValue<QualificationDataContract>("QualificationModel", null); }
            set { SetPropertyValue<QualificationDataContract>("QualificationModel", value); }
        }

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        public Nullable<int> ParentSubCategoryId
        {
            get { return GetPropertyValue<Nullable<int>>("ParentSubCategoryId", default(Nullable<int>)); }
            set 
            { 
                SetPropertyValue<Nullable<int>>("ParentSubCategoryId", value);
                LoadSubCategories(default(Nullable<int>));
            }
        }

        public Nullable<int> MainCategoryId
        {
            get { return GetPropertyValue<Nullable<int>>("MainCategoryId", default(Nullable<int>)); }
            set { SetPropertyValue<Nullable<int>>("MainCategoryId", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageQualifications); }

        protected void drpDownCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpDownSubCategory.Enabled = true;
            drpDownChildCategory.Enabled = false;
            drpDownChildCategory.Items.Clear();
            int selectedCategoryId = int.Parse(drpDownCategories.SelectedValue);
            if (selectedCategoryId > 0) LoadSubCategories(selectedCategoryId);
            else
            {
                drpDownSubCategory.Items.Clear();
            }
        }

        protected void drpDownSubCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpDownChildCategory.Enabled = true;
            int selectedCategoryId = int.Parse(drpDownSubCategory.SelectedValue);
            if (selectedCategoryId > 0) LoadChildCategories(selectedCategoryId);
            else
            {
                drpDownChildCategory.Items.Clear();
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
                    CategoryDataContract selectedSubCategory = source.Find(i => i.Id == ParentSubCategoryId);
                    if (selectedSubCategory != null) MainCategoryId = selectedSubCategory.ParentCategoryId;
                }
                else
                {
                    source.Insert(0, new CategoryDataContract { Id = 0, Name = "Select" });
                }

                drpDownSubCategory.DataTextField = "Name";
                drpDownSubCategory.DataValueField = "Id";
                drpDownSubCategory.DataSource = source;
                drpDownSubCategory.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load categories";
            }
        }

        private void LoadChildCategories(int? selectedCategoryId)
        {
            try
            {
                int totalRecords = 0;
                List<CategoryDataContract> source = new List<CategoryDataContract>();
                
                drpDownChildCategory.DataTextField = "Name";
                drpDownChildCategory.DataValueField = "Id";

                source.AddRange(QualificationsController.GetChildCategories(selectedCategoryId, out totalRecords));

                if (IsEditMode.HasValue && IsEditMode.Value)
                {                    
                    if (source.Any())
                    {
                        CategoryDataContract selectedChildCategory = source.Find(i => i.Id == QualificationModel.ChildCategoryId);
                        if (selectedChildCategory != null) ParentSubCategoryId = selectedChildCategory.ParentCategoryId;
                    }
                    else
                    {
                        source.Insert(0, new CategoryDataContract { Id = 0, Name = "No child category exists" });
                    }
                }
                else
                {                   
                    source.Insert(0, new CategoryDataContract { Id = 0, Name = "Select" });
                }

                drpDownChildCategory.DataSource = source;
                drpDownChildCategory.DataBind();               

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load categories";
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
                source.AddRange( QualificationsController.GetCategories() );
                drpDownCategories.DataSource = source;
                drpDownCategories.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load categories";
            }
        }
    }
}