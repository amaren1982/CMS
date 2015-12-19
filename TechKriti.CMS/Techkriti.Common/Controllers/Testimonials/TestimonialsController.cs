using Datacontracts.Misc;
using Datacontracts.NewsManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datacontracts.TestimonialsManagement;
using Datacontracts.AttachmentsManagement;
using Techkriti.Common.Proxy;
using Datacontracts.SectionManagement;
using Common.SectionManagement;

namespace Techkriti.Common.Controllers.Testimonials
{
    public class TestimonialsController
    {
        public static bool SaveTestimonial(TestimonialDataContract testimonialToBeSaved, List<AttachmentDataContract> attachments)
        {
            try
            {
                if (testimonialToBeSaved.Id > 0) return UpdateTestimonial(testimonialToBeSaved, attachments);
                else return AddTestimonial(testimonialToBeSaved, attachments);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddTestimonial(TestimonialDataContract testimonialToBeSaved, List<AttachmentDataContract> attachments)
        {
            CreateTestimonialRequest request = new CreateTestimonialRequest();
            EmptyResponse response = null;
            request.TestimonialToBeSaved = testimonialToBeSaved;
            request.AttachmentsToBeSaved = attachments;

            using (TestimonialsManagementClient client = ProxyFactory.CreateTestimonialsManagementProxy())
            {
                response = client.ServiceChannel.CreateTestimonial(request);
            }

            return response.Success;
        }

        public static bool UpdateTestimonial(TestimonialDataContract testimonialToBeUpdated, List<AttachmentDataContract> attachments)
        {
            UpdateTestimonialRequest request = new UpdateTestimonialRequest();
            request.TestimonialToBeSaved = testimonialToBeUpdated;
            request.AttachmentsToBeSaved = attachments;

            EmptyResponse response = null;

            using (TestimonialsManagementClient client = ProxyFactory.CreateTestimonialsManagementProxy())
            {
                response = client.ServiceChannel.UpdateTestimonial(request);
            }

            return response.Success;
        }

        public static bool DeleteTestimonial(int testimonialId)
        {
            try
            {
                DeleteTestimonialRequest request = new DeleteTestimonialRequest();
                EmptyResponse response = null;
                request.TestimonialID = testimonialId;

                using (TestimonialsManagementClient client = ProxyFactory.CreateTestimonialsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteTestimonial(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static TestimonialDataContract GetTestimonialById(int testimonialId, out  List<AttachmentDataContract> attachments)
        {
            GetTestimonialByIdResponse response = null;
            try
            {
                GetTestimonialByIdRequest request = new GetTestimonialByIdRequest();
                request.TestimonialId = testimonialId;

                using (TestimonialsManagementClient client = ProxyFactory.CreateTestimonialsManagementProxy())
                {
                    response = client.ServiceChannel.GetTestimonialById(request);
                }

                attachments = response.Attachments;
                return response.Testimonial;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<SectionDataContract> LoadSectionsForTestimonials()  { return LoadSections(SectionType.Testimonials); }

        public static List<SectionDataContract> LoadSectionsForPhotoGallery() { return LoadSections(SectionType.PhotoGallery); }

        private static List<SectionDataContract>  LoadSections(SectionType type)
        {
            try
            {
                GetSectionsRequest request = new GetSectionsRequest();
                request.Filter = new SectionSearchFilterDataContract();
                request.Filter.SectionType = type;
                GetSectionsResponse response = null;

                using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
                {
                    response = client.ServiceChannel.GetSections(request);
                } 
           
                return response.Sections;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<TestimonialDataContract> SearchTestimonials(string displayName, int startIndex, int count, int sectionId,
                                                             out int totalNumnerOfRecords)
        {
            try
            {
                SearchTestimonialsRequest request = new SearchTestimonialsRequest();
                SearchTestimonialsResponse response = null;

                TestimonialSearchFilterDataContract filter = new TestimonialSearchFilterDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;               
                filter.DisplayName = displayName;
                filter.SectionId = sectionId;
        
                request.Filter = filter;

                using (TestimonialsManagementClient client = ProxyFactory.CreateTestimonialsManagementProxy())
                {
                    response = client.ServiceChannel.SearchTestimonials(request);
                }

                totalNumnerOfRecords = response.Count;
                return response.Testimonials;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}