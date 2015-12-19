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
    public class GetPhotoGalleryByIdResponse
    {
        [DataMember]
        public PhotoGalleryDataContract PhotoGallery { get; set; }

        [DataMember]
        public List<AttachmentDataContract> Attachments { get; set; }
    }
}
