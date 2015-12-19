
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
    public class UpdateTestimonialManager
    {       
        ITestimonial testimonialToBeUpdated;
        List<IAttachment> attachmentsToBeSaved;
        private TechKritiCMSEntities dbContext = null;

        public UpdateTestimonialManager(ITestimonial testimonial,  List<IAttachment> attachments)
        {
            testimonialToBeUpdated = testimonial;
            this.attachmentsToBeSaved = attachments;
 
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateTestimonialsQuery = from sector in dbContext.Testimonials
                                             where sector.Id == this.testimonialToBeUpdated.Id
                                       select sector;

            Testimonial candidateTestimonial = candidateTestimonialsQuery.First();          
            candidateTestimonial.DisplayName = testimonialToBeUpdated.DisplayName;
           
            candidateTestimonial.SectionId = testimonialToBeUpdated.SectionId;
            candidateTestimonial.ModifiedDate = DateTime.Now;

            if (attachmentsToBeSaved.Any())
            {
                var existingAttachments = from attachments in dbContext.TestimonialAttachments
                                          where attachments.TestimonialId == this.testimonialToBeUpdated.Id
                                          select attachments;

                existingAttachments.ToList().ForEach( item => dbContext.TestimonialAttachments.Remove(item) );

                attachmentsToBeSaved.ForEach(item => candidateTestimonial.TestimonialAttachments
                                                                          .Add(new TestimonialAttachment { CreatedDate = DateTime.Now, DownloadPath = item.AttachmentPath })
               );
            }

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
