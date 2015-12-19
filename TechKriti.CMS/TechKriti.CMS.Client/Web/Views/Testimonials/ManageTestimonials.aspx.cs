using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.Testimonials;
using Datacontracts.SectorsManagement;
using Datacontracts.SectionManagement;

namespace TechKriti.CMS.Client.Web.Views.Testimonials
{
    public partial class ManageTestimonials : BasePage
    {
        public const string EditCommandName = "EditTestimonial";
        public const string DeleteCommandName = "DeleteTestimonial";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageTestimonials; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;

            if (!Page.IsPostBack) 
            {                
                linkAddTestimonial.NavigateUrl = Pages.AddTestimonial;
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

                source.AddRange(TestimonialsController.LoadSectionsForTestimonials());
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

                this.gridTestimonial.DataSource =
                TestimonialsController.SearchTestimonials(txtDisplayName.Text, startIndex, PageSize, sectionId, out totalNumberOfRecords);

                this.gridTestimonial.VirtualItemCount = totalNumberOfRecords;
                this.gridTestimonial.DataBind();
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
            }
            catch (Exception e)
            {
                lblStatus.Text = "Failed to get Testimonials";
                lblStatus.Visible = true;
            }
        }

        protected void gridTestimonial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int testimonialId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName) Response.Redirect(Pages.AddTestimonial + "?testimonialId=" + testimonialId);
            else if (e.CommandName == DeleteCommandName) DeleteTestimonial(testimonialId);
        }

        private void DeleteTestimonial(int sectorId)
        {
            try
            {
                lblStatus.Visible = true;

                bool isDeleted = TestimonialsController.DeleteTestimonial(sectorId);

                if (isDeleted)
                {
                    RefreshTestimonials(0);
                    lblStatus.Text = "Testimonial deleted successfully";
                }
                else lblStatus.Text = "Failed to delete Testimonial";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete Testimonial";
            }
        }

        protected void gridTestimonial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridTestimonial.PageIndex = e.NewPageIndex;

            RefreshTestimonials(startIndex);
        }

        protected void btnTestimonialSearch_Click(object sender, EventArgs e) { RefreshTestimonials(0); }

        private int PageSize { get { return this.gridTestimonial.PageSize; } }
    }
}