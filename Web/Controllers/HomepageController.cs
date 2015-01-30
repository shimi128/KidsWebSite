using System.Web.Mvc;
using Examine;
using Umbraco.Web;
using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class HomepageController : BaseController<HomePage,HomePageViewModel>
    {
        private readonly IExternalSearchService _externalSearchService;

        public HomepageController(IMapperProvider mapperProvider, IExternalSearchService externalSearchService)
            : base(mapperProvider)
        {
            _externalSearchService = externalSearchService;
        }

        public ActionResult SearchResults(string searchTerm)
        {
            ISearchResults results = null;
            if (searchTerm.Length >= 3)
                results = _externalSearchService.Search(searchTerm, CurrentPage.AncestorOrSelf(1).Id);
            var vm = CreateSearchResultsModel(results, searchTerm);

            return View(vm);
        }

        private SearchResultsViewModel CreateSearchResultsModel(ISearchResults results, string q)
        {

            var model = CurrentPage.MapContent<SearchResults, SearchResultsViewModel>(_mapperProvider);
            model.Header.Name = "תוצאות חיפוש";
            model.Results = results;
            if (results == null)
            {
                model.Message = "יש להקיש לפחות 3 תווים על מנת לבצע חיפוש";
            }
            else if (results.TotalItemCount == 0)
            {
                model.Message = string.Format("לא נמצאו תוצאות לחיפוש \"{0}\"", q);

            }
            else
            {
                model.Message = string.Format("נמצאו {0} תוצאות ל \"{1}\"", results.TotalItemCount, q);
            }

            return model;
        }

    }
}
