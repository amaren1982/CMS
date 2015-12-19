using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.PhotoGalleryManagement
{
    public class DeletePhotoGalleryRequestManager
    {
        private int photoGalleryId;       
        private TechKritiCMSEntities dbContext = null;

        public DeletePhotoGalleryRequestManager(int photoGalleryId)
        {
            this.photoGalleryId = photoGalleryId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; }  }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePhotoGalleryQuery = from photoGallery in dbContext.PhotoGalleries
                                             where photoGallery.Id == this.photoGalleryId
                                             select photoGallery;

            var candidateAttachments = from attachments in dbContext.PhotoGalleryAttachments
                                       where attachments.GalleryId == this.photoGalleryId
                                       select attachments;

            PhotoGallery candidatePhotoGallery = candidatePhotoGalleryQuery.First();

            candidateAttachments.ToList().ForEach( item => dbContext.PhotoGalleryAttachments.Remove(item) );           
            dbContext.PhotoGalleries.Remove(candidatePhotoGallery);

            dbContext.SaveChanges();     
            response.Success = true;

            return response;
        }
    }
}
