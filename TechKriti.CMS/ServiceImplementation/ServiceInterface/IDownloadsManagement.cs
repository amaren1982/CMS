using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.DownloadsManagement;

namespace ServiceInterface
{
   [ServiceContract]
    public interface IDownloadsManagement
    {
       [OperationContract]
       EmptyResponse CreateDownload(CreateDownloadRequest request);

       [OperationContract]
       EmptyResponse UpdateDownload(UpdateDownloadRequest request);

       [OperationContract]
       EmptyResponse DeleteDownload(DeleteDownloadRequest request);

       [OperationContract]
       GetDownloadByIdResponse GetDownloadById(GetDownloadByIdRequest request);

       [OperationContract]
       SearchDownloadsResponse SearchDownloads(SearchDownloadsRequest request);
    }
}
