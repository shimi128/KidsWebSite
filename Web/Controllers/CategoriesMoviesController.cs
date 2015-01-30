using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class CategoriesMoviesController : BaseController<CategoriesMovies, CategoriesMoviesViewModel>
    {
        public CategoriesMoviesController(IMapperProvider mapperProvider)
            : base(mapperProvider)
        {
        }
    }
}
