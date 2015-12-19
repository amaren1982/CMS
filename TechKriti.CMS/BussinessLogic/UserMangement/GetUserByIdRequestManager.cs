using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.UserMangement
{
    public class GetUserByIdRequestManager
    {
        private int userId;
        private TechKritiCMSEntities dbContext = null;

        public GetUserByIdRequestManager(int userId)
        {
            this.userId = userId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public User User { get; set; }  }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateUserQuery = from user in dbContext.Users
                                    where user.UserId == this.userId
                                    select user;

            response.User = candidateUserQuery.First();           

            return response;
        }
    }
}
