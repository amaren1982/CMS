using Common.NewsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class CreateNewsRequestManager
    {
        INews newsToBeCreated;
        private TechKritiCMSEntities dbContext = null;        

        public CreateNewsRequestManager(INews news)
        {
            newsToBeCreated = news;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response  { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            News candidateNews = new News();
            candidateNews.NewsDescription = newsToBeCreated.NewsDescription;
            candidateNews.Date = newsToBeCreated.Date;
            candidateNews.IsActive = newsToBeCreated.IsActive;
            candidateNews.CreatedDate = DateTime.Now;            

            dbContext.News.Add(candidateNews);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
