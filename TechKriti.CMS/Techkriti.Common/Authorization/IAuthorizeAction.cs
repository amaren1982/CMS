using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.UserManagement;

namespace Techkriti.Common.Authorization
{
    public interface IAuthorizeAction
    {
        Permissions RequiredActionPermission { get; }
        void AuthorizeBasedOnPermissions();
    }
}
