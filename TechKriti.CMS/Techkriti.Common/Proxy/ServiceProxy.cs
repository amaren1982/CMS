using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Techkriti.Common.Proxy
{
    public class ServiceProxy<T> : ClientBase<T>, IDisposable where T : class
    {
        public ServiceProxy(string endPointConfigurationName) : base(endPointConfigurationName) { }

        public T ServiceChannel { get { return this.Channel; } }

        void IDisposable.Dispose()
        {
            try
            {
                if (this.State != CommunicationState.Faulted) this.Close();
                else this.Abort();
            }
            catch (Exception ex)
            {
                //SWALLOW FOR NOW
                //TO DO LOG EXCEPTION
            }
        }
    }
}