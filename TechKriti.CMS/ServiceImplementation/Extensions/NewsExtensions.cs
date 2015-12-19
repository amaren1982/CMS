using Bussiness.Entities.NewsManagement;
using Common.NewsManagement;
using Datacontracts.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Extensions.NewsManagement
{
    public static class NewsExtensions
    {
        public static List<NewsDataContract> ToDatacontract(this List<DAL.Datamodel.News> news)
        {
            List<NewsDataContract> dc = new List<NewsDataContract>();

            news.ForEach(item =>
                {
                    NewsDataContract dcNews = new NewsDataContract();
                    dc.Add(item.ToDataContract());
                });

            return dc;
        }

        public static NewsDataContract ToDataContract(this DAL.Datamodel.News item)
        {
            NewsDataContract dcNews = new NewsDataContract();
            dcNews.Id = item.Id;
            dcNews.NewsDescription = item.NewsDescription;
            dcNews.IsActive = item.IsActive;
            dcNews.Date = item.Date;

            return dcNews;
        }

        public static INewsSearchFilter ToFilter(this NewsSearchFilterDataContract filter)
        {
            INewsSearchFilter bussinessEntityFilter = new NewsSearchFilter();
            bussinessEntityFilter.Count = filter.Count;
            bussinessEntityFilter.StartIndex = filter.StartIndex;
            bussinessEntityFilter.Date = filter.Date;
            bussinessEntityFilter.NewsDescription = filter.NewsDescription;
            bussinessEntityFilter.IsActive = filter.IsActive;

            return bussinessEntityFilter;
        }

        public static INews ToBussinessEntity(this NewsDataContract item)
        {
            INews bussinessEntityNews = new News();

            bussinessEntityNews.Id = item.Id;
            bussinessEntityNews.NewsDescription = item.NewsDescription;
            bussinessEntityNews.IsActive = item.IsActive;
            bussinessEntityNews.Date = item.Date;

            return bussinessEntityNews;
        }
    }
}
