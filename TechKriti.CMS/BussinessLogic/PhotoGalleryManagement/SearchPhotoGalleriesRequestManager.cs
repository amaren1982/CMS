using Common.NewsManagement;
using Common.SectorsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.PhotoGalleryManagement;

namespace BussinessLogic.PhotoGalleryManagement
{
    public class SearchPhotoGalleriesRequestManager
    {
        IPhotoGallerySearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchPhotoGalleriesRequestManager(IPhotoGallerySearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<PhotoGallery> PhotoGalleries { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePhotoGalleriesQuery = from photoGalleries in dbContext.PhotoGalleries
                                        select photoGalleries;
            var countQuery = from photoGalleries in dbContext.PhotoGalleries
                             select photoGalleries;

            // filter the list if needed
            if (! string.IsNullOrEmpty( this.filter.DisplayName) )
            {
                candidatePhotoGalleriesQuery = candidatePhotoGalleriesQuery.Where(item => item.DisplayName.Contains(this.filter.DisplayName));
                countQuery = countQuery.Where(item => item.DisplayName.Contains(this.filter.DisplayName));
            }           

            //// filter the list if needed
            if ( this.filter.SectionId > 0 )
            {
                candidatePhotoGalleriesQuery = candidatePhotoGalleriesQuery.Where(item => item.SectionId == this.filter.SectionId);
                countQuery = countQuery.Where(item => item.SectionId == this.filter.SectionId );
            }          

            // paginate
            candidatePhotoGalleriesQuery = candidatePhotoGalleriesQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                        Take(this.filter.Count.Value);

            // execute the query 
            List<PhotoGallery> candidatePhotoGalleries = candidatePhotoGalleriesQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();

            response.PhotoGalleries = candidatePhotoGalleries;

            return response;
        }
    }
}
