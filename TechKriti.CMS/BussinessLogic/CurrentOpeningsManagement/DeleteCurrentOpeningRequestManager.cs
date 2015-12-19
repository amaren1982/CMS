using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class DeleteCurrentOpeningRequestManager
    {
        private int currentOpeningID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteCurrentOpeningRequestManager(int currentOpeningID)
        {
            this.currentOpeningID = currentOpeningID;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response {  public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var currentOpeningQuery = from currentOpening in dbContext.CurrentOpenings
                                     where currentOpening.Id == this.currentOpeningID
                                     select currentOpening;

            CurrentOpening candidateCurrentOpening = currentOpeningQuery.First();
            dbContext.CurrentOpenings.Remove(candidateCurrentOpening);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
