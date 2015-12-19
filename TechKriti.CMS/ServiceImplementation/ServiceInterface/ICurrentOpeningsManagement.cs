using Datacontracts.CurrentOpeningManagement;
using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
   [ServiceContract]
    public interface ICurrentOpeningsManagement
    {
       [OperationContract]
       EmptyResponse CreateOpening(CreateCurrentOpeningRequest request);

       [OperationContract]
       EmptyResponse UpdateOpening(UpdateCurrentOpeningRequest request);

       [OperationContract]
       EmptyResponse DeleteOpening(DeleteCurrentOpeningRequest request);

       [OperationContract]
       GetCurrentOpeningByIdResponse GetCurrentOpeningById(GetCurrentOpeningByIdRequest request);

       [OperationContract]
       SearchCurrentOpeningsResponse SearchCurrentOpenings(SearchCurrentOpeningsRequest request);
    }
}
