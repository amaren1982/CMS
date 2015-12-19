using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContracts.Downloads;
using System.IO;
using Datacontracts.AttachmentsManagement;
using Common.UserManagement;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.Downloads;
using Techkriti.Common.Controllers.Attachments;

namespace TechKriti.CMS.Client.Web.Views.Downloads
{
    public partial class AddDownload : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddDownload; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateDownloadId = Request.Params["downloadId"];

                if (!string.IsNullOrEmpty(candidateDownloadId))
                {
                    int result;
                    if (int.TryParse(candidateDownloadId, out result))
                    {
                        DownloadToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetDownloadModel();
                BuildView();
            }
        }

        private void BuildView()
        {
            txtDisplayName.Text = DownloadModel.DisplayName;           
            drpDownSections.SelectedValue = DownloadModel.SectionId.ToString();
            chkIsActive.Checked = DownloadModel.IsActive.HasValue ? DownloadModel.IsActive.Value : false;

            if (IsEditMode.HasValue && IsEditMode.Value)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                pnlAttachments.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        private List<AttachmentDataContract> UploadAttachments()
        {
            try
            {
                BaseAttachmentsController uploader = new DownloadsAttachmentsController(uploadGallery);
                return uploader.Upload();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool ValidateUpload()
        {
            bool isValid = true;

            List<string> validEtension = new List<string> { ".pdf"};

            if (uploadGallery.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in uploadGallery.PostedFiles)
                {
                    string ext = Path.GetExtension(uploadedFile.FileName).ToLower();

                    if (!validEtension.Any(item => item == ext))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveDownload(); }

        private void SaveDownload()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                if (!ValidateUpload())
                {
                    lblStatus.Text = "Not an valid pdf file...";
                    lblStatus.Visible = true;

                    return;
                }

                BuildNewsRequest();
                List<AttachmentDataContract> uploadedAttachments = UploadAttachments();
                isCreated = DownloadsController.SaveDownload(DownloadModel, uploadedAttachments);

                if (isCreated) { lblStatus.Text = "Download saved successfully"; }
                else lblStatus.Text = "Failed to save Download";

                ClearForm();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save Download";
            }
        }

        private void BuildNewsRequest()
        {
            DownloadModel.DisplayName = txtDisplayName.Text;          
            DownloadModel.SectionId = int.Parse(drpDownSections.SelectedValue);
            DownloadModel.IsActive = chkIsActive.Checked;
        }

        private void ClearForm()
        {
            txtDisplayName.Text = string.Empty;
            drpDownSections.SelectedValue = "";
            pnlAttachments.Visible = false;
        }

        private void GetDownloadModel()
        {
            List<AttachmentDataContract> attachments = new List<AttachmentDataContract>();

            if (DownloadToBeEdited > 0) DownloadModel = DownloadsController.GetDownloadById(DownloadToBeEdited, out attachments);
            else DownloadModel = new DownloadsDataContract();

            repeaterAttachments.DataSource = attachments;
            repeaterAttachments.DataBind();
        }

        public int DownloadToBeEdited
        {
            get { return GetPropertyValue<int>("DownloadToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("DownloadToBeEdited", value); }
        }

        public DownloadsDataContract DownloadModel
        {
            get { return GetPropertyValue<DownloadsDataContract>("DownloadModel", null); }
            set { SetPropertyValue<DownloadsDataContract>("DownloadModel", value); }
        }

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageDownloads); }
    }
}