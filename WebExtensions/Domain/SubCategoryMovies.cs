using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class SubCategoryMovies : BaseCategories
    {
        public IList<Movie> Movies { get; set; }
    }
}
