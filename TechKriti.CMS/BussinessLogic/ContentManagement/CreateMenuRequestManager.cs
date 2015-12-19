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
    public class CreateMenuRequestManager
    {
        IMenu menuToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateMenuRequestManager(IMenu menuToBeCreated)
        {
            this.menuToBeCreated = menuToBeCreated;           
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            Menu candidateMenu = new Menu();
            candidateMenu.MenuName = menuToBeCreated.MenuName;
            candidateMenu.DisplayOrderId = menuToBeCreated.DisplayOrderId;
            candidateMenu.IsActive = menuToBeCreated.IsActive;
            candidateMenu.ParentMenuId = menuToBeCreated.ParentMenuId;

            dbContext.Menus.Add(candidateMenu);
            dbContext.SaveChanges();

            response.Success = true;
            return response;
        }
    }
}
