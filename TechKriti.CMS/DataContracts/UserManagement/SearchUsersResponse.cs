using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.UserManagement
{
    [DataContract]
    public class SearchUsersResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<UserTypeDataContract> Users { get; set; }
    }
}
