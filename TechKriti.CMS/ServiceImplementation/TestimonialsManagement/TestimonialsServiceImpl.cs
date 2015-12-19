using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceImplementation.Extensions.TestimonialsManagement;
using Datacontracts.TestimonialsManagement;
using BussinessLogic.TestimonialsManagement;
using ServiceInterface;
using ServiceImplementation.Extensions.AttachmentsManagement;

namespace ServiceInterface.ServiceImplementation.TestimonialsManagement
{
    public class TestimonialsServiceImpl : ITestimonialManagement
    {
        public EmptyResponse CreateTestimonial(CreateTestimonialRequest request)
        {
            try
            {
                CreateTestimonialRequestManager requestManger = new CreateTestimonialRequestManager( request.TestimonialToBeSaved.ToBussinessEntity(),
                                                                                                      request.AttachmentsToBeSaved.ToBussinessEntity() );
                CreateTestimonialRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse UpdateTestimonial(UpdateTestimonialRequest request)
        {
            try
            {
                UpdateTestimonialManager requestManger = new UpdateTestimonialManager( request.TestimonialToBeSaved.ToBussinessEntity(),
                                                                                       request.AttachmentsToBeSaved.ToBussinessEntity() );
                UpdateTestimonialManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse DeleteTestimonial(DeleteTestimonialRequest request)
        {
            try
            {
                DeleteTestimonialRequestManager requestManger = new DeleteTestimonialRequestManager(request.TestimonialID);
                DeleteTestimonialRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetTestimonialByIdResponse GetTestimonialById(GetTestimonialByIdRequest request)
        {
            try
            {
                GetTestimonialByIdRequestManager requestManger = new GetTestimonialByIdRequestManager(request.TestimonialId);
                GetTestimonialByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetTestimonialByIdResponse response = new GetTestimonialByIdResponse();
                response.Testimonial = bllResponse.Testimonial.ToDataContract();
                response.Attachments = bllResponse.Attachments.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public SearchTestimonialsResponse SearchTestimonials(SearchTestimonialsRequest request)
        {
            try
            {
                SearchTestimonialsRequestManager requestManger = new SearchTestimonialsRequestManager( request.Filter.ToFilter() );
                SearchTestimonialsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchTestimonialsResponse response = new SearchTestimonialsResponse();
                response.Testimonials = bllResponse.Testimonials.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }
    }
}
