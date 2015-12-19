using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class GetQualificationByIdRequestManager
    {
        private int qualificationId;
        private TechKritiCMSEntities dbContext = null;

        public GetQualificationByIdRequestManager(int qualificationId)
        {
            this.qualificationId = qualificationId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public SelectionCriteria Qualification { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateQualificationQuery = from qualification in dbContext.SelectionCriterias
                                    where qualification.Id == this.qualificationId
                                    select qualification;

            response.Qualification = candidateQualificationQuery.First();           

            return response;
        }
    }
}
