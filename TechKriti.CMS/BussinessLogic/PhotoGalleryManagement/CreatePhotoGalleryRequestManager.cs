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
    public class CreatePhotoGalleryRequestManager
    {
        IPhotoGallery photoGalleryTobeCreated;
        List<IAttachment> attachmentsToBeSaved;
        private TechKritiCMSEntities dbContext = null;

        public CreatePhotoGalleryRequestManager(IPhotoGallery photoGallery, List<IAttachment> attachments)
        {
            photoGalleryTobeCreated = photoGallery;
            attachmentsToBeSaved = attachments;

            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            PhotoGallery candidatePhotoGallery = new PhotoGallery();           
            candidatePhotoGallery.CreatedDate = DateTime.Now;
            candidatePhotoGallery.DisplayName = photoGalleryTobeCreated.DisplayName;            
            candidatePhotoGallery.SectionId = photoGalleryTobeCreated.SectionId;

            dbContext.PhotoGalleries.Add(candidatePhotoGallery);

            attachmentsToBeSaved.ForEach( item =>

                candidatePhotoGallery.PhotoGalleryAttachments.Add( new PhotoGalleryAttachment { CreatedDate = DateTime.Now, DownloadPath = item.AttachmentPath } )

                );

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
