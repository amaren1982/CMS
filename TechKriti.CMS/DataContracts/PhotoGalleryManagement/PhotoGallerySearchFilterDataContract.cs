using Common.SectorsManagement;
using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.PhotoGalleryManagement;

namespace Datacontracts.PhotoGalleryManagement
{
    [DataContract]
    public class PhotoGallerySearchFilterDataContract : PagedFilter, IPhotoGallerySearchFilter
    {
        [DataMember]
        public int Id { get; set; }        
        [DataMember]
        public int? SectionId { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }
    }
}
