using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.PhotoGallery;
using Datacontracts.SectionManagement;
using Techkriti.Common.Controllers.Testimonials;

namespace TechKriti.CMS.Client.Web.Views.PhotoGallery
{
    public partial class ManagePhotoGallery : BasePage
    {
        public const string EditCommandName = "EditPhotoGallery";
        public const string DeleteCommandName = "DeletePhotoGallery";

        public override Permissions RequiredActionPermission { get { return Permissions.ManagePhotoGallery; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            if (!Page.IsPostBack) 
            {
                linkPhotoGallery.NavigateUrl = Pages.AddPhotoGallery;
                RefreshTestimonials(0);
                LoadSections();
            }          
        }

        private void LoadSections()
        {
            try
            {
                List<SectionDataContract> source = new List<SectionDataContract>();

                drpDownSections.DataTextField = "Name";
                drpDownSections.DataValueField = "Id";

                source.Add(new SectionDataContract { Id = 0, Name = "Select" });

                source.AddRange(TestimonialsController.LoadSectionsForPhotoGallery());
                drpDownSections.DataSource = source;
                drpDownSections.DataBind();

            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load sections";
            }
        }

        private void RefreshTestimonials(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;
                int sectionId = 0;
                if (!string.IsNullOrEmpty(drpDownSections.SelectedValue)) sectionId = int.Parse(drpDownSections.SelectedValue);

                this.gridPhotoGallery.DataSource =
                PhotoGalleryController.SearchPhotoGalleries(txtDisplayName.Text, startIndex, PageSize, sectionId, out totalNumberOfRecords);

                this.gridPhotoGallery.VirtualItemCount = totalNumberOfRecords;
                this.gridPhotoGallery.DataBind();
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
            }
            catch (Exception e)
            {
                lblStatus.Text = "Failed to get Testimonials";
                lblStatus.Visible = true;
            }
        }

        protected void gridPhotoGallery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int photoGalleryid = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName) Response.Redirect(Pages.AddPhotoGallery + "?photoGalleryid=" + photoGalleryid);
            else if (e.CommandName == DeleteCommandName) DeletePhotoGallery(photoGalleryid);
        }

        private void DeletePhotoGallery(int photoGalleryid)
        {
            try
            {
                lblStatus.Visible = true;

                bool isDeleted = PhotoGalleryController.DeletePhotoGallery(photoGalleryid);

                if (isDeleted)
                {
                    RefreshTestimonials(0);
                    lblStatus.Text = "Photo gallery deleted successfully";
                }
                else lblStatus.Text = "Failed to delete Photo gallery";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete Photo gallery";
            }
        }

        protected void gridPhotoGallery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridPhotoGallery.PageIndex = e.NewPageIndex;

            RefreshTestimonials(startIndex);
        }

        protected void btnPhotoGallerySearch_Click(object sender, EventArgs e) { RefreshTestimonials(0); }

        private int PageSize { get { return this.gridPhotoGallery.PageSize; } }
    }
}