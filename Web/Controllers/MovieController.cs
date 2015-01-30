using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class MovieController : BaseController<Movie,MovieViewModel>
    {
        public MovieController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}
