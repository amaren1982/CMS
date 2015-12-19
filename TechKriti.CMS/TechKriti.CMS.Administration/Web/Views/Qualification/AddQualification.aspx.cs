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
            LoadSubCategories( default(Nullable<int>) );

            txtDescription.Text = QualificationModel.Description;           
            drpDownSubCategory.SelectedValue = QualificationModel.SubCategoryId.ToString();

            if (ParentCategoryId.HasValue) drpDownCategories.SelectedValue = ParentCategoryId.Value.ToString();
            else drpDownCategories.SelectedValue = "0";

            if (IsEditMode.HasValue && IsEditMode.Value)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;               
                drpDownSubCategory.Enabled = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
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
            QualificationModel.SubCategoryId = int.Parse(drpDownSubCategory.SelectedValue);
        }

        private void ClearForm()
        {
            txtDescription.Text = string.Empty;
            drpDownCategories.SelectedValue = drpDownSubCategory.SelectedValue = "0";
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

        public Nullable<int> ParentCategoryId
        {
            get { return GetPropertyValue<Nullable<int>>("ParentCategoryId", default(Nullable<int>)); }
            set { SetPropertyValue<Nullable<int>>("ParentCategoryId", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageQualifications); }

        protected void drpDownCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpDownSubCategory.Enabled = true;
            int selectedCategoryId = int.Parse(drpDownCategories.SelectedValue);
            if (selectedCategoryId > 0) LoadSubCategories(selectedCategoryId);
            else
            {
                drpDownSubCategory.Items.Clear();
            }
        }

        private void LoadSubCategories(int? selectedCategoryId)
        {
            try
            {
                List<CategoryDataContract> source = new List<CategoryDataContract>();
                source.Add(new CategoryDataContract { Id = 0, Name = "Select" });               

                drpDownSubCategory.DataTextField = "Name";
                drpDownSubCategory.DataValueField = "Id";
               
                source.AddRange( QualificationsController.GetSubCategories(selectedCategoryId) );
                drpDownSubCategory.DataSource = source;
                drpDownSubCategory.DataBind();

                if (IsEditMode.HasValue && IsEditMode.Value)
                {
                    CategoryDataContract selectedParentCategory = source.Find(i => i.Id == QualificationModel.SubCategoryId);
                    if (selectedParentCategory != null) ParentCategoryId = selectedParentCategory.ParentCategoryId;
                }

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