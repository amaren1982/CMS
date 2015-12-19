using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.QualificaionManagement;

namespace Datacontracts.QualificationManagement
{
    [DataContract, Serializable]
    public class CategoryDataContract : ICategory
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int? ParentCategoryId { get; set; }
    }
}
