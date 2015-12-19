using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.ContentManagement;

namespace Datacontracts.ContentManagement
{
    [DataContract, Serializable]
    public class PageDataContract : IPage
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public PageStatus Status { get; set; }
        [DataMember]
        public string SeoTitle { get; set; }
        [DataMember]
        public string MetaKeys { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string H1 { get; set; }
        [DataMember]
        public string H2 { get; set; }
    }
}
