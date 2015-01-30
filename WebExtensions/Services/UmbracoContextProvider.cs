using Umbraco.Core;
using Umbraco.Web;

namespace WebExtensions.Services
{
    public class UmbracoContextProvider : IUmbracoContextProvider
    {
        public UmbracoContext GetUmbracoContext()
        {
            return UmbracoContext.Current;
        }

        public ApplicationContext GetAppContext()
        {
            return ApplicationContext.Current;
        }
    }
}
