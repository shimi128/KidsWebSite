using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;

namespace WebExtensions.Services
{
    public class NewsService : INewsService
    {
        private readonly UmbracoHelper _umbraco;

        public NewsService(IUmbracoContextProvider umbracoContextProvider)
        {
            _umbraco = new UmbracoHelper(umbracoContextProvider.GetUmbracoContext());
        }

        public IEnumerable<IPublishedContent> GetAllNews()
        {
            var news = _umbraco.TypedContentAtXPath("//NewsCategory/News['umbracoNaviHide'!='1']");
            return news;
        }

        public IPublishedContent GetNewsById(int id)
        {
            var news = _umbraco.TypedContent(id);
            return news;
        }
    }
}
