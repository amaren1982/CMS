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
    public class CreateRoleRequestManager
    {
        IRole roleToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateRoleRequestManager(IRole roleToBeCreated)
        {
            this.roleToBeCreated = roleToBeCreated;           
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            Role candidateRole = new Role();
            candidateRole.Name = roleToBeCreated.RoleName;
            candidateRole.Description = roleToBeCreated.Description;
            candidateRole.IsEditable = true;

            roleToBeCreated.Permissions.ForEach(item =>
                candidateRole.PermissionsInRoles.Add ( new PermissionsInRole { Role = candidateRole, PermissionId = (int)item } )
                );            

            dbContext.Roles.Add(candidateRole);
            
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
