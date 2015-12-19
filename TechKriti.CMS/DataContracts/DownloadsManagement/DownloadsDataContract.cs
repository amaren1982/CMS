using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.DownloadsManagement;

namespace DataContracts.Downloads
{
    [DataContract, Serializable]
    public class DownloadsDataContract : IDownload
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
