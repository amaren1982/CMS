using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.PhotoGalleryManagement
{
    [DataContract]
    public class GetPhotoGalleryByIdRequest
    {
        [DataMember]
        public int PhotoGalleryId { get; set; }
    }
}
