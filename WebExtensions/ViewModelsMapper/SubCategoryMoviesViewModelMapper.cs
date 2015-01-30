using System;
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
    public class SubCategoryMoviesViewModelMapper : BaseCategoriesViewModelMapper<SubCategoryMovies, SubCategoryMoviesViewModel>
    {
        private readonly IContentMapper<Movie> _movieMapper;
        private readonly IMapperProvider _mapperProvider;
        private readonly IBaseCategoriesService<CategoriesMovies> _categoriesService;
        private readonly IBaseCategoriesService<SubCategoryMovies> _categoryService;

        public SubCategoryMoviesViewModelMapper(IUmbracoContextProvider umbracoConextProvider, IBaseCategoriesService<SubCategoryMovies> categoryService,
            IContentMapper<Movie> movieMapper, IMapperProvider mapperProvider, IBaseCategoriesService<CategoriesMovies> categoriesService)
            : base(umbracoConextProvider)
        {
            _categoryService = categoryService;
            _movieMapper = movieMapper;
            _mapperProvider = mapperProvider;
            _categoriesService = categoriesService;
        }

        protected override void Then(SubCategoryMovies model, SubCategoryMoviesViewModel viewModel)
        {
            base.Then(model, viewModel);
            var movies = _categoryService.GetMoviesBySubCategoryId(model.Id);
            var subCategories = _categoriesService.GetSubCategory();

            var publishedContents = movies as IList<IPublishedContent> ?? movies.ToList();

            if (publishedContents.Any())
            {
                publishedContents.ForEach(
                    x =>
                    {
                        var movie = _mapperProvider.GetViewModelMapper<Movie, MovieViewModel>().Map(_movieMapper.Map(x));
                        movie.LargeImageUrl = model.PublishedContent.Children(m => m.Id == x.Id).First().GetCropUrl("image", "large");
                        movie.SmallImageUrl = model.PublishedContent.Children(m => m.Id == x.Id).First().GetCropUrl("image", "small");
                        viewModel.Movies.Add(movie);
                    });
            }
            
            var subCategoriesContent = subCategories as IList<IPublishedContent> ?? subCategories.ToList();

            if (subCategoriesContent.Any())
            {
                subCategoriesContent.OrderBy(x => Guid.NewGuid()).Take(15).ForEach(
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
