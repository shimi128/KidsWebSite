using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using WebExtensions.ViewModels;


namespace WebExtensions.Extensions
{
    public static class ViewModelMappersExtensions
    {
        private static string[] hideSubMenuTypes = new[] { "", "", "" };
        private static string[] containerTypes = new[] { "", "" };
        public static bool IsContainer(this IPublishedContent content)
        {
            return containerTypes.Contains(content.DocumentTypeAlias);
        }
        public static bool HideInMenu(this IPublishedContent publishedContent)
        {
            return
                hideSubMenuTypes.Any(
                    x => x.Equals(publishedContent.DocumentTypeAlias, StringComparison.InvariantCultureIgnoreCase) || publishedContent.GetPropertyValue<bool>("hideInTopMenu"));

        }



        public static IEnumerable<MenuItem> GetTopMenuItems(this IPublishedContent content)
        {
            var home = content.AncestorOrSelf(1);
            return GetMenuItmes(home, 2,content);
        }



        private static IEnumerable<MenuItem> GetMenuItmes(IPublishedContent parent, int numLevels,IPublishedContent current)
        {
            var children = parent.Children.Where(x => x.IsVisible() && !x.HideInMenu()).Select(x => new MenuItem
            {
                Id = x.Id,
                Target = x.GetPropertyValue<string>("target", "_Self"),
                Name = x.Name,
                Title = x.GetPropertyValue<string>("pageTitle", x.Name),
                Url = x.Url,
                NodeTypeAlias = x.DocumentTypeAlias,
                IsActive = current.Path.Split(',').Contains(x.Id.ToString()),
                Children = numLevels >= 1 ? GetMenuItmes(x, numLevels - 1,current).ToList() : new List<MenuItem>(),
                ImageIconUrl = x.GetCropUrl("imageIcon", "icon")
            });
            
            return children;
        }
    }
}
