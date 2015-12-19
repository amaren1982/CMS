using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.ContentManagement;

namespace Datacontracts.ContentManagement
{
    [DataContract, Serializable]
    public class MenuDataContract : IMenu
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string MenuName { get; set; }
        [DataMember]
        public int? ParentMenuId { get; set; }
        [DataMember]
        public int DisplayOrderId { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
    }
}
