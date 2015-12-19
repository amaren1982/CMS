using Common.AttachmentsManagement;
using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PhotoGalleryManagement
{
    public interface IPhotoGallery 
    {
        int Id { get; set; }        
        int? SectionId { get; set; }
        string DisplayName { get; set; }
        int? CreatedBy { get; set; }       
    }
}
