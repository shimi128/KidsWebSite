using System.Collections.Generic;
using WebExtensions.Domain;

namespace WebExtensions.ViewModels
{
    public class CategoriesMoviesViewModel : BaseCategoriesViewModel
    {
        public IList<SubCategoryMoviesViewModel> SubCategoryMovies { get; set; }
        public IList<MovieViewModel> LastMovies { get; set; }

        public CategoriesMoviesViewModel()
        {
            SubCategoryMovies = new List<SubCategoryMoviesViewModel>();
            LastMovies=new List<MovieViewModel>();
        }
    }
}
