using Datacontracts.AttachmentsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.SectorsManagement
{
    [DataContract]
    public class GetSectorByIdResponse
    {
        [DataMember]
        public SectorDataContract Sector { get; set; }
        [DataMember]
        public List<AttachmentDataContract> Attachments { get; set; }

    }
}
