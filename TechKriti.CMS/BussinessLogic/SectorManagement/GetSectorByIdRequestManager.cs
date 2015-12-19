using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.SectorsManagement
{
    public class GetSectorByIdRequestManager
    {
        private int sectorId;
        private TechKritiCMSEntities dbContext = null;

        public GetSectorByIdRequestManager(int sectorId)
        {
            this.sectorId = sectorId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response 
        { 
            public Sector Sector { get; set; }
            public List<SectorAttachment> Attachments { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateNewQuery = from sector in dbContext.Sectors
                                    where sector.Id == this.sectorId
                                    select sector;

            var candidateAttachments = from attachments in dbContext.SectorAttachments
                                       where attachments.SectorId == this.sectorId
                                       select attachments;

            response.Sector = candidateNewQuery.First();
            response.Attachments = candidateAttachments.ToList();
            return response;
        }
    }
}
