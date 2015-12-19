using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.NewsManagement
{
    [DataContract]
    public class SearchNewsRequest 
    {
        [DataMember]
        public NewsSearchFilterDataContract Filter { get; set; }
    }
}
