using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Downloads;
using Datacontracts.AttachmentsManagement;

namespace Datacontracts.DownloadsManagement
{
    [DataContract]
    public class CreateDownloadRequest
    {
        [DataMember]
        public DownloadsDataContract DownloadTobeSaved { get; set; }

        [DataMember]
        public List<AttachmentDataContract> AttachmentsToBeSaved { get; set; }
    }
}
