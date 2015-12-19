using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QualificaionManagement
{
    public interface ICategorySearchFilter : IPagedFilter
    {
        int? CategoryId { get; set; }
        int? ParentCategoryId { get; set; }
        string CategoryName { get; set; }
        string CategoryCode { get; set; }
    }
}
