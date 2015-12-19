using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class GetCurrentOpeningByIdRequestManager
    {
        private int id;
        private TechKritiCMSEntities dbContext = null;

        public GetCurrentOpeningByIdRequestManager(int id)
        {
            this.id = id;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public CurrentOpening CurrentOpening { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateCurrentOpeningQuery = from currentOpening in dbContext.CurrentOpenings
                                               where currentOpening.Id == this.id
                                               select currentOpening;

            CurrentOpening candidateCurrentOpening = candidateCurrentOpeningQuery.First();
            response.CurrentOpening = candidateCurrentOpening;

            return response;
        }
    }
}
