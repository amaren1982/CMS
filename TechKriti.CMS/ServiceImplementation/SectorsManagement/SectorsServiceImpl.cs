using BussinessLogic.NewsManagement;
using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceImplementation.Extensions.SectorsManagement;
using Datacontracts.SectorsManagement;
using BussinessLogic.SectorsManagement;
using ServiceImplementation.Extensions.AttachmentsManagement;
using Datacontracts.SectionManagement;
using BussinessLogic.SectionManagement;

namespace ServiceInterface.ServiceImplementation.SectorsManagement
{
    public class SectorsManagementServiceImpl : ISectorsManagement
    {
        public EmptyResponse CreateSector(CreateSectorRequest request)
        {
            try
            {
                CreateSectorRequestManager requestManger = new CreateSectorRequestManager( request.SectorToBeSaved.ToBussinessEntity(),
                                                                                           request.AttachmentsToBeSaved.ToBussinessEntity() );
                CreateSectorRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public EmptyResponse UpdateSector(UpdateSectorRequest request)
        {
            try
            {
                UpdateSectorRequestManager requestManger = new UpdateSectorRequestManager( request.SectorToBeSaved.ToBussinessEntity(),
                                                                                           request.AttachmentsToBeSaved.ToBussinessEntity(),
                                                                                           request.AttachmentsToBeUpdated.ToBussinessEntity() );
                UpdateSectorRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public DeleteSectorResponse DeleteSector(DeleteSectorRequest request)
        {
            try
            {
                DeleteSectorRequestManager requestManger = new DeleteSectorRequestManager(request.SectorID);
                DeleteSectorRequestManager.Response bllResponse = requestManger.ProcessRequest();

                DeleteSectorResponse response = new DeleteSectorResponse();
                response.IsDeleted = bllResponse.Success;
                response.FailureReason = bllResponse.FailureReasonCode;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public SearchSectorsResponse SearchSectors(SearchSectorsRequest request)
        {
            try
            {
                SearchSectorsRequestManager requestManger = new SearchSectorsRequestManager( request.Filter.ToFilter() );
                SearchSectorsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchSectorsResponse response = new SearchSectorsResponse();
                response.Count = bllResponse.TotalNumberofRecords;
                response.Sectors = bllResponse.Sectors.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetSectorByIdResponse GetSectorById(GetSectorByIdRequest request)
        {
            try
            {
                GetSectorByIdRequestManager requestManger = new GetSectorByIdRequestManager(request.SectorId);
                GetSectorByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetSectorByIdResponse response = new GetSectorByIdResponse();
                response.Sector = bllResponse.Sector.ToDataContract();
                response.Attachments = bllResponse.Attachments.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetSectionsResponse GetSections(GetSectionsRequest request)
        {
            try
            {
                SearchSectionsRequestManager requestManger = new SearchSectionsRequestManager( request.Filter.ToFilter() );
                SearchSectionsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetSectionsResponse response = new GetSectionsResponse();
                response.Sections = bllResponse.Sections.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse CreateSection(CreateSectionRequest request)
        {
            try
            {
                CreateSectionRequestManager requestManger = new CreateSectionRequestManager(request.SectionToBeSaved.ToBussinessEntity());
                CreateSectionRequestManager.Response bllResponse = requestManger.ProcessRequest();

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
    }
}
