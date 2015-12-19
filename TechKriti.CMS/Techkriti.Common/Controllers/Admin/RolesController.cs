using Datacontracts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.UserManagement;
using Datacontracts.UserManagement;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.Admin
{
    public class RolesController
    {
        public static bool SaveRole(RoleDataContract roleToBeSaved)
        {
            try
            {
                if (roleToBeSaved.Id > 0) return UpdateRole(roleToBeSaved);
                else return AddRole(roleToBeSaved);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddRole(RoleDataContract roleToBeSaved)
        {
            CreateRoleRequest request = new CreateRoleRequest();
            EmptyResponse response = null;
            request.RoleToBeSaved = roleToBeSaved;

            using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy()) 
            { 
                response = client.ServiceChannel.CreateRole(request); 
            }

            return response.Success;
        }

        public static bool UpdateRole(RoleDataContract roleToBeSaved)
        {
            UpdateRoleRequest request = new UpdateRoleRequest();
            EmptyResponse response = null;
            request.RoleToBeSaved = roleToBeSaved;

            using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
            {
                response = client.ServiceChannel.UpdateRole(request);
            }

            return response.Success;
        }

        public static bool DeleteRole(int roleId, out string errorMessage)
        {
            try
            {
                DeleteRoleRequest request = new DeleteRoleRequest();
                DeleteRoleResponse response = null;
                request.RoleID = roleId;

                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
                {
                    response = client.ServiceChannel.DeleteRole(request);
                }

                errorMessage = response.FailureReason.ToString();
                return response.IsDeleted;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static RoleDataContract GetRoleById(int roleId)
        {
            GetRoleByIdResponse response = null;
            try
            {
                GetRoleByIdRequest request = new GetRoleByIdRequest();
                request.RoleId = roleId;

                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
                {
                    response = client.ServiceChannel.GetRoleById(request);
                }

                return response.Role;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<RoleDataContract> GetAllRoles()
        {
            try
            {
                SearchRolesRequest request = new SearchRolesRequest();
                SearchRolesResponse response = null;

                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
                {
                    response = client.ServiceChannel.SearchRoles(request);
                }
               
                return response.Roles;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<RoleDataContract> SearchRoles(string roleName, int startIndex, int count, out int totalNumnerOfRecords)
        {
            try
            {
                SearchRolesRequest request = new SearchRolesRequest();
                SearchRolesResponse response = null;

                RolesSearchFilterDataContract filter = new RolesSearchFilterDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;
                if (!string.IsNullOrEmpty(roleName)) filter.RoleName = roleName;
                request.Filter = filter;

                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
                {
                    response = client.ServiceChannel.SearchRoles(request);
                }               

                totalNumnerOfRecords = response.Count;
                return response.Roles;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}