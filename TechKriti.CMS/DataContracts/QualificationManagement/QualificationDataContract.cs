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
    public class QualificationDataContract : IQualification
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }       
        [DataMember]
        public int? ChildCategoryId { get; set; }
        [DataMember]
        public CategoryDataContract Category { get; set; }
    }
}
