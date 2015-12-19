using BussinessLogic.UserMangement;
using Datacontracts.Misc;
using Datacontracts.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceImplementation.Extensions.UsersManagement;

namespace ServiceInterface.ServiceImplementation.UserManagement
{
    public class UserManagementServiceImpl : IUserManagement
    {
        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            try
            {
                UserManagementRequestManager requestManager = new UserManagementRequestManager(request.Username, request.Password);
                UserManagementRequestManager.Response bllResponse = requestManager.ProcessRequest();

                AuthenticateUserResponse response = new AuthenticateUserResponse();
                response.IsUserAuthentic = bllResponse.IsUserAuthentic;
                response.FailureReason = bllResponse.FailureReasonCode;
                response.User = bllResponse.User.ToDataContract();
                response.Permissions = bllResponse.Role.PermissionsInRoles
                                           .Select(item => (Common.UserManagement.Permissions)item.PermissionId)
                                           .ToList();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public EmptyResponse CreateRole(CreateRoleRequest request)
        {
            try
            {
                CreateRoleRequestManager requestManger = new CreateRoleRequestManager( request.RoleToBeSaved.ToBussinessEntity() );
                CreateRoleRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public EmptyResponse UpdateRole(UpdateRoleRequest request)
        {
            try
            {
                UpdateRoleManagementRequestManager requestManger = new UpdateRoleManagementRequestManager(request
                                                                                                          .RoleToBeSaved
                                                                                                          .ToBussinessEntity());
                UpdateRoleManagementRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public DeleteRoleResponse DeleteRole(DeleteRoleRequest request)
        {
            try
            {
                DeleteRoleRequestManager requestManger = new DeleteRoleRequestManager(request.RoleID);
                DeleteRoleRequestManager.Response bllResponse = requestManger.ProcessRequest();

                DeleteRoleResponse response = new DeleteRoleResponse();
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

        public GetRoleByIdResponse GetRoleById(GetRoleByIdRequest request)
        {
            try
            {
                GetRoleByIdRequestManager requestManger = new GetRoleByIdRequestManager(request.RoleId);
                GetRoleByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetRoleByIdResponse response = new GetRoleByIdResponse();
                response.Role = bllResponse.Role.ToDataContract();
                response.Role.Permissions = bllResponse.Role.PermissionsInRoles
                                            .Select(item => (Common.UserManagement.Permissions)item.PermissionId)
                                            .ToList();               

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public SearchRolesResponse SearchRoles(SearchRolesRequest request)
        {
            try
            {
                SearchRolesRequestManager requestManger = new SearchRolesRequestManager(request.Filter.ToFilter());
                SearchRolesRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchRolesResponse response = new SearchRolesResponse();

                response.Roles = bllResponse.Roles.ToDataContract();               
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            try
            {
                CreateUserRequestManager requestManger = new CreateUserRequestManager(request.UserToBeSaved.ToBussinessEntity());
                CreateUserRequestManager.Response bllResponse = requestManger.ProcessRequest();

                CreateUserResponse response = new CreateUserResponse();
                response.Success = bllResponse.Success;
                response.FailureReason = bllResponse.FailureReasonCode;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            try
            {
                UpdateUserManagementRequestManager requestManger = new UpdateUserManagementRequestManager(request.UserToBeSaved.ToBussinessEntity());
                UpdateUserManagementRequestManager.Response bllResponse = requestManger.ProcessRequest();

                UpdateUserResponse response = new UpdateUserResponse();
                response.Success = bllResponse.Success;
                response.FailureReason = bllResponse.FailureReasonCode;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse DeleteUser(DeleteUserRequest request)
        {
            try
            {
                DeleteUserRequestManager requestManger = new DeleteUserRequestManager(request.UserID);
                DeleteUserRequestManager.Response bllResponse = requestManger.ProcessRequest();

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

        public GetUserByIdResponse GetUserById(GetUserByIdRequest request)
        {
            try
            {
                GetUserByIdRequestManager requestManger = new GetUserByIdRequestManager(request.UserId);
                GetUserByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetUserByIdResponse response = new GetUserByIdResponse();                
                response.User = bllResponse.User.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public SearchUsersResponse SearchUsers(SearchUsersRequest request)
        {
            try
            {
                SearchUsersRequestManager requestManger = new SearchUsersRequestManager( request.Filter.ToFilter() );
                SearchUsersRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchUsersResponse response = new SearchUsersResponse();
                response.Count = bllResponse.TotalNumberofRecords;
                response.Users = bllResponse.Users.ToDataContract();               

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
