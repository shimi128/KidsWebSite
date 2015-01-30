using System.Collections.Generic;

namespace WebExtensions.ViewModels
{
    public class ArticlesCategoryViewModel:BaseCategoriesViewModel
    {
         public IList<ArticleViewModel> Articles { get; set; }

         public ArticlesCategoryViewModel()
        {
            Articles = new List<ArticleViewModel>();
        }
    }
}
