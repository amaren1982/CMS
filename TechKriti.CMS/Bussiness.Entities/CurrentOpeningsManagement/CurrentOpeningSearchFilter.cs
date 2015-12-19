using Bussiness.Entities.Paging;
using Common.CurrentOpeningManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.CurrentOpeningManagement
{   
    public class CurrentOpeningSearchFilter : PagedFilter, ICurrentOpeningSearchFilter
    {       
        public string Company { get; set; }
        public string Position { get; set; }
        public string Qualification { get; set; }
        public string SkillSet { get; set; }
        public string Email { get; set; }
        public DateTime? OpenTillDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
