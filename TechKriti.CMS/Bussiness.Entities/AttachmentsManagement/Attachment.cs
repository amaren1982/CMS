using Common.AttachmentsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.AttachmentsManagement
{
    public class Attachment : IAttachment
    {  
        public int AttachmentId { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentCaption { get; set; }
    }
}
