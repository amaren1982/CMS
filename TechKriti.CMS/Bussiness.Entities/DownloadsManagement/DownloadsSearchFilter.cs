using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Entities.Paging;
using Common.DownloadsManagement;

namespace Bussiness.Entities.DownloadsManagement
{
    public class DownloadsSearchFilter : PagedFilter, IDownloadsSearchFilter
    {
        public int Id { get; set; }        
        public int? SectionId { get; set; }
        public string DisplayName { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
