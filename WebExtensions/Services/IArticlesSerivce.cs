using System.Collections.Generic;
using Umbraco.Core.Models;

namespace WebExtensions.Services
{
    public interface IArticlesSerivce
    {
        IEnumerable<IPublishedContent> GetAllArticles();
        IPublishedContent GetArticleById(int id);
    }
}