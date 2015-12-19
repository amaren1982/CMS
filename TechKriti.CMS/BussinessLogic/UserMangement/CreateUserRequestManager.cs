using Common;
using Common.UserManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.UserMangement
{
    public class CreateUserRequestManager
    {
        IUser userToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateUserRequestManager(IUser userToBeSaved)
        {
            this.userToBeCreated = userToBeSaved;
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
                                     where user.Username == this.userToBeCreated.Username
                                     select user;

            User existingUser = candidateUsernameQuery.FirstOrDefault();

            if (existingUser != null)
            {
                response.FailureReasonCode = LogicalErrorCode.UsernameAlreadyExists;
                response.Success = false;
            }
            else
            {
                User candidateUser = new User();
                candidateUser.Username = this.userToBeCreated.Username;
                candidateUser.Password = this.userToBeCreated.Password;
                candidateUser.RoleId = this.userToBeCreated.RoleId;

                dbContext.Users.Add(candidateUser);
                dbContext.SaveChanges();

                response.Success = true;
            }           

            return response;
        }
    }
}
