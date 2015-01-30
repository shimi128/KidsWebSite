using System.Collections.Generic;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public string EmbedUrl { get; set; }
        public string ShortDescription { get; set; }
        public string LargeImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public string IframeHeight { get; set; }
        public string IframeWidth { get; set; }
    }
}
