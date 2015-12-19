using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.UserManagement;

namespace Datacontracts.UserManagement
{
    [DataContract, Serializable]
    public class UserTypeDataContract : IUser
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime? LastLogin { get; set; }
        [DataMember]
        public int RoleId { get; set; }
    }
}
