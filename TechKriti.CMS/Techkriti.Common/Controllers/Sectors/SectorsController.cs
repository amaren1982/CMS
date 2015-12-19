using Datacontracts.AttachmentsManagement;
using Datacontracts.Misc;
using Datacontracts.NewsManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.Sectors
{
    public class SectorsController
    {
        public static bool SaveSector(SectorDataContract sectorToBeSaved, List<AttachmentDataContract> attachmentsToBeSaved, 
                                                                          List<AttachmentDataContract> attachmentsToBeUpdated)
        {
            try
            {
                if (sectorToBeSaved.Id > 0) return UpdateSector(sectorToBeSaved, attachmentsToBeSaved, attachmentsToBeUpdated);
                else return AddSector(sectorToBeSaved, attachmentsToBeSaved);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddSector(SectorDataContract sectorToBeSaved, List<AttachmentDataContract> attachments)
        {
            CreateSectorRequest request = new CreateSectorRequest();
            EmptyResponse response = null;
            request.SectorToBeSaved = sectorToBeSaved;
            request.AttachmentsToBeSaved = attachments;

            using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
            {
                response = client.ServiceChannel.CreateSector(request);
            }

            return response.Success;
        }

        public static bool UpdateSector(SectorDataContract sectorToBeUpdated, List<AttachmentDataContract> attachmentsToBeSaved, 
                                                                              List<AttachmentDataContract> attachmentsToBeUpdated)
        {
            UpdateSectorRequest request = new UpdateSectorRequest();
            EmptyResponse response = null;
            request.SectorToBeSaved = sectorToBeUpdated;
            request.AttachmentsToBeSaved = attachmentsToBeSaved;
            request.AttachmentsToBeUpdated = attachmentsToBeUpdated;          

            using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
            {
                response = client.ServiceChannel.UpdateSector(request);
            }

            return response.Success;
        }

        public static bool DeleteSector(int sectorId, out string errorMessage)
        {
            try
            {
                DeleteSectorRequest request = new DeleteSectorRequest();
                DeleteSectorResponse response = null;
                request.SectorID = sectorId;

                using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteSector(request);
                }

                errorMessage = response.FailureReason.ToString();
                return response.IsDeleted;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static SectorDataContract GetSectorById(int sectorId, out List<AttachmentDataContract> attachments)
        {
            GetSectorByIdRequest request = new GetSectorByIdRequest();
            GetSectorByIdResponse response = null;
            request.SectorId = sectorId;           
            attachments = new List<AttachmentDataContract>();

            try
            {
                using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
                {
                    response = client.ServiceChannel.GetSectorById(request);
                }

                attachments = response.Attachments;
                return response.Sector;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                return null;
            }
        }

        public static List<SectorDataContract> GetParentSectors()
        {
            int totalNumberOfRecords;
            return SearchSectors(string.Empty, null, null, true, out totalNumberOfRecords);
        }

        public static List<SectorDataContract> SearchSectors(string displayName, int? startIndex, int? count, bool? getParentSectorsOnly,
                                                                                                              out int totalNumnerOfRecords)
        {
            try
            {
                SearchSectorsRequest request = new SearchSectorsRequest();
                SearchSectorsResponse response = null;

                SectorSearchFilterDataContract filter = new SectorSearchFilterDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;
                filter.GetParentSectorsOnly = getParentSectorsOnly;        
                request.Filter = filter;

                using (SectorsManagementClient client = ProxyFactory.CreateSectorsManagementProxy())
                {
                    response = client.ServiceChannel.SearchSectors(request);
                }

                totalNumnerOfRecords = response.Count;
                return response.Sectors;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}