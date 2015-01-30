using System.Collections.Generic;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.ViewModels
{
    public class GalleryViewModel:BaseViewModel
    {
        public string ImageUrl { get; set; }
         public IList<MediaFolderFeature> Media { get; set; }

         public GalleryViewModel()
        {
            Media = new List<MediaFolderFeature>();
        }
    }
}