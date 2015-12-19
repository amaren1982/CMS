using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserManagement
{
    public interface IRole
    {
        int Id { get; set; }
        string RoleName { get; set; }
        string Description { get; set; }
        List<Permissions> Permissions { get; set; }
    }
}
