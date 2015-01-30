using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class CategoriesGames : BaseCategories
    {
        public IList<SubCategoryGames> SubCategoryGames { get; set; }
    }
}
