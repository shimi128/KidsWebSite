using System.Collections.Generic;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Domain
{
    public class Gallery:BaseContent
    {
        public IList<MediaFolderFeature> Media { get; set; }

        public Gallery()
        {
            Media = new List<MediaFolderFeature>();
        }
    }
}