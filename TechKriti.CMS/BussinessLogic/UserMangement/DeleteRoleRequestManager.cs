using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.UserMangement
{
    public class DeleteRoleRequestManager
    {
        private int roleID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteRoleRequestManager(int roleID)
        {
            this.roleID = roleID;
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

            var candidateRoleQuery = from role in dbContext.Roles
                                     where role.Id == roleID
                                     select role;

            Role candidateRole = candidateRoleQuery.First();

            if (candidateRole.Users.Any())
            {
                response.Success = false;
                response.FailureReasonCode = LogicalErrorCode.RoleAssignedToUser;
            }
            else
            {
                candidateRole.PermissionsInRoles.ToList().ForEach(item => dbContext.PermissionsInRoles.Remove(item));
                dbContext.Roles.Remove(candidateRole);

                dbContext.SaveChanges();
                response.FailureReasonCode = LogicalErrorCode.None;
                response.Success = true;
            }

            return response;
        }
    }
}
