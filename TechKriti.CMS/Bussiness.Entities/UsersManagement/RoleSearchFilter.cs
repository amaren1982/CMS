using Bussiness.Entities.Paging;
using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.UsersManagement
{
    public class RoleSearchFilter : PagedFilter, IRolesSearchFilter
    { 
        public string RoleName { get; set; }      
    }
}
