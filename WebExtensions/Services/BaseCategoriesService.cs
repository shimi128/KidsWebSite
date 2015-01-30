using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;

namespace WebExtensions.Services
{
    public class BaseCategoriesService<T> : IBaseCategoriesService<T> where T:BaseCategories, new()
    {
        private readonly IContentService _contentService;
        private readonly IContentMapper<T> _contentMapper;
        
        private readonly UmbracoHelper _umbraco;

        public BaseCategoriesService(IContentService contentService, IContentMapper<T> contentMapper, IUmbracoContextProvider umbracoConextProvider)
        {
            _contentService = contentService;
            _contentMapper = contentMapper;
            _umbraco = new UmbracoHelper(umbracoConextProvider.GetUmbracoContext());
        }

        public IEnumerable<IPublishedContent> GetSubCategory()
        {
            var type = GetType().GenericTypeArguments.First(x=>x!=null).Name;

            if (string.IsNullOrWhiteSpace(type))
                return null;

            var xpath = "//" + type + "/SubCategory" + type.Remove(0,10) + "['umbracoNaviHide'!='1']";
            var subCategories = _umbraco.TypedContentAtXPath(xpath);
            if (subCategories.Any())
                return subCategories;

            return null;
        }

        public IEnumerable<IPublishedContent> GetGamesBySubCategoryId(int id)
        {
            var games = _umbraco.TypedContentAtXPath(string.Format("//SubCategoryGames[@id='{0}']/Game['umbracoNaviHide'!='1']", id));
            if (games.Any())
                return games;

            return null;
        }

        public IEnumerable<IPublishedContent> GetMoviesBySubCategoryId(int id)
        {
            var movies = _umbraco.TypedContentAtXPath(string.Format("//SubCategoryMovies[@id='{0}']/Movie['umbracoNaviHide'!='1']", id));
            if (movies.Any())
                return movies;

            return null;
        }

        public IEnumerable<IPublishedContent> GetLastGames()
        {
            var lastGames = _umbraco.TypedContentAtXPath("//CategoriesGames/SubCategoryGames/Game['umbracoNaviHide'!='1']").OrderByDescending(x=>x.CreateDate);
            if (lastGames.Any())
                return lastGames.Take(10);
            return null;
        }

        public IEnumerable<IPublishedContent> GetLastMovies()
        {
            var lastMovies = _umbraco.TypedContentAtXPath("//CategoriesMovies/SubCategoryMovies/Movie['umbracoNaviHide'!='1']").OrderByDescending(x => x.CreateDate);
            if (lastMovies.Any())
                return lastMovies.Take(10);
            return null;
        }
    }
}
