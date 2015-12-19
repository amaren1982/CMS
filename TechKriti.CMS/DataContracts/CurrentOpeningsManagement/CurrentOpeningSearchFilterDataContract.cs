using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.CurrentOpeningManagement
{
   [DataContract]
    public class CurrentOpeningSearchFilterDataContract : PagedFilter
    {
        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string Position { get; set; }

        [DataMember]
        public string Qualification { get; set; }

        [DataMember]
        public string SkillSet { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime? OpenTillDate { get; set; }

        [DataMember]
        public bool? IsActive { get; set; }
    }
}
