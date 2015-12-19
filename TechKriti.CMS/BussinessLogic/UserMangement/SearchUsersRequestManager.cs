using Common.UserManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.UserMangement
{
    public class SearchUsersRequestManager
    {
        IUsersSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchUsersRequestManager(IUsersSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<User> Users { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateUsersQuery = from users in dbContext.Users
                                      select users;

            var countQuery = from users in dbContext.Users
                             select users;

            // filter the list if needed
            if (! string.IsNullOrEmpty(this.filter.UserName) )
            {
                candidateUsersQuery = candidateUsersQuery.Where(item => item.Username.Contains(this.filter.UserName));
                countQuery = countQuery.Where(item => item.Username.Contains(this.filter.UserName));
            }

            // paginate
            if(this.filter.StartIndex.HasValue && this.filter.Count.HasValue)
            candidateUsersQuery = candidateUsersQuery.OrderByDescending(item => item.UserId)
                                                          .Skip(this.filter.StartIndex.Value)
                                                          .Take(this.filter.Count.Value);

            response.Users = candidateUsersQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();  
           
            return response;
        }
    }
}
