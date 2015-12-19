using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.ContentManagement
{
    [DataContract]
    public class GetMenuByIdRequest
    {
        [DataMember]
        public int MenuId { get; set; }
    }
}
