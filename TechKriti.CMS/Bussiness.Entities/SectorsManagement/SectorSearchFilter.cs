using Bussiness.Entities.Paging;
using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.SectorsManagement
{
    public class SectorSearchFilter : PagedFilter, ISectorsSearchFilter
    {        
        public string Path { get; set; }        
        public string SectorName { get; set; }
        public bool? GetParentSectorsOnly { get; set; }
    }
}
