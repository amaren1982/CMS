using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserManagement
{
    public interface IRolesSearchFilter : IPagedFilter
    {   
        string RoleName { get; set; }        
    }
}
