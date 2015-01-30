using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace WebExtensions.Services
{
    public class ArticlesSerivce : IArticlesSerivce
    {
        private readonly UmbracoHelper _umbraco;
        public ArticlesSerivce(IUmbracoContextProvider umbracoContextProvider)
        {
            _umbraco = new UmbracoHelper(umbracoContextProvider.GetUmbracoContext());
        }

        public IEnumerable<IPublishedContent> GetAllArticles()
        {
            var articles = _umbraco.TypedContentAtXPath("//ArticlesCategory/Article['umbracoNaviHide'!='1']");
            return articles;
        }

        public IPublishedContent GetArticleById(int id)
        {
            var article = _umbraco.TypedContent(id);
            return article;
        }
    }
}
