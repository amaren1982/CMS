using Bussiness.Entities.Paging;
using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.SectionManagement;

namespace Bussiness.Entities.SectionManagement
{
    public class SectionSearchFilter : PagedFilter, ISectionSearchFilter
    {        
        public SectionType SectionType { get; set; }        
       
    }
}
