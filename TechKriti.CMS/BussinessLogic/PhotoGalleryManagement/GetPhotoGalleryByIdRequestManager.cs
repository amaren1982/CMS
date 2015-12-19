using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.PhotoGalleryManagement
{
    public class GetPhotoGalleryByIdRequestManager
    {
        private int photoGalleryId;
        private TechKritiCMSEntities dbContext = null;

        public GetPhotoGalleryByIdRequestManager(int photoGalleryId)
        {
            this.photoGalleryId = photoGalleryId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response 
        { 
            public PhotoGallery PhotoGallery { get; set; }
            public List<PhotoGalleryAttachment> Attachments { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateNewQuery = from photoGallery in dbContext.PhotoGalleries
                                    where photoGallery.Id == this.photoGalleryId
                                    select photoGallery;

            var candidateAttachments = from attachments in dbContext.PhotoGalleryAttachments
                                       where attachments.GalleryId == this.photoGalleryId
                                       select attachments;
           
            response.PhotoGallery = candidateNewQuery.First();
            response.Attachments = candidateAttachments.ToList();

            return response;
        }
    }
}
