using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class GetNewsByIdRequestManager
    {
        private int newsId;
        private TechKritiCMSEntities dbContext = null;

        public GetNewsByIdRequestManager(int newsId)
        {
            this.newsId = newsId;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public News News { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateNewQuery = from news in dbContext.News
                                     where news.Id == this.newsId
                                 select news;

            News candidateNew = candidateNewQuery.First();
            response.News = candidateNew;

            return response;
        }
    }
}
