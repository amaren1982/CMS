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
    public class CreateDownloadRequestManager
    {
        IDownload downloadToBeSaved;
        List<IAttachment> attachmentsToBeSaved;
        private TechKritiCMSEntities dbContext = null;

        public CreateDownloadRequestManager( IDownload download,  List<IAttachment> attachments)
        {
            this.downloadToBeSaved = download;
            this.attachmentsToBeSaved = attachments;

            dbContext = new TechKritiCMSEntities();        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateDownload = new Download();
            candidateDownload.DisplayName = downloadToBeSaved.DisplayName;           
            candidateDownload.IsActive = downloadToBeSaved.IsActive;
            candidateDownload.SectionId = downloadToBeSaved.SectionId;
            candidateDownload.CreatedDate = DateTime.Now;
            
            dbContext.Downloads.Add(candidateDownload);

            attachmentsToBeSaved.ForEach(item => candidateDownload.DownloadAttachments
                                                                  .Add(new DownloadAttachment { CreatedDate = DateTime.Now, DownloadPath = item.AttachmentPath }));
           

            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
