using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Entities.TestimonialsManagement;
using Common.SectorsManagement;
using Common.TestimonialsManagement;
using Datacontracts.TestimonialsManagement;

namespace ServiceImplementation.Extensions.TestimonialsManagement
{
    public static class TestimonialsManagementExtensions
    {
        public static List<TestimonialDataContract> ToDataContract(this List<DAL.Datamodel.Testimonial> items)
        {
            List<TestimonialDataContract> dc = new List<TestimonialDataContract>();

            items.ForEach( item => dc.Add( item.ToDataContract()) );

            return dc;
        }

        public static TestimonialDataContract ToDataContract(this DAL.Datamodel.Testimonial item)
        {
            TestimonialDataContract dc = new TestimonialDataContract();

            dc.DisplayName = item.DisplayName;
            dc.Id = item.Id;          
            dc.SectionId = item.SectionId;

            return dc;
        }

        public static ITestimonial ToBussinessEntity(this TestimonialDataContract item)
        {
            ITestimonial bo = new Testimonial();

            bo.DisplayName = item.DisplayName;
            bo.Id = item.Id;          
            bo.SectionId = item.SectionId;            

            return bo;
        }

        public static ITestimonialSearchFilter ToFilter(this TestimonialSearchFilterDataContract item)
        {
            ITestimonialSearchFilter filter = new TestimonialSearchFilter();

            filter.Count = item.Count;
            filter.CreatedBy = item.CreatedBy;
            filter.DisplayName = item.DisplayName;          
            filter.SectionId = item.SectionId;
            filter.StartIndex = item.StartIndex;

            return filter;
        }
    }
}
