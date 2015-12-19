using Common.CurrentOpeningManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class UpdateCurrentOpeningRequestManager
    {
        ICurrentOpening currentOpeningToBeUpdated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateCurrentOpeningRequestManager(ICurrentOpening currentOpening)
        {
            currentOpeningToBeUpdated = currentOpening;
            dbContext = new TechKritiCMSEntities();
        }      

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var currentOpeningQuery = from currentOpening in dbContext.CurrentOpenings
                                      where currentOpening.Id == currentOpeningToBeUpdated.Id
                                      select currentOpening;

            CurrentOpening candidateCurrentOpening = currentOpeningQuery.First();
            candidateCurrentOpening.Company = currentOpeningToBeUpdated.Company;
            candidateCurrentOpening.CreatedDate = DateTime.Now;
            candidateCurrentOpening.Email = currentOpeningToBeUpdated.Email;
            candidateCurrentOpening.IsActive = currentOpeningToBeUpdated.IsActive;
            candidateCurrentOpening.OpenTillDate = currentOpeningToBeUpdated.OpenTillDate;
            candidateCurrentOpening.Position = currentOpeningToBeUpdated.Position;
            candidateCurrentOpening.Qualification = currentOpeningToBeUpdated.Qualification;
            candidateCurrentOpening.SkillSet = currentOpeningToBeUpdated.SkillSet;
            candidateCurrentOpening.ModifiedDate = DateTime.Now;

            dbContext.SaveChanges();
                                
            response.Success = true;

            return response;
        }
    }
}
