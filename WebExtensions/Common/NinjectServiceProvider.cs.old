using Ninject;

namespace WebExtensions.Common
{
    public class NinjectServiceProvider : IServiceProvider
    {
        private readonly IKernel _kernel;

        public NinjectServiceProvider(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public object GetService(System.Type serviceType)
        {
           return  _kernel.GetService(serviceType);
        }
    }
}
