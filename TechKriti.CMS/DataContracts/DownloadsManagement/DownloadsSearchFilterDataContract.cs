using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Paging;
using Common.DownloadsManagement;
using System.Runtime.Serialization;

namespace DataContracts.Downloads
{
    [DataContract]
    public class DownloadsSearchFilterDataContract : PagedFilter, IDownloadsSearchFilter
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
        public bool? IsActive { get; set; }
    }
}
