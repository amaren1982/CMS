using Datacontracts.Misc;
using Datacontracts.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
   [ServiceContract]
    public interface INewsManagement
    {
       [OperationContract]
       EmptyResponse CreateNews(CreateNewsRequest request);

       [OperationContract]
       EmptyResponse UpdateNews(UpdateNewsRequest request);

       [OperationContract]
       EmptyResponse DeleteNews(DeleteNewsRequest request);

       [OperationContract]
       SearchNewsResponse SearchNews(SearchNewsRequest request);

       [OperationContract]
       GetNewsByIdResponse GetNewsById(GetNewsByIdRequest request);
    }
}
