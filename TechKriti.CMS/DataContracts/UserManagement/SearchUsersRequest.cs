using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.UserManagement
{
    [DataContract]
    public class SearchUsersRequest
    {
        public SearchUsersRequest() { Filter = new UsersSearchFilterDataContract(); }
        [DataMember]
        public UsersSearchFilterDataContract Filter { get; set; }
    }
}
