using Common.UserManagement;
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
    public class RolesSearchFilterDataContract : PagedFilter, IRolesSearchFilter
    {       
        [DataMember]
        public string RoleName { get; set; }       
    }
}
