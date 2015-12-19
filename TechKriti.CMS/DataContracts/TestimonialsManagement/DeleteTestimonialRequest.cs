using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.TestimonialsManagement
{
    [DataContract]
    public class DeleteTestimonialRequest
    {
        [DataMember]
        public int TestimonialID { get; set; }
    }
}
