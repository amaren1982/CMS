using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ContentManagement
{
    public interface IPage
    {
        int Id { get; set; }
        string Title { get; set; }
        string SeoTitle { get; set; }
        string MetaKeys { get; set; }
        string Description { get; set; }
        string H1 { get; set; }
        string H2 { get; set; }     
        int MenuId { get; set; }
        string Content { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        PageStatus Status { get; set; }
    }
}
