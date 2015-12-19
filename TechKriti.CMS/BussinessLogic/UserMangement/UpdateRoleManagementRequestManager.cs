using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datamodel;
using Common;
using Common.UserManagement;

namespace BussinessLogic.UserMangement
{
    public class UpdateRoleManagementRequestManager
    {
        IRole roleToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateRoleManagementRequestManager(IRole roleToBeCreated)
        {
            this.roleToBeCreated = roleToBeCreated;
           
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateRoleQuery = from role in dbContext.Roles
                                     where role.Id == roleToBeCreated.Id
                                     select role;

            Role candidateRole = candidateRoleQuery.First();
            candidateRole.Name = roleToBeCreated.RoleName;
            candidateRole.Description = roleToBeCreated.Description;

            candidateRole.PermissionsInRoles.ToList().ForEach(item => dbContext.PermissionsInRoles.Remove(item) );

            roleToBeCreated.Permissions.ForEach(item =>
               candidateRole.PermissionsInRoles.Add(new PermissionsInRole { Role = candidateRole, PermissionId = (int)item })
               );

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
