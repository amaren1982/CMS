using BussinessLogic.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceImplementation.Extensions.CurrentOpeningManagement;
using Datacontracts.CurrentOpeningManagement;
using Datacontracts.Misc;

namespace ServiceInterface.ServiceImplementation.CurrentOpenings
{
    public class CurrentOpeningsServiceImpl : ICurrentOpeningsManagement
    {
        public EmptyResponse CreateOpening(CreateCurrentOpeningRequest request)
        {
            try
            {
                CreateCurrentOpeningRequestManager requestManger = new CreateCurrentOpeningRequestManager( request.CurrentOpeningToBeSaved.ToBussinessEntity() );
                CreateCurrentOpeningRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public EmptyResponse UpdateOpening(UpdateCurrentOpeningRequest request)
        {
            try
            {
                UpdateCurrentOpeningRequestManager requestManger = new UpdateCurrentOpeningRequestManager( request.CurrentOpeningToBeSaved.ToBussinessEntity() );
                UpdateCurrentOpeningRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public EmptyResponse DeleteOpening(DeleteCurrentOpeningRequest request)
        {
            try
            {
                DeleteCurrentOpeningRequestManager requestManger = new DeleteCurrentOpeningRequestManager( request.CurrentOpeningID );
                DeleteCurrentOpeningRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                return null;
            }
        }

        public GetCurrentOpeningByIdResponse GetCurrentOpeningById(GetCurrentOpeningByIdRequest request)
        {
            try
            {
                GetCurrentOpeningByIdRequestManager requestManger = new GetCurrentOpeningByIdRequestManager( request.CurrentOpeningId );
                GetCurrentOpeningByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetCurrentOpeningByIdResponse response = new GetCurrentOpeningByIdResponse();
                response.CurrentOpening = bllResponse.CurrentOpening.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public SearchCurrentOpeningsResponse SearchCurrentOpenings(SearchCurrentOpeningsRequest request)
        {
            try
            {   
                SearchCurrentOpeningsRequestManager requestManger = new SearchCurrentOpeningsRequestManager( request.Filter.ToFilter() );
                SearchCurrentOpeningsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchCurrentOpeningsResponse response = new SearchCurrentOpeningsResponse();
                response.CurrentOpenings = bllResponse.CurrentOpenings.ToDatacontract();
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
