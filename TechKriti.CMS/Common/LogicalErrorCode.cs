using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum LogicalErrorCode
    {
        None,
        InvalidUser,
        InvalidUsernameOrPassword,
        UserAccountLocked,
        RoleAssignedToUser,
        UsernameAlreadyExists,
        MenuAssignedToPage,
        ChildSectorExists,
        ChildCategoryExists,
        CannotDeleteSubCategoryQualificationExists
    }
}
