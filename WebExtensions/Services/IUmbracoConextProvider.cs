using Umbraco.Core;
using Umbraco.Web;

namespace WebExtensions.Services
{
    public interface IUmbracoConextProvider
    {
        UmbracoContext GetUmbracoContext();
        ApplicationContext GetAppContext();
    }
}
