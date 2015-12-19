using Common.UserManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.UserMangement
{
    public class SearchRolesRequestManager
    {
        IRolesSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchRolesRequestManager(IRolesSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<Role> Roles { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateRolesQuery = from roles in dbContext.Roles
                                      where roles.IsEditable == true
                                     select roles;
            var countQuery = from roles in dbContext.Roles
                             where roles.IsEditable == true
                             select roles;

            // filter the list if needed
            if (! string.IsNullOrEmpty(this.filter.RoleName) )
            {
                candidateRolesQuery = candidateRolesQuery.Where(item => item.Name.Contains(this.filter.RoleName));
                countQuery = countQuery.Where(item => item.Name.Contains(this.filter.RoleName));
            }

            // paginate
            if(this.filter.StartIndex.HasValue && this.filter.Count.HasValue)
            candidateRolesQuery = candidateRolesQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                        Take(this.filter.Count.Value);

            response.Roles = candidateRolesQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();  
           
            return response;
        }
    }
}
