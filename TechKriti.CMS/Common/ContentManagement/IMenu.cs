using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ContentManagement
{
    public interface IMenu
    {
        int Id { get; set; }
        string MenuName { get; set; }      
        int? ParentMenuId { get; set; }
        int DisplayOrderId { get; set; }
        bool? IsActive { get; set; }
    }
}
