using Bussiness.Entities.Paging;
using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TestimonialsManagement;

namespace Bussiness.Entities.TestimonialsManagement
{
    public class Testimonial : ITestimonial
    {
        public int Id { get; set; }       
        public int? SectionId { get; set; }
        public string DisplayName { get; set; }
        public int? CreatedBy { get; set; }
    }
}
