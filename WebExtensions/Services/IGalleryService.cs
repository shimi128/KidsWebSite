using System.Collections.Generic;
using Umbraco.Core.Models;

namespace WebExtensions.Services
{
    public interface IGalleryService
    {
        IEnumerable<IPublishedContent> GetAllGalleries();
    }
}