using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datamodel;
using Common;
using Common.ContentManagement;

namespace BussinessLogic.ContentMangement
{
    public class UpdatePageRequestManager
    {
        IPage pageToBeUpdated;
        private TechKritiCMSEntities dbContext = null;

        public UpdatePageRequestManager(IPage pageToBeUpdated)
        {
            this.pageToBeUpdated = pageToBeUpdated;           
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePageQuery = from page in dbContext.Pages
                                     where page.Id == pageToBeUpdated.Id
                                     select page;

            Page candidatePage = candidatePageQuery.First();
            candidatePage.Title = pageToBeUpdated.Title;
            candidatePage.Content = pageToBeUpdated.Content;
            candidatePage.CreatedBy = pageToBeUpdated.CreatedBy;
            candidatePage.MenuId = pageToBeUpdated.MenuId;
            candidatePage.Status = (short) (pageToBeUpdated.Status == PageStatus.Draft ? 1 : 2);
            candidatePage.Description = pageToBeUpdated.Description;
            candidatePage.H1 = pageToBeUpdated.H1;
            candidatePage.H2 = pageToBeUpdated.H2;
            candidatePage.MetaKeys = pageToBeUpdated.MetaKeys;
            candidatePage.SeoTitle = pageToBeUpdated.SeoTitle;
            
            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
