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
    public class UpdateUserManagementRequestManager
    {
        IUser userToBeUpdated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateUserManagementRequestManager(IUser userToBeUpdated)
        {
            this.userToBeUpdated = userToBeUpdated;           
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

            var candidateUsernameQuery = from user in dbContext.Users
                                         where user.Username == this.userToBeUpdated.Username && 
                                         user.UserId != this.userToBeUpdated.Id
                                         select user;

            User duplicateUser = candidateUsernameQuery.FirstOrDefault();

            if (duplicateUser != null)
            {
                response.FailureReasonCode = LogicalErrorCode.UsernameAlreadyExists;
                response.Success = false;
            }
            else
            {
                var candidateUserQuery = from user in dbContext.Users
                                            where user.UserId == this.userToBeUpdated.Id
                                            select user;

                User candidateUser = candidateUserQuery.First();

                if ( candidateUser.Username != this.userToBeUpdated.Username ) candidateUser.Username = this.userToBeUpdated.Username;
                if ( string.IsNullOrEmpty(this.userToBeUpdated.Password) )       candidateUser.Password = this.userToBeUpdated.Password;
                candidateUser.RoleId = this.userToBeUpdated.RoleId;

                dbContext.SaveChanges();

                response.Success = true;
            }           

            return response;
        }
    }
}
