using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Paging
{
    public interface IPagedFilter
    {        
         int? StartIndex { get; set; }       
         int? Count { get; set; }
    }
}
