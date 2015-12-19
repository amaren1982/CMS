using BussinessLogic.NewsManagement;
using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.PhotoGalleryManagement;
using ServiceImplementation.Extensions.PhotoGalleryManagement;
using Datacontracts.PhotoGalleryManagement;
using ServiceImplementation.Extensions.AttachmentsManagement;

namespace ServiceInterface.ServiceImplementation.PhotoGalleryManagement
{
    public class PhotoGalleryServiceImpl : IPhotoGalleryManagement
    {
        public EmptyResponse CreatePhotoGallery(CreatePhotoGalleryRequest request)
        {
            try
            {
                CreatePhotoGalleryRequestManager requestManger = new CreatePhotoGalleryRequestManager( request.PhotoGalleryToBeSaved.ToBussinessEntity(),
                                                                                                       request.AttachmentsToBeSaved.ToBussinessEntity() );
                CreatePhotoGalleryRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public EmptyResponse UpdatePhotoGallery(UpdatePhotoGalleryRequest request)
        {
            try
            {
                UpdatePhotoGalleryRequestManager requestManger = new UpdatePhotoGalleryRequestManager( request.PhotoGalleryToBeSaved.ToBussinessEntity(),
                                                                                                       request.AttachmentsToBeSaved.ToBussinessEntity() );
                UpdatePhotoGalleryRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public EmptyResponse DeletePhotoGallery(DeletePhotoGalleryRequest request)
        {
            try
            {
                DeletePhotoGalleryRequestManager requestManger = new DeletePhotoGalleryRequestManager(request.PhotoGalleryID);
                DeletePhotoGalleryRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public SearchPhotoGalleryResponse SearchPhotoGalleries(SearchPhotoGalleryRequest request)
        {
            try
            {
                SearchPhotoGalleriesRequestManager requestManger = new SearchPhotoGalleriesRequestManager(request.Filter.ToFilter());
                SearchPhotoGalleriesRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchPhotoGalleryResponse response = new SearchPhotoGalleryResponse();
                response.Count = bllResponse.TotalNumberofRecords;
                response.PhotoGalleries = bllResponse.PhotoGalleries.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetPhotoGalleryByIdResponse GetPhotoGalleryById(GetPhotoGalleryByIdRequest request)
        {
            try
            {
                GetPhotoGalleryByIdRequestManager requestManger = new GetPhotoGalleryByIdRequestManager(request.PhotoGalleryId);
                GetPhotoGalleryByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetPhotoGalleryByIdResponse response = new GetPhotoGalleryByIdResponse();
                response.PhotoGallery = bllResponse.PhotoGallery.ToDataContract();
                response.Attachments = bllResponse.Attachments.ToDataContract();

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
