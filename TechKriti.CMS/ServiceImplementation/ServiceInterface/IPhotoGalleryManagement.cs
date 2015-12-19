using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.PhotoGalleryManagement;

namespace ServiceInterface
{
   [ServiceContract]
    public interface IPhotoGalleryManagement
    {
       [OperationContract]
       EmptyResponse CreatePhotoGallery(CreatePhotoGalleryRequest request);

       [OperationContract]
       EmptyResponse UpdatePhotoGallery(UpdatePhotoGalleryRequest request);

       [OperationContract]
       EmptyResponse DeletePhotoGallery(DeletePhotoGalleryRequest request);

       [OperationContract]
       GetPhotoGalleryByIdResponse GetPhotoGalleryById(GetPhotoGalleryByIdRequest request);

       [OperationContract]
       SearchPhotoGalleryResponse SearchPhotoGalleries(SearchPhotoGalleryRequest request);
    }
}
