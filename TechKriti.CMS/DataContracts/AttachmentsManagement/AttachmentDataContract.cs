using Common.AttachmentsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.AttachmentsManagement
{
    [DataContract]
    [Serializable]
    public class AttachmentDataContract : IAttachment
    {
        [DataMember]
        public int AttachmentId { get; set; }
        [DataMemberAttribute]
        public string AttachmentPath { get; set; }
        [DataMemberAttribute]
        public string  AttachmentCaption {get; set;}
    }
}
