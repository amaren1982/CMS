using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Datacontracts.TestimonialsManagement;
using Datacontracts.AttachmentsManagement;
using System.IO;
using Common.UserManagement;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.Attachments;
using Techkriti.Common.Controllers.Testimonials;
using Datacontracts.SectionManagement;
using Common.SectionManagement;

namespace TechKriti.CMS.Client.Web.Views.Testimonial
{
    public partial class AddTestimonial : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddTestimonial; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateTestimonialId = Request.Params["testimonialId"];

                if (!string.IsNullOrEmpty(candidateTestimonialId))
                {
                    int result;
                    if (int.TryParse(candidateTestimonialId, out result))
                    {
                        TestimonialToBeEdited = result;
                        IsEditMode = true;
                    }
                }
                
                LoadSections();
                GetTestimonialModel();
                BuildView();
            }
        }

        private void BuildView()
        {
            txtDisplayName.Text = TestimonialModel.DisplayName;            
            drpDownSections.SelectedValue = TestimonialModel.SectionId.ToString();

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

        private void LoadSections()
        {
            try
            {
                List<SectionDataContract> source = new List<SectionDataContract>();

                drpDownSections.DataTextField = "Name";
                drpDownSections.DataValueField = "Id";

                if (! (IsEditMode.HasValue && IsEditMode.Value) )
                {
                    source.Add(new SectionDataContract { Id = 0, Name = "Select" });
                }

                source.AddRange(TestimonialsController.LoadSectionsForTestimonials());
                drpDownSections.DataSource = source;
                drpDownSections.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load Sections";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveTestimonial(); }

        private List<AttachmentDataContract> UploadAttachments()
        {
            try
            {
                BaseAttachmentsController uploader = new TestimonialsAttachmentsController(uploadGallery);
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

            List<string> validEtension = new List<string> { ".pdf" };

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

        private void SaveTestimonial()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                if (!ValidateUpload())
                {
                    lblStatus.Text = "Only PDFs allowed...";
                    lblStatus.Visible = true;

                    return;
                }

                BuildNewsRequest();
                List<AttachmentDataContract> uploadedAttachments = UploadAttachments();

                isCreated = TestimonialsController.SaveTestimonial(TestimonialModel, uploadedAttachments);

                if (isCreated) { lblStatus.Text = "Testimonial saved successfully"; }
                else lblStatus.Text = "Failed to save Testimonial";

                ClearForm();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save Testimonial" + ex.Message;
            }
        }

        private void BuildNewsRequest()
        {
            TestimonialModel.DisplayName = txtDisplayName.Text;           
            TestimonialModel.SectionId = int.Parse(drpDownSections.SelectedValue);
        }

        private void ClearForm()
        {
            txtDisplayName.Text = string.Empty;           
            pnlAttachments.Visible = false;
        }

        private void GetTestimonialModel()
        {
            List<AttachmentDataContract> attachments = new List<AttachmentDataContract>();

            if (TestimonialToBeEdited > 0) TestimonialModel = TestimonialsController.GetTestimonialById(TestimonialToBeEdited, out attachments);
            else TestimonialModel = new TestimonialDataContract();

            repeaterAttachments.DataSource = attachments;
            repeaterAttachments.DataBind();
        }

        public int TestimonialToBeEdited
        {
            get { return GetPropertyValue<int>("TestimonialToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("TestimonialToBeEdited", value); }
        }

        public TestimonialDataContract TestimonialModel
        {
            get { return GetPropertyValue<TestimonialDataContract>("TestimonialModel", null); }
            set { SetPropertyValue<TestimonialDataContract>("TestimonialModel", value); }
        }

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageTestimonials); }

        protected void OkButtonPopUp_Click(object sender, EventArgs e)
        {
            bool success = SaveSection(txtSectionName.Text, SectionType.Testimonials);
            txtSectionName.Text = string.Empty;

            if (success) LoadSections();
        }
    }
}