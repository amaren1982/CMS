using Datacontracts.SectorsManagement;
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
    public class SearchSectorsResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<SectorDataContract> Sectors { get; set; }
    }
}
