using Umbraco.Core;
using Umbraco.Web;

namespace WebExtensions.Services
{
    public interface IUmbracoContextProvider
    {
        UmbracoContext GetUmbracoContext();
        ApplicationContext GetAppContext();
    }
}
