using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SectorsManagement
{
    public interface ISector
    {
        int Id { get; set; }
        string SectorName { get; set; }
        int? ParentSectorId { get; set; }
    }
}
