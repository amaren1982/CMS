using Bussiness.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.QualificaionManagement;

namespace Bussiness.Entities.QualificationManagement
{
    public class Qualification : IQualification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? SubCategoryId { get; set; }
        public int? ChildCategoryId { get; set; }
    }
}
