using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.CurrentOpeningManagement
{
    public interface ICurrentOpeningSearchFilter : IPagedFilter
    {
        string Company { get; set; }
        string Position { get; set; }
        string Qualification { get; set; }
        string SkillSet { get; set; }
        string Email { get; set; }
        DateTime? OpenTillDate { get; set; }
        bool? IsActive { get; set; }
    }
}
