using System;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace WebExtensions.ViewModels
{
    public class BaseViewModel:IBaseViewModel
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

        public FooterModel Footer { get; set; }
        public HeaderModel Header { get; set; }
        public IList<SideNav> SideNav { get; set; }

        public BaseViewModel()
        {
            Footer = new FooterModel();
            Header = new HeaderModel();
            SideNav = new List<SideNav>();
        }
    }
}
