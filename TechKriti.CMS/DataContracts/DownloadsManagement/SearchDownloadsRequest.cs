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
    public class SearchDownloadsRequest
    {
        [DataMember]
        public DownloadsSearchFilterDataContract Filter { get; set; }
    }
}
