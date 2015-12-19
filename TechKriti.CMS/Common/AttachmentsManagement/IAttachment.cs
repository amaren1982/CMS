using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AttachmentsManagement
{
    public interface IAttachment
    {
        int AttachmentId { get; set; }
        string AttachmentPath { get; set; }
        string AttachmentCaption { get; set; }
    }
}
