using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class NewsCategoryViewModelMapper : ViewModelMapper<NewsCategory, NewsCategoryViewModel>
    {
        private readonly IMapperProvider _mapperProvider;
        private readonly INewsService _newsService;
        private readonly IContentMapper<News> _contentMapper;
        public NewsCategoryViewModelMapper(IUmbracoContextProvider umbracoConextProvider, IContentMapper<News> contentMapper,
            IMapperProvider mapperProvider, INewsService newsService)
            : base(umbracoConextProvider)
        {
            _contentMapper = contentMapper;
            _mapperProvider = mapperProvider;
            _newsService = newsService;
        }
        protected override void Then(NewsCategory model, NewsCategoryViewModel viewModel)
        {
            base.Then(model, viewModel);

            var news = _newsService.GetAllNews();

            var publishedContents = news as IList<IPublishedContent> ?? news.ToList();

            if (publishedContents.Any())
            {
                publishedContents.ForEach(
                    x =>
                        viewModel.News.Add(
                            _mapperProvider.GetViewModelMapper<News, NewsViewModel>().Map(_contentMapper.Map(x))));
            }
        }
        
    }
}
