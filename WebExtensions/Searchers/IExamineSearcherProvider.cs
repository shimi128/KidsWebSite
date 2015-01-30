using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examine.Providers;

namespace WebExtensions.Searchers
{
    public interface IExamineSearcherProvider
    {
        BaseSearchProvider GetSearcher(string searcherName);
    }
}
