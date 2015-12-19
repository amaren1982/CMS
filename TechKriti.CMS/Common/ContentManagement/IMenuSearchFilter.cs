using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ContentManagement
{
    public interface IMenuSearchFilter : IPagedFilter
    {
        int Id { get; set; }
        string MenuName { get; set; }
        bool? IsActive { get; set; }
    }
}
