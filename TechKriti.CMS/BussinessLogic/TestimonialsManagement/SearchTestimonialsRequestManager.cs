using Common.NewsManagement;
using Common.SectorsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TestimonialsManagement;

namespace BussinessLogic.TestimonialsManagement
{
    public class SearchTestimonialsRequestManager
    {
        ITestimonialSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchTestimonialsRequestManager(ITestimonialSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<Testimonial> Testimonials { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateSectorsQuery = from testimonial in dbContext.Testimonials
                                        select testimonial;

            var countQuery = from testimonial in dbContext.Testimonials
                             select testimonial;

            // filter the list if needed
            if (! string.IsNullOrEmpty( this.filter.DisplayName) )
            {
                candidateSectorsQuery = candidateSectorsQuery.Where(item => item.DisplayName.Contains(this.filter.DisplayName));
                countQuery = countQuery.Where(item => item.DisplayName.Contains(this.filter.DisplayName));
            }           

            //// filter the list if needed
            if ( this.filter.SectionId > 0 )
            {
                candidateSectorsQuery = candidateSectorsQuery.Where(item => item.SectionId == this.filter.SectionId );
                countQuery = countQuery.Where(item => item.SectionId == this.filter.SectionId );
            }          

            // paginate
            candidateSectorsQuery = candidateSectorsQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                        Take(this.filter.Count.Value);

            // execute the query 
            List<Testimonial> candidateSectors = candidateSectorsQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();

            response.Testimonials = candidateSectors;

            return response;
        }
    }
}
