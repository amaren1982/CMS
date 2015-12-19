using Datacontracts.AttachmentsManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.SectorsManagement
{
    [DataContract]
    public class UpdateSectorRequest
    {
        [DataMember]
        public SectorDataContract SectorToBeSaved { get; set; }
        [DataMember]
        public List<AttachmentDataContract> AttachmentsToBeSaved { get; set; }
        [DataMember]
        public List<AttachmentDataContract> AttachmentsToBeUpdated { get; set; }
    }
}
