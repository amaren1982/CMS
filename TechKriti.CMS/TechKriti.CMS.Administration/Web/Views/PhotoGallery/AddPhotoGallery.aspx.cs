using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datacontracts.PhotoGalleryManagement;
using Common.AttachmentsManagement;
using Datacontracts.AttachmentsManagement;
using System.IO;
using Common.UserManagement;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.PhotoGallery;
using Techkriti.Common.Controllers.Attachments;

namespace TechKriti.CMS.Client.Web.Views.PhotoGallery
{
    public partial class AddPhotoGallery : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddPhotoGallery; } }

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                string candidatePhotoGalleryId = Request.Params["photoGalleryid"];

                if (!string.IsNullOrEmpty(candidatePhotoGalleryId))
                {
                    int result;
                    if (int.TryParse(candidatePhotoGalleryId, out result))
                    {
                        PhotoGalleryToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetSectorModel();
                BuildView();
            }
        }

        private void BuildView()
        {
            txtDisplayName.Text = PhotoGalleryModel.DisplayName;           
            drpDownSections.SelectedValue = PhotoGalleryModel.SectionId.ToString();

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

        protected void btnSave_Click(object sender, EventArgs e) { SaveSector(); }

        private List<AttachmentDataContract> UploadAttachments()
        {
            try
            {
                BaseAttachmentsController uploader = new PhotoGalleryAttachmentsController(uploadGallery);
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

            List<string> validEtension = new List<string> { ".jpg",".jpeg",".bmp",".gif",".png",".pdf" };

            if (uploadGallery.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in uploadGallery.PostedFiles)
                {
                    string ext = Path.GetExtension(uploadedFile.FileName).ToLower();

                    if (! validEtension.Any(item => item == ext) )
                    {
                        isValid = false;
                        break;
                    }                   
                }
            }           

            return isValid;
        }

        private void SaveSector()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                if (! ValidateUpload() )
                {
                    lblStatus.Text = "Not an valid image file...";
                    lblStatus.Visible = true;
                    return;
                }

                BuildNewsRequest();
                List<AttachmentDataContract> uploadedAttachments = UploadAttachments();
                isCreated = PhotoGalleryController.SavePhotoGallery(PhotoGalleryModel, uploadedAttachments);

                if (isCreated) { lblStatus.Text = "Photo gallery saved successfully"; }
                else lblStatus.Text = "Failed to save Photo gallery";

                ClearForm();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save Photo gallery";
            }
        }

        private void BuildNewsRequest()
        {
            PhotoGalleryModel.DisplayName = txtDisplayName.Text;           
            PhotoGalleryModel.SectionId = int.Parse(drpDownSections.SelectedValue);
        }

        private void ClearForm()
        {
            txtDisplayName.Text = string.Empty;
            drpDownSections.SelectedValue = "";
            pnlAttachments.Visible = false;
        }

        private void GetSectorModel()
        {
            List<AttachmentDataContract> attachments = new List<AttachmentDataContract>();

            if (PhotoGalleryToBeEdited > 0)
            {
                PhotoGalleryModel = PhotoGalleryController.GetPhotoGalleryById(PhotoGalleryToBeEdited, out attachments);
            }
            else PhotoGalleryModel = new PhotoGalleryDataContract();

            repeaterAttachments.DataSource = attachments;
            repeaterAttachments.DataBind();
        }

        public int PhotoGalleryToBeEdited
        {
            get { return GetPropertyValue<int>("PhotoGalleryToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("PhotoGalleryToBeEdited", value); }
        }

        public PhotoGalleryDataContract PhotoGalleryModel
        {
            get { return GetPropertyValue<PhotoGalleryDataContract>("PhotoGalleryModel", null); }
            set { SetPropertyValue<PhotoGalleryDataContract>("PhotoGalleryModel", value); }
        }

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }       

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManagePhotoGallery); }        
    }
}