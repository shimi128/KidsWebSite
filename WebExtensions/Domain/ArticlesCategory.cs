using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class ArticlesCategory:BaseCategories
    {
        public IList<Article> Articles { get; set; }

        public ArticlesCategory()
        {
            Articles = new List<Article>();
        }
    }
}
