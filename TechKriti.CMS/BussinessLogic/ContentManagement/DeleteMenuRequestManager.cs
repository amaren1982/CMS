using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ContentMangement
{
    public class DeleteMenuRequestManager
    {
        private int menuID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteMenuRequestManager(int menuID)
        {
            this.menuID = menuID;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  
        { 
            public bool Success { get; set; }
            public LogicalErrorCode FailureReasonCode;
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePageQuery = from page in dbContext.Pages
                                     where page.MenuId == menuID
                                     select page;

            Page candidatePage = candidatePageQuery.FirstOrDefault();

            if (candidatePage != null)
            {
                response.Success = false;
                response.FailureReasonCode = LogicalErrorCode.MenuAssignedToPage;
            }
            else
            {
                var candidateMenuQuery = from menu in dbContext.Menus
                                         where menu.Id == menuID
                                         select menu;

                dbContext.Menus.Remove(candidateMenuQuery.First());

                dbContext.SaveChanges();
                response.FailureReasonCode = LogicalErrorCode.MenuAssignedToPage;
                response.Success = true;
            }         

            return response;
        }
    }
}
