using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Converters
{
    class ImagesHomePageConvertor:BaseJsonConverter<List<HomePageImages>>
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.DataTypeId == 1061;
        }
        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            var model=(List<HomePageImages>)base.ConvertSourceToObject(propertyType, source, preview);
            if (model == null)
                return source;
            model.ForEach(x =>
            {
                x.ImageUrl = GetImageUrl(x);
                x.ImageLink = GetInternalLink(x);
            });

            return model;
        }

        private string GetInternalLink(HomePageImages x)
        {
            if (x.InternalLink.GetValueOrDefault() > 0)
                return Umbraco.NiceUrl(x.InternalLink.GetValueOrDefault());

            return "#";
        }

        private string GetImageUrl(HomePageImages x)
        {
            var media = Umbraco.TypedMedia(x.Image.GetValueOrDefault());
            if (media == null)
                return "/images/logo.png";

            return media.GetPropertyValue<string>("umbracoFile");
        }
    }
}
