using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class CreateQualificationRequestManager
    {
        IQualification qualificationToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateQualificationRequestManager(IQualification qualificationToBeCreated)
        {
            this.qualificationToBeCreated = qualificationToBeCreated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            SelectionCriteria candidateQualification = new SelectionCriteria();
            candidateQualification.Description = qualificationToBeCreated.Description;
            candidateQualification.CreatedDate = DateTime.Now;
            candidateQualification.SubCategoryId = qualificationToBeCreated.ChildCategoryId;

            dbContext.SelectionCriterias.Add(candidateQualification);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
