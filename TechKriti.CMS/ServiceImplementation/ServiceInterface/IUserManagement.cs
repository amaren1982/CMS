using Datacontracts.Misc;
using Datacontracts.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
    [ServiceContract]
    public interface IUserManagement
    {
        [OperationContract]
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);

        [OperationContract]
        EmptyResponse CreateRole(CreateRoleRequest request);

        [OperationContract]
        EmptyResponse UpdateRole(UpdateRoleRequest request);

        [OperationContract]
        DeleteRoleResponse DeleteRole(DeleteRoleRequest request);

        [OperationContract]
        GetRoleByIdResponse GetRoleById(GetRoleByIdRequest request);

        [OperationContract]
        SearchRolesResponse SearchRoles(SearchRolesRequest request);

        [OperationContract]
        CreateUserResponse CreateUser(CreateUserRequest request);

        [OperationContract]
        UpdateUserResponse UpdateUser(UpdateUserRequest request);

        [OperationContract]
        EmptyResponse DeleteUser(DeleteUserRequest request);

        [OperationContract]
        GetUserByIdResponse GetUserById(GetUserByIdRequest request);

        [OperationContract]
        SearchUsersResponse SearchUsers(SearchUsersRequest request);
    }
}
