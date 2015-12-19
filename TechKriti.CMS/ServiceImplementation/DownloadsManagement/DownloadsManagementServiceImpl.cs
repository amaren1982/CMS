using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.DownloadsManagement;
using ServiceInterface;
using ServiceImplementation.Extensions.DownloadsManagement;
using BussinessLogic.DownloadsManagement;
using ServiceImplementation.Extensions.AttachmentsManagement;

namespace ServiceInterface.ServiceImplementation.DownloadsManagement
{
    public class DownloadsManagementServiceImpl : IDownloadsManagement
    {
        public EmptyResponse CreateDownload(CreateDownloadRequest request)
        {
            try 
            {
                CreateDownloadRequestManager requestManger = new CreateDownloadRequestManager( request.DownloadTobeSaved.ToBussinessEntity(),
                                                                                               request.AttachmentsToBeSaved.ToBussinessEntity() );
                CreateDownloadRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse UpdateDownload(UpdateDownloadRequest request)
        {
            try
            {
                UpdateDownloadRequestManager requestManger = new UpdateDownloadRequestManager( request.DownloadTobeSaved.ToBussinessEntity(),
                                                                                               request.AttachmentsToBeSaved.ToBussinessEntity() );
                UpdateDownloadRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse DeleteDownload(DeleteDownloadRequest request)
        {
            try
            {
                DeleteDownloadRequestManager requestManger = new DeleteDownloadRequestManager(request.DownloadID);
                DeleteDownloadRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetDownloadByIdResponse GetDownloadById(GetDownloadByIdRequest request)
        {
            try
            {
                GetDownloadByIdRequestManager requestManger = new GetDownloadByIdRequestManager(request.DownloadId);
                GetDownloadByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetDownloadByIdResponse response = new GetDownloadByIdResponse();
                response.Download = bllResponse.Download.ToDataContract();
                response.Attachments = bllResponse.Attachments.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }

        }

        public SearchDownloadsResponse SearchDownloads(SearchDownloadsRequest request)
        {
            try
            {
                SearchDownloadsRequestManager requestManger = new SearchDownloadsRequestManager( request.Filter.ToFilter() );
                SearchDownloadsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchDownloadsResponse response = new SearchDownloadsResponse();
                response.Downloads = bllResponse.Downloads.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }

        }
    }
}
