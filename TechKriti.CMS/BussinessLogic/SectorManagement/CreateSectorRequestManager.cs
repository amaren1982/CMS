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
    public class CreateSectorRequestManager
    {
        ISector sectorToBeCreated;
        private TechKritiCMSEntities dbContext = null;
        List<IAttachment> attachmentsToBeSaved;

        public CreateSectorRequestManager(ISector sector, List<IAttachment> attachments)
        {
            sectorToBeCreated = sector;
            this.attachmentsToBeSaved = attachments;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            Sector candidateSector = new Sector();         
            candidateSector.SectorName = sectorToBeCreated.SectorName;            
            candidateSector.ParentSectorId = sectorToBeCreated.ParentSectorId;

            dbContext.Sectors.Add(candidateSector);

            if (candidateSector.ParentSectorId.HasValue && candidateSector.ParentSectorId.Value > 0)

            attachmentsToBeSaved.ForEach(item =>

               candidateSector.SectorAttachments.Add(new SectorAttachment { DownloadPath = item.AttachmentPath, Caption = item.AttachmentCaption })

               );

            dbContext.SaveChanges();

            response.Success = true;
            return response;
        }
    }
}
