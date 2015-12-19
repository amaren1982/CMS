using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.UserManagement
{
    [DataContract]
    public class DeleteRoleRequest
    {
        [DataMember]
        public int RoleID { get; set; }
    }
}
