using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;
using Umbraco.Web;
using Umbraco.Core;

namespace WebExtensions.ViewModelsMapper
{
    public class GameViewModelMapper : ViewModelMapper<Game, GameViewModel>
    {
        private readonly IBaseCategoriesService<SubCategoryGames> _categoryService;

        public GameViewModelMapper(IUmbracoContextProvider umbracoConextProvider, IBaseCategoriesService<SubCategoryGames> categoryService)
            : base(umbracoConextProvider)
        {
            _categoryService = categoryService;
        }

        protected override void Then(Game model, GameViewModel viewModel)
        {
            base.Then(model, viewModel);

            var games = _categoryService.GetGamesBySubCategoryId(model.PublishedContent.Parent.Id);

            var publishedContent = games as IList<IPublishedContent> ?? games.ToList();

            if (publishedContent.Any())
            {
                publishedContent.OrderBy(x => Guid.NewGuid()).Take(15).ForEach(
                    x =>
                        viewModel.SideNav.Add(new SideNav
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Level = x.Level,
                            SortOrder = x.SortOrder,
                            Url = x.Url
                        }));
            }

            if (model.PublishedContent.HasValue("image"))
            {
                viewModel.LargeImageUrl = model.PublishedContent.GetCropUrl("image", "large");
                viewModel.SmallImageUrl = model.PublishedContent.GetCropUrl("image", "small");
            }
        }
    }
}
