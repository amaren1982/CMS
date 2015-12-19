using Common.UserManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.Sectors;
using Techkriti.Common.Controllers.Attachments;
using Datacontracts.AttachmentsManagement;
using Techkriti.Common.Extensions.List;

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
                LoadParentSectors();
                BuildView();
            }
        }

        private void BuildView()
        {
            txtSectorName.Text = SectorModel.SectorName;
            pnlUpoadAttachments.Visible = false;
            if (SectorModel.ParentSectorId.HasValue) drpDownParentSectors.SelectedValue = SectorModel.ParentSectorId.Value.ToString();

            if (IsEditMode.HasValue && IsEditMode.Value)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                if (SectorModel.ParentSectorId.HasValue && SectorModel.ParentSectorId.Value > 0) pnlUpoadAttachments.Visible = true;
                BuildAttachmentUI();
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        private void BuildAttachmentUI()
        {
            if (SectorAttachments.Any())
            {
                List<AttachmentDataContract> existingAttachments = SectorAttachments.OrderBy(item => item.AttachmentId).ToList();

                AttachmentDataContract attachmentFirst = existingAttachments.FirstOrDefault();
                imgAttachment1.Visible = true;
                imgAttachment1.ImageUrl = attachmentFirst.AttachmentPath;
                txtCaptionAttachment1.Text = attachmentFirst.AttachmentCaption;
                if (! string.IsNullOrEmpty( attachmentFirst.AttachmentPath ) ) uploadSectorAttachment1.Visible = false;

                AttachmentDataContract attachmentSecond = existingAttachments.Second();
                if (attachmentSecond != null)
                {
                    imgAttachment2.Visible = true;
                    imgAttachment2.ImageUrl = attachmentSecond.AttachmentPath;
                    txtCaptionAttachment2.Text = attachmentSecond.AttachmentCaption;
                    uploadSectorAttachment2.Visible = false;

                    if (! string.IsNullOrEmpty(attachmentSecond.AttachmentPath) ) uploadSectorAttachment2.Visible = false;
                }

                AttachmentDataContract attachmentThird = existingAttachments.Third();
                if (attachmentThird != null)
                {
                    imgAttachment3.Visible = true;
                    imgAttachment3.ImageUrl = attachmentThird.AttachmentPath;
                    txtCaptionAttachment3.Text = attachmentThird.AttachmentCaption;

                    if (!string.IsNullOrEmpty(attachmentThird.AttachmentPath)) uploadSectorAttachment3.Visible = false;
                }

                AttachmentDataContract attachmentFourth = existingAttachments.Fourth();
                if (attachmentFourth != null)
                {
                    imgAttachment4.Visible = true;
                    imgAttachment4.ImageUrl = attachmentFourth.AttachmentPath;
                    txtCaptionAttachment4.Text = attachmentFourth.AttachmentCaption;

                    if (!string.IsNullOrEmpty(attachmentFourth.AttachmentPath)) uploadSectorAttachment4.Visible = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveSector(); }

        protected void drpDownParentSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDownParentSectors.SelectedValue == "0") pnlUpoadAttachments.Visible = false;
            else pnlUpoadAttachments.Visible = true;           
        } 

        private void SaveSector()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                if (!IsSectorHierarchyOK()) return;
                BuildNewsRequest();
                List<AttachmentDataContract> attachmentsToBeUpdated = null;
                List<AttachmentDataContract> attachmentsToBeSaved = UploadAttachments(out attachmentsToBeUpdated);
                isCreated = SectorsController.SaveSector(SectorModel, attachmentsToBeSaved, attachmentsToBeUpdated);

                if (isCreated) { lblStatus.Text = "Sector saved successfully"; }
                else lblStatus.Text = "Failed to save sector";

                ClearForm();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save sector " + ex.Message;
            }
        }

        private bool IsSectorHierarchyOK()
        {
            if (drpDownParentSectors.SelectedValue == "0") return true;

            if (SectorModel.Id == int.Parse(drpDownParentSectors.SelectedValue))
            {
                lblStatus.Text = "Sector cannot be same as assigned as it's own parent sector";
                return false;
            }

            return true;
        }

        private List<AttachmentDataContract> UploadAttachments(out List<AttachmentDataContract> attachmentsToBeUpdated)
        {
            List<AttachmentDataContract> attachmentsToBeSaved = new List<AttachmentDataContract>();
            attachmentsToBeUpdated = new List<AttachmentDataContract>();
            List<AttachmentDataContract> existingAttachments = SectorAttachments.OrderBy(item => item.AttachmentId).ToList();

            BaseAttachmentsController uploader = null;
            try
            {
                if (this.uploadSectorAttachment1.Visible)
                {
                    uploader = new SectorsAttachmentsController(this.uploadSectorAttachment1, txtCaptionAttachment1);
                    attachmentsToBeSaved.AddRange(uploader.Upload());
                }
                else
                {
                    AttachmentDataContract attachmentFirst = existingAttachments.FirstOrDefault();
                    if (attachmentFirst != null)
                    {
                        attachmentFirst.AttachmentCaption = txtCaptionAttachment1.Text;
                        attachmentsToBeUpdated.Add(attachmentFirst);
                    }
                }

                if (this.uploadSectorAttachment2.Visible)
                {
                    uploader = new SectorsAttachmentsController(this.uploadSectorAttachment2, txtCaptionAttachment2);
                    attachmentsToBeSaved.AddRange(uploader.Upload());
                }
                else
                {
                    AttachmentDataContract attachmentSecond = existingAttachments.Second();
                    if (attachmentSecond != null)
                    {
                        attachmentSecond.AttachmentCaption = txtCaptionAttachment2.Text;
                        attachmentsToBeUpdated.Add( attachmentSecond );
                    }
                }

                if (this.uploadSectorAttachment3.Visible)
                {
                    uploader = new SectorsAttachmentsController(this.uploadSectorAttachment3, txtCaptionAttachment3);
                    attachmentsToBeSaved.AddRange(uploader.Upload());
                }
                else
                {
                    AttachmentDataContract attachmentThird = existingAttachments.Third();
                    if (attachmentThird != null)
                    {
                        attachmentThird.AttachmentCaption = txtCaptionAttachment3.Text;
                        attachmentsToBeUpdated.Add(attachmentThird);
                    }
                }

                if ( this.uploadSectorAttachment4.Visible )
                {
                    uploader = new SectorsAttachmentsController( this.uploadSectorAttachment4, txtCaptionAttachment4 );
                    attachmentsToBeSaved.AddRange(uploader.Upload());
                }
                else
                {
                    AttachmentDataContract attachmentFourth = existingAttachments.Fourth();
                    if (attachmentFourth != null)
                    {
                        attachmentFourth.AttachmentCaption = txtCaptionAttachment4.Text;
                        attachmentsToBeUpdated.Add(attachmentFourth);
                    }
                }

                return attachmentsToBeSaved;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BuildNewsRequest()
        {
            SectorModel.SectorName = txtSectorName.Text;
            if (drpDownParentSectors.SelectedValue == "0") SectorModel.ParentSectorId = null;
            else SectorModel.ParentSectorId = int.Parse(drpDownParentSectors.SelectedValue);
        }

        private void ClearForm()
        {
            txtSectorName.Text = string.Empty;
            drpDownParentSectors.SelectedValue = "0";
        }

        private void GetSectorModel()
        {
            if (SectorToBeEdited > 0)
            {
                List<AttachmentDataContract> attachments = null;
                SectorModel = SectorsController.GetSectorById(SectorToBeEdited, out attachments);
                SectorAttachments = attachments;
            }
            else SectorModel = new SectorDataContract();
        }

        private void LoadParentSectors()
        {
            try
            {
                List<SectorDataContract> source = new List<SectorDataContract>();
                source.Add(new SectorDataContract { Id = 0, SectorName = "Select" });

                drpDownParentSectors.DataTextField = "SectorName";
                drpDownParentSectors.DataValueField = "Id";
                source.AddRange( SectorsController.GetParentSectors() );

                drpDownParentSectors.DataSource = source;
                drpDownParentSectors.DataBind();
            }
            catch (Exception e)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load parent sectors";
            }
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

        private List<AttachmentDataContract> SectorAttachments
        {
            get { return GetPropertyValue<List<AttachmentDataContract>>("SectorAttachments", new List<AttachmentDataContract>()); }
            set { SetPropertyValue<List<AttachmentDataContract>>("SectorAttachments", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageSectors); }              
    }
}