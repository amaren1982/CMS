using Common.AttachmentsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.SectionManagement;

namespace BussinessLogic.SectionManagement
{
    public class CreateSectionRequestManager
    {
        ISection sectionToBeCreated;
        private TechKritiCMSEntities dbContext = null;      

        public CreateSectionRequestManager(ISection section)
        {
            sectionToBeCreated = section;            
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            SectionMaster candidateSection = new SectionMaster();
            candidateSection.Name = sectionToBeCreated.Name;
            candidateSection.SectionType = (int)sectionToBeCreated.SectionType;                     

            dbContext.SectionMasters.Add(candidateSection);
            dbContext.SaveChanges();

            response.Success = true;
            return response;
        }
    }
}
