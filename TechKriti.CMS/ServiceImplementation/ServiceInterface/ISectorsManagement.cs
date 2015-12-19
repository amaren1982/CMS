using Datacontracts.Misc;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.SectionManagement;

namespace ServiceInterface
{
   [ServiceContract]
    public interface ISectorsManagement
    {
       [OperationContract]
       EmptyResponse CreateSector(CreateSectorRequest request);

       [OperationContract]
       EmptyResponse UpdateSector(UpdateSectorRequest request);

       [OperationContract]
       DeleteSectorResponse DeleteSector(DeleteSectorRequest request);

       [OperationContract]
       SearchSectorsResponse SearchSectors(SearchSectorsRequest request);

       [OperationContract]
       GetSectorByIdResponse GetSectorById(GetSectorByIdRequest request);

       [OperationContract]
       GetSectionsResponse GetSections(GetSectionsRequest request);

       [OperationContract]
       EmptyResponse CreateSection(CreateSectionRequest request);
    }
}
