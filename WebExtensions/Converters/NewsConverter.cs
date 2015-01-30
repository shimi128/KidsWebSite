﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using WebExtensions.Extensions;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Converters
{
    public  class NewsConverter:BaseJsonConverter<List<NewsFeature>>
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.DataTypeId == 1064;
        }

        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
                return new List<NewsFeature>();

            var items = Umbraco.TypedContent(source.ToString().Split(',')).Where(x => x != null);
            return items.Select(x => x.ToNewsFeature()).ToList();
        }

        public override object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }
    }
}
