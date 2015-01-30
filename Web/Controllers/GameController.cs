using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class GameController : BaseController<Game, GameViewModel>
    {

        public GameController(IMapperProvider mapperProvider)
            : base(mapperProvider)
        {
        }

       

    }
}
