using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Downloads;

namespace Datacontracts.DownloadsManagement
{
    [DataContract]
    public class SearchDownloadsResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<DownloadsDataContract> Downloads { get; set; }
    }
}
