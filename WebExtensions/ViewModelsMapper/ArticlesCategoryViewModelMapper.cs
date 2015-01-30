using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class ArticlesCategoryViewModelMapper:BaseCategoriesViewModelMapper<ArticlesCategory,ArticlesCategoryViewModel>
    {
        private readonly IMapperProvider _mapperProvider;
        private readonly IArticlesSerivce _articlesService;
        private readonly IContentMapper<Article> _contentMapper;

        public ArticlesCategoryViewModelMapper(IUmbracoContextProvider umbracoConextProvider, IContentMapper<Article> contentMapper,
            IMapperProvider mapperProvider,IArticlesSerivce articlesService): base(umbracoConextProvider)
        {
            _contentMapper = contentMapper;
            _mapperProvider = mapperProvider;
            _articlesService = articlesService;
        }

        protected override void Then(ArticlesCategory model, ArticlesCategoryViewModel viewModel)
        {
            base.Then(model, viewModel);
            var articles = _articlesService.GetAllArticles();

            var publishedContents = articles as IList<IPublishedContent> ?? articles.ToList();

            if (publishedContents.Any())
            {
                publishedContents.ForEach(
                    x =>
                        viewModel.Articles.Add(
                            _mapperProvider.GetViewModelMapper<Article, ArticleViewModel>().Map(_contentMapper.Map(x))));
            }
        }
    }
}
