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
    public class SearchRolesRequest
    {
        public SearchRolesRequest() { Filter = new RolesSearchFilterDataContract(); }

        [DataMember]
        public RolesSearchFilterDataContract Filter { get; set; }
    }
}
