using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Common.UserManagement;

namespace Techkriti.Common.Authorization
{
    public class TechKritiPrincipal : IPrincipal
    {
        public List<Permissions> userActions { get; set; }

        public TechKritiPrincipal(IIdentity identity, List<Permissions> userActions)
        {
            this.identity = identity;
            this.userActions = userActions;
        }

        public bool HasPermisson(Permissions userAction)
        {
            return this.userActions.Any(item => item == userAction);
        }

        #region IPrincipal Members

        IIdentity identity;

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role) { return true; }

        #endregion
    }
}
