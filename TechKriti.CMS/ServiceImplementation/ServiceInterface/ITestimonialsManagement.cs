using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.TestimonialsManagement;

namespace ServiceInterface
{
   [ServiceContract]
    public interface ITestimonialManagement
    {
       [OperationContract]
       EmptyResponse CreateTestimonial(CreateTestimonialRequest request);

       [OperationContract]
       EmptyResponse UpdateTestimonial(UpdateTestimonialRequest request);

       [OperationContract]
       EmptyResponse DeleteTestimonial(DeleteTestimonialRequest request);

       [OperationContract]
       GetTestimonialByIdResponse GetTestimonialById(GetTestimonialByIdRequest request);

       [OperationContract]
       SearchTestimonialsResponse SearchTestimonials(SearchTestimonialsRequest request);
    }
}
