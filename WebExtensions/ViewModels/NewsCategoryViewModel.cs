using System.Collections.Generic;
using WebExtensions.Domain;

namespace WebExtensions.ViewModels
{
    public class NewsCategoryViewModel : BaseCategoriesViewModel
    {
        public IList<NewsViewModel> News { get; set; }

         public NewsCategoryViewModel()
        {
            News = new List<NewsViewModel>();
        }
    }
}
