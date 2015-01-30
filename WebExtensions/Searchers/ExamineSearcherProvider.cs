using Examine;
using Examine.Providers;

namespace WebExtensions.Searchers
{
    public class ExamineSearcherProvider:IExamineSearcherProvider
    {
        public BaseSearchProvider GetSearcher(string searcherName)
        {
            return ExamineManager.Instance.SearchProviderCollection[searcherName];
        }
    }
}
