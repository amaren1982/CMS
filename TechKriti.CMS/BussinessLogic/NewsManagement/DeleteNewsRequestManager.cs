using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class DeleteNewsRequestManager
    {
        private int newsID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteNewsRequestManager(int newsId)
        {           
            this.newsID = newsId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response
        {
            public bool Success { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateNewsQuery = from news in dbContext.News
                                 where news.Id == this.newsID
                                 select news;

            News candidateNews = candidateNewsQuery.First();
            dbContext.News.Remove(candidateNews);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
