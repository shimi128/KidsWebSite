using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WebExtensions.Events
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ILifetimeScope _lifetimeScope;

        public SubscriptionService(ILifetimeScope dpendencyResolver)
        {
            _lifetimeScope = dpendencyResolver;
        }

        public IList<IConsumer<T>> GetSubscriptions<T>()
        {
            return _lifetimeScope.Resolve<IEnumerable<IConsumer<T>>>().ToList();
        }
    }
}
