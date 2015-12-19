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
    public class UpdateMenuRequestManager
    {
        IMenu menuToBeUpdated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateMenuRequestManager(IMenu menuToBeUpdated)
        {
            this.menuToBeUpdated = menuToBeUpdated;           
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateMenuQuery = from menu in dbContext.Menus
                                     where menu.Id == menuToBeUpdated.Id
                                     select menu;

            Menu candidateMenu = candidateMenuQuery.First();
            candidateMenu.MenuName = menuToBeUpdated.MenuName;
            candidateMenu.DisplayOrderId = menuToBeUpdated.DisplayOrderId;
            candidateMenu.IsActive = menuToBeUpdated.IsActive;
            candidateMenu.ParentMenuId = menuToBeUpdated.ParentMenuId;

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
