using System.Collections.Generic;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.ViewModels
{
    public class HeaderModel
    {
        
        public string FacebookLink { get; set; }
        public string Name { get; set; }
        public IList<RelatedLink> HeaderLinks { get; set; }
        public IList<MenuItem> Menu { get; set; }
        public HomePageModel HomePage { get; set; }
        public IList<KeyValuePair<string, string>> BreadCrumbs { get; set; }



        public HeaderModel()
        {
            Menu = new List<MenuItem>();
            HeaderLinks = new List<RelatedLink>();
            BreadCrumbs = new List<KeyValuePair<string, string>>();
            HomePage = new HomePageModel();
        }
    }
}