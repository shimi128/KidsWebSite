using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;
using Umbraco.Web;

namespace WebExtensions.ViewModelsMapper
{
    public class BaseCategoriesViewModelMapper<TModel,TViewModel> :ViewModelMapper<TModel,TViewModel>
        where TModel:BaseCategories
        where TViewModel:BaseCategoriesViewModel
    {
        public BaseCategoriesViewModelMapper(IUmbracoContextProvider umbracoConextProvider) : base(umbracoConextProvider)
        {
        }
        protected override void Then(TModel model, TViewModel viewModel)
        {
            base.Then(model, viewModel);
            viewModel.ImageUrl = model.PublishedContent.HasValue("image")
                ? model.PublishedContent.GetPropertyValue<string>("image")
                : string.Empty;
        }
    }
}
