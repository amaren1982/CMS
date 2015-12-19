using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.Misc
{
    [DataContract]
    public class EmptyResponse
    {
        [DataMember]
        public bool Success { get; set; }
    }
}
