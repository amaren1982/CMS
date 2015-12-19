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
    public class CreatePageRequestManager
    {
        IPage pageToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreatePageRequestManager(IPage pageToBeCreated)
        {
            this.pageToBeCreated = pageToBeCreated;           
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            Page candidatePage = new Page();
            candidatePage.Title = pageToBeCreated.Title;
            candidatePage.Content = pageToBeCreated.Content;
            candidatePage.CreatedBy = pageToBeCreated.CreatedBy;
            candidatePage.CreatedOn = DateTime.Now;
            candidatePage.MenuId = pageToBeCreated.MenuId;
            candidatePage.Status = (short) (pageToBeCreated.Status == PageStatus.Draft ?  1 : 2);
            candidatePage.Description = pageToBeCreated.Description;
            candidatePage.H1 = pageToBeCreated.H1;
            candidatePage.H2 = pageToBeCreated.H2;
            candidatePage.MetaKeys = pageToBeCreated.MetaKeys;
            candidatePage.SeoTitle = pageToBeCreated.SeoTitle;

            dbContext.Pages.Add(candidatePage);

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
