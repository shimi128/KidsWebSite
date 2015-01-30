using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;
using Umbraco.Web;


namespace WebExtensions.ViewModelsMapper
{
    public class NewsViewModelMapper:ViewModelMapper<News,NewsViewModel>
    {
        private readonly INewsService _newsService;
        public NewsViewModelMapper(IUmbracoContextProvider umbracoConextProvider, INewsService newsService)
            : base(umbracoConextProvider)
        {
            _newsService = newsService;
        }

        protected override void Then(News model, NewsViewModel viewModel)
        {
            base.Then(model, viewModel);
            viewModel.LargeImageUrl = model.PublishedContent.GetCropUrl("image", "large");
            viewModel.SmallImageUrl = model.PublishedContent.GetCropUrl("image", "small");

            var news = _newsService.GetAllNews();

            var newsContent = news as IList<IPublishedContent> ?? news.ToList();

            if (newsContent.Any())
            {
                newsContent.ForEach(
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
