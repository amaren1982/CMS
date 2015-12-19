using Bussiness.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.QualificaionManagement;

namespace Bussiness.Entities.QualificationManagement
{
    public class CategorySearchFilter : PagedFilter, ICategorySearchFilter
    {
        public int? CategoryId { get; set; }    
        public int? ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
    }
}
