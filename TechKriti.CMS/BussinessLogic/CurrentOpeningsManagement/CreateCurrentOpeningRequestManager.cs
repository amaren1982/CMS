using Common.CurrentOpeningManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class CreateCurrentOpeningRequestManager
    {
        ICurrentOpening currentOpeningToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateCurrentOpeningRequestManager(ICurrentOpening currentOpening)
        {
            currentOpeningToBeCreated = currentOpening;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateCurrentOpening = new CurrentOpening();
            candidateCurrentOpening.Company = currentOpeningToBeCreated.Company;
            candidateCurrentOpening.CreatedDate = DateTime.Now;
            candidateCurrentOpening.Email = currentOpeningToBeCreated.Email;
            candidateCurrentOpening.IsActive = currentOpeningToBeCreated.IsActive;
            candidateCurrentOpening.OpenTillDate = currentOpeningToBeCreated.OpenTillDate;
            candidateCurrentOpening.Position = currentOpeningToBeCreated.Position;
            candidateCurrentOpening.Qualification = currentOpeningToBeCreated.Qualification;
            candidateCurrentOpening.SkillSet = currentOpeningToBeCreated.SkillSet;

            dbContext.CurrentOpenings.Add(candidateCurrentOpening);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
