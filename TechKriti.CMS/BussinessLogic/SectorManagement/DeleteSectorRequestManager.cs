using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.SectorsManagement
{
    public class DeleteSectorRequestManager
    {
        private int sectorID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteSectorRequestManager(int sectorId)
        {
            this.sectorID = sectorId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  
        { 
            public bool Success { get; set; }
            public LogicalErrorCode FailureReasonCode;
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var childSectorQuery = from sector in dbContext.Sectors
                                       where sector.ParentSectorId == this.sectorID
                                       select sector;

            Sector childSector = childSectorQuery.FirstOrDefault();

            if (childSector != null)
             {
                 response.Success = false;
                 response.FailureReasonCode = LogicalErrorCode.ChildSectorExists;
             }
             else
             {

                 var candidateSectorQuery = from sector in dbContext.Sectors
                                            where sector.Id == this.sectorID
                                            select sector;

                 var candidateAttachments = from attachments in dbContext.SectorAttachments
                                            where attachments.SectorId == this.sectorID
                                            select attachments;

                 Sector candidateSector = candidateSectorQuery.First();
                 candidateAttachments.ToList().ForEach(item => dbContext.SectorAttachments.Remove(item));
                 dbContext.Sectors.Remove(candidateSector);
                 dbContext.SaveChanges();

                 response.Success = true;
             }

            return response;
        }
    }
}
