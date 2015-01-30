using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using WebExtensions.Extensions;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Converters
{
    public class GamesConverter : BaseJsonConverter<List<GameFeature>>
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.DataTypeId == 1058;
        }

        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }


        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
                return new List<GameFeature>();

            var items = Umbraco.TypedContent(source.ToString().Split(',')).Where(x => x != null);
            return items.Select(x => x.ToGameFeature()).ToList();
        }

        public override object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }
    }
}
