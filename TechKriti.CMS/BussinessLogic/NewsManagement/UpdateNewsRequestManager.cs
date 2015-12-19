using Common.NewsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class UpdateNewsRequestManager
    {
        //private int newsID;
        //private string description = string.Empty;
        //private DateTime? date = null;
        //private bool? isActive;

        INews newsToBeUpdated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateNewsRequestManager(INews news)
        {
            newsToBeUpdated = news;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateNewsQuery = from news in dbContext.News
                                     where news.Id == newsToBeUpdated.Id
                                     select news;

            News candidateNews = candidateNewsQuery.First();

            candidateNews.NewsDescription = newsToBeUpdated.NewsDescription;
            candidateNews.ModifiedDate = DateTime.Now;
            candidateNews.Date = newsToBeUpdated.Date;
            candidateNews.IsActive = newsToBeUpdated.IsActive;
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
