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
    public class Page : IPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SeoTitle { get; set; }
        public string MetaKeys { get; set; }
        public string Description { get; set; }
        public string H1 { get; set; }
        public string H2 { get; set; } 
        public int MenuId { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public PageStatus Status { get; set; }
    }
}
