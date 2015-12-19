using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.TestimonialsManagement;

namespace Datacontracts.TestimonialsManagement
{
    [DataContract, Serializable]
    public class TestimonialDataContract : ITestimonial
    {
        [DataMember]
        public int Id { get; set; }       
        [DataMember]
        public int? SectionId { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }
    }
}
