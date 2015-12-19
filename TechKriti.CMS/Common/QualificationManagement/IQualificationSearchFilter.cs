using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QualificaionManagement
{
    public interface IQualificationSearchFilter : IPagedFilter
    {
        int Id { get; set; }
        string Description { get; set; }
        int? SubCategoryId { get; set; }
    }
}
