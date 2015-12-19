using Bussiness.Entities.Paging;
using Common.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.NewsManagement
{
    public class NewsSearchFilter : PagedFilter, INewsSearchFilter
    {       
        public DateTime? Date { get; set; }       
        public string NewsDescription { get; set; }        
        public bool? IsActive { get; set; }
    }
}
