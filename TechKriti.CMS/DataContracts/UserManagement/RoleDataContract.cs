using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.UserManagement;

namespace Datacontracts.UserManagement
{
    [DataContract, Serializable]
    public class RoleDataContract : IRole
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<Permissions> Permissions { get; set; }
    }
}
