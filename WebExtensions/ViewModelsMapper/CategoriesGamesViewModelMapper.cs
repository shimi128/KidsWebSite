using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Converters;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;
using Umbraco.Web;

namespace WebExtensions.ViewModelsMapper
{
    public class CategoriesGamesViewModelMapper : BaseCategoriesViewModelMapper<CategoriesGames, CategoriesGamesViewModel>
    {
        
        private readonly IContentMapper<SubCategoryGames> _subCategoryGamesMapper;
        private readonly IContentMapper<Game> _gamesMapper;
        private readonly IMapperProvider _mapperProvider;
        private readonly IBaseCategoriesService<CategoriesGames> _categoriesService;


        public CategoriesGamesViewModelMapper(IUmbracoContextProvider umbracoConextProvider, 
            IContentMapper<SubCategoryGames> subCategoryGamesMapper,
            IMapperProvider mapperProvider,IContentMapper<Game> gamesMapper,IBaseCategoriesService<CategoriesGames> categoriesService )
            : base(umbracoConextProvider)
        {
            
            _subCategoryGamesMapper = subCategoryGamesMapper;
            _mapperProvider = mapperProvider;
            _gamesMapper = gamesMapper;
            _categoriesService = categoriesService;
        }

        protected override void Then(CategoriesGames model, CategoriesGamesViewModel viewModel)
        {
            base.Then(model, viewModel);

            var subCategories = _categoriesService.GetSubCategory();
            var lastGames = _categoriesService.GetLastGames();

            var publishedContents = subCategories as IList<IPublishedContent> ?? subCategories.ToList();
            if (publishedContents.Any())
            {
                publishedContents.ForEach(x => viewModel.SubCategoryGames.Add(_mapperProvider.GetViewModelMapper<SubCategoryGames,SubCategoryGamesViewModel>().Map(_subCategoryGamesMapper.Map(x))));
                viewModel.SubCategoryGames.ForEach(
                    s =>
                    {
                        s.ImageUrl = publishedContents.SingleOrDefault(x => x.Id == s.Id).GetPropertyValue<string>("image");
                    });
            }

            var enumerable = lastGames as IList<IPublishedContent> ?? lastGames.ToList();
            if (enumerable.Any())
            {
                enumerable.ForEach(
                    x =>
                        viewModel.LastGames.Add(
                            _mapperProvider.GetViewModelMapper<Game, GameViewModel>().Map(_gamesMapper.Map(x))));
            }
        }
            
        }
    }

