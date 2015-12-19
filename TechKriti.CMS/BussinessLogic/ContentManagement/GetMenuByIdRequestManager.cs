using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ContentMangement
{
    public class GetMenuByIdRequestManager
    {
        private int menuId;
        private TechKritiCMSEntities dbContext = null;

        public GetMenuByIdRequestManager(int menuId)
        {
            this.menuId = menuId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public Menu Menu { get; set; }  }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateMenuQuery = from menu in dbContext.Menus
                                     where menu.Id == this.menuId
                                     select menu;

            response.Menu = candidateMenuQuery.First();           

            return response;
        }
    }
}
