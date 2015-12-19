using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.SectionManagement;

namespace Datacontracts.SectionManagement
{
    [DataContract, Serializable]
    public class SectionDataContract : ISection
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }  
        [DataMember]
        public SectionType SectionType { get; set; } 
    }
}
