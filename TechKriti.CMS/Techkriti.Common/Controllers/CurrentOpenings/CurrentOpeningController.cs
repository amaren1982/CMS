using Datacontracts.CurrentOpeningManagement;
using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.CurrentOpening
{
    public class CurrentOpeningController
    {
        public static bool Save(CurrentOpeningDataContract currentOpeningToBeSaved)
        {
            try
            {
                if (currentOpeningToBeSaved.Id > 0) return Update(currentOpeningToBeSaved);
                else                                return Add(currentOpeningToBeSaved);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }           
        }

        public static bool Add(CurrentOpeningDataContract currentOpeningToBeSaved)
        {
            CreateCurrentOpeningRequest request = new CreateCurrentOpeningRequest();
            EmptyResponse response = null;
            request.CurrentOpeningToBeSaved = currentOpeningToBeSaved;

            using (CurrentOpeningsManagementClient client = ProxyFactory.CreateCurrentOpeningManagementProxy())
            {
                response = client.ServiceChannel.CreateOpening(request);
            }

            return response.Success;            
        }

        public static bool Update(CurrentOpeningDataContract currentOpeningToBeUpdated)
        {
            UpdateCurrentOpeningRequest request = new UpdateCurrentOpeningRequest();
            EmptyResponse response = null;
            request.CurrentOpeningToBeSaved = currentOpeningToBeUpdated;

            using (CurrentOpeningsManagementClient client = ProxyFactory.CreateCurrentOpeningManagementProxy())
            {
                response = client.ServiceChannel.UpdateOpening(request);
            }

            return response.Success;
        }

        public static bool Delete(int currentOpeningId)
        {
            try
            {
                DeleteCurrentOpeningRequest request = new DeleteCurrentOpeningRequest();
                EmptyResponse response = null;
                request.CurrentOpeningID = currentOpeningId;

                using (CurrentOpeningsManagementClient client = ProxyFactory.CreateCurrentOpeningManagementProxy())
                {
                    response = client.ServiceChannel.DeleteOpening(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                //TO DO LOG 
                throw;
            }
        }

        public static CurrentOpeningDataContract GetCurrentOpeningById(int currentOpeningId)
        {
            GetCurrentOpeningByIdRequest request = new GetCurrentOpeningByIdRequest();
            GetCurrentOpeningByIdResponse response = null;     

            request.CurrentOpeningId = currentOpeningId;              
            try
            {
                using (CurrentOpeningsManagementClient client = ProxyFactory.CreateCurrentOpeningManagementProxy())
                {
                    response = client.ServiceChannel.GetCurrentOpeningById(request);
                }

                return response.CurrentOpening;

            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                return null;
            }
        }

        public static List<CurrentOpeningDataContract> Search(string company, string position, string qualification, string skillSet, string email,
                                                               DateTime? openTillDate, bool? isActive, int? startIndex, int? count, out int totalNumnerOfRecords)
        {
            SearchCurrentOpeningsResponse response = null;
            try
            {
                SearchCurrentOpeningsRequest request = new SearchCurrentOpeningsRequest();
                request.Filter = new CurrentOpeningSearchFilterDataContract();
                request.Filter.Company = company;
                request.Filter.Email = email;
                request.Filter.IsActive = isActive;
                request.Filter.OpenTillDate = openTillDate;
                request.Filter.Position = position;
                request.Filter.Qualification = qualification;
                request.Filter.SkillSet = skillSet;
                request.Filter.StartIndex = startIndex;
                request.Filter.Count = count;

                using (CurrentOpeningsManagementClient client = ProxyFactory.CreateCurrentOpeningManagementProxy())
                {
                    response = client.ServiceChannel.SearchCurrentOpenings(request);
                }

                totalNumnerOfRecords = response.Count;

                return response.CurrentOpenings;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}