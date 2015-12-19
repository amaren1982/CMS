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
    public class CategorySearchDataContract : PagedFilter, ICategorySearchFilter
    {
        [DataMember]
        public int? CategoryId { get; set; }
        [DataMember]
        public int? ParentCategoryId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string CategoryCode { get; set; }
    }
}
