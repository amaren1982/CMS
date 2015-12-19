using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.NewsManagement
{
    public interface INewsSearchFilter : IPagedFilter
    {   
        DateTime? Date { get; set; }       
        string NewsDescription { get; set; }       
        bool? IsActive { get; set; }
    }
}
