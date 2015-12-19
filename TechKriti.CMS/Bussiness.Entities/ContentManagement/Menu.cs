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
    public class Menu : IMenu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int? ParentMenuId { get; set; }
        public int DisplayOrderId { get; set; }
        public bool? IsActive { get; set; } 
    }
}
