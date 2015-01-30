using System.Collections.Generic;
using WebExtensions.Domain;

namespace WebExtensions.ViewModels
{
    public class SubCategoryMoviesViewModel : BaseCategoriesViewModel
    {
        public IList<MovieViewModel> Movies { get; set; }

        public SubCategoryMoviesViewModel()
        {
            Movies = new List<MovieViewModel>();
        }
    }
}
