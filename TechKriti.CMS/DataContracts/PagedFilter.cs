using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Paging
{
    [DataContract]
    public class PagedFilter : IPagedFilter
    {
        [DataMember]
        public int? StartIndex { get; set; }

        [DataMember]
        public int? Count { get; set; }
    }
}
