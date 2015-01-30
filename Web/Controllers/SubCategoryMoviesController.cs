using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class SubCategoryMoviesController : BaseController<SubCategoryMovies, SubCategoryMoviesViewModel>
    {
        public SubCategoryMoviesController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}
