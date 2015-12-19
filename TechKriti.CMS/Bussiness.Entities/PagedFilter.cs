using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.Paging
{
    public class PagedFilter : IPagedFilter
    {  
        public int? StartIndex { get; set; }
        public int? Count { get; set; }
    }
}
