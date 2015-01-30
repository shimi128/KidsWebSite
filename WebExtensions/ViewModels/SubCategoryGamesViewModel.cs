using System.Collections.Generic;
using WebExtensions.Domain;

namespace WebExtensions.ViewModels
{
    public class SubCategoryGamesViewModel : BaseCategoriesViewModel
    {
        public IList<GameViewModel> Games { get; set; }

        public SubCategoryGamesViewModel()
        {
            Games = new List<GameViewModel>();
        }
    }
}
