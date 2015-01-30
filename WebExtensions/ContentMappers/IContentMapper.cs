using Umbraco.Core.Models;
using WebExtensions.Domain;

namespace WebExtensions.ContentMappers
{
    public interface IContentMapper<out TContent> where TContent : BaseContent, new()
    {
        TContent Map(IPublishedContent content);
    }
}
