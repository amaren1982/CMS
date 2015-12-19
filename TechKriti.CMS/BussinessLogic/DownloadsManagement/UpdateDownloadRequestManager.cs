using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DownloadsManagement;
using Common.AttachmentsManagement;

namespace BussinessLogic.DownloadsManagement
{
    public class UpdateDownloadRequestManager
    {
        IDownload downloadToBeSaved;
        List<IAttachment> attachmentsToBeSaved;
        private TechKritiCMSEntities dbContext = null;

        public UpdateDownloadRequestManager(  IDownload downloadToBeSaved,  List<IAttachment> attachments)
        {
           this.downloadToBeSaved = downloadToBeSaved;
           this.attachmentsToBeSaved = attachments;

            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var currentDownloadQuery = from download in dbContext.Downloads
                                       where download.Id == downloadToBeSaved.Id
                                       select download;

            Download candidateDownload = currentDownloadQuery.First();

            candidateDownload.DisplayName = downloadToBeSaved.DisplayName;            
            candidateDownload.IsActive = downloadToBeSaved.IsActive;
            candidateDownload.SectionId = downloadToBeSaved.SectionId;
            candidateDownload.ModifiedDate = DateTime.Now;

            if (attachmentsToBeSaved.Any())
            {
                var existingAttachments = from attachments in dbContext.DownloadAttachments
                                          where attachments.DownloadId == this.downloadToBeSaved.Id
                                          select attachments;

                existingAttachments.ToList().ForEach(item => dbContext.DownloadAttachments.Remove(item));

                attachmentsToBeSaved.ForEach(item => candidateDownload.DownloadAttachments
                                                                      .Add(new DownloadAttachment { CreatedDate = DateTime.Now, DownloadPath = item.AttachmentPath })
               );
            }

            dbContext.SaveChanges();                                
            response.Success = true;

            return response;
        }
    }
}
