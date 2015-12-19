using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ContentManagement;
using DataContracts.Paging;
using System.Runtime.Serialization;

namespace Datacontracts.ContentManagement
{
    [DataContract]
    public class MenuSearchFilterDataContract : PagedFilter, IMenuSearchFilter
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string MenuName { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
    }
}
