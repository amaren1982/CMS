using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.TestimonialsManagement
{
    [DataContract]
    public class GetTestimonialByIdRequest
    {
        [DataMember]
        public int TestimonialId { get; set; }
    }
}
