using Common.UserManagement;
using Datacontracts.CurrentOpeningManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.CurrentOpening;

namespace TechKriti.CMS.Client.Web.Views.CurrentOpenings
{
    public partial class AddCurrentOpening : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddCurrentOpening; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateNewsId = Request.Params["currentOpeningId"];

                if (!string.IsNullOrEmpty(candidateNewsId))
                {
                    int result;
                    if (int.TryParse(candidateNewsId, out result))
                    {
                        CurrentOpeningToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetNewsModel();
                BuildView();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveCurrentOpening(); }

        private void BuildView()
        {
            txtCompany.Text = CurrentOpeningModel.Company;
            chkIsActive.Checked = CurrentOpeningModel.IsActive.HasValue ? CurrentOpeningModel.IsActive.Value : false;
            txtEmailPhone.Text = CurrentOpeningModel.Email;
            txtPosition.Text = CurrentOpeningModel.Position;
            txtQualification.Text = CurrentOpeningModel.Qualification;
            txtSkillSet.Text = CurrentOpeningModel.SkillSet;

            if (CurrentOpeningModel.OpenTillDate != null) txtOpenTillDate.Text = CurrentOpeningModel.OpenTillDate.ToString();

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

        private void BuildCurrentOpeningRequest()
        {
            DateTime result;
            DateTime? openTillDate;

            if (DateTime.TryParse(txtOpenTillDate.Text, out result)) openTillDate = result;
            else openTillDate = null;

            CurrentOpeningModel.Company = txtCompany.Text;
            CurrentOpeningModel.IsActive = chkIsActive.Checked;
            CurrentOpeningModel.Email = txtEmailPhone.Text;
            CurrentOpeningModel.OpenTillDate = openTillDate;
            CurrentOpeningModel.Position = txtPosition.Text;
            CurrentOpeningModel.Qualification = txtQualification.Text;
            CurrentOpeningModel.SkillSet = txtSkillSet.Text;
        }

        private void SaveCurrentOpening()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildCurrentOpeningRequest();
                isCreated = CurrentOpeningController.Save(CurrentOpeningModel);

                if (isCreated) { lblStatus.Text = "Current opening saved successfully"; }
                else lblStatus.Text = "Failed to save Current opening";

                ClearForm();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save Current opening";
            }
        }

        private void ClearForm()
        {
            txtCompany.Text = txtEmailPhone.Text = txtPosition.Text= txtOpenTillDate.Text = txtSkillSet.Text = txtQualification.Text = string.Empty;
            chkIsActive.Checked = false;  
        }

        private void GetNewsModel()
        {
            if (CurrentOpeningToBeEdited > 0) CurrentOpeningModel = CurrentOpeningController.GetCurrentOpeningById(CurrentOpeningToBeEdited);
            else CurrentOpeningModel = new CurrentOpeningDataContract();
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageCurrentOpenings); }    

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        public int CurrentOpeningToBeEdited
        {
            get { return GetPropertyValue<int>("CurrentOpeningToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("CurrentOpeningToBeEdited", value); }
        }

        public CurrentOpeningDataContract CurrentOpeningModel
        {
            get { return GetPropertyValue<CurrentOpeningDataContract>("CurrentOpeningModel", null); }
            set { SetPropertyValue<CurrentOpeningDataContract>("CurrentOpeningModel", value); }
        }  
    }
}