using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.PhotoGalleryManagement;

namespace Datacontracts.PhotoGalleryManagement
{
    [DataContract]
    public class SearchPhotoGalleryRequest
    {
        [DataMember]
        public PhotoGallerySearchFilterDataContract Filter { get; set; }
    }
}
