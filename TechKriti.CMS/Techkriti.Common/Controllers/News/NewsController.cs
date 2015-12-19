using Datacontracts.Misc;
using Datacontracts.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.News
{
    public class NewsController
    {
        public static bool SaveNews(NewsDataContract newsToBeSaved)
        {
            try
            {
                if (newsToBeSaved.Id > 0) return UpdateNews(newsToBeSaved);
                else return AddNews(newsToBeSaved);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddNews(NewsDataContract newsToBeSaved)
        {
            CreateNewsRequest request = new CreateNewsRequest();
            EmptyResponse response = null;
            request.NewsToBeSaved = newsToBeSaved;

            using (NewsManagementClient client = ProxyFactory.CreateNewsManagementProxy())
            {
                response = client.ServiceChannel.CreateNews(request);
            }

            return response.Success;
        }

        public static bool UpdateNews(NewsDataContract newsToBeUpdated)
        {
            UpdateNewsRequest request = new UpdateNewsRequest();
            request.NewsToBeUpdated = newsToBeUpdated;

            EmptyResponse response = null;

            using (NewsManagementClient client = ProxyFactory.CreateNewsManagementProxy())
            {
                response = client.ServiceChannel.UpdateNews(request);
            }

            return response.Success;
        }

        public static bool DeleteNews(int newsId)
        {
            try
            {
                DeleteNewsRequest request = new DeleteNewsRequest();
                EmptyResponse response = null;
                request.NewsID = newsId;

                using (NewsManagementClient client = ProxyFactory.CreateNewsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteNews(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static NewsDataContract GetNewsById(int newsId)
        {
            GetNewsByIdRequest request = new GetNewsByIdRequest();
            request.NewsId = newsId;
            GetNewsByIdResponse response = null;           

            try
            {
                using (NewsManagementClient client = ProxyFactory.CreateNewsManagementProxy())
                {
                    response = client.ServiceChannel.GetNewsById(request);
                }

                return response.News;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                return null;
            }
        }

        public static List<NewsDataContract> SearchNews(string description, DateTime? date, int startIndex, int count,
                                                        bool? isActive, out int totalNumnerOfRecords)
        {
            try
            {
                SearchNewsRequest request = new SearchNewsRequest();
                SearchNewsResponse response = null;

                NewsSearchFilterDataContract filter = new NewsSearchFilterDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;
                if (!string.IsNullOrEmpty(description)) filter.NewsDescription = description;
                if (date.HasValue) filter.Date = date;
                filter.IsActive = isActive;

                request.Filter = filter;

                using (NewsManagementClient client = ProxyFactory.CreateNewsManagementProxy())
                {
                    response = client.ServiceChannel.SearchNews(request);
                }

                totalNumnerOfRecords = response.Count;

                return response.News;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}