using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.SectorsManagement
{
    [DataContract, Serializable]
    public class SectorDataContract : ISector
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SectorName { get; set; }
        [DataMember]
        public int? ParentSectorId { get; set; }       
    }
}
