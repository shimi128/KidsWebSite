using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Converters
{
    class GalleryConverter:BaseJsonConverter<List<MediaFolderFeature>>
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.DataTypeId == 1110;
        }

        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
                return new List<MediaFolderFeature>();

            var items = Umbraco.TypedMedia(source.ToString().Split(',')).Where(x => x != null);
            var images = SetImage(items.FirstOrDefault());

            return images;
        }

        private List<MediaFolderFeature> SetImage(IPublishedContent x)
        {
            var mediaFolder = new List<MediaFolderFeature>();
            var media = Umbraco.TypedMedia(x.Id);
            if (media == null || !media.Children.Any())
            {
                mediaFolder.Add(new MediaFolderFeature { ImageUrl="/images/logo.png"});
            }
            else {
                media.Children.Where(g=> g.DocumentTypeAlias == "Image").ForEach(g => mediaFolder.Add(new MediaFolderFeature
            {
                    ImageUrl=g.Url,
                    Id=g.Id,
                    ImageName=g.Name
            }));
            }

            return mediaFolder;
        }
    }

    
}
