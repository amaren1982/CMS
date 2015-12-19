using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.TestimonialsManagement
{
    public class GetTestimonialByIdRequestManager
    {
        private int testimonialId;
        private TechKritiCMSEntities dbContext = null;

        public GetTestimonialByIdRequestManager(int testimonialId)
        {
            this.testimonialId = testimonialId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response
        {
            public Testimonial Testimonial { get; set; }
            public List<TestimonialAttachment> Attachments { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidaTestimonialQuery = from testimonial in dbContext.Testimonials
                                    where testimonial.Id == this.testimonialId
                                    select testimonial;            
            var candidateAttachments = from attachments in dbContext.TestimonialAttachments
                                       where attachments.TestimonialId == this.testimonialId
                                       select attachments;

            Testimonial candidateTestimonial = candidaTestimonialQuery.First();

            response.Testimonial = candidateTestimonial;
            response.Attachments = candidateAttachments.ToList();

            return response;
        }
    }
}
