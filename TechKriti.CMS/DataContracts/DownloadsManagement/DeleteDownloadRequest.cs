using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.DownloadsManagement
{
    [DataContract]
    public class DeleteDownloadRequest
    {
        [DataMember]
        public int DownloadID { get; set; }
    }
}
