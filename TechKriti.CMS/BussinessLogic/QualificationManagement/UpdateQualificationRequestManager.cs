using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class UpdateQualificationRequestManager
    {
        IQualification qualificationToBeUpdated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateQualificationRequestManager(IQualification qualificationToBeUpdated)
        {
            this.qualificationToBeUpdated = qualificationToBeUpdated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateQualifictionQuery = from qualification in dbContext.SelectionCriterias
                                             where qualification.Id == qualificationToBeUpdated.Id
                                             select qualification;

            SelectionCriteria candidateQualification = candidateQualifictionQuery.First();
            candidateQualification.Description = qualificationToBeUpdated.Description;
            candidateQualification.ModifiedDate = DateTime.Now;
            candidateQualification.SubCategoryId = qualificationToBeUpdated.ChildCategoryId;
           
            dbContext.SaveChanges();            
            response.Success = true;

            return response;
        }
    }
}
