using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.SectionManagement;

namespace Datacontracts.SectionManagement
{
    [DataContract]
    public class SectionSearchFilterDataContract : PagedFilter, ISectionSearchFilter
    {
        [DataMember]
        public SectionType SectionType  { get; set; }
    }
}
