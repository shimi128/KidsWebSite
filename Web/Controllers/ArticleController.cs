using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class ArticleController:BaseController<Article,ArticleViewModel>
    {
        public ArticleController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}