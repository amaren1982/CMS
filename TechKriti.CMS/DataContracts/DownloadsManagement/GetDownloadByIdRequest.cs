using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.DownloadsManagement
{
    [DataContract]
    public class GetDownloadByIdRequest
    {
        [DataMember]
        public int DownloadId { get; set; }
    }
}
