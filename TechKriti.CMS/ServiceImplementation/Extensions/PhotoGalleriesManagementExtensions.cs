using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.PhotoGalleryManagement;
using Bussiness.Entities.PhotoGalleryManagement;
using Datacontracts.PhotoGalleryManagement;

namespace ServiceImplementation.Extensions.PhotoGalleryManagement
{
    public static class PhotoGalleriesManagementExtensions
    {
        public static List<PhotoGalleryDataContract> ToDataContract(this List<DAL.Datamodel.PhotoGallery> items)
        {
            List<PhotoGalleryDataContract> dc = new List<PhotoGalleryDataContract>();

            items.ForEach( i => dc.Add(i.ToDataContract()) );

            return dc;
        }

        public static PhotoGalleryDataContract ToDataContract(this DAL.Datamodel.PhotoGallery item)
        {
            PhotoGalleryDataContract dc = new PhotoGalleryDataContract();

            dc.Id = item.Id;
           // dc.CreatedBy = item.CreatedBy;
            dc.DisplayName = item.DisplayName;           
            dc.SectionId = item.SectionId;           

            return dc;
        }

        public static IPhotoGallery ToBussinessEntity(this PhotoGalleryDataContract item)
        {
            IPhotoGallery bussinessEntitySector = new Bussiness.Entities.PhotoGalleryManagement.PhotoGallery();

            bussinessEntitySector.Id = item.Id;
            bussinessEntitySector.CreatedBy = item.CreatedBy;
            bussinessEntitySector.DisplayName = item.DisplayName;           
            bussinessEntitySector.SectionId = item.SectionId;

            return bussinessEntitySector;
        }

        public static IPhotoGallerySearchFilter ToFilter(this PhotoGallerySearchFilterDataContract item)
        {
            IPhotoGallerySearchFilter filter = new PhotoGallerySearchFilter();

            filter.Count = item.Count;
            filter.CreatedBy = item.CreatedBy;
            filter.DisplayName = item.DisplayName;           
            filter.SectionId = item.SectionId;
            filter.StartIndex = item.StartIndex;            

            return filter;
        }
    }
}
