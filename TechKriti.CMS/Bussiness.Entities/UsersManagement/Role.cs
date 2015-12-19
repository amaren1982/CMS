using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.UsersManagement
{
    public class Role : IRole
    {      
        public int Id { get; set; }        
        public string RoleName { get; set; }       
        public string Description { get; set; }       
        public List<Permissions> Permissions { get; set; }
    }
}
