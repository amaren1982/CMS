using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TestimonialsManagement;
using Common.AttachmentsManagement;

namespace BussinessLogic.TestimonialsManagement
{
    public class CreateTestimonialRequestManager
    {       
        ITestimonial testimonialToBeCreated;
        List<IAttachment> attachmentsToBeSaved;
        private TechKritiCMSEntities dbContext = null;

        public CreateTestimonialRequestManager(ITestimonial testimonial, List<IAttachment> attachments)
        {
            this.testimonialToBeCreated = testimonial;
            attachmentsToBeSaved = attachments;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            Testimonial candidateTestimonial = new Testimonial();

            candidateTestimonial.CreatedDate = DateTime.Now;
            candidateTestimonial.DisplayName = testimonialToBeCreated.DisplayName;
            candidateTestimonial.SectionId = testimonialToBeCreated.SectionId;

            dbContext.Testimonials.Add(candidateTestimonial);

            attachmentsToBeSaved.ForEach(item => candidateTestimonial.TestimonialAttachments
                                                                     .Add(new TestimonialAttachment { CreatedDate = DateTime.Now, DownloadPath = item.AttachmentPath }) );
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
