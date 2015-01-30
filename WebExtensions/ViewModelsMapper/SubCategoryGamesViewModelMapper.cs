using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;
using Umbraco.Web;
using System;

namespace WebExtensions.ViewModelsMapper
{
    public class SubCategoryGamesViewModelMapper : BaseCategoriesViewModelMapper<SubCategoryGames, SubCategoryGamesViewModel>
    {
        private readonly IContentMapper<Game> _gameMapper;
        private readonly IMapperProvider _mapperProvider;
        private readonly IBaseCategoriesService<SubCategoryGames> _categoryService;
        private readonly IBaseCategoriesService<CategoriesGames> _categoriesService;

        public SubCategoryGamesViewModelMapper(IUmbracoContextProvider umbracoConextProvider,IBaseCategoriesService<SubCategoryGames> categoryService,
            IContentMapper<Game> gameMapper, IMapperProvider mapperProvider, IBaseCategoriesService<CategoriesGames> categoriesService)
            : base(umbracoConextProvider)
        {
            _categoryService = categoryService;
            _gameMapper = gameMapper;
            _mapperProvider = mapperProvider;
            _categoriesService = categoriesService;
        }

        protected override void Then(SubCategoryGames model, SubCategoryGamesViewModel viewModel)
        {
            base.Then(model, viewModel);
            var games = _categoryService.GetGamesBySubCategoryId(model.Id);
            var subCategories = _categoriesService.GetSubCategory();
            
            var publishedContents = games as IList<IPublishedContent> ?? games.ToList();

            if (publishedContents.Any())
            {
                publishedContents.ForEach(
                    x =>
                    {
                        var game = _mapperProvider.GetViewModelMapper<Game, GameViewModel>().Map(_gameMapper.Map(x));
                        game.LargeImageUrl = model.PublishedContent.Children(g => g.Id == x.Id).First().GetCropUrl("image", "large");
                        game.SmallImageUrl = model.PublishedContent.Children(g => g.Id == x.Id).First().GetCropUrl("image", "small");
                        viewModel.Games.Add(game);
                    });

            }

            //viewModel.Games.ForEach(x =>
            //{
            //    x.LargeImageUrl = model.PublishedContent.Children(g =>g.Id==x.Id).First().GetCropUrl("image", "large");
            //    x.SmallImageUrl = model.PublishedContent.Children(g => g.Id == x.Id).First().GetCropUrl("image", "small");
            //});

            var subCategoriesContent = subCategories as IList<IPublishedContent> ?? subCategories.ToList();

            if (subCategoriesContent.Any())
            {
                subCategoriesContent.OrderBy(x=>Guid.NewGuid()).Take(15).ForEach(
                    x =>
                        viewModel.SideNav.Add(new SideNav
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Url = x.Url,
                            Level = x.Level,
                            SortOrder = x.SortOrder
                        }));
            }
        }
    }
}
