using Common.NewsManagement;
using Common.SectorsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DownloadsManagement;

namespace BussinessLogic.DownloadsManagement
{
    public class SearchDownloadsRequestManager
    {
        IDownloadsSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchDownloadsRequestManager(IDownloadsSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<Download> Downloads { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateDownloadsQuery = from downloads in dbContext.Downloads
                                          select downloads;
            var countQuery = from downloads in dbContext.Downloads
                             select downloads;

            // filter the list if needed
            if ( this.filter.IsActive.HasValue && this.filter.IsActive.Value )
            {
                candidateDownloadsQuery = candidateDownloadsQuery.Where( item => (item.IsActive.HasValue) &&
                                                                      (item.IsActive == this.filter.IsActive) );

                countQuery = countQuery.Where( item => (item.IsActive.HasValue) &&
                                                      (item.IsActive == this.filter.IsActive) );
            }

            // filter the list if needed
            if (! string.IsNullOrEmpty( this.filter.DisplayName) )
            {
                candidateDownloadsQuery = candidateDownloadsQuery.Where( item => item.DisplayName.Contains(this.filter.DisplayName) );
                countQuery = countQuery.Where( item => item.DisplayName.Contains(this.filter.DisplayName) );
            }           

            //// filter the list if needed
            if ( this.filter.SectionId > 0 )
            {
                candidateDownloadsQuery = candidateDownloadsQuery.Where( item => item.SectionId == this.filter.SectionId );
                countQuery = countQuery.Where( item => item.SectionId == this.filter.SectionId );
            }          

            // paginate
            candidateDownloadsQuery = candidateDownloadsQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                        Take(this.filter.Count.Value);

            // execute the query 
            List<Download> candidateDownloads = candidateDownloadsQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();

            response.Downloads = candidateDownloads;

            return response;
        }
    }
}
