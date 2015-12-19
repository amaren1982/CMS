using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.UserMangement
{
    public class GetRoleByIdRequestManager
    {
        private int roleId;
        private TechKritiCMSEntities dbContext = null;

        public GetRoleByIdRequestManager(int roleId)
        {
            this.roleId = roleId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public Role Role { get; set; }  }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateRoleQuery = from role in dbContext.Roles
                                    where role.Id == this.roleId
                                    select role;
           
            response.Role = candidateRoleQuery.First();           

            return response;
        }
    }
}
