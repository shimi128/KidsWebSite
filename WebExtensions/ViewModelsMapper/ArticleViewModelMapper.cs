using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;
using Umbraco.Web;

namespace WebExtensions.ViewModelsMapper
{
    public class ArticleViewModelMapper:ViewModelMapper<Article,ArticleViewModel>
    {
        private readonly IArticlesSerivce _articlesService;
        public ArticleViewModelMapper(IUmbracoContextProvider umbracoConextProvider, IArticlesSerivce articlesService) : base(umbracoConextProvider)
        {
            _articlesService = articlesService;
        }

        protected override void Then(Article model, ArticleViewModel viewModel)
        {
            base.Then(model, viewModel);
            var articles = _articlesService.GetAllArticles();
            viewModel.ArticleImageUrl =model.PublishedContent.HasValue("articleImage")?
                model.PublishedContent.GetCropUrl("articleImage", "smallImage") : "http://lorempixel.com/370/240/";
            viewModel.ArticleImageWide =model.PublishedContent.HasValue("articleImage")?
                model.PublishedContent.GetCropUrl("articleImage", "wideImage"):"http://lorempixel.com/770/240/";
           var articlesContent = articles as IList<IPublishedContent> ?? articles.ToList();

            if (articlesContent.Any())
            {
                articlesContent.OrderBy(x => Guid.NewGuid()).Take(15).ForEach(
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
