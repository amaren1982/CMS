using Common.SectorsManagement;
using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.SectorsManagement
{
    [DataContract]
    public class SectorSearchFilterDataContract : PagedFilter, ISectorsSearchFilter
    {
        [DataMember]
        public int Id { get; set; }       
        [DataMember]
        public string SectorName { get; set; }
        [DataMember]
        public bool? GetParentSectorsOnly { get; set; }
    }
}
