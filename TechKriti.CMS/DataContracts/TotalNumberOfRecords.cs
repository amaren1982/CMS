using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Paging
{
    [DataContract]
    public class TotalNumberOfRecords
    {   
        [DataMember]
        public int Count { get; set; }
    }
}
