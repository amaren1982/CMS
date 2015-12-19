using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ContentMangement
{
    public class DeletePageRequestManager
    {
        private int pageID;       
        private TechKritiCMSEntities dbContext = null;

        public DeletePageRequestManager(int pageID)
        {
            this.pageID = pageID;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  
        { 
            public bool Success { get; set; }            
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePageQuery = from page in dbContext.Pages
                                     where page.Id == pageID
                                     select page;

            Page candidatePage = candidatePageQuery.First();
            dbContext.Pages.Remove(candidatePage);
            dbContext.SaveChanges();

            response.Success = true;
            return response;
        }
    }
}
