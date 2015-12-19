using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.ContentManagement
{
    [DataContract]
    public class SearchMenuResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<MenuDataContract> Menus { get; set; }
    }
}
