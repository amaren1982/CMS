using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.PhotoGalleryManagement;
using Datacontracts.AttachmentsManagement;

namespace Datacontracts.PhotoGalleryManagement
{
    [DataContract, Serializable]
    public class PhotoGalleryDataContract : IPhotoGallery
    {
        [DataMember]
        public int Id { get; set; }        
        [DataMember]
        public int? SectionId { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }
        [DataMember]
        public List<AttachmentDataContract> Attachments { get; set; }
    }
}
