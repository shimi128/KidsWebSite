using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class NewsController : BaseController<News,NewsViewModel>
    {
        public NewsController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}
