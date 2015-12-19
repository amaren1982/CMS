using Bussiness.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TestimonialsManagement;

namespace Bussiness.Entities.TestimonialsManagement
{
    public class TestimonialSearchFilter : PagedFilter, ITestimonialSearchFilter
    {        
        public int SectionId { get; set; }
        public string DisplayName { get; set; }
        public int CreatedBy { get; set; }
    }
}
