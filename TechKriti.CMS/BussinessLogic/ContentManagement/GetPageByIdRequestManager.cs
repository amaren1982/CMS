using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ContentMangement
{
    public class GetPageByIdRequestManager
    {
        private int pageId;
        private TechKritiCMSEntities dbContext = null;

        public GetPageByIdRequestManager(int pageId)
        {
            this.pageId = pageId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public Page Page { get; set; }  }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePageQuery = from page in dbContext.Pages
                                     where page.Id == pageId
                                     select page;

             response.Page = candidatePageQuery.First();
             return response;          
        }
    }
}
