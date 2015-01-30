using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class SubCategoryGames : BaseCategories
    {
        public IList<Game> Games { get; set; }
    }
}
