using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class CategoriesGamesController : BaseController<CategoriesGames, CategoriesGamesViewModel>
    {
        public CategoriesGamesController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}
