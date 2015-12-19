using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SectorsManagement
{
    public interface ISectorsSearchFilter : IPagedFilter
    {            
        string SectorName { get; set; }
        bool? GetParentSectorsOnly { get; set; }
    }
}
