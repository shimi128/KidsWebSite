using Umbraco.Web;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class MovieViewModelMapper:ViewModelMapper<Movie,MovieViewModel>
    {
        public MovieViewModelMapper(IUmbracoContextProvider umbracoConextProvider) : base(umbracoConextProvider)
        {
        }
        protected override void Then(Movie model, MovieViewModel viewModel)
        {
            base.Then(model, viewModel);

            if (model.PublishedContent.HasValue("image"))
            {
                viewModel.LargeImageUrl = model.PublishedContent.GetCropUrl("image", "large");
                viewModel.SmallImageUrl = model.PublishedContent.GetCropUrl("image", "small");
            }
        }
    }
}
