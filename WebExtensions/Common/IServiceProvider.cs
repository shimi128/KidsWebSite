using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Common
{
    public interface IServiceProvider
    {
        T GetService<T>();
        object GetService(Type serviceType);
    }
}
