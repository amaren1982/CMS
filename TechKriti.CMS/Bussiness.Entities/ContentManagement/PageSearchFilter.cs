using Bussiness.Entities.Paging;
using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ContentManagement;

namespace Bussiness.Entities.ContentManagement
{
    public class PageSearchFilter : PagedFilter, IPageSearchFilter
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public PageStatus Status { get; set; }
    }
}
