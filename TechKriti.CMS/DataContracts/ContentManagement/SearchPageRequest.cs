using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.ContentManagement
{
    [DataContract]
    public class SearchPageRequest
    {
        public SearchPageRequest() { Filter = new PageSearchFilterDataContract(); }

        [DataMember]
        public PageSearchFilterDataContract Filter { get; set; }
    }
}
