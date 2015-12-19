using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.SectionManagement
{
    [DataContract]
    public class CreateSectionRequest 
    {      
        [DataMember]
        public SectionDataContract SectionToBeSaved { get; set; }      
       
    }
}
