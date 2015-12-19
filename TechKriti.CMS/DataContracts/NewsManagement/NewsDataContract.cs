using Common.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.NewsManagement
{
    [DataContract, Serializable]
    public class NewsDataContract : INews
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public string NewsDescription { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
    }
}
