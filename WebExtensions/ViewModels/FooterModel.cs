using System.Collections.Generic;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.ViewModels
{
    public class FooterModel
    {
        public List<RelatedLink> FooterLink { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string YouTubeLink { get; set; }
        public bool FacebookEnable { get; set; }
        public bool InstagramEnable { get; set; }
        public bool TwitterEnable { get; set; }
        public bool YouTubeEnable { get; set; }
        public string FooterText { get; set; }
    }
}