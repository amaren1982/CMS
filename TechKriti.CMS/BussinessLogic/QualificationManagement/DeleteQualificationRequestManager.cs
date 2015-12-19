using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class DeleteQualificationRequestManager
    {
        private int qualificationID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteQualificationRequestManager(int qualificationID)
        {
            this.qualificationID = qualificationID;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; }  }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateQualificationQuery = from qualification in dbContext.SelectionCriterias
                                       where qualification.Id == qualificationID
                                       select qualification;

            SelectionCriteria candidateQualification = candidateQualificationQuery.First();
            dbContext.SelectionCriterias.Remove(candidateQualification);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
