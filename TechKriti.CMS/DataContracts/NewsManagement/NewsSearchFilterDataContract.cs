using Common.NewsManagement;
using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.NewsManagement
{
   [DataContract]
    public class NewsSearchFilterDataContract : PagedFilter, INewsSearchFilter
    {
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public string NewsDescription { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
    }
}
