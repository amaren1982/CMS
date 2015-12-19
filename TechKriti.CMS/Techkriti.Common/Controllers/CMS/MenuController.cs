using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datacontracts.ContentManagement;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.CMS
{
    public class MenuController
    {
        public static bool Save(MenuDataContract menuToBeSaved)
        {
            try
            {
                if (menuToBeSaved.Id > 0) return UpdateMenu(menuToBeSaved);
                else return AddMenu(menuToBeSaved);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddMenu(MenuDataContract menuToBeSaved)
        {
            CreateMenuRequest request = new CreateMenuRequest();
            EmptyResponse response = null;
            request.MenuToBeSaved = menuToBeSaved;

            using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
            {
                response = client.ServiceChannel.CreateMenu(request);
            }

            return response.Success;
        }

        public static bool UpdateMenu(MenuDataContract menuToBeUpdated)
        {
            UpdateMenuRequest request = new UpdateMenuRequest();
            request.MenuToBeUpdated = menuToBeUpdated;
            EmptyResponse response = null;

            using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
            {
                response = client.ServiceChannel.UpdateMenu(request);
            }

            return response.Success;
        }

        public static bool DeleteMenu(int menuId, out string errorMessage)
        {
            try
            {
                DeleteMenuRequest request = new DeleteMenuRequest();
                DeleteMenuResponse response = null;
                request.MenuID = menuId;

                using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
                {
                    response = client.ServiceChannel.DeleteMenu(request);
                }

                errorMessage = response.FailureReason.ToString();
                return response.IsDeleted;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static MenuDataContract GetMenuById(int menuId)
        {
            try
            {
                GetMenuByIdRequest request = new GetMenuByIdRequest();
                request.MenuId = menuId;
                GetMenuByIdResponse response = null;

                using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
                {
                    response = client.ServiceChannel.GetMenuById(request);
                }

                return response.Menu;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                return null;
            }
        }

        public static List<MenuDataContract> GetAllMenus()
        {
            try
            {
                SearchMenuRequest request = new SearchMenuRequest();
                SearchMenuResponse response = null;              

                using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
                {
                    response = client.ServiceChannel.SearchMenu(request);
                }
               
                return response.Menus;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<MenuDataContract> SearchMenu(string menuName, bool? isActive,int startIndex, int count, out int totalNumnerOfRecords)
        {
            try
            {
                SearchMenuRequest request = new SearchMenuRequest();
                SearchMenuResponse response = null;
                request.Filter.StartIndex = startIndex;
                request.Filter.Count = count;
                request.Filter.IsActive = isActive;
                request.Filter.MenuName = menuName;

                using (ContentManagementClient client = ProxyFactory.CreateContentManagementProxy())
                {
                    response = client.ServiceChannel.SearchMenu(request);
                }

                totalNumnerOfRecords = response.Count;
                return response.Menus;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}