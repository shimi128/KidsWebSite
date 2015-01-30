using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using WebExtensions.Domain;

namespace WebExtensions.Services
{
    public interface ICategoriesGamesService
    {
        IEnumerable<IPublishedContent> GetSubCategoryGames();
    }
}
