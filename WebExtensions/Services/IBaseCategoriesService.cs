using System.Collections.Generic;
using Umbraco.Core.Models;
using WebExtensions.Domain;

namespace WebExtensions.Services
{
    public interface IBaseCategoriesService<T> where T : BaseCategories, new()
    {
        IEnumerable<IPublishedContent> GetSubCategory();
        IEnumerable<IPublishedContent> GetGamesBySubCategoryId(int id);
        IEnumerable<IPublishedContent> GetMoviesBySubCategoryId(int id);
        IEnumerable<IPublishedContent> GetLastGames();
        IEnumerable<IPublishedContent> GetLastMovies();
    }
}