using Common.AttachmentsManagement;
using Common.SectorsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.SectorsManagement
{
    public class UpdateSectorRequestManager
    {
        ISector sectorToBeUpdated;
        private TechKritiCMSEntities dbContext = null;
        List<IAttachment> attachmentsToBeSaved;
        List<IAttachment> attachmentsToBeUpdated;

        public UpdateSectorRequestManager(ISector sector, List<IAttachment> attachmentsToBeSaved, List<IAttachment> attachmentsToBeUpdated)
        {
            sectorToBeUpdated = sector;
            this.attachmentsToBeSaved = attachmentsToBeSaved;
            this.attachmentsToBeUpdated = attachmentsToBeUpdated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateSectorQuery = from sector in dbContext.Sectors
                                       where sector.Id == sectorToBeUpdated.Id
                                       select sector;

            Sector candidateSector = candidateSectorQuery.First();           
            candidateSector.SectorName = sectorToBeUpdated.SectorName;            
            candidateSector.ParentSectorId = sectorToBeUpdated.ParentSectorId;

            if ( (!candidateSector.ParentSectorId.HasValue) || (candidateSector.ParentSectorId.Value == 0) )
            {
                var candidateAttachments = from attachments in dbContext.SectorAttachments
                                           where attachments.SectorId == this.sectorToBeUpdated.Id
                                           select attachments;

                candidateAttachments.ToList().ForEach(item => dbContext.SectorAttachments.Remove(item));           
            }
            else if (candidateSector.ParentSectorId.HasValue && candidateSector.ParentSectorId.Value > 0)
            {
                attachmentsToBeSaved.ForEach(item =>

                   candidateSector.SectorAttachments.Add(new SectorAttachment { DownloadPath = item.AttachmentPath, Caption = item.AttachmentCaption })

                   );

                attachmentsToBeUpdated.ForEach( item =>
                        {
                            SectorAttachment attachment = dbContext.SectorAttachments.First(att => att.Id == item.AttachmentId);
                            attachment.Caption = item.AttachmentCaption;
                           // dbContext.SectorAttachments.Attach(attachment);
                           // dbContext.Entry(attachment).State = System.Data.EntityState.Modified;

                        }
                    );
            }

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
