using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PhotoGalleryManagement
{
    public interface IPhotoGallerySearchFilter : IPagedFilter
    {        
        int? SectionId { get; set; }
        string DisplayName { get; set; }
        int? CreatedBy { get; set; }
    }
}
