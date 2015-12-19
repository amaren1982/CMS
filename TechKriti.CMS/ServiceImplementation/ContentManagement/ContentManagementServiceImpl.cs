using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.Misc;
using Datacontracts.ContentManagement;
using BussinessLogic.ContentMangement;
using ServiceImplementation.Extensions.ContentManagement;

namespace ServiceInterface.ServiceImplementation.ContentManagement
{
    public class ContentManagementServiceImpl : IContentManagement
    {
        #region IContentManagement Members

        public EmptyResponse CreateMenu(Datacontracts.ContentManagement.CreateMenuRequest request)
        {
            try
            {
                CreateMenuRequestManager requestManger = new CreateMenuRequestManager( request.MenuToBeSaved.ToBussinessEntity() );
                CreateMenuRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public EmptyResponse UpdateMenu(Datacontracts.ContentManagement.UpdateMenuRequest request)
        {
            try
            {
                UpdateMenuRequestManager requestManger = new UpdateMenuRequestManager( request.MenuToBeUpdated.ToBussinessEntity() );
                UpdateMenuRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public DeleteMenuResponse DeleteMenu(Datacontracts.ContentManagement.DeleteMenuRequest request)
        {
            try
            {
                DeleteMenuRequestManager requestManger = new DeleteMenuRequestManager(request.MenuID);
                DeleteMenuRequestManager.Response bllResponse = requestManger.ProcessRequest();

                DeleteMenuResponse response = new DeleteMenuResponse();
                response.IsDeleted = bllResponse.Success;
                response.FailureReason = bllResponse.FailureReasonCode;
                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public GetMenuByIdResponse GetMenuById(Datacontracts.ContentManagement.GetMenuByIdRequest request)
        {
            try
            {
                GetMenuByIdRequestManager requestManger = new GetMenuByIdRequestManager(request.MenuId);
                GetMenuByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetMenuByIdResponse response = new GetMenuByIdResponse();
                response.Menu = bllResponse.Menu.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public SearchMenuResponse SearchMenu(Datacontracts.ContentManagement.SearchMenuRequest request)
        {
            try
            {
                SearchMenusRequestManager requestManger = new SearchMenusRequestManager(request.Filter.ToFilter());
                SearchMenusRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchMenuResponse response = new SearchMenuResponse();
                response.Menus = bllResponse.Menus.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public EmptyResponse CreatePage(CreatePageRequest request)
        {
            try
            {
                CreatePageRequestManager requestManger = new CreatePageRequestManager(request.PageToBeSaved.ToBussinessEntity());
                CreatePageRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public EmptyResponse UpdatePage(UpdatePageRequest request)
        {
            try
            {
                UpdatePageRequestManager requestManger = new UpdatePageRequestManager(request.PageToBeUpdated);
                UpdatePageRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public EmptyResponse DeletePage(DeletePageRequest request)
        {
            try
            {
                DeletePageRequestManager requestManger = new DeletePageRequestManager(request.PageID);
                DeletePageRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public  GetPageByIdResponse GetPageById(GetPageByIdRequest request)
        {
            try
            {
                GetPageByIdRequestManager requestManger = new GetPageByIdRequestManager(request.PageId);
                GetPageByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetPageByIdResponse response = new GetPageByIdResponse();
                response.Page = bllResponse.Page.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public SearchPageResponse SearchPages(SearchPageRequest request)
        {
            try
            {
                SearchPagesRequestManager requestManger = new SearchPagesRequestManager( request.Filter.ToFilter() );
                SearchPagesRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchPageResponse response = new SearchPageResponse();
                response.Pages = bllResponse.Pages.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        #endregion
    }
}
