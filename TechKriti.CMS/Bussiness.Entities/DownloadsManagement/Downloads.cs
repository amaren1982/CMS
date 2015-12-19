using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DownloadsManagement;

namespace Bussiness.Entities.DownloadsManagement
{
    public class Downloads : IDownload
    {
        public int Id { get; set; }       
        public int? SectionId { get; set; }
        public string DisplayName { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
