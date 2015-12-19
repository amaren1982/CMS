using Datacontracts.Misc;
using Datacontracts.NewsManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datacontracts.PhotoGalleryManagement;
using Datacontracts.AttachmentsManagement;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.PhotoGallery
{
    public class PhotoGalleryController
    {
        public static bool SavePhotoGallery(PhotoGalleryDataContract photoGalleryToBeSaved, List<AttachmentDataContract> attachments)
        {
            try
            {
                if (photoGalleryToBeSaved.Id > 0) return UpdatePhotoGallery(photoGalleryToBeSaved, attachments);
                else return AddPhotoGallery(photoGalleryToBeSaved, attachments);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddPhotoGallery(PhotoGalleryDataContract photoGalleryToBeSaved, List<AttachmentDataContract> attachments)
        {
            CreatePhotoGalleryRequest request = new CreatePhotoGalleryRequest();
            EmptyResponse response = null;
            request.PhotoGalleryToBeSaved = photoGalleryToBeSaved;
            request.AttachmentsToBeSaved = attachments;

            using (PhotoGalleryManagementClient client = ProxyFactory.CreatePhotoGalleryManagementProxy())
            {
                response = client.ServiceChannel.CreatePhotoGallery(request);
            }

            return response.Success;
        }

        public static bool UpdatePhotoGallery(PhotoGalleryDataContract photoGalleryToBeSaved, List<AttachmentDataContract> attachmentsToBeSaved)
        {
            UpdatePhotoGalleryRequest request = new UpdatePhotoGalleryRequest();
            request.PhotoGalleryToBeSaved = photoGalleryToBeSaved;
            request.AttachmentsToBeSaved = attachmentsToBeSaved;
            
            EmptyResponse response = null;

            using (PhotoGalleryManagementClient client = ProxyFactory.CreatePhotoGalleryManagementProxy())
            {
                response = client.ServiceChannel.UpdatePhotoGallery(request);
            }

            return response.Success;
        }

        public static bool DeletePhotoGallery(int photoGalleryId)
        {
            try
            {
                DeletePhotoGalleryRequest request = new DeletePhotoGalleryRequest();
                EmptyResponse response = null;
                request.PhotoGalleryID = photoGalleryId;

                using (PhotoGalleryManagementClient client = ProxyFactory.CreatePhotoGalleryManagementProxy())
                {
                    response = client.ServiceChannel.DeletePhotoGallery(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static PhotoGalleryDataContract GetPhotoGalleryById(int photoGalleryId, out  List<AttachmentDataContract> attachments)
        {
            GetPhotoGalleryByIdResponse response = null;
            try
            {
                GetPhotoGalleryByIdRequest request = new GetPhotoGalleryByIdRequest();
                request.PhotoGalleryId = photoGalleryId;

                using (PhotoGalleryManagementClient client = ProxyFactory.CreatePhotoGalleryManagementProxy())
                {
                    response = client.ServiceChannel.GetPhotoGalleryById(request);
                }

                attachments = response.Attachments;

                return response.PhotoGallery;

            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<PhotoGalleryDataContract> SearchPhotoGalleries(string displayName, int startIndex, int count, int sectionId,
                                                             out int totalNumnerOfRecords)
        {
            try
            {
                SearchPhotoGalleryRequest request = new SearchPhotoGalleryRequest();
                SearchPhotoGalleryResponse response = null;

                PhotoGallerySearchFilterDataContract filter = new PhotoGallerySearchFilterDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;                
                filter.DisplayName = displayName;
                filter.SectionId = sectionId;
        
                request.Filter = filter;

                using (PhotoGalleryManagementClient client = ProxyFactory.CreatePhotoGalleryManagementProxy())
                {
                    response = client.ServiceChannel.SearchPhotoGalleries(request);
                }

                totalNumnerOfRecords = response.Count;
                return response.PhotoGalleries;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}