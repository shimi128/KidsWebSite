using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class NewsCategoryController : BaseController<NewsCategory,NewsCategoryViewModel>
    {
        public NewsCategoryController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}
