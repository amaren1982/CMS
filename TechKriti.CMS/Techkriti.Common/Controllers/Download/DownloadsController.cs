using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataContracts.Downloads;
using Datacontracts.DownloadsManagement;
using Datacontracts.AttachmentsManagement;
using Techkriti.Common.Proxy;
using Datacontracts.SectionManagement;
using Common.SectionManagement;

namespace Techkriti.Common.Controllers.Downloads
{
    public class DownloadsController
    {
        public static bool SaveDownload(DownloadsDataContract downloadToBeSaved, List<AttachmentDataContract> attachments)
        {
            try
            {
                if (downloadToBeSaved.Id > 0) return UpdateDownload(downloadToBeSaved, attachments);
                else return AddDownload(downloadToBeSaved, attachments);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddDownload(DownloadsDataContract downloadToBeSaved, List<AttachmentDataContract> attachments)
        {
            CreateDownloadRequest request = new CreateDownloadRequest();
            EmptyResponse response = null;
            request.DownloadTobeSaved = downloadToBeSaved;
            request.AttachmentsToBeSaved = attachments;

            using (DownloadsManagementClient client = ProxyFactory.CreateDownloadsManagementProxy())
            {
                response = client.ServiceChannel.CreateDownload(request);
            }

            return response.Success;
        }

        public static bool UpdateDownload(DownloadsDataContract downloadToBeUpdated, List<AttachmentDataContract> attachments)
        {
            UpdateDownloadRequest request = new UpdateDownloadRequest();
            request.DownloadTobeSaved = downloadToBeUpdated;
            request.AttachmentsToBeSaved = attachments;

            EmptyResponse response = null;

            using (DownloadsManagementClient client = ProxyFactory.CreateDownloadsManagementProxy())
            {
                response = client.ServiceChannel.UpdateDownload(request);
            }

            return response.Success;
        }

        public static bool DeleteDownload(int downloadId)
        {
            try
            {
                DeleteDownloadRequest request = new DeleteDownloadRequest();
                EmptyResponse response = null;
                request.DownloadID = downloadId;

                using (DownloadsManagementClient client = ProxyFactory.CreateDownloadsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteDownload(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DownloadsDataContract GetDownloadById(int downloadId, out  List<AttachmentDataContract> attachments)
        {
            GetDownloadByIdRequest request = new GetDownloadByIdRequest();
            request.DownloadId = downloadId;
            GetDownloadByIdResponse response = null;           

            try
            {
                using (DownloadsManagementClient client = ProxyFactory.CreateDownloadsManagementProxy())
                {
                    response = client.ServiceChannel.GetDownloadById(request);
                }

                attachments = response.Attachments;
                return response.Download;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<DownloadsDataContract> SearchDownloads(string displayName, int startIndex, int count, int sectionId, bool isActive,
                                                             out int totalNumnerOfRecords)
        {
            try
            {
                SearchDownloadsRequest request = new SearchDownloadsRequest();
                SearchDownloadsResponse response = null;

                DownloadsSearchFilterDataContract filter = new DownloadsSearchFilterDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;                
                filter.DisplayName = displayName;
                filter.SectionId = sectionId;
                filter.IsActive = isActive;
        
                request.Filter = filter;

                using (DownloadsManagementClient client = ProxyFactory.CreateDownloadsManagementProxy())
                {
                    response = client.ServiceChannel.SearchDownloads(request);
                }

                totalNumnerOfRecords = response.Count;
                return response.Downloads;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<SectionDataContract> LoadSectionsForDownloads() { return LoadSections(SectionType.Downloads); }

        private static List<SectionDataContract> LoadSections(SectionType type)
        {
            try
            {
                GetSectionsRequest request = new GetSectionsRequest();
                request.Filter = new SectionSearchFilterDataContract();
                request.Filter.SectionType = type;
                GetSectionsResponse response = null;

                using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
                {
                    response = client.ServiceChannel.GetSections(request);
                }

                return response.Sections;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static bool SaveSection(SectionDataContract sectionTOBeSaved)
        {
            try
            {
                CreateSectionRequest request = new CreateSectionRequest();
                request.SectionToBeSaved = sectionTOBeSaved;               
                EmptyResponse response = null;

                using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
                {
                    response = client.ServiceChannel.CreateSection(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}