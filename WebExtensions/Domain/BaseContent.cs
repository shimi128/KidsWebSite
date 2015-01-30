using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace WebExtensions.Domain
{
    public class BaseContent
    {
        public bool IsVisible { get; set; }
        public bool HideSideMenu { get; set; }
        public bool HideTitle { get; set; }
        public int Id { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Path { get; set; }
        public int SortOrder { get; set; }
        public string Url { get; set; }
        public IPublishedContent PublishedContent { get; set; }
        public string Title { get; set; }
        public string PageBody { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }
}
