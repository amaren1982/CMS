using Common.NewsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class SearchNewsRequestManager
    {   
        private TechKritiCMSEntities dbContext = null;
        INewsSearchFilter filter;      

        public SearchNewsRequestManager(INewsSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        { 
            public List<News> News { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateNewsQuery = from news in dbContext.News                                
                                     select news;
            var countQuery = from news in dbContext.News
                             select news;

            // filter the list if needed
            if (! string.IsNullOrEmpty(this.filter.NewsDescription) )
            {
                candidateNewsQuery = candidateNewsQuery.Where(item => item.NewsDescription.Contains( this.filter.NewsDescription ));
                countQuery = countQuery.Where(item => item.NewsDescription.Contains( this.filter.NewsDescription) );
            }

            // filter the list if needed
            if (this.filter.IsActive.HasValue && this.filter.IsActive.Value)
            {
                candidateNewsQuery = candidateNewsQuery.Where( item => (item.IsActive.HasValue) &&
                                                                      (item.IsActive == this.filter.IsActive) );

                countQuery = countQuery.Where( item => (item.IsActive.HasValue) &&
                                                      (item.IsActive == this.filter.IsActive) );
            }

            // filter the list if needed
            if ( this.filter.Date.HasValue )
            {
                candidateNewsQuery = candidateNewsQuery.Where(item => item.Date.Value.Year == this.filter.Date.Value.Year &&
                                                                       item.Date.Value.Month == this.filter.Date.Value.Month &&
                                                                       item.Date.Value.Day == this.filter.Date.Value.Day);

                countQuery = countQuery.Where(item => item.Date.Value.Year == this.filter.Date.Value.Year &&
                                                      item.Date.Value.Month == this.filter.Date.Value.Month &&
                                                      item.Date.Value.Day == this.filter.Date.Value.Day);
            }

            // paginate
            candidateNewsQuery = candidateNewsQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                        Take(this.filter.Count.Value);

            // execute the query 
            List<News> candidateNews = candidateNewsQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();         

            response.News = candidateNews;

            return response;
        }
    }
}
