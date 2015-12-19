using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ContentManagement;

namespace BussinessLogic.ContentMangement
{
    public class SearchPagesRequestManager
    {
        IPageSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchPagesRequestManager(IPageSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<Page> Pages { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidatePagesQuery = from pages in dbContext.Pages
                                      select pages;
            var countQuery = from pages in dbContext.Pages
                             select pages;

            // filter the list if needed
            if (!string.IsNullOrEmpty(this.filter.Title))
            {
                candidatePagesQuery = candidatePagesQuery.Where(item => item.Title.Contains(this.filter.Title));
                countQuery = countQuery.Where(item => item.Title.Contains(this.filter.Title));
            }

            // filter the list if needed
            if (!string.IsNullOrEmpty(this.filter.Title))
            {
                candidatePagesQuery = candidatePagesQuery.Where(item => item.Title.Contains(this.filter.Title));
                countQuery = countQuery.Where(item => item.Title.Contains(this.filter.Title));
            }

            // filter the list if needed
            if (this.filter.Status != PageStatus.All) 
            {
                candidatePagesQuery = candidatePagesQuery.Where(item => item.Status == (short)this.filter.Status);
                countQuery = countQuery.Where(item => item.Status == (short)this.filter.Status);
            }

            // paginate
            if (this.filter.StartIndex.HasValue && this.filter.Count.HasValue)
                candidatePagesQuery = candidatePagesQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                            Take(this.filter.Count.Value);

            response.Pages = candidatePagesQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();  
           
            return response;
        }
    }
}
