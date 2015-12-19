using Common.UserManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.Sectors;

namespace TechKriti.CMS.Client.Web.Views.Sectors
{
    public partial class AddSector : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddSector; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateSectorId = Request.Params["sectorId"];

                if (!string.IsNullOrEmpty(candidateSectorId))
                {
                    int result;
                    if (int.TryParse(candidateSectorId, out result))
                    {
                        SectorToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetSectorModel();
                BuildView();
            }
        }

        private void BuildView()
        {
            txtDisplayName.Text = SectorModel.DisplayName;
            txtPath.Text = SectorModel.Path;
            drpDownSections.SelectedValue = SectorModel.SectionId.ToString();

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

        protected void btnSave_Click(object sender, EventArgs e) { SaveSector(); }

        private void SaveSector()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildNewsRequest();
                isCreated = SectorsController.SaveSector(SectorModel);

                if (isCreated) { lblStatus.Text = "Sector saved successfully"; }
                else lblStatus.Text = "Failed to save sector";

                ClearForm();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save sector";
            }
        }

        private void BuildNewsRequest()
        {
            SectorModel.DisplayName = txtDisplayName.Text;
            SectorModel.Path = txtPath.Text;
            SectorModel.SectionId = int.Parse( drpDownSections.SelectedValue );
        }

        private void ClearForm()
        {
            txtDisplayName.Text = txtPath.Text = string.Empty;
            drpDownSections.SelectedValue = "";
        }

        private void GetSectorModel()
        {
            if (SectorToBeEdited > 0) SectorModel = SectorsController.GetSectorById(SectorToBeEdited);
            else SectorModel = new SectorDataContract();
        }

        public int SectorToBeEdited
        {
            get { return GetPropertyValue<int>("SectorToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("SectorToBeEdited", value); }
        }

        public SectorDataContract SectorModel
        {
            get { return GetPropertyValue<SectorDataContract>("SectorModel", null); }
            set { SetPropertyValue<SectorDataContract>("SectorModel", value); }
        }

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageSectors); }        
    }
}