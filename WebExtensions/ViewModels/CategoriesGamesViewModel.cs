using System.Collections.Generic;
using WebExtensions.Domain;

namespace WebExtensions.ViewModels
{
    public class CategoriesGamesViewModel : BaseCategoriesViewModel
    {
        public IList<SubCategoryGamesViewModel> SubCategoryGames { get; set; }
        public IList<GameViewModel> LastGames { get; set; }

        public CategoriesGamesViewModel()
        {
            SubCategoryGames = new List<SubCategoryGamesViewModel>();
            LastGames=new List<GameViewModel>();
        }
    }
}
