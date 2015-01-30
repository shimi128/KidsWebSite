using System.Collections.Generic;
using Umbraco.Core.Models;

namespace WebExtensions.Services
{
    public interface INewsService
    {
        IEnumerable<IPublishedContent> GetAllNews();
        IPublishedContent GetNewsById(int id);
    }
}