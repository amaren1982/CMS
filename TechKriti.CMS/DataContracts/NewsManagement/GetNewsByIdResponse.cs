using Datacontracts.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.NewsManagement
{
    [DataContract]
    public class GetNewsByIdResponse
    {
        [DataMember]
        public NewsDataContract News { get; set; }      
    }
}
