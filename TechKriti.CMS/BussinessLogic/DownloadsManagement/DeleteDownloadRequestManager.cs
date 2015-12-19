using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DownloadsManagement
{
    public class DeleteDownloadRequestManager
    {
        private int downloadID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteDownloadRequestManager(int downloadId)
        {
            this.downloadID = downloadId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response {  public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var currentDownloadQuery = from download in dbContext.Downloads
                                      where download.Id == this.downloadID
                                      select download;

            var candidateAttachments = from attachments in dbContext.DownloadAttachments
                                       where attachments.DownloadId == this.downloadID
                                       select attachments;

            Download candidateDowload = currentDownloadQuery.First();

            candidateAttachments.ToList().ForEach(item => dbContext.DownloadAttachments.Remove(item)); 
            dbContext.Downloads.Remove(candidateDowload);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
