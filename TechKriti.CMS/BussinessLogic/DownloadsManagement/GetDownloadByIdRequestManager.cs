using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DownloadsManagement
{
    public class GetDownloadByIdRequestManager
    {
        private int downloadId;
        private TechKritiCMSEntities dbContext = null;

        public GetDownloadByIdRequestManager(int downloadId)
        {
            this.downloadId = downloadId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response
        {
            public Download Download { get; set; }
            public List<DownloadAttachment> Attachments { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateNewQuery = from download in dbContext.Downloads
                                    where download.Id == this.downloadId
                                    select download;
            var candidateAttachments = from attachments in dbContext.DownloadAttachments
                                       where attachments.DownloadId == this.downloadId
                                       select attachments;

            Download candidateNew = candidateNewQuery.First();
            response.Attachments = candidateAttachments.ToList();
            response.Download = candidateNew;

            return response;
        }
    }
}
