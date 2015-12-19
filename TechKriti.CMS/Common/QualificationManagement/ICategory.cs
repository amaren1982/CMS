using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QualificaionManagement
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        int? ParentCategoryId { get; set; }
    }
}
