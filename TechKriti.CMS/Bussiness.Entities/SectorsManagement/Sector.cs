using Bussiness.Entities.Paging;
using Common.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.SectorsManagement
{
    public class Sector : ISector
    {
        public int Id { get; set; }
        public string SectorName { get; set; }
        public int? ParentSectorId { get; set; }       
    }
}
