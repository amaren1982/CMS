using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.TestimonialsManagement;
using Datacontracts.AttachmentsManagement;

namespace Datacontracts.TestimonialsManagement
{
    [DataContract]
    public class GetTestimonialByIdResponse
    {
        [DataMember]
        public TestimonialDataContract Testimonial { get; set; }

        [DataMember]
        public List<AttachmentDataContract> Attachments { get; set; }
    }
}
