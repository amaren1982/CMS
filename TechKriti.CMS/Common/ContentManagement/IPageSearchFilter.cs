using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ContentManagement
{
    public interface IPageSearchFilter : IPagedFilter
    {
        int Id { get; set; }
        string Title { get; set; }
        PageStatus Status { get; set; }
    }
}
