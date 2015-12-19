using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.PhotoGalleryManagement;
using Common.AttachmentsManagement;

namespace BussinessLogic.PhotoGalleryManagement
{
    public class UpdatePhotoGalleryRequestManager
    {
        IPhotoGallery photoGalleryTobeUpdated;
        List<IAttachment> attachmentsToBeSaved;
        private TechKritiCMSEntities dbContext = null;

        public UpdatePhotoGalleryRequestManager(IPhotoGallery photoGallery, List<IAttachment> attachmentsToBeSaved)
        {
            photoGalleryTobeUpdated = photoGallery;
            this.attachmentsToBeSaved = attachmentsToBeSaved;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePhotoGalleryQuery = from photoGallery in dbContext.PhotoGalleries
                                             where photoGallery.Id == photoGalleryTobeUpdated.Id
                                            select photoGallery;

            PhotoGallery candidatePhotoGallery = candidatePhotoGalleryQuery.First();
                     
            candidatePhotoGallery.DisplayName = photoGalleryTobeUpdated.DisplayName;            
            candidatePhotoGallery.SectionId = photoGalleryTobeUpdated.SectionId;
            candidatePhotoGallery.ModifiedDate = DateTime.Now;

            if (attachmentsToBeSaved.Any() )
            {
                var existingAttachments = from attachments in dbContext.PhotoGalleryAttachments
                                          where attachments.GalleryId == this.photoGalleryTobeUpdated.Id
                                          select attachments;

                existingAttachments.ToList().ForEach( item => dbContext.PhotoGalleryAttachments.Remove(item) );

                attachmentsToBeSaved.ForEach(item => candidatePhotoGallery.PhotoGalleryAttachments
                                                                           .Add(new PhotoGalleryAttachment { CreatedDate = DateTime.Now, DownloadPath = item.AttachmentPath })

               );
            }

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
