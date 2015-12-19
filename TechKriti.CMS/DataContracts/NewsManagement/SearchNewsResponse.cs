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
    public class SearchNewsResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<NewsDataContract> News { get; set; }
    }
}
