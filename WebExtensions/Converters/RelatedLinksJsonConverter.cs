using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Converters
{
    public class RelatedLinksJsonConverter:BaseJsonConverter<List<RelatedLink>>
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.DataTypeId == 1040;
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            var model = (List<RelatedLink>) base.ConvertSourceToObject(propertyType, source, preview);

            model.ForEach(x =>
            {
              x.Url = x.IsInternal ? Umbraco.NiceUrl((int.Parse(x.Internal))) : x.Link;
                x.Target = x.NewWindow ? "_blank" : "_self";
            });
            return model;
        }
    }
}
