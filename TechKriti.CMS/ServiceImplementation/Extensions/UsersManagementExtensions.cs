using Common.UserManagement;
using Datacontracts.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Entities.UsersManagement;

namespace ServiceImplementation.Extensions.UsersManagement
{
    public static class UsersManagementExtensions
    {
        public static List<RoleDataContract> ToDataContract(this List<DAL.Datamodel.Role> items)
        {
            List<RoleDataContract> dc = new List<RoleDataContract>();

            items.ForEach(item => dc.Add(item.ToDataContract()));

            return dc;
        }

        public static RoleDataContract ToDataContract(this DAL.Datamodel.Role item)
        {
            RoleDataContract dc = new RoleDataContract();

            dc.RoleName = item.Name;
            dc.Id = item.Id;
            dc.Description = item.Description;

            return dc;
        }

        public static IRole ToBussinessEntity(this RoleDataContract item)
        {
            IRole bo = new Role();

            bo.Id = item.Id;
            bo.RoleName = item.RoleName;
            bo.Description = item.Description;
            bo.Permissions = item.Permissions;                    

            return bo;
        }

        public static IRolesSearchFilter ToFilter(this RolesSearchFilterDataContract item)
        {
            IRolesSearchFilter filter = new RoleSearchFilter();

            filter.Count = item.Count;
            filter.RoleName = item.RoleName;
            filter.StartIndex = item.StartIndex;

            return filter;
        }

        public static IUser ToBussinessEntity(this UserTypeDataContract item)
        {
            IUser bo = new UserType();

            bo.Id = item.Id;
            bo.Username = item.Username;
            bo.Password = item.Password;
            bo.RoleId = item.RoleId;

            return bo;
        }

        public static IUsersSearchFilter ToFilter(this UsersSearchFilterDataContract item)
        {
            IUsersSearchFilter filter = new UsersSearchFilter();

            filter.Count = item.Count;
            filter.UserName = item.UserName;
            filter.StartIndex = item.StartIndex;

            return filter;
        }

        public static List<UserTypeDataContract> ToDataContract(this List<DAL.Datamodel.User> items)
        {
            List<UserTypeDataContract> dc = new List<UserTypeDataContract>();

            items.ForEach(item => dc.Add(item.ToDataContract()));

            return dc;
        }

        public static UserTypeDataContract ToDataContract(this DAL.Datamodel.User item)
        {
            UserTypeDataContract dc = new UserTypeDataContract();

            dc.Username = item.Username;
            dc.Id = item.UserId;
            dc.Password = item.Password;
            dc.RoleId = item.RoleId;
            dc.LastLogin = item.LastLogin;

            return dc;
        }
    }
}
