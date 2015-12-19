using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.UserManagement
{
    [DataContract]
    public class CreateUserRequest
    {
        [DataMember]
        public UserTypeDataContract UserToBeSaved { get; set; }
    }
}
