using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.CurrentOpeningManagement;

namespace Datacontracts.CurrentOpeningManagement
{
    [DataContract]
    public class SearchCurrentOpeningsResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<CurrentOpeningDataContract> CurrentOpenings { get; set; }
    }
}
