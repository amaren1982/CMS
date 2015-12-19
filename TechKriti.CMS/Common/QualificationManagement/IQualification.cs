using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QualificaionManagement
{
    public interface IQualification
    {
        int Id { get; set; }
        string Description { get; set; }      
        int? ChildCategoryId { get; set; }
    }
}
