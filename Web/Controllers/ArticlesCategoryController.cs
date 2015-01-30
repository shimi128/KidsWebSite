using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class ArticlesCategoryController : BaseController<ArticlesCategory, ArticlesCategoryViewModel>
    {
        public ArticlesCategoryController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}