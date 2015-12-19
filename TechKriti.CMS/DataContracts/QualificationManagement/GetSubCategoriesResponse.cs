using DataContracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.QualificationManagement
{
    [DataContract]
    public class GetSubCategoriesResponse : TotalNumberOfRecords
    {
        [DataMember]
        public List<CategoryDataContract> Categories { get; set; }
    }
}
