using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datamodel;
using Common;

namespace BussinessLogic.UserMangement
{
    public class UserManagementRequestManager
    {
        private string username { get; set; }
        private string password { get; set; }
        private TechKritiCMSEntities dbContext = null;       

        public class Response   
        {
            public bool IsUserAuthentic;
            public LogicalErrorCode FailureReasonCode;
            public User User = new User();
            public Role Role = new Role();
        }

        public UserManagementRequestManager(string username, string pwd)
        {
            this.username = username;
            this.password = pwd;
            dbContext = new TechKritiCMSEntities();
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateUserQuery = from user in dbContext.Users
                                     where user.Username == this.username
                                     select user;

            var candidateUser = candidateUserQuery.FirstOrDefault<User>();

            if (candidateUser == null)
            {
                response.FailureReasonCode = LogicalErrorCode.InvalidUser;
                return response;
            }

            var authenticateUserQuery = from user in dbContext.Users
                                     where user.Username == this.username && user.Password == this.password
                                     select user;

            var authenticUser = authenticateUserQuery.FirstOrDefault<User>();

            if (authenticUser == null)
            {
                response.FailureReasonCode = LogicalErrorCode.InvalidUsernameOrPassword;
                candidateUser.FailtedAttempts++;
                dbContext.SaveChanges();

                return response;
            }

            if (authenticUser.FailtedAttempts >= 3)
            {
                response.FailureReasonCode = LogicalErrorCode.UserAccountLocked;
                return response;
            }

            authenticUser.FailtedAttempts = 0;
            authenticUser.LastLogin = DateTime.Now;

            var candidateRoleQuery = from role in dbContext.Roles
                                     where role.Id == authenticUser.RoleId
                                     select role;

            response.Role = candidateRoleQuery.First();  

            dbContext.SaveChanges();

            response.IsUserAuthentic = true;
            response.User = authenticUser;

            return response;
        }
    }
}
