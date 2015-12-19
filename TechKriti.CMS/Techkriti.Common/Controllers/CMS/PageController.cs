using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datacontracts.ContentManagement;
using Common.ContentManagement;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.CMS
{
    public class PageController
    {
        public static bool Save(PageDataContract pageToBeSaved)
        {
            try
            {
                if (pageToBeSaved.Id > 0) return UpdatePage(pageToBeSaved);
                else return AddPage(pageToBeSaved);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddPage(PageDataContract pageToBeSaved)
        {
            CreatePageRequest request = new CreatePageRequest();
            EmptyResponse response = null;
            request.PageToBeSaved = pageToBeSaved;

            using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
            {
                response = client.ServiceChannel.CreatePage(request);
            }

            return response.Success;
        }

        public static bool UpdatePage(PageDataContract pageToBeUpdated)
        {
            UpdatePageRequest request = new UpdatePageRequest();
            request.PageToBeUpdated = pageToBeUpdated;
            EmptyResponse response = null;

            using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
            {
                response = client.ServiceChannel.UpdatePage(request);
            }

            return response.Success;
        }

        public static bool DeletePage(int pageId)
        {
            try
            {
                DeletePageRequest request = new DeletePageRequest();
                EmptyResponse response = null;
                request.PageID = pageId;

                using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
                {
                    response = client.ServiceChannel.DeletePage(request);
                }
               
                return response.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static PageDataContract GetPageById(int pageId)
        {
            try
            {
                GetPageByIdRequest request = new GetPageByIdRequest();
                request.PageId = pageId;
                GetPageByIdResponse response = null;

                using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
                {
                    response = client.ServiceChannel.GetPageById(request);
                }

                return response.Page;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                return null;
            }
        }

        public static List<PageDataContract> SearchPages(string pageTitle, PageStatus status ,int startIndex, int count, out int totalNumnerOfRecords)
        {
            try
            {
                SearchPageRequest request = new SearchPageRequest();
                SearchPageResponse response = null;
                request.Filter.StartIndex = startIndex;
                request.Filter.Count = count;
                request.Filter.Title = pageTitle;
                request.Filter.Status = status;

                using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
                {
                    response = client.ServiceChannel.SearchPages(request);
                }

                totalNumnerOfRecords = response.Count;
                return response.Pages;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}