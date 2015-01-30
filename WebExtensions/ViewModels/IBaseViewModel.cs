using System;
using Umbraco.Core.Models;

namespace WebExtensions.ViewModels
{
    public interface IBaseViewModel
    {
        bool IsVisible { get; }
        int Id { get; }
        string CreatorName { get; }
        DateTime CreateDate { get; }
        DateTime UpdateDate { get; }
        string Name { get; }
        int Level { get; }
        string Path { get; }
        int SortOrder { get; }
        string Url { get; }
        IPublishedContent PublishedContent { get; }
        string PageTitle { get; }
        string MetaKeywords { get; }
        string MetaDescription { get; }
       
    }
}
