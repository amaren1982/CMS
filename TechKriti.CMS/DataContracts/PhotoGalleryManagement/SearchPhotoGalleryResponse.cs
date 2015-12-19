using Datacontracts.SectorsManagement;
using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.PhotoGalleryManagement
{
    [DataContract]
    public class SearchPhotoGalleryResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<PhotoGalleryDataContract> PhotoGalleries { get; set; }
    }
}
