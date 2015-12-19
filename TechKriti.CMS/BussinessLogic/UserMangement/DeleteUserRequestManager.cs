using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.UserMangement
{
    public class DeleteUserRequestManager
    {
        private int userID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteUserRequestManager(int userID)
        {
            this.userID = userID;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  
        { 
            public bool Success { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateUserQuery = from user in dbContext.Users
                                     where user.UserId == userID
                                     select user;

            User candidateUser = candidateUserQuery.First();

            dbContext.Users.Remove(candidateUser);

            dbContext.SaveChanges();
            response.Success = true;
            
            return response;
        }
    }
}
