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
    public class UsersController
    {
        public static bool SaveUser(UserTypeDataContract userToBeSaved, out string errorMessage)
        {
            try
            {
                if (userToBeSaved.Id > 0) return UpdateUser(userToBeSaved, out errorMessage);
                else return AddUser(userToBeSaved, out errorMessage);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddUser(UserTypeDataContract userToBeSaved, out string errorMessage)
        {
            CreateUserRequest request = new CreateUserRequest();
            CreateUserResponse response = null;
            request.UserToBeSaved = userToBeSaved;

            using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy()) 
            { 
                response = client.ServiceChannel.CreateUser(request); 
            }

            errorMessage = response.FailureReason.ToString();

            return response.Success;
        }

        public static bool UpdateUser(UserTypeDataContract userToBeSaved, out string errorMessage)
        {
            UpdateUserRequest request = new UpdateUserRequest();
            UpdateUserResponse response = null;
            request.UserToBeSaved = userToBeSaved;

            using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
            {
                response = client.ServiceChannel.UpdateUser(request);
            }

            errorMessage = response.FailureReason.ToString();
            return response.Success;
        }

        public static bool DeleteUser(int userId)
        {
            try
            {
                DeleteUserRequest request = new DeleteUserRequest();
                EmptyResponse response = null;
                request.UserID = userId;

                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
                {
                    response = client.ServiceChannel.DeleteUser(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static UserTypeDataContract GetUserById(int userId)
        {
            GetUserByIdResponse response = null;
            try
            {
                GetUserByIdRequest request = new GetUserByIdRequest();
                request.UserId = userId;

                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
                {
                    response = client.ServiceChannel.GetUserById(request);
                }

                return response.User;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<UserTypeDataContract> SearchUsers(string userName, int startIndex, int count, out int totalNumnerOfRecords)
        {
            try
            {
                SearchUsersRequest request = new SearchUsersRequest();
                SearchUsersResponse response = null;

                UsersSearchFilterDataContract filter = new UsersSearchFilterDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;
                if (!string.IsNullOrEmpty(userName)) filter.UserName = userName;

                request.Filter = filter;

                using (UserManagementClient client = ProxyFactory.CreateUserManagementProxy())
                {
                    response = client.ServiceChannel.SearchUsers(request);
                }
                

                totalNumnerOfRecords = response.Count;
                return response.Users;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }
    }
}