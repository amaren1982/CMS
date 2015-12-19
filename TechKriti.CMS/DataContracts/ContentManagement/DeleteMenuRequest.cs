using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.ContentManagement
{
    [DataContract]
    public class DeleteMenuRequest
    {
        [DataMember]
        public int MenuID { get; set; }
    }
}
