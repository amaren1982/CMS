using Datacontracts.AttachmentsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.PhotoGalleryManagement
{
    [DataContract]
    public class UpdatePhotoGalleryRequest
    {
        [DataMember]
        public PhotoGalleryDataContract PhotoGalleryToBeSaved { get; set; }

        [DataMember]
        public List<AttachmentDataContract> AttachmentsToBeSaved { get; set; }
    }
}
