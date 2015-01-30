using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using WebExtensions.PropertyEditorTypes;
using WebExtensions.Extensions;

namespace WebExtensions.Converters
{
    public class HomePageMediaConvertor : BaseJsonConverter<List<ImageFeature>>
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.DataTypeId == 1121;
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
                return new List<ImageFeature>();

            var media = Umbraco.TypedMedia(source.ToString().Split(',').Where(x => x != null));
            return media.Select(x => x.ToMediaFeature()).ToList();
        }

        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }

        public override object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }
    }
}
