using Common.Paging;
using Common.QualificaionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.QualificationManagement
{
    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
