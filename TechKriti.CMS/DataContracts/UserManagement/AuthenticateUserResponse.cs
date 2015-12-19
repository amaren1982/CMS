using Common;
using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.UserManagement
{
    [DataContract]
    public class AuthenticateUserResponse
    {
        [DataMember]
        public bool IsUserAuthentic { get; set; }
        [DataMember]
        public LogicalErrorCode FailureReason { get; set; }
        [DataMember]
        public UserTypeDataContract User { get; set; }
        [DataMember]
        public List<Permissions> Permissions { get; set; }
    }
}
