using BussinessLogic.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceImplementation.Extensions.NewsManagement;
using Datacontracts.NewsManagement;
using Datacontracts.Misc;

namespace ServiceInterface.ServiceImplementation.NewsManagement
{
    public class NewsManagementServiceImpl : INewsManagement
    {
        public EmptyResponse CreateNews(CreateNewsRequest request)
        {
            try
            {
                CreateNewsRequestManager requestManger = new CreateNewsRequestManager( request.NewsToBeSaved.ToBussinessEntity() );
                CreateNewsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public EmptyResponse UpdateNews(UpdateNewsRequest request)
        {
            try
            {
                UpdateNewsRequestManager requestManger = new UpdateNewsRequestManager( request.NewsToBeUpdated.ToBussinessEntity() );
                UpdateNewsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public EmptyResponse DeleteNews(DeleteNewsRequest request)
        {
            try
            {
                DeleteNewsRequestManager requestManger = new DeleteNewsRequestManager(request.NewsID);
                DeleteNewsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public SearchNewsResponse SearchNews(SearchNewsRequest request)
        {
            try
            {
                SearchNewsRequestManager requestManger = new SearchNewsRequestManager( request.Filter.ToFilter() );
                SearchNewsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchNewsResponse response = new SearchNewsResponse();
                response.News = bllResponse.News.ToDatacontract();
                response.Count = bllResponse.TotalNumberofRecords;
             
                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public GetNewsByIdResponse GetNewsById(GetNewsByIdRequest request)
        {
            try
            {
                GetNewsByIdRequestManager requestManger = new GetNewsByIdRequestManager(request.NewsId);
                GetNewsByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetNewsByIdResponse response = new GetNewsByIdResponse();
                response.News = bllResponse.News.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}
