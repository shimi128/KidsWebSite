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
    public class CategoriesGamesService:ICategoriesGamesService
    {
        private readonly IContentService _contentService;
        private readonly IContentMapper<CategoriesGames> _contentMapper;

        private readonly UmbracoHelper _umbraco;

        public CategoriesGamesService(IContentService contentService, IContentMapper<CategoriesGames> contentMapper, IUmbracoContextProvider umbracoConextProvider)
        {
            _contentService = contentService;
            _contentMapper = contentMapper;
            _umbraco = new UmbracoHelper(umbracoConextProvider.GetUmbracoContext());
        }

        public IEnumerable<IPublishedContent> GetSubCategoryGames()
        {
            var categoriesGames = _umbraco.TypedContentAtXPath("//CategoriesGames/SubCategoryGames['umbracoNaviHide'!='1']");
            if (categoriesGames.Any())
                return categoriesGames;
            return null;
        }

       
    }
}
