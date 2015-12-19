using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SectionManagement
{
    public interface ISection
    {
        int Id { get; set; }
        string Name { get; set; }
        SectionType SectionType { get; set; } 
    }
}
