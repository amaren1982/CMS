using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.SectorsManagement
{
    [DataContract]
    public class DeleteSectorRequest
    {
        [DataMember]
        public int SectorID { get; set; }
    }
}
