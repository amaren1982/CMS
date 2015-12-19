using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.CurrentOpeningManagement
{
    [DataContract]
    public class GetCurrentOpeningByIdRequest
    {
        [DataMember]
        public int CurrentOpeningId { get; set; }
      
    }
}
