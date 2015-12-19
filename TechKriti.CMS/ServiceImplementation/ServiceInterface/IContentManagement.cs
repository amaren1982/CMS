using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.ContentManagement;

namespace ServiceInterface
{
   [ServiceContract]
    public interface IContentManagement
    {
       [OperationContract]
       EmptyResponse CreateMenu(CreateMenuRequest request);

       [OperationContract]
       EmptyResponse UpdateMenu(UpdateMenuRequest request);

       [OperationContract]
       DeleteMenuResponse DeleteMenu(DeleteMenuRequest request);

       [OperationContract]
       GetMenuByIdResponse GetMenuById(GetMenuByIdRequest request);

       [OperationContract]
       SearchMenuResponse SearchMenu(SearchMenuRequest request);

       [OperationContract]
       EmptyResponse CreatePage(CreatePageRequest request);

       [OperationContract]
       EmptyResponse UpdatePage(UpdatePageRequest request);

       [OperationContract]
       EmptyResponse DeletePage(DeletePageRequest request);

       [OperationContract]
       GetPageByIdResponse GetPageById(GetPageByIdRequest request);

       [OperationContract]
       SearchPageResponse SearchPages(SearchPageRequest request);
    }
}
