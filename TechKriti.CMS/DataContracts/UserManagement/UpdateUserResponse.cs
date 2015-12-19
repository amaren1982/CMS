using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.UserManagement
{
    [DataContract]
    public class UpdateUserResponse
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public LogicalErrorCode FailureReason { get; set; }
    }
}
