using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Web;
using Umbraco.Core.Models;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Extensions
{
    public static class Mappers
    {
        public static GameFeature ToGameFeature(this IPublishedContent content)
        {
            return new GameFeature {
                Id = content.Id,
                Name = content.Name,
                Url=content.Url,
                LargeImageUrl = content.GetCropUrl("image", "large"),
                SmallImageUrl = content.GetCropUrl("image", "small")
            };
        }

        public static NewsFeature ToNewsFeature(this IPublishedContent content)
        {
            return new NewsFeature
            {
                Id = content.Id,
                Name = content.Name,
                Url = content.Url,
                LargeImageUrl = content.GetCropUrl("image", "large"),
                SmallImageUrl = content.GetCropUrl("image", "small"),
                HomeImageUrl = content.GetCropUrl("image", "home")
            };
        }

        public static MovieFeature ToMoviewFeature(this IPublishedContent content)
        {
            return new MovieFeature
            {
                Id = content.Id,
                Name = content.Name, 
                Url = content.Url,
                LargeImageUrl = content.GetCropUrl("image", "large"),
                SmallImageUrl = content.GetCropUrl("image", "small"),
                YouTubeUrl=content.HasValue("youtubeurl")?content.GetPropertyValue<string>("youtubeurl"):string.Empty
            };
        }

        public static ImageFeature ToMediaFeature(this IPublishedContent content)
        {
            return new ImageFeature
            {
                 ImageTitle=content.Name,
                 ImageUrl=content.GetPropertyValue<string>("umbracoFile"),
                 MediaImage=content.Url
            };
        }
    }
}
