using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class CategoriesMoviesViewModelMapper : BaseCategoriesViewModelMapper<CategoriesMovies, CategoriesMoviesViewModel>
    {
        private readonly IContentMapper<SubCategoryMovies> _subCategoryMoviesMapper;
        private readonly IContentMapper<Movie> _moviesMapper;
        private readonly IMapperProvider _mapperProvider;
        private readonly IBaseCategoriesService<CategoriesMovies> _categoriesService;

        public CategoriesMoviesViewModelMapper(IUmbracoContextProvider umbracoConextProvider,
            IContentMapper<SubCategoryMovies> subCategoryMoviesMapper,
            IMapperProvider mapperProvider, IContentMapper<Movie> moviesMapper, IBaseCategoriesService<CategoriesMovies> categoriesService
            ) : base(umbracoConextProvider)
        {
            _subCategoryMoviesMapper = subCategoryMoviesMapper;
            _mapperProvider = mapperProvider;
            _moviesMapper = moviesMapper;
            _categoriesService = categoriesService;
        }

        protected override void Then(CategoriesMovies model, CategoriesMoviesViewModel viewModel)
        {
            base.Then(model, viewModel);

            var subCategories = _categoriesService.GetSubCategory();
            var lastGames = _categoriesService.GetLastMovies();

            var publishedContents = subCategories as IList<IPublishedContent> ?? subCategories.ToList();
            if (publishedContents.Any())
            {
                publishedContents.ForEach(
                    x => viewModel.SubCategoryMovies.Add(_mapperProvider.GetViewModelMapper<SubCategoryMovies, SubCategoryMoviesViewModel>().Map(_subCategoryMoviesMapper.Map(x))));
            }
            viewModel.SubCategoryMovies.ForEach(
                    s =>
                    {
                        s.ImageUrl = publishedContents.SingleOrDefault(x => x.Id == s.Id).GetPropertyValue<string>("image");
                    });

            var enumerable = lastGames as IList<IPublishedContent> ?? lastGames.ToList();
            if (enumerable.Any())
            {
                enumerable.ForEach(
                    x =>
                        viewModel.LastMovies.Add(
                            _mapperProvider.GetViewModelMapper<Movie, MovieViewModel>().Map(_moviesMapper.Map(x))));
            }
        }

    }
}
