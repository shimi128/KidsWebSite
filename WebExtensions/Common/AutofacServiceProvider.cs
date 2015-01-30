using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WebExtensions.Common
{
    public class AutofacServiceProvider:IServiceProvider
    {
        private ILifetimeScope _lifetimeScope;

        public AutofacServiceProvider(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public T GetService<T>()
        {
            return _lifetimeScope.Resolve<T>();
        }

        public object GetService(Type serviceType)
        {
            return _lifetimeScope.Resolve(serviceType);
        }
     
    }
}
