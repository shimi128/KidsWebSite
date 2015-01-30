using System.Text.RegularExpressions;
using Examine;
using Examine.Providers;
using Examine.SearchCriteria;
using WebExtensions.Searchers;

namespace WebExtensions.Services
{
    public class ExternalSearchService : IExternalSearchService
    {
        private readonly BaseSearchProvider _examineSearcher;

        public ExternalSearchService(IExamineSearcherProvider examineSearcherProvider)
        {
            _examineSearcher = examineSearcherProvider.GetSearcher("ExternalSearcher");
        }
        public ISearchResults Search(string text, int homeNodeId)
        {
            var criteria = _examineSearcher.CreateSearchCriteria(BooleanOperation.Or);

            var fixedText = Regex.Replace(text, "\\s", " ");
            var textArr = fixedText.Split(' ');

            textArr[textArr.Length - 1] = textArr[textArr.Length - 1] + "*";

            var query =
                criteria.Field("_fixedPath", homeNodeId.ToString())
                    .And()
                    .GroupedOr(new string[] {"_allContent"}, textArr)
                    .Not()
                    .Field("umbracoNaviHide", "1")
                    .Not()
                    .NodeTypeAlias("Movie");

            return _examineSearcher.Search(query.Compile());
        }
    }
}