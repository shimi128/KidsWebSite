using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class SubCategoryGamesController : BaseController<SubCategoryGames, SubCategoryGamesViewModel>
    {
        public SubCategoryGamesController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}
