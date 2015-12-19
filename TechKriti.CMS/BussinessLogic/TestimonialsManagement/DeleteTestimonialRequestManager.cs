using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.TestimonialsManagement
{
    public class DeleteTestimonialRequestManager
    {
        private int testimonialID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteTestimonialRequestManager(int testimonialID)
        {
            this.testimonialID = testimonialID;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; }  }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateTestimonialQuery = from testimonial in dbContext.Testimonials
                                            where testimonial.Id == this.testimonialID
                                            select testimonial;

            var candidateAttachments = from attachments in dbContext.TestimonialAttachments
                                       where attachments.TestimonialId == this.testimonialID
                                       select attachments;


            Testimonial candidateSector = candidateTestimonialQuery.First();

            candidateAttachments.ToList().ForEach( item => dbContext.TestimonialAttachments.Remove(item) ); 
            dbContext.Testimonials.Remove(candidateSector);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
