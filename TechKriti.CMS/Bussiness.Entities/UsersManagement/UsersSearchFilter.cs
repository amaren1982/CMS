using Bussiness.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TestimonialsManagement;
using Common.UserManagement;

namespace Bussiness.Entities.UsersManagement
{
    public class UsersSearchFilter : PagedFilter, IUsersSearchFilter
    {
        public string UserName { get; set; }
    }
}
