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
    public class MenuSearchFilter : PagedFilter, IMenuSearchFilter
    {
       public int Id { get; set; }
       public string MenuName { get; set; }
       public bool? IsActive { get; set; }
    }
}
