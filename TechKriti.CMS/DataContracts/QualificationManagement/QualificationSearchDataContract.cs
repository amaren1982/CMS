using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.QualificaionManagement;
using DataContracts.Paging;

namespace Datacontracts.QualificationManagement
{
    [DataContract]
    public class QualificationSearchDataContract : PagedFilter, IQualificationSearchFilter
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int? SubCategoryId { get; set; }
    }
}
